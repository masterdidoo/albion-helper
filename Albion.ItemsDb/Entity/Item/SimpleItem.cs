using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;
using Albion.Db.Xml.Enums;
using Albion.Db.Xml.Requirements;

namespace Albion.Db.Xml.Entity.Item
{
    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class SimpleItem : IItem, IItemCraftingcategory, IItemEnchantmentLevel, IItemValued, IItemSalvageable
    {
        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("replacementitem", typeof(itemsSimpleitemReplaceondeathReplacementitem),
            Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public itemsSimpleitemReplaceondeathReplacementitem[] replaceondeath { get; set; }


        [XmlAttribute] public string weight { get; set; }


        [XmlAttribute] public string maxstacksize { get; set; }


        [XmlAttribute] public string uisprite { get; set; }


        [XmlAttribute] public string unlockedtocraft { get; set; }


        [XmlAttribute] public float itemvalue { get; set; }


        [XmlAttribute] public string showinmarketplace { get; set; }


        [XmlAttribute] public string nutrition { get; set; }


        [XmlAttribute] public string foodcategory { get; set; }


        [XmlAttribute] public string resourcetype { get; set; }


        [XmlAttribute] public string craftfamegainfactor { get; set; }


        [XmlAttribute] public int enchantmentlevel { get; set; }


        [XmlAttribute] public string fishingfame { get; set; }


        [XmlAttribute] public string fishingminigamesetting { get; set; }


        [XmlAttribute] public string descriptionlocatag { get; set; }


        [XmlAttribute] public string fasttravelfactor { get; set; }


        [XmlAttribute] public string namelocatag { get; set; }


        [XmlAttribute] public bool salvageable { get; set; }


        [XmlAttribute] public string descvariable0 { get; set; }


        [XmlAttribute] public string descvariable1 { get; set; }


        [XmlAttribute] public string uicraftsoundstart { get; set; }


        [XmlAttribute] public string uicraftsoundfinish { get; set; }


        [XmlAttribute] public string canbestoredinbattlevault { get; set; }


        [XmlAttribute] public int tier { get; set; }


        [XmlAttribute] public shopCategory shopcategory { get; set; }


        [XmlAttribute] public shopSubCategory shopsubcategory1 { get; set; }


        [XmlElement("craftingrequirements")] public Craftingrequirements[] craftingrequirements { get; set; }


        [XmlAttribute] public string uniquename { get; set; }


        [XmlAttribute] public string craftingcategory { get; set; }
    }
}