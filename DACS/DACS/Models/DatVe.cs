namespace DACS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DatVe")]
    public partial class DatVe
    {
        public int Id { get; set; }

        public int? IdLichChieu { get; set; }

        public int? IdGhe { get; set; }

        public int? IdNhanVien { get; set; }

        public int? IdKhachHang { get; set; }

        public int? IdLoaiVe { get; set; }

        public int? SoLuong { get; set; }

        public decimal? TongTien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDat { get; set; }

        public virtual Ghe Ghe { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual LichChieu LichChieu { get; set; }

        public virtual LoaiVe LoaiVe { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
