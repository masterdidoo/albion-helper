/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
[System.Xml.Serialization.XmlRootAttribute("AO-Resources", Namespace="", IsNullable=false)]
public class AOResources {
    //[System.Xml.Serialization.XmlElementAttribute("Harvestables", typeof(AOResourcesHarvestables), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlElementAttribute("Resources", typeof(AOResourcesResources), Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public object[] Items{get;set;}
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class AOResourcesHarvestables {
    
    private AOResourcesHarvestablesHarvestable[] harvestableField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Harvestable", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public AOResourcesHarvestablesHarvestable[] Harvestable {
        get {
            return this.harvestableField;
        }
        set {
            this.harvestableField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class AOResourcesHarvestablesHarvestable {
    
    private AOResourcesHarvestablesHarvestableToolModifierModifier[][] toolModifierField;
    
    private AOResourcesHarvestablesHarvestableTier[] tierField;
    
    private string nameField;
    
    private string resourceField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("Modifier", typeof(AOResourcesHarvestablesHarvestableToolModifierModifier), Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
    public AOResourcesHarvestablesHarvestableToolModifierModifier[][] ToolModifier {
        get {
            return this.toolModifierField;
        }
        set {
            this.toolModifierField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Tier", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public AOResourcesHarvestablesHarvestableTier[] Tier {
        get {
            return this.tierField;
        }
        set {
            this.tierField = value;
        }
    }
    
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
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string resource {
        get {
            return this.resourceField;
        }
        set {
            this.resourceField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class AOResourcesHarvestablesHarvestableToolModifierModifier {
    
    private string tierdifferenceField;
    
    private string timefactorField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string tierdifference {
        get {
            return this.tierdifferenceField;
        }
        set {
            this.tierdifferenceField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string timefactor {
        get {
            return this.timefactorField;
        }
        set {
            this.timefactorField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class AOResourcesHarvestablesHarvestableTier {
    
    private AOResourcesHarvestablesHarvestableTierCharge[] chargeField;
    
    private AOResourcesHarvestablesHarvestableTierRareState[] rareStateField;
    
    private string tierField;
    
    private string itemField;
    
    private string maxchargesperharvestField;
    
    private string respawntimesecondsField;
    
    private string harvesttimesecondsField;
    
    private string requirestoolField;
    
    private string notooltimefactorField;
    
    private string startchargesField;
    
    private string tileField;
    
    private string decaytimesecondsField;
    
    private string decaytimewhenexhaustedsecondsField;
    
    private string tilepremiumField;
    
    private string isscaledField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Charge", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public AOResourcesHarvestablesHarvestableTierCharge[] Charge {
        get {
            return this.chargeField;
        }
        set {
            this.chargeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("RareState", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public AOResourcesHarvestablesHarvestableTierRareState[] RareState {
        get {
            return this.rareStateField;
        }
        set {
            this.rareStateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string tier {
        get {
            return this.tierField;
        }
        set {
            this.tierField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string item {
        get {
            return this.itemField;
        }
        set {
            this.itemField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string maxchargesperharvest {
        get {
            return this.maxchargesperharvestField;
        }
        set {
            this.maxchargesperharvestField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string respawntimeseconds {
        get {
            return this.respawntimesecondsField;
        }
        set {
            this.respawntimesecondsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string harvesttimeseconds {
        get {
            return this.harvesttimesecondsField;
        }
        set {
            this.harvesttimesecondsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string requirestool {
        get {
            return this.requirestoolField;
        }
        set {
            this.requirestoolField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string notooltimefactor {
        get {
            return this.notooltimefactorField;
        }
        set {
            this.notooltimefactorField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string startcharges {
        get {
            return this.startchargesField;
        }
        set {
            this.startchargesField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string tile {
        get {
            return this.tileField;
        }
        set {
            this.tileField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string decaytimeseconds {
        get {
            return this.decaytimesecondsField;
        }
        set {
            this.decaytimesecondsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string decaytimewhenexhaustedseconds {
        get {
            return this.decaytimewhenexhaustedsecondsField;
        }
        set {
            this.decaytimewhenexhaustedsecondsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string tilepremium {
        get {
            return this.tilepremiumField;
        }
        set {
            this.tilepremiumField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string isscaled {
        get {
            return this.isscaledField;
        }
        set {
            this.isscaledField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class AOResourcesHarvestablesHarvestableTierCharge {
    
    private string levelField;
    
    private string gfxstateField;
    
    private string respawnfactorminField;
    
    private string respawnfactormaxField;
    
    private string respawnchargesField;
    
    private string yieldField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string level {
        get {
            return this.levelField;
        }
        set {
            this.levelField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string gfxstate {
        get {
            return this.gfxstateField;
        }
        set {
            this.gfxstateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string respawnfactormin {
        get {
            return this.respawnfactorminField;
        }
        set {
            this.respawnfactorminField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string respawnfactormax {
        get {
            return this.respawnfactormaxField;
        }
        set {
            this.respawnfactormaxField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string respawncharges {
        get {
            return this.respawnchargesField;
        }
        set {
            this.respawnchargesField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string yield {
        get {
            return this.yieldField;
        }
        set {
            this.yieldField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class AOResourcesHarvestablesHarvestableTierRareState {
    
    private string stateField;
    
    private string itemField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string state {
        get {
            return this.stateField;
        }
        set {
            this.stateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string item {
        get {
            return this.itemField;
        }
        set {
            this.itemField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class AOResourcesResources {
    
    private AOResourcesResourcesResource[] resourceField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("Resource", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public AOResourcesResourcesResource[] Resource {
        get {
            return this.resourceField;
        }
        set {
            this.resourceField = value;
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class AOResourcesResourcesResource {
    
    private AOResourcesResourcesResourceResourceTier[] resourceTierField;
    
    private string nameField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ResourceTier", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public AOResourcesResourcesResourceResourceTier[] ResourceTier {
        get {
            return this.resourceTierField;
        }
        set {
            this.resourceTierField = value;
        }
    }
    
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
public class AOResourcesResourcesResourceResourceTier {
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public int value { get; set; }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public double resourcevalue { get; set; }

    [System.Xml.Serialization.XmlAttributeAttribute()]
    public double famevalue { get; set; }
}
