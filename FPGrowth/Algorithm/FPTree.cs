using System;
using System.Collections.Generic;
using System.Linq;

namespace FPGrowth.Algorithm
{
    class FPTree
    {
        Node root;
        IDictionary<string, Node> headerTable;
        int minimumSupport;
        int minimumSupportCount;
        List<Item> frequentItems;
        int numNode=1;
        public List<Item> FrequentItems
        {
            get { return frequentItems; }
            set { frequentItems = value; }
        }
        private FPTree()
        {
            root = new Node("");
            //2.Tạo gốc của cây FP(kí hiệu T), gán nhãn là null.
            //Tạo bảng Header có |F| dòng và đặt tất cả các node–link chỉ đến null
            headerTable = new Dictionary<string, Node>(numNode);//numNode này chắc chắn có giá trị vì nó chạy 31 trước
            //minimumSupport = 0;
            frequentItems = new List<Item>();
        }
        public FPTree(string[][] sortData, List<Item> items, int numTransact, int minSup)
            : this()
        {
            minimumSupportCount = minSup;
            CalculateFrequentItems(items);
            frequentItems = frequentItems.OrderByDescending(x => x.GetCount()).ToList();
            numNode = frequentItems.Count;
            //1. Duyệt D lần đầu để  thu được tập F gồm các frequent item và support của chúng.
            //Sắp xếp các item trong F theo trật tự giảm dần của support  ta được danh sách FList bởi InsertTransaction(aTransaction);
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
                {
                    aTransaction.Add(sortData[i][j]);
                }
                if (aTransaction.Count!=0)//if ( item còn lại khác rỗng)  insert_tree(P,N).
                    InsertTree(aTransaction);//3. Quét từng giao tác Trans trong cơ sở dữ liệu, với mỗi giao tác t:
                i++;
            }
            while ( i< sortData.Length);
            /*Console.WriteLine("Items List");
            foreach (KeyValuePair<string, Node> author in headerTable)
            {
                Console.WriteLine("Key: {0}, Name: {1}, Count: {2}, NumChild: {3}",
                    author.Key, author.Value.Name, author.Value.FPCount, author.Value.Children.Count);
                foreach(Node child in author.Value.Children)
                {
                    Console.WriteLine("Child's child: {0}, Child name: {1}, Child Count: {2}",
                        child.Children.Count, child.Name, author.Value.FPCount);
                }
            }*/
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
            //Console.Write("InsertTransaction_root: " + root.Symbol+"-"+root.FpCount+" - parent: "+root.Parent + "\r\n");

