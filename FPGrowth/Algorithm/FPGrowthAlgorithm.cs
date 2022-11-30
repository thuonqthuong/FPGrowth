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
        public int GenerateFrequentItemSets()
        {
            List<Item> frequentItems = fpTree.FrequentItems;
            int totalFrequentItemSets = frequentItems.Count;
            foreach (Item anItem in frequentItems)
            {
                ItemSet anItemSet = new ItemSet();
                anItemSet.AddItem(anItem);
                int t= Mine(fpTree, anItemSet);
                totalFrequentItemSets += t;
            }
            return totalFrequentItemSets;
        }

        private int Mine(FPTree fpTree, ItemSet anItemSet)
        {
            FPTree projectedTree = fpTree.Project(anItemSet);
            int minedItemSets =  projectedTree.FrequentItems.Count;
            resultItemSet.Add(anItemSet);
            foreach (Item anItem in projectedTree.FrequentItems)
            {
                ItemSet nextItemSet = anItemSet.Clone();
                nextItemSet.AddItem(anItem);
                minedItemSets += Mine(projectedTree, nextItemSet); 
            }
            return minedItemSets;
        }
        public List<ItemSet> CreateFPTreeAndGenerateFrequentItemsets(string[][] sortData, List<Item> items, int numTransact, int minSup)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            FPTree _fpTree = new FPTree(sortData, items, numTransact, minSup);
            fpTree = _fpTree;
            int totalFrequentItemSets = GenerateFrequentItemSets();
            watch.Stop();
            return resultItemSet;
        }
    }
}
