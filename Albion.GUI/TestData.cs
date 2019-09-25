using System.Collections;
using System.Collections.Generic;
using Albion.Db.Items;
using Albion.Db.Items.Requirements;
using Albion.Db.Items.Requirements.Resources;

namespace Albion.GUI
{
    public class TestData : List<SimpleItem>
    {
        public TestData()
        {
            var empty = new CraftingRequirement[0];

            SimpleItem item1 = new SimpleItem("test00", null)
            {
                CraftingRequirements = empty
            };
            Add(item1);

            var item2 = new SimpleItem("test", null);
            item2.CraftingRequirements = new []
            {
                new CraftingRequirement(item2)
                {
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

            Add(new SimpleItem("test2", null)
            {
                CraftingRequirements = empty
            });
            Add(new SimpleItem("test3", null)
            {
                CraftingRequirements = empty
            });
        }
    }
}