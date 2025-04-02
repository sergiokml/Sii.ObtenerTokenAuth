using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using Microsoft.Extensions.Azure;
using ServiceCrSeed;
using ServiceGetTokenFromSeed;
using Sii.ObtenerTokenAuth.Helper;
using Sii.ObtenerTokenAuth.Models;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<DigitalCertLoader>();
builder.Services.AddSingleton<SeedSign>();


builder.Services.AddAzureClients(clientBuilder =>
{
    clientBuilder.AddBlobServiceClient(builder.Configuration["StorageConnection"]!);
});

WebApplication app = builder.Build();
app.UseHttpsRedirection();

app.MapGet(
    "/api/token",
    async (DigitalCertLoader certLoader, SeedSign seedSign) =>
    {
        try
        {
            using CrSeedClient _crSeedClient = new();
            string seed = await _crSeedClient.getSeedAsync();
            ResCrSeed.RESPUESTA seedResult = Deserialize<ResCrSeed.RESPUESTA>(seed);

            if (seedResult.RESP_HDR.ESTADO != 0)
                return Results.Problem("Error obtaining seed from SII.");

            string seedXml =
                $"<getToken><item><Semilla>{seedResult.RESP_BODY.SEMILLA}</Semilla></item></getToken>";
            X509Certificate2 cert = await certLoader.LoadCertificateAsync();
            string signedSeed = seedSign.SignSeedAsync(seedXml, cert);
            using GetTokenFromSeedClient _getTokenFromSeedClient = new();
            string tokenResponse = await _getTokenFromSeedClient.getTokenAsync(signedSeed);
            ResCrToken.RESPUESTA token = Deserialize<ResCrToken.RESPUESTA>(tokenResponse);

            return token.RESP_HDR.ESTADO != 0 || token.RESP_HDR.GLOSA != "Token Creado"
                ? Results.Problem("Error obtaining token from SII.")
                : Results.Ok(new { Token = token.RESP_BODY.TOKEN, Fecha = DateTime.UtcNow });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] {ex.Message}");
            return Results.Problem(
                detail: ex.Message,
                statusCode: 500,
                title: "Unexpected error while generating token"
            );
        }
    }
);

await app.RunAsync();

static T Deserialize<T>(string xml)
{
    XmlSerializer serializer = new(typeof(T));
    using StringReader reader = new(xml);
    return (T)serializer.Deserialize(reader)!;
}
