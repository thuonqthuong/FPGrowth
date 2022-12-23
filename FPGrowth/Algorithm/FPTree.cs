using System;
using System.Collections.Generic;
using System.Linq;

namespace FPGrowth.Algorithm
{
    class FPTree
    {
        Node root;
        IDictionary<string, Node> headerTable;
        int minimumSupportCount;
        List<Item> frequentItems;
        public List<Item> FrequentItems
        {
            get { return frequentItems; }
            set { frequentItems = value; }
        }
        private FPTree()
        {
            root = new Node("");
            headerTable = new Dictionary<string, Node>();
            frequentItems = new List<Item>();
        }
        public FPTree(string[][] sortData, List<Item> items, int minSup)
            : this()
        {
            minimumSupportCount = minSup;
            CalculateFrequentItems(items);
            frequentItems = frequentItems.OrderByDescending(x => x.GetCount()).ToList();
            List<string> aTransaction;
            int i = 0;
            do
            {
                aTransaction = new List<string>();
                if (sortData[i].Length == 0)
                {
                    i++;
                    continue;
                }
                for (int j = 0; j < sortData[i].Length; ++j)//cột
                    aTransaction.Add(sortData[i][j]);
                if (aTransaction.Count!=0)//if ( item còn lại khác rỗng)  insert_tree(P,N).
                    InsertTree(aTransaction);//3. Quét từng giao tác Trans trong cơ sở dữ liệu, với mỗi giao tác t:
                i++;
            }
            while ( i< sortData.Length);
        }

        private void InsertTree(List<string> aTransaction)
        {
            List<Item> items = frequentItems.FindAll
                (
                    delegate (Item anItem)
                    {
                        return aTransaction.Exists(x => x == anItem.GetItemName());
                    }
                );
            Node tempRoot = root;
            Node tempNode;

            foreach (Item anItem in items)
            {
                if ((tempNode = tempRoot.Children.Find(c => c.Name == anItem.GetItemName())) != null)
                {
                    tempNode.FPCount++;
                    tempRoot = tempNode; 
                }
                else
                { 
                    Node aNode = new Node(anItem.GetItemName());//new Node đã tạo count = 1, item_name = anItem.GetItemName()
                    tempRoot.AddChild(aNode);//liên kết với nút cha là T;
                    tempRoot = aNode;
                    if (headerTable.ContainsKey(aNode.Name))
                    {
                        aNode.NextHeader = headerTable[aNode.Name];
                        headerTable[aNode.Name] = aNode;
                    }
                    else
                    {
                        headerTable[aNode.Name] = aNode;
                    }
                }
            }
        }

        private void CalculateFrequentItems(List<Item> items)
        {
            foreach (Item anItem in items)
            {
                if (anItem.GetCount() >= minimumSupportCount)
                {
                    frequentItems.Add(anItem.Clone());
                }
            }
        }
        private void InsertBranch(List<Node> branch)
        {
            Node tempRoot = root;
            for (int i = 0; i < branch.Count; ++i)
            {
                Node aNode = branch[i];
                Node tempNode = tempRoot.Children.Find(x => x.Name == aNode.Name);
                if (null != tempNode)
                {
                    tempNode.FPCount += aNode.FPCount;
                    tempRoot = tempNode;
                }
                else
                {
                    while (i < branch.Count)
                    {
                        aNode = branch[i];
                        aNode.Parent = tempRoot;
                        //tempRoot.AddChild(aNode);
                        if (headerTable.ContainsKey(aNode.Name))
                        {
                            aNode.NextHeader = headerTable[aNode.Name];
                        }
                        headerTable[aNode.Name] = aNode;
                        tempRoot = aNode;
                        ++i;

                    }
                    break;
                }
            }
        }
        public int GetTotalSupportCount(string itemSymbol)
        {
            int sCount = 0;
            Node node = headerTable[itemSymbol];
            while (null != node)
            {
                sCount += node.FPCount;
                node = node.NextHeader;
            }
            return sCount;
        }

        public FPTree Project(ItemSet anItem)
        {
            FPTree tree = new FPTree();
            tree.minimumSupportCount = minimumSupportCount;
            Node startNode = headerTable[anItem.GetLastItem().GetItemName()];
            while (startNode != null)
            {
                Console.WriteLine("startNode: " + startNode.Name + " " + startNode.FPCount);
                int projectedFPCount = startNode.FPCount;
                Node tempNode = startNode;
                List<Node> aBranch = new List<Node>();
                while (null != tempNode.Parent)
                {
                    Node parentNode = tempNode.Parent;
                    if (parentNode.IsNull()) break;
                    Node newNode = new Node(parentNode.Name);
                    newNode.FPCount = projectedFPCount;
                    aBranch.Add(newNode);
                    tempNode = tempNode.Parent;
                }
                aBranch.Reverse();
                Console.WriteLine("DANG XET: " + startNode.Name);
                foreach (Node i in aBranch)
                {
                    Console.WriteLine(i.Name + " ");
                }
                if (aBranch.Count != 0)
                {
                    tree.InsertBranch(aBranch);
                }
                startNode = startNode.NextHeader;
            }
            IDictionary<string, Node> inFrequentHeaderTable = tree.headerTable.
                Where(x => tree.GetTotalSupportCount(x.Value.Name) < minimumSupportCount).
                ToDictionary(p => p.Key, p => p.Value);
            tree.headerTable = tree.headerTable.
                Where(x => tree.GetTotalSupportCount(x.Value.Name) >= minimumSupportCount).
                ToDictionary(p => p.Key, p => p.Value);
            foreach (KeyValuePair<string, Node> hEntry in inFrequentHeaderTable)
            {
                Node temp = hEntry.Value;
                while (null != temp)
                {
                    Console.WriteLine("inFrequentHeaderTable: " + temp.Name +" "+temp.FPCount);
                    Node tempNext = temp.NextHeader;
                    Node tempParent = temp.Parent;
                    tempParent.Children.Remove(temp); 
                    temp = tempNext;
                }
            }
            tree.frequentItems = frequentItems.FindAll
            (
                delegate (Item item)
                {
                    return tree.headerTable.ContainsKey(item.GetItemName());
                }
            );
            foreach (Item i in tree.frequentItems)
            {
                Console.WriteLine("frequentItems: " + i.GetItemName() + " " + i.GetCount());
                if (tree.headerTable.ContainsKey(i.GetItemName()))
                {
                    i.SetCount(tree.GetTotalSupportCount(i.GetItemName()));
                }
            }
            foreach (Item i in tree.frequentItems)
            {
                Console.WriteLine("    AllfItems: " + i.GetItemName() + " " + i.GetCount());
            }
            return tree;
        }
    }
}
