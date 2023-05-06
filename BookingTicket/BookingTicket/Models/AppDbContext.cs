using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BookingTicket.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
        }

        public virtual DbSet<DatVe> DatVes { get; set; }
        public virtual DbSet<DinhDangPhim> DinhDangPhims { get; set; }
        public virtual DbSet<Ghe> Ghes { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LichChieu> LichChieux { get; set; }
        public virtual DbSet<LoaiPhim> LoaiPhims { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<Phim> Phims { get; set; }
        public virtual DbSet<PhongChieu> PhongChieux { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Vaitro> Vaitroes { get; set; }
        public virtual DbSet<Ve> Ves { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DinhDangPhim>()
                .HasMany(e => e.LichChieux)
                .WithOptional(e => e.DinhDangPhim)
                .HasForeignKey(e => e.IdDinhDangPhim);

            modelBuilder.Entity<Ghe>()
                .Property(e => e.Row)
                .IsFixedLength();

            modelBuilder.Entity<Ghe>()
                .HasMany(e => e.Ves)
                .WithOptional(e => e.Ghe)
                .HasForeignKey(e => e.IdGhe);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SDT)
                .IsFixedLength();

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.DatVes)
                .WithOptional(e => e.KhachHang)
                .HasForeignKey(e => e.IdKH);

            modelBuilder.Entity<LichChieu>()
                .HasMany(e => e.Ves)
                .WithOptional(e => e.LichChieu)
                .HasForeignKey(e => e.IdLichChieu);

            modelBuilder.Entity<LoaiPhim>()
                .HasMany(e => e.Phims)
                .WithOptional(e => e.LoaiPhim)
                .HasForeignKey(e => e.IdLoaiPhim);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SDT)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.Ves)
                .WithOptional(e => e.NhanVien)
                .HasForeignKey(e => e.IdNhanVien);

            modelBuilder.Entity<Phim>()
                .Property(e => e.Traler)
                .IsFixedLength();

            modelBuilder.Entity<Phim>()
                .HasMany(e => e.LichChieux)
                .WithOptional(e => e.Phim)
                .HasForeignKey(e => e.IdPhim);

            modelBuilder.Entity<PhongChieu>()
                .HasMany(e => e.Ghes)
                .WithOptional(e => e.PhongChieu)
                .HasForeignKey(e => e.IdPhongChieu);

            modelBuilder.Entity<PhongChieu>()
                .HasMany(e => e.LichChieux)
                .WithOptional(e => e.PhongChieu)
                .HasForeignKey(e => e.IdPhongChieu);

            modelBuilder.Entity<Vaitro>()
                .HasMany(e => e.NhanViens)
                .WithOptional(e => e.Vaitro)
                .HasForeignKey(e => e.IdVaiTro);

            modelBuilder.Entity<Ve>()
                .Property(e => e.GiaBan)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Ve>()
                .HasMany(e => e.DatVes)
                .WithOptional(e => e.Ve)
                .HasForeignKey(e => e.IdVe);
        }
    }
}
