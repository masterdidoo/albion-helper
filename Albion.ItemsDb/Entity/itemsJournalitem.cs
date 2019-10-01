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
    public class ItemsJournalitem : IItem
    {
        private string baselootamountField;

        private string craftfamegainfactorField;

        private craftingrequirements[] craftingrequirementsField;

        private itemsJournalitemFamefillingmissions[] famefillingmissionsField;

        private string fasttravelfactorField;

        private itemsJournalitemLootlistLoot[] lootlistField;

        private string maxfameField;

        private string salvageableField;

        private string shopcategoryField;

        private string shopsubcategory1Field;

        private string tierField;

        private string uispriteField;

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
        [XmlElement("famefillingmissions", Form = XmlSchemaForm.Unqualified)]
        public itemsJournalitemFamefillingmissions[] famefillingmissions
        {
            get => famefillingmissionsField;
            set => famefillingmissionsField = value;
        }

        /// <remarks />
        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("loot", typeof(itemsJournalitemLootlistLoot), Form = XmlSchemaForm.Unqualified,
            IsNullable = false)]
        public itemsJournalitemLootlistLoot[] lootlist
        {
            get => lootlistField;
            set => lootlistField = value;
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
        public string tier
        {
            get => tierField;
            set => tierField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string maxfame
        {
            get => maxfameField;
            set => maxfameField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string baselootamount
        {
            get => baselootamountField;
            set => baselootamountField = value;
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
        public string weight
        {
            get => weightField;
            set => weightField = value;
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
        public string craftfamegainfactor
        {
            get => craftfamegainfactorField;
            set => craftfamegainfactorField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string fasttravelfactor
        {
            get => fasttravelfactorField;
            set => fasttravelfactorField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string uisprite
        {
            get => uispriteField;
            set => uispriteField = value;
        }

        public string craftingcategory => "itemsJournalitem???";


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