using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

/// <remarks />
[GeneratedCode("xsd", "4.6.1055.0")]
[Serializable]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
public class itemsFurnitureitem : IItem
{
    private string accessrightspresetField;

    private string cheatproviderField;

    private itemsFurnitureitemContainer[] containerField;

    private string craftfamegainfactorField;

    private craftingrequirements[] craftingrequirementsField;

    private string customizewithguildlogoField;

    private string descriptionlocatagField;

    private string durabilityField;

    private string durabilitylossperdayfactorField;

    private string durabilitylossperusefactorField;

    private string enchantmentlevelField;

    private string itemvalueField;

    private string labourerfurnituretypeField;

    private string labourerhappinessField;

    private string labourersaffectedField;

    private string labourersperfurnitureitemField;

    private string placeableindoorsField;

    private string placeableindungeonsField;

    private string placeableonlyonislandsField;

    private string placeableoutdoorsField;

    private itemsFurnitureitemRepairkit[] repairkitField;

    private string residencyslotsField;

    private string shopcategoryField;

    private string shopsubcategory1Field;

    private string showinmarketplaceField;

    private string tierField;

    private string tileField;

    private string uicraftsoundfinishField;

    private string uicraftsoundstartField;

    private string uispriteField;

    private string uniquenameField;

    private string unlockedtocraftField;

    private string weightField;

    /// <remarks />
    [XmlElement(Form = XmlSchemaForm.Unqualified)]
    public string cheatprovider
    {
        get => cheatproviderField;
        set => cheatproviderField = value;
    }

    /// <remarks />
    [XmlElement("craftingrequirements")]
    public craftingrequirements[] craftingrequirements
    {
        get => craftingrequirementsField;
        set => craftingrequirementsField = value;
    }

    /// <remarks />
    [XmlElement("container", Form = XmlSchemaForm.Unqualified)]
    public itemsFurnitureitemContainer[] container
    {
        get => containerField;
        set => containerField = value;
    }

    /// <remarks />
    [XmlElement("repairkit", Form = XmlSchemaForm.Unqualified)]
    public itemsFurnitureitemRepairkit[] repairkit
    {
        get => repairkitField;
        set => repairkitField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string shopsubcategory1
    {
        get => shopsubcategory1Field;
        set => shopsubcategory1Field = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string tier
    {
        get => tierField;
        set => tierField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string durability
    {
        get => durabilityField;
        set => durabilityField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string durabilitylossperdayfactor
    {
        get => durabilitylossperdayfactorField;
        set => durabilitylossperdayfactorField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string weight
    {
        get => weightField;
        set => weightField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string unlockedtocraft
    {
        get => unlockedtocraftField;
        set => unlockedtocraftField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string placeableindoors
    {
        get => placeableindoorsField;
        set => placeableindoorsField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string placeableoutdoors
    {
        get => placeableoutdoorsField;
        set => placeableoutdoorsField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string placeableindungeons
    {
        get => placeableindungeonsField;
        set => placeableindungeonsField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string accessrightspreset
    {
        get => accessrightspresetField;
        set => accessrightspresetField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string uicraftsoundstart
    {
        get => uicraftsoundstartField;
        set => uicraftsoundstartField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string uicraftsoundfinish
    {
        get => uicraftsoundfinishField;
        set => uicraftsoundfinishField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string customizewithguildlogo
    {
        get => customizewithguildlogoField;
        set => customizewithguildlogoField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string enchantmentlevel
    {
        get => enchantmentlevelField;
        set => enchantmentlevelField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string uisprite
    {
        get => uispriteField;
        set => uispriteField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string tile
    {
        get => tileField;
        set => tileField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string itemvalue
    {
        get => itemvalueField;
        set => itemvalueField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string showinmarketplace
    {
        get => showinmarketplaceField;
        set => showinmarketplaceField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string residencyslots
    {
        get => residencyslotsField;
        set => residencyslotsField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string labourerfurnituretype
    {
        get => labourerfurnituretypeField;
        set => labourerfurnituretypeField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string labourersaffected
    {
        get => labourersaffectedField;
        set => labourersaffectedField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string labourerhappiness
    {
        get => labourerhappinessField;
        set => labourerhappinessField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string labourersperfurnitureitem
    {
        get => labourersperfurnitureitemField;
        set => labourersperfurnitureitemField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string placeableonlyonislands
    {
        get => placeableonlyonislandsField;
        set => placeableonlyonislandsField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string descriptionlocatag
    {
        get => descriptionlocatagField;
        set => descriptionlocatagField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string craftfamegainfactor
    {
        get => craftfamegainfactorField;
        set => craftfamegainfactorField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string durabilitylossperusefactor
    {
        get => durabilitylossperusefactorField;
        set => durabilitylossperusefactorField = value;
    }

    public string craftingcategory => "itemsFurnitureitem???";


    /// <remarks />
    [XmlAttribute]
    public string uniquename
    {
        get => uniquenameField;
        set => uniquenameField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string shopcategory
    {
        get => shopcategoryField;
        set => shopcategoryField = value;
    }
}