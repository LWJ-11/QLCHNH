--- lấy danh sách nhân viên
create proc sp_danhsachnhanvien
as
begin
	select * from NhanVien
end

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

--- Lấy danh sách sản phẩm
create proc sp_danhsachsanpham
as
begin
    select sp.ma_SP,ten_SP, sp.gia, sp.chitiet, br.ten_Br ,ncc.ten_NCC
    from SanPham sp, NhaCungCap ncc, Brand br
    where sp.ma_Br = br.ma_Br
    and sp.ma_NCC = ncc.ma_NCC
end

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

