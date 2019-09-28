using System;
using System.Collections;
using System.Collections.Generic;
using Albion.Common;
using Albion.Db.Items;
using Albion.Db.Items.Requirements;
using Albion.Db.Items.Requirements.Resources;

namespace Albion.GUI
{
    public class TestData : List<SimpleItem>
    {
        public TestData()
        {
            var cont = new TestPlayerContext();

            var empty = new CraftingRequirement[0];

            SimpleItem item1 = new SimpleItem("test00", cont)
            {
                CraftingRequirements = empty,
            };

            item1.FastBuyRequirement.Silver = 1000*10000;
            Add(item1);

            var item2 = new SimpleItem("test", cont);
            item2.CraftingRequirements = new []
            {
                new CraftingRequirement(item2)
                {
                    IsExpanded = true,
                    IsMin = true,
                    CraftResources = new CraftResource[]
                    {
                        new CraftResource()
                        {
                            Count = 10,
                            Item = item1
                        },
                    }
                }
            };
            Add(item2);

            Add(new SimpleItem("test2", cont)
            {
                CraftingRequirements = empty
            });
            Add(new SimpleItem("test3", cont)
            {
                CraftingRequirements = empty
            });
        }
    }

    public class TestPlayerContext : IPlayerContext
    {
        public int TownIndex { get; }
        public Location Town { get; set; }

        public long GetCraftTax(ShopCategory shopCategory)
        {
            return 10000;
        }

        public event Action TownIndexChanged;
        public void SavePricesContainer(string id, PricesContainer pricesContainer)
        {
        }

        public PricesContainer LoadPricesContainer(string id)
        {
            return null;
        }

        public long GetReturn(Craftingcategory category)
        {
            return 100;
        }
    }
}