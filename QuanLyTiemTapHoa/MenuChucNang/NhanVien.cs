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
    public partial class NhanVien : Form
    {
        #region Global Varibles
        SqlConnection cnn = classConnect.connect;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public NhanVien()
        {
            InitializeComponent();
        }
        #endregion
        #region Methods
        void loadData()
        {
            command = cnn.CreateCommand();
            command.CommandText = "select MaNV , TenNV , GioiTinh , NgaySinh , DiaChi , SDT , CCCD , Email , c.TenCV from NhanVien n, ChucVu c where c.MaCV = n.MaCV";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvEmployees.DataSource = table;
        }
        public void Add()
        {
            string nn = datetimeNgaySinh.Value.ToString("yyyy-MM-dd");
            command = cnn.CreateCommand();
            command.CommandText = "insert into NhanVien values('"+txtMaNV.Text+"',N'"+txtHoTen.Text+"',N'"+cmbGioiTinh.SelectedItem+"','" + nn + "',N'"+txtDiaChi.Text+"','"+txtSDT.Text+"','"+txtCCCD.Text+"','"+txtEmail.Text+"','"+(cmbChucVu.SelectedIndex+1)+"')";
            command.ExecuteNonQuery();
            loadData();
        }
        public void Delete()
        {
            command = cnn.CreateCommand();
            command.CommandText = "delete from NhanVien where MaNV = '"+txtMaNV.Text+"'";
            command.ExecuteNonQuery ();
            loadData();
        }
        public void Update()
        {
            command = cnn.CreateCommand();
            command.CommandText = "update NhanVien set TenNV = N'" + txtHoTen.Text + "',GioiTinh = N'" + cmbGioiTinh.Text + "',NgaySinh = '" + datetimeNgaySinh.Value.ToString("yyyy-MM-dd") + "',DiaChi = N'" + txtDiaChi.Text + "',SDT = '" + txtSDT.Text + "',CCCD = '" + txtCCCD.Text + "',Email = '" + txtEmail.Text + "',MaCV = '" + (cmbChucVu.SelectedIndex + 1) + "' where MaNV = '"+txtMaNV.Text+"'";
            command.ExecuteNonQuery();
            loadData();
        }
        private void NhanVien_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(classConnect.sql);
            cnn.Open();
            //kết nối vào chức vụ
            string sql = "select TenCV from ChucVu";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmbChucVu.DisplayMember = "TenCV";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cmbChucVu.DataSource = dt;
            //kết nối vào datagird view
            loadData();
        }
        #endregion
        #region Events
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvEmployees.CurrentRow.Index;
            txtMaNV.Text = dgvEmployees.Rows[i].Cells[0].Value.ToString();
            txtHoTen.Text = dgvEmployees.Rows[i].Cells[1].Value.ToString();
            cmbGioiTinh.Text = dgvEmployees.Rows[i].Cells[2].Value.ToString();
            datetimeNgaySinh.Text = dgvEmployees.Rows[i].Cells[3].Value.ToString();
            txtDiaChi.Text = dgvEmployees.Rows[i].Cells[4].Value.ToString();
            txtSDT.Text = dgvEmployees.Rows[i].Cells[5].Value.ToString();
            txtCCCD.Text = dgvEmployees.Rows[i].Cells[6].Value.ToString();
            txtEmail.Text = dgvEmployees.Rows[i].Cells[7].Value.ToString();
            cmbChucVu.Text = dgvEmployees.Rows[i].Cells[8].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            
            frmMenu frmMenu = new frmMenu();
            this.Hide();
            frmMenu.ShowDialog();
        }

        private void btnTKNV_Click(object sender, EventArgs e)
        {
            MenuChucNang.TaiKhoan frtk = new MenuChucNang.TaiKhoan();
            this.Hide();
            frtk.ShowDialog();
        }
    }
    #endregion
}
