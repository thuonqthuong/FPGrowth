using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace FPGrowth
{
    static class Program
    {
        public static System.Data.SqlClient.SqlDataReader reader;
        public static SqlConnection connection = new SqlConnection();
        public static String servername = "INTERN-TTHUONGT"; // luu ten server tra vè ở form dang nhap
        public static String username = "sa";
        public static String password = "123";
        public static SqlDataReader myReader;
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        public static SqlDataReader ExecSqlDataReader(String strLenh)
        {
            SqlDataReader myreader;
            SqlCommand sqlcmd = new SqlCommand(strLenh, Program.connection);
            sqlcmd.CommandType = CommandType.Text;
            //tối đa cho đợi 10p, tgian tính bằng s
            sqlcmd.CommandTimeout = 600;
            // Kiểm tra trạng thái đóng hay mở
            if (Program.connection.State == ConnectionState.Closed) Program.connection.Open();
            try
            {
                myreader = sqlcmd.ExecuteReader();
                return myreader;
            }
            catch (SqlException ex)
            {
                Program.connection.Close();
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public static int KetNoi(String database)
        {
            if (Program.connection != null && Program.connection.State == ConnectionState.Open)
                Program.connection.Close();
            try
            {
                String cntstr = "Data Source=" + Program.servername + ";Initial Catalog=" +
                      database + ";User ID=" +
                      Program.username + ";password=" + Program.password;
                Program.connection.ConnectionString = cntstr;
                Program.connection.Open();
                return 1;
            }

            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại user name và password.\n " + e.Message, "Kết nối", MessageBoxButtons.OK);
                return 0;
            }
        }
    }
}
