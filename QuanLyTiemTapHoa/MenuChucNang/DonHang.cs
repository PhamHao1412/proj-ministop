using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyTiemTapHoa.MenuChucNang
{
    public partial class DonHang : Form
    {
        #region Globas Varibles
        SqlConnection cnn = classConnect.connect;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public DonHang()
        {
            InitializeComponent();
        }
        #endregion
        #region Methods
        void loadData()
        {
            command = cnn.CreateCommand();
            command.CommandText = "select MaHD[Mã hóa đơn],MaSP[Mã sản phẩm],TenSP[Tên sản phẩm],SoLuong[Số lượng],TenDV[Đơn vị],DonGia[Đơn giá],GiamGia[Giảm giá],ThanhTien[Thành tiền] from CTHD c,DonViSP d where c.MaDV=d.MaDV";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvDonHang.DataSource = table;
            cmbMaHD.SelectedIndex = 0;
        }
        DataTable TruyVan(String s)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter(s, cnn);
                da.Fill(ds, "KQ");
                cnn.Close();
                return ds.Tables["KQ"];
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi truy vấn CSDL. ");
                return new DataTable();
            }
        }
        void addMaHD()
        {
            string sql = "select MaHD from HoaDon";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmbMaHD.DisplayMember = "MaHD";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt = TruyVan(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbMaHD.Items.Add(dt.Rows[i][0].ToString());
            }
        }
        private void DonHang_Load(object sender, EventArgs e)
        {
            cnn.Open();
            loadData();
            addMaHD();
            cnn.Close();
        }
        void searchData()
        {
            if(cmbMaHD.SelectedIndex == 0)
            {
                loadData();
            }
            else
            {
                SqlCommand comand = new SqlCommand();
                SqlDataAdapter adapter = new SqlDataAdapter();
                DataTable table1 = new DataTable();
                comand = cnn.CreateCommand();
                comand.CommandText = "select MaHD[Mã hóa đơn],MaSP[Mã sản phẩm],TenSP[Tên sản phẩm],SoLuong[Số lượng],TenDV[Đơn vị],DonGia[Đơn giá],GiamGia[Giảm giá],ThanhTien[Thành tiền] from CTHD c,DonViSP d where c.MaDV=d.MaDV and MaHD = '" + cmbMaHD.SelectedItem + "' ";
                adapter.SelectCommand = comand;
                table1.Clear();
                adapter.Fill(table1);
                dgvDonHang.DataSource = table1;
            }
        }
        #endregion
        #region Events
        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmMenu frmMenu = new frmMenu();
            this.Hide();
            frmMenu.ShowDialog();
        }
        private void cmbMaHD_SelectedIndexChanged(object sender, EventArgs e)
        {
            searchData();
        }

        private void cmbMaHD_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dgvDonHang_ReadOnlyChanged(object sender, EventArgs e)
        {
            Enabled = true;
        }

    }
    #endregion
}
