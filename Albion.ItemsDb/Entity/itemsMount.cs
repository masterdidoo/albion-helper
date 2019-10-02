using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Albion.ItemsDb.Entity
{
    /// <remarks />
    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class itemsMount : IItem
    {
        private string abilitypowerField;

        private string activespellslotsField;

        private AssetVfxPreset[] assetVfxPresetField;

        private AudioInfo[] audioInfoField;

        private string canuseingvgField;

        private string craftfamegainfactorField;

        private craftingrequirements[] craftingrequirementsField;

        private craftingspelllistCraftspell[] craftingspelllistField;

        private string despawneffectField;

        private string despawneffectscalingField;

        private string dismountbuffField;

        private string dismounttimeField;

        private string durabilityField;

        private string durabilityloss_attackField;

        private string durabilityloss_mountingField;

        private string durabilityloss_receivedattack_mountedField;

        private string durabilityloss_receivedattackField;

        private string durabilityloss_receivedspell_mountedField;

        private string durabilityloss_receivedspellField;

        private string durabilityloss_spelluseField;

        private string enchantmentlevelField;

        private itemsMountFootStepVfxPreset[] footStepVfxPresetField;

        private string forceddismountcooldownField;

        private string forceddismountspellcooldownField;

        private string fulldismountcooldownField;

        private string halfmountedbuffField;

        private string halfmountrangeField;

        private string itempowerField;

        private string itemvalueField;

        private string maxqualitylevelField;

        private string mountcategoryField;

        private string mountedbuffField;

        private string mounthitpointsmaxField;

        private string mounthitpointsregenerationField;

        private itemsMountMountspelllistMountspell[] mountspelllistField;

        private string mounttimeField;

        private string nametagoffsetField;

        private string passivespellslotsField;

        private string prefabnameField;

        private string prefabscalingField;

        private string remountdistanceField;

        private string remounttimeField;

        private string shopcategoryField;

        private string shopsubcategory1Field;

        private string showinmarketplaceField;

        private string slottypeField;

        private SocketPreset[] socketPresetField;

        private string tierField;

        private string uicraftsoundfinishField;

        private string uicraftsoundstartField;

        private string uispriteField;

        private string uniquenameField;

        private string unlockedtocraftField;

        private string unlockedtoequipField;

        private string weightField;

        /// <remarks />
        [XmlElement("craftingrequirements")]
        public craftingrequirements[] craftingrequirements
        {
            get => craftingrequirementsField;
            set => craftingrequirementsField = value;
        }

        /// <remarks />
        [XmlElement("SocketPreset")]
        public SocketPreset[] SocketPreset
        {
            get => socketPresetField;
            set => socketPresetField = value;
        }

        /// <remarks />
        [XmlElement("AudioInfo")]
        public AudioInfo[] AudioInfo
        {
            get => audioInfoField;
            set => audioInfoField = value;
        }

        /// <remarks />
        [XmlElement("FootStepVfxPreset", Form = XmlSchemaForm.Unqualified)]
        public itemsMountFootStepVfxPreset[] FootStepVfxPreset
        {
            get => footStepVfxPresetField;
            set => footStepVfxPresetField = value;
        }

        /// <remarks />
        [XmlElement("AssetVfxPreset")]
        public AssetVfxPreset[] AssetVfxPreset
        {
            get => assetVfxPresetField;
            set => assetVfxPresetField = value;
        }

        /// <remarks />
        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("mountspell", typeof(itemsMountMountspelllistMountspell), Form = XmlSchemaForm.Unqualified,
            IsNullable = false)]
        public itemsMountMountspelllistMountspell[] mountspelllist
        {
            get => mountspelllistField;
            set => mountspelllistField = value;
        }

        /// <remarks />
        [XmlArrayItem("craftspell", typeof(craftingspelllistCraftspell), Form = XmlSchemaForm.Unqualified,
            IsNullable = false)]
        public craftingspelllistCraftspell[] craftingspelllist
        {
            get => craftingspelllistField;
            set => craftingspelllistField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string mountcategory
        {
            get => mountcategoryField;
            set => mountcategoryField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string maxqualitylevel
        {
            get => maxqualitylevelField;
            set => maxqualitylevelField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string itempower
        {
            get => itempowerField;
            set => itempowerField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string abilitypower
        {
            get => abilitypowerField;
            set => abilitypowerField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string slottype
        {
            get => slottypeField;
            set => slottypeField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string shopsubcategory1
        {
            get => shopsubcategory1Field;
            set => shopsubcategory1Field = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string mountedbuff
        {
            get => mountedbuffField;
            set => mountedbuffField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string halfmountedbuff
        {
            get => halfmountedbuffField;
            set => halfmountedbuffField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string tier
        {
            get => tierField;
            set => tierField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string weight
        {
            get => weightField;
            set => weightField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string activespellslots
        {
            get => activespellslotsField;
            set => activespellslotsField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string passivespellslots
        {
            get => passivespellslotsField;
            set => passivespellslotsField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string durability
        {
            get => durabilityField;
            set => durabilityField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string durabilityloss_attack
        {
            get => durabilityloss_attackField;
            set => durabilityloss_attackField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string durabilityloss_spelluse
        {
            get => durabilityloss_spelluseField;
            set => durabilityloss_spelluseField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string durabilityloss_receivedattack
        {
            get => durabilityloss_receivedattackField;
            set => durabilityloss_receivedattackField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string durabilityloss_receivedspell
        {
            get => durabilityloss_receivedspellField;
            set => durabilityloss_receivedspellField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string durabilityloss_receivedattack_mounted
        {
            get => durabilityloss_receivedattack_mountedField;
            set => durabilityloss_receivedattack_mountedField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string durabilityloss_receivedspell_mounted
        {
            get => durabilityloss_receivedspell_mountedField;
            set => durabilityloss_receivedspell_mountedField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string durabilityloss_mounting
        {
            get => durabilityloss_mountingField;
            set => durabilityloss_mountingField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string unlockedtocraft
        {
            get => unlockedtocraftField;
            set => unlockedtocraftField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string unlockedtoequip
        {
            get => unlockedtoequipField;
            set => unlockedtoequipField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string mounttime
        {
            get => mounttimeField;
            set => mounttimeField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string dismounttime
        {
            get => dismounttimeField;
            set => dismounttimeField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string mounthitpointsmax
        {
            get => mounthitpointsmaxField;
            set => mounthitpointsmaxField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string mounthitpointsregeneration
        {
            get => mounthitpointsregenerationField;
            set => mounthitpointsregenerationField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string prefabname
        {
            get => prefabnameField;
            set => prefabnameField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string prefabscaling
        {
            get => prefabscalingField;
            set => prefabscalingField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string despawneffect
        {
            get => despawneffectField;
            set => despawneffectField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string despawneffectscaling
        {
            get => despawneffectscalingField;
            set => despawneffectscalingField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string remountdistance
        {
            get => remountdistanceField;
            set => remountdistanceField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string halfmountrange
        {
            get => halfmountrangeField;
            set => halfmountrangeField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string forceddismountcooldown
        {
            get => forceddismountcooldownField;
            set => forceddismountcooldownField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string forceddismountspellcooldown
        {
            get => forceddismountspellcooldownField;
            set => forceddismountspellcooldownField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string fulldismountcooldown
        {
            get => fulldismountcooldownField;
            set => fulldismountcooldownField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string remounttime
        {
            get => remounttimeField;
            set => remounttimeField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string uicraftsoundstart
        {
            get => uicraftsoundstartField;
            set => uicraftsoundstartField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string uicraftsoundfinish
        {
            get => uicraftsoundfinishField;
            set => uicraftsoundfinishField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string dismountbuff
        {
            get => dismountbuffField;
            set => dismountbuffField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string uisprite
        {
            get => uispriteField;
            set => uispriteField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string showinmarketplace
        {
            get => showinmarketplaceField;
            set => showinmarketplaceField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string enchantmentlevel
        {
            get => enchantmentlevelField;
            set => enchantmentlevelField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string canuseingvg
        {
            get => canuseingvgField;
            set => canuseingvgField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string itemvalue
        {
            get => itemvalueField;
            set => itemvalueField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string nametagoffset
        {
            get => nametagoffsetField;
            set => nametagoffsetField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string craftfamegainfactor
        {
            get => craftfamegainfactorField;
            set => craftfamegainfactorField = value;
        }

        public string craftingcategory => "mount??";


        /// <remarks />
        [XmlAttribute]
        public string uniquename
        {
            get => uniquenameField;
            set => uniquenameField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string shopcategory
        {
            get => shopcategoryField;
            set => shopcategoryField = value;
        }
    }
}