---truy vấn từ một bảng
--01/12/2022
--Phạm Huỳnh Duy Kha
--lấy thông tin bảng brand
select * from Brand
--lấy thông tin bảng Cửa hàng
select * from CuaHang
--lấy thông tin bảng Doanh thu
select * from DoanhThu
--lấy thông tin bảng Hóa đơn
select * from HoaDon
--lấy thông tin bảng khách hàng
select * from KhachHang
--lấy thông tin bảng Kho
select * from Kho
--lấy thông tin bảng Nhà cung cấp
select * from NhaCungCap
--lấy thông tin bảng Nhân viên
select * from NhanVien
--lấy thông tin bảng Quản lý
select * from QuanLy
--lấy thông tin bảng Sản phẩm
select * from SanPham

---truy vấn từ nhiều bảng
----Phạm Huỳnh Duy Kha
---01/12/2022
--lấy thông tin nhân viên và tài khoản
select tk.id, tk.taikhoan , nv.ma_NV ,nv.ten_NV ,nv.ngaysinh , nv.gioitinh , nv.sdt , nv.diachi 
from TaiKhoan tk,NhanVien nv where tk.id = nv.id
----Phạm Huỳnh Duy Kha
---01/12/2022
--lấy thông tin quản lý và tài khoản
select tk.id , tk.taikhoan , ql.ma_QL,ql.ten_QL ,ql.ngaysinh, ql.gioitinh, ql.sdt, ql.diachi 
from TaiKhoan tk,QuanLy ql where tk.id = ql.id
----Phạm Huỳnh Duy Kha
---01/12/2022
--lấy thông tin cửa hàng
select ch.ma_CH,ch.ten_CH,ql.ten_QL,ch.sdt,ch.diachi 
from CuaHang ch,QuanLy ql where ch.ma_QL=ql.ma_QL
----Phạm Huỳnh Duy Kha
---01/12/2022
--lấy thông tin sản phẩm
select sp.ma_SP,sp.ten_SP,sp.gia,Brand.ten_Br,NhaCungCap.ten_NCC,sp.chitiet 
from SanPham sp,Brand,NhaCungCap 
where sp.ma_Br=Brand.ma_Br and sp.ma_NCC=NhaCungCap.ma_NCC
----Phạm Huỳnh Duy Kha
---01/12/2022
--lấy thông tin kho
select k.ma_Kho, ch.ten_CH , k.diachi, sp.ma_SP, tk.soluongtonkho
from Kho k, TonKho tk, CuaHang ch, SanPham sp
where ch.ma_CH=k.ma_CH and k.ma_Kho=tk.ma_Kho and tk.ma_SP=sp.ma_SP

----Lê Quang Duy
---01/12/2022
--lấy thông tin hóa đơn
select hd.*, kh.ten_KH, sp.ten_SP,ct.soluong, ct.thanhtien
from HoaDon hd, ChiTietHD ct, KhachHang kh, SanPham sp
where hd.ma_HD=ct.ma_HD and ct.ma_KH=kh.ma_KH and ct.ma_SP=sp.ma_SP
----Lê Quang Duy
---01/12/2022
--lấy thông tin doanh thu
select dt.*, ch.ten_CH, Nv.ten_NV, ct.chi, ct.thu, ct.tongtien
from DoanhThu dt, ChiTietDT ct, CuaHang ch, NhanVien nv
where dt.ma_DT=ct.ma_DT and ct.ma_CH = ch.ma_CH and ct.ma_NV = nv.ma_NV
----Lê Quang Duy
---01/12/2022
--lấy thông tin nhân viên của một cửa hàng
select ch.ma_CH, ch.ten_CH, nv.ma_NV, nv.ten_NV, nv.ngaysinh, nv.gioitinh, nv.sdt, nv.diachi
from CuaHang ch, NhanVien nv
where ch.ma_CH=nv.ma_CH
----Lê Quang Duy
---01/12/2022
--lấy sản phẩm của một brand
select br.ma_Br, br.ten_Br, sp.ma_SP, sp.ten_SP
from SanPham sp, Brand br
where sp.ma_Br = br.ma_Br
----Lê Quang Duy
---01/12/2022
--lấy sản phẩm từ một nhà cung cấp
select ncc.ma_NCC, ncc.ten_NCC, sp.ma_SP, sp.ten_SP
from SanPham sp, NhaCungCap ncc
where sp.ma_NCC=ncc.ma_NCC
