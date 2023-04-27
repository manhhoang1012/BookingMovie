namespace DACS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            DatVes = new HashSet<DatVe>();
        }

        public int Id { get; set; }

        [Column(TypeName = "ntext")]
        public string TenNV { get; set; }

        [StringLength(250)]
        public string Email { get; set; }

        [StringLength(15)]
        public string SDT { get; set; }

        [StringLength(250)]
        public string Password { get; set; }

        public bool? GioiTinh { get; set; }

        public int? IdVaiTro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatVe> DatVes { get; set; }

        public virtual Vaitro Vaitro { get; set; }
    }
}
