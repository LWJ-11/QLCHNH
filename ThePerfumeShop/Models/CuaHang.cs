using System;
using System.Collections.Generic;

namespace ThePerfumeShop.Models;

public partial class CuaHang
{
    public int MaCh { get; set; }

    public string? TenCh { get; set; }

    public int? Sdt { get; set; }

    public string? Diachi { get; set; }

    public int MaQl { get; set; }

    public virtual ICollection<ChiTietDt> ChiTietDts { get; } = new List<ChiTietDt>();

    public virtual ICollection<Kho> Khos { get; } = new List<Kho>();

    public virtual QuanLy MaQlNavigation { get; set; } = null!;

    public virtual ICollection<NhanVien> NhanViens { get; } = new List<NhanVien>();
}
