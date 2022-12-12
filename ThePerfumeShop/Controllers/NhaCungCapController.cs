using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] NhaCungCap model)
        {
            if(ModelState.IsValid) {
                qlchnhContext.Database.ExecuteSqlRaw("sp_themncc @p0, @p1, @p2", parameters: new object[] { model.TenNcc, model.Sdt, model.Diachi});
                return RedirectToAction("Index");
            }
            return View(model);
            
        }
    }
}
