using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;
using Albion.Db.Xml.Enums;
using Albion.Db.Xml.Requirements;

namespace Albion.Db.Xml.Entity
{
    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class Equipmentitem : IItem, IItemCraftingcategory, IItemEnchantments, IItemPowered
    {
        [XmlElement("craftingrequirements")] public Craftingrequirements[] craftingrequirements { get; set; }


        [XmlElement("SocketPreset")] public SocketPreset[] SocketPreset { get; set; }


        [XmlElement("AssetVfxPreset")] public AssetVfxPreset[] AssetVfxPreset { get; set; }


        [XmlArrayItem("enchantment", typeof(EnchantmentsEnchantment), Form = XmlSchemaForm.Unqualified,
            IsNullable = false)]
        public EnchantmentsEnchantment[] enchantments { get; set; }


        [XmlArrayItem("craftspell", typeof(craftingspelllistCraftspell), Form = XmlSchemaForm.Unqualified,
            IsNullable = false)]
        public craftingspelllistCraftspell[] craftingspelllist { get; set; }


        [XmlElement("AudioInfo")] public AudioInfo[] AudioInfo { get; set; }


        [XmlAttribute] public string uisprite { get; set; }


        [XmlAttribute] public string maxqualitylevel { get; set; }


        [XmlAttribute] public string abilitypower { get; set; }


        [XmlAttribute] public string slottype { get; set; }


        [XmlAttribute] public string itempowerprogressiontype { get; set; }


        [XmlAttribute] public shopSubCategory shopsubcategory1 { get; set; }


        [XmlAttribute] public string uicraftsoundstart { get; set; }


        [XmlAttribute] public string uicraftsoundfinish { get; set; }


        [XmlAttribute] public string skincount { get; set; }


        [XmlAttribute] public int tier { get; set; }


        [XmlAttribute] public string weight { get; set; }


        [XmlAttribute] public string activespellslots { get; set; }


        [XmlAttribute] public string passivespellslots { get; set; }


        [XmlAttribute] public string physicalarmor { get; set; }


        [XmlAttribute] public string magicresistance { get; set; }


        [XmlAttribute] public string durability { get; set; }


        [XmlAttribute] public string durabilityloss_attack { get; set; }


        [XmlAttribute] public string durabilityloss_spelluse { get; set; }


        [XmlAttribute] public string durabilityloss_receivedattack { get; set; }


        [XmlAttribute] public string durabilityloss_receivedspell { get; set; }


        [XmlAttribute] public string offhandanimationtype { get; set; }


        [XmlAttribute] public string unlockedtocraft { get; set; }


        [XmlAttribute] public string unlockedtoequip { get; set; }


        [XmlAttribute] public string hitpointsmax { get; set; }


        [XmlAttribute] public string hitpointsregenerationbonus { get; set; }


        [XmlAttribute] public string energymax { get; set; }


        [XmlAttribute] public string energyregenerationbonus { get; set; }


        [XmlAttribute] public string crowdcontrolresistance { get; set; }


        [XmlAttribute] public int itempower { get; set; }


        [XmlAttribute] public string physicalattackdamagebonus { get; set; }


        [XmlAttribute] public string magicattackdamagebonus { get; set; }


        [XmlAttribute] public string physicalspelldamagebonus { get; set; }


        [XmlAttribute] public string magicspelldamagebonus { get; set; }


        [XmlAttribute] public string healbonus { get; set; }


        [XmlAttribute] public string bonusccdurationvsplayers { get; set; }


        [XmlAttribute] public string bonusccdurationvsmobs { get; set; }


        [XmlAttribute] public string threatbonus { get; set; }


        [XmlAttribute] public string magiccooldownreduction { get; set; }


        [XmlAttribute] public string bonusdefensevsplayers { get; set; }


        [XmlAttribute] public string bonusdefensevsmobs { get; set; }


        [XmlAttribute] public string magiccasttimereduction { get; set; }


        [XmlAttribute] public string attackspeedbonus { get; set; }


        [XmlAttribute] public string movespeedbonus { get; set; }


        [XmlAttribute] public string healmodifier { get; set; }


        [XmlAttribute] public string canbeovercharged { get; set; }


        [XmlAttribute] public string showinmarketplace { get; set; }


        [XmlAttribute] public string energycostreduction { get; set; }


        [XmlAttribute] public string tradable { get; set; }


        [XmlAttribute] public string movespeed { get; set; }


        [XmlAttribute] public string maxload { get; set; }


        [XmlAttribute] public string facestate { get; set; }


        [XmlAttribute] public string requiredaccesslevel { get; set; }


        [XmlAttribute] public string uispriteoverlay { get; set; }


        [XmlAttribute] public string beardstate { get; set; }


        [XmlAttribute] public string mesh { get; set; }


        [XmlAttribute] public string craftfamegainfactor { get; set; }


        [XmlAttribute] public string enchantmentlevel { get; set; }


        [XmlAttribute] public string mainhandanimationtype { get; set; }


        [XmlAttribute] public string descriptionlocatag { get; set; }


        [XmlAttribute] public string uniquename { get; set; }


        [XmlAttribute] public shopCategory shopcategory { get; set; }


        [XmlAttribute] public string craftingcategory { get; set; }
    }
}