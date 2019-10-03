using System.Diagnostics;
using Albion.ItemsDb.Enums;
using Albion.ItemsDb.Requirements;

namespace Albion.ItemsDb
{
    public interface IItem
    {
        string uniquename { get; }
        shopCategory shopcategory { get; }
        shopSubCategory shopsubcategory1 { get; }

        Craftingrequirements[] craftingrequirements { get; }

        int tier { get; set; }
    }

    public interface IItemPowered : IItem
    {
        int itempower { get; }
    }

    public interface IItemValued : IItem
    {
        int itemvalue { get; }
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