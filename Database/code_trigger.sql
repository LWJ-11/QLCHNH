--------trigger

--số lượng sản phẩm mua phải lớn hơn bằng 1
create trigger trg_soluongsanpham
on ChitietHD
instead of insert, update
as begin
	declare @soluong int
	select @soluong = soluong from inserted
	if(@soluong<1)
	begin
		rollback tran
		raiserror('Số lượng sản phẩm phải lớn hơn hoặc bằng một',16,1)
		return
	end
end
--Kiểm tra tuổi nhân viên đủ 18
create trigger trg_tuoinvtren18
on NhanVien
instead of insert, update
as begin
	declare @ngaysinh datetime
	select @ngaysinh = ngaysinh from inserted
	if(datediff(y,@ngaysinh,getdate())<18)
	begin
		rollback tran
		raiserror('Nhân viên chưa đủ 18 tuổi',16,1)
		return
	end
end
--Kiểm tra tuổi quản lý đủ 18
create trigger trg_tuoiqltren18
on QuanLy
instead of insert, update
as begin
	declare @ngaysinh datetime
	select @ngaysinh = ngaysinh from inserted
	if(datediff(y,@ngaysinh,getdate())<18)
	begin
		rollback tran
		raiserror('Quản lý chưa đủ 18 tuổi',16,1)
		return
	end
end
--Kiểm tra tuổi khách hàng đủ 18
create trigger trg_tuoikhtren18
on KhachHang
instead of insert, update
as begin
	declare @ngaysinh datetime
	select @ngaysinh = ngaysinh from inserted
	if(datediff(y,@ngaysinh,getdate())<18)
	begin
		rollback tran
		raiserror('Khách hàng chưa đủ 18 tuổi',16,1)
		return
	end
end
--kiểm tra số kí tự số điện thoại nhân viên
create trigger trg_Sokitusdtnv
on NhanVien
instead of insert, update
as begin
	declare @sdt int
	select @sdt=sdt from inserted
	if(Len(@sdt)>10 or Len(@sdt)<10)
	begin
		rollback tran
		raiserror('Số điện thoại không đúng',16,1)
		return
	end
end
--kiểm tra số kí tự số điện thoại quản lý
create trigger trg_Sokitusdtql
on QuanLy
instead of insert, update
as begin
	declare @sdt int
	select @sdt=sdt from inserted
	if(Len(@sdt)>10 or Len(@sdt)<10)
	begin
		rollback tran
		raiserror('Số điện thoại không đúng',16,1)
		return
	end
end
--kiểm tra số kí tự số điện thoại khách hàng
create trigger trg_Sokitusdtkh
on KhachHang
instead of insert, update
as begin
	declare @sdt int
	select @sdt=sdt from inserted
	if(Len(@sdt)>10 or Len(@sdt)<10)
	begin
		rollback tran
		raiserror('Số điện thoại không đúng',16,1)
		return
	end
end
--kiểm tra số kí tự số điện thoại nhà cung cấp
create trigger trg_Sokitusdtncc
on NhaCungCap
instead of insert, update
as begin
	declare @sdt int
	select @sdt=sdt from inserted
	if(Len(@sdt)>10 or Len(@sdt)<10)
	begin
		rollback tran
		raiserror('Số điện thoại không đúng',16,1)
		return
	end
end
--kiểm tra số kí tự số điện thoại cửa hàng
create trigger trg_Sokitusdtch
on CuaHang
instead of insert, update
as begin
	declare @sdt int
	select @sdt=sdt from inserted
	if(Len(@sdt)>10 or Len(@sdt)<10)
	begin
		rollback tran
		raiserror('Số điện thoại không đúng',16,1)
		return
	end
end
--kiểm tra giá không được bé hơn 1000
create trigger trg_giakhongbe1000
on SanPham
instead of insert, update
as begin
	declare @gia float
	select @gia=gia from inserted
	if(@gia<1000)
	begin
		rollback tran
		raiserror('Giá sản phẩm không được bé hơn 1000đ',16,1)
		return
	end
end
--kiểm tra ngay tạo hóa đơn không được lớn hơn ngày hiện tại
create trigger trg_ngaytaohd
on HoaDon
instead of insert,update
as begin
	declare @ngaytao datetime
	select @ngaytao= thoigian from inserted
	if(datediff(dd,getdate(),@ngaytao)>0)
	begin
		rollback tran
		raiserror('Ngày tạo hóa đơn không vượt qua ngày hiện tại',16,1)
		return
	end
end
--kiểm tra ngày thống kê doanh thu không được lớn hơn ngày hiện tại
create trigger trg_ngaytaodt
on DoanhThu
instead of insert,update
as begin
	declare @ngaytao datetime
	select @ngaytao= thoigian from inserted
	if(datediff(dd,getdate(),@ngaytao)>0)
	begin
		rollback tran
		raiserror('Ngày thống kê doanh thu không vượt qua ngày hiện tại',16,1)
		return
	end
end
--kiểm tra mật khẩu tối thiểu 8 ký tự và tối đa 20 ký tự
create trigger trg_kitumk
on TaiKhoan
instead of insert, update
as begin
	declare @mk nvarchar(10)
	select @mk = matkhau from inserted
	if(len(@mk)<8 or len(@mk)>10)
	begin
		rollback tran
		raiserror('Mật khẩu phải từ 8 đến 10 ký tự',16,1)
		return
	end
end
--kiểm tra số lượng tồn kho không được bé hơn 0
create trigger trg_soluongtonkho
on TonKho
instead of insert, update
as begin
	declare @soluong int
	select @soluong= soluongtonkho from inserted
	if(@soluong<0)
	begin
		rollback tran
		raiserror('Số lượng tồn kho không được bé hơn 0',16,1)
		return
	end
end
--kiểm tra tên nhân viên phải có ít nhất 6 ký tự
create trigger trg_sokitutennv
on NhanVien
instead of insert, update
as begin
	declare @ten nvarchar(50)
	select @ten= ten_NV from inserted
	if(len(@ten)<4)
	begin 
		rollback tran
		raiserror('Tên không được ít hơn 4 ký tự',16,1)
	end
end
--kiểm tra tên quản lý phải có ít nhất 6 ký tự
create trigger trg_sokitutenql
on QuanLy
instead of insert, update
as begin
	declare @ten nvarchar(50)
	select @ten= ten_QL from inserted
	if(len(@ten)<4)
	begin 
		rollback tran
		raiserror('Tên không được ít hơn 4 ký tự',16,1)
	end
end
--kiểm tra tên khách hàng phải có ít nhất 6 ký tự
create trigger trg_sokitutenkh
on KhachHang
instead of insert, update
as begin
	declare @ten nvarchar(50)
	select @ten= ten_KH from inserted
	if(len(@ten)<4)
	begin 
		rollback tran
		raiserror('Tên không được ít hơn 4 ký tự',16,1)
	end
end