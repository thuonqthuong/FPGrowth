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
                Console.WriteLine("\r\nFrequent Item: " + anItemSet.GetInfoString());
                Mine(fpTree, anItemSet);
            }
        }

        private void Mine(FPTree fpTree, ItemSet anItemSet)
        {
            FPTree projectedTree = fpTree.Project(anItemSet);
            resultItemSet.Add(anItemSet);

            Console.WriteLine("KQ: " + anItemSet.GetInfoString());
            foreach (Item anItem in projectedTree.FrequentItems)
            {
                ItemSet nextItemSet = anItemSet.Clone();
                nextItemSet.AddItem(anItem);
                Mine(projectedTree, nextItemSet); 
            }
        }
        public List<ItemSet> CreateFPTreeAndGenerateFrequentItemsets(string[][] sortData, List<Item> items, int minSup)
        {
            FPTree _fpTree = new FPTree(sortData, items, minSup);
            fpTree = _fpTree;
            GenerateFrequentItemSets();
            return resultItemSet;
        }
    }
}
