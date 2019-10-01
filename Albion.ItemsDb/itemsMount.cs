/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public class itemsMount : IItem
{
    
    private craftingrequirements[] craftingrequirementsField;
    
    private SocketPreset[] socketPresetField;
    
    private AudioInfo[] audioInfoField;
    
    private itemsMountFootStepVfxPreset[] footStepVfxPresetField;
    
    private AssetVfxPreset[] assetVfxPresetField;
    
    private itemsMountMountspelllistMountspell[] mountspelllistField;
    
    private craftingspelllistCraftspell[] craftingspelllistField;
    
    private string uniquenameField;
    
    private string mountcategoryField;
    
    private string maxqualitylevelField;
    
    private string itempowerField;
    
    private string abilitypowerField;
    
    private string slottypeField;
    
    private string shopcategoryField;
    
    private string shopsubcategory1Field;
    
    private string mountedbuffField;
    
    private string halfmountedbuffField;
    
    private string tierField;
    
    private string weightField;
    
    private string activespellslotsField;
    
    private string passivespellslotsField;
    
    private string durabilityField;
    
    private string durabilityloss_attackField;
    
    private string durabilityloss_spelluseField;
    
    private string durabilityloss_receivedattackField;
    
    private string durabilityloss_receivedspellField;
    
    private string durabilityloss_receivedattack_mountedField;
    
    private string durabilityloss_receivedspell_mountedField;
    
    private string durabilityloss_mountingField;
    
    private string unlockedtocraftField;
    
    private string unlockedtoequipField;
    
    private string mounttimeField;
    
    private string dismounttimeField;
    
    private string mounthitpointsmaxField;
    
    private string mounthitpointsregenerationField;
    
    private string prefabnameField;
    
    private string prefabscalingField;
    
    private string despawneffectField;
    
    private string despawneffectscalingField;
    
    private string remountdistanceField;
    
    private string halfmountrangeField;
    
    private string forceddismountcooldownField;
    
    private string forceddismountspellcooldownField;
    
    private string fulldismountcooldownField;
    
    private string remounttimeField;
    
    private string uicraftsoundstartField;
    
    private string uicraftsoundfinishField;
    
    private string dismountbuffField;
    
    private string uispriteField;
    
    private string showinmarketplaceField;
    
    private string enchantmentlevelField;
    
    private string canuseingvgField;
    
    private string itemvalueField;
    
    private string nametagoffsetField;
    
    private string craftfamegainfactorField;
    private string _craftingcategory;

    public string craftingcategory
    {
        get => "mount??";
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
    [System.Xml.Serialization.XmlElementAttribute("FootStepVfxPreset", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public itemsMountFootStepVfxPreset[] FootStepVfxPreset {
        get {
            return this.footStepVfxPresetField;
        }
        set {
            this.footStepVfxPresetField = value;
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
    [System.Xml.Serialization.XmlArrayAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    [System.Xml.Serialization.XmlArrayItemAttribute("mountspell", typeof(itemsMountMountspelllistMountspell), Form=System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable=false)]
    public itemsMountMountspelllistMountspell[] mountspelllist {
        get {
            return this.mountspelllistField;
        }
        set {
            this.mountspelllistField = value;
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
    public string mountcategory {
        get {
            return this.mountcategoryField;
        }
        set {
            this.mountcategoryField = value;
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
    public string mountedbuff {
        get {
            return this.mountedbuffField;
        }
        set {
            this.mountedbuffField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string halfmountedbuff {
        get {
            return this.halfmountedbuffField;
        }
        set {
            this.halfmountedbuffField = value;
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
    public string durabilityloss_receivedattack_mounted {
        get {
            return this.durabilityloss_receivedattack_mountedField;
        }
        set {
            this.durabilityloss_receivedattack_mountedField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string durabilityloss_receivedspell_mounted {
        get {
            return this.durabilityloss_receivedspell_mountedField;
        }
        set {
            this.durabilityloss_receivedspell_mountedField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string durabilityloss_mounting {
        get {
            return this.durabilityloss_mountingField;
        }
        set {
            this.durabilityloss_mountingField = value;
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
    public string mounttime {
        get {
            return this.mounttimeField;
        }
        set {
            this.mounttimeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string dismounttime {
        get {
            return this.dismounttimeField;
        }
        set {
            this.dismounttimeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string mounthitpointsmax {
        get {
            return this.mounthitpointsmaxField;
        }
        set {
            this.mounthitpointsmaxField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string mounthitpointsregeneration {
        get {
            return this.mounthitpointsregenerationField;
        }
        set {
            this.mounthitpointsregenerationField = value;
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
    public string prefabscaling {
        get {
            return this.prefabscalingField;
        }
        set {
            this.prefabscalingField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string despawneffect {
        get {
            return this.despawneffectField;
        }
        set {
            this.despawneffectField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string despawneffectscaling {
        get {
            return this.despawneffectscalingField;
        }
        set {
            this.despawneffectscalingField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string remountdistance {
        get {
            return this.remountdistanceField;
        }
        set {
            this.remountdistanceField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string halfmountrange {
        get {
            return this.halfmountrangeField;
        }
        set {
            this.halfmountrangeField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string forceddismountcooldown {
        get {
            return this.forceddismountcooldownField;
        }
        set {
            this.forceddismountcooldownField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string forceddismountspellcooldown {
        get {
            return this.forceddismountspellcooldownField;
        }
        set {
            this.forceddismountspellcooldownField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string fulldismountcooldown {
        get {
            return this.fulldismountcooldownField;
        }
        set {
            this.fulldismountcooldownField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string remounttime {
        get {
            return this.remounttimeField;
        }
        set {
            this.remounttimeField = value;
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
    public string dismountbuff {
        get {
            return this.dismountbuffField;
        }
        set {
            this.dismountbuffField = value;
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
    public string canuseingvg {
        get {
            return this.canuseingvgField;
        }
        set {
            this.canuseingvgField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string itemvalue {
        get {
            return this.itemvalueField;
        }
        set {
            this.itemvalueField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute()]
    public string nametagoffset {
        get {
            return this.nametagoffsetField;
        }
        set {
            this.nametagoffsetField = value;
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
}