using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLyTiemTapHoa.MenuChucNang
{
    public partial class TonKho : Form
    {
        #region Global Varibles
        SqlConnection cnn = classConnect.connect;
        SqlCommand command = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        DataTable table1 = new DataTable();

        public TonKho()
        {
            InitializeComponent();
        }
        #endregion
        #region Methods
        void LoadData()
        {
            command = cnn.CreateCommand();
            command.CommandText = "select MaSP[Mã sản phẩm],TenSP[Tên sản phẩm],SoLuong[Số lượng],TenDV[Đơn vị],GiaNhap[Giá nhập],GiaBan[Giá bán],TenNCC[Nhà cung cấp] from TonKho t,DonViSP d,NhaCungCap n where t.MaDV=d.MaDV and t.MaNCC=n.MaNCC";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dtgvTonKho.DataSource = table;
        }
        void AddCmbDonVi()
        {
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            string sql = "select TenDV from DonViSP";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmbDonVi.DisplayMember = "TenDV";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cmbDonVi.DataSource = dt;
        }
        void AddCmbNcc()
        {
            if(cnn.State == ConnectionState.Closed)
                cnn.Open();
            string sql = "select TenNCC from NhaCungCap";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmbNCC.DisplayMember = "TenNCC";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cmbNCC.DataSource = dt;
        }
        void Add()
        {
            string ma = txtMaSP.Text;
            string tensp = txtTenSp.Text;
            string sl = txtSL.Text;
            string gn = txtGiaNhap.Text;
            string gb =txtGiaBan.Text;
            int dv = cmbDonVi.SelectedIndex + 1;
            int ncc = cmbNCC.SelectedIndex + 1;
            command = cnn.CreateCommand();
            command.CommandText = "Insert into TonKho values('" + ma + "',N'" + tensp + "','" + sl + "','" + dv + "','" + gn + "','" + gb + "','" + ncc + "')";
            command.ExecuteNonQuery();
            LoadData();
        }
        void Delete()
        {
            command = cnn.CreateCommand();
            command.CommandText = "delete from TonKho where MaSP = '" + txtMaSP.Text + "'";
            command.ExecuteNonQuery();
            LoadData();
        }
        void Update()
        {

            string ma = txtMaSP.Text;
            string tensp = txtTenSp.Text;
            string sl = txtSL.Text;
            decimal gn = decimal.Parse(txtGiaNhap.Text);
            decimal gb = decimal.Parse(txtGiaBan.Text);
            int dv = cmbDonVi.SelectedIndex + 1;
            int ncc = cmbNCC.SelectedIndex + 1;
            command = cnn.CreateCommand();
            command.CommandText = "update TonKho set TenSP = N'" + tensp + "',SoLuong = '" + sl + "',MaDV = '" + dv + "',GiaNhap = '" + gn + "',GiaBan = '" + gb + "',MaNCC = '" + ncc + "' where MaSP = '" + ma + "'";
            command.ExecuteNonQuery();
            LoadData();
        }
        public void searchData(string searchVal)
        {
            SqlCommand command = new SqlCommand();
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table1 = new DataTable();
            command = cnn.CreateCommand();
            if (cmbDanhMuc.SelectedIndex == 0)
            {
                command.CommandText = "Select MaSP[Mã sản phẩm],TenSP[Tên sản phẩm],SoLuong[Số lượng],TenDV[Đơn vị],GiaNhap[Giá nhập],GiaBan[Giá bán],TenNCC[Nhà cung cấp] from TonKho T,NhaCungCap N,DonViSP D WHERE T.MaDV=D.MaDV and T.MaNCC=N.MaNCC and MaSP like '%" + searchVal + "%'";
            }
            else if (cmbDanhMuc.SelectedIndex == 1)
            {
                command.CommandText = "Select MaSP[Mã sản phẩm],TenSP[Tên sản phẩm],SoLuong[Số lượng],TenDV[Đơn vị],GiaNhap[Giá nhập],GiaBan[Giá bán],TenNCC[Nhà cung cấp] from TonKho T,NhaCungCap N,DonViSP D  WHERE T.MaDV=D.MaDV and T.MaNCC=N.MaNCC and TenSP like N'%" + searchVal + "%'";
            }
            else if (cmbDanhMuc.SelectedIndex == 2)
            {
                command.CommandText = "Select MaSP[Mã sản phẩm],TenSP[Tên sản phẩm],SoLuong[Số lượng],TenDV[Đơn vị],GiaNhap[Giá nhập],GiaBan[Giá bán],TenNCC[Nhà cung cấp] from TonKho T,NhaCungCap N,DonViSP D WHERE T.MaDV=D.MaDV and T.MaNCC=N.MaNCC and SoLuong like '%" + searchVal + "%'";
            }
            else if (cmbDanhMuc.SelectedIndex == 3)
            {
                command.CommandText = "Select MaSP[Mã sản phẩm],TenSP[Tên sản phẩm],SoLuong[Số lượng],TenDV[Đơn vị],GiaNhap[Giá nhập],GiaBan[Giá bán],TenNCC[Nhà cung cấp] from TonKho T,NhaCungCap N,DonViSP D WHERE T.MaDV=D.MaDV and T.MaNCC=N.MaNCC and TenDV like N'%" + searchVal + "%'";
            }
            else
            {
                command.CommandText = "Select MaSP[Mã sản phẩm],TenSP[Tên sản phẩm],SoLuong[Số lượng],TenDV[Đơn vị],GiaNhap[Giá nhập],GiaBan[Giá bán],TenNCC[Nhà cung cấp] from TonKho T,NhaCungCap N,DonViSP D WHERE T.MaDV=D.MaDV and T.MaNCC=N.MaNCC and TenNCC like N'%" + searchVal + "%'";

            }
            adapter.SelectCommand = command;
            table1.Clear();
            adapter.Fill(table1);
            dtgvTonKho.DataSource = table1;
        }
        #endregion
        #region Events

        private void TonKho_Load_1(object sender, EventArgs e)
        {
            LoadData();
            AddCmbDonVi();
            AddCmbNcc();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            Add();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            Update();
        }

        private void btnDel_Click_1(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            
        }

        private void dtgvTonKho_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dtgvTonKho.CurrentRow.Index;
            txtMaSP.Text = dtgvTonKho.Rows[i].Cells[0].Value.ToString();
            txtTenSp.Text = dtgvTonKho.Rows[i].Cells[1].Value.ToString();
            txtSL.Text = dtgvTonKho.Rows[i].Cells[2].Value.ToString();
            cmbDonVi.Text = dtgvTonKho.Rows[i].Cells[3].Value.ToString();
            txtGiaNhap.Text = dtgvTonKho.Rows[i].Cells[4].Value.ToString();
            txtGiaBan.Text = dtgvTonKho.Rows[i].Cells[5].Value.ToString();
            cmbNCC.Text = dtgvTonKho.Rows[i].Cells[6].Value.ToString();
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
            frmMenu frmMenu = new frmMenu();
            frmMenu.Show();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchData(txtSearch.Text);
        }
        #endregion
    }
}
