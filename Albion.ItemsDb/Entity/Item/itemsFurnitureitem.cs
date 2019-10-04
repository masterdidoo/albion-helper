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
    public class ItemsFurnitureitem : IItem, IItemEnchantmentLevel
    {
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string cheatprovider { get; set; }


        [XmlElement("craftingrequirements")] public Craftingrequirements[] craftingrequirements { get; set; }


        [XmlElement("container", Form = XmlSchemaForm.Unqualified)]
        public itemsFurnitureitemContainer[] container { get; set; }


        [XmlElement("repairkit", Form = XmlSchemaForm.Unqualified)]
        public itemsFurnitureitemRepairkit[] repairkit { get; set; }


        [XmlAttribute] public shopSubCategory shopsubcategory1 { get; set; }


        [XmlAttribute] public int tier { get; set; }


        [XmlAttribute] public string durability { get; set; }


        [XmlAttribute] public string durabilitylossperdayfactor { get; set; }


        [XmlAttribute] public string weight { get; set; }


        [XmlAttribute] public string unlockedtocraft { get; set; }


        [XmlAttribute] public string placeableindoors { get; set; }


        [XmlAttribute] public string placeableoutdoors { get; set; }


        [XmlAttribute] public string placeableindungeons { get; set; }


        [XmlAttribute] public string accessrightspreset { get; set; }


        [XmlAttribute] public string uicraftsoundstart { get; set; }


        [XmlAttribute] public string uicraftsoundfinish { get; set; }


        [XmlAttribute] public string customizewithguildlogo { get; set; }


        [XmlAttribute] public int enchantmentlevel { get; set; }


        [XmlAttribute] public string uisprite { get; set; }


        [XmlAttribute] public string tile { get; set; }


        [XmlAttribute] public string itemvalue { get; set; }


        [XmlAttribute] public string showinmarketplace { get; set; }


        [XmlAttribute] public string residencyslots { get; set; }


        [XmlAttribute] public string labourerfurnituretype { get; set; }


        [XmlAttribute] public string labourersaffected { get; set; }


        [XmlAttribute] public string labourerhappiness { get; set; }


        [XmlAttribute] public string labourersperfurnitureitem { get; set; }


        [XmlAttribute] public string placeableonlyonislands { get; set; }


        [XmlAttribute] public string descriptionlocatag { get; set; }


        [XmlAttribute] public string craftfamegainfactor { get; set; }


        [XmlAttribute] public string durabilitylossperusefactor { get; set; }


        [XmlAttribute] public string uniquename { get; set; }


        [XmlAttribute] public shopCategory shopcategory { get; set; }
    }
}