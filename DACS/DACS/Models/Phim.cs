namespace DACS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phim")]
    public partial class Phim
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phim()
        {
            LichChieux = new HashSet<LichChieu>();
        }

        public int Id { get; set; }

        [StringLength(250)]
        public string TenPhim { get; set; }

        public string NoiDung { get; set; }

        public int? ThoiLuong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayCongChieu { get; set; }

        [StringLength(100)]
        public string NgonNgu { get; set; }

        [StringLength(100)]
        public string QuocGia { get; set; }

        [StringLength(250)]
        public string NSX { get; set; }

        [StringLength(250)]
        public string DienVienChinh { get; set; }

        [StringLength(250)]
        public string Hinh { get; set; }

        [StringLength(250)]
        public string Traler { get; set; }

        public int? IdLoaiPhim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichChieu> LichChieux { get; set; }

        public virtual LoaiPhim LoaiPhim { get; set; }
    }
}
