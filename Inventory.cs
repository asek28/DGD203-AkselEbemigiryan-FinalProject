using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    public class Inventory
    {
        private Dictionary<string, int> items = new Dictionary<string, int>();

        public void Clear()
        {
            items.Clear();
        }
        public void AddItem(string item)
        {
            if (items.ContainsKey(item))
            {
                items[item]++;
            }
            else
            {
                items.Add(item, 1);
            }
            Console.WriteLine($"You acquired a {item}.");
        }
        public List<string> GetItems()
        {
            List<string> itemList = new List<string>();
            foreach (var kvp in items)
            {
                for (int i = 0; i < kvp.Value; i++)
                {
                    itemList.Add(kvp.Key);
                }
            }
            return itemList;
        }

        public bool HasItem(string item)
        {
            return items.ContainsKey(item) && items[item] > 0;
        }
    }
}
