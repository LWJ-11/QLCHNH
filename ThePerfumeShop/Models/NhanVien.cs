using System;
using System.Collections.Generic;

namespace ThePerfumeShop.Models;

public partial class NhanVien
{
    public int MaNv { get; set; }

    public string? TenNv { get; set; }

    public DateTime? Ngaysinh { get; set; }

    public string? Gioitinh { get; set; }

    public int? Sdt { get; set; }

    public string? Diachi { get; set; }

    public int MaCh { get; set; }

    public int Id { get; set; }

    public virtual ICollection<ChiTietDt> ChiTietDts { get; } = new List<ChiTietDt>();

    public virtual TaiKhoan IdNavigation { get; set; } = null!;

    public virtual CuaHang MaChNavigation { get; set; } = null!;
}
