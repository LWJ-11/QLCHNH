using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThePerfumeShop.Models;

namespace ThePerfumeShop.Controllers
{
    public class HoaDonController : Controller
    {
        private QlchnhContext qlchnhContext = new QlchnhContext();
        public IActionResult Index()
        {
            var q = qlchnhContext.HoaDons.FromSql($"exec sp_danhsachhoadon").ToList();
            return View(q);
        }
    }
}
