/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public class itemsFarmableitem : IItem {
    
    private craftingrequirements[] craftingrequirementsField;
    
    private AudioInfo[] audioInfoField;
    
    private itemsFarmableitemHarvest[] harvestField;
    
    private itemsFarmableitemGrownitem[] grownitemField;
    
    private itemsFarmableitemConsumptionFood[] consumptionField;
    
    private itemsFarmableitemProductsProduct[] productsField;
    
    private string uniquenameField;
    
    private string tierField;
    
    private string craftfamegainfactorField;
    
    private string placecostField;
    
    private string placefameField;
    
    private string pickupableField;
    
    private string destroyableField;
    
    private string unlockedtoplaceField;
    
    private string maxstacksizeField;
    
    private string shopcategoryField;
    
    private string shopsubcategory1Field;
    
    private string kindField;
    
    private string weightField;
    
    private string unlockedtocraftField;
    
    private string animationidField;
    
    private string activefarmfocuscostField;
    
    private string activefarmmaxcyclesField;
    
    private string activefarmactiondurationsecondsField;
    
    private string activefarmcyclelengthsecondsField;
    
    private string activefarmbonusField;
    
    private string prefabnameField;
    
    private string prefabscaleField;
    
    private string resourcevalueField;
    
    private string tileField;
    
    private string uispriteField;
    
    private string showinmarketplaceField;

    public string craftingcategory => "farmabal??";

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
    [System.Xml.Serialization.XmlElementAttribute("harvest", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public itemsFarmableitemHarvest[] harvest {
        get {
            return this.harvestField;
        }
        set {
            this.harvestField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("grownitem", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public itemsFarmableitemGrownitem[] grownitem {
        get {
            return this.grownitemField;
        }
        set {
            this.grownitemField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("food", typeof(itemsFarmableitemConsumptionFood), Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
    public itemsFarmableitemConsumptionFood[] consumption {
        get {
            return this.consumptionField;
        }
        set {
            this.consumptionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("product", typeof(itemsFarmableitemProductsProduct), Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
    public itemsFarmableitemProductsProduct[] products {
        get {
            return this.productsField;
        }
        set {
            this.productsField = value;
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
    public string placecost {
        get {
            return this.placecostField;
        }
        set {
            this.placecostField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string placefame {
        get {
            return this.placefameField;
        }
        set {
            this.placefameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string pickupable {
        get {
            return this.pickupableField;
        }
        set {
            this.pickupableField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string destroyable {
        get {
            return this.destroyableField;
        }
        set {
            this.destroyableField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string unlockedtoplace {
        get {
            return this.unlockedtoplaceField;
        }
        set {
            this.unlockedtoplaceField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string maxstacksize {
        get {
            return this.maxstacksizeField;
        }
        set {
            this.maxstacksizeField = value;
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
    public string kind {
        get {
            return this.kindField;
        }
        set {
            this.kindField = value;
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
    public string animationid {
        get {
            return this.animationidField;
        }
        set {
            this.animationidField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string activefarmfocuscost {
        get {
            return this.activefarmfocuscostField;
        }
        set {
            this.activefarmfocuscostField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string activefarmmaxcycles {
        get {
            return this.activefarmmaxcyclesField;
        }
        set {
            this.activefarmmaxcyclesField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string activefarmactiondurationseconds {
        get {
            return this.activefarmactiondurationsecondsField;
        }
        set {
            this.activefarmactiondurationsecondsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string activefarmcyclelengthseconds {
        get {
            return this.activefarmcyclelengthsecondsField;
        }
        set {
            this.activefarmcyclelengthsecondsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string activefarmbonus {
        get {
            return this.activefarmbonusField;
        }
        set {
            this.activefarmbonusField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string prefabname {
        get {
            return this.prefabnameField;
        }
        set {
            this.prefabnameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string prefabscale {
        get {
            return this.prefabscaleField;
        }
        set {
            this.prefabscaleField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string resourcevalue {
        get {
            return this.resourcevalueField;
        }
        set {
            this.resourcevalueField = value;
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
    public string uisprite {
        get {
            return this.uispriteField;
        }
        set {
            this.uispriteField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string showinmarketplace {
        get {
            return this.showinmarketplaceField;
        }
        set {
            this.showinmarketplaceField = value;
        }
    }
}