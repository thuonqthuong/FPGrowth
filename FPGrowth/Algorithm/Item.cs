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
            this.count = -1;
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

        public Item(string _item_name)
            : this()
        {
            item_name = _item_name;
        }
        public Item(string _item_name, int _supportCount)
            : this()
        {
            item_name = _item_name;
            count = _supportCount;
        }
        public Item Clone()
        {
            Item item = new Item(item_name, count);
            return item;
        }
    }
}
