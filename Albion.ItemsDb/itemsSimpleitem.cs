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
public class itemsSimpleitem : IItem
{
    private string canbestoredinbattlevaultField;

    private string craftfamegainfactorField;

    private string craftingcategoryField;

    private craftingrequirements[] craftingrequirementsField;

    private string descriptionlocatagField;

    private string descvariable0Field;

    private string descvariable1Field;

    private string enchantmentlevelField;

    private string fasttravelfactorField;

    private string fishingfameField;

    private string fishingminigamesettingField;

    private string foodcategoryField;

    private string itemvalueField;

    private string maxstacksizeField;

    private string namelocatagField;

    private string nutritionField;

    private itemsSimpleitemReplaceondeathReplacementitem[] replaceondeathField;

    private string resourcetypeField;

    private string salvageableField;

    private string shopcategoryField;

    private string shopsubcategory1Field;

    private string showinmarketplaceField;

    private string tierField;

    private string uicraftsoundfinishField;

    private string uicraftsoundstartField;

    private string uispriteField;

    private string uniquenameField;

    private string unlockedtocraftField;

    private string weightField;

    /// <remarks />
    [XmlArray(Form = XmlSchemaForm.Unqualified)]
    [XmlArrayItem("replacementitem", typeof(itemsSimpleitemReplaceondeathReplacementitem),
        Form = XmlSchemaForm.Unqualified, IsNullable = false)]
    public itemsSimpleitemReplaceondeathReplacementitem[] replaceondeath
    {
        get => replaceondeathField;
        set => replaceondeathField = value;
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
    public string weight
    {
        get => weightField;
        set => weightField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string maxstacksize
    {
        get => maxstacksizeField;
        set => maxstacksizeField = value;
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
    public string shopcategory
    {
        get => shopcategoryField;
        set => shopcategoryField = value;
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
    public string unlockedtocraft
    {
        get => unlockedtocraftField;
        set => unlockedtocraftField = value;
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
    public string nutrition
    {
        get => nutritionField;
        set => nutritionField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string foodcategory
    {
        get => foodcategoryField;
        set => foodcategoryField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string resourcetype
    {
        get => resourcetypeField;
        set => resourcetypeField = value;
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
    public string enchantmentlevel
    {
        get => enchantmentlevelField;
        set => enchantmentlevelField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string fishingfame
    {
        get => fishingfameField;
        set => fishingfameField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string fishingminigamesetting
    {
        get => fishingminigamesettingField;
        set => fishingminigamesettingField = value;
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
    public string fasttravelfactor
    {
        get => fasttravelfactorField;
        set => fasttravelfactorField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string namelocatag
    {
        get => namelocatagField;
        set => namelocatagField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string salvageable
    {
        get => salvageableField;
        set => salvageableField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string descvariable0
    {
        get => descvariable0Field;
        set => descvariable0Field = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string descvariable1
    {
        get => descvariable1Field;
        set => descvariable1Field = value;
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
    public string canbestoredinbattlevault
    {
        get => canbestoredinbattlevaultField;
        set => canbestoredinbattlevaultField = value;
    }

    /// <remarks />
    [XmlElement("craftingrequirements")]
    public craftingrequirements[] craftingrequirements
    {
        get => craftingrequirementsField;
        set => craftingrequirementsField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string uniquename
    {
        get => uniquenameField;
        set => uniquenameField = value;
    }

    /// <remarks />
    [XmlAttribute]
    public string craftingcategory
    {
        get => craftingcategoryField;
        set => craftingcategoryField = value;
    }
}