----- Phạm Huỳnh Duy Kha
----01/12/2022
--- lấy danh sách nhân viên
create proc sp_danhsachnhanvien
as
begin
	select nv.ma_NV, nv.ten_NV, nv.ngaysinh, nv.gioitinh, nv.sdt, nv.diachi, ch.ma_CH, ch.ten_CH from NhanVien nv, CuaHang ch
	where nv.ma_CH = @maCH
	and ch.ma_CH = @maCH
end
------ Lê Quang Duy
----- 01/12/2022
-----Tìm nhân viên băng Id
create proc sp_nhanvienbyId @maNV int
as
begin
	select nv.ma_NV, nv.ten_NV, nv.ngaysinh, nv.gioitinh, nv.sdt, nv.diachi, ch.ma_CH, ch.ten_CH from NhanVien nv, TaiKhoan tk
	where nv.ma_CH = @maCH
	and ch.ma_CH = @maCH
end
----- Phạm Huỳnh Duy Kha
----01/12/2022
--- Lấy danh sách khách hàng
create proc sp_danhsachkhachhang
as
begin
	select * from KhachHang
end
------ Lê Quang Duy
----- 01/12/2022
--Lấy danh sách cửa hàng
create proc sp_danhsachcuahang
as
begin
	select *  from CuaHang
end
------ Lê Quang Duy
----- 01/12/2022
--Tìm cửa hàng băng Id
create proc sp_cuahangbyId
@maCH int
as
begin
	select *  from CuaHang ch
	where ma_CH = @maCH
end

----- Phạm Huỳnh Duy Kha
----01/12/2022
--- Lấy danh sách Kho
create proc sp_danhsachkho
as
begin
	select k.ma_Kho, k.diachi, ch.ten_CH from Kho k, CuaHang ch
	where k.ma_CH = ch.ma_CH
end
----- Phạm Huỳnh Duy Kha
----01/12/2022
--- Lấy danh sách nhà cung cấp
create proc sp_danhsachncc
as
begin
	select * from NhaCungCap
end
----- Lê Quang Duy
----01/12/2022
--- Lấy thông tin nhà cung cấp với mã nhà cung cấp
create proc sp_nhacungcapById
@maNcc int
as
begin
	select * from NhaCungCap
	where ma_NCC = @maNcc
end
----- Lê Quang Duy
----01/12/2022
--- Lấy danh sách sản phẩm
create proc sp_danhsachsanpham
as
begin
    select sp.ma_SP,ten_SP, sp.gia, sp.chitiet, br.ten_Br ,ncc.ten_NCC
    from SanPham sp, NhaCungCap ncc, Brand br
    where sp.ma_Br = br.ma_Br
    and sp.ma_NCC = ncc.ma_NCC
end
----- Lê Quang Duy
----01/12/2022
--- Lấy danh sách hóa đơn
alter proc sp_danhsachhoadon
as
begin
	select hd.ma_HD, kh.ten_KH, hd.thoigian, cthd.thanhtien
	from HoaDon hd, ChiTietHD cthd, KhachHang kh, SanPham sp
	where hd.ma_HD=cthd.ma_HD
	and cthd.ma_SP = sp.ma_SP
	and cthd.ma_KH = kh.ma_KH
end
----- Lê Quang Duy
----01/12/2022
--- Lấy thông tin sản phẩm
create proc sp_thongtinsanpham @maSP int
as
begin
	select sp.ma_SP, sp.ten_SP, sp.gia, sp.chitiet, br.ten_Br
	from SanPham sp, NhaCungCap ncc, Brand br
	where sp.ma_Br = br.ma_Br
	and sp.ma_SP = @maSP
end
----- Lê Quang Duy
----01/12/2022
-----lấy hóa đơn và chi tiết hóa đơn
create proc sp_thongtinhoadon @maHD int
as
begin
	select hd.ma_HD, kh.ten_KH, hd.thoigian, sp.gia, cthd.soluong, cthd.thanhtien
	from HoaDon hd, ChiTietHD cthd, KhachHang kh, SanPham sp
	where hd.ma_HD=@maHD
	and hd.ma_HD=cthd.ma_HD
	and cthd.ma_SP = sp.ma_SP
	and cthd.ma_KH = kh.ma_KH
end
----- Phạm Huỳnh Duy Kha
----01/12/2022
--Xem danh sách sản phẩm tồn kho
create proc sp_danhsachsanphamtonkho @maKho int
as
begin
	select sp.ma_SP, sp.ten_SP, sp.gia, tk.soluongtonkho from Kho k, SanPham sp, TonKho tk
	where tk.ma_SP = sp.ma_SP
	and tk.ma_Kho = k.ma_Kho
	and tk.ma_Kho = @maKho
----- Phạm Huỳnh Duy Kha
----01/12/2022
-- lấy quản lý
create proc sp_danhsachquanly
as begin
	select * from QuanLy
end
----- Phạm Huỳnh Duy Kha
----01/12/2022
-- lấy brand
create proc sp_danhsachbrand
as begin
	select * from Brand
end

