using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

/// <remarks />
[GeneratedCode("xsd", "4.6.1055.0")]
[Serializable]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class rementsResource
{
    /// <remarks />
    [XmlAttribute]
    public string uniquename { get; set; }

    /// <remarks />
    [XmlAttribute]
    public int count { get; set; }

    /// <remarks />
    [XmlAttribute]
    public string maxreturnamount { get; set; }

    /// <remarks />
    [XmlAttribute]
    public int enchantmentlevel { get; set; }
}