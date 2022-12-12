using System;
using System.Collections.Generic;

namespace ThePerfumeShop.Models;

public partial class Kho
{
    public int MaKho { get; set; }

    public string? Diachi { get; set; }

    public int MaCh { get; set; }

    public virtual CuaHang MaChNavigation { get; set; } = null!;

    public virtual ICollection<TonKho> TonKhos { get; } = new List<TonKho>();
}
