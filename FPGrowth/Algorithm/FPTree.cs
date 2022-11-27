using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        tempRoot.AddChild(aNode);
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

        public FPTree Project(Item anItem)
        {
            FPTree tree = new FPTree();
            //tree.minimumSupport = minimumSupport;
            tree.minimumSupportCount = minimumSupportCount;
            Node startNode = headerTable[anItem.GetItemName()];
            //Console.Write("startNode: " + startNode.Name + " - " + startNode.FPCount+"\r\n");
            //startNode.Children.Count + " - " + startNode.Parent+"\r\n");
            /*Console.WriteLine("Items List");
            foreach (KeyValuePair<string, Node> author in headerTable)
            {
                Console.WriteLine("1Name: {0}, 1Count: {1}, 1NumChild: {2}", author.Value.Name, author.Value.FPCount, author.Value.Children.Count);
                foreach (Node child in author.Value.Children)
                {
                    Console.WriteLine("2Child name: {0}, 2Child Count: {1}, 2NumChild: {2}",
                        child.Name, child.FPCount, child.Children.Count);
                    foreach (Node c in child.Children)
                    {
                        Console.WriteLine("3Child name: {0}, 3Child Count: {1}",
                           c.Name, c.FPCount);
                    }
                }
                Console.WriteLine("\r\n");
            }*/
            while (startNode != null)
            {
                int projectedFPCount = startNode.FPCount; 
                //Console.Write("\r\n\r\nprojectedFPCount: " + startNode.Name +" - " + projectedFPCount + "\r\n");
                Node tempNode = startNode;
                List<Node> aBranch = new List<Node>();
                while (null != tempNode.Parent)
                {
                    Node parentNode = tempNode.Parent;//parentNode giữ cả node cha
                    if (parentNode.IsNull())
                    {
                        break;
                    }
                    Node newNode = new Node(parentNode.Name);//newNode chỉ giữ tên node cha và count = 1
                    newNode.FPCount = projectedFPCount;
                    aBranch.Add(newNode);
                    tempNode = tempNode.Parent;
                    //Console.Write("Parent not null\r\nparentNode: " + parentNode.Name+" "+parentNode.FPCount);
                    //Console.Write("newNode: " + parentNode.Name + " " + parentNode.FPCount);
                    //Console.Write("A Branch Before Reverse\r\n");
                    /*foreach (Node i in aBranch)
                    {
                        Console.Write(i.Name + " " + i.FPCount+"\r\n");
                    }*/
                }
                aBranch.Reverse();
                /*Console.Write("\r\nA Branch\r\n");
                foreach (Node i in aBranch)
                {
                    Console.Write(i.Name + " " + i.FPCount + "\r\n");
                }*/
                tree.InsertBranch(aBranch);
                startNode = startNode.NextHeader;
            }
            IDictionary<string, Node> inFrequentHeaderTable = tree.headerTable.
                Where(x => tree.GetTotalSupportCount(x.Value.Name) < minimumSupportCount).
                ToDictionary(p => p.Key, p => p.Value);
            //Console.Write(inFrequentHeaderTable.Values.Count+ "\r\n");
            //Console.Write(" \r\n-----------FHT-------------");
            /*foreach (KeyValuePair<string, Node> author in inFrequentHeaderTable)
            {
                Console.WriteLine("Key: {0}, Name: {1}, Parent: {2}, Children: {3}",
                    author.Key, author.Value.Name, author.Value.Parent.Name, author.Value.Children.Count );
            }*/
            tree.headerTable = tree.headerTable.
                Where(x => tree.GetTotalSupportCount(x.Value.Name) >= minimumSupportCount).
                ToDictionary(p => p.Key, p => p.Value);

            //Console.Write(" \r\n------------headerTable------------");
            /*foreach (KeyValuePair<string, Node> author in tree.headerTable)
            {
                Console.WriteLine("Key: {0}, Name: {1}, Parent: {2}, Children: {3}",
                    author.Key, author.Value.Name, author.Value.Parent.Name, author.Value.Children.Count);
            }*/
            foreach (KeyValuePair<string, Node> hEntry in inFrequentHeaderTable)
            {
                Node temp = hEntry.Value;
                while (null != temp)
                {
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
            return tree;
        }
    }
}
