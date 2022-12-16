---Tạo view
----Phạm Huỳnh Duy Kha
---01/12/2022
--lấy thông tin sản phẩm
select sp.ma_SP as 'Mã sản phẩm',sp.ten_SP as 'Tên sản phẩm',Brand.ten_Br as 'Brand',
NhaCungCap.ten_NCC as 'Nhà cung cấp',sp.gia as 'giá', sp.chitiet as 'Chi tiết sản phẩm'
from SanPham sp,Brand,NhaCungCap 
where sp.ma_Br=Brand.ma_Br and sp.ma_NCC=NhaCungCap.ma_NCC
----Phạm Huỳnh Duy Kha
---01/12/2022
--lấy thông tin kho
select k.ma_Kho as 'Mã kho', ch.ten_CH as 'Tên cửa hàng', k.diachi as 'Địa chỉ', 
sp.ten_SP as 'Tên sản phẩm', tk.soluongtonkho as 'Số lượng tồn kho'
from Kho k, TonKho tk, CuaHang ch, SanPham sp
where ch.ma_CH=k.ma_CH and k.ma_Kho=tk.ma_Kho and tk.ma_SP=sp.ma_SP
----Phạm Huỳnh Duy Kha
---01/12/2022
--lấy thông tin hóa đơn
select hd.ma_HD as 'Mã hóa đơn', hd.thoigian as 'Thời gian', kh.ten_KH as 'Tên khách hàng', 
sp.ten_SP as 'Tên sản phẩm',ct.soluong as 'Số lượng', ct.thanhtien as 'Thành tiền'
from HoaDon hd, ChiTietHD ct, KhachHang kh, SanPham sp
where hd.ma_HD=ct.ma_HD and ct.ma_KH=kh.ma_KH and ct.ma_SP=sp.ma_SP
----Phạm Huỳnh Duy Kha
---01/12/2022
--lấy thông tin doanh thu
select dt.ma_DT as 'Mã doanh thu',dt.thoigian as 'Thời gian', ch.ten_CH as 'Tên cửa hàng', 
Nv.ten_NV as 'Tên nhân vật', ct.chi as 'Số tiền chi', ct.thu as 'Số tiền thu', ct.tongtien as 'Tổng tiền'
from DoanhThu dt, ChiTietDT ct, CuaHang ch, NhanVien nv
where dt.ma_DT=ct.ma_DT and ct.ma_CH = ch.ma_CH and ct.ma_NV = nv.ma_NV
----Phạm Huỳnh Duy Kha
---01/12/2022
--lấy thông tin nhân viên của một cửa hàng
select ch.ma_CH as 'Mã cửa hàng', ch.ten_CH as 'Tên cửa hàng', nv.ma_NV as 'Mã nhân viên', 
nv.ten_NV as 'Tên nhân viên', nv.ngaysinh as 'Ngày sinh', nv.gioitinh as 'Giới tính', 
nv.sdt as 'Số điện thoại', nv.diachi as 'Địa chỉ'
from CuaHang ch, NhanVien nv
where ch.ma_CH=nv.ma_CH
----Lê Quang Duy
---01/12/2022
--lấy sản phẩm của một brand
select br.ma_Br as 'Mã brand', br.ten_Br as 'Tên brand', 
sp.ma_SP as 'Mã sản phẩm', sp.ten_SP as 'Tên sản phẩm'
from SanPham sp, Brand br
where sp.ma_Br = br.ma_Br
----Lê Quang Duy
---01/12/2022
--lấy sản phẩm từ một nhà cung cấp
select ncc.ma_NCC as 'Mã nhà cung cấp', ncc.ten_NCC as 'Tên nhà cung cấp', 
sp.ma_SP as 'Mã sản phẩm', sp.ten_SP as 'Tên sản phẩm'
from SanPham sp, NhaCungCap ncc
where sp.ma_NCC=ncc.ma_NCC
----Lê Quang Duy
---01/12/2022
--lấy thông tin nhân viên và tài khoản
select tk.id as 'ID tài khoản', tk.taikhoan as 'Tài khoản', nv.ma_NV as 'Mã nhân viên',
nv.ten_NV as 'Tên nhân viên',nv.ngaysinh as 'Ngày sinh', nv.gioitinh as 'Giới tính', 
nv.sdt as 'Số điện thoại', nv.diachi as 'Địa chỉ'
from TaiKhoan tk,NhanVien nv where tk.id = nv.id
----Lê Quang Duy
---01/12/2022
--lấy thông tin quản lý và tài khoản
select tk.id as 'ID tài khoản', tk.taikhoan as 'Tài khoản', ql.ma_QL as 'Mã quản lý',
ql.ten_QL as 'Tên quản lý',ql.ngaysinh as 'Ngày sinh', ql.gioitinh as 'Giới tính', 
ql.sdt as 'Số điện thoại', ql.diachi as 'Địa chỉ'
from TaiKhoan tk,QuanLy ql where tk.id = ql.id
----Lê Quang Duy
---01/12/2022
--lấy thông tin cửa hàng
select ch.ma_CH as 'Mã cửa hàng',ch.ten_CH as 'Tên cửa hàng',ql.ten_QL as 'Tên quản lý',
ch.sdt as 'Số điện thoại',ch.diachi as 'Địa chỉ' 
from CuaHang ch,QuanLy ql where ch.ma_QL=ql.ma_QL