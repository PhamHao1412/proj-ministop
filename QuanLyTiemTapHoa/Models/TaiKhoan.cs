namespace QuanLyTiemTapHoa
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [Key]
        [StringLength(100)]
        public string TenTK { get; set; }

        [StringLength(100)]
        public string MatKhau { get; set; }

        [StringLength(5)]
        public string MaNV { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
