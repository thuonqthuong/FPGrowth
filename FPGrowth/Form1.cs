using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
        DataTable tbl;
        public static string[] cot;
        string[][] Values;
        string[][] sortValues;
        public string[][] sortData;//Dữ liệu sắp xếp cuối cùng
        public int minSupResult;
        public int minConf;
        public int num_transac;
        public static Form1 instance;
        List<ItemSet> resultsOfItemsets = new List<ItemSet>();
        public List<List<string>> findLaws;
        List<ResultSet> displayResults; 
        List<Item> sort;
        Form2 form = new Form2();
        TimeSpan processTime;
        public Form1()
        {
            InitializeComponent();
            instance = this;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterDataSet.databases' table. You can move, or remove it, as needed.
            this.databasesTableAdapter.Fill(this.masterDataSet.databases);
            comboBox1.Text = "Chọn CSDL";
            button1.Enabled = thucthithuattoan.Enabled = false; 
        }
        List<Item> CalculateFrequency(string[][] Values, string[] distinct_item)
        {
            List<Item> items = new List<Item>();
            string[] tempItems = distinct_item;
            int[] numItems = new int[tempItems.Length];
            int index = 0;
            while (index < tempItems.Length)//--------UPDATE--------
            {
                for (int i = 0; i < Values.Length; ++i)//dòng
                {
                    for (int j = 0; j < Values[i].Length; ++j)//cột
                    {
                        if (Values[i][j] != null && Values[i][j].Equals(tempItems[index]))
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
            resultsOfItemsets.Clear(); time.Text = time1.Text = "";
            thucthithuattoan.Enabled = true;
            button1.Enabled = false;
            textBox1.Text = textBox2.Text = results.Text = aprioriResults.Text = law.Text = cachtinh.Text = "";
            //LẤY DỮ LIỆU BẢNG DỮ LIỆU GIAO TÁC
            SYS_DB = comboBox1.GetItemText(comboBox1.SelectedItem);
            if (SYS_DB != null)
                textBox1.Enabled = textBox2.Enabled = true;
            String dulieubang = "USE " + SYS_DB + " EXEC SP_GIAOTAC";
            string constring = "Data Source=INTERN-TTHUONGT;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=123";
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            SqlCommand cmd = new SqlCommand(dulieubang, con);
            SqlDataReader r = cmd.ExecuteReader();
            tbl = new DataTable();
            tbl.Load(r);

            //LẤY DỮ LIỆU GIAO TÁC NHỮNG SẢN PHẨM XUẤT HIỆN TRONG HÓA ĐƠN
            int number_cols = tbl.Columns.Count;
            int number_rows = tbl.Rows.Count;
            numTrans.Text = number_rows + "";
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
                int index = 0;
                string[] d = new string[number_cols];
                for (int j = 1; j < number_cols; j++)
                {
                    if (Convert.ToDouble(tbl.Rows[i].ItemArray[j]) == 1)
                    {
                        d[index++] = cot[j];
                    }
                }
                Values[i] = d;
            }

            var fqcTable = new DataTable();
            fqcTable.Clear();
            fqcTable.Columns.Add("Item ID");
            fqcTable.Columns.Add("Frequency Count");
            this.frequency.DataSource = fqcTable;
            List<Item> headerTable = CalculateFrequency(Values, cot);
            headerTable.RemoveAt(0); //du cot MAHD tu bien cot
            //SẮP XẾP DỮ LIỆU HEADER TABLE THEO ĐỘ PHỔ BIẾN 
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
            //Định nghĩa bảng để hiển thị bảng giao tác
            var dt = new DataTable();
            sortValues = new string[number_rows][];
            dt.Clear();
            dt.Columns.Add("TID");
            dt.Columns.Add("Items");
            this.data.DataSource = dt;
            for (int i = 0; i < Values.Length; ++i)//dòng
            {
                DataRow row = dt.NewRow();
                row["TID"] = tbl.Rows[i].ItemArray[0];//Dependent
                int j = 0; int k = 0; int l = 0;
                string[] temp = new string[Values[i].Length];
                while (k < headerTable.Count)//cột
                {
                    if (headerTable[k].GetItemName().Equals(Values[i][j]))
                    {
                        temp[++l] = Values[i][j];
                        k++; j = 0;
                    }
                    else if (j == Values[i].Length - 1)
                    {
                        j = 0;
                        k++;
                    }
                    else
                        j++;
                }
                temp = temp.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                sortValues[i] = temp;
            }
            for (int i = 0; i < sortValues.Length; ++i)//dòng
            {
                DataRow row = dt.NewRow();
                row["TID"] = tbl.Rows[i].ItemArray[0];//Dependent
                string display = "";
                for (int j = 0; j < sortValues[i].Length; ++j)//cột
                {
                    display += sortValues[i][j] + ", ";
                }
                display = display.Remove(display.Length - 2, 2);
                row["Items"] = display;
                dt.Rows.Add(row);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = false; time.Text = time1.Text = "";
            //int minSup = int.Parse(textBox1.Text);//https://www.youtube.com/watch?v=k3M8yT6FB7w
            cachtinh.Text = law.Text = results.Text = ""; aprioriResults.Text = "";
            double minSup;
            bool res = double.TryParse(textBox1.Text, out minSup);//https://social.msdn.microsoft.com/Forums/sqlserver/en-US/92d5e038-82a2-43c7-a029-bc65aff90cc5/c-textbox-text-to-integer?forum=winforms
            if (minSup < 0 || minSup > 100 || res == false)
                textBox1.Text = "";
            else
            {
                double min = Math.Ceiling((double)minSup / 100 * num_transac);
                minSupResult = Convert.ToInt32(min);
                t.Text = "Ta có: " + minSup + " / 100 * " + num_transac + " = " + min + "\r\n => Tần suất xuất hiện T thỏa T>=" + minSupResult;
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
                sort = new List<Item>();
                foreach (Item i in headerTable)
                {
                    Item tam = new Item();
                    if (i.GetCount() >= minSupResult)
                    {
                        DataRow row = fqcTable.NewRow();
                        row["Item ID"] = i.GetItemName();
                        row["Frequency Count"] = i.GetCount();
                        tam.SetItemName(i.GetItemName());
                        tam.SetCount(i.GetCount());
                        fqcTable.Rows.Add(row);
                        sort.Add(tam);
                    }
                }
                // SẮP XẾP DỮ LIỆU THEO BẢNG HEADER TABLE
                var dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("TID");
                dt.Columns.Add("Items Sort");
                this.data.DataSource = dt;
                sortData = new string[sortValues.Length][];

                for (int i = 0; i < sortValues.Length; ++i)//dòng
                {
                    string[] display = new string[sortValues[i].Length]; int k = 0;
                    for (; k < sort.Count; k++)//cột
                    {
                        for (int j = 0; j < sortValues[i].Length; ++j)
                        {
                            if (sort[k].GetItemName().Equals(sortValues[i][j]))
                            {
                                display[j] = sortValues[i][j];
                                break;
                            }
                            else if (k == sort.Count)
                            {
                                display = null;
                                break;
                            }
                            continue;
                        }
                    }
                    display = display.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                    sortData[i] = display;
                }
                for (int i = 0; i < sortData.Length; ++i)//dòng
                {
                    DataRow row = dt.NewRow();
                    row["TID"] = tbl.Rows[i].ItemArray[0];//Dependent
                    string display = "";
                    if (sortData[i].Length == 0)
                    {//Nếu muốn thêm dòng dữ liệu trống thì để 2 dòng code này lại
                     //row["Items Sort"] = "";
                     //dt.Rows.Add(row);
                        continue;
                    }
                    for (int j = 0; j < sortData[i].Length; ++j)//cột
                    {
                        display += sortData[i][j] + ", ";
                    }
                    display = display.Remove(display.Length - 2, 2);
                    row["Items Sort"] = display;
                    dt.Rows.Add(row);
                }
            }
        }

        private void thucthithuattoan_Click(object sender, EventArgs e)
        {
            time.Text = "";
            if (textBox1.Text == "")
                MessageBox.Show("Vui lòng nhập giá trị cho ô minSup");
            double minSup;
            bool res = double.TryParse(textBox1.Text, out minSup);//https://social.msdn.microsoft.com/Forums/sqlserver/en-US/92d5e038-82a2-43c7-a029-bc65aff90cc5/c-textbox-text-to-integer?forum=winforms
            if (minSup < 0 || minSup > 100 || res == false)
                textBox1.Text = "";
            else
            {
                button1.Enabled = true;
                law.Text = cachtinh.Text = "";
                FPGrowthAlgorithm fpGrowth = new FPGrowthAlgorithm();
                Stopwatch sw = Stopwatch.StartNew();
                resultsOfItemsets = fpGrowth.CreateFPTreeAndGenerateFrequentItemsets(sortData, sort, minSupResult);
                sw.Stop();
                time.Text = sw.Elapsed.TotalSeconds/*.TotalMilliseconds*/ + "";
                string t = "";
                for(int i = 1; i < resultsOfItemsets.Count; i++)
                {
                    foreach (ItemSet j in resultsOfItemsets)
                        if (i == j.Items.Count)
                            t += "    " + j.GetInfoString() + "\r\n";
                }
                results.Text = t;
            }
        }
        private void thucthiapriori_Click(object sender, EventArgs e)
        {
            time1.Text = "";
            if (textBox1.Text == "")
                MessageBox.Show("Vui lòng nhập giá trị cho ô minSup");
            double minSup;
            bool res = double.TryParse(textBox1.Text, out minSup);//https://social.msdn.microsoft.com/Forums/sqlserver/en-US/92d5e038-82a2-43c7-a029-bc65aff90cc5/c-textbox-text-to-integer?forum=winforms
            if (minSup < 0 || minSup > 100 || res == false)
                textBox1.Text = "";
            else
            {
                button1.Enabled = true;
                law.Text = cachtinh.Text = "";
                AprioriAlgorithm apriori = new AprioriAlgorithm();
                Stopwatch sw = Stopwatch.StartNew();
                resultsOfItemsets = apriori.GenerateFrequentItemsets(sortData, sort, minSupResult);
                sw.Stop();
                time1.Text = sw.Elapsed.TotalSeconds /*.TotalMilliseconds*/ + "";
                string t = "";
                foreach (ItemSet i in resultsOfItemsets)
                    t += "    " + i.GetInfoString() + "\r\n";
                aprioriResults.Text = t;
            }
        }
        static List<List<T>> GetSubsets<T>(IEnumerable<T> Set)
        {
            var set = Set.ToList<T>();
            // Init list
            List<List<T>> subsets = new List<List<T>>();
            for (int i = 1; i < set.Count; i++)
            {
                subsets.Add(new List<T>() { set[i - 1] });
                List<List<T>> newSubsets = new List<List<T>>();
                // Loop over existing subsets
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
            // Add in the last element
            subsets.Add(new List<T>() { set[set.Count - 1] });
            foreach (List<T> l in subsets)
            {
                if (l.Count == set.Count)
                {
                    subsets.Remove(l);
                    break;
                }
            }
            return subsets;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                MessageBox.Show("Vui lòng nhập giá trị cho ô minConf");
            double minConf;
            bool res = double.TryParse(textBox2.Text, out minConf);//https://social.msdn.microsoft.com/Forums/sqlserver/en-US/92d5e038-82a2-43c7-a029-bc65aff90cc5/c-textbox-text-to-integer?forum=winforms
            if (minConf < 0 || minConf > 100 || res == false)
                textBox2.Text = "";
            else if (resultsOfItemsets.Count > 0)
            {
                string tinh = "";
                string laws = "";
                displayResults = new List<ResultSet>();
                for (int i = 0; i < resultsOfItemsets.Count; i++)
                {
                    if (resultsOfItemsets[i].Items.Count > 1)
                    {
                        List<string> info = new List<string>();
                        foreach (Item anItem in resultsOfItemsets[i].Items)
                            info.Add(anItem.GetItemName().ToString());
                        var test = GetSubsets<string>(info);//Generate
                        for (int j = 0; j < test.Count; j++)
                        {
                            int firstElement = 0;
                            int secondElement = 0;
                            int fpCountOfList = 0;
                            for (int k = 0; k < test.Count; k++)
                            {
                                if (test[j].Intersect(test[k]).Any())//bo qua nhung cai giong no, Giao nhau bang rong
                                    continue;
                                else
                                {
                                    List<string> frstList = new List<string>();
                                    List<string> scndList = new List<string>();
                                    List<string> twList = new List<string>();
                                    List<string> allList = new List<string>(); ;
                                    foreach (string o in test[j])
                                    {
                                        frstList.Add(o);
                                        twList.Add(o);
                                    }
                                    foreach (string o in test[k])
                                    {
                                        scndList.Add(o);
                                        twList.Add(o);
                                    }
                                    for (int it2 = 0; it2 < resultsOfItemsets.Count; it2++)
                                    {
                                        int fpCount1 = resultsOfItemsets[it2].SupportCount;
                                        int fpCount2 = resultsOfItemsets[it2].SupportCount;
                                        allList = new List<string>();
                                        foreach (Item item in resultsOfItemsets[it2].Items)
                                        {
                                            allList.Add(item.GetItemName());
                                        }
                                        bool isEqualFrstList = Enumerable.SequenceEqual(frstList.OrderBy(fe => fe), allList.OrderBy(fe => fe));
                                        if (isEqualFrstList) { firstElement = fpCount1; }
                                        bool isEqualScndtList = Enumerable.SequenceEqual(scndList.OrderBy(fe => fe), allList.OrderBy(fe => fe));
                                        if (isEqualScndtList) { secondElement = fpCount1; }
                                        bool isEqualList = Enumerable.SequenceEqual(twList.OrderBy(fe => fe), allList.OrderBy(fe => fe));
                                        if (isEqualList) { fpCountOfList = fpCount2; }
                                    }
                                    string r = "";
                                    foreach (string o in frstList)
                                        r += o;
                                    string l = "";
                                    foreach (string o in scndList)
                                        l += o;
                                    ResultSet temp = new ResultSet();
                                    temp.LeftList = scndList;
                                    temp.RightList = frstList;
                                    temp.LeftCount = fpCountOfList;
                                    temp.RightCount = firstElement;
                                    displayResults.Add(temp);
                                }
                            }
                        }
                    }
                }
                int i1 = 0;
                bool isEqualFList = true;
                bool isEqualSList = true; int soluat = 0;
                for (int i = 0; i < displayResults.Count; i++)
                {
                    bool flag = true;
                    for (int j = i + 1; j < displayResults.Count; j++)
                    {
                        isEqualFList = Enumerable.SequenceEqual(displayResults[i].LeftList.OrderBy(fe => fe), displayResults[j].LeftList.OrderBy(fe => fe));
                        isEqualSList = Enumerable.SequenceEqual(displayResults[i].RightList.OrderBy(fe => fe), displayResults[j].RightList.OrderBy(fe => fe));
                        if (isEqualFList & isEqualSList)
                            flag = false;
                    }
                    if (!(isEqualFList & isEqualSList) & flag == true)
                    {
                        if (minConf / 100 <= (displayResults[i].LeftCount * 1.0 / displayResults[i].RightCount))
                            soluat++;
                        tinh += displayResults[i].GetInfoString(++i1);
                        laws += displayResults[i].GetInfoStringLaws(minConf);
                    }
                }
                string header2 = "                " + soluat + " Luật được sinh ra thỏa Conf(X->Y) >= minConf \r\n                Giá trị của thông số minConf = minConf/100 = " + minConf / 100 + "\r\n\r\n";

                cachtinh.Text = tinh;
                law.Text = header2 + laws;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            double minConf;
            bool res = double.TryParse(textBox2.Text, out minConf);//https://social.msdn.microsoft.com/Forums/sqlserver/en-US/92d5e038-82a2-43c7-a029-bc65aff90cc5/c-textbox-text-to-integer?forum=winforms
            if (minConf < 0 || minConf > 100 || res == false)
                textBox2.Text = "";
            else if (resultsOfItemsets.Count > 0)
            {
                string tinh = "";
                string laws = "";
                displayResults = new List<ResultSet>();
                for (int i = 0; i < resultsOfItemsets.Count; i++)//Xét trong tất cả các tập mục thường xuyên đã tìm được
                {
                    if (resultsOfItemsets[i].Items.Count > 1)//Chỉ generate các Itemset có số lượng item >1
                    {
                        List<string> info = new List<string>();// Lấy các item và count của Itemset đang xét
                        foreach (Item anItem in resultsOfItemsets[i].Items)//Convert Items 1 itemset về dạng List<string>
                        {
                            info.Add(anItem.GetItemName().ToString());
                        }
                        var test = GetSubsets<string>(info);//Generate ra các tập con trừ tập rỗng và tập đầy đủ
                        for (int j = 0; j < test.Count; j++)
                        {
                            int firstElement = 0;
                            int secondElement = 0;
                            int fpCountOfList = 0;
                            for (int k = 0; k < test.Count; k++)
                            {
                                if (test[j].Intersect(test[k]).Any())//bo qua nhung cai giong no
                                    continue;
                                else
                                {
                                    List<string> frstList = new List<string>();
                                    List<string> scndList = new List<string>();
                                    List<string> twList = new List<string>();
                                    List<string> allList = new List<string>();
                                    foreach (string o in test[j])
                                    {
                                        frstList.Add(o);
                                        twList.Add(o);
                                    }
                                    foreach (string o in test[k])
                                    {
                                        scndList.Add(o);
                                        twList.Add(o);
                                    }
                                    for (int it2 = 0; it2 < resultsOfItemsets.Count; it2++)
                                    {
                                        int fpCount1 = resultsOfItemsets[it2].SupportCount;
                                        int fpCount2 = resultsOfItemsets[it2].SupportCount;
                                        allList = new List<string>();
                                        foreach (Item item in resultsOfItemsets[it2].Items)
                                        {
                                            allList.Add(item.GetItemName());
                                        }
                                        bool isEqualFrstList = Enumerable.SequenceEqual(frstList.OrderBy(fe => fe), allList.OrderBy(fe => fe));
                                        if (isEqualFrstList) { firstElement = fpCount1; }
                                        bool isEqualScndtList = Enumerable.SequenceEqual(scndList.OrderBy(fe => fe), allList.OrderBy(fe => fe));
                                        if (isEqualScndtList) { secondElement = fpCount1; }
                                        bool isEqualList = Enumerable.SequenceEqual(twList.OrderBy(fe => fe), allList.OrderBy(fe => fe));
                                        if (isEqualList) { fpCountOfList = fpCount2; }
                                    }
                                    string r = "";
                                    foreach (string o in frstList)
                                        r += o;
                                    string l = "";
                                    foreach (string o in scndList)
                                        l += o;
                                    ResultSet temp = new ResultSet();
                                    temp.LeftList = scndList;
                                    temp.RightList = frstList;
                                    temp.LeftCount = fpCountOfList;
                                    temp.RightCount = firstElement;
                                    displayResults.Add(temp);
                                }
                            }
                        }
                    }
                }
                int i1 = 0;
                bool isEqualFList = true;
                bool isEqualSList = true; int soluat = 0;
                for (int i = 0; i < displayResults.Count; i++)
                {
                    bool flag = true;
                    for (int j = i + 1; j < displayResults.Count; j++)
                    {
                        isEqualFList = Enumerable.SequenceEqual(displayResults[i].LeftList.OrderBy(fe => fe), displayResults[j].LeftList.OrderBy(fe => fe));
                        isEqualSList = Enumerable.SequenceEqual(displayResults[i].RightList.OrderBy(fe => fe), displayResults[j].RightList.OrderBy(fe => fe));
                        if (isEqualFList & isEqualSList)
                            flag = false;
                    }
                    if (!(isEqualFList & isEqualSList) & flag == true)
                    {
                        if (minConf / 100 <= (displayResults[i].LeftCount * 1.0 / displayResults[i].RightCount))
                            soluat++;
                        tinh += displayResults[i].GetInfoString(++i1);
                        laws += displayResults[i].GetInfoStringLaws(minConf);
                    }
                }
                string header2 = "                " + soluat + " Luật được sinh ra thỏa Conf(X->Y) >= minConf \r\n                Giá trị của thông số minConf = minConf/100 = " + minConf / 100 + "\r\n\r\n";

                cachtinh.Text = tinh;
                law.Text = header2 + laws;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
        
    }
}
