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
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class buildings
    {
        /// <remarks />
        [XmlElement("AudioInfo", typeof(AudioInfo))]
        [XmlElement("bankbuilding", typeof(buildingsBankbuilding), Form = XmlSchemaForm.Unqualified)]
        [XmlElement("blackmarketbuilding", typeof(buildingsBlackmarketbuilding), Form = XmlSchemaForm.Unqualified)]
        [XmlElement("buildingreference", typeof(buildingsBuildingreference), Form = XmlSchemaForm.Unqualified)]
        [XmlElement("castlegate", typeof(buildingsCastlegate), Form = XmlSchemaForm.Unqualified)]
        [XmlElement("craftbuilding", typeof(CraftBuilding), Form = XmlSchemaForm.Unqualified)]
        [XmlElement("craftingitemlist", typeof(CraftingItemList))]
        [XmlElement("craftingrequirements", typeof(craftingrequirements))]
        [XmlElement("factionbuilding", typeof(buildingsFactionbuilding), Form = XmlSchemaForm.Unqualified)]
        [XmlElement("farmbuilding", typeof(buildingsFarmbuilding), Form = XmlSchemaForm.Unqualified)]
        [XmlElement("favoritedish", typeof(favoritedish))]
        [XmlElement("journal", typeof(journal))]
        [XmlElement("labourer", typeof(buildingsLabourer), Form = XmlSchemaForm.Unqualified)]
        [XmlElement("marketplacebuilding", typeof(buildingsMarketplacebuilding), Form = XmlSchemaForm.Unqualified)]
        [XmlElement("meldbuilding", typeof(buildingsMeldbuilding), Form = XmlSchemaForm.Unqualified)]
        [XmlElement("playerbuilding", typeof(buildingsPlayerbuilding), Form = XmlSchemaForm.Unqualified)]
        [XmlElement("repairbuilding", typeof(buildingsRepairbuilding), Form = XmlSchemaForm.Unqualified)]
        [XmlElement("tutorialbuilding", typeof(buildingsTutorialbuilding), Form = XmlSchemaForm.Unqualified)]
        public object[] Items { get; set; }
    }
}