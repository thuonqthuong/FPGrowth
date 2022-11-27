using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPGrowth.Algorithm
{
    class FPGrowthAlgorithm
    {
        FPTree fpTree;
        string[][] frequentItemsets;
        public static int index = 0;
        public FPGrowthAlgorithm()
        {
            fpTree = null;
        }
        public FPGrowthAlgorithm(FPTree tree)
            : this()
        {
            fpTree = tree;
        }
        public int GenerateFrequentItemSets()
        {
            List<Item> frequentItems = fpTree.FrequentItems;//FrequentItems giống Header Table
            int totalFrequentItemSets = frequentItems.Count;//Số các sản phẩm riêng biệt thỏa MinSupport
            Console.WriteLine("Itemsets");
            foreach (Item anItem in frequentItems)
            {
                ItemSet anItemSet = new ItemSet();
                anItemSet.AddItem(anItem);
                //Console.WriteLine(anItem.GetItemName()+"-"+anItem.GetCount());
                int t= Mine(fpTree, anItemSet);
                totalFrequentItemSets += t;
                //Console.WriteLine(t + " itemsets for " + anItemSet.GetInfoString());
            }
            
            //Console.WriteLine("GenerateFrequentItemSets_totalFrequentItemSets: "+totalFrequentItemSets);
            return totalFrequentItemSets;
        }

        private int Mine(FPTree fpTree, ItemSet anItemSet)
        {
            //Console.Write("1. Input Project: " + anItemSet.GetLastItem().GetItemName() +
                //"-"+ anItemSet.GetLastItem().GetCount()+"\r\n");
            FPTree projectedTree = fpTree.Project(anItemSet.GetLastItem());
            int minedItemSets =  projectedTree.FrequentItems.Count;
            //Console.Write("projectedTree.FrequentItems.Count: "+minedItemSets+"  ");
            //Console.Write("Mine_anItemSet.GetLastItem: " + anItemSet.GetLastItem().GetItemName()+"-"+ anItemSet.GetLastItem().GetCount() + "\r\n");
            Console.Write("\r\n1. anItemSet: " + anItemSet.GetInfoString() + "\r\n");
            //Console.Write("\r\n2. SupportCount: " + anItemSet.SupportCount + "\r\n");
            //Console.Write("2. Last Item: " + anItemSet.GetLastItem().GetItemName() + "\r\n");
            foreach (Item anItem in projectedTree.FrequentItems)
            {
                ItemSet nextItemSet = anItemSet.Clone();
                nextItemSet.AddItem(anItem);
                /*Console.Write("\r\n1. ItemSet: " + nextItemSet.GetInfoString() + "\r\n");
                Console.Write("2. Last: " + anItem.GetItemName() + "\r\n");*/
                minedItemSets += Mine(projectedTree, nextItemSet);
            }
            return minedItemSets;
        }
        public int CreateFPTreeAndGenerateFrequentItemsets(string[][] sortData, List<Item> items, int numTransact, int minSup)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            FPTree _fpTree = new FPTree(sortData, items, numTransact, minSup);
            //Console.Write("CreateFPTreeAndGenerateFrequentItemsets\r\n");
            fpTree = _fpTree;
            int totalFrequentItemSets = GenerateFrequentItemSets();
            watch.Stop();
            return totalFrequentItemSets;
        }
    }
}
