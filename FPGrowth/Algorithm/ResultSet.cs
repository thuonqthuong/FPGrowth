using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FPGrowth.Algorithm
{
    class ResultSet
    {
        private List<string> leftList;
        private int leftCount;
        private List<string> rightList;
        private int rightCount;
        public ResultSet()
        {
            leftList = new List<string>();
            leftCount = 0;
            rightList = new List<string>();
            rightCount = 0;
        }
        public int LeftCount
        {
            get { return leftCount; }
            set { leftCount = value; }
        }
        public List<string> LeftList
        {
            get { return leftList; }
            set { leftList = value; }
        }
        public int RightCount
        {
            get { return rightCount; }
            set { rightCount = value; }
        }
        public List<string> RightList
        {
            get { return rightList; }
            set { rightList = value; }
        }
        public string GetInfoString(int index)
        {
            string info = "";
            string left = "";
            foreach (string o in leftList)
                left += o;
            string right = "";
            foreach (string o in rightList)
                right += o;
            info += "   " + index + ". conf(" + right + "->" + left + ") = supp(" + left + right + ") / supp(" + right + ") = " + leftCount + "/" + rightCount + " = " + leftCount * 1.0 / rightCount/*Math.Round(leftCount * 1.0 / rightCount, 2)*/ + "\r\n";
            return info;
        }
        public string GetInfoStringLaws(double minConf)
        {
            string info = "";
            string left = "";
            foreach (string o in leftList)
                left += o;
            string right = "";
            foreach (string o in rightList)
                right += o;
            if (minConf / 100 <= (leftCount * 1.0 / rightCount))
                info += "                             "  + "conf(" + right + "->" + left + ") = " + leftCount * 1.0 / rightCount + "\r\n";
            return info;
        }
    }
}
