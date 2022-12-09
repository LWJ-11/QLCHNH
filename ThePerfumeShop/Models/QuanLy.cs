using System;
using System.Collections.Generic;

namespace ThePerfumeShop.Models;

public partial class QuanLy
{
    public int MaQl { get; set; }

    public string? TenQl { get; set; }

    public DateTime? Ngaysinh { get; set; }

    public string? Gioitinh { get; set; }

    public int? Sdt { get; set; }

    public string? Diachi { get; set; }

    public int Id { get; set; }

    public virtual ICollection<CuaHang> CuaHangs { get; } = new List<CuaHang>();

    public virtual TaiKhoan IdNavigation { get; set; } = null!;
}
