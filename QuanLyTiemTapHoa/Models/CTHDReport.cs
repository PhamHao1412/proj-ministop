using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTiemTapHoa
{
    internal class CTHDReport
    {
        public string MaHD { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public double SoLuong { get; set; }
        public string TenDV { get; set; }
        public decimal DonGia { get; set; }
        public decimal? GiamGia { get; set; }
        public decimal ThanhTien { get; set; }
    }
}
