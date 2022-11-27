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
        List<ItemSet> resultItemSet = new List<ItemSet>();
        public FPGrowthAlgorithm()
        {
            fpTree = null;
        }
        public FPGrowthAlgorithm(FPTree tree)
            : this()
        {
            fpTree = tree;
        }
        public int GenerateFrequentItemSets(double minconf)
        {
            List<Item> frequentItems = fpTree.FrequentItems;//FrequentItems giống Header Table
            int totalFrequentItemSets = frequentItems.Count;//Số các sản phẩm riêng biệt thỏa MinSupport
            //Console.WriteLine("Itemsets");
            foreach (Item anItem in frequentItems)//DUYET THEO CHIEU NAO?
            {
                ItemSet anItemSet = new ItemSet();
                anItemSet.AddItem(anItem);
                //Console.WriteLine(anItem.GetItemName()+"-"+anItem.GetCount());

                //Console.WriteLine("       B AN ITEMSET:" + anItemSet.GetInfoString());
                int t= Mine(fpTree, anItemSet);
                totalFrequentItemSets += t;
                //Console.WriteLine("HAVE: "+fpTree.FrequentItems.Count);
                //Console.WriteLine("       A AN ITEMSET:" + anItemSet.GetInfoString());
            }
            
            //Console.WriteLine("GenerateFrequentItemSets_totalFrequentItemSets: "+totalFrequentItemSets);
            return totalFrequentItemSets;
        }

        private int Mine(FPTree fpTree, ItemSet anItemSet)
        {
            //Console.WriteLine("Ngoai--------------------------------------------------------------");
            //Console.WriteLine("MAYBE HAVE: " + fpTree.FrequentItems.Count);
            //Console.Write("\r\n\r\nLAST ITEMSETS: " + anItemSet.GetLastItem().GetItemName() + " " + anItemSet.GetLastItem().GetCount() + "\r\n");
            //anItemSet.SupportCount = anItemSet.GetLastItem().GetCount();
            //Console.Write("  00. Mine_anItemSet: " + anItemSet.GetInfoString() + "-" + anItemSet.SupportCount + "\r\n");
            //"-"+ anItemSet.GetLastItem().GetCount()+"\r\n");
            FPTree projectedTree = fpTree.Project(anItemSet);
            //Console.WriteLine("Count of last item: " + anItemSet.GetLastItem().GetCount());
            int minedItemSets =  projectedTree.FrequentItems.Count;
            //Console.Write("    projectedTree.FrequentItems.Count: " + minedItemSets + "\r\n");
            //Console.Write("  0. Mine_anItemSet: " + anItemSet.GetInfoString() + "-"+ anItemSet.SupportCount + "\r\n");
            //Console.Write("\r\n  " + anItemSet.GetInfoString() + "\r\n");
            resultItemSet.Add(anItemSet);
            //Console.Write("\r\n2. SupportCount: " + anItemSet.SupportCount + "\r\n");
            //Console.Write("2. Last Item: " + anItemSet.GetLastItem().GetItemName() + "\r\n");
            foreach (Item anItem in projectedTree.FrequentItems)
            {
                //anItemSet.SupportCount = anItem.GetCount();
                //Console.Write("\r\nMINE FUNCTION");
                //Console.Write("FPCount: "+ anItem.GetCount());
                ItemSet nextItemSet = anItemSet.Clone();
                //Console.WriteLine("\r\n  1. nextItemSet: " + nextItemSet.GetInfoString() + "-" + nextItemSet.SupportCount);
                nextItemSet.AddItem(anItem);
                //Console.Write("   AddItem: " + anItem.GetItemName() + "-" + anItem.GetCount() + "\r\n");
                //Console.Write("  2. AddItem: " + anItem.GetItemName() +"-"+anItem.GetCount()+ "\r\n");
                //Console.Write("  3. Next Item: " + nextItemSet.GetInfoString() + "-"+ nextItemSet.SupportCount+"\r\n");
                
                /*Console.Write("    Du lieu projectedTree.frequentItems: ");
                foreach (Item i in projectedTree.FrequentItems)
                {
                    Console.Write(i.GetItemName() + " " + i.GetCount() + ", ");
                }
                Console.Write("    \r\n");
                Console.WriteLine("Trong--------------------------------------------------------------");*/
                minedItemSets += Mine(projectedTree, nextItemSet); 
                /*if (flag == 1)
                {
                    Console.Write("\r\n2. nextItemSet: " + nextItemSet.SupportCount);
                    Console.Write("\r\n3. anItem: " + anItem.GetCount());
                }*/
            }
            //Console.Write("\r\n  RESULTS: " + anItemSet.GetInfoString() + "\r\n");
            return minedItemSets;
        }
        public List<ItemSet> CreateFPTreeAndGenerateFrequentItemsets(string[][] sortData, List<Item> items, int numTransact, int minSup, double minconf)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            FPTree _fpTree = new FPTree(sortData, items, numTransact, minSup);
            //Console.Write("CreateFPTreeAndGenerateFrequentItemsets\r\n");
            fpTree = _fpTree;
            int totalFrequentItemSets = GenerateFrequentItemSets(minconf);
            watch.Stop();
            return resultItemSet;
        }
    }
}
