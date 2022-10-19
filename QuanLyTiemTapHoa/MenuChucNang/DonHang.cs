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
    public partial class DonHang : Form
    {
        SqlConnection cnn = classConnect.connect;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public DonHang()
        {
            InitializeComponent();
        }
        void loadData()
        {
            command = cnn.CreateCommand();
            command.CommandText = "select MaHD[Mã hóa đơn],MaSP[Mã sản phẩm],TenSP[Tên sản phẩm],SoLuong[Số lượng],TenDV[Đơn vị],DonGia[Đơn giá],GiamGia[Giảm giá],ThanhTien[Thành tiền] from CTHD c,DonViSP d where c.MaDV=d.MaDV";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvDonHang.DataSource = table;
        }

        private void DonHang_Load(object sender, EventArgs e)
        {
            cnn.Open();
            loadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmMenu frmMenu = new frmMenu();
            this.Hide();
            frmMenu.ShowDialog();
        }
    }
}
