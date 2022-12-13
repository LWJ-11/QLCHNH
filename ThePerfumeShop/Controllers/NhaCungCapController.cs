using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.RegularExpressions;
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
            try
            {
                if (ModelState.IsValid)
                {
                    qlchnhContext.Database.ExecuteSqlRaw("sp_themncc @p0, @p1, @p2", parameters: new object[] { model.TenNcc, model.Sdt, model.Diachi });
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
            var q = qlchnhContext.NhaCungCaps.FromSqlRaw("exec sp_nhacungcapById {0}", id).AsEnumerable();
            return View(q);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind] NhaCungCap model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    qlchnhContext.Database.ExecuteSqlRaw("sp_suancc @p0, @p1, @p2, @p3", parameters: new object[] { model.MaNcc, model.TenNcc, model.Sdt, model.Diachi });
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
                    IEnumerable<NhaCungCap> rModel = new[] { model };
                    return View(rModel);
                }
            }
            return View(model as IEnumerable<NhaCungCap>);

        }
    }
}
