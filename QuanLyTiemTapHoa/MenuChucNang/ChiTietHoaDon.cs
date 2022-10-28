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
    public partial class ChiTietHoaDon : Form
    {
        #region Global Varibles
        SqlConnection cnn = classConnect.connect;
        SqlCommand command = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        SqlDataReader reader;
        public static int mahd = 0;
        public static string tennv = "";
        public static string tensp = "";
        public static string tendv = "";
        public static decimal thanhtien = 0;
        public static decimal giaban = 0;
        public static decimal giamgia = 0;
        public static decimal tongtien = 0;
        decimal sl;
        public ChiTietHoaDon()
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
       
        void autoTinhTien()
        {
            
            sl = 0;
            giamgia = 0;
            thanhtien = 0;
            if(txtSL.Text =="" || txtGiamGia.Text == "" || txtDonGia.Text == "")
            {
                giaban = 0;
                sl = 0;
                giamgia = 0;
            }
            else
            {
                giaban = Convert.ToDecimal(txtDonGia.Text);
                sl = Convert.ToDecimal(txtSL.Text);
                giamgia = Convert.ToDecimal(txtGiamGia.Text);
                
            }
            thanhtien = giaban * sl - giamgia;
            txtThanhTien.Text = Convert.ToString(thanhtien);
        }

        void loadData()
        {
            tongtien = 0;
            mahd = BanHang.mahd;
            command.CommandText = "select MaHD,TenNV from HoaDon hd,NhanVien where hd.MaHD = '"+mahd+"'";
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
            
            cnn.Close();
            command = cnn.CreateCommand();
            command.CommandText = "select MaHD[Mã hóa đơn],MaSP[Mã sản phẩm],TenSP[Tên sản phẩm],SoLuong[Số lượng],TenDV[Đơn vị],DonGia[Đơn giá],GiamGia[Giảm giá],ThanhTien[Thành tiền] from CTHD c,DonViSP d where c.MaDV=d.MaDV and MaHD = '" + txtMaHD.Text+"'";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvHoaDon.DataSource = table;
            
            string s = "select ThanhTien from CTHD where MaHD = '"+txtMaHD.Text+"'";
            SqlCommand sqlCommand = new SqlCommand(s, cnn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            dataTable = TruyVan(s);
            for(int i= 0; i < dataTable.Rows.Count; i++)
            {
                string tien = dataTable.Rows[i][0].ToString();
                tongtien = tongtien + Convert.ToDecimal(tien);

            }
            txtTongCong.Text = Convert.ToString(tongtien);
        }

        void Add()
        {
            command = cnn.CreateCommand();
            command.CommandText = "insert into CTHD values('"+txtMaHD.Text+"','"+txtMaSP.Text+"',N'"+txtTenSP.Text+"','"+txtSL.Text+"','"+(cmbDonViSP.SelectedIndex+1)+"','"+txtDonGia.Text+"','"+txtGiamGia.Text+"','"+txtThanhTien.Text+"')";
            command.ExecuteNonQuery();
            command.CommandText = "update TonKho set soluong = soluong - '" + txtSL.Text+"'where MaSP = '"+txtMaSP.Text+"'";
            command.ExecuteNonQuery();
            loadData();
            cnn.Close();
        }

        void Delete()
        {
            cnn.Open();
            command = cnn.CreateCommand();
            command.CommandText = "delete from CTHD where MaSP = '" + txtMaSP.Text + "'";
            command.ExecuteNonQuery();
            command.CommandText = "update TonKho set soluong = soluong + '" + txtSL.Text + "'where MaSP = '" + txtMaSP.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }
        #endregion
        #region Events
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cnn.Open();
            Add();
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
                txtMaHD.ResetText();
                this.Hide();
                banHang.ShowDialog();
            }
        }

        private void txtMaSP_TextChanged(object sender, EventArgs e)
        {
            string sql = "select TenSP  from TonKho where MaSP = '" + txtMaSP.Text + "' ";
            SqlCommand cmd = new SqlCommand(sql, cnn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dt = TruyVan(sql);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                txtTenSP.Text = dt.Rows[i][0].ToString();
            }

            string sql2 = "select TenDV from TonKho t,DonViSP d where t.MaDV=d.MaDV and MaSP = '" + txtMaSP.Text + "' ";
            SqlCommand cmd2 = new SqlCommand(sql2, cnn);
            SqlDataAdapter adapter2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            dt2 = TruyVan(sql2);
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                cmbDonViSP.Text = dt2.Rows[i][0].ToString();
            }

            string sql3 = "select GiaBan from TonKho where MaSP = '" + txtMaSP.Text + "' ";
            SqlCommand cmd3 = new SqlCommand(sql, cnn);
            SqlDataAdapter adapter3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            dt3 = TruyVan(sql3);
            for (int i = 0; i < dt3.Rows.Count; i++)
            {
                txtDonGia.Text = dt3.Rows[i][0].ToString();
            }
            autoTinhTien();
        }

        private void txtThanhTien_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSL_TextChanged(object sender, EventArgs e)
        {
            autoTinhTien();
        }

        private void txtGiamGia_TextChanged(object sender, EventArgs e)
        {
            autoTinhTien();
        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

            }
            if(e.KeyChar == 8 )
            {
                e.Handled = false;
            }
        }
    }
    #endregion
}
