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
    public class itemsEquipmentitem : IItem
    {
        private string abilitypowerField;

        private string activespellslotsField;

        private AssetVfxPreset[] assetVfxPresetField;

        private string attackspeedbonusField;

        private AudioInfo[] audioInfoField;

        private string beardstateField;

        private string bonusccdurationvsmobsField;

        private string bonusccdurationvsplayersField;

        private string bonusdefensevsmobsField;

        private string bonusdefensevsplayersField;

        private string canbeoverchargedField;

        private string craftfamegainfactorField;

        private string craftingcategoryField;

        private craftingrequirements[] craftingrequirementsField;

        private craftingspelllistCraftspell[] craftingspelllistField;

        private string crowdcontrolresistanceField;

        private string descriptionlocatagField;

        private string durabilityField;

        private string durabilityloss_attackField;

        private string durabilityloss_receivedattackField;

        private string durabilityloss_receivedspellField;

        private string durabilityloss_spelluseField;

        private string enchantmentlevelField;

        private enchantmentsEnchantment[] enchantmentsField;

        private string energycostreductionField;

        private string energymaxField;

        private string energyregenerationbonusField;

        private string facestateField;

        private string healbonusField;

        private string healmodifierField;

        private string hitpointsmaxField;

        private string hitpointsregenerationbonusField;

        private string itempowerField;

        private string itempowerprogressiontypeField;

        private string magicattackdamagebonusField;

        private string magiccasttimereductionField;

        private string magiccooldownreductionField;

        private string magicresistanceField;

        private string magicspelldamagebonusField;

        private string mainhandanimationtypeField;

        private string maxloadField;

        private string maxqualitylevelField;

        private string meshField;

        private string movespeedbonusField;

        private string movespeedField;

        private string offhandanimationtypeField;

        private string passivespellslotsField;

        private string physicalarmorField;

        private string physicalattackdamagebonusField;

        private string physicalspelldamagebonusField;

        private string requiredaccesslevelField;

        private string shopcategoryField;

        private string shopsubcategory1Field;

        private string showinmarketplaceField;

        private string skincountField;

        private string slottypeField;

        private SocketPreset[] socketPresetField;

        private string threatbonusField;

        private string tierField;

        private string tradableField;

        private string uicraftsoundfinishField;

        private string uicraftsoundstartField;

        private string uispriteField;

        private string uispriteoverlayField;

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
        [XmlElement("AssetVfxPreset")]
        public AssetVfxPreset[] AssetVfxPreset
        {
            get => assetVfxPresetField;
            set => assetVfxPresetField = value;
        }

        /// <remarks />
        [XmlArrayItem("enchantment", typeof(enchantmentsEnchantment), Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public enchantmentsEnchantment[] enchantments
        {
            get => enchantmentsField;
            set => enchantmentsField = value;
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
        [XmlElement("AudioInfo")]
        public AudioInfo[] AudioInfo
        {
            get => audioInfoField;
            set => audioInfoField = value;
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
        public string maxqualitylevel
        {
            get => maxqualitylevelField;
            set => maxqualitylevelField = value;
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
        public string itempowerprogressiontype
        {
            get => itempowerprogressiontypeField;
            set => itempowerprogressiontypeField = value;
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
        public string skincount
        {
            get => skincountField;
            set => skincountField = value;
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
        public string physicalarmor
        {
            get => physicalarmorField;
            set => physicalarmorField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string magicresistance
        {
            get => magicresistanceField;
            set => magicresistanceField = value;
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
        public string offhandanimationtype
        {
            get => offhandanimationtypeField;
            set => offhandanimationtypeField = value;
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
        public string hitpointsmax
        {
            get => hitpointsmaxField;
            set => hitpointsmaxField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string hitpointsregenerationbonus
        {
            get => hitpointsregenerationbonusField;
            set => hitpointsregenerationbonusField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string energymax
        {
            get => energymaxField;
            set => energymaxField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string energyregenerationbonus
        {
            get => energyregenerationbonusField;
            set => energyregenerationbonusField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string crowdcontrolresistance
        {
            get => crowdcontrolresistanceField;
            set => crowdcontrolresistanceField = value;
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
        public string physicalattackdamagebonus
        {
            get => physicalattackdamagebonusField;
            set => physicalattackdamagebonusField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string magicattackdamagebonus
        {
            get => magicattackdamagebonusField;
            set => magicattackdamagebonusField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string physicalspelldamagebonus
        {
            get => physicalspelldamagebonusField;
            set => physicalspelldamagebonusField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string magicspelldamagebonus
        {
            get => magicspelldamagebonusField;
            set => magicspelldamagebonusField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string healbonus
        {
            get => healbonusField;
            set => healbonusField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string bonusccdurationvsplayers
        {
            get => bonusccdurationvsplayersField;
            set => bonusccdurationvsplayersField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string bonusccdurationvsmobs
        {
            get => bonusccdurationvsmobsField;
            set => bonusccdurationvsmobsField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string threatbonus
        {
            get => threatbonusField;
            set => threatbonusField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string magiccooldownreduction
        {
            get => magiccooldownreductionField;
            set => magiccooldownreductionField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string bonusdefensevsplayers
        {
            get => bonusdefensevsplayersField;
            set => bonusdefensevsplayersField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string bonusdefensevsmobs
        {
            get => bonusdefensevsmobsField;
            set => bonusdefensevsmobsField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string magiccasttimereduction
        {
            get => magiccasttimereductionField;
            set => magiccasttimereductionField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string attackspeedbonus
        {
            get => attackspeedbonusField;
            set => attackspeedbonusField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string movespeedbonus
        {
            get => movespeedbonusField;
            set => movespeedbonusField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string healmodifier
        {
            get => healmodifierField;
            set => healmodifierField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string canbeovercharged
        {
            get => canbeoverchargedField;
            set => canbeoverchargedField = value;
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
        public string energycostreduction
        {
            get => energycostreductionField;
            set => energycostreductionField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string tradable
        {
            get => tradableField;
            set => tradableField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string movespeed
        {
            get => movespeedField;
            set => movespeedField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string maxload
        {
            get => maxloadField;
            set => maxloadField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string facestate
        {
            get => facestateField;
            set => facestateField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string requiredaccesslevel
        {
            get => requiredaccesslevelField;
            set => requiredaccesslevelField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string uispriteoverlay
        {
            get => uispriteoverlayField;
            set => uispriteoverlayField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string beardstate
        {
            get => beardstateField;
            set => beardstateField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string mesh
        {
            get => meshField;
            set => meshField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string craftfamegainfactor
        {
            get => craftfamegainfactorField;
            set => craftfamegainfactorField = value;
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
        public string mainhandanimationtype
        {
            get => mainhandanimationtypeField;
            set => mainhandanimationtypeField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string descriptionlocatag
        {
            get => descriptionlocatagField;
            set => descriptionlocatagField = value;
        }


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

        /// <remarks />
        [XmlAttribute]
        public string craftingcategory
        {
            get => craftingcategoryField;
            set => craftingcategoryField = value;
        }
    }
}