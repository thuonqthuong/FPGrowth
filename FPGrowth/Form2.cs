using FPGrowth.Algorithm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPGrowth
{
    public partial class Form2 : Form
    {
        public string[][] sortData { get; set; }
        public int minSup { get; set; }
        public int numTransact { get; set; }
        List<Item> items { get; set; }
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FPGrowthAlgorithm fpGrowth = new FPGrowthAlgorithm();
            //fpGrowth.CreateFPTreeAndGenerateFrequentItemsets(sortData, items, numTransact, minSup);
            textBox1.Text = "MinSup: "+minSup + "";
            textBox2.Text = "numTransact: " + numTransact + "";
            string d = "";

            /*for(int i=0; i < items.Count; i++)
            {
                d += items[i].GetItemName() + "-" + items[i].GetCount() + ", ";
            }
            textBox3.Text = "items: " + d + "";*/
        }
    }
}
