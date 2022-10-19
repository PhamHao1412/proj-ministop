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
    public partial class ThanhToan : Form
    {
        public static decimal thanhtoan = 0;
        public static decimal khachdua = 0;
        public static decimal tienthoilai = 0;
        public ThanhToan()
        {
            InitializeComponent();
        }
        private void ThanhToan_Load(object sender, EventArgs e)
        {
            txtThanhToan.Text = Convert.ToString(thanhtoan);   
        }

        private void btnTienThoi_Click(object sender, EventArgs e)
        {
            khachdua = Convert.ToDecimal(txtKhachDua.Text);
            tienthoilai = khachdua - thanhtoan;
            txtTienTL.Text = tienthoilai.ToString();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            MenuChucNang.Bill bill = new MenuChucNang.Bill();
            this.Hide();
            bill.ShowDialog();

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn quay trở về không ?", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                MenuChucNang.BanHang banHang = new MenuChucNang.BanHang();
                this.Hide();
                banHang.ShowDialog();
            }
        }
    }
}
