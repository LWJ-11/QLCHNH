using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThePerfumeShop.Models;

namespace ThePerfumeShop.Controllers
{
    public class NhaCungCapController : Controller
    {
        private QlchnhContext qlchnhContext = new QlchnhContext();
        public IActionResult Index()
        {
            var q = qlchnhContext.NhaCungCaps.FromSql($"exec sp_danhsachncc").ToList();
            return View(q);
        }
    }
}
