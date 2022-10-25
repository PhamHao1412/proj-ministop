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
    public partial class ThongKeSanPham : Form
    {
        public ThongKeSanPham()
        {
            InitializeComponent();
        }
        SqlConnection cnn = classConnect.connect;
        SqlCommand command = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        void LoadData()
        {
            command = cnn.CreateCommand();
            command.CommandText = "select T.MaSP [Mã sản phẩm],T.TenSP [Tên sản phẩm],N.SoLuong[Số lượng nhập vào], T.SoLuong[Số lượng tồn],N.SoLuong-T.SoLuong[Số lượng đã bán]  from NhapKho N, TonKho T,CTHD C where N.MaSP=T.MaSP group by T.MaSP,T.TenSP,N.SoLuong, T.SoLuong";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dtgvTKSP.DataSource = table;

        }
        private void ThongKeSanPham_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void txtMaSP_TextChanged(object sender, EventArgs e)
        {
            command = cnn.CreateCommand();
            command.CommandText = "select T.MaSP[Mã sản phẩm],T.TenSP[Tên sản phẩm],N.SoLuong[Số lượng nhập vào], T.SoLuong[Số lượng tồn],N.SoLuong-T.SoLuong[Số lượng đã bán] from NhapKho N, TonKho T,CTHD C where N.MaSP=T.MaSP and T.MaSP like '%" + txtMaSP.Text + "%' group by T.MaSP,T.TenSP,N.SoLuong, T.SoLuong";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dtgvTKSP.DataSource = table;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            MenuChucNang.ThongKe tk = new MenuChucNang.ThongKe();
            this.Hide();
            tk.Show();
        }
    }
}
