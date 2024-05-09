use QLHSUT
go

--Create role NHANVIEN
exec sp_addrole 'NHANVIEN'
go


create or alter view V_NV_QLDSTTDOANHNGHIEP
as
	select ID_DOANHNGHIEP, TEN_CONGTY, ID_THUE, NGUOIDAIDIEN, DIACHI, EMAIL
	from DS_DOANHNGHIEP
go

grant select, update, delete on V_NV_QLDSTTDOANHNGHIEP to NHANVIEN
go