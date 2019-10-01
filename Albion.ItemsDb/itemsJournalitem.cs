/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public class itemsJournalitem : IItem{
    
    private craftingrequirements[] craftingrequirementsField;
    
    private itemsJournalitemFamefillingmissions[] famefillingmissionsField;
    
    private itemsJournalitemLootlistLoot[] lootlistField;
    
    private string salvageableField;
    
    private string uniquenameField;
    
    private string tierField;
    
    private string maxfameField;
    
    private string baselootamountField;
    
    private string shopcategoryField;
    
    private string shopsubcategory1Field;
    
    private string weightField;
    
    private string unlockedtocraftField;
    
    private string craftfamegainfactorField;
    
    private string fasttravelfactorField;
    
    private string uispriteField;

    public string craftingcategory => "itemsJournalitem???";

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("craftingrequirements")]
    public craftingrequirements[] craftingrequirements {
        get {
            return this.craftingrequirementsField;
        }
        set {
            this.craftingrequirementsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("famefillingmissions", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public itemsJournalitemFamefillingmissions[] famefillingmissions {
        get {
            return this.famefillingmissionsField;
        }
        set {
            this.famefillingmissionsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("loot", typeof(itemsJournalitemLootlistLoot), Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
    public itemsJournalitemLootlistLoot[] lootlist {
        get {
            return this.lootlistField;
        }
        set {
            this.lootlistField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string salvageable {
        get {
            return this.salvageableField;
        }
        set {
            this.salvageableField = value;
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
    public string maxfame {
        get {
            return this.maxfameField;
        }
        set {
            this.maxfameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string baselootamount {
        get {
            return this.baselootamountField;
        }
        set {
            this.baselootamountField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string shopcategory {
        get {
            return this.shopcategoryField;
        }
        set {
            this.shopcategoryField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string shopsubcategory1 {
        get {
            return this.shopsubcategory1Field;
        }
        set {
            this.shopsubcategory1Field = value;
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
    public string unlockedtocraft {
        get {
            return this.unlockedtocraftField;
        }
        set {
            this.unlockedtocraftField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string craftfamegainfactor {
        get {
            return this.craftfamegainfactorField;
        }
        set {
            this.craftfamegainfactorField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string fasttravelfactor {
        get {
            return this.fasttravelfactorField;
        }
        set {
            this.fasttravelfactorField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string uisprite {
        get {
            return this.uispriteField;
        }
        set {
            this.uispriteField = value;
        }
    }
}