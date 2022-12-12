using System;
using System.Collections.Generic;

namespace ThePerfumeShop.Models;

public partial class ChiTietDt
{
    public int MaNv { get; set; }

    public int MaCh { get; set; }

    public double? Chi { get; set; }

    public double? Thu { get; set; }

    public double? Tongtien { get; set; }

    public int MaDt { get; set; }

    public virtual CuaHang MaChNavigation { get; set; } = null!;

    public virtual DoanhThu MaDtNavigation { get; set; } = null!;

    public virtual NhanVien MaNvNavigation { get; set; } = null!;
}
