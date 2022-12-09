using System;
using System.Collections.Generic;

namespace ThePerfumeShop.Models;

public partial class TaiKhoan
{
    public int Id { get; set; }

    public string? Taikhoan1 { get; set; }

    public string? Matkhau { get; set; }

    public string? Roll { get; set; }

    public virtual ICollection<KhachHang> KhachHangs { get; } = new List<KhachHang>();

    public virtual ICollection<NhanVien> NhanViens { get; } = new List<NhanVien>();

    public virtual ICollection<QuanLy> QuanLies { get; } = new List<QuanLy>();
}
