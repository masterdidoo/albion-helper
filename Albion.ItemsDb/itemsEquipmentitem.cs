/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class itemsEquipmentitem : IItem {
    
    private craftingrequirements[] craftingrequirementsField;
    
    private SocketPreset[] socketPresetField;
    
    private AssetVfxPreset[] assetVfxPresetField;
    
    private enchantmentsEnchantment[] enchantmentsField;
    
    private craftingspelllistCraftspell[] craftingspelllistField;
    
    private AudioInfo[] audioInfoField;
    
    private string uniquenameField;
    
    private string uispriteField;
    
    private string maxqualitylevelField;
    
    private string abilitypowerField;
    
    private string slottypeField;
    
    private string itempowerprogressiontypeField;
    
    private string shopcategoryField;
    
    private string shopsubcategory1Field;
    
    private string uicraftsoundstartField;
    
    private string uicraftsoundfinishField;
    
    private string skincountField;
    
    private string tierField;
    
    private string weightField;
    
    private string activespellslotsField;
    
    private string passivespellslotsField;
    
    private string physicalarmorField;
    
    private string magicresistanceField;
    
    private string durabilityField;
    
    private string durabilityloss_attackField;
    
    private string durabilityloss_spelluseField;
    
    private string durabilityloss_receivedattackField;
    
    private string durabilityloss_receivedspellField;
    
    private string offhandanimationtypeField;
    
    private string unlockedtocraftField;
    
    private string unlockedtoequipField;
    
    private string hitpointsmaxField;
    
    private string hitpointsregenerationbonusField;
    
    private string energymaxField;
    
    private string energyregenerationbonusField;
    
    private string crowdcontrolresistanceField;
    
    private string itempowerField;
    
    private string physicalattackdamagebonusField;
    
    private string magicattackdamagebonusField;
    
    private string physicalspelldamagebonusField;
    
    private string magicspelldamagebonusField;
    
    private string healbonusField;
    
    private string bonusccdurationvsplayersField;
    
    private string bonusccdurationvsmobsField;
    
    private string threatbonusField;
    
    private string magiccooldownreductionField;
    
    private string bonusdefensevsplayersField;
    
    private string bonusdefensevsmobsField;
    
    private string magiccasttimereductionField;
    
    private string attackspeedbonusField;
    
    private string movespeedbonusField;
    
    private string healmodifierField;
    
    private string canbeoverchargedField;
    
    private string showinmarketplaceField;
    
    private string energycostreductionField;
    
    private string craftingcategoryField;
    
    private string tradableField;
    
    private string movespeedField;
    
    private string maxloadField;
    
    private string facestateField;
    
    private string requiredaccesslevelField;
    
    private string uispriteoverlayField;
    
    private string beardstateField;
    
    private string meshField;
    
    private string craftfamegainfactorField;
    
    private string enchantmentlevelField;
    
    private string mainhandanimationtypeField;
    
    private string descriptionlocatagField;
    
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
    [System.Xml.Serialization.XmlElementAttribute("SocketPreset")]
    public SocketPreset[] SocketPreset {
        get {
            return this.socketPresetField;
        }
        set {
            this.socketPresetField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("AssetVfxPreset")]
    public AssetVfxPreset[] AssetVfxPreset {
        get {
            return this.assetVfxPresetField;
        }
        set {
            this.assetVfxPresetField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("enchantment", typeof(enchantmentsEnchantment), Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
    public enchantmentsEnchantment[] enchantments {
        get {
            return this.enchantmentsField;
        }
        set {
            this.enchantmentsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlArrayItemAttribute("craftspell", typeof(craftingspelllistCraftspell), Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
    public craftingspelllistCraftspell[] craftingspelllist {
        get {
            return this.craftingspelllistField;
        }
        set {
            this.craftingspelllistField = value;
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
    public string maxqualitylevel {
        get {
            return this.maxqualitylevelField;
        }
        set {
            this.maxqualitylevelField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string abilitypower {
        get {
            return this.abilitypowerField;
        }
        set {
            this.abilitypowerField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string slottype {
        get {
            return this.slottypeField;
        }
        set {
            this.slottypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string itempowerprogressiontype {
        get {
            return this.itempowerprogressiontypeField;
        }
        set {
            this.itempowerprogressiontypeField = value;
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
    public string uicraftsoundstart {
        get {
            return this.uicraftsoundstartField;
        }
        set {
            this.uicraftsoundstartField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string uicraftsoundfinish {
        get {
            return this.uicraftsoundfinishField;
        }
        set {
            this.uicraftsoundfinishField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string skincount {
        get {
            return this.skincountField;
        }
        set {
            this.skincountField = value;
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
    public string activespellslots {
        get {
            return this.activespellslotsField;
        }
        set {
            this.activespellslotsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string passivespellslots {
        get {
            return this.passivespellslotsField;
        }
        set {
            this.passivespellslotsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string physicalarmor {
        get {
            return this.physicalarmorField;
        }
        set {
            this.physicalarmorField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string magicresistance {
        get {
            return this.magicresistanceField;
        }
        set {
            this.magicresistanceField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string durability {
        get {
            return this.durabilityField;
        }
        set {
            this.durabilityField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string durabilityloss_attack {
        get {
            return this.durabilityloss_attackField;
        }
        set {
            this.durabilityloss_attackField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string durabilityloss_spelluse {
        get {
            return this.durabilityloss_spelluseField;
        }
        set {
            this.durabilityloss_spelluseField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string durabilityloss_receivedattack {
        get {
            return this.durabilityloss_receivedattackField;
        }
        set {
            this.durabilityloss_receivedattackField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string durabilityloss_receivedspell {
        get {
            return this.durabilityloss_receivedspellField;
        }
        set {
            this.durabilityloss_receivedspellField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string offhandanimationtype {
        get {
            return this.offhandanimationtypeField;
        }
        set {
            this.offhandanimationtypeField = value;
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
    public string unlockedtoequip {
        get {
            return this.unlockedtoequipField;
        }
        set {
            this.unlockedtoequipField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string hitpointsmax {
        get {
            return this.hitpointsmaxField;
        }
        set {
            this.hitpointsmaxField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string hitpointsregenerationbonus {
        get {
            return this.hitpointsregenerationbonusField;
        }
        set {
            this.hitpointsregenerationbonusField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string energymax {
        get {
            return this.energymaxField;
        }
        set {
            this.energymaxField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string energyregenerationbonus {
        get {
            return this.energyregenerationbonusField;
        }
        set {
            this.energyregenerationbonusField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string crowdcontrolresistance {
        get {
            return this.crowdcontrolresistanceField;
        }
        set {
            this.crowdcontrolresistanceField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string itempower {
        get {
            return this.itempowerField;
        }
        set {
            this.itempowerField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string physicalattackdamagebonus {
        get {
            return this.physicalattackdamagebonusField;
        }
        set {
            this.physicalattackdamagebonusField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string magicattackdamagebonus {
        get {
            return this.magicattackdamagebonusField;
        }
        set {
            this.magicattackdamagebonusField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string physicalspelldamagebonus {
        get {
            return this.physicalspelldamagebonusField;
        }
        set {
            this.physicalspelldamagebonusField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string magicspelldamagebonus {
        get {
            return this.magicspelldamagebonusField;
        }
        set {
            this.magicspelldamagebonusField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string healbonus {
        get {
            return this.healbonusField;
        }
        set {
            this.healbonusField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string bonusccdurationvsplayers {
        get {
            return this.bonusccdurationvsplayersField;
        }
        set {
            this.bonusccdurationvsplayersField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string bonusccdurationvsmobs {
        get {
            return this.bonusccdurationvsmobsField;
        }
        set {
            this.bonusccdurationvsmobsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string threatbonus {
        get {
            return this.threatbonusField;
        }
        set {
            this.threatbonusField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string magiccooldownreduction {
        get {
            return this.magiccooldownreductionField;
        }
        set {
            this.magiccooldownreductionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string bonusdefensevsplayers {
        get {
            return this.bonusdefensevsplayersField;
        }
        set {
            this.bonusdefensevsplayersField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string bonusdefensevsmobs {
        get {
            return this.bonusdefensevsmobsField;
        }
        set {
            this.bonusdefensevsmobsField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string magiccasttimereduction {
        get {
            return this.magiccasttimereductionField;
        }
        set {
            this.magiccasttimereductionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string attackspeedbonus {
        get {
            return this.attackspeedbonusField;
        }
        set {
            this.attackspeedbonusField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string movespeedbonus {
        get {
            return this.movespeedbonusField;
        }
        set {
            this.movespeedbonusField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string healmodifier {
        get {
            return this.healmodifierField;
        }
        set {
            this.healmodifierField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string canbeovercharged {
        get {
            return this.canbeoverchargedField;
        }
        set {
            this.canbeoverchargedField = value;
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
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string energycostreduction {
        get {
            return this.energycostreductionField;
        }
        set {
            this.energycostreductionField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string craftingcategory {
        get {
            return this.craftingcategoryField;
        }
        set {
            this.craftingcategoryField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string tradable {
        get {
            return this.tradableField;
        }
        set {
            this.tradableField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string movespeed {
        get {
            return this.movespeedField;
        }
        set {
            this.movespeedField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string maxload {
        get {
            return this.maxloadField;
        }
        set {
            this.maxloadField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string facestate {
        get {
            return this.facestateField;
        }
        set {
            this.facestateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string requiredaccesslevel {
        get {
            return this.requiredaccesslevelField;
        }
        set {
            this.requiredaccesslevelField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string uispriteoverlay {
        get {
            return this.uispriteoverlayField;
        }
        set {
            this.uispriteoverlayField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string beardstate {
        get {
            return this.beardstateField;
        }
        set {
            this.beardstateField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string mesh {
        get {
            return this.meshField;
        }
        set {
            this.meshField = value;
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
    public string enchantmentlevel {
        get {
            return this.enchantmentlevelField;
        }
        set {
            this.enchantmentlevelField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string mainhandanimationtype {
        get {
            return this.mainhandanimationtypeField;
        }
        set {
            this.mainhandanimationtypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string descriptionlocatag {
        get {
            return this.descriptionlocatagField;
        }
        set {
            this.descriptionlocatagField = value;
        }
    }
}