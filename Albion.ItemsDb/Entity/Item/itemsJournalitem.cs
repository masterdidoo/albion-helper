﻿using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;
using Albion.Db.Xml.Enums;
using Albion.Db.Xml.Requirements;

namespace Albion.Db.Xml.Entity.Item
{
    [GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class ItemsJournalitem : IItem, IItemSalvageable
    {
        [XmlElement("craftingrequirements")] public Craftingrequirements[] craftingrequirements { get; set; }


        [XmlElement("famefillingmissions", Form = XmlSchemaForm.Unqualified)]
        public itemsJournalitemFamefillingmissions[] famefillingmissions { get; set; }


        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("loot", typeof(itemsJournalitemLootlistLoot), Form = XmlSchemaForm.Unqualified,
            IsNullable = false)]
        public itemsJournalitemLootlistLoot[] lootlist { get; set; }


        [XmlAttribute] public bool salvageable { get; set; }


        [XmlAttribute] public int tier { get; set; }


        [XmlAttribute] public int maxfame { get; set; }


        [XmlAttribute] public string baselootamount { get; set; }


        [XmlAttribute] public shopSubCategory shopsubcategory1 { get; set; }


        [XmlAttribute] public string weight { get; set; }


        [XmlAttribute] public bool unlockedtocraft { get; set; }


        [XmlAttribute] public string craftfamegainfactor { get; set; }


        [XmlAttribute] public string fasttravelfactor { get; set; }


        [XmlAttribute] public string uisprite { get; set; }


        [XmlAttribute] public string uniquename { get; set; }


        [XmlAttribute] public shopCategory shopcategory { get; set; }
    }
}