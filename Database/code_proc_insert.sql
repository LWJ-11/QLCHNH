﻿----Phạm Huỳnh Duy Kha
---01/12/2022
-----thêm sản phẩm
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
----Phạm Huỳnh Duy Kha
---01/12/2022
--thêm khách hàng
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
----Phạm Huỳnh Duy Kha
---01/12/2022
--thêm nhà cung cấp
create proc sp_themncc
@tenNCC nvarchar(50),
@sdt int,
@diachi nvarchar(50)
as
begin
	insert into NhaCungCap(ten_NCC,sdt,diachi)
	values (@tenNCC,@sdt,@diachi)
end
----Lê Quang Duy
---01/12/2022
--thêm brand 
create proc sp_thembrand
@tenBr nvarchar(50)
as begin
	insert into Brand(ten_Br) values (@tenBr)
end
----Lê Quang Duy
---01/12/2022
--thêm hóa đơn
create proc sp_themhd
@thoigian datetime,
@maSP int,
@maKH int,
@soluong int,
@thanhtien float
as begin
	declare @top int
	if not exists (select ma_SP from SanPham where ma_SP=@maSP)
	begin
		raiserror('Sản phẩm không tồn tại',16,1)
		return
	end
	if not exists (select ma_KH from KhachHang where ma_KH=@maKH)
	begin
		raiserror('Khách hàng không tồn tại',16,1)
		return
	end
	insert into HoaDon (thoigian) values (@thoigian)
	set @top = (select top 1 ma_HD from HoaDon)
	insert into ChiTietHD (ma_HD,ma_SP,ma_KH, soluong,thanhtien) values (@top,@maSP,@maKH,@soluong,@thanhtien)
end