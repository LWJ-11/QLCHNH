using System;
using System.Collections.Generic;

namespace ThePerfumeShop.Models;

public partial class TonKho
{
    public int MaKho { get; set; }

    public int MaSp { get; set; }

    public int? Soluongtonkho { get; set; }

    public virtual Kho MaKhoNavigation { get; set; } = null!;

    public virtual SanPham MaSpNavigation { get; set; } = null!;
}
