using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ThePerfumeShop.Models;
using ThePerfumeShop.Models.DataView;

namespace ThePerfumeShop.Controllers
{
    public class NhanVienController : Controller
    {
        private QlchnhContext qlchnhContext = new QlchnhContext();
       
        public IActionResult Create(int id)
        {
            ViewBag.MaCH = id;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] ThemNhanVien model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    qlchnhContext.Database.ExecuteSqlRaw("sp_themnhanvien @p0, @p1, @p2, @p3, @p4, @p5, @p6, @p7", parameters: new object[] { model.TenDN, model.Matkhau, model.TenNv, model.Ngaysinh, model.Gioitinh, model.Sdt, model.Diachi, model.MaCh });
                    return RedirectToAction("DanhSachNhanVien","CuaHang");
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
                        case 15151:
                            return RedirectToAction("DanhSachNhanVien", "CuaHang", new { id = model.MaCh });
                            break;
                        //case 2601:  // Duplicated key row error
                        //    ModelState.AddModelError("DiaChi", "Constraint check violation");
                        //    break;
                        default:
                            break;
                    }
                    IEnumerable<ThemNhanVien> erModel = new[] { model };
                    return View(erModel);
                }
            }
            IEnumerable<ThemNhanVien> rModel = new[] { model };
            return View(rModel);
        }
        public IActionResult Delete(int id)
        {
            var q = qlchnhContext.ThemNhanVien  .FromSqlRaw("exec sp_nhacungcapById {0}", id).AsEnumerable();
            return View(q);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete([Bind] NhaCungCap model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    qlchnhContext.Database.ExecuteSqlRaw("sp_xoancc @p0", model.MaNcc);
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
                            ModelState.AddModelError("Diachi", "Vui lòng gỡ sản phẩm của nhà cung cấp này trước khi xóa!");
                            break;
                        default:
                            break;
                    }
                    IEnumerable<NhaCungCap> rModel = new[] { model };
                    return View(rModel);
                }
            }
            return View();
        }
    }
}
