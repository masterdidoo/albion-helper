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
    public class Mount : IItem, IItemPowered
    {
        [XmlElement("craftingrequirements")] public Craftingrequirements[] craftingrequirements { get; set; }


        [XmlElement("SocketPreset")] public SocketPreset[] SocketPreset { get; set; }


        [XmlElement("AudioInfo")] public AudioInfo[] AudioInfo { get; set; }


        [XmlElement("FootStepVfxPreset", Form = XmlSchemaForm.Unqualified)]
        public itemsMountFootStepVfxPreset[] FootStepVfxPreset { get; set; }


        [XmlElement("AssetVfxPreset")] public AssetVfxPreset[] AssetVfxPreset { get; set; }


        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("mountspell", typeof(itemsMountMountspelllistMountspell), Form = XmlSchemaForm.Unqualified,
            IsNullable = false)]
        public itemsMountMountspelllistMountspell[] mountspelllist { get; set; }


        [XmlArrayItem("craftspell", typeof(craftingspelllistCraftspell), Form = XmlSchemaForm.Unqualified,
            IsNullable = false)]
        public craftingspelllistCraftspell[] craftingspelllist { get; set; }


        [XmlAttribute] public string mountcategory { get; set; }


        [XmlAttribute] public string maxqualitylevel { get; set; }


        [XmlAttribute] public int itempower { get; set; }


        [XmlAttribute] public string abilitypower { get; set; }


        [XmlAttribute] public string slottype { get; set; }


        [XmlAttribute] public shopSubCategory shopsubcategory1 { get; set; }


        [XmlAttribute] public string mountedbuff { get; set; }


        [XmlAttribute] public string halfmountedbuff { get; set; }


        [XmlAttribute] public int tier { get; set; }


        [XmlAttribute] public string weight { get; set; }


        [XmlAttribute] public string activespellslots { get; set; }


        [XmlAttribute] public string passivespellslots { get; set; }


        [XmlAttribute] public string durability { get; set; }


        [XmlAttribute] public string durabilityloss_attack { get; set; }


        [XmlAttribute] public string durabilityloss_spelluse { get; set; }


        [XmlAttribute] public string durabilityloss_receivedattack { get; set; }


        [XmlAttribute] public string durabilityloss_receivedspell { get; set; }


        [XmlAttribute] public string durabilityloss_receivedattack_mounted { get; set; }


        [XmlAttribute] public string durabilityloss_receivedspell_mounted { get; set; }


        [XmlAttribute] public string durabilityloss_mounting { get; set; }


        [XmlAttribute] public string unlockedtocraft { get; set; }


        [XmlAttribute] public string unlockedtoequip { get; set; }


        [XmlAttribute] public string mounttime { get; set; }


        [XmlAttribute] public string dismounttime { get; set; }


        [XmlAttribute] public string mounthitpointsmax { get; set; }


        [XmlAttribute] public string mounthitpointsregeneration { get; set; }


        [XmlAttribute] public string prefabname { get; set; }


        [XmlAttribute] public string prefabscaling { get; set; }


        [XmlAttribute] public string despawneffect { get; set; }


        [XmlAttribute] public string despawneffectscaling { get; set; }


        [XmlAttribute] public string remountdistance { get; set; }


        [XmlAttribute] public string halfmountrange { get; set; }


        [XmlAttribute] public string forceddismountcooldown { get; set; }


        [XmlAttribute] public string forceddismountspellcooldown { get; set; }


        [XmlAttribute] public string fulldismountcooldown { get; set; }


        [XmlAttribute] public string remounttime { get; set; }


        [XmlAttribute] public string uicraftsoundstart { get; set; }


        [XmlAttribute] public string uicraftsoundfinish { get; set; }


        [XmlAttribute] public string dismountbuff { get; set; }


        [XmlAttribute] public string uisprite { get; set; }


        [XmlAttribute] public string showinmarketplace { get; set; }


        [XmlAttribute] public string enchantmentlevel { get; set; }


        [XmlAttribute] public string canuseingvg { get; set; }


        [XmlAttribute] public string itemvalue { get; set; }


        [XmlAttribute] public string nametagoffset { get; set; }


        [XmlAttribute] public string craftfamegainfactor { get; set; }


        [XmlAttribute] public string uniquename { get; set; }


        [XmlAttribute] public shopCategory shopcategory { get; set; }
    }
}