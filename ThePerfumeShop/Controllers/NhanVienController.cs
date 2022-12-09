using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThePerfumeShop.Models;

namespace ThePerfumeShop.Controllers
{
    public class NhanVienController : Controller
    {
        private QlchnhContext qlchnhContext = new QlchnhContext();
        public IActionResult Index()
        {
            var q = qlchnhContext.NhanViens.FromSql($"exec sp_danhsachnhanvien").ToList();
            return View(q);
        }
    }
}
