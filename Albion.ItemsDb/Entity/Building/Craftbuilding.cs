using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;
using Albion.Db.Xml.Entity.Common;

namespace Albion.Db.Xml.Entity.Building
{
    /// <remarks />
    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class CraftBuilding
    {
        [XmlArrayItem("dish", typeof(favoritedishDish), Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public favoritedishDish[] favoritedish { get; set; }


        [XmlElement("craftingitemlist")] public CraftingItemList[] craftingitemlist { get; set; }


        [XmlElement("craftingrequirements")] public craftingrequirements[] craftingrequirements { get; set; }


        [XmlElement("AudioInfo")] public AudioInfo[] AudioInfo { get; set; }


        [XmlAttribute] public string uniquename { get; set; }


        [XmlAttribute] public string tier { get; set; }


        [XmlAttribute] public string placecost { get; set; }


        [XmlAttribute] public string upgradeableto { get; set; }


        [XmlAttribute] public string allowsstudy { get; set; }


        [XmlAttribute] public string durability { get; set; }


        [XmlAttribute] public string durabilityloss { get; set; }


        [XmlAttribute] public string nutritionstorage { get; set; }


        [XmlAttribute] public string nutritionloss { get; set; }


        [XmlAttribute] public string craftcapacity { get; set; }


        [XmlAttribute] public string craftcapacityregeneration { get; set; }


        [XmlAttribute] public string category { get; set; }


        [XmlAttribute] public string displaygroup { get; set; }


        [XmlAttribute] public string defaultcostfactorfriends { get; set; }


        [XmlAttribute] public string defaultcostfactorusers { get; set; }


        [XmlAttribute] public string craftanimation { get; set; }


        [XmlAttribute] public string unlocked { get; set; }


        [XmlAttribute] public string iconAtlas { get; set; }


        [XmlAttribute] public string iconSprite { get; set; }


        [XmlAttribute] public string uispritename { get; set; }


        [XmlAttribute] public string uisoundevent { get; set; }


        [XmlAttribute] public string accessrightspreset { get; set; }


        [XmlAttribute] public string repaircostfactor { get; set; }


        [XmlAttribute] public string destructionreturnfactor { get; set; }


        [XmlAttribute] public string initialnutrition { get; set; }


        [XmlAttribute] public string uinpcspritename { get; set; }


        [XmlAttribute] public string tile { get; set; }


        [XmlAttribute] public string isshop { get; set; }


        [XmlAttribute] public string usesbuildingplacementrules { get; set; }


        [XmlAttribute] public string isarena { get; set; }


        [XmlAttribute] public string hideonclustermap { get; set; }


        [XmlAttribute] public string randomidleanimoffset { get; set; }


        [XmlAttribute] public string animateonguiopen { get; set; }


        [XmlAttribute] public string warningpopupstring { get; set; }
    }
}