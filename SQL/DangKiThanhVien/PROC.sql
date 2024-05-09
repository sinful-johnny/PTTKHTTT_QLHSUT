--Proc NHANVIEN view DS Doanh Nghiep
create or alter proc sp_NV_XemDSDoanhNghiep
as
	begin tran
		select *
		from V_NV_QLDSTTDOANHNGHIEP
	commit tran
go

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

exec sp_NV_XemDSDoanhNghiep
go

exec sp_NV_SearchTTDoanhNghiep N'TẬP ĐOÀN XĂNG DẦU VIỆT NAM'
go

--Proc NHANVIEN update TT Doanh Nghiep
create or alter proc sp_KH_SuaTTDoanhNghiep
					@iddoanhnghiep varchar(5),
					@tencongty nvarchar(100),
					@idthue varchar(5),
					@nguoidaidien nvarchar(50),
					@diachi nvarchar(200),
					@email nvarchar(50),
					@tinhtrangxacthuc nvarchar(50)
as
	begin tran
		if	@tencongty is null
		begin
			update V_NV_QLDSTTDOANHNGHIEP
			set TEN_CONGTY = @tencongty
			where ID_DOANHNGHIEP = @iddoanhnghiep
		end

		if	@idthue is null
		begin
			update V_NV_QLDSTTDOANHNGHIEP
			set ID_THUE = @idthue
			where ID_DOANHNGHIEP = @iddoanhnghiep
		end

		if	@nguoidaidien is null
		begin
			update V_NV_QLDSTTDOANHNGHIEP
			set NGUOIDAIDIEN = @nguoidaidien
			where ID_DOANHNGHIEP = @iddoanhnghiep
		end

		if	@diachi is null
		begin
			update V_NV_QLDSTTDOANHNGHIEP
			set DIACHI = @diachi
			where ID_DOANHNGHIEP = @iddoanhnghiep
		end

		if	@email is null
		begin
			update V_NV_QLDSTTDOANHNGHIEP
			set EMAIL = @email
			where ID_DOANHNGHIEP = @iddoanhnghiep
		end

		if	@tinhtrangxacthuc is null
		begin
			update V_NV_QLDSTTDOANHNGHIEP
			set TINHTRANG_XACTHUC = @tinhtrangxacthuc
			where ID_DOANHNGHIEP = @iddoanhnghiep
		end

	commit tran
go

--Proc NHANVIEN delete TT Doanh Nghiep
create or alter proc sp_KH_XoaTTDoanhNghiep
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
GRANT EXECUTE ON OBJECT::sp_KH_SuaTTDoanhNghiep
    TO NHANVIEN;  
GO

--Proc NHANVIEN delete TT Doanh Nghiep
GRANT EXECUTE ON OBJECT::sp_KH_XoaTTDoanhNghiep
    TO NHANVIEN;  
GO

exec sp_NV_XemDSDoanhNghiep;