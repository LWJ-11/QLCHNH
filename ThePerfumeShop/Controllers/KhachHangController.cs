using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] KhachHang model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    qlchnhContext.Database.ExecuteSqlRaw("sp_themkhachhang @p0, @p1, @p2, @p3, @p4", parameters: new object[] { model.TenKh, model.Ngaysinh, model.Gioitinh, model.Sdt, model.Diachi });
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
                                ModelState.AddModelError("TenKh", "Tên khách hàng cấp đã tồn tại");
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
            var q = qlchnhContext.KhachHangs.FromSqlRaw("exec sp_khachhangbyId {0}", id).AsEnumerable();
            return View(q);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind] KhachHang model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    qlchnhContext.Database.ExecuteSqlRaw("sp_suakh @p0, @p1, @p2, @p3, @p4, @p5", parameters: new object[] { model.MaKh, model.TenKh, model.Ngaysinh, model.Gioitinh, model.Sdt, model.Diachi });
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
                                ModelState.AddModelError("TenKh", "Tên khách hàng đã tồn tại");
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
                    IEnumerable<KhachHang> rModel = new[] { model };
                    return View(rModel);
                }
            }
            return View();
        }
    }
}
