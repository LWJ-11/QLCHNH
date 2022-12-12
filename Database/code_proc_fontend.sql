--- lấy danh sách nhân viên

create proc sp_danhsachnhanvien
as
begin
	select * from NhanVien
end

exec sp_danhsachnhanvien
--- Lấy danh sách khách hàng

create proc sp_danhsachkhachhang
as
begin
	select * from KhachHang
end

exec sp_danhsachkhachhang
--- Lấy danh sách Kho

create proc sp_danhsachkho
as
begin
	select * from Kho
end

exec sp_danhsachkho
--- Lấy danh sách hóa đơn

create proc sp_danhsachhoadon
as
begin 
	select * from HoaDon
end

exec sp_danhsachhoadon
--- Lấy danh sách nhà cung cấp

create proc sp_danhsachncc
as
begin
	select * from NhaCungCap
end

exec sp_danhsachncc
--- Lấy danh sách sản phẩm

create proc sp_danhsachsanpham
as
begin
	select * from SanPham
end

alter proc sp_danhsachsanpham
as
begin
    select sp.*, br.ten_Br ,ncc.ten_NCC
    from SanPham sp, NhaCungCap ncc, Brand br
    where sp.ma_Br = br.ma_Br
    and sp.ma_NCC = ncc.ma_NCC
end
exec sp_danhsachsanpham

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


-----thêm

create proc sp_themsanpham 
@tenSP nvarchar(50),
@gia float,
@chitiet nvarchar(500),
@maNCC int,
@maBr int
as
begin
	if not exists( select * from Brand where ma_Br = @maBr)
	begin
		raiserror('Brand không tồn tại',16,1)
		return
	end
	if not exists( select * from NhaCungCap where ma_NCC = @maNCC)
	begin
		raiserror('Nhà cung cấp không tồn tại',16,1)
		return
	end
	insert into SanPham(ten_SP, gia, chitiet, ma_NCC, ma_Br) 
	values (@tenSP, @gia, @chitiet, @maNCC, @maBr)
end

create proc sp_themnhanvien
@tenNV nvarchar(50),
@ngaysinh datetime,
@gioitinh nvarchar(3),
@sdt int,
@diachi nvarchar(50),
@maCH int,
@id int
as
begin
	if not exists( select * from CuaHang where ma_CH=@maCH)
	begin
		raiserror('Cửa hàng không tồn tại',16,1)
		return
	end
	if not exists( select * from TaiKhoan where id=@id)
	begin
		raiserror('Tài khoản không tồn tại',16,1)
		return
	end
	insert into NhanVien(ten_NV, ngaysinh, gioitinh, sdt, diachi, ma_CH, id) 
	values (@tenNV, @ngaysinh, @gioitinh, @sdt, @diachi, @maCH, @id)
end

create proc sp_themkhachhang
@tenKH nvarchar(50),
@ngaysinh datetime,
@gioitinh nvarchar(3),
@sdt int,
@diachi nvarchar(50)
as 
begin
	insert into KhachHang(ten_KH,ngaysinh,gioitinh,sdt,diachi)
	values (@tenKH,@ngaysinh,@gioitinh,@sdt,@diachi)
end


create proc sp_themncc
@tenNCC nvarchar(50),
@sdt int,
@diachi nvarchar(50)
as
begin
	insert into NhaCungCap(ten_NCC,sdt,diachi)
	values (@tenNCC,@sdt,@diachi)
end

------xóa

create proc sp_xoanv
@maNV int
as
begin
	delete from NhanVien where ma_NV = @maNV
end

create proc sp_xoancc
@maNCC int
as 
begin
	delete from NhaCungCap where ma_NCC = @maNCC
end

--------sửa

create proc sp_suanv
@maNV int,
@tenNV nvarchar(50),
@ngaysinh datetime,
@gioitinh nvarchar(3),
@sdt int,
@diachi nvarchar(50),
@maCH int,
@id int
as
begin
	update NhanVien 
	set ten_NV=@tenNV, ngaysinh=@ngaysinh, gioitinh=@ngaysinh, sdt=@sdt, diachi=@diachi, ma_CH=@maCH, id=@id
	where @maNV = ma_NV
	and @maCH = (select ma_CH from CuaHang)
	and @id = (SElect id from TaiKhoan)
end

create proc sp_suakh
@maKH int,
@tenKH nvarchar(50),
@ngaysinh datetime,
@gioitinh nvarchar(3),
@sdt int,
@diachi nvarchar(50)
as
begin
	update KhachHang
	set ten_KH=@tenKH,ngaysinh=@ngaysinh,gioitinh=@gioitinh,sdt=@sdt,diachi=@diachi
	where @maKH=ma_KH
end

create proc sp_suasp
@maSP int,
@tenSP nvarchar(50),
@gia float,
@chitiet nvarchar(500),
@maNCC int,
@maBr int
as
begin
	update SanPham
	set ten_SP=@tenSP,gia=@gia,chitiet=@chitiet,ma_NCC=@maNCC,ma_Br=@maBr
	where @maSP=ma_SP
	and @maNCC=(select ma_NCC from NhaCungCap)
	and @maBr=(select ma_Br from Brand)
end

create proc sp_suancc
@maNCC int, 
@tenNCC nvarchar(50),
@sdt int,
@diachi nvarchar(50)
as
begin
	update NhaCungCap
	set ten_NCC=@tenNCC,sdt=@sdt,diachi=@diachi
	where ma_NCC=@maNCC
end

create proc sp_suakho
@makho int,
@diachi nvarchar(50),
@maCH int
as
begin
	update Kho
	set diachi=@diachi, ma_CH=@maCH
	where ma_Kho=@makho
	and @maCH=(select ma_CH from CuaHang)
end