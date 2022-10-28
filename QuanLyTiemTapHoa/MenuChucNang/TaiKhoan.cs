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
    public partial class TaiKhoan : Form
    {
        #region Global Varibles
        SqlConnection connect = classConnect.connect;
        SqlCommand command = new SqlCommand();
        public static string TenTK = "";

        public TaiKhoan()
        {
            InitializeComponent();
        }
        #endregion
        #region Methods
        DataTable TruyVan(String s)
        {
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            try
            {
                da = new SqlDataAdapter(s, connect);
                da.Fill(ds, "KQ");
                connect.Close();
                return ds.Tables["KQ"];
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi truy vấn CSDL. ");
                return new DataTable();
            }
        }
        private void TaiKhoan_Load(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Closed)
              command.CommandText = "select TenTK,MatKhau,MaNV from TaiKhoan";
            command.Connection = connect;
            connect.Open();
            AddCmbMaNV();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát không ? ", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Hide();
                frmDangNhap frmDangNhap = new frmDangNhap();
                frmDangNhap.ShowDialog();
            }
        }
        void AddCmbMaNV()
        {
            string s = "select MaNV from NhanVien";
            SqlCommand cmd = new SqlCommand(s, connect);
            cbmMaNV.DisplayMember = "MaNV";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt = TruyVan(s);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cbmMaNV.Items.Add(dt.Rows[i][0].ToString());
            }
            
        }
        #endregion
        #region Events
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            TenTK = txtTaiKhoan.Text;
            string sql = "select * from TaiKhoan where TenTK='" + txtTaiKhoan.Text + "' and MatKhau='" + txtMatKhau.Text + "'";
            SqlDataAdapter sqldata = new SqlDataAdapter(sql, connect);
            DataTable datatable = new DataTable();
            sqldata.Fill(datatable);
            if (datatable.Rows.Count == 1)
            {
                MessageBox.Show("Đăng nhập thành công");
                frmMenu menu = new frmMenu();
                this.Hide();
                menu.ShowDialog();
            }
            else
            {
                if (txtTaiKhoan.Text == "" && txtMatKhau.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập đầy đủ dữ liệu");
                }
                else if (txtTaiKhoan.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập tài khoản");
                }
                else if (txtMatKhau.Text == "")
                {
                    MessageBox.Show("Bạn chưa nhập mật khẩu");
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string manv = cbmMaNV.SelectedItem.ToString();
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
                command = connect.CreateCommand();
                command.CommandText = "Insert into TaiKhoan values('" + txtTaiKhoan.Text + "',N'" + txtMatKhau.Text + "','" + (cbmMaNV.SelectedItem) + "')";
                command.ExecuteNonQuery();
                MessageBox.Show("Tạo Tài khoản thành công", "Thông báo");
            }
            else
            {
                
                command = connect.CreateCommand();
                command.CommandText = "Insert into TaiKhoan values('" + txtTaiKhoan.Text + "','" + txtMatKhau.Text + "','" + manv + "')";
                command.ExecuteNonQuery();
                MessageBox.Show("Tạo Tài khoản thành công", "Thông báo");
            }    
        }
    }
    #endregion
}
