using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemTapHoa
{
    internal class ChucNang
    {
        public static SqlConnection cnn =classConnect.connect;
        public static void connect()
        {
            cnn = new SqlConnection(@"Data Source=DESKTOP-O2TB88K\SQLEXPRESS;Initial Catalog=QLCuaHangTapHoa;Integrated Security=True");
            //connect = new SqlConnection(@"Data Source=LAPTOP-FAMD6FDU\PHAMHAO;Initial Catalog=QLCuaHangTapHoa;Integrated Security=True");

            cnn.Open();
        }
        
        //SqlCommand command = new SqlCommand();
        //string str = @"Data Source=DESKTOP-O2TB88K\SQLEXPRESS;Initial Catalog=QLCuaHangTapHoa;Integrated Security=True";
        //SqlDataAdapter adapter = new SqlDataAdapter();
        //DataTable table = new DataTable();
        //SqlDataReader reader;
        public static bool CheckKey(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql,cnn);
            DataTable table = new DataTable();
            dap.Fill(table);
            if(table.Rows.Count > 0)
                  return true;
            else return false;
        }
    }
}
