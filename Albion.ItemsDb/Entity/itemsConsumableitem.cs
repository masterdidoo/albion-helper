using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;
using Albion.ItemsDb.Enums;
using Albion.ItemsDb.Requirements;

namespace Albion.ItemsDb.Entity
{
    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class ItemsConsumableitem : IItem, IItemEnchantments, IItemPowered2
    {
        [XmlAttribute] public string fishingfame { get; set; }


        [XmlAttribute] public string fishingminigamesetting { get; set; }


        [XmlAttribute] public string descriptionlocatag { get; set; }


        [XmlAttribute] public string uisprite { get; set; }


        [XmlAttribute] public string nutrition { get; set; }


        [XmlAttribute] public string abilitypower { get; set; }


        [XmlAttribute] public string slottype { get; set; }


        [XmlAttribute] public string consumespell { get; set; }


        [XmlAttribute] public string resourcetype { get; set; }


        [XmlAttribute] public string weight { get; set; }


        [XmlAttribute] public int dummyitempower { get; set; }


        [XmlAttribute] public string maxstacksize { get; set; }


        [XmlAttribute] public string unlockedtocraft { get; set; }


        [XmlAttribute] public string unlockedtoequip { get; set; }


        [XmlAttribute] public string uicraftsoundstart { get; set; }


        [XmlAttribute] public string uicraftsoundfinish { get; set; }


        [XmlAttribute] public string uispriteoverlay { get; set; }


        [XmlAttribute] public string tradable { get; set; }

        [XmlArrayItem("enchantment", typeof(EnchantmentsEnchantment), Form = XmlSchemaForm.Unqualified,
            IsNullable = false)]
        public EnchantmentsEnchantment[] enchantments { get; set; }


        [XmlAttribute] public shopSubCategory shopsubcategory1 { get; set; }


        [XmlAttribute] public int tier { get; set; }


        [XmlElement("craftingrequirements")] public Craftingrequirements[] craftingrequirements { get; set; }


        [XmlAttribute] public string uniquename { get; set; }


        [XmlAttribute] public shopCategory shopcategory { get; set; }
    }
}