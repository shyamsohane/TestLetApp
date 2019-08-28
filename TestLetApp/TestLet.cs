using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLetApp
{
    public class Testlet
    {
        public string TestletId;
        private List<Item> Items;
        public Testlet(string testletId, List<Item> items)
        {
            TestletId = testletId;
            Items = items;
        }
        public List<Item> Randomize()
        {
            //if there are not items return null value.
            if (Items == null)
                return null;
            Random rnd = new Random();
            //Taking only two pretest items as per problem but we can parameterize this to make dynamic and genric.
            var filteredTwoPreTestItems = Items.Where(x => x.ItemType == ItemTypeEnum.Pretest).OrderBy((item) => rnd.Next()).Take(2).ToList();
            var remainingRandomList= Items.Except(filteredTwoPreTestItems).OrderBy((item) => rnd.Next()).ToList();
            //Items private collection has 6 Operational and 4 Pretest Items. Randomize the order of these items as per the requirement (with TDD)
            filteredTwoPreTestItems.AddRange(remainingRandomList);
            return filteredTwoPreTestItems;
        }
    }
    public class Item
    {
        public string ItemId;
        public ItemTypeEnum ItemType;
    }
    public enum ItemTypeEnum
    {
        Pretest = 0,
        Operational = 1
    }
}
