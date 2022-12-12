using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThePerfumeShop.Models;

namespace ThePerfumeShop.Controllers
{
    public class KhoController : Controller
    {
        private QlchnhContext qlchnhContext = new QlchnhContext();
        public IActionResult Index()
        {
            var q = qlchnhContext.DanhSachKho.FromSql($"exec sp_danhsachkho").ToList();
            return View(q);
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
