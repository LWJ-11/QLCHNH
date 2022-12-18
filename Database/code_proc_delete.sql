----Phạm Huỳnh Duy Kha
---03/12/2022
--xóa nhân viên
create proc sp_xoanv
@maNV int
as
begin
	delete from NhanVien where ma_NV = @maNV
	delete from TaiKhoan where id = (select id from NhanVien where ma_NV=@maNV)
end
----Phạm Huỳnh Duy Kha
---03/12/2022
--xóa nhà cung cấp
create proc sp_xoancc
@maNCC int
as 
begin
	delete from NhaCungCap where ma_NCC = @maNCC
end
----Phạm Huỳnh Duy Kha
---03/12/2022
--xóa brand
create proc sp_xoabr
@mabr int
as 
begin
	delete from Brand where ma_Br = @mabr
end
