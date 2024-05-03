use master
go

create database QLHSUT
go

use QLHSUT
go

create table DS_DOANHNGHIEP(
	ID_DOANHNGHIEP varchar(5),
	TEN_CONGTY nvarchar(100),
	NGUOIDAIDIEN nvarchar(50),
	DIACHI nvarchar(200),
	EMAIL nvarchar(50),
	TINHTRANG_XACTHUC nvarchar(50),
	TIEMNANG_DN nvarchar(50),

	constraint PK_DS_DOANHNGHIEP primary key(ID_DOANHNGHIEP)
);

create table CHINHSACH_UUDAI(
	ID_CHINHSACH varchar(5),
	TEN_CHINHSACH nvarchar(100),
	NOIDUNG nvarchar(200),
	NGAYBATDAU date,
	NGAYKETTHUC date,
	TINHTRANG_SUDUNG nvarchar(50),
	ID_DOANHNGHIEP varchar(5),

	constraint PK_CHINHSACH_UUDAI primary key (ID_CHINHSACH),
	constraint FK_CHINHSACH_UUDAI_DS_DOANHNGHIEP foreign key (ID_DOANHNGHIEP) references DS_DOANHNGHIEP(ID_DOANHNGHIEP)
);

create table HOSO_UNGVIEN(
	ID_UNGVIEN varchar(5),
	HOTEN nvarchar(100),
	NGAYSINH date,
	DIACHI nvarchar(200),
	SDT nvarchar(12),
	EMAIL nvarchar(50),
	CCCD nvarchar(50),

	constraint PK_HOSO_UNGVIEN primary key(ID_UNGVIEN)
);

create table HOPDONG_DANGTUYEN(
	ID_HD_DANGTUYEN varchar(5),
	ID_DOANHNGHIEP varchar(5) not null,
	TENVITRI nvarchar(100),
	TINHTRANG_UNGTUYEN nvarchar(50),
	SOLUONG_TUYENDUNG int,
	YEUCAU_UNGVIEN nvarchar(1000),
	NGAYBATDAU date,
	NGAYKETTHUC date,
	HINHTHUCDANGTUYEN nvarchar(100),
	TINHTRANG_DANGTUYEN nvarchar(50),
	HINHTHUC_THANHTOAN nvarchar(50),
	NGAYLAP date,

	constraint PK_HOPDONG_DANGTUYEN primary key (ID_HD_DANGTUYEN),
	constraint FK_HOPDONG_DANGTUYEN_DS_DOANHNGHIEP foreign key (ID_DOANHNGHIEP) references DS_DOANHNGHIEP(ID_DOANHNGHIEP)
);

create table PHIEUDANGKI_UNGTUYEN(
	ID_UNGVIEN varchar(5),
	ID_HD_DANGTUYEN varchar(5),
	VITRI_UNGTUYEN nvarchar(100),
	DOUUTIEN int,
	TINHTRANG_DUYET nvarchar(50),
	TINHTRANG_PHANHOI nvarchar(50),
	NGAYTIEPNHAN date,

	constraint PK_PHIEUDANGKI_UNGTUYEN primary key (ID_UNGVIEN,ID_HD_DANGTUYEN),
	constraint FK_PHIEUDANGKI_UNGTUYEN_HOSO_UNGVIEN foreign key (ID_UNGVIEN) references HOSO_UNGVIEN(ID_UNGVIEN),
	constraint FK_PHIEUDANGKI_UNGTUYEN_HOPDONG_DANGTUYEN foreign key (ID_HD_DANGTUYEN) references HOPDONG_DANGTUYEN(ID_HD_DANGTUYEN)
);

create table UNGVIEN_CHUNGTU(
	ID_CHUNGTU varchar(5),
	TEN_CHUNGTU nvarchar(100),
	ID_UNGVIEN varchar(5) not null,
	ID_HD_DANGTUYEN varchar(5) not null,

	constraint PK_UNGVIEN_CHUNGTU primary key(ID_CHUNGTU),
	constraint FK_PHIEUDANGKI_UNGTUYEN_PHIEUDANGKI_UNGTUYEN foreign key (ID_UNGVIEN,ID_HD_DANGTUYEN) references PHIEUDANGKI_UNGTUYEN(ID_UNGVIEN,ID_HD_DANGTUYEN)
);

create table UNGVIEN_BANGCAP(
	ID_BANGCAP varchar(5),
	TEN_BANGCAP nvarchar(100),
	ID_UNGVIEN varchar(5) not null,
	ID_HD_DANGTUYEN varchar(5) not null,

	constraint PK_UNGVIEN_UNGVIEN_BANGCAP primary key(ID_BANGCAP),
	constraint FK_PHIEUDANGKI_UNGTUYEN_UNGVIEN_BANGCAP foreign key (ID_UNGVIEN,ID_HD_DANGTUYEN) references PHIEUDANGKI_UNGTUYEN(ID_UNGVIEN,ID_HD_DANGTUYEN)
);

create table HOADON(
	ID_HOADON varchar(5),
	ID_HD_DANGTUYEN varchar(5) not null,
	SOTIENCANTRA int,
	SOTIENDATRA int,
	NGAYLAP date,
	SOLAN_THANHTOAN int,
	DOT_THANHTOAN int,
	TINHTRANG_THANHTOAN nvarchar(50)

	constraint PK_HOADON primary key(ID_HOADON)
	constraint FK_HOADON_HOPDONG_DANGTUYEN foreign key (ID_HD_DANGTUYEN) references HOPDONG_DANGTUYEN(ID_HD_DANGTUYEN)
);

create table NHANVIEN(
	ID_NHANVIEN varchar(5),
	HOTEN nvarchar(100),
	NGAYSINH date,
	DIACHI nvarchar(200),
	SDT nvarchar(12),
	EMAIL nvarchar(50),
	CHUCVU nvarchar(50)

	constraint PK_NHANVIEN primary key (ID_NHANVIEN)
);