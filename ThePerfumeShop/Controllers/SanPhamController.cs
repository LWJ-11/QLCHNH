using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThePerfumeShop.Models;

namespace ThePerfumeShop.Controllers
{
    public class SanPhamController : Controller
    {
        private QlchnhContext qlchnhContext = new QlchnhContext();
        public IActionResult Index()
        {
            var q = qlchnhContext.SanPhams.FromSql($"exec sp_danhsachsanpham").ToList();
            return View(q);
        }
    }
}
