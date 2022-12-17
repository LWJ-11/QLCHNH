using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ThePerfumeShop.Models;
using ThePerfumeShop.Models.DataView;

namespace ThePerfumeShop.Controllers
{
    public class SanPhamController : Controller
    {
        private QlchnhContext qlchnhContext = new QlchnhContext();
        public IActionResult Index()
        {
            var q = qlchnhContext.DanhSachSanPham.FromSql($"exec sp_danhsachsanpham").ToList();
            return View(q);
        }
        public IActionResult Create() 
        {

            ViewBag.Brand = new SelectList(qlchnhContext.Brands.ToList(), "MaBr", "TenBr");
            ViewBag.Ncc = new SelectList(qlchnhContext.NhaCungCaps.ToList(), "MaNcc", "TenNcc");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] ThemSanPham model)
        {
            if (ModelState.IsValid)
            {
                qlchnhContext.Database.ExecuteSqlRaw("sp_themsanpham @p0, @p1, @p2, @p3, @p4", parameters: new object[] { model.TenSp, model.Gia, model.Chitiet, model.MaNcc, model.MaBr });
                return RedirectToAction("Index", "SanPham");
            }
            return View(model);
        }
    }
}
