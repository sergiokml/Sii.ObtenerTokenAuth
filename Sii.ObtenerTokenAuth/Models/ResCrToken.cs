namespace Sii.ObtenerTokenAuth.Models;

public class ResCrToken
{
    // NOTA: El código generado puede requerir, como mínimo, .NET Framework 4.5 o .NET Core/Standard 2.0.
    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(
        AnonymousType = true,
        Namespace = "http://www.sii.cl/XMLSchema"
    )]
    [System.Xml.Serialization.XmlRoot(
        Namespace = "http://www.sii.cl/XMLSchema",
        IsNullable = false
    )]
    public partial class RESPUESTA
    {
        private RESPUESTARESP_BODY? rESP_BODYField;

        private RESPUESTARESP_HDR? rESP_HDRField;

        /// <remarks/>
        public RESPUESTARESP_BODY RESP_BODY
        {
            get => rESP_BODYField!;
            set => rESP_BODYField = value;
        }

        /// <remarks/>
        public RESPUESTARESP_HDR RESP_HDR
        {
            get => rESP_HDRField!;
            set => rESP_HDRField = value;
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(
        AnonymousType = true,
        Namespace = "http://www.sii.cl/XMLSchema"
    )]
    public partial class RESPUESTARESP_BODY
    {
        private string? tOKENField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "")]
        public string TOKEN
        {
            get => tOKENField!;
            set => tOKENField = value;
        }
    }

    /// <remarks/>
    [Serializable()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(
        AnonymousType = true,
        Namespace = "http://www.sii.cl/XMLSchema"
    )]
    public partial class RESPUESTARESP_HDR
    {
        private byte eSTADOField;

        private string? gLOSAField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "")]
        public byte ESTADO
        {
            get => eSTADOField;
            set => eSTADOField = value;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Namespace = "")]
        public string GLOSA
        {
            get => gLOSAField!;
            set => gLOSAField = value;
        }
    }
}
