using System;
using System.Collections.Generic;

namespace ThePerfumeShop.Models;

public partial class Brand
{
    public int MaBr { get; set; }

    public string? TenBr { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; } = new List<SanPham>();
}
