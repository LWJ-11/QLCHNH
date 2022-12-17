

----- Lê Quang Duy
----01/12/2022
--- tran sp xem thông tin hóa đơn
create proc sp_thongtinhoadon @maHD int
as
begin
	set xact_abort on
	begin transaction
	set transaction isolation level serializable
	select * from HoaDon with (readcommitted)
		begin try
			if not exists( select ma_HD from HoaDon where ma_HD=@maHD)
			raiserror('Xem lại mã hóa đơn',16,1)
			else
			begin
				select hd.ma_HD, kh.ten_KH, hd.thoigian, sp.gia, cthd.soluong, cthd.thanhtien
				from HoaDon hd, ChiTietHD cthd, KhachHang kh, SanPham sp
				where hd.ma_HD=@maHD
				and hd.ma_HD=cthd.ma_HD
				and cthd.ma_SP = sp.ma_SP
				and cthd.ma_KH = kh.ma_KH
			end
			commit
		end try
		begin catch
			rollback tran
			declare @errorMessage varchar(2000)
			select @errorMessage = 'Loi: ' + ERROR_MESSAGE()
			RAISERROR (@errorMessage, 16, 1)
		end catch
end
----Phạm Huỳnh Duy Kha
---01/12/2022
--- tran sp thêm khách hàng
create proc sp_themsanpham 
@tenSP nvarchar(50),
@gia float,
@chitiet nvarchar(500),
@maNCC int,
@maBr int
as
begin
	set xact_abort on
	begin transaction
	set transaction isolation level serializable
	select * from SanPham with (readcommitted)
	select * from Brand with(updlock)
	select * from NhaCungCap with (updlock)
		begin try
			if not exists( select * from Brand where ma_Br = @maBr)
				raiserror('Brand không tồn tại',16,1)
			if not exists( select * from NhaCungCap where ma_NCC = @maNCC)
				raiserror('Nhà cung cấp không tồn tại',16,1)
			else
			begin
				insert into SanPham(ten_SP, gia, chitiet, ma_NCC, ma_Br) 
				values (@tenSP, @gia, @chitiet, @maNCC, @maBr)
			end
			commit
		end try
		begin catch
			rollback tran
			declare @errorMessage varchar(2000)
			select @errorMessage = 'Loi: ' + ERROR_MESSAGE()
			RAISERROR (@errorMessage, 16, 1)
		end catch
end
----Lê Quang Duy
---01/12/2022
--- tran sp them hd
create proc sp_themhd
@thoigian datetime,
@maSP int,
@maKH int,
@soluong int,
@thanhtien float
as begin
	declare @top int
	set xact_abort on
	begin transaction
	set transaction isolation level serializable
	select * from HoaDon with (readcommitted)
	select * from ChiTietHD with (readcommitted)
	select * from SanPham with(updlock)
	select * from KhachHang with (updlock)
		begin try
			if not exists (select ma_SP from SanPham where ma_SP=@maSP)
				raiserror('Sản phẩm không tồn tại',16,1)
			if not exists (select ma_KH from KhachHang where ma_KH=@maKH)
				raiserror('Khách hàng không tồn tại',16,1)
			else
			begin
				insert into HoaDon (thoigian) values (@thoigian)
				set @top = (select top 1 ma_HD from HoaDon)
				insert into ChiTietHD (ma_HD,ma_SP,ma_KH, soluong,thanhtien) values (@top,@maSP,@maKH,@soluong,@thanhtien)
			end
			commit
		end try
		begin catch
			rollback tran
			declare @errorMessage varchar(2000)
			select @errorMessage = 'Loi: ' + ERROR_MESSAGE()
			RAISERROR (@errorMessage, 16, 1)
		end catch
