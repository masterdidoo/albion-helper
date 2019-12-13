using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

/// <remarks />
[GeneratedCode("xsd", "4.6.1055.0")]
[Serializable]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
[XmlRoot("AO-Resources", Namespace = "", IsNullable = false)]
public class AOResources
{
    //[System.Xml.Serialization.XmlElementAttribute("Harvestables", typeof(AOResourcesHarvestables), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [XmlElement("Resources", typeof(AOResourcesResources), Form = XmlSchemaForm.Unqualified)]
    public object[] Items { get; set; }
}

/// <remarks />
[GeneratedCode("xsd", "4.6.1055.0")]
[Serializable]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class AOResourcesResources
{
    [XmlElement("Resource", Form = XmlSchemaForm.Unqualified)]
    public AOResourcesResourcesResource[] Resource { get; set; }
}

[GeneratedCode("xsd", "4.6.1055.0")]
[Serializable]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class AOResourcesResourcesResource
{
    [XmlElement("ResourceTier", Form = XmlSchemaForm.Unqualified)]
    public AOResourcesResourcesResourceResourceTier[] ResourceTier { get; set; }

    [XmlAttribute] public string name { get; set; }
}

/// <remarks />
[GeneratedCode("xsd", "4.6.1055.0")]
[Serializable]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class AOResourcesResourcesResourceResourceTier
{
    [XmlAttribute] public int value { get; set; }

    [XmlAttribute] public double resourcevalue { get; set; }

    [XmlAttribute] public double famevalue { get; set; }
}