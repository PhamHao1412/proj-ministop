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
    public partial class NhaCungCap : Form
    {
        SqlConnection cnn = classConnect.connect;
        SqlCommand command;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        public NhaCungCap()
        {
            InitializeComponent();
        }
        void loadData()
        {
            command = cnn.CreateCommand();
            command.CommandText = "select MaNCC[Mã nhà cung cấp],TenNCC[Tên nhà cung cấp] from NhaCungCap";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvNhaCungCap.DataSource = table;
        }
        public void Add()
        {
            command = cnn.CreateCommand();
            command.CommandText = "insert into NhaCungCap values('"+txtMaNCC.Text+"',N'"+txtTenNCC.Text+"')";
            command.ExecuteNonQuery();
            loadData();
        }
        public void Delete()
        {
            command = cnn.CreateCommand();
            command.CommandText = "delete from NhaCungCap where MaNCC = '" + txtMaNCC.Text + "'";
            command.ExecuteNonQuery();
            loadData();
        }
        public void Update()
        {
            command = cnn.CreateCommand();
            command.CommandText = "update NhaCungCap set TenNCC = N'"+txtTenNCC.Text+"' where MaNCC='"+txtMaNCC.Text+"'";
            command.ExecuteNonQuery();
            loadData();
        }

        private void NhaCungCap_Load(object sender, EventArgs e)
        {
            cnn = new SqlConnection(classConnect.sql);
            cnn.Open();
            loadData();
        }

        private void btnExit_Click(object sender, EventArgs e)
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

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMaNCC.Clear();
            txtTenNCC.Clear();
        }

        private void dgvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvNhaCungCap.CurrentRow.Index;
            txtMaNCC.Text = dgvNhaCungCap.Rows[i].Cells[0].Value.ToString();
            txtTenNCC.Text = dgvNhaCungCap.Rows[i].Cells[1].Value.ToString();
        }
    }
}