            foreach (Item anItem in items)
            {
                //Console.Write("InsertTransaction_anItem: " + anItem.Symbol+" supp: "+ anItem.SupportCount + "\r\n");
                //Node aNode = new Node(anItem.GetItemName());
                //aNode.FPCount = 1;
                if ((tempNode = tempRoot.Children.Find(c => c.Name == anItem.GetItemName())) != null)
                {
                    /*If (T có một nút con N với N.item-name=p.item-name) Then
	                    N.count++;*/
                    tempNode.FPCount++;
                    tempRoot = tempNode; 
                    //Console.Write("Old Node: " + anItem.GetItemName()+".."+tempNode.Name + "-" + tempNode.FPCount + "\r\n");
                }
                else
                { 
                    Node aNode = new Node(anItem.GetItemName());//new Node đã tạo count = 1, item_name = anItem.GetItemName()
                    tempRoot.AddChild(aNode);//liên kết với nút cha là T;
                    tempRoot = aNode;
                    //Console.Write("New Node: " + aNode.Name + "-" + aNode.FPCount + "\r\n");
                    if (headerTable.ContainsKey(aNode.Name))
                    {
                        aNode.NextHeader = headerTable[aNode.Name];
                        headerTable[aNode.Name] = aNode;
                    }
                    else
                    {
                        headerTable[aNode.Name] = aNode;
                    }
                    //Console.Write("InsertTransac_HTable: " + headerTable[aNode.Name].Name + "-" + headerTable[aNode.Name].FPCount + "\r\n");
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
            //Console.WriteLine("        Branch root: " + tempRoot.Name + " " + tempRoot.FPCount);
            //Console.WriteLine("        Branch.Count: " + branch.Count); 
            for (int i = 0; i < branch.Count; ++i)
            {
                Node aNode = branch[i];
                //Console.WriteLine("        branch["+i+"]: " + aNode.Name + "-" + aNode.FPCount);
                Node tempNode = tempRoot.Children.Find(x => x.Name == aNode.Name);
                if (null != tempNode)
                {
                    //Console.WriteLine("        Trong tempNode chua children"+ aNode.Name);
                    tempNode.FPCount += aNode.FPCount;
                    tempRoot = tempNode;
                }
                else
                {
                    //Console.WriteLine("        Trong tempNode khong chua children");
                    while (i < branch.Count)
                    {
                        aNode = branch[i];// Console.WriteLine("        So nhanh: "+ branch.Count+" - i:"+i);
                        //Console.WriteLine("        branchcount[" + i + "]: " + aNode.Name + "-" + aNode.FPCount);
                        aNode.Parent = tempRoot;
                        tempRoot.AddChild(aNode);//du thua
                        if (headerTable.ContainsKey(aNode.Name))
                        {
                            aNode.NextHeader = headerTable[aNode.Name];
                        }
                        headerTable[aNode.Name] = aNode;
                        //Console.WriteLine("        header Table moi: " + headerTable[aNode.Name].Name+" "+ headerTable[aNode.Name].FPCount);
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
            /*Console.WriteLine("\r\n        HEADER TABLE IN GET TOTAL");
            foreach (KeyValuePair<string, Node> author in headerTable)
            {
                Console.WriteLine("        1Name: {0}, 1Count: {1}, 1NumChild: {2}", author.Value.Name, author.Value.FPCount, author.Value.Children.Count);
                foreach (Node child in author.Value.Children)
                {
                    Console.WriteLine("        2Child name: {0}, 2Child Count: {1}, 2NumChild: {2}",
                        child.Name, child.FPCount, child.Children.Count);
                    foreach (Node c in child.Children)
                    {
                        Console.WriteLine("    3Child name: {0}, 3Child Count: {1}",
                           c.Name, c.FPCount);
                    }
                }
            }*/
            while (null != node)
            {
                sCount += node.FPCount;
                node = node.NextHeader;
            }
            //Console.Write("        GetTotalSupportCount(" + itemSymbol + ") = " + sCount);
            return sCount;
        }

        public FPTree Project(ItemSet anItem)
        {
            FPTree tree = new FPTree();
            //tree.minimumSupport = minimumSupport;
            tree.minimumSupportCount = minimumSupportCount;
            //Console.Write("    "+ headerTable.Count + "\r\n");
            Node startNode = headerTable[anItem.GetLastItem().GetItemName()];
            //Console.Write("startNode: " + startNode.Name + " - " + startNode.FPCount+"\r\n");
            //startNode.Children.Count + " - " + startNode.Parent+"\r\n");
            /*Console.WriteLine("    HEADER TABLE");
            foreach (KeyValuePair<string, Node> author in headerTable)
            {
                Console.WriteLine("    1Name: {0}, 1Count: {1}, 1NumChild: {2}", author.Value.Name, author.Value.FPCount, author.Value.Children.Count);
                foreach (Node child in author.Value.Children)
                {
                    Console.WriteLine("    2Child name: {0}, 2Child Count: {1}, 2NumChild: {2}",
                        child.Name, child.FPCount, child.Children.Count);
                    foreach (Node c in child.Children)
                    {
                        Console.WriteLine("    3Child name: {0}, 3Child Count: {1}",
                           c.Name, c.FPCount);
                    }
                }
                Console.WriteLine("\r\n");
            }*/
            /*anItem.SupportCount = anItem.GetLastItem().GetCount(); 
            Console.Write("Before: " + anItem.GetLastItem().GetCount());*/
            while (startNode != null)
            {
                int projectedFPCount = startNode.FPCount;
                //Console.Write("    projectedFPCount: " + startNode.Name +" - " + projectedFPCount + "\r\n");
                Node tempNode = startNode;
                List<Node> aBranch = new List<Node>();
                while (null != tempNode.Parent)
                {
                    Node parentNode = tempNode.Parent;
                    if (parentNode.IsNull()) break;
                    Node newNode = new Node(parentNode.Name);//newNode chỉ giữ tên node cha và count = 1
                    newNode.FPCount = projectedFPCount;
                    aBranch.Add(newNode);
                    tempNode = tempNode.Parent;
                    /*Console.WriteLine("    parentNode: " + parentNode.Name + " " + parentNode.FPCount+"\r\n");
                    Console.Write("    newNode: " + newNode.Name + " " + newNode.FPCount + "\r\n");
                    Console.Write("    A Branch Before Reverse\r\n");
                    foreach (Node i in aBranch)
                    {
                        Console.Write("    "+i.Name + " " + i.FPCount+", ");
                    }*/
                }
                aBranch.Reverse();
                /*Console.Write("\r\n     A Branch After Reverse\r\n");
                foreach (Node i in aBranch)
                {
                    Console.Write("    "+i.Name + "-" + i.FPCount + ", ");
                }*/
                if (aBranch.Count != 0)
                {
                    tree.InsertBranch(aBranch);//Kiểm tra Branch, branch khác rỗng mới insert
                }
                startNode = startNode.NextHeader;
            }
            IDictionary<string, Node> inFrequentHeaderTable = tree.headerTable.
                Where(x => tree.GetTotalSupportCount(x.Value.Name) < minimumSupportCount).
                ToDictionary(p => p.Key, p => p.Value);
            //Console.Write(inFrequentHeaderTable.Values.Count+ "\r\n");
            //Console.Write(" \r\n-----------FHT-------------");
            /*foreach (KeyValuePair<string, Node> author in inFrequentHeaderTable)
            {
                Console.WriteLine("    1. Name: {0}, Count: {1}, Parent: {2}, Children: {3}",
                    author.Value.Name, author.Value.FPCount, author.Value.Parent.Name, author.Value.Children.Count );
            }*/
            tree.headerTable = tree.headerTable.
                Where(x => tree.GetTotalSupportCount(x.Value.Name) >= minimumSupportCount).
                ToDictionary(p => p.Key, p => p.Value);
            Console.WriteLine();
            //Console.Write(" \r\n------------headerTable------------");
            /*if(tree.headerTable.Count > 0)
            {
                int min = tree.GetTotalSupportCount(tree.headerTable.First().Value.Name);
                Console.WriteLine("Min khoi tao: " + min);
                foreach (KeyValuePair<string, Node> author in tree.headerTable)
                {
                    if (min > tree.GetTotalSupportCount(author.Value.Name))
                    {
                        min = tree.GetTotalSupportCount(author.Value.Name);
                    }
                    *//*Console.WriteLine("\r\n    2. Name: {0}, Count: {1}, Parent: {2}, Children: {3}",
                        author.Value.Name, author.Value.FPCount, author.Value.Parent.Name, author.Value.Children.Count);*//*
                    //Console.WriteLine(author.Value.Name + " - " + tree.GetTotalSupportCount(author.Value.Name));
                }
                if (min >= minimumSupportCount)
                {
                    anItem.SupportCount = min;
                }
                Console.WriteLine("KQ Min: " + min);
            }*/
            foreach (KeyValuePair<string, Node> hEntry in inFrequentHeaderTable)
            {
                Node temp = hEntry.Value;
                //Console.Write(temp.Name+" "+temp.FPCount + "\r\n");
                while (null != temp)
                {
                    Node tempNext = temp.NextHeader;
                    Node tempParent = temp.Parent;
                    tempParent.Children.Remove(temp); 
                    //Console.Write("    tempParent: "+tempParent.Name + " " + tempParent.FPCount + "\r\n");
                    //Console.Write("    Remove: " + temp.Name + " " + temp.FPCount + "\r\n");
                    temp = tempNext;
                }
            }
            //frequentItems của tree thay đổi ở đây nè!
            //tree.frequentItems chỉ còn giữ lại những item mà trong header table có tồn tại
            //Gỉa sử với milk-3, header table chứ bread-2, thì trong frequentitem chỉ chứa bread-3
            tree.frequentItems = frequentItems.FindAll
            (
                delegate (Item item)
                {
                    return tree.headerTable.ContainsKey(item.GetItemName());
                }
            );
            foreach (Item i in tree.frequentItems)
            {
                if (tree.headerTable.ContainsKey(i.GetItemName()))
                {
                    i.SetCount(tree.GetTotalSupportCount(i.GetItemName()));
                }
            }
            
            /*string s = "ITEMSET: ";
            foreach (Item i in anItem.Items)
            {
                s +=i.GetItemName() +" - "+ i.GetCount()+"  ";
            }Console.WriteLine(s);*/
            /*foreach (KeyValuePair<string, Node> author in tree.headerTable)
            {
                Console.WriteLine("\r\n    3. Name: {0}, Count: {1}, Parent: {2}, Children: {3}",
                    author.Value.Name, author.Value.FPCount, author.Value.Parent.Name, author.Value.Children.Count);
            }
            Console.Write("    Du lieu tree.frequentItems: ");
            foreach (Item i in tree.frequentItems)
            {
                Console.Write(i.GetItemName() + " " + i.GetCount() + ", ");
            }
            Console.Write("    \r\n");*/
            //Console.WriteLine(anItem.GetLastItem().GetItemName() + " " + anItem.GetLastItem().GetCount());
            return tree;
        }
    }
}
