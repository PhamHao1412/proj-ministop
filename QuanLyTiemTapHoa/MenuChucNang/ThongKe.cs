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

    public partial class ThongKe : Form
    {

        SqlConnection cnn = classConnect.connect;
        SqlCommand command = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public ThongKe()
        {
            InitializeComponent();
        }
        private void btnThongKeDT_Click(object sender, EventArgs e)
        {
            MenuChucNang.ThongKeDoanhThu tkdt = new MenuChucNang.ThongKeDoanhThu();
            this.Hide();
            tkdt.Show();
        }
        private void btnThongKeHD_Click(object sender, EventArgs e)
        {
            MenuChucNang.ThongKeHoaDon tkhd = new MenuChucNang.ThongKeHoaDon();
            this.Hide();
            tkhd.Show();
        }
        private void btnTKSN_Click(object sender, EventArgs e)
        {
            MenuChucNang.ThongKeSanPham tksp = new MenuChucNang.ThongKeSanPham();
            this.Hide();
            tksp.Show();
        }
        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            frmMenu frmMenu = new frmMenu();
            this.Hide();
            frmMenu.ShowDialog();
        }
    }
}
