using System.Collections;
using System.Collections.Generic;
using Albion.Db.Items;

namespace Albion.GUI
{
    public class TestData : List<SimpleItem>
    {
        public TestData()
        {
            BaseRequirement[] empty = new BaseRequirement[0];

            SimpleItem item1 = new SimpleItem("test00", null)
            {
                CraftingRequirements = empty
            };
            Add(item1);

            Add(new SimpleItem("test", null)
            {
                CraftingRequirements = new BaseRequirement[]
                {
                    new BaseRequirement()
                    {
                        CraftResources = new BaseResource[]
                        {
                            new BaseResource()
                            {
                                Count = 10,
                                Item = item1
                            }, 
                        }
                    }
                }
            });
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