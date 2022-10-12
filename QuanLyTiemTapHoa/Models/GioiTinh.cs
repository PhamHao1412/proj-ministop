namespace QuanLyTiemTapHoa
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GioiTinh")]
    public partial class GioiTinh
    {
        [Key]
        [Column("GioiTinh")]
        [StringLength(5)]
        public string GioiTinh1 { get; set; }
    }
}
