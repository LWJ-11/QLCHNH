using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ThePerfumeShop.Models.DataView;

namespace ThePerfumeShop.Models;

public partial class QlchnhContext : DbContext
{
    public QlchnhContext()
    {
    }

    public QlchnhContext(DbContextOptions<QlchnhContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<ChiTietDt> ChiTietDts { get; set; }

    public virtual DbSet<ChiTietHd> ChiTietHds { get; set; }

    public virtual DbSet<CuaHang> CuaHangs { get; set; }

    public virtual DbSet<DoanhThu> DoanhThus { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<Kho> Khos { get; set; }

    public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<QuanLy> QuanLies { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<TonKho> TonKhos { get; set; }

    //*************************************************************
    //DataView

    public DbSet<DanhSachKho> DanhSachKho { get; set; }
    public DbSet<DanhSachSanPham> DanhSachSanPham { get; set; }
    public DbSet<DanhSachHoaDon> DanhSachHoaDon { get; set; }
    public DbSet<DanhSachNhanVien> DanhSachNhanVien { get; set; }
    public DbSet<ThemNhanVien> ThemNhanVien { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-ETCHBCG;Database=QLCHNH;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //DataView
        modelBuilder.Entity<ThemNhanVien>(
            eb =>
            {
                eb.HasNoKey();
                eb.ToView("View_ThemNhanVien");
                eb.Property(v => v.TenDN).HasColumnName("taikhoan");
                eb.Property(v => v.Matkhau).HasColumnName("matkhau");
                eb.Property(v => v.TenNv).HasColumnName("ten_NV");
                eb.Property(v => v.Ngaysinh).HasColumnName("ngaysinh");
                eb.Property(v => v.Gioitinh).HasColumnName("gioitinh");
                eb.Property(v => v.Sdt).HasColumnName("sdt");
                eb.Property(v => v.Diachi).HasColumnName("diachi");
                eb.Property(v => v.MaCh).HasColumnName("ma_CH");
            });
        modelBuilder.Entity<DanhSachNhanVien>(
            eb =>
           {
               eb.HasNoKey();
               eb.ToView("View_DanhSachNhanVien");
               eb.Property(v => v.MaNv).HasColumnName("ma_NV");
               eb.Property(v => v.TenNv).HasColumnName("ten_NV");
               eb.Property(v => v.Ngaysinh).HasColumnName("ngaysinh");
               eb.Property(v => v.Gioitinh).HasColumnName("gioitinh");
               eb.Property(v => v.Sdt).HasColumnName("sdt");
               eb.Property(v => v.Diachi).HasColumnName("diachi");
               eb.Property(v => v.MaCh).HasColumnName("ma_CH");
               eb.Property(v => v.TenCh).HasColumnName("ten_CH");
           });
        modelBuilder.Entity<DanhSachHoaDon>(
           eb =>
           {
               eb.HasNoKey();
               eb.ToView("View_DanhSachHoaDon");
               eb.Property(v => v.MaHd).HasColumnName("ma_HD");
               eb.Property(v => v.TenKh).HasColumnName("ten_KH");
               eb.Property(v => v.Thoigian).HasColumnName("thoigian");
               eb.Property(v => v.Thanhtien).HasColumnName("thanhtien");
           });
        modelBuilder.Entity<DanhSachKho>(
            eb =>
            {
                eb.HasNoKey();
                eb.ToView("View_DanhSachKho");
                eb.Property(v => v.MaKho).HasColumnName("ma_Kho");
                eb.Property(v => v.Diachi).HasColumnName("diaChi");
                eb.Property(v => v.TenCh).HasColumnName("ten_CH");
            });
        modelBuilder.Entity<DanhSachSanPham>(
            eb =>
            {
                eb.HasNoKey();
                eb.ToView("View_DanhSachSanPham");
                eb.Property(v => v.MaSp).HasColumnName("ma_SP");
                eb.Property(v => v.TenSp).HasColumnName("ten_SP");
                eb.Property(v => v.Gia).HasColumnName("gia");
                eb.Property(v => v.Chitiet).HasColumnName("chitiet");
                eb.Property(v => v.TenBr).HasColumnName("ten_Br");
                eb.Property(v => v.TenNcc).HasColumnName("ten_NCC");
            });

        //**************************************************************
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.MaBr).HasName("PK__Brand__0FE67ACBFD6EC22A");

            entity.ToTable("Brand");

            entity.HasIndex(e => e.TenBr, "unique_tenbr").IsUnique();

            entity.Property(e => e.MaBr).HasColumnName("ma_Br");
            entity.Property(e => e.TenBr)
                .HasMaxLength(20)
                .HasColumnName("ten_Br");
        });

        modelBuilder.Entity<ChiTietDt>(entity =>
        {
            entity.HasKey(e => new { e.MaNv, e.MaCh, e.MaDt }).HasName("PK__ChiTietD__F517DA021BF80307");

            entity.ToTable("ChiTietDT");

            entity.Property(e => e.MaNv).HasColumnName("ma_NV");
            entity.Property(e => e.MaCh).HasColumnName("ma_CH");
            entity.Property(e => e.MaDt).HasColumnName("ma_DT");
            entity.Property(e => e.Chi).HasColumnName("chi");
            entity.Property(e => e.Thu).HasColumnName("thu");
            entity.Property(e => e.Tongtien).HasColumnName("tongtien");

            entity.HasOne(d => d.MaChNavigation).WithMany(p => p.ChiTietDts)
                .HasForeignKey(d => d.MaCh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ch_detail_dt");

            entity.HasOne(d => d.MaDtNavigation).WithMany(p => p.ChiTietDts)
                .HasForeignKey(d => d.MaDt)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_dt_detail_dt");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.ChiTietDts)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_nv_detail_dt");
        });

        modelBuilder.Entity<ChiTietHd>(entity =>
        {
            entity.HasKey(e => new { e.MaHd, e.MaSp, e.MaKh }).HasName("PK__ChiTietH__C81794011361C9C0");

            entity.ToTable("ChiTietHD");

            entity.Property(e => e.MaHd).HasColumnName("ma_HD");
            entity.Property(e => e.MaSp).HasColumnName("ma_SP");
            entity.Property(e => e.MaKh).HasColumnName("ma_KH");
            entity.Property(e => e.Soluong).HasColumnName("soluong");
            entity.Property(e => e.Thanhtien).HasColumnName("thanhtien");

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.ChiTietHds)
                .HasForeignKey(d => d.MaHd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_hd_detail");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.ChiTietHds)
                .HasForeignKey(d => d.MaKh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_kh_detail");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.ChiTietHds)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sp_detail");
        });

        modelBuilder.Entity<CuaHang>(entity =>
        {
            entity.HasKey(e => e.MaCh).HasName("PK__CuaHang__0FE672DCC21869E7");

            entity.ToTable("CuaHang");

            entity.HasIndex(e => e.Sdt, "unique_sdt_ch").IsUnique();

            entity.Property(e => e.MaCh).HasColumnName("ma_CH");
            entity.Property(e => e.Diachi)
                .HasMaxLength(100)
                .HasColumnName("diachi");
            entity.Property(e => e.MaQl).HasColumnName("ma_QL");
            entity.Property(e => e.Sdt).HasColumnName("sdt");
            entity.Property(e => e.TenCh)
                .HasMaxLength(50)
                .HasColumnName("ten_CH");

            entity.HasOne(d => d.MaQlNavigation).WithMany(p => p.CuaHangs)
                .HasForeignKey(d => d.MaQl)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ql_ch");
        });

        modelBuilder.Entity<DoanhThu>(entity =>
        {
            entity.HasKey(e => e.MaDt).HasName("PK__DoanhThu__0FE64B2BA1D837BA");

            entity.ToTable("DoanhThu");

            entity.Property(e => e.MaDt).HasColumnName("ma_DT");
            entity.Property(e => e.Thoigian)
                .HasColumnType("datetime")
                .HasColumnName("thoigian");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHd).HasName("PK__HoaDon__0FE66ABE3EB71203");

            entity.ToTable("HoaDon");

            entity.Property(e => e.MaHd).HasColumnName("ma_HD");
            entity.Property(e => e.Thoigian)
                .HasColumnType("datetime")
                .HasColumnName("thoigian");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK__KhachHan__0FE1B3D6B7A9CDD4");

            entity.ToTable("KhachHang");

            entity.HasIndex(e => e.Sdt, "unique_sdt_kh").IsUnique();

            entity.Property(e => e.MaKh).HasColumnName("ma_KH");
            entity.Property(e => e.Diachi)
                .HasMaxLength(100)
                .HasColumnName("diachi");
            entity.Property(e => e.Gioitinh)
                .HasMaxLength(3)
                .HasColumnName("gioitinh");
            entity.Property(e => e.Ngaysinh)
                .HasColumnType("datetime")
                .HasColumnName("ngaysinh");
            entity.Property(e => e.Sdt).HasColumnName("sdt");
            entity.Property(e => e.TenKh)
                .HasMaxLength(100)
                .HasColumnName("ten_KH");
        });

