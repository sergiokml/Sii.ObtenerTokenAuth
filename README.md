﻿[![](https://img.shields.io/badge/License-GPLv3-blue.svg?style=for-the-badge)](LICENSE.txt)
[![.NET](https://img.shields.io/badge/.NET-8.0-blueviolet?style=for-the-badge)](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
[![GitHub commit activity](https://img.shields.io/github/commit-activity/w/sergiokml/Sii.ObtenerTokenAuth?style=for-the-badge)](https://github.com/sergiokml/Sii.ObtenerTokenAuth)
[![GitHub contributors](https://img.shields.io/github/contributors/sergiokml/Sii.ObtenerTokenAuth?style=for-the-badge)](https://github.com/sergiokml/Sii.ObtenerTokenAuth/graphs/contributors/)
[![GitHub code size in bytes](https://img.shields.io/github/languages/code-size/sergiokml/Sii.ObtenerTokenAuth?style=for-the-badge)](https://github.com/sergiokml/Sii.ObtenerTokenAuth)


# Obtener Token de autorización SII

This solution demonstrates how to programmatically obtain an authentication token from Chile's [Servicio de Impuestos Internos](https://www.sii.cl/) using WCF SOAP services. It makes use of the following official SOAP endpoints:

- [CrSeed.jws](https://palena.sii.cl/DTEWS/CrSeed.jws)
- [GetTokenFromSeed.jws](https://palena.sii.cl/DTEWS/GetTokenFromSeed.jws)

It includes:

- Minimal API for secure access to SOAP services  
- XML Digital Signature using a .pfx certificate  
- Digital certificate retrieval from Azure Blob Storage  

> This repository has no relationship with the government entity [SII](https://www.sii.cl/), only for educational purposes.

---

### 📦 Details

| Package Reference            | Version |
|-----------------------------|:-------:|
| Azure.Storage.Blobs         | 12.24.0 |
| Microsoft.Extensions.Azure  | 1.7.6   |

---

### 🚀 Usage

This solution exposes a **Minimal API** endpoint that allows you to request through a simple HTTP GET. Once the app is running, you can call the endpoint:

```bash
curl http://localhost:5058/api/token \
  -H "Accept: application/json"
```

The response will be a JSON payload with the token issued by the SII :

```json
{
  "token": "XYZ123456789",
  "fecha": "2025-04-02T17:00:00Z"
}
```

---

### ⚙️ Configuration

Use `appsettings.json` or environment variables to configure the certificate source:

```json
{
  "StorageConnection": "UseDevelopmentStorage=true",
  "StorageConnection:ContainerName": "certificados",
  "StorageConnection:BlobName": "certificado1.pfx",
  "StorageConnection:CertPassword": "<your-cert-password>"
}
```

You may also define these as [Azure App Settings](https://learn.microsoft.com/en-us/azure/app-service/configure-common) if you're deploying the API to the cloud.

---

### 📢 Have a question? Found a Bug?

Feel free to **file a new issue** with a respective title and description on the [Sii.ObtenerTokenAuth/issues](https://github.com/sergiokml/Sii.ObtenerTokenAuth/issues) repository.

---

### 💖 Community and Contributions

If this tool was useful, consider contributing with ideas or improving it further.


<p align="center">
    <a href="https://www.paypal.com/donate/?hosted_button_id=PTKX9BNY96SNJ" target="_blank">
        <img width="12%" src="https://img.shields.io/badge/PayPal-00457C?style=for-the-badge&logo=paypal&logoColor=white" alt="Azure Function">
    </a>
</p>

---

### 📘 License

All my repository content is released under the terms of the [GNU General Public License v3.0](LICENSE.txt).
