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
        public void GenerateFrequentItemSets()
        {
            List<Item> frequentItems = fpTree.FrequentItems;
            foreach (Item anItem in frequentItems)
            {
                ItemSet anItemSet = new ItemSet();
                anItemSet.AddItem(anItem);
                Mine(fpTree, anItemSet);
            }
        }

        private void Mine(FPTree fpTree, ItemSet anItemSet)
        {
            FPTree projectedTree = fpTree.Project(anItemSet);
            resultItemSet.Add(anItemSet);
            foreach (Item anItem in projectedTree.FrequentItems)
            {
                ItemSet nextItemSet = anItemSet.Clone();
                nextItemSet.AddItem(anItem);
                Mine(projectedTree, nextItemSet); 
            }
        }
        public List<ItemSet> CreateFPTreeAndGenerateFrequentItemsets(string[][] sortData, List<Item> items, int numTransact, int minSup)
        {
            FPTree _fpTree = new FPTree(sortData, items, numTransact, minSup);
            fpTree = _fpTree;
            GenerateFrequentItemSets();
            return resultItemSet;
        }
    }
}