        modelBuilder.Entity<Kho>(entity =>
        {
            entity.HasKey(e => e.MaKho).HasName("PK__Kho__022D2F8A01FCD418");

            entity.ToTable("Kho");

            entity.Property(e => e.MaKho).HasColumnName("ma_Kho");
            entity.Property(e => e.Diachi)
                .HasMaxLength(100)
                .HasColumnName("diachi");
            entity.Property(e => e.MaCh).HasColumnName("ma_CH");

            entity.HasOne(d => d.MaChNavigation).WithMany(p => p.Khos)
                .HasForeignKey(d => d.MaCh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ch_kh");
        });

        modelBuilder.Entity<NhaCungCap>(entity =>
        {
            entity.HasKey(e => e.MaNcc).HasName("PK__NhaCungC__3C46EE97DA1A2162");

            entity.ToTable("NhaCungCap");

            entity.HasIndex(e => e.Sdt, "unique_sdt_ncc").IsUnique();

            entity.HasIndex(e => e.TenNcc, "unique_tenncc").IsUnique();

            entity.Property(e => e.MaNcc).HasColumnName("ma_NCC");
            entity.Property(e => e.Diachi)
                .HasMaxLength(100)
                .HasColumnName("diachi");
            entity.Property(e => e.Sdt).HasColumnName("sdt");
            entity.Property(e => e.TenNcc)
                .HasMaxLength(50)
                .HasColumnName("ten_NCC");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PK__NhanVien__0FE65B6458665499");

            entity.ToTable("NhanVien");

            entity.HasIndex(e => e.Sdt, "unique_sdt_nv").IsUnique();

            entity.Property(e => e.MaNv).HasColumnName("ma_NV");
            entity.Property(e => e.Diachi)
                .HasMaxLength(100)
                .HasColumnName("diachi");
            entity.Property(e => e.Gioitinh)
                .HasMaxLength(3)
                .HasColumnName("gioitinh");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MaCh).HasColumnName("ma_CH");
            entity.Property(e => e.Ngaysinh)
                .HasColumnType("datetime")
                .HasColumnName("ngaysinh");
            entity.Property(e => e.Sdt).HasColumnName("sdt");
            entity.Property(e => e.TenNv)
                .HasMaxLength(50)
                .HasColumnName("ten_NV");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tk_nv");

            entity.HasOne(d => d.MaChNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaCh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ck_nv");
        });

        modelBuilder.Entity<QuanLy>(entity =>
        {
            entity.HasKey(e => e.MaQl).HasName("PK__QuanLy__0FE1A39D836F1050");

            entity.ToTable("QuanLy");

            entity.HasIndex(e => e.Sdt, "unique_sdt_ql").IsUnique();

            entity.Property(e => e.MaQl).HasColumnName("ma_QL");
            entity.Property(e => e.Diachi)
                .HasMaxLength(100)
                .HasColumnName("diachi");
            entity.Property(e => e.Gioitinh)
                .HasMaxLength(3)
                .HasColumnName("gioitinh");
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ngaysinh)
                .HasColumnType("datetime")
                .HasColumnName("ngaysinh");
            entity.Property(e => e.Sdt).HasColumnName("sdt");
            entity.Property(e => e.TenQl)
                .HasMaxLength(50)
                .HasColumnName("ten_QL");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.QuanLies)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tk_ql");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSp).HasName("PK__SanPham__0FE1F0C01DFDC57A");

            entity.ToTable("SanPham");

            entity.Property(e => e.MaSp).HasColumnName("ma_SP");
            entity.Property(e => e.Chitiet)
                .HasMaxLength(500)
                .HasColumnName("chitiet");
            entity.Property(e => e.Gia).HasColumnName("gia");
            entity.Property(e => e.MaBr).HasColumnName("ma_Br");
            entity.Property(e => e.MaNcc).HasColumnName("ma_NCC");
            entity.Property(e => e.TenSp)
                .HasMaxLength(50)
                .HasColumnName("ten_SP");

            entity.HasOne(d => d.MaBrNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaBr)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_br_sp");

            entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaNcc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ncc_sp");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TaiKhoan__3213E83FECEBD36C");

            entity.ToTable("TaiKhoan");

            entity.HasIndex(e => e.Taikhoan1, "unique_taikhoan").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Matkhau)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("matkhau");
            entity.Property(e => e.Role)
                .HasMaxLength(10)
                .HasColumnName("role");
            entity.Property(e => e.Taikhoan1)
                .HasMaxLength(50)
                .HasColumnName("taikhoan");
        });

        modelBuilder.Entity<TonKho>(entity =>
        {
            entity.HasKey(e => new { e.MaKho, e.MaSp }).HasName("PK__TonKho__12D330861B13E234");

            entity.ToTable("TonKho");

            entity.Property(e => e.MaKho).HasColumnName("ma_Kho");
            entity.Property(e => e.MaSp).HasColumnName("ma_SP");
            entity.Property(e => e.Soluongtonkho).HasColumnName("soluongtonkho");

            entity.HasOne(d => d.MaKhoNavigation).WithMany(p => p.TonKhos)
                .HasForeignKey(d => d.MaKho)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_kh_tonkho");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.TonKhos)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_sp_tonkho");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
