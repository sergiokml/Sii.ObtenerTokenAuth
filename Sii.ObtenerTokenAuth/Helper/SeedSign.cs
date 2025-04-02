using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace Sii.ObtenerTokenAuth.Helper;

public class SeedSign
{
    public string SignSeedAsync(string xml, X509Certificate2 cert)
    {
        XmlDocument xmlDocument = new() { PreserveWhitespace = true };
        xmlDocument.LoadXml(xml);
        SignedXml signedXml = new(xmlDocument) { SigningKey = cert.GetRSAPrivateKey() };
        KeyInfo keyInfo = new();
        keyInfo.AddClause(new RSAKeyValue(cert.GetRSAPrivateKey()!));
        keyInfo.AddClause(new KeyInfoX509Data(cert));
        Reference reference = new() { Uri = "" };
        reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
        Signature signature = signedXml.Signature;
        signature.SignedInfo!.AddReference(reference);
        signature.KeyInfo = keyInfo;
        signedXml.ComputeSignature();
        xmlDocument.DocumentElement!.AppendChild(xmlDocument.ImportNode(signedXml.GetXml(), true));
        return xmlDocument.InnerXml;
    }
}
