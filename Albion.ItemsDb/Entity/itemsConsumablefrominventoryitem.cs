using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace Albion.ItemsDb.Entity
{
    /// <remarks />
    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class itemsConsumablefrominventoryitem : IItem
    {
        private string abilitypowerField;

        private AudioInfo[] audioInfoField;

        private string consumespellField;

        private craftingrequirements[] craftingrequirementsField;

        private string descriptionlocatagField;

        private string dummyitempowerField;

        private string enchantmentlevelField;

        private string itemvalueField;

        private string maxstacksizeField;

        private string salvageableField;

        private string shopcategoryField;

        private string shopsubcategory1Field;

        private string showinmarketplaceField;

        private string tierField;

        private string tradableField;

        private string uicraftsoundfinishField;

        private string uicraftsoundstartField;

        private string uispriteField;

        private string uispriteoverlayField;

        private string uniquenameField;

        private string unlockedtocraftField;

        private string weightField;

        /// <remarks />
        [XmlElement("craftingrequirements")]
        public craftingrequirements[] craftingrequirements
        {
            get => craftingrequirementsField;
            set => craftingrequirementsField = value;
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
        public string tradable
        {
            get => tradableField;
            set => tradableField = value;
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
        public string abilitypower
        {
            get => abilitypowerField;
            set => abilitypowerField = value;
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
        public string itemvalue
        {
            get => itemvalueField;
            set => itemvalueField = value;
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
        public string enchantmentlevel
        {
            get => enchantmentlevelField;
            set => enchantmentlevelField = value;
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
        public string salvageable
        {
            get => salvageableField;
            set => salvageableField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string showinmarketplace
        {
            get => showinmarketplaceField;
            set => showinmarketplaceField = value;
        }

        public string craftingcategory => "itemsConsumablefrominventoryitem???";


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