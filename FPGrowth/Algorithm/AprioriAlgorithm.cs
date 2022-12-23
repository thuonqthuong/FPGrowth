using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPGrowth.Algorithm
{
    class AprioriAlgorithm
    {
        List<ItemSet> resultItemSet = new List<ItemSet>();
        static List<List<T>> GetSubsets<T>(IEnumerable<T> Set, int count)
        {
            var set = Set.ToList<T>();
            List<List<T>> subsets = new List<List<T>>();
            for (int i = 1; i < set.Count; i++)
            {
                subsets.Add(new List<T>() { set[i - 1] });
                List<List<T>> newSubsets = new List<List<T>>();
                for (int j = 0; j < subsets.Count; j++)
                {
                    var newSubset = new List<T>();
                    foreach (var temp in subsets[j])
                        newSubset.Add(temp);
                    newSubset.Add(set[i]);
                    newSubsets.Add(newSubset);
                }
                subsets.AddRange(newSubsets);
            }
            subsets.Add(new List<T>() { set[set.Count - 1] });
            List<List<T>> childSubsets = new List<List<T>>();
            foreach (List<T> l in subsets)
            {
                if (l.Count == count)
                {
                    childSubsets.Add(l);
                }
            }
            return childSubsets;
        }

        public List<ItemSet> GenerateFrequentItemsets(string[][] sortData, List<Item> items, int minSupCount)
        {
            foreach (Item i in items)
            {
                ItemSet temp = new ItemSet();
                temp.SupportCount = i.GetCount();
                List<Item> it = new List<Item>();
                it.Add(i);
                temp.Items = it;
                resultItemSet.Add(temp);
            }
            for (int i = 2; i < items.Count + 1; i++)
            {
                List<string> info = new List<string>();
                foreach (Item anItem in items)
                    info.Add(anItem.GetItemName().ToString());
                var test = GetSubsets<string>(info, i);
                for (int j = 0; j < test.Count; j++)// Xét các Tuple
                {
                    int count = 0;
                    for (int m = 0; m < sortData.Length; ++m)//Xét từng phần tử trong test có xuất hiện trong sort data
                    {
                        List<string> rowList = new List<string>();
                        for (int n = 0; n < sortData[m].Length; ++n)//cột
                        {
                            rowList.Add(sortData[m][n]);
                        }
                        bool allInList2 = !test[j].Except(rowList).Any();
                        if (allInList2) { count++; }
                    }
                    if (count >= minSupCount)
                    {
                        ItemSet temp = new ItemSet();
                        List<Item> it = new List<Item>();
                        foreach (string o in test[j])
                        {
                            Item t = new Item();
                            t.SetItemName(o);
                            it.Add(t);
                        }
                        temp.Items = it;
                        temp.SupportCount = count;
                        resultItemSet.Add(temp);
                    }
                }
            }
            return resultItemSet;
        }
    }
}
