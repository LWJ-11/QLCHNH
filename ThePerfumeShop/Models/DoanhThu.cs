using System;
using System.Collections.Generic;

namespace ThePerfumeShop.Models;

public partial class DoanhThu
{
    public int MaDt { get; set; }

    public DateTime? Thoigian { get; set; }

    public virtual ICollection<ChiTietDt> ChiTietDts { get; } = new List<ChiTietDt>();
}
