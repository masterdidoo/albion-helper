/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class itemsWeapon : IItem {
    
    private itemsWeaponProjectile[] projectileField;
    
    private itemsWeaponCanharvest[] canharvestField;
    
    private craftingrequirements[] craftingrequirementsField;
    
    private AudioInfo[] audioInfoField;
    
    private SocketPreset[] socketPresetField;
    
    private craftingspelllistCraftspell[] craftingspelllistField;
    
    private enchantmentsEnchantment[] enchantmentsField;
    
    private AssetVfxPreset[] assetVfxPresetField;
    
    private string uniquenameField;
    
    private string meshField;
    
    private string uispriteField;
    
    private string maxqualitylevelField;
    
    private string abilitypowerField;
    
    private string slottypeField;
    
    private string shopcategoryField;
    
    private string shopsubcategory1Field;
    
    private string attacktypeField;
    
    private string attackdamageField;
    
    private string attackspeedField;
    
    private string attackrangeField;
    
    private string twohandedField;
    
    private string tierField;
    
    private string weightField;
    
    private string activespellslotsField;
    
    private string passivespellslotsField;
    
    private string durabilityField;
    
    private string durabilityloss_attackField;
    
    private string durabilityloss_spelluseField;
    
    private string durabilityloss_receivedattackField;
    
    private string durabilityloss_receivedspellField;
    
    private string mainhandanimationtypeField;
    
    private string unlockedtocraftField;
    
    private string unlockedtoequipField;
    
    private string itempowerField;
    
    private string unequipincombatField;
    
    private string uicraftsoundstartField;
    
    private string uicraftsoundfinishField;
    
    private string canbeoverchargedField;
    
    private string attackbuildingdamageField;
    
    private string fishingField;
    
    private string fishingspeedField;
    
    private string physicalspelldamagebonusField;
    
    private string magicspelldamagebonusField;
    
    private string fxbonenameField;
    
    private string fxboneoffsetField;
    
    private string hitpointsmaxField;
    
    private string hitpointsregenerationbonusField;
    
    private string itempowerprogressiontypeField;
    
    private string focusfireprotectionpenerationField;
    
    private string craftingcategoryField;
    
    private string healmodifierField;
    
    private string showinmarketplaceField;
    
    private string attackdamagetimefactorField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("projectile", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public itemsWeaponProjectile[] projectile {
        get {
            return this.projectileField;
        }
        set {
            this.projectileField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("canharvest", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public itemsWeaponCanharvest[] canharvest {
        get {
            return this.canharvestField;
        }
        set {
            this.canharvestField = value;
        }
    }
    
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
    public string attacktype {
        get {
            return this.attacktypeField;
        }
        set {
            this.attacktypeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string attackdamage {
        get {
            return this.attackdamageField;
        }
        set {
            this.attackdamageField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string attackspeed {
        get {
            return this.attackspeedField;
        }
        set {
            this.attackspeedField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string attackrange {
        get {
            return this.attackrangeField;
        }
        set {
            this.attackrangeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string twohanded {
        get {
            return this.twohandedField;
        }
        set {
            this.twohandedField = value;
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
    public string unequipincombat {
        get {
            return this.unequipincombatField;
        }
        set {
            this.unequipincombatField = value;
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
    public string attackbuildingdamage {
        get {
            return this.attackbuildingdamageField;
        }
        set {
            this.attackbuildingdamageField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string fishing {
        get {
            return this.fishingField;
        }
        set {
            this.fishingField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string fishingspeed {
        get {
            return this.fishingspeedField;
        }
        set {
            this.fishingspeedField = value;
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
    public string fxbonename {
        get {
            return this.fxbonenameField;
        }
        set {
            this.fxbonenameField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string fxboneoffset {
        get {
            return this.fxboneoffsetField;
        }
        set {
            this.fxboneoffsetField = value;
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
    public string focusfireprotectionpeneration {
        get {
            return this.focusfireprotectionpenerationField;
        }
        set {
            this.focusfireprotectionpenerationField = value;
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
    public string attackdamagetimefactor {
        get {
            return this.attackdamagetimefactorField;
        }
        set {
            this.attackdamagetimefactorField = value;
        }
    }
}