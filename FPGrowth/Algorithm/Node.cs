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
        Node node_link;
        Node parent_link;

        public Node(string item_name, int count, Node node_link, Node parent_link)
        {
            this.item_name = item_name;
            this.count = count;
            this.node_link = node_link;
            this.parent_link = parent_link;
        }
    }

}
