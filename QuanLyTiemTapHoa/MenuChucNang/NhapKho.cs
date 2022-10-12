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
using System.Xml.Linq;

namespace QuanLyTiemTapHoa.MenuChucNang
{
    public partial class NhapKho : Form
    {
        #region Global Varibles

        SqlConnection cnn = KetNoiCoSoDuLieu.cnn;
        SqlCommand command = new SqlCommand();
        //string str = @"Data Source=LAPTOP-FAMD6FDU\PHAMHAO;Initial Catalog=QLCuaHangTapHoa;Integrated Security=True";
        string str = @"Data Source=DESKTOP-O2TB88K\SQLEXPRESS;Initial Catalog=QLCuaHangTapHoa;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        SqlDataReader reader;
        public static string manv = "";
        public static string tennv = "";
        public NhapKho()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        void loadData()
        {
            command.CommandText = "select MaNV,TenNV from NhanVien";
            command.Connection = cnn;
            reader = command.ExecuteReader();
            bool temp = false;
            while (reader.Read())
            {
                txtMaNV.Text = reader.GetString(0);
                manv = reader.GetString(0);
                txtTenNV.Text = reader.GetString(1);
                tennv = reader.GetString(1);
                temp = true;
            }
            if (temp == false)
                MessageBox.Show("Không tìm thấy");
            cnn.Close();
            command = cnn.CreateCommand();
            command.CommandText = "select MaSP,TenSP,SoLuong,TenDV,GiaNhap,GiaBan,MaNV,NgayNhap,TenNCC from NhapKho n, NhaCungCap c ,DonViSP d where n.MaNCC = c.MaNCC and n.MaDV=d.MaDV";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dtgvWarehouse.DataSource = table;
            groupBox1.Enabled = false;
        }
        void AddCmbDonVi()
        {
            //nut luu
            cnn = new SqlConnection(str);
            cnn.Open();
            //kết nối vào chức vụ
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
            cnn = new SqlConnection(str);
            cnn.Open();
            //kết nối vào chức vụ
            string sql = "select TenNCC from NhaCungCap";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmbNcc.DisplayMember = "TenNCC";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cmbNcc.DataSource = dt;
        }
        public void Add()
        {
            if(cnn.State== ConnectionState.Closed)
            {
                cnn.Open();
                string ma = txtMaSP.Text;
                string tensp = txtTenSP.Text;
                string sl = txtSL.Text;
                string gn = txtGiaNhap.Text;
                string gb = txtGiaBan.Text;
                string manv = txtMaNV.Text;
                int dv = cmbDonVi.SelectedIndex + 1;
                int ncc = cmbNcc.SelectedIndex + 1;
                string nn = dtpNgayNhap.Value.ToString("yyyy-MM-dd");
                command = cnn.CreateCommand();
                command.CommandText = "Insert into NhapKho values('" + ma + "',N'" + tensp + "','" + sl + "','" + dv + "','" + gn + "','" + gb + "','" + manv + "','" + nn + "','" + ncc + "')";
                command.ExecuteNonQuery();
                loadData();
            }
            else
            {
                string ma = txtMaSP.Text;
                string tensp = txtTenSP.Text;
                string sl = txtSL.Text;
                string gn = txtGiaNhap.Text;
                string gb = txtGiaBan.Text;
                string manv = txtMaNV.Text;
                int dv = cmbDonVi.SelectedIndex + 1;
                int ncc = cmbNcc.SelectedIndex + 1;
                string nn = dtpNgayNhap.Value.ToString("yyyy-MM-dd");
                command = cnn.CreateCommand();
                command.CommandText = "Insert into NhapKho values('" + ma + "',N'" + tensp + "','" + sl + "','" + dv + "','" + gn + "','" + gb + "','" + manv + "','" + nn + "','" + ncc + "')";
                command.ExecuteNonQuery();
                loadData();
            }
            
        }
        public void Delete()
        {
            if(cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
                command = cnn.CreateCommand();
                command.CommandText = "delete from NhapKho where MaSP = '" + txtMaSP.Text + "'";
                command.ExecuteNonQuery();
                loadData();
            }
            else
            {
                command = cnn.CreateCommand();
                command.CommandText = "delete from NhapKho where MaSP = '" + txtMaSP.Text + "'";
                command.ExecuteNonQuery();
                loadData();
            }
            
        }
        public void Update()
        {
            string ma = txtMaSP.Text;
            string manv = txtMaNV.Text;
            string tensp = txtTenSP.Text;
            string sl = txtSL.Text;
            decimal gn = decimal.Parse(txtGiaNhap.Text);
            decimal gb = decimal.Parse(txtGiaBan.Text);
            int dv = cmbDonVi.SelectedIndex + 1;
            int ncc = cmbNcc.SelectedIndex + 1;
            string nn = dtpNgayNhap.Value.ToString("yyyy-MM-dd");
            if (cnn.State == ConnectionState.Closed)
            {
                cnn.Open();
                command = cnn.CreateCommand();
                command.CommandText = "update NhapKho set TenSP = N'" + tensp + "',SoLuong = '" + sl + "',MaDV = '" + dv + "',GiaNhap = '" + gn + "',GiaBan = '" + gb + "',MaNV = '" + manv + "',NgayNhap = '" + nn + "',MaNCC = '" + ncc + "' where MaSP = '" + ma + "'";
                command.ExecuteNonQuery();
                loadData();
            }
            else
            {
                command = cnn.CreateCommand();
                command.CommandText = "update NhapKho set TenSP = N'" + tensp + "',SoLuong = '" + sl + "',MaDV = '" + dv + "',GiaNhap = '" + gn + "',GiaBan = '" + gb + "',MaNV = '" + manv + "',NgayNhap = '" + nn + "',MaNCC = '" + ncc + "' where MaSP = '" + ma + "'";
                command.ExecuteNonQuery();
                loadData();
            }
            
        }

