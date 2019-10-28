using System.Diagnostics;
using Albion.Db.Xml.Enums;
using Albion.Db.Xml.Requirements;

namespace Albion.Db.Xml
{
    public interface IItem
    {
        string uniquename { get; }
        shopCategory shopcategory { get; }
        shopSubCategory shopsubcategory1 { get; }

        Craftingrequirements[] craftingrequirements { get; }

        int tier { get; }
        bool unlockedtocraft { get; }
    }

    public interface IItemSalvageable : IItem
    {
        bool salvageable { get; }
    }

    public interface IItemEnchantmentLevel : IItem
    {
        int enchantmentlevel { get; }
    }

    public interface IItemPowered : IItem
    {
        int itempower { get; }
    }

    public interface IItemPowered2 : IItem
    {
        int dummyitempower { get; }
    }

    public interface IItemValued : IItemEnchantmentLevel
    {
        float itemvalue { get; }
    }

    public interface IItemCraftingcategory : IItem
    {
        string craftingcategory { get; }
    }

    public interface IItemEnchantments : IItem
    {
        EnchantmentsEnchantment[] enchantments { get; }
    }
}