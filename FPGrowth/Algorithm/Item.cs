using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPGrowth.Algorithm
{
    class Item
    {
        private String item_name;
        private int count;
        public Item()
        {
            this.item_name = null;
            this.count = 0;
        }
        public string GetItemName()
        {
            return this.item_name;
        }

        public void SetItemName(string name)
        {
            this.item_name = name;
        }

        public int GetCount()
        {
            return this.count;
        }

        public void SetCount(int count)
        {
            this.count = count;
        }

        public Item(string item_name, int count)
        {
            this.item_name = item_name;
            this.count = count;
        }
    }
}
