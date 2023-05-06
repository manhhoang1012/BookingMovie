namespace BookingTicket.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ve")]
    public partial class Ve
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ve()
        {
            DatVes = new HashSet<DatVe>();
        }

        public int Id { get; set; }

        public int? IdLichChieu { get; set; }

        public int? IdGhe { get; set; }

        public int? IdNhanVien { get; set; }

        public bool? DaBan { get; set; }

        public decimal? GiaBan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatVe> DatVes { get; set; }

        public virtual Ghe Ghe { get; set; }

        public virtual LichChieu LichChieu { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
