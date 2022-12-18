using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ThePerfumeShop.Models;
using ThePerfumeShop.Models.DataView;

namespace ThePerfumeShop.Controllers
{
    public class CuaHangController : Controller
    {
        private QlchnhContext qlchnhContext = new QlchnhContext();
        public IActionResult Index()
        {
            var q = qlchnhContext.DanhSachCuaHang.FromSql($"exec sp_danhsachcuahang").ToList();
            return View(q);
        }
        public IActionResult Create()
        {
            ViewBag.QuanLy = new SelectList(qlchnhContext.DanhSachQuanLyChuaDuocPhanCong.FromSql($"exec sp_danhsachquanlyphancongcuahang"), "MaQl", "Sdt");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] ThemCuaHang model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    qlchnhContext.Database.ExecuteSqlRaw("sp_themcuahang @p0, @p1, @p2, @p3", parameters: new object[] { model.TenCh, model.Sdt, model.Diachi, model.MaQl });
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
                    return View(model);
                }
            }
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            ViewBag.QuanLy = new SelectList(qlchnhContext.DanhSachQuanLyChuaDuocPhanCong.FromSql($"exec sp_danhsachquanlyhientaiphancongcuahang {id}"), "MaQl", "Sdt");
            var q = qlchnhContext.CapNhatCuaHang.FromSqlRaw("exec sp_cuahangbyId {0}", id).AsEnumerable();
            return View(q);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind] CapNhatCuaHang model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    qlchnhContext.Database.ExecuteSqlRaw("sp_suacuahang @p0, @p1, @p2, @p3, @p4", parameters: new object[] { model.MaCh, model.TenCh, model.Sdt, model.Diachi, model.MaQl });
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
                    IEnumerable<CapNhatCuaHang> rModel = new[] { model };
                    return View(rModel);
                }
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            var q = qlchnhContext.XoaCuaHang.FromSqlRaw("exec sp_cuahangbyId {0}", id).AsEnumerable();
            return View(q);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([Bind] XoaCuaHang model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    qlchnhContext.Database.ExecuteSqlRaw("sp_xoacuahang @p0", model.MaCh);
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
                        case 547:   // Constraint check violation
                            ModelState.AddModelError("Diachi", "Không thể xóa cửa hàng vì cửa hàng vẫn còn nhân viên!");
                            break;
                        default:
                            break;
                    }
                    IEnumerable<XoaCuaHang> rModel = new[] { model };
                    return View(rModel);
                }
            }
            return View();
        }
        public IActionResult DanhSachNhanVien(int id)
        {
            var q = qlchnhContext.DanhSachNhanVien.FromSqlRaw("exec sp_danhsachnhanvien {0}", id).ToList();
            if(q.Count == 0)
            {
                return RedirectToAction("Create", "NhanVien", new { id = id });
            }
            return View(q);
        }
    }
}
