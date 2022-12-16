using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThePerfumeShop.Models;

namespace ThePerfumeShop.Controllers
{
    public class CuaHangController : Controller
    {
        private QlchnhContext qlchnhContext = new QlchnhContext();
        public IActionResult Index()
        {
            var q = qlchnhContext.CuaHangs.FromSql($"exec sp_danhsachcuahang").ToList();
            return View(q);
        }
        public IActionResult DanhSachNhanVien(int id)
        {
            var q = qlchnhContext.DanhSachNhanVien.FromSqlRaw("exec sp_danhsachnhanvien {0}", id).ToList();
            return View(q);
        }
    }
}
