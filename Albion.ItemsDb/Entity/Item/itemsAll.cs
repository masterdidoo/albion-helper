﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System.Xml.Serialization;
using Albion.Db.Xml;
using Albion.Db.Xml.Entity.Common;
using Albion.Db.Xml.Requirements;

// 
// Этот исходный код был создан с помощью xsd, версия=4.6.1055.0.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class craftingrequirementsPlayerfactionstanding {
    
    private string factionField;
    
    private string minstandingField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string faction {
        get {
            return this.factionField;
        }
        set {
            this.factionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string minstanding {
        get {
            return this.minstandingField;
        }
        set {
            this.minstandingField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class craftingrequirementsCurrency {
    
    private string uniquenameField;
    
    private string amountField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string uniquename {
        get {
            return this.uniquenameField;
        }
        set {
            this.uniquenameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string amount {
        get {
            return this.amountField;
        }
        set {
            this.amountField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class enchantments {
    
    private EnchantmentsEnchantment[] enchantmentField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("enchantment", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public EnchantmentsEnchantment[] enchantment {
        get {
            return this.enchantmentField;
        }
        set {
            this.enchantmentField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class SocketPreset {
    
    private string nameField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class AssetVfxPreset {
    
    private string nameField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class craftingspelllist {
    
    private craftingspelllistCraftspell[] craftspellField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("craftspell", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public craftingspelllistCraftspell[] craftspell {
        get {
            return this.craftspellField;
        }
        set {
            this.craftspellField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class craftingspelllistCraftspell {
    
    private string uniquenameField;
    
    private string slotsField;
    
    private string tagField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string uniquename {
        get {
            return this.uniquenameField;
        }
        set {
            this.uniquenameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string slots {
        get {
            return this.slotsField;
        }
        set {
            this.slotsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string tag {
        get {
            return this.tagField;
        }
        set {
            this.tagField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
public partial class validitem {
    
    private string idField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class itemsFarmableitemHarvest {
    
    private itemsFarmableitemHarvestSeed[] seedField;
    
    private string growtimeField;
    
    private string lootlistField;
    
    private string lootchanceField;
    
    private string fameField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("seed", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public itemsFarmableitemHarvestSeed[] seed {
        get {
            return this.seedField;
        }
        set {
            this.seedField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string growtime {
        get {
            return this.growtimeField;
        }
        set {
            this.growtimeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string lootlist {
        get {
            return this.lootlistField;
        }
        set {
            this.lootlistField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string lootchance {
        get {
            return this.lootchanceField;
        }
        set {
            this.lootchanceField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string fame {
        get {
            return this.fameField;
        }
        set {
            this.fameField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class itemsFarmableitemHarvestSeed {
    
    private string chanceField;
    
    private string amountField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string chance {
        get {
            return this.chanceField;
        }
        set {
            this.chanceField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string amount {
        get {
            return this.amountField;
        }
        set {
            this.amountField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class itemsFarmableitemGrownitem {
    
    private itemsFarmableitemGrownitemOffspring[] offspringField;
    
    private string uniquenameField;
    
    private string growtimeField;
    
    private string fameField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("offspring", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public itemsFarmableitemGrownitemOffspring[] offspring {
        get {
            return this.offspringField;
        }
        set {
            this.offspringField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string uniquename {
        get {
            return this.uniquenameField;
        }
        set {
            this.uniquenameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string growtime {
        get {
            return this.growtimeField;
        }
        set {
            this.growtimeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string fame {
        get {
            return this.fameField;
        }
        set {
            this.fameField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class itemsFarmableitemGrownitemOffspring {
    
    private string chanceField;
    
    private string amountField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string chance {
        get {
            return this.chanceField;
        }
        set {
            this.chanceField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string amount {
        get {
            return this.amountField;
        }
        set {
            this.amountField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class itemsFarmableitemConsumptionFood {
    
    private itemsFarmableitemConsumptionFoodAcceptedfood[] acceptedfoodField;
    
    private string nutritionmaxField;
    
    private string secondspernutritionField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("acceptedfood", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public itemsFarmableitemConsumptionFoodAcceptedfood[] acceptedfood {
        get {
            return this.acceptedfoodField;
        }
        set {
            this.acceptedfoodField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string nutritionmax {
        get {
            return this.nutritionmaxField;
        }
        set {
            this.nutritionmaxField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string secondspernutrition {
        get {
            return this.secondspernutritionField;
        }
        set {
            this.secondspernutritionField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class itemsFarmableitemConsumptionFoodAcceptedfood {
    
    private string foodcategoryField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string foodcategory {
        get {
            return this.foodcategoryField;
        }
        set {
            this.foodcategoryField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class itemsFarmableitemProductsProduct {
    
    private string productiontimeField;
    
    private string actionnameField;
    
    private string lootlistField;
    
    private string lootchanceField;
    
    private string fameField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string productiontime {
        get {
            return this.productiontimeField;
        }
        set {
            this.productiontimeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string actionname {
        get {
            return this.actionnameField;
        }
        set {
            this.actionnameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string lootlist {
        get {
            return this.lootlistField;
        }
        set {
            this.lootlistField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string lootchance {
        get {
            return this.lootchanceField;
        }
        set {
            this.lootchanceField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string fame {
        get {
            return this.fameField;
        }
        set {
            this.fameField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class itemsFurnitureitemContainer {
    
    private string capacityField;
    
    private string weightlimitField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string capacity {
        get {
            return this.capacityField;
        }
        set {
            this.capacityField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string weightlimit {
        get {
            return this.weightlimitField;
        }
        set {
            this.weightlimitField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class itemsFurnitureitemRepairkit {
    
    private string repaircostfactorField;
    
    private string maxtierField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string repaircostfactor {
        get {
            return this.repaircostfactorField;
        }
        set {
            this.repaircostfactorField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string maxtier {
        get {
            return this.maxtierField;
        }
        set {
            this.maxtierField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class itemsJournalitemFamefillingmissions {
    
    private itemsJournalitemFamefillingmissionsFishingfame[] fishingfameField;
    
    private itemsJournalitemFamefillingmissionsFameearned[] fameearnedField;
    
    private itemsJournalitemFamefillingmissionsKillmobfame[] killmobfameField;
    
    private itemsJournalitemFamefillingmissionsCraftitemfame[] craftitemfameField;
    
    private itemsJournalitemFamefillingmissionsGatherfame[] gatherfameField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("fishingfame", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public itemsJournalitemFamefillingmissionsFishingfame[] fishingfame {
        get {
            return this.fishingfameField;
        }
        set {
            this.fishingfameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("fameearned", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public itemsJournalitemFamefillingmissionsFameearned[] fameearned {
        get {
            return this.fameearnedField;
        }
        set {
            this.fameearnedField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("killmobfame", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public itemsJournalitemFamefillingmissionsKillmobfame[] killmobfame {
        get {
            return this.killmobfameField;
        }
        set {
            this.killmobfameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("craftitemfame", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public itemsJournalitemFamefillingmissionsCraftitemfame[] craftitemfame {
        get {
            return this.craftitemfameField;
        }
        set {
            this.craftitemfameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("gatherfame", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public itemsJournalitemFamefillingmissionsGatherfame[] gatherfame {
        get {
            return this.gatherfameField;
        }
        set {
            this.gatherfameField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class itemsJournalitemFamefillingmissionsFishingfame {
    
    private string valueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class itemsJournalitemFamefillingmissionsFameearned {
    
    private string valueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class itemsJournalitemFamefillingmissionsKillmobfame {
    
    private string mintierField;
    
    private string valueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string mintier {
        get {
            return this.mintierField;
        }
        set {
            this.mintierField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class itemsJournalitemFamefillingmissionsCraftitemfame {
    
    private validitem[] validitemField;
    
    private string mintierField;
    
    private string valueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("validitem")]
    public validitem[] validitem {
        get {
            return this.validitemField;
        }
        set {
            this.validitemField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string mintier {
        get {
            return this.mintierField;
        }
        set {
            this.mintierField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class itemsJournalitemFamefillingmissionsGatherfame {
    
    private validitem[] validitemField;
    
    private string mintierField;
    
    private string valueField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("validitem")]
    public validitem[] validitem {
        get {
            return this.validitemField;
        }
        set {
            this.validitemField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string mintier {
        get {
            return this.mintierField;
        }
        set {
            this.mintierField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string value {
        get {
            return this.valueField;
        }
        set {
            this.valueField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class itemsJournalitemLootlistLoot {
    
    private string itemnameField;
    
    private string itemamountField;
    
    private string weightField;
    
    private string labourerfameField;
    
    private string itemenchantmentlevelField;
    
    private string silveramountField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string itemname {
        get {
            return this.itemnameField;
        }
        set {
            this.itemnameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string itemamount {
        get {
            return this.itemamountField;
        }
        set {
            this.itemamountField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string weight {
        get {
            return this.weightField;
        }
        set {
            this.weightField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string labourerfame {
        get {
            return this.labourerfameField;
        }
        set {
            this.labourerfameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string itemenchantmentlevel {
        get {
            return this.itemenchantmentlevelField;
        }
        set {
            this.itemenchantmentlevelField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string silveramount {
        get {
            return this.silveramountField;
        }
        set {
            this.silveramountField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class itemsMountFootStepVfxPreset {
    
    private string nameField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string name {
        get {
            return this.nameField;
        }
        set {
            this.nameField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class itemsMountMountspelllistMountspell {
    
    private string uniquenameField;
    
    private string spellslotField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string uniquename {
        get {
            return this.uniquenameField;
        }
        set {
            this.uniquenameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string spellslot {
        get {
            return this.spellslotField;
        }
        set {
            this.spellslotField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class itemsSimpleitemReplaceondeathReplacementitem {
    
    private string uniquenameField;
    
    private string countField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string uniquename {
        get {
            return this.uniquenameField;
        }
        set {
            this.uniquenameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string count {
        get {
            return this.countField;
        }
        set {
            this.countField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class itemsWeaponProjectile {
    
    private itemsWeaponProjectileImpactvfx[] impactvfxField;
    
    private AudioInfo[] audioInfoField;
    
    private string prefabField;
    
    private string startsocketField;
    
    private string hitsocketField;
    
    private string timeoffsetField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("impactvfx", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public itemsWeaponProjectileImpactvfx[] impactvfx {
        get {
            return this.impactvfxField;
        }
        set {
            this.impactvfxField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AudioInfo")]
    public AudioInfo[] AudioInfo {
        get {
            return this.audioInfoField;
        }
        set {
            this.audioInfoField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string prefab {
        get {
            return this.prefabField;
        }
        set {
            this.prefabField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string startsocket {
        get {
            return this.startsocketField;
        }
        set {
            this.startsocketField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string hitsocket {
        get {
            return this.hitsocketField;
        }
        set {
            this.hitsocketField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string timeoffset {
        get {
            return this.timeoffsetField;
        }
        set {
            this.timeoffsetField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class itemsWeaponProjectileImpactvfx {
    
    private string prefabField;
    
    private string impactsocketField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string prefab {
        get {
            return this.prefabField;
        }
        set {
            this.prefabField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string impactsocket {
        get {
            return this.impactsocketField;
        }
        set {
            this.impactsocketField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class itemsWeaponCanharvest {
    
    private string resourcetypeField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string resourcetype {
        get {
            return this.resourcetypeField;
        }
        set {
            this.resourcetypeField = value;
        }
    }
}
