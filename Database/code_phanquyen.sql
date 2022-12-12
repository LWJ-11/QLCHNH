---------Phân quyền

-----Admin
create role Admin 

grant select, insert, delete, update to Admin


-----Nhân viên
create role NhanVien

grant select, update on NhanVien to NhanVien
grant select, insert, delete, update on SanPham to NhanVien
grant select, insert, delete, update on DoanhThu to NhanVien
grant select, insert, delete, update on ChitietDT to NhanVien
grant select, insert, delete, update on HoaDon to NhanVien
grant select, insert, delete, update on ChitietHD to NhanVien
grant select on Brand to NhanVien
grant select on NhaCungCap to NhanVien

------proc tạo tài khoản

---thông tin đăng ký: Tên, ngày sinh, giới tính, sdt, địa chỉ
---nhân viên có thêm Mã cửa hàng

---nhân viên
create proc sp_nhanvien
@tenDN nvarchar(50),
@matkhau nvarchar(10),
@tenNV nvarchar(50),
@ngaysinh datetime,
@gioitinh nvarchar(3),
@sdt int,
@diachi nvarchar(100),
@maCH int,
@role nvarchar(10)
as begin
declare @id int
	if not exists (select ma_CH from CuaHang where ma_CH=@maCH)
	begin
		raiserror('Cửa hàng không tồn tại',16,1)
		return
	end
	if exists (select taikhoan from TaiKhoan where @tenDN = taikhoan)
	begin
		raiserror('Tài khoản đã tồn tại',16,1)
		return
	end
	--tạo login
	exec sp_addlogin @tenDN, @matkhau
	--gán user cho login
	exec sp_adduser @tenDN, @tenNV
	--add user vào role nv
	exec sp_addRolemember @role,@tenNV
	--thêm tài khoản vào Taikhoan
	insert into TaiKhoan(taikhoan,matkhau,role)
	values (@tenDN,@matkhau,@role)
	--lấy id tk vừa tạo
	set @id = (select top 1 id from TaiKhoan where Taikhoan = @tenDN)
	--thêm nhân viên mới
	insert into NhanVien (ten_NV,ngaysinh,gioitinh,sdt,diachi,ma_CH,id)
	values (@tenNV,@ngaysinh,@gioitinh,@sdt,@diachi,@maCH,@id)
	
	select top 1 * from NhanVien
end

exec sp_nhanvien 'DuyKha','123456','Duy Kha', 23/11/2001, 'nam', 0987654321, 'TP HCM', 1, 'Nhan Vien'