using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemTapHoa
{
    internal class classConnect
    {
 
        public static string sql = @"Data Source=LAPTOP-FAMD6FDU\PHAMHAO;Initial Catalog=QLCuaHangTapHoa;Integrated Security=True";
        //public static string sql = @"Data Source=DERKAISER\SQLEXPRESS;Initial Catalog=QLCuaHangTapHoa;Integrated Security=True";
        public static SqlConnection connect = new SqlConnection(sql);
    }
}
