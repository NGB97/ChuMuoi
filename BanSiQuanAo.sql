use master
go
create database BanSiQuanAo -- drop database BanSiQuanAo
go
USE BanSiQuanAo
go
CREATE TABLE [dbo].[Size](
	[IDSize] [bigint] IDENTITY(1,1) PRIMARY KEY,
	[MaSize] [nvarchar](max) NULL,
	[TenSize] [nvarchar](max) NULL,
	[GhiChu] [ntext] NULL
) 
go
CREATE TABLE [dbo].[MauSac](
	[IDMauSac] [bigint] IDENTITY(1,1) PRIMARY KEY,
	[MaMauSac] [nvarchar](max) NULL,
	[TenMauSac] [nvarchar](max) NULL,
	[GhiChu] [ntext] NULL
) 

GO
CREATE TABLE [dbo].[HangHoa]
(
	[IDHangHoa] [bigint] IDENTITY(1,1) PRIMARY KEY,
	[MaHangHoa] [nvarchar](max) NULL,
	[TenHangHoa] [nvarchar](max) NULL,
	[IDSize] [bigint] NULL,
	[IDMauSac] [bigint] NULL,	
	[GhiChu] [ntext] NULL,
	foreign key (IDSize) references Size(IDSize),
	foreign key (IDMauSac) references MauSac(IDMauSac)
	
) 

go
CREATE TABLE [dbo].[KhachHang](
	[IDKhachHang] [bigint] IDENTITY(1,1) PRIMARY KEY ,
	[MaKhachHang] [nvarchar](max) NULL,
	[TenKhachHang] [nvarchar](max) NULL,
	[DienThoai] [nvarchar](max) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[GhiChu] [ntext] NULL
	
) 

go
CREATE TABLE [dbo].[ChiTietGiaTheoKhach](
	[IDChiTietGiaTheoKhach] [bigint] IDENTITY(1,1) PRIMARY KEY,
	[IDKhachHang] [bigint] NULL,
	[IDHangHoa] [bigint] NULL,
	[Gia] [float] NULL,
	[GhiChu] [ntext] NULL,
	foreign key (IDHangHoa) references HangHoa(IDHangHoa),
	foreign key (IDKhachHang) references KhachHang(IDKhachHang)
) 
go
CREATE TABLE [dbo].[NhaCungCap](
	[IDNhaCungCap] [bigint] IDENTITY(1,1) PRIMARY KEY,
	[MaNhaCungCap] [nvarchar](max) NULL,
	[TenNhaCungCap] [nvarchar](max) NULL,
	[SDT] [nvarchar](max) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[GhiChu] [ntext] NULL
)
go
CREATE TABLE [dbo].[Kho](
	[IDKho] [bigint] IDENTITY(1,1) PRIMARY KEY,
	[MaKho] [nvarchar](max) NULL,
	[TenKho] [nvarchar](max) NULL,
	[GhiChu] [ntext] NULL
)
go
CREATE TABLE [dbo].[PhieuNhap]
(
	[IDPhieuNhap] [bigint] IDENTITY(1,1) PRIMARY KEY,
	[MaPhieuNhap] [nvarchar](max) NULL,
	[NgayNhap] [datetime] NULL,
	[GhiChu] [ntext] NULL,
	[IDNhaCungCap] [bigint] ,
	[IDKho] [bigint] ,
	foreign key (IDNhaCungCap) references NhaCungCap(IDNhaCungCap),
	foreign key (IDKho) references Kho(IDKho)
)
GO
CREATE TABLE [dbo].[ChiTietPhieuNhap](
	[IDChiTietPhieuNhap] [bigint] IDENTITY(1,1) PRIMARY KEY,
	[IDHangHoa] [bigint] NULL,
	[IDPhieuNhap] [bigint] NULL,
	[SoLuong] [int] NULL,
	[DonGiaNhap] [float] NULL,
	[GhiChu] [ntext] NULL,
	[NgayNhapChiTiet] [datetime] NULL,
	foreign key (IDHangHoa) references HangHoa(IDHangHoa),
	foreign key (IDPhieuNhap) references PhieuNhap(IDPhieuNhap)
) 

GO
CREATE TABLE [dbo].[PhieuXuat](
	[IDPhieuXuat] [bigint] IDENTITY(1,1) PRIMARY KEY,
	[MaPhieuXuat] [nvarchar](max) NULL,
	[NgayXuat] [datetime] NULL,
	[GhiChu] [ntext] NULL,
	[IDKhachHang] [bigint],
	[TienThanhToan] [float],
	foreign key (IDKhachHang) references KhachHang(IDKhachHang)
) 
GO
CREATE TABLE [dbo].[ChiTietPhieuXuat](
	[IDChiTietPhieuXuat] [bigint] IDENTITY(1,1) PRIMARY KEY,
	[IDPhieuXuat] [bigint] NULL,
	[IDHangHoa] [bigint] NULL,
	[IDKhachHang] [bigint] NULL,
	[SoLuong] [int] NULL,
	[DonGiaXuat] [float] NULL,	
	[GiaVon] [float] NULL,	
	[GhiChu] [ntext] NULL,		
	foreign key (IDHangHoa) references HangHoa(IDHangHoa),
	foreign key (IDPhieuXuat) references PhieuXuat(IDPhieuXuat)
)

GO
CREATE TABLE [dbo].[NguoiDung](
	[IDNguoiDung] [bigint] IDENTITY(1,1) PRIMARY KEY,
	[TaiKhoan] [nvarchar](250) unique,
	[MatKhau] [nvarchar](250) NULL,
	[TenNguoiDung] [nvarchar](250) NULL,
	[Quyen] [nvarchar](250) NULL
)
go
CREATE TABLE [dbo].[PhieuTraNo](
	[IDPhieuTraNo] [bigint] IDENTITY(1,1) PRIMARY KEY,
	[MaPhieuTraNo] [nvarchar](max) NULL,
	[Ngay] [datetime] NULL,
	[GhiChu] [ntext] NULL,
	[IDKhachHang] [bigint],
	[SoTien] [float],
	foreign key (IDKhachHang) references KhachHang(IDKhachHang)
) 



