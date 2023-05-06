namespace BookingTicket.Models
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

        public int? IdVe { get; set; }

        public int? IdKH { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDat { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual Ve Ve { get; set; }
    }
}
