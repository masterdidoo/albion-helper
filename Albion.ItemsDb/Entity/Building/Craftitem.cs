using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Albion.Db.Xml.Entity.Building
{
    /// <remarks />
    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class CraftItem
    {
        [XmlAttribute] public string uniquename { get; set; }


        [XmlAttribute] public string displaygroup { get; set; }


        [XmlAttribute] public string category { get; set; }


        [XmlAttribute] public string stacksize { get; set; }
    }
}