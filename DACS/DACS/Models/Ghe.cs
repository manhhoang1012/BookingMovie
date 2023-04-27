namespace DACS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ghe")]
    public partial class Ghe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ghe()
        {
            DatVes = new HashSet<DatVe>();
        }

        public int Id { get; set; }

        [StringLength(5)]
        public string Row { get; set; }

        public int? Num { get; set; }

        public bool? Status { get; set; }

        public int? IdPhongChieu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatVe> DatVes { get; set; }

        public virtual PhongChieu PhongChieu { get; set; }
    }
}
