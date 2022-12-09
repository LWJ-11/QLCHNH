using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThePerfumeShop.Models;

namespace ThePerfumeShop.Controllers
{
    public class KhachHangController : Controller
    {
        private QlchnhContext qlchnhContext = new QlchnhContext();
        public IActionResult Index()
        {
            var q = qlchnhContext.KhachHangs.FromSql($"exec sp_danhsachkhachhang").ToList();
            return View(q);
        }
    }
}