        #endregion

        #region Events

        private void btnAdd_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            btnAdd.Enabled = false;
            btnDel.Enabled = false;
            btnUpdate.Enabled = false;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Update();
        }
        private void NhapKho_Load_1(object sender, EventArgs e)
        {
            AddCmbDonVi();
            AddCmbNcc();
            loadData();
            txtMaNV.Focus();
        }

        private void dtgvWarehouse_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtMaSP.Text = dtgvWarehouse.Rows[e.RowIndex].Cells[0].Value?.ToString();
            txtTenSP.Text = dtgvWarehouse.Rows[e.RowIndex].Cells[1].Value?.ToString();
            txtSL.Text = dtgvWarehouse.Rows[e.RowIndex].Cells[2].Value?.ToString();
            cmbDonVi.Text = dtgvWarehouse.Rows[e.RowIndex].Cells[3].Value?.ToString();
            txtGiaNhap.Text = dtgvWarehouse.Rows[e.RowIndex].Cells[4].Value?.ToString();
            txtGiaBan.Text = dtgvWarehouse.Rows[e.RowIndex].Cells[5].Value?.ToString();
            txtMaNV.Text = dtgvWarehouse.Rows[e.RowIndex].Cells[6].Value?.ToString();
            dtpNgayNhap.Text = dtgvWarehouse.Rows[e.RowIndex].Cells[7].Value?.ToString();
            cmbNcc.Text = dtgvWarehouse.Rows[e.RowIndex].Cells[8].Value?.ToString();
        }

        private void btnTonKho_Click_1(object sender, EventArgs e)
        {
            MenuChucNang.TonKho frtk = new MenuChucNang.TonKho();
            this.Hide();
            frtk.ShowDialog();

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Add();
            btnAdd.Enabled = false;
            btnDel.Enabled = false;
            btnUpdate.Enabled = false;



        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            frmMenu frmMenu = new frmMenu();
            this.Hide();
            frmMenu.ShowDialog();
        }


        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            btnAdd.Enabled = true;
            btnDel.Enabled = true;
            btnUpdate.Enabled = true;
        }
    }
}
