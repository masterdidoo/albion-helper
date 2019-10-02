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
    public class itemsFarmableitem : IItem
    {
        private string activefarmactiondurationsecondsField;

        private string activefarmbonusField;

        private string activefarmcyclelengthsecondsField;

        private string activefarmfocuscostField;

        private string activefarmmaxcyclesField;

        private string animationidField;

        private AudioInfo[] audioInfoField;

        private itemsFarmableitemConsumptionFood[] consumptionField;

        private string craftfamegainfactorField;

        private craftingrequirements[] craftingrequirementsField;

        private string destroyableField;

        private itemsFarmableitemGrownitem[] grownitemField;

        private itemsFarmableitemHarvest[] harvestField;

        private string kindField;

        private string maxstacksizeField;

        private string pickupableField;

        private string placecostField;

        private string placefameField;

        private string prefabnameField;

        private string prefabscaleField;

        private itemsFarmableitemProductsProduct[] productsField;

        private string resourcevalueField;

        private string shopcategoryField;

        private string shopsubcategory1Field;

        private string showinmarketplaceField;

        private string tierField;

        private string tileField;

        private string uispriteField;

        private string uniquenameField;

        private string unlockedtocraftField;

        private string unlockedtoplaceField;

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
        [XmlElement("harvest", Form = XmlSchemaForm.Unqualified)]
        public itemsFarmableitemHarvest[] harvest
        {
            get => harvestField;
            set => harvestField = value;
        }

        /// <remarks />
        [XmlElement("grownitem", Form = XmlSchemaForm.Unqualified)]
        public itemsFarmableitemGrownitem[] grownitem
        {
            get => grownitemField;
            set => grownitemField = value;
        }

        /// <remarks />
        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("food", typeof(itemsFarmableitemConsumptionFood), Form = XmlSchemaForm.Unqualified,
            IsNullable = false)]
        public itemsFarmableitemConsumptionFood[] consumption
        {
            get => consumptionField;
            set => consumptionField = value;
        }

        /// <remarks />
        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("product", typeof(itemsFarmableitemProductsProduct), Form = XmlSchemaForm.Unqualified,
            IsNullable = false)]
        public itemsFarmableitemProductsProduct[] products
        {
            get => productsField;
            set => productsField = value;
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
        public string craftfamegainfactor
        {
            get => craftfamegainfactorField;
            set => craftfamegainfactorField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string placecost
        {
            get => placecostField;
            set => placecostField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string placefame
        {
            get => placefameField;
            set => placefameField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string pickupable
        {
            get => pickupableField;
            set => pickupableField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string destroyable
        {
            get => destroyableField;
            set => destroyableField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string unlockedtoplace
        {
            get => unlockedtoplaceField;
            set => unlockedtoplaceField = value;
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
        public string shopsubcategory1
        {
            get => shopsubcategory1Field;
            set => shopsubcategory1Field = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string kind
        {
            get => kindField;
            set => kindField = value;
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
        public string animationid
        {
            get => animationidField;
            set => animationidField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string activefarmfocuscost
        {
            get => activefarmfocuscostField;
            set => activefarmfocuscostField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string activefarmmaxcycles
        {
            get => activefarmmaxcyclesField;
            set => activefarmmaxcyclesField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string activefarmactiondurationseconds
        {
            get => activefarmactiondurationsecondsField;
            set => activefarmactiondurationsecondsField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string activefarmcyclelengthseconds
        {
            get => activefarmcyclelengthsecondsField;
            set => activefarmcyclelengthsecondsField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string activefarmbonus
        {
            get => activefarmbonusField;
            set => activefarmbonusField = value;
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
        public string prefabscale
        {
            get => prefabscaleField;
            set => prefabscaleField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string resourcevalue
        {
            get => resourcevalueField;
            set => resourcevalueField = value;
        }

        /// <remarks />
        [XmlAttribute]
        public string tile
        {
            get => tileField;
            set => tileField = value;
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

        public string craftingcategory => "farmabal??";


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