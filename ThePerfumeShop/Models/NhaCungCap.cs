using System;
using System.Collections.Generic;

namespace ThePerfumeShop.Models;

public partial class NhaCungCap
{
    public int MaNcc { get; set; }

    public string? TenNcc { get; set; }

    public int? Sdt { get; set; }

    public string? Diachi { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; } = new List<SanPham>();
}
