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
    public partial class BanHang : Form
    {
        #region Global Varibles
        SqlConnection cnn = classConnect.connect;
        SqlCommand command = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        SqlDataReader reader;
        public static string manv = "";
        public static string tennv = "";
        public static int mahd = 0;
        public BanHang()
        {
            InitializeComponent();
        }
        #endregion
        #region Methods
        public void loadData()
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
            command.CommandText = "select * from HoaDon";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvHD.DataSource = table;
            txtMaHD.Text = Convert.ToString(dgvHD.RowCount);
        }
        void Add()
        {
            if (cnn.State == ConnectionState.Closed)
            {
                string sql = " select MaHD from HoaDon where MaHD = '" + txtMaHD.Text + "'";
                if(ChucNang.CheckKey(sql))
                {
                    MessageBox.Show("Mã bạn tạo đã tồn tại\nVui lòng nhập mã khác","Thông báo");
                    txtMaHD.Text = txtKH.Text = "";
                }
                else
                {
                    cnn.Open();
                    string nl = dtpNgayLap.Value.ToString("yyyy-MM-dd");
                    command = cnn.CreateCommand();
                    command.CommandText = "insert into HoaDon(NgayLap,MaNV,MaKH) values('" + nl + "','" + txtMaNV.Text + "','" + txtKH.Text + "')";
                    command.ExecuteNonQuery();
                    loadData();
                }
                
            }
            else
            {
                string sql = " select MaHD from HoaDon where MaHD = '" + txtMaHD + "'";
                if (ChucNang.CheckKey(sql))
                {
                    MessageBox.Show("");
                }
                else
                {
                    command = cnn.CreateCommand();
                    command.CommandText = "insert into HoaDon values('" + dtpNgayLap.Value + "','" + txtMaNV.Text + "','" + txtKH.Text + "')";
                    command.ExecuteNonQuery();
                    loadData();
                }
                
            } 
        }
        void Delete()
        {
            cnn = new SqlConnection(classConnect.sql);
            cnn.Open();
            command = cnn.CreateCommand();
            command.CommandText = "delete from HoaDon where MaHD = '" + txtMaHD.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }
        void update()
        {
            cnn = new SqlConnection(classConnect.sql);
            cnn.Open();
            command = cnn.CreateCommand();
            command.CommandText = "update HoaDon set NgayLap = '" + dtpNgayLap.Value + "',MaKH = '" + txtKH.Text + "'where MaHD = '" + txtMaHD.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }
        void load()
        {
            if (txtMaHD.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã hóa đơn", "Thông báo");
            }
            else
            {
                cnn = new SqlConnection(classConnect.sql);
                cnn.Open();
                command.CommandText = " select MaHD from HoaDon where MaHD = '" + txtMaHD.Text + "'";
                command.Connection = cnn;
                reader = command.ExecuteReader();
                bool temp = false;
                while (reader.Read())
                {
                    txtMaHD.Text = reader.GetInt32(0).ToString();
                    mahd = reader.GetInt32(0);
                    temp = true;
                }
                MenuChucNang.ChiTietHoaDon frmCTHD = new MenuChucNang.ChiTietHoaDon();
                this.Hide();
                frmCTHD.ShowDialog();
            }
            
        }
        #endregion
        #region Events
        private void btnLapHD_Click(object sender, EventArgs e)
        {
            load(); 
        }

        private void BanHang_Load(object sender, EventArgs e)
        {

            cnn = new SqlConnection(classConnect.sql);
            cnn.Open();
            loadData();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn quay lại trang chủ không ?","Thông báo",MessageBoxButtons.OK);
            if(dr == DialogResult.OK)
            {
                frmMenu frmMenu = new frmMenu();
                this.Hide();
                frmMenu.ShowDialog();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void dgvHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvHD.CurrentRow.Index;
            txtMaHD.Text = dgvHD.Rows[i].Cells[0].Value.ToString();
            dtpNgayLap.Text = dgvHD.Rows[i].Cells[1].Value.ToString();
            txtMaNV.Text = dgvHD.Rows[i].Cells[2].Value.ToString();
            //txtTenNV.Text = dgvHD.Rows[i].Cells[3].ToString();
            txtKH.Text = dgvHD.Rows[i].Cells[3].Value.ToString();
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            update();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaHD.Clear();
            txtKH.Clear();
        }
    }
    #endregion
}
