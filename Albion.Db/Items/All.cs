using System.Collections.Generic;
using System.Linq;
using Albion.Common;
using Albion.Db.JsonLoader;

namespace Albion.Db.Items
{
    public class All
    {
        public SimpleItem[] Weapons { get; set; }

        public SimpleItem[] FarmableItem { get; set; }

        public SimpleItem[] SimpleItems { get; }

        public IDictionary<string, SimpleItem> ItemsDb { get; } = new Dictionary<string, SimpleItem>();

        public SimpleItem[] Artefacts { get; }

        public Location Town { get; set; }

        #region JsonLoader

        public readonly CraftingRequirement[] Empty = new CraftingRequirement[0];
        public readonly CraftResource[] Empty2 = new CraftResource[0];

        public All(JsonDb db)
        {
            FarmableItem = db.Items.Farmableitem
                .Select(x =>
                {
                    var art = GetItem(x.Uniquename);
                    art.Tier = x.Tier;
                    art.Weight = x.Weight;
                    art.ShopCategory = x.Shopcategory;
                    art.CraftingRequirements =
                        GetCraftingRequirements(x.Craftingrequirements);

                    return art;
                })
                .ToArray();

            SimpleItems = db.Items.Simpleitem
                .Select(x =>
                {
                    var art = new SimpleItem(x.Uniquename, this)
                    {
                        Tier = x.Tier,
                        Weight = x.Weight,
                        ShopCategory = x.Shopcategory,
                        CraftingRequirements =
                            GetCraftingRequirements(x.Craftingrequirements)
                    };

                    ItemsDb.Add(art.Id, art);

                    return art;
                })
                .ToArray();

            Weapons = db.Items.Weapon
                .Select(x =>
                {
                    var art = new SimpleItem(x.Uniquename, this)
                    {
                        Tier = x.Tier,
                        Weight = x.Weight,
                        ShopCategory = x.Shopcategory,
                        CraftingRequirements =
                            GetCraftingRequirements(x.Craftingrequirements)
                    };

                    ItemsDb.Add(art.Id, art);

                    return art;
                })
                .ToArray();

            Artefacts = SimpleItems.Where(x => x.ShopCategory == ShopCategory.Artefacts).ToArray();

        }

        private CraftingRequirement[] GetCraftingRequirements(Craftingrequirements? craftingrequirements)
        {
            if (craftingrequirements == null) return Empty;

            if (craftingrequirements.Value.TentacledCraftingrequirements != null)
                return new[]
                {
                    new CraftingRequirement
                    {
                        CraftResources =
                            GetCraftResources1(craftingrequirements.Value.TentacledCraftingrequirements.Craftresource)
                    }
                };
            if (craftingrequirements.Value.FluffyCraftingrequirementArray != null)
                return
                    craftingrequirements.Value.FluffyCraftingrequirementArray.Select(x =>
                        new CraftingRequirement
                        {
                            CraftResources = GetCraftResources1(x.Craftresource)
                        }).ToArray();

            return Empty;
        }

        private CraftResource[] GetCraftResources1(CraftingrequirementCraftresourceUnion? craftresource)
        {
            if (!craftresource.HasValue) return Empty2;

            if (craftresource.Value.CraftresourceElement != null)
            {
                var elem = craftresource.Value.CraftresourceElement;
                return new[]
                {
                    new CraftResource
                    {
                        Item = GetItem(elem.Uniquename),
                        Count = elem.Count
                    }
                };
            }

            return craftresource.Value.CraftresourceElementArray.Select(elem =>
                new CraftResource
                {
                    Item = GetItem(elem.Uniquename),
                    Count = elem.Count
                }
            ).ToArray();
        }

        #endregion

        public SimpleItem GetItem(string id)
        {
            if (ItemsDb.TryGetValue(id, out var item)) return item;
            item = new SimpleItem(id, this);
            return item;
        }
    }
}