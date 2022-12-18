using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ThePerfumeShop.Models;
using ThePerfumeShop.Models.DataView;

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
            ViewBag.CuaHang = new SelectList(qlchnhContext.CuaHangs.ToList(), "MaCh", "TenCh");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] ThemKho model)
        {
                if (ModelState.IsValid)
                {
                    qlchnhContext.Database.ExecuteSqlRaw("sp_themkho @p0, @p1", parameters: new object[] { model.Diachi, model.MaCh });
                    return RedirectToAction("Index");
                }
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            var q = qlchnhContext.SuaKho.FromSqlRaw("exec sp_khobangId {0}", id).AsEnumerable();
            ViewBag.CuaHang = new SelectList(qlchnhContext.CuaHangs.ToList(), "MaCh", "TenCh");
            return View(q);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind] SuaKho model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    qlchnhContext.Database.ExecuteSqlRaw("sp_suakho @p0, @p1, @p2", parameters: new object[] { model.MaKho, model.Diachi, model.MaCh});
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                if (ex.GetBaseException().GetType() == typeof(SqlException))
                {
                    Int32 ErrorCode = ((SqlException)ex).Number;
                    switch (ErrorCode)
                    {
                        case 2627:  // Unique constraint error
                            if (ex.Message.Contains("unique_tenncc"))
                                ModelState.AddModelError("TenNcc", "Tên nhà cung cấp đã tồn tại");
                            else if (ex.Message.Contains("unique_sdt_ncc"))
                                ModelState.AddModelError("Sdt", "Số điện thoại đã tồn tại");
                            break;
                        //case 547:   // Constraint check violation
                        //    ModelState.AddModelError("Sdt", "Số điện thoại đã tồn tại");
                        //    break;
                        //case 2601:  // Duplicated key row error
                        //    ModelState.AddModelError("DiaChi", "Constraint check violation");
                        //    break;
                        default:
                            break;
                    }
                    IEnumerable<SuaKho> rModel = new[] { model };
                    return View(rModel);
                }
            }
            return View();
        }
        public IActionResult DanhSachTonKho(int id)
        {
            var q = qlchnhContext.DanhSachTonKho.FromSqlRaw("exec sp_danhsachtonkho {0}", id).ToList();
            if (q.Count == 0)
            {
                return RedirectToAction("Create", "TonKho", new { id = id });
            }
            return View(q);
        }
    }
}
