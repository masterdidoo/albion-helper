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
    public class itemsConsumableitem : IItem
    {
        private string abilitypowerField;

        private string consumespellField;

        private craftingrequirements[] craftingrequirementsField;

        private string descriptionlocatagField;

        private string dummyitempowerField;

        private enchantmentsEnchantment[] enchantmentsField;

        private string fishingfameField;

        private string fishingminigamesettingField;

        private string maxstacksizeField;

        private string nutritionField;

        private string resourcetypeField;

        private string shopcategoryField;

        private string shopsubcategory1Field;

        private string slottypeField;

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
        [XmlArrayItem("enchantment", typeof(enchantmentsEnchantment), Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public enchantmentsEnchantment[] enchantments
        {
            get => enchantmentsField;
            set => enchantmentsField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string fishingfame
        {
            get => fishingfameField;
            set => fishingfameField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string fishingminigamesetting
        {
            get => fishingminigamesettingField;
            set => fishingminigamesettingField = value;
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
        public string uisprite
        {
            get => uispriteField;
            set => uispriteField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string nutrition
        {
            get => nutritionField;
            set => nutritionField = value;
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
        public string consumespell
        {
            get => consumespellField;
            set => consumespellField = value;
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
        public string resourcetype
        {
            get => resourcetypeField;
            set => resourcetypeField = value;
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
        public string dummyitempower
        {
            get => dummyitempowerField;
            set => dummyitempowerField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string maxstacksize
        {
            get => maxstacksizeField;
            set => maxstacksizeField = value;
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
        public string uispriteoverlay
        {
            get => uispriteoverlayField;
            set => uispriteoverlayField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string tradable
        {
            get => tradableField;
            set => tradableField = value;
        }

        public string craftingcategory => "itemsConsumableitem???";

        /// <remarks />
        [XmlElement("craftingrequirements")]
        public craftingrequirements[] craftingrequirements
        {
            get => craftingrequirementsField;
            set => craftingrequirementsField = value;
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
    }
}