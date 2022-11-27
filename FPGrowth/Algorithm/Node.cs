using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPGrowth.Algorithm
{
    class Node
    {
        string item_name;
        int count;
        Node nextHeader;
        Node parent;

        public Node NextHeader
        {
            get { return nextHeader; }
            set { nextHeader = value; }
        }
        List<Node> children;
        public List<Node> Children
        {
            get { return children; }
            set { children = value; }
        }
        private Node()
        {
            count = 0;
            nextHeader = null;
            children = new List<Node>();
            parent = null;
        }
        //ADD
        public Node(string _item_name)
            : this()
        {
            item_name = _item_name;
            if (item_name.Length != 0)
                count = 1;
        }
        public int FPCount
        {
            get { return count; }
            set { count = value; }
        }
        public string Name
        {
            get { return item_name; }
        }
        public bool IsNull()
        {
            return item_name.Length == 0;
        }
        public void AddChild(Node child)
        {
            child.parent = this;
            children.Add(child);
        }
        public Node Parent
        {
            get { return parent; }
            set { parent = value; }
        }
    }

}
