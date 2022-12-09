using System;
using System.Collections.Generic;

namespace ThePerfumeShop.Models;

public partial class KhachHang
{
    public int MaKh { get; set; }

    public string? TenKh { get; set; }

    public DateTime? Ngaysinh { get; set; }

    public string? Gioitinh { get; set; }

    public int? Sdt { get; set; }

    public string? Diachi { get; set; }

    public int Id { get; set; }

    public virtual ICollection<ChiTietHd> ChiTietHds { get; } = new List<ChiTietHd>();

    public virtual TaiKhoan IdNavigation { get; set; } = null!;
}
