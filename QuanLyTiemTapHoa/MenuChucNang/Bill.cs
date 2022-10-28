using Microsoft.Reporting.WinForms;
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
    public partial class Bill : Form
    {
        SqlConnection cnn = classConnect.connect;
        SqlCommand command = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        SqlDataReader reader;
        public static int mahd = 0;
        public Bill()
        {
            InitializeComponent();
        }
        void loadBill()
        {
            cnn.Open();
            mahd = BanHang.mahd;
            command.CommandText = "select MaHD from HoaDon where MaHD = '" + mahd + "'";
            command.Connection = cnn;
            reader = command.ExecuteReader();
            bool temp = false;
            while (reader.Read())
            {
                txtMaHD.Text = reader.GetInt32(0).ToString();
                mahd = reader.GetInt32(0);
                temp = true;
            }
            cnn.Close();
        }

       
    
        private void Bill_Load(object sender, EventArgs e)
        {
            
            loadBill();
            ReportParameterCollection reportParameters = new ReportParameterCollection();
            reportParameters.Add(new ReportParameter("ReportParameter1", txtMaHD.Text));
            reportViewer1.LocalReport.SetParameters(reportParameters);
            string sql = "select MaSP,TenSP,SoLuong,TenDV,DonGia,GiamGia,ThanhTien from CTHD c,DonViSP d where c.MaDV=d.MaDV and MaHD = '" + txtMaHD.Text + "'";
            adapter = new SqlDataAdapter(sql, cnn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "CTHDReport");
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyTiemTapHoa.MenuChucNang.rptBill.rdlc";
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSetCTHD";
            reportDataSource.Value = ds.Tables["CTHDReport"];
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
            txtMaHD.Hide();
        }
    }
}
