﻿using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
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
    public class ItemsConsumablefrominventoryitem : IItem, IItemPowered2, IItemEnchantmentLevel, IItemValued, IItemSalvageable
    {
        [XmlElement("craftingrequirements")] public Craftingrequirements[] craftingrequirements { get; set; }

        [XmlElement("AudioInfo")] public AudioInfo[] AudioInfo { get; set; }


        [XmlAttribute] public string tradable { get; set; }


        [XmlAttribute] public string uisprite { get; set; }


        [XmlAttribute] public string abilitypower { get; set; }


        [XmlAttribute] public string consumespell { get; set; }


        [XmlAttribute] public string weight { get; set; }


        [XmlAttribute] public int dummyitempower { get; set; }


        [XmlAttribute] public string maxstacksize { get; set; }


        [XmlAttribute] public bool unlockedtocraft { get; set; }


        [XmlAttribute] public string uicraftsoundstart { get; set; }


        [XmlAttribute] public string uicraftsoundfinish { get; set; }


        [XmlAttribute] public float itemvalue { get; set; }


        [XmlAttribute] public string uispriteoverlay { get; set; }


        [XmlAttribute] public int enchantmentlevel { get; set; }


        [XmlAttribute] public string descriptionlocatag { get; set; }


        [XmlAttribute] public bool salvageable { get; set; }


        [XmlAttribute] public string showinmarketplace { get; set; }


        [XmlAttribute] public shopSubCategory shopsubcategory1 { get; set; }


        [XmlAttribute] public int tier { get; set; }


        [XmlAttribute] public string uniquename { get; set; }


        [XmlAttribute] public shopCategory shopcategory { get; set; }
    }
}