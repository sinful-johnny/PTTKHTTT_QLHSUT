use QLHSUT
go

--Drop PROCEDURE sp_NV_XemDSDoanhNghiep if exist
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_NV_XemDSDoanhNghiep')
	DROP PROCEDURE sp_NV_XemDSDoanhNghiep;
GO
--Proc NHANVIEN view DS Doanh Nghiep
create or alter proc sp_NV_XemDSDoanhNghiep
as
	begin tran
		select *
		from V_NV_QLDSTTDOANHNGHIEP
	commit tran
go

--Drop PROCEDURE sp_NV_SearchTTDoanhNghiep if exist
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_NV_SearchTTDoanhNghiep')
	DROP PROCEDURE sp_NV_SearchTTDoanhNghiep;
GO
--Proc NHANVIEN search TT Doanh Nghiep
create or alter proc sp_NV_SearchTTDoanhNghiep
					@tencongty nvarchar(100)
as
	begin tran
		select *
		from V_NV_QLDSTTDOANHNGHIEP
		where upper(TEN_CONGTY) Like '%' + upper(@tencongty) +'%'
	commit tran
go

--Drop PROCEDURE sp_NV_SuaTTDoanhNghiep if exist
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_NV_SuaTTDoanhNghiep')
	DROP PROCEDURE sp_NV_SuaTTDoanhNghiep;
GO
--Proc NHANVIEN update TT Doanh Nghiep
create or alter proc sp_NV_SuaTTDoanhNghiep
					@iddoanhnghiep varchar(5),
					@tencongty nvarchar(100),
					@idthue varchar(5),
					@nguoidaidien nvarchar(50),
					@diachi nvarchar(200),
					@email nvarchar(50),
					@tinhtrangxacthuc nvarchar(50)
as
	begin tran
		update V_NV_QLDSTTDOANHNGHIEP
			set TEN_CONGTY = @tencongty,
				ID_THUE = @idthue,
				NGUOIDAIDIEN = @nguoidaidien,
				DIACHI = @diachi,
				EMAIL = @email,
				TINHTRANG_XACTHUC = @tinhtrangxacthuc
			where ID_DOANHNGHIEP = @iddoanhnghiep

	commit tran
go

--Drop PROCEDURE sp_NV_XoaTTDoanhNghiep if exist
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'sp_NV_XoaTTDoanhNghiep')
	DROP PROCEDURE sp_NV_XoaTTDoanhNghiep;
GO
--Proc NHANVIEN delete TT Doanh Nghiep
create or alter proc sp_NV_XoaTTDoanhNghiep
					@iddoanhnghiep varchar(5)
as
	begin tran
		delete from V_NV_QLDSTTDOANHNGHIEP
		where ID_DOANHNGHIEP = @iddoanhnghiep
	commit tran
go

--Proc NHANVIEN view DS Doanh Nghiep
GRANT EXECUTE ON OBJECT::sp_NV_XemDSDoanhNghiep
    TO NHANVIEN;  
GO

--Proc NHANVIEN search TT Doanh Nghiep
GRANT EXECUTE ON OBJECT::sp_NV_SearchTTDoanhNghiep
    TO NHANVIEN;  
GO

--Proc NHANVIEN update TT Doanh Nghiep
GRANT EXECUTE ON OBJECT::sp_NV_SuaTTDoanhNghiep
    TO NHANVIEN;  
GO

--Proc NHANVIEN delete TT Doanh Nghiep
GRANT EXECUTE ON OBJECT::sp_NV_XoaTTDoanhNghiep
    TO NHANVIEN;  
GO