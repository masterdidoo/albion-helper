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
    public class ItemsFarmableitem : IItem
    {
        [XmlElement("craftingrequirements")] public Craftingrequirements[] craftingrequirements { get; set; }


        [XmlElement("AudioInfo")] public AudioInfo[] AudioInfo { get; set; }


        [XmlElement("harvest", Form = XmlSchemaForm.Unqualified)]
        public itemsFarmableitemHarvest[] harvest { get; set; }


        [XmlElement("grownitem", Form = XmlSchemaForm.Unqualified)]
        public itemsFarmableitemGrownitem[] grownitem { get; set; }


        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("food", typeof(itemsFarmableitemConsumptionFood), Form = XmlSchemaForm.Unqualified,
            IsNullable = false)]
        public itemsFarmableitemConsumptionFood[] consumption { get; set; }


        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("product", typeof(itemsFarmableitemProductsProduct), Form = XmlSchemaForm.Unqualified,
            IsNullable = false)]
        public itemsFarmableitemProductsProduct[] products { get; set; }


        [XmlAttribute] public int tier { get; set; }


        [XmlAttribute] public string craftfamegainfactor { get; set; }


        [XmlAttribute] public string placecost { get; set; }


        [XmlAttribute] public string placefame { get; set; }


        [XmlAttribute] public string pickupable { get; set; }


        [XmlAttribute] public string destroyable { get; set; }


        [XmlAttribute] public string unlockedtoplace { get; set; }


        [XmlAttribute] public string maxstacksize { get; set; }


        [XmlAttribute] public shopSubCategory shopsubcategory1 { get; set; }


        [XmlAttribute] public string kind { get; set; }


        [XmlAttribute] public string weight { get; set; }


        [XmlAttribute] public string unlockedtocraft { get; set; }


        [XmlAttribute] public string animationid { get; set; }


        [XmlAttribute] public string activefarmfocuscost { get; set; }


        [XmlAttribute] public string activefarmmaxcycles { get; set; }


        [XmlAttribute] public string activefarmactiondurationseconds { get; set; }


        [XmlAttribute] public string activefarmcyclelengthseconds { get; set; }


        [XmlAttribute] public string activefarmbonus { get; set; }


        [XmlAttribute] public string prefabname { get; set; }


        [XmlAttribute] public string prefabscale { get; set; }


        [XmlAttribute] public string resourcevalue { get; set; }


        [XmlAttribute] public string tile { get; set; }


        [XmlAttribute] public string uisprite { get; set; }


        [XmlAttribute] public string showinmarketplace { get; set; }


        [XmlAttribute] public string uniquename { get; set; }


        [XmlAttribute] public shopCategory shopcategory { get; set; }
    }
}