end
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
	set xact_abort on
	begin transaction
	set transaction isolation level serializable
	select * from NhanVien with (readcommitted)
	select * from TaiKhoan with (updlock)
		begin try
			if (@maNV is null or @tenNV is null or @ngaysinh is null 
			or @gioitinh is null or @sdt is null or @diachi is null or @maCH is null or @id is null)
			raiserror('Thong tin nhap rong',16,1)	
			if not exists(select id from TaiKhoan where id = @id)
			raiserror('Tài khoản không tồn tại',16,1)
			if not exists(select ma_CH from CuaHang where ma_CH = @maCH)
			raiserror('Cửa hàng không tồn tại',16,1)
			else 
			begin
				update NhanVien 
				set ten_NV=@tenNV, ngaysinh=@ngaysinh, gioitinh=@ngaysinh, sdt=@sdt, diachi=@diachi, ma_CH=@maCH, id=@id
				where @maNV = ma_NV
				and @maCH = (select ma_CH from CuaHang)
				and @id = (SElect id from TaiKhoan)
			end
			commit
		end try
		begin catch
			rollback tran
			declare @errorMessage varchar(2000)
			select @errorMessage = 'Loi: ' + ERROR_MESSAGE()
			RAISERROR (@errorMessage, 16, 1)
		end catch
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
	set xact_abort on
	set transaction isolation level serializable
	select * from KhachHang with (readcommitted)
		begin try
			if (@maKH is null or @tenKH is null or @NgaySinh is null 
					or @gioitinh is null or @sdt is null or @diachi is null)
				raiserror('Thong tin nhap rong',16,1)	
			if not exists(select ma_KH from KhachHang where ma_KH = @maKH)
			raiserror('Khach hàng không tồn tại',16,1)
			else 
			begin
				update KhachHang
				set ten_KH=@tenKH,ngaysinh=@ngaysinh,gioitinh=@gioitinh,sdt=@sdt,diachi=@diachi
				where @maKH=ma_KH
			end
			commit
		end try
		begin catch
			rollback tran
			declare @errorMessage varchar(2000)
			select @errorMessage = 'Loi: ' + ERROR_MESSAGE()
			RAISERROR (@errorMessage, 16, 1)
		end catch
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
	set xact_abort on
	set transaction isolation level serializable
	select * from SanPham with (readcommitted)
	select * from NhaCungCap with (updlock)
	select * from Brand with (updlock)
		begin try
			if (@maSP is null or @tenSP is null or @gia is null 
					or @chitiet is null or @maNCC is null or @maBr is null)
				raiserror('Thong tin nhap rong',16,1)	
			if not exists(select ma_NCC from NhaCungCap where ma_NCC = @maNCC)
			raiserror('Nhà cung cấp không tồn tại',16,1)
			if not exists(select ma_Br from Brand where ma_Br = @maBr)
			raiserror('Brand không tồn tại',16,1)
			else 
			begin
				update SanPham
				set ten_SP=@tenSP,gia=@gia,chitiet=@chitiet,ma_NCC=@maNCC,ma_Br=@maBr
				where @maSP=ma_SP
				and @maNCC=(select ma_NCC from NhaCungCap)
				and @maBr=(select ma_Br from Brand)
			end
			commit
		end try
		begin catch
			rollback tran
			declare @errorMessage varchar(2000)
			select @errorMessage = 'Loi: ' + ERROR_MESSAGE()
			RAISERROR (@errorMessage, 16, 1)
		end catch
	
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
	set xact_abort on
	set transaction isolation level serializable
	select * from SanPham with (readcommitted)
	select * from NhaCungCap with (updlock)
	select * from Brand with (updlock)
		begin try
			if (@maNCC is null or @tenNCC is null or @sdt is null or @diachi is null)
				raiserror('Thong tin nhap rong',16,1)	
			if not exists(select ma_NCC from NhaCungCap where ma_NCC = @maNCC)
			raiserror('Nhà cung cấp không tồn tại',16,1)
			else 
			begin
				update NhaCungCap
				set ten_NCC=@tenNCC,sdt=@sdt,diachi=@diachi
				where ma_NCC=@maNCC
			end
			commit
		end try
		begin catch
			rollback tran
			declare @errorMessage varchar(2000)
			select @errorMessage = 'Loi: ' + ERROR_MESSAGE()
			RAISERROR (@errorMessage, 16, 1)
		end catch
	
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
	set xact_abort on
	set transaction isolation level serializable
	select * from Kho with (readcommitted)
	select * from CuaHang with (updlock)
		begin try
			if (@makho is null or @diachi is null or @maCH is null)
				raiserror('Thong tin nhap rong',16,1)	
			if not exists(select ma_CH from CuaHang where ma_CH = @maCH)
			raiserror('Nhà cung cấp không tồn tại',16,1)
			else 
			begin
				update Kho
				set diachi=@diachi, ma_CH=@maCH
				where ma_Kho=@makho
				and @maCH=(select ma_CH from CuaHang)
			end
			commit
		end try
		begin catch
			rollback tran
			declare @errorMessage varchar(2000)
			select @errorMessage = 'Loi: ' + ERROR_MESSAGE()
			RAISERROR (@errorMessage, 16, 1)
		end catch
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
	set xact_abort on
	set transaction isolation level serializable
	select * from SanPham with (readcommitted)
	select * from NhaCungCap with (updlock)
	select * from Brand with (updlock)
		begin try
			if (@maQl is null or @tenQl is null or @NgaySinh is null 
					or @gioitinh is null or @sdt is null or @diachi is null)
				raiserror('Thong tin nhap rong',16,1)	
			if not exists(select id from TaiKhoan where id = @id)
			raiserror('Tài khoản không tồn tại',16,1)
			else 
			begin
				update QuanLy 
				set ten_QL=@tenQl, ngaysinh=@ngaysinh, gioitinh=@ngaysinh, sdt=@sdt, diachi=@diachi, id=@id
				where @maQL = ma_QL
				and @id = (SElect id from TaiKhoan)
			end
			commit
		end try
		begin catch
			rollback tran
			declare @errorMessage varchar(2000)
			select @errorMessage = 'Loi: ' + ERROR_MESSAGE()
			RAISERROR (@errorMessage, 16, 1)
		end catch
	
end
-----Lê Quang Duy
--02/12/2022
--sửa brand
create proc sp_suabrand
@mabr int,
@tenbr nvarchar(50)
as begin
	set xact_abort on
	set transaction isolation level serializable
	select * from Kho with (readcommitted)
	select * from CuaHang with (updlock)
		begin try
			if (@mabr is null or @tenbr is null)
			raiserror('Thong tin nhap rong',16,1)	
			else 
			begin
				update Brand
				set ten_Br=@tenbr
				where ma_Br=@mabr
			end
			commit
		end try
		begin catch
			rollback tran
			declare @errorMessage varchar(2000)
			select @errorMessage = 'Loi: ' + ERROR_MESSAGE()
			RAISERROR (@errorMessage, 16, 1)
		end catch
	
end
----Phạm Huỳnh Duy Kha
---03/12/2022
--xóa nhân viên
create proc sp_xoanv
@maNV int
as
begin
	set xact_abort on
	set transaction isolation level serializable
	select * from NhanVien with (readcommitted)
	select * from TaiKhoan with (readcommitted)
		begin try
			if not exists(select ma_NV from NhanVien where ma_NV=@maNV)
			raiserror('Nhân viên không tồn tại',16,1)
			else 
			begin
				delete from NhanVien where ma_NV = @maNV
				delete from TaiKhoan where id = (select id from NhanVien where ma_NV=@maNV)
			end
			commit
		end try
		begin catch
			rollback tran
			declare @errorMessage varchar(2000)
			select @errorMessage = 'Loi: ' + ERROR_MESSAGE()
			RAISERROR (@errorMessage, 16, 1)
		end catch
	
end
----Lê Quang Duy
---03/12/2022
--xóa nhà cung cấp
create proc sp_xoancc
@maNCC int
as 
begin
	set xact_abort on
	set transaction isolation level serializable
	select * from NhaCungCap with (readcommitted)
		begin try
			if not exists(select ma_NCC from NhaCungCap where ma_NCC=@maNCC)
			raiserror('Nhà cung cấp không tồn tại',16,1)
			else 
			begin
				delete from NhaCungCap where ma_NCC = @maNCC
			end
			commit
		end try
		begin catch
			rollback tran
			declare @errorMessage varchar(2000)
			select @errorMessage = 'Loi: ' + ERROR_MESSAGE()
			RAISERROR (@errorMessage, 16, 1)
		end catch
	
end
----Phạm Huỳnh Duy Kha
---03/12/2022
--xóa brand
create proc sp_xoabr
@mabr int
as 
begin
	set xact_abort on
	set transaction isolation level serializable
	select * from Brand with (readcommitted)
		begin try
			if not exists(select ma_Br from Brand where ma_Br=@mabr)
			raiserror('Brand không tồn tại',16,1)
			else 
			begin
				delete from Brand where ma_Br = @mabr
			end
			commit
		end try
		begin catch
			rollback tran
			declare @errorMessage varchar(2000)
			select @errorMessage = 'Loi: ' + ERROR_MESSAGE()
			RAISERROR (@errorMessage, 16, 1)
		end catch
	
end
