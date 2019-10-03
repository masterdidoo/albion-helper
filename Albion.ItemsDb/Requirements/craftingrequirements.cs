using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Albion.ItemsDb.Requirements
{
    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class Craftingrequirements
    {
        [XmlElement("playerfactionstanding", Form = XmlSchemaForm.Unqualified)]
        public craftingrequirementsPlayerfactionstanding[] playerfactionstanding { get; set; }


        [XmlElement("currency", Form = XmlSchemaForm.Unqualified)]
        public craftingrequirementsCurrency[] currency { get; set; }


        [XmlElement("craftresource", Form = XmlSchemaForm.Unqualified)]
        public rementsResource[] craftresource { get; set; }


        [XmlAttribute] public long silver { get; set; }


        [XmlAttribute] public string time { get; set; }


        [XmlAttribute] public string swaptransaction { get; set; }


        [XmlAttribute] public int amountcrafted { get; set; } = 1;


        [XmlAttribute] public string craftingfocus { get; set; }


        [XmlAttribute] public string buildingfilter { get; set; }


        [XmlAttribute] public string forcesinglecraft { get; set; }


        [XmlAttribute] public string gold { get; set; }


        [XmlAttribute] public string compensategold { get; set; }
    }
}