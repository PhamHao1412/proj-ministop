namespace QuanLyTiemTapHoa
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhapKho")]
    public partial class NhapKho
    {
        [Key]
        [StringLength(5)]
        public string MaSP { get; set; }

        [StringLength(200)]
        public string TenSP { get; set; }

        public int? SoLuong { get; set; }

        [StringLength(5)]
        public string MaDV { get; set; }

        [Column(TypeName = "money")]
        public decimal? GiaNhap { get; set; }

        [Column(TypeName = "money")]
        public decimal? GiaBan { get; set; }

        [StringLength(5)]
        public string MaNV { get; set; }

        public DateTime? NgayNhap { get; set; }

        [StringLength(5)]
        public string MaNCC { get; set; }

        public virtual DonViSP DonViSP { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }

        public virtual TonKho TonKho { get; set; }
    }
}
