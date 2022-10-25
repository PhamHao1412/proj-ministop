using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTiemTapHoa.MenuChucNang
{
    public partial class ThongKeHoaDon : Form
    {
        SqlConnection cnn = classConnect.connect;
        SqlCommand command = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public ThongKeHoaDon()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            command = cnn.CreateCommand();
            command.CommandText = "select MaHD,count(MaHD) [Tổng số hóa đơn],NgayLap,MaNV from HoaDon group by MaHD,NgayLap,MaNV";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dtgvTKHD.DataSource = table;

        }
        private void dtpThoiGian_ValueChanged(object sender, EventArgs e)
        {
            string time = dtpThoiGian.Value.ToString("yyyy-MM-dd");
            command = cnn.CreateCommand();
            command.CommandText = "select  MaHD,count(MaHD) [Tổng số hóa đơn],NgayLap,MaNV from HoaDon where NgayLap = '" + time + "' group by MaHD,NgayLap,MaNV";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dtgvTKHD.DataSource = table;
        }
        private void ThongKeHoaDon_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            MenuChucNang.ThongKe tk = new MenuChucNang.ThongKe();
            this.Hide();
            tk.Show();
        }  
    }
}
