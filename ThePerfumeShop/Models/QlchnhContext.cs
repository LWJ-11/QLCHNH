using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-ETCHBCG;Initial Catalog=QLCHNH;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.MaBr).HasName("PK__Brand__0FE67ACB2F8A4E03");

            entity.ToTable("Brand");

            entity.Property(e => e.MaBr).HasColumnName("ma_Br");
            entity.Property(e => e.TenBr)
                .HasMaxLength(20)
                .HasColumnName("ten_Br");
        });

        modelBuilder.Entity<ChiTietDt>(entity =>
        {
            entity.HasKey(e => new { e.MaNv, e.MaCh, e.MaDt }).HasName("PK__ChiTietD__F517DA02877AF029");

            entity.ToTable("ChiTietDT");

            entity.Property(e => e.MaNv).HasColumnName("ma_NV");
            entity.Property(e => e.MaCh).HasColumnName("ma_CH");
            entity.Property(e => e.MaDt).HasColumnName("ma_DT");
            entity.Property(e => e.Chi).HasColumnName("chi");
            entity.Property(e => e.MaHd).HasColumnName("ma_HD");
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

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.ChiTietDts)
                .HasForeignKey(d => d.MaHd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_hd_detail_dt");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.ChiTietDts)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_nv_detail_dt");
        });

        modelBuilder.Entity<ChiTietHd>(entity =>
        {
            entity.HasKey(e => new { e.MaHd, e.MaSp, e.MaKh }).HasName("PK__ChiTietH__C8179401E96C5C90");

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
            entity.HasKey(e => e.MaCh).HasName("PK__CuaHang__0FE672DC6F4B56E3");

            entity.ToTable("CuaHang");

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
            entity.HasKey(e => e.MaDt).HasName("PK__DoanhThu__0FE64B2BD9D2A4D9");

            entity.ToTable("DoanhThu");

            entity.Property(e => e.MaDt).HasColumnName("ma_DT");
            entity.Property(e => e.Thoigian)
                .HasColumnType("datetime")
                .HasColumnName("thoigian");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHd).HasName("PK__HoaDon__0FE66ABEF8B1829E");

            entity.ToTable("HoaDon");

            entity.Property(e => e.MaHd).HasColumnName("ma_HD");
            entity.Property(e => e.Thoigian)
                .HasColumnType("datetime")
                .HasColumnName("thoigian");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK__KhachHan__0FE1B3D6BF3CCDE7");

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKh).HasColumnName("ma_KH");
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
            entity.Property(e => e.TenKh)
                .HasMaxLength(100)
                .HasColumnName("ten_KH");

            entity.HasOne(d => d.IdNavigation).WithMany(p => p.KhachHangs)
                .HasForeignKey(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tk_kh");
        });

        modelBuilder.Entity<Kho>(entity =>
        {
            entity.HasKey(e => e.MaKho).HasName("PK__Kho__022D2F8A9AC8FC73");

            entity.ToTable("Kho");

            entity.Property(e => e.MaKho).HasColumnName("ma_Kho");
            entity.Property(e => e.Diachi)
                .HasMaxLength(100)
                .HasColumnName("diachi");
            entity.Property(e => e.MaCh).HasColumnName("ma_CH");
            entity.Property(e => e.Soluong).HasColumnName("soluong");

            entity.HasOne(d => d.MaChNavigation).WithMany(p => p.Khos)
                .HasForeignKey(d => d.MaCh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ch_kh");
        });

        modelBuilder.Entity<NhaCungCap>(entity =>
        {
            entity.HasKey(e => e.MaNcc).HasName("PK__NhaCungC__3C46EE9775BB1F14");

            entity.ToTable("NhaCungCap");

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
            entity.HasKey(e => e.MaNv).HasName("PK__NhanVien__0FE65B6457BD68E0");

            entity.ToTable("NhanVien");

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
            entity.HasKey(e => e.MaQl).HasName("PK__QuanLy__0FE1A39D43189D77");

            entity.ToTable("QuanLy");

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
            entity.HasKey(e => e.MaSp).HasName("PK__SanPham__0FE1F0C0C2929F95");

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
            entity.HasKey(e => e.Id).HasName("PK__TaiKhoan__3213E83F85515C3B");

            entity.ToTable("TaiKhoan");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Matkhau)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("matkhau");
            entity.Property(e => e.Roll)
                .HasMaxLength(10)
                .HasColumnName("roll");
            entity.Property(e => e.Taikhoan1)
                .HasMaxLength(50)
                .HasColumnName("taikhoan");
        });

        modelBuilder.Entity<TonKho>(entity =>
        {
            entity.HasKey(e => new { e.MaKho, e.MaSp }).HasName("PK__TonKho__12D330861043C8E5");

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
