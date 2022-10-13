using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FPGrowth.Algorithm;

namespace FPGrowth
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        string SYS_DB;
        string[] cot;
        string[][] Values;
        static int num_transac;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterDataSet.databases' table. You can move, or remove it, as needed.
            this.databasesTableAdapter.Fill(this.masterDataSet.databases);
            comboBox1.Text = "Chọn CSDL";

        }
        List<Item> CalculateFrequency(string[][] Values, string[] distinct_item)
        {
            List<Item> items = new List<Item>();
            string[] tempItems = distinct_item;
            int[] numItems = new int[tempItems.Length];
            int index = 0;
            while(index<tempItems.Length)//--------UPDATE--------
            {
                for (int i = 0; i < Values.Length; ++i)//dòng
                {
                    for (int j = 0; j < Values[i].Length; ++j)//cột
                    {
                        if (Values[i][j]!=null && Values[i][j].Equals(tempItems[index]))
                        {
                            numItems[index]++;
                        }
                    }
                }
                Item anItem = new Item(tempItems[index], numItems[index]);
                items.Add(anItem);
                index++;
            }
            return items;
        }
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //LẤY DỮ LIỆU BẢNG DỮ LIỆU GIAO TÁC
            SYS_DB = comboBox1.GetItemText(comboBox1.SelectedItem);
            String dulieubang = "USE " + SYS_DB + " EXEC SP_GIAOTAC";
            if (Program.KetNoi(SYS_DB) == 0) return;
            Program.myReader = Program.ExecSqlDataReader(dulieubang);
            var datatable = new DataTable();
            datatable.Load(Program.myReader);
            string constring = "Data Source=DESKTOP-UPGKA2J;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=123";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand(dulieubang, con);
            SqlDataReader r = cmd.ExecuteReader();
            DataTable tbl = new DataTable();
            tbl.Load(r);
            
            //LẤY DỮ LIỆU GIAO TÁC NHỮNG SẢN PHẨM XUẤT HIỆN TRONG HÓA ĐƠN
            int number_cols = tbl.Columns.Count;
            int number_rows = tbl.Rows.Count;
            num_transac = number_rows;
            Values = new string[number_rows][];
            cot = new string[tbl.Columns.Count];
            //Lấy distinct tên các sản phẩm đã được mua -------string[] cot-------
            for (int i = 0; i < number_cols; i++)//cot
            {
                cot[i] = tbl.Columns[i].ColumnName;
            }
            
            //Lấy giá trị có nghĩa ở từng dòng giao tác (lấy tên cột khi giá trị dòng i cột đó = 1)-------string[][] Values-------
            for (int i = 0; i < number_rows; i++)
            {
                int index=0;
                string[] d = new string[number_cols];
                for (int j = 1; j < number_cols; j++)
                {
                    if (Convert.ToDouble(tbl.Rows[i].ItemArray[j])==1)
                    {
                        d[index++] = cot[j];
                    }
                }
                Values[i] = d;
            }

            //Định nghĩa bảng để hiển thị bảng giao tác
            var dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("TID");
            dt.Columns.Add("Items");
            
            this.data.DataSource = dt;
            for (int i = 0; i < Values.Length; ++i)//dòng
            {
                DataRow row = dt.NewRow();
                row["TID"] = tbl.Rows[i].ItemArray[0];//Dependent
                string display = "";
                for (int j = 0; j < Values[i].Length; ++j)//cột
                {
                    if (Values[i][j] != null)
                        display += Values[i][j] + ", ";
                }
                display = display.Remove(display.Length - 2, 2);
                row["Items"] = display;
                dt.Rows.Add(row);
            }
            //LẤY DỮ LIỆU CHO BẢNG HEADER TABLE
            var fqcTable = new DataTable();
            fqcTable.Clear();
            fqcTable.Columns.Add("Item ID");
            fqcTable.Columns.Add("Frequency Count");
            this.frequency.DataSource = fqcTable;
            List<Item> headerTable = CalculateFrequency(Values, cot);
            headerTable.RemoveAt(0);
            headerTable.Sort(//https://stackoverflow.com/questions/3309188/how-to-sort-a-listt-by-a-property-in-the-object
            delegate (Item p1, Item p2)//Không cần sort thêm điều kiện thứ 2 vì mã sản phẩm đã được sort trong csdl
                {
                    return p2.GetCount().CompareTo(p1.GetCount());
                }
            );
            foreach (Item i in headerTable)
            {
                DataRow row = fqcTable.NewRow();
                row["Item ID"] = i.GetItemName();
                row["Frequency Count"] = i.GetCount();
                fqcTable.Rows.Add(row);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            double minSup;
            //int minSup = int.Parse(textBox1.Text);//https://www.youtube.com/watch?v=k3M8yT6FB7w
            bool res = double.TryParse(textBox1.Text, out minSup);//https://social.msdn.microsoft.com/Forums/sqlserver/en-US/92d5e038-82a2-43c7-a029-bc65aff90cc5/c-textbox-text-to-integer?forum=winforms
            double min = Math.Ceiling(minSup / 100 * num_transac);
            int minSupResult = Convert.ToInt32(min);
            //LẤY DỮ LIỆU CHO BẢNG HEADER TABLE
            var fqcTable = new DataTable();
            fqcTable.Clear();
            fqcTable.Columns.Add("Item ID");
            fqcTable.Columns.Add("Frequency Count");
            this.frequency.DataSource = fqcTable;
            List<Item> headerTable = CalculateFrequency(Values, cot);
            headerTable.RemoveAt(0);
            headerTable.Sort(//https://stackoverflow.com/questions/3309188/how-to-sort-a-listt-by-a-property-in-the-object
            delegate (Item p1, Item p2)//Không cần sort thêm điều kiện thứ 2 vì mã sản phẩm đã được sort trong csdl
            {
                return p2.GetCount().CompareTo(p1.GetCount());
            }
            );
            foreach (Item i in headerTable)
            {
                if(i.GetCount() >= minSupResult)
                {
                    DataRow row = fqcTable.NewRow();
                    row["Item ID"] = i.GetItemName();
                    row["Frequency Count"] = i.GetCount();
                    fqcTable.Rows.Add(row);
                }    
            }
        }

        private void hienthicay_Click(object sender, EventArgs e)
        {

        }
    }
}
