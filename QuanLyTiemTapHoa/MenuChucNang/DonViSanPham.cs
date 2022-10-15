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
    
    public partial class DonViSanPham : Form
    {
        SqlConnection cnn = classConnect.connect;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public DonViSanPham()
        {
            InitializeComponent();
        }

        void loadData()
        {
            command = cnn.CreateCommand();
            command.CommandText = "select MaDV[Mã đơn vị],TenDV[Tên đơn vị] from DonViSP";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvDonViSP.DataSource = table;
        }

        void Add()
        {
            command = cnn.CreateCommand();
            command.CommandText = "insert into DonViSP values('" + txtID.Text + "',N'" + txtName.Text + "')";
            command.ExecuteNonQuery();
            loadData();
        }

        public void Delete()
        {
            command = cnn.CreateCommand();
            command.CommandText = "delete from DonViSP where MaDV = '" + txtID.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }

        public void Update()
        {
            command = cnn.CreateCommand();
            command.CommandText = "update DonVi set TenNV = N'" + txtName.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }

        private void DonViSanPham_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(classConnect.sql);
            cnn.Open();
            loadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmMenu frmMenu = new frmMenu();
            this.Hide();
            frmMenu.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtName.Clear();
        }

        private void dgvDonViSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvDonViSP.CurrentRow.Index;
            txtID.Text = dgvDonViSP.Rows[i].Cells[0].Value.ToString();
            txtName.Text = dgvDonViSP.Rows[i].Cells[1].Value.ToString();
        }
    }
}
