﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPGrowth.Algorithm
{
    class ItemSet
    {
        private List<Item> items; //list of items in item set
        private int supportCount; // support count of this item set

        public int SupportCount
        {
            get { return supportCount; }
            set { supportCount = value; }
        }
        public List<Item> Items
        {
            get { return items; }
            set { items = value; }
        }

        //constructor
        public ItemSet()
        {
            items = new List<Item>();
            supportCount = 0;
        }
        //add item into item set
        public void AddItem(Item item)
        {
            items.Add(item);
            supportCount = item.GetCount();
        }
        //remove item
        public Item GetItem(int position)
        {
            if (position < items.Count)
                return items[position];
            else
                return null;
        }
        //add item into item set
        public bool IsEmpty()
        {
            return items.Count == 0;
        }
        //add item into item set
        public int GetLength()
        {
            return items.Count;
        }
        public ItemSet Clone()
        {
            ItemSet itemSet = new ItemSet();
            itemSet.SupportCount = SupportCount;
            foreach (Item anItem in items)
            {
                itemSet.AddItem(anItem.Clone());
            }
            return itemSet;
        }
        public string GetInfoString()
        {
            string info = "[";
            foreach (Item anItem in items)
            {
                info += anItem.GetItemName().ToString() + ", ";
            }
            info = info.Remove(info.Length - 2, 2);
            info += "]: " + SupportCount;
            return info;
        }
        public void Print()
        {
            Console.WriteLine(SupportCount);
            foreach (Item item in items)
            {
                Console.Write(item.GetItemName().ToString() + " ");
            }
        }

        public Item GetLastItem()
        {
            return items.Last();
        }
    }
}
