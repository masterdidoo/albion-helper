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
    public class EnchantmentsEnchantment
    {
        [XmlElement("craftingrequirements")] public Craftingrequirements[] craftingrequirements { get; set; }


        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("upgraderesource", typeof(rementsResource),
            Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public rementsResource[] upgraderequirements { get; set; }


        [XmlAttribute] public int enchantmentlevel { get; set; }


        [XmlAttribute] public string abilitypower { get; set; }


        [XmlAttribute] public string dummyitempower { get; set; }


        [XmlAttribute] public string consumespell { get; set; }


        [XmlAttribute] public string nutrition { get; set; }


        [XmlAttribute] public string weight { get; set; }


        [XmlAttribute] public string itempower { get; set; }


        [XmlAttribute] public string durability { get; set; }
    }
}