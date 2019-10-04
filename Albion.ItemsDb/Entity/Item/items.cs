using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;
using Albion.Db.Xml.Entity.Common;
using Albion.Db.Xml.Requirements;

namespace Albion.Db.Xml.Entity.Item
{
    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class items
    {
        [XmlElement("AssetVfxPreset", typeof(AssetVfxPreset))]
        [XmlElement("AudioInfo", typeof(AudioInfo))]
        [XmlElement("SocketPreset", typeof(SocketPreset))]
        [XmlElement("consumablefrominventoryitem",
            typeof(ItemsConsumablefrominventoryitem), Form = XmlSchemaForm.Unqualified)]
        [XmlElement("consumableitem", typeof(ItemsConsumableitem), Form =
            XmlSchemaForm.Unqualified)]
        [XmlElement("craftingrequirements", typeof(Craftingrequirements))]
        [XmlElement("craftingspelllist", typeof(craftingspelllist))]
        [XmlElement("enchantments", typeof(enchantments))]
        [XmlElement("equipmentitem", typeof(Equipmentitem), Form =
            XmlSchemaForm.Unqualified)]
        [XmlElement("farmableitem", typeof(ItemsFarmableitem), Form =
            XmlSchemaForm.Unqualified)]
        [XmlElement("furnitureitem", typeof(ItemsFurnitureitem), Form =
            XmlSchemaForm.Unqualified)]
        [XmlElement("journalitem", typeof(ItemsJournalitem), Form =
            XmlSchemaForm.Unqualified)]
        [XmlElement("mount", typeof(Mount), Form =
            XmlSchemaForm.Unqualified)]
        [XmlElement("simpleitem", typeof(SimpleItem), Form =
            XmlSchemaForm.Unqualified)]
        [XmlElement("validitem", typeof(validitem))]
        [XmlElement("weapon", typeof(Weapon), Form =
            XmlSchemaForm.Unqualified)]
        public object[] Items { get; set; }
    }
}