using System;
using System.Collections.Generic;

namespace ThePerfumeShop.Models;

public partial class HoaDon
{
    public int MaHd { get; set; }

    public DateTime? Thoigian { get; set; }

    public virtual ICollection<ChiTietDt> ChiTietDts { get; } = new List<ChiTietDt>();

    public virtual ICollection<ChiTietHd> ChiTietHds { get; } = new List<ChiTietHd>();
}
