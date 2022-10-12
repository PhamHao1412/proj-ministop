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
            
        }
    }
}
