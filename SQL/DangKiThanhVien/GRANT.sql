use QLHSUT
go

--Create role NHANVIEN
exec sp_addrole 'NHANVIEN'
go

--View, update, delete DSTT doanh nghiep
create or alter view V_NV_QLDSTTDOANHNGHIEP
as
	select ID_DOANHNGHIEP, TEN_CONGTY, ID_THUE, NGUOIDAIDIEN, DIACHI, EMAIL, TINHTRANG_XACTHUC
	from DS_DOANHNGHIEP
go

--View DSTT doanh nghiep
grant select, update, delete on V_NV_QLDSTTDOANHNGHIEP to NHANVIEN
go