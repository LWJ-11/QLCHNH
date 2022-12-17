---function
----Phạm Huỳnh Duy Kha
---01/12/2022
--số nhân viên trong cửa hàng
create function f_Sonvtrongcuahang(@mach int)
returns int as begin
	declare @sonv int
	set @sonv = (select count(ma_NV) from NhanVien where ma_CH=@mach)
	return @sonv
end
----Phạm Huỳnh Duy Kha
---01/12/2022
--tính tổng tiền hóa đơn
--giá được convert từ float sang int
create function f_Tongtienhd(@gia int, @soluong int)
returns int as begin
	declare @tongtien int
	set @tongtien = @gia * @soluong
	return @tongtien
end
----Lê Quang Duy
---01/12/2022
--tính tổng doanh thu
--chi và thu được convert từ float sang int
create function f_Tongtiendt(@thu int, @chi int)
returns int as begin
	declare @tongtien int
	set @tongtien = @thu - @chi
	return @tongtien
end
----Phạm Huỳnh Duy Kha
---01/12/2022
--tổng số nhân viên
create function f_Sonv()
returns int as begin
	declare @sonv int
	set @sonv = (select count(ma_NV) from NhanVien)
	return @sonv
end
----Lê Quang Duy
---01/12/2022
--tổng số sản phẩm còn trong kho
create function f_Tongsptrongkho(@ma_Kho int)
returns int as begin
	declare @count int
	set @count = (select count(ma_SP) from TonKho where ma_Kho=@ma_Kho)
	return @count
end
----Lê Quang Duy
---01/12/2022
--số khách hàng đã mua hàng một sản phẩm nhất định
create function f_Sokhdamua(@ma_SP int)
returns int as begin
	declare @count int
	set @count = (select count(ma_KH) from ChiTietHD where ma_SP=@ma_SP)
	return @count
end