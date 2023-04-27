namespace DACS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LichChieu")]
    public partial class LichChieu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LichChieu()
        {
            DatVes = new HashSet<DatVe>();
        }

        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayChieu { get; set; }

        public TimeSpan? GioBatDau { get; set; }

        public TimeSpan? GioKetThuc { get; set; }

        public int? IdPhim { get; set; }

        public int? IdPhongChieu { get; set; }

        public int? IdDinhDangPhim { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatVe> DatVes { get; set; }

        public virtual DinhDangPhim DinhDangPhim { get; set; }

        public virtual Phim Phim { get; set; }

        public virtual PhongChieu PhongChieu { get; set; }
    }
}
