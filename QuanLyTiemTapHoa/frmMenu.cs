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

namespace QuanLyTiemTapHoa
{
    public partial class frmMenu : Form
    {
        //hello world
        string str = @"Data Source=DESKTOP-O2TB88K\SQLEXPRESS;Initial Catalog=QLCuaHangTapHoa;Integrated Security=True";

        //SqlConnection cnn = new SqlConnection(@"Data Source=LAPTOP-FAMD6FDU\PHAMHAO;Initial Catalog=QLCuaHangTapHoa;Integrated Security=True");
        SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-O2TB88K\SQLEXPRESS;Initial Catalog=QLCuaHangTapHoa;Integrated Security=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        SqlDataReader reader;

        public static string tennv = "";
        public frmMenu()
        {
            InitializeComponent();
        }
        public void loadData()
        {
            cnn.Open();
            cmd.CommandText = "select MaNV,TenNV from NhanVien ";
            cmd.Connection = cnn;
            reader = cmd.ExecuteReader();
            bool temp = false;
            while (reader.Read())
            {
                lbUser.Text = reader.GetString(1);
                tennv = reader.GetString(1);
                temp = true;
            }
            if (temp == false)
                MessageBox.Show("Không tìm thấy");
            cnn.Close();
        }
        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn đăng xuất không ? ", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                Application.Restart();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            String.Format("");
            timer1.Start();
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            MenuChucNang.NhanVien frnv = new MenuChucNang.NhanVien();
            this.Hide();
            frnv.ShowDialog();
        }

        private void btnBanHang_Click(object sender, EventArgs e)
        {
            MenuChucNang.BanHang frbh = new MenuChucNang.BanHang();
            this.Hide();
            frbh.ShowDialog();
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            MenuChucNang.NhapKho nhapKho = new MenuChucNang.NhapKho();
            this.Hide();
            nhapKho.ShowDialog();
        }

        private void btnTonKho_Click(object sender, EventArgs e)
        {
            MenuChucNang.TonKho frtk = new MenuChucNang.TonKho();
            this.Hide();
            frtk.ShowDialog();
        }

        private void btnDonViSP_Click(object sender, EventArgs e)
        {
            MenuChucNang.DonViSanPham donViSanPham = new MenuChucNang.DonViSanPham();
            this.Hide();
            donViSanPham.ShowDialog();
        }

        private void btnDonHang_Click(object sender, EventArgs e)
        {
            MenuChucNang.DonHang donHang = new MenuChucNang.DonHang();
            this.Hide();
            donHang.ShowDialog();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            MenuChucNang.ThongKe thongke = new MenuChucNang.ThongKe();
            this.Hide();
            thongke.ShowDialog();
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            MenuChucNang.NhaCungCap ncc = new MenuChucNang.NhaCungCap();
            this.Hide();
            ncc.ShowDialog();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
