using System.Collections.Generic;
using System.Linq;
using Albion.Db.Items.Requirements;
using Albion.Db.Items.Requirements.Resources;
using Albion.Db.Items.ViewModels;
using Albion.Db.JsonLoader;

namespace Albion.Db.Items
{
    public class All
    {
        public IPlayerContext Context { get; }

        public SimpleItem[] Weapons { get; set; }

        public SimpleItem[] FarmableItem { get; set; }

        public SimpleItem[] SimpleItems { get; }

        public IDictionary<string, SimpleItem> ItemsDb { get; } = new Dictionary<string, SimpleItem>();

        public ArtefactVm[] Artefacts { get; }

        public SimpleItem GetItem(string id)
        {
            if (id.Length > 2 && id[id.Length - 2] == '@') id = id.Substring(0, id.Length - 2);
            if (ItemsDb.TryGetValue(id, out var item)) return item;
            item = new SimpleItem(id, Context);
            ItemsDb.Add(id,item);
            return item;
        }

        #region JsonLoader

        public readonly CraftingRequirement[] Empty = new CraftingRequirement[0];
        public readonly CraftResource[] Empty2 = new CraftResource[0];

        public All(JsonDb db, JsonNames[] jnames)
        {
            var names = jnames.Where(x=>x.LocalizedNames!=null).ToDictionary(k => k.UniqueName, v => v.LocalizedNames.RU);

            Context = new PlayerContext();
            FarmableItem = db.Items.Farmableitem
                .Select(x =>
                {
                    var art = GetItem(x.Uniquename);
                    art.Name = names[x.Uniquename];
                    art.Tier = x.Tier;
                    art.Weight = x.Weight;
                    art.ShopCategory = x.Shopcategory;
                    art.CraftingRequirements =
                        GetCraftingRequirements(x.Craftingrequirements, art);

                    return art;
                })
                .ToArray();

            SimpleItems = db.Items.Simpleitem
                .Select(x =>
                {
                    var art = GetItem(x.Uniquename);
                    art.Name = names.TryGetValue(x.Uniquename, out var name) ? name : x.Uniquename;
                    art.ItemValue = x.Itemvalue ?? 0;
                    art.Tier = x.Tier;
                    art.Weight = x.Weight;
                    art.ShopCategory = x.Shopcategory;
                    art.Craftingcategory = x.Craftingcategory ?? Craftingcategory.None;
                    art.CraftingRequirements =
                        GetCraftingRequirements(x.Craftingrequirements, art);

                    return art;
                })
                .ToArray();

            Weapons = db.Items.Weapon
                .Select(x =>
                {
                    var art = GetItem(x.Uniquename);
                    art.Name = names.TryGetValue(x.Uniquename, out var name) ? name : x.Uniquename;
                    art.ItemValue = x.Itempower;
                    art.Tier = x.Tier;
                    art.Weight = x.Weight;
                    art.ShopCategory = x.Shopcategory;
                    art.Craftingcategory = x.Craftingcategory ?? Craftingcategory.None;
                    art.CraftingRequirements =
                        GetCraftingRequirements(x.Craftingrequirements, art);

                    return art;
                })
                .ToArray();

            Equipment = db.Items.Equipmentitem
                .Select(x =>
                {
                    var art = GetItem(x.Uniquename);
                    art.Name = names.TryGetValue(x.Uniquename, out var name) ? name : x.Uniquename;
                    art.ItemValue = x.Itempower;
                    art.Tier = x.Tier;
                    art.Weight = x.Weight;
                    art.ShopCategory = x.Shopcategory;
                    art.Craftingcategory = x.Craftingcategory ?? Craftingcategory.None;
                    art.CraftingRequirements =
                        GetCraftingRequirements(x.Craftingrequirements, art);

                    return art;
                })
                .ToArray();

            Artefacts = SimpleItems.Where(x => x.ShopCategory == ShopCategory.Artefacts).Select(s=>new ArtefactVm(s)).ToArray();
        }

        public SimpleItem[] Equipment { get; set; }

        private CraftingRequirement[] GetCraftingRequirements(Craftingrequirements? craftingrequirements,
            SimpleItem item)
        {
            if (craftingrequirements == null) return Empty;

            {
                var cvt = craftingrequirements.Value.Craftingrequirement;
                if (cvt != null)
                    return new []
                    {
                        new CraftingRequirement(item, GetCraftResources(cvt.Craftresource), cvt.Silver * 10000 ?? 0)
                    };
            }
            if (craftingrequirements.Value.CraftingrequirementArrayArray != null)
                return
                    craftingrequirements.Value.CraftingrequirementArrayArray.Select(cvt =>
                        new CraftingRequirement(item, GetCraftResources(cvt.Craftresource), cvt.Silver * 10000 ?? 0)).ToArray();

            return Empty;
        }

        private CraftResource[] GetCraftResources(CraftingrequirementCraftresourceUnion? craftresource)
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
    }
}