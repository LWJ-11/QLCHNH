using System;
using System.Collections.Generic;

namespace ThePerfumeShop.Models;

public partial class ChiTietHd
{
    public int MaHd { get; set; }

    public int MaSp { get; set; }

    public int MaKh { get; set; }

    public int? Soluong { get; set; }

    public double? Thanhtien { get; set; }

    public virtual HoaDon MaHdNavigation { get; set; } = null!;

    public virtual KhachHang MaKhNavigation { get; set; } = null!;

    public virtual SanPham MaSpNavigation { get; set; } = null!;
}
