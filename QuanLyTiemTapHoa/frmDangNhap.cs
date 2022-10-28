using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;

namespace QuanLyTiemTapHoa
{
    public partial class frmDangNhap : Form
    {
        SqlConnection connect = classConnect.connect;

        public frmDangNhap()
        {
            InitializeComponent();
        }
        void DangNhap()
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
        public static string TenTK = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            if (connect.State == ConnectionState.Closed)
            {
                connect.Open();
                txtTaiKhoan.Text = Properties.Settings.Default.username;
                txtMatKhau.Text = Properties.Settings.Default.password;
                if (Properties.Settings.Default.password != "")
                {
                    checkBox1.Checked = true;
                }
            }

            else
            {
                txtTaiKhoan.Text = Properties.Settings.Default.username;
                txtMatKhau.Text = Properties.Settings.Default.password;
            }






        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát không ? ", "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
        }


        private void btnDangNhap_Click(object sender, EventArgs e)
        {

            DangNhap();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (txtTaiKhoan.Text != "" && txtMatKhau.Text != "")
            {
                if (checkBox1.Checked == true)
                {
                    string user = txtTaiKhoan.Text;
                    string pwd = txtMatKhau.Text;
                    Properties.Settings.Default.username = user;
                    Properties.Settings.Default.password = pwd;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.Reset();
                }
            }
        }

        private void txtTaiKhoan_TextChanged(object sender, EventArgs e)
        {
           checkBox1.Checked = false;

        }
    }
}
