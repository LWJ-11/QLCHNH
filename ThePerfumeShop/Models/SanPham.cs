using System;
using System.Collections.Generic;

namespace ThePerfumeShop.Models;

public partial class SanPham
{
    public int MaSp { get; set; }

    public string? TenSp { get; set; }

    public double? Gia { get; set; }

    public string? Chitiet { get; set; }

    public int MaNcc { get; set; }

    public int MaBr { get; set; }

    public virtual ICollection<ChiTietHd> ChiTietHds { get; } = new List<ChiTietHd>();

    public virtual Brand MaBrNavigation { get; set; } = null!;

    public virtual NhaCungCap MaNccNavigation { get; set; } = null!;

    public virtual ICollection<TonKho> TonKhos { get; } = new List<TonKho>();
}
