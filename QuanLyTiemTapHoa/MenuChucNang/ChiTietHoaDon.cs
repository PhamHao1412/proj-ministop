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
    public partial class ChiTietHoaDon : Form
    {
        SqlConnection cnn = classConnect.connect;
        SqlCommand command = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        SqlDataReader reader;
        public static int mahd = 0;
        public static string tennv = "";
        public static string tensp = "";
        public static string tendv = "";
        public static decimal giaban = 0;
        public static decimal giamgia = 0;
        public ChiTietHoaDon()
        {
            InitializeComponent();
        }
        void loadData()
        {
            command.CommandText = "select MaHD,TenNV from HoaDon,NhanVien";
            command.Connection = cnn;
            reader = command.ExecuteReader();
            bool temp = false;
            while (reader.Read())
            {
                txtMaHD.Text = reader.GetInt32(0).ToString();
                mahd = reader.GetInt32(0);
                txtTenNV.Text = reader.GetString(1);
                tennv = reader.GetString(1);
                temp = true;
            }
            if (temp == false)
                MessageBox.Show("Không tìm thấy");  
        }
        void Add()
        {
            command = cnn.CreateCommand();
            command.CommandText = "insert into CTHD values('"+txtMaHD.Text+"','"+txtMaSP.Text+"','"+txtTenSP.Text+"','"+txtSL.Text+"','"+(cmbDonViSP.SelectedIndex+1)+"','"+txtDonGia.Text+"','"+txtGiamGia.Text+"','"+txtThanhTien.Text+"')";
            command.ExecuteNonQuery();
            command.CommandText = "update TonKho set soluong = soluong - '" + txtSL.Text+"'where MaSP = '"+txtMaSP.Text+"'";
            command.ExecuteNonQuery();
            loadData();
            cnn.Close();
            loadHD();
        }
        void Delete()
        {
            cnn.Open();
            command = cnn.CreateCommand();
            command.CommandText = "delete from CTHD where MaSP = '" + txtMaSP.Text + "'";
            command.ExecuteNonQuery();
            command.CommandText = "update TonKho set soluong = soluong + '" + txtSL.Text + "'where MaSP = '" + txtMaSP.Text + "'";
            command.ExecuteNonQuery();
            loadHD();
        }
        void loadHD()
        {
            command = cnn.CreateCommand();
            command.CommandText = "select MaHD[Mã hóa đơn],MaSP[Mã sản phẩm] , TenSP[Tên sản phẩm] , SoLuong[Số lượng] ,TenDV[Đơn vị] ,DonGia[Đơn giá] , GiamGia[Giảm giá] , ThanhTien[Thành tiền]  from CTHD,DonViSP where MaHD = '"+txtMaHD.Text+ "'and DonViSP.MaDV = CTHD.MaDV";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvHoaDon.DataSource = table;
        }
        void Search()
        {
            cnn.Close();
            cnn.Open();
            command.CommandText = "select TenSP,TenDV,GiaBan from NhapKho,DonViSP where NhapKho.MaDV = DonViSP.MaDV and MaSP='"+txtMaSP.Text+"'";
            command.Connection = cnn;
            reader = command.ExecuteReader();
            bool temp = false;
            while (reader.Read())
            {
                txtTenSP.Text = reader.GetString(0);
                tensp = reader.GetString(0);
                cmbDonViSP.Text = reader.GetString(1);
                tendv = reader.GetString(1);
                txtDonGia.Text = Convert.ToString(reader.GetDecimal(2));
                giaban = reader.GetDecimal(2);
                temp = true;
            }
            if (temp == false)
                MessageBox.Show("Không tìm thấy");

        }
        private void ChiTietHoaDon_Load(object sender, EventArgs e)
        {
            cnn.Open();
            string sql = "select TenDV from DonViSP";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            cmbDonViSP.DisplayMember = "TenDV";
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            cmbDonViSP.DataSource = dt;
            loadData();
            cnn.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
            cnn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cnn.Open();
            Add();
            decimal total ;
            total = Convert.ToDecimal(txtTongCong.Text) + Convert.ToDecimal(txtThanhTien.Text);
            txtTongCong.Text = Convert.ToString(total);
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtSL.Clear();
            txtDonGia.Clear();
            txtGiamGia.Clear();
            txtThanhTien.Clear();
        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            if(txtSL.Text == "" || txtGiamGia.Text =="")
            {
                MessageBox.Show("Bạn chưa nhập số lượng sản phẩm hoặc giảm giá");
            }
            else
            {
                decimal dongia = Convert.ToDecimal(txtDonGia.Text);
                decimal sl = Convert.ToDecimal(txtSL.Text);
                decimal giamgia = Convert.ToDecimal(txtGiamGia.Text);
                txtThanhTien.Text = Convert.ToString(dongia*sl-giamgia);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvHoaDon.CurrentRow.Index;
            txtMaSP.Text = dgvHoaDon.Rows[i].Cells[1].Value.ToString();
            txtTenSP.Text = dgvHoaDon.Rows[i].Cells[2].Value.ToString();
            txtSL.Text = dgvHoaDon.Rows[i].Cells[3].Value.ToString();
            cmbDonViSP.Text = dgvHoaDon.Rows[i].Cells[4].Value.ToString();
            txtDonGia.Text = dgvHoaDon.Rows[i].Cells[5].Value.ToString();
            txtGiamGia.Text = dgvHoaDon.Rows[i].Cells[6].Value.ToString();
            txtThanhTien.Text = dgvHoaDon.Rows[i].Cells[7].Value.ToString();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            MenuChucNang.ThanhToan.thanhtoan = Convert.ToDecimal(txtTongCong.Text);
            MenuChucNang.ThanhToan frmTT = new MenuChucNang.ThanhToan();
            this.Hide();
            frmTT.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn hủy hóa đơn không ?", "Thông báo", MessageBoxButtons.YesNo);
            if(dr == DialogResult.Yes)
            {
                MenuChucNang.BanHang banHang = new MenuChucNang.BanHang();
                table.Clear();
                this.Hide();
                banHang.ShowDialog();
            }
        }
    }
}
