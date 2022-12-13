------xóa
--xóa nhân viên
create proc sp_xoanv
@maNV int
as
begin
	delete from NhanVien where ma_NV = @maNV
end

--xóa nhà cung cấp
create proc sp_xoancc
@maNCC int
as 
begin
	delete from NhaCungCap where ma_NCC = @maNCC
end

--xóa brand
create proc sp_xoabr
@mabr int
as 
begin
	delete from Brand where ma_Br = @mabr
end