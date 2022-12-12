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

------------------------Thêm nhân viên-------------------
-------- thêm nhân viên, thêm quản lý nằm bên phần phân quyền
------------------------------------------------------------
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
