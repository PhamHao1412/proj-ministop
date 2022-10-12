namespace QuanLyTiemTapHoa
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CTHD")]
    public partial class CTHD
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string MaHD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(5)]
        public string MaSP { get; set; }

        [Required]
        [StringLength(200)]
        public string TenSP { get; set; }

        public double SoLuong { get; set; }

        [StringLength(5)]
        public string MaDV { get; set; }

        [Column(TypeName = "money")]
        public decimal DonGia { get; set; }

        [Column(TypeName = "money")]
        public decimal? GiamGia { get; set; }

        [Column(TypeName = "money")]
        public decimal ThanhTien { get; set; }

        public virtual DonViSP DonViSP { get; set; }

        public virtual HoaDon HoaDon { get; set; }

        public virtual TonKho TonKho { get; set; }
    }
}
