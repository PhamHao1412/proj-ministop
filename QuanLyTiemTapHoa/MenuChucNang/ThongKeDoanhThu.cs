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
    public partial class ThongKeDoanhThu : Form
    {
        SqlConnection cnn = classConnect.connect;
        SqlCommand command = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public ThongKeDoanhThu()
        {
            InitializeComponent();
        }
        void LoadData()
        {
            command = cnn.CreateCommand();
            command.CommandText = "select  NgayLap,ThanhTien from HoaDon D,CTHD C where D.MaHD=C.MaHD";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dtgvTKDT.DataSource = table;
        }
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            decimal sum = 0;
            for (int i = 0; i < dtgvTKDT.Rows.Count; ++i)
            {
                sum += Convert.ToDecimal(dtgvTKDT.Rows[i].Cells[1].Value);
            }
            txTong.Text = sum.ToString();
        }

        private void ThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dtpThoiGian_ValueChanged(object sender, EventArgs e)
        {
            string time = dtpThoiGian.Value.ToString("yyyy-MM-dd");
            command = cnn.CreateCommand();
            command.CommandText = "select  NgayLap,ThanhTien from HoaDon D,CTHD C where D.MaHD=C.MaHD and NgayLap = '" + time + "'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dtgvTKDT.DataSource = table;
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
