using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;
using Albion.Db.Xml.Entity.Common;
using Albion.Db.Xml.Enums;
using Albion.Db.Xml.Requirements;

namespace Albion.Db.Xml.Entity.Item
{
    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class Weapon : IItem, IItemCraftingcategory, IItemEnchantments, IItemPowered, IItemSalvageable
    {
        [XmlElement("projectile", Form = XmlSchemaForm.Unqualified)]
        public itemsWeaponProjectile[] projectile { get; set; }


        [XmlElement("canharvest", Form = XmlSchemaForm.Unqualified)]
        public itemsWeaponCanharvest[] canharvest { get; set; }


        [XmlElement("craftingrequirements")] public Craftingrequirements[] craftingrequirements { get; set; }

        [XmlElement("AudioInfo")] public AudioInfo[] AudioInfo { get; set; }


        [XmlElement("SocketPreset")] public SocketPreset[] SocketPreset { get; set; }


        [XmlArrayItem("craftspell", typeof(craftingspelllistCraftspell), Form = XmlSchemaForm.Unqualified,
            IsNullable = false)]
        public craftingspelllistCraftspell[] craftingspelllist { get; set; }


        [XmlElement("AssetVfxPreset")] public AssetVfxPreset[] AssetVfxPreset { get; set; }


        [XmlAttribute] public string mesh { get; set; }


        [XmlAttribute] public string uisprite { get; set; }


        [XmlAttribute] public string maxqualitylevel { get; set; }


        [XmlAttribute] public string abilitypower { get; set; }


        [XmlAttribute] public string slottype { get; set; }


        [XmlAttribute] public string attacktype { get; set; }


        [XmlAttribute] public string attackdamage { get; set; }


        [XmlAttribute] public string attackspeed { get; set; }


        [XmlAttribute] public string attackrange { get; set; }


        [XmlAttribute] public string twohanded { get; set; }


        [XmlAttribute] public string weight { get; set; }


        [XmlAttribute] public string activespellslots { get; set; }


        [XmlAttribute] public string passivespellslots { get; set; }


        [XmlAttribute] public string durability { get; set; }


        [XmlAttribute] public string durabilityloss_attack { get; set; }


        [XmlAttribute] public string durabilityloss_spelluse { get; set; }


        [XmlAttribute] public string durabilityloss_receivedattack { get; set; }


        [XmlAttribute] public string durabilityloss_receivedspell { get; set; }


        [XmlAttribute] public string mainhandanimationtype { get; set; }


        [XmlAttribute] public bool unlockedtocraft { get; set; }


        [XmlAttribute] public string unlockedtoequip { get; set; }


        [XmlAttribute] public int itempower { get; set; }


        [XmlAttribute] public string unequipincombat { get; set; }


        [XmlAttribute] public string uicraftsoundstart { get; set; }


        [XmlAttribute] public string uicraftsoundfinish { get; set; }


        [XmlAttribute] public string canbeovercharged { get; set; }


        [XmlAttribute] public string attackbuildingdamage { get; set; }


        [XmlAttribute] public string fishing { get; set; }


        [XmlAttribute] public string fishingspeed { get; set; }


        [XmlAttribute] public string physicalspelldamagebonus { get; set; }


        [XmlAttribute] public string magicspelldamagebonus { get; set; }


        [XmlAttribute] public string fxbonename { get; set; }


        [XmlAttribute] public string fxboneoffset { get; set; }


        [XmlAttribute] public string hitpointsmax { get; set; }


        [XmlAttribute] public string hitpointsregenerationbonus { get; set; }


        [XmlAttribute] public string itempowerprogressiontype { get; set; }


        [XmlAttribute] public string focusfireprotectionpeneration { get; set; }


        [XmlAttribute] public string healmodifier { get; set; }


        [XmlAttribute] public string showinmarketplace { get; set; }


        [XmlAttribute] public string attackdamagetimefactor { get; set; }


        [XmlAttribute] public shopSubCategory shopsubcategory1 { get; set; }


        [XmlAttribute] public int tier { get; set; }


        [XmlAttribute] public string uniquename { get; set; }


        [XmlAttribute] public shopCategory shopcategory { get; set; }


        [XmlAttribute] public string craftingcategory { get; set; }


        [XmlArrayItem("enchantment", typeof(EnchantmentsEnchantment), Form = XmlSchemaForm.Unqualified,
            IsNullable = false)]
        public EnchantmentsEnchantment[] enchantments { get; set; }

        public bool salvageable => true;
    }
}