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
        public Bill()
        {
            InitializeComponent();
        }
        SqlConnection connection = classConnect.connect;
        SqlDataAdapter  adapter = new SqlDataAdapter();
        public DataTable getAllCTHD()
        {
            DataTable dataTable = new DataTable();
            string sql = "select MaHD[Mã hóa đơn],MaSP[Mã sản phẩm],TenSP[Tên sản phẩm],SoLuong[Số lượng],TenDV[Đơn vị],DonGia[Đơn giá],GiamGia[Giảm giá],ThanhTien[Thành tiền] from CTHD c,DonViSP d where c.MaDV=d.MaDV";
            connection.Open();
            adapter = new SqlDataAdapter(sql,connection);
            adapter.Fill(dataTable);
            return dataTable;
        }
        private void Bill_Load(object sender, EventArgs e)
        {
            reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyTiemTapHoa.rptBill.rdlc";
            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Name = "DataSetCTHD";
            reportDataSource.Value = getAllCTHD();
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);
            this.reportViewer1.RefreshReport();
        }
    }
}
