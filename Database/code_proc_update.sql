-----Lê Quang Duy
--02/12/2022
--- sửa nhân viên
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
-----Phạm huỳnh Duy Kha
--02/12/2022
---sửa khách hàng
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
-----Lê Quang Duy
--02/12/2022
---sửa sản phẩm
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
-----Phạm Huỳnh Duy Kha
--02/12/2022
---sửa ncc
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
-----Phạm Huỳnh DUy Kha
--02/12/2022
---sửa kho
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
-----Lê Quang Duy
--02/12/2022
--sửa quản lý
create proc sp_suaquanly
@maQL int,
@tenQl nvarchar(50),
@ngaysinh datetime,
@gioitinh nvarchar(3),
@sdt int,
@diachi nvarchar(100),
@id int
as begin
	update QuanLy 
	set ten_QL=@tenQl, ngaysinh=@ngaysinh, gioitinh=@ngaysinh, sdt=@sdt, diachi=@diachi, id=@id
	where @maQL = ma_QL
	and @id = (SElect id from TaiKhoan)
end
-----Lê Quang Duy
--02/12/2022
--sửa brand
create proc sp_suabrand
@mabr int,
@tenbr nvarchar(50)
as begin
	update Brand
	set ten_Br=@tenbr
	where ma_Br=@mabr
end