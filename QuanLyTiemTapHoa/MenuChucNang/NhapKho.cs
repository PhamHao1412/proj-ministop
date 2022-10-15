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

        SqlConnection cnn = classConnect.connect;
        SqlCommand command = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        SqlDataReader reader;
        SqlCommand command1 = new SqlCommand();
        SqlDataAdapter adapter1 = new SqlDataAdapter();
        DataTable table1 = new DataTable();
        
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

        }
        void loadDataGirdViewWareHouse()
        {
            cnn.Close();
            command = cnn.CreateCommand();
            command.CommandText = "select MaSP[Mã sản phẩm],TenSP[Tên sản phẩm],SoLuong[Số lượng],TenDV[Đơn vị],GiaNhap[Giá nhập],GiaBan[Giá bán],MaNV[Mã nhân viên],NgayNhap[Ngày nhập],TenNCC[Nhà cung cấp] from NhapKho n, NhaCungCap c ,DonViSP d where n.MaNCC = c.MaNCC and n.MaDV=d.MaDV";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dtgvWarehouse.DataSource = table;
            groupBox1.Enabled = false;
        }
        void loadDataGirdViewInventory()
        {
            cnn.Close();
            command1 = cnn.CreateCommand();
            command1.CommandText = "select MaSP[Mã sản phẩm tồn kho],TenSP[Tên sản phẩm],SoLuong[Số lượng],TenDV[Đơn vị],GiaNhap[Giá nhập],GiaBan[Giá bán],TenNCC[Nhà cung cấp] from TonKho t,NhaCungCap n,DonViSP d where t.MaDV=d.MaDV and n.MaNCC=t.MaNCC";
            adapter1.SelectCommand = command1;
            table1.Clear();
            adapter1.Fill(table1);
            dgvTonKho.DataSource = table1;
        }
        void AddCmbDonVi()
        {
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
            string sql = "select TenNCC from NhaCungCap";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmbNcc.DisplayMember = "TenNCC";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cmbNcc.DataSource = dt;
        }
        private int GetSelectedRowNhapKho(string MaSP)
        {
            for (int i = 0; i < dtgvWarehouse.Rows.Count; i++)
            {
                if (dtgvWarehouse.Rows[i].Cells[0].Value.ToString() == MaSP)
                {
                    return i;
                }
            }
            return -1;
        }
        private int GetSelectedRowTonKho(string MaSP)
        {
            for (int i = 0; i < dgvTonKho.Rows.Count; i++)
            {
                if (dgvTonKho.Rows[i].Cells[0].Value.ToString() == MaSP)
                {
                    return i;
                }
            }
            return -1;
        }
        public void addNhapKho()
        {
            int selectedRowsNhapKho = GetSelectedRowNhapKho(txtMaSP.Text);
            if (selectedRowsNhapKho == -1)
            {
                string nn = dtpNgayNhap.Value.ToString("yyyy-MM-dd");
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                    command = cnn.CreateCommand();
                    command.CommandText = "Insert into NhapKho values('" + txtMaSP.Text + "',N'" + txtTenSP.Text + "','" + txtSL.Text + "','" + (cmbDonVi.SelectedIndex + 1) + "','" + txtGiaNhap.Text + "','" + txtGiaBan.Text + "','" + txtMaNV.Text + "','" + nn + "','" + (cmbNcc.SelectedIndex + 1) + "')";
                    command.ExecuteNonQuery();
                    loadDataGirdViewWareHouse();
                }

                else
                {
                    command = cnn.CreateCommand();
                    command.CommandText = "Insert into NhapKho values('" + txtMaSP.Text + "',N'" + txtTenSP.Text + "','" + txtSL.Text + "','" + (cmbDonVi.SelectedIndex + 1) + "','" + txtGiaNhap.Text + "','" + txtGiaBan.Text + "','" + txtMaNV.Text + "','" + nn + "','" + (cmbNcc.SelectedIndex + 1) + "')";
                    command.ExecuteNonQuery();
                    loadDataGirdViewWareHouse();
                }
            }
            else
            {
                int soluongNhapKho = Convert.ToInt32(table.Rows[selectedRowsNhapKho]["Số lượng"].ToString());
                int tongNhapKho = soluongNhapKho + Convert.ToInt32(txtSL.Text);
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                    command = cnn.CreateCommand();
                    command.CommandText = "Update NhapKho set SoLuong = '" + tongNhapKho + "' Where MaSP = '" + txtMaSP.Text + "'";
                    command.ExecuteNonQuery();
                    loadDataGirdViewWareHouse();
                }
                else
                {
                    command = cnn.CreateCommand();
                    command.CommandText = "Update NhapKho set SoLuong = '" + tongNhapKho + "' Where MaSP = '" + txtMaSP.Text + "'";
                    command.ExecuteNonQuery();
                    loadDataGirdViewWareHouse();
                }
            }  
        }
        public void addTonKho()
        {
            string ma = txtMaSP.Text;
            string tensp = txtTenSP.Text;
            string sl = txtSL.Text;
            string gn = txtGiaNhap.Text;
            string gb = txtGiaBan.Text;
            int dv = cmbDonVi.SelectedIndex + 1;
            int ncc = cmbNcc.SelectedIndex + 1;
            int selectedRowsTonKho = GetSelectedRowTonKho(ma);
            if (selectedRowsTonKho == -1)
            {
                string nn = dtpNgayNhap.Value.ToString("yyyy-MM-dd");
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                    command = cnn.CreateCommand();
                    command.CommandText = "Insert into TonKho values('" + ma + "',N'" + tensp + "','" + sl + "','" + dv + "','" + gn + "','" + gb + "','" + ncc + "')";
                    command.ExecuteNonQuery();
                    loadDataGirdViewInventory();
                }

                else
                {
                    command = cnn.CreateCommand();
                    command.CommandText = "Insert into TonKho values('" + ma + "',N'" + tensp + "','" + sl + "','" + dv + "','" + gn + "','" + gb + "','" + ncc + "')";
                    command.ExecuteNonQuery();
                    loadDataGirdViewInventory();
                }
            }
            else
            {
                int soluongTonKho = Convert.ToInt32(table1.Rows[selectedRowsTonKho]["Số lượng"].ToString());
                int tongTonKho = soluongTonKho + Convert.ToInt32(txtSL.Text);
                if (cnn.State == ConnectionState.Closed)
                {
                    cnn.Open();
                    command = cnn.CreateCommand();
                    command.CommandText = "Update TonKho set SoLuong = '" + tongTonKho + "' Where MaSP = '" + txtMaSP.Text + "'";
                    command.ExecuteNonQuery();
                    loadDataGirdViewInventory();
                }
                else
                {
                    command = cnn.CreateCommand();
                    command.CommandText = "Update TonKho set SoLuong = '" + tongTonKho + "' Where MaSP = '" + txtMaSP.Text + "'";
                    command.ExecuteNonQuery();
                    loadDataGirdViewInventory();
                } 
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
                loadDataGirdViewWareHouse();
            }
            else
            {
                command = cnn.CreateCommand();
                command.CommandText = "delete from NhapKho where MaSP = '" + txtMaSP.Text + "'";
                command.ExecuteNonQuery();
                loadDataGirdViewWareHouse();
            }
            
        }
        public void Update()
        {
            //Moi check cung ok do 
            // tao commit do , thay khong ?
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
                loadDataGirdViewWareHouse();
            }
            else
            {
                command = cnn.CreateCommand();
                command.CommandText = "update NhapKho set TenSP = N'" + tensp + "',SoLuong = '" + sl + "',MaDV = '" + dv + "',GiaNhap = '" + gn + "',GiaBan = '" + gb + "',MaNV = '" + manv + "',NgayNhap = '" + nn + "',MaNCC = '" + ncc + "' where MaSP = '" + ma + "'";
                command.ExecuteNonQuery();
                loadDataGirdViewWareHouse();
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

        private void NhapKho_Load(object sender, EventArgs e)
        {
            dgvTonKho.Hide();
            cnn = new SqlConnection(classConnect.sql);
            cnn.Open();
            AddCmbDonVi();
            AddCmbNcc();
            loadData();
            loadDataGirdViewWareHouse();
            loadDataGirdViewInventory();
            txtMaNV.Focus();
        }

        private void dtgvWarehouse_CellClick(object sender, DataGridViewCellEventArgs e)
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

        private void btnTonKho_Click(object sender, EventArgs e)
        {
            MenuChucNang.TonKho frtk = new MenuChucNang.TonKho();
            this.Hide();
            frtk.ShowDialog();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            addNhapKho();
            addTonKho();
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
