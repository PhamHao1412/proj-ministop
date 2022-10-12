namespace QuanLyTiemTapHoa
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TonKho")]
    public partial class TonKho
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TonKho()
        {
            CTHD = new HashSet<CTHD>();
        }

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
        public string MaNCC { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTHD> CTHD { get; set; }

        public virtual DonViSP DonViSP { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }

        public virtual NhapKho NhapKho { get; set; }
    }
}
