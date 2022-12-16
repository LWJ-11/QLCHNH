--- lấy danh sách nhân viên
alter proc sp_danhsachnhanvien
as
begin
	select nv.ma_NV, nv.ten_NV, nv.ngaysinh, nv.gioitinh, nv.sdt, nv.diachi, ch.ten_CH from NhanVien nv, CuaHang ch
	where nv.ma_CH = ch.ma_CH
end

exec sp_danhsachnhanvien

--- Lấy danh sách khách hàng
create proc sp_danhsachkhachhang
as
begin
	select * from KhachHang
end

--- Lấy danh sách Kho
create proc sp_danhsachkho
as
begin
	select * from Kho
end

--- Lấy danh sách nhà cung cấp
create proc sp_danhsachncc
as
begin
	select * from NhaCungCap
end

create proc sp_nhacungcapById
@maNcc int
as
begin
	select * from NhaCungCap
	where ma_NCC = @maNcc
end

exec sp_nhacungcapById 1


--- Lấy danh sách sản phẩm
create proc sp_danhsachsanpham
as
begin
    select sp.ma_SP,ten_SP, sp.gia, sp.chitiet, br.ten_Br ,ncc.ten_NCC
    from SanPham sp, NhaCungCap ncc, Brand br
    where sp.ma_Br = br.ma_Br
    and sp.ma_NCC = ncc.ma_NCC
end


alter proc sp_danhsachhoadon
as
begin
	select hd.ma_HD, kh.ten_KH, hd.thoigian, cthd.thanhtien
	from HoaDon hd, ChiTietHD cthd, KhachHang kh, SanPham sp
	where hd.ma_HD=cthd.ma_HD
	and cthd.ma_SP = sp.ma_SP
	and cthd.ma_KH = kh.ma_KH
end

exec sp_danhsachhoadon


------------------------------------------------
--- Lấy thông tin sản phẩm
create proc sp_thongtinsanpham @maSP int
as
begin
	select sp.ma_SP, sp.ten_SP, sp.gia, sp.chitiet, br.ten_Br
	from SanPham sp, NhaCungCap ncc, Brand br
	where sp.ma_Br = br.ma_Br
	and sp.ma_SP = @maSP
end

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

