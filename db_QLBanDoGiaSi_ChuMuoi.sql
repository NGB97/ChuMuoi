USE [db_QLBanDoGiaSi_ChuMuoi]
GO
/****** Object:  Table [dbo].[BangLog]    Script Date: 7/9/2019 10:37:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangLog](
	[IDBangLog] [bigint] IDENTITY(1,1) NOT NULL,
	[TaiKhoan] [nvarchar](250) NULL,
	[ThaoTac] [ntext] NULL,
	[NgayGio] [datetime] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[bangtam]    Script Date: 7/9/2019 10:37:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bangtam](
	[chuoi] [nvarchar](max) NULL,
	[f] [nvarchar](max) NULL,
	[dm] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BlackList]    Script Date: 7/9/2019 10:37:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BlackList](
	[IDBlackList] [bigint] IDENTITY(1,1) NOT NULL,
	[IDLoaiHangHoa] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDBlackList] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChatLieu]    Script Date: 7/9/2019 10:37:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatLieu](
	[IDChatLieu] [int] IDENTITY(1,1) NOT NULL,
	[MaChatLieu] [nvarchar](15) NULL,
	[TenChatLieu] [nvarchar](50) NULL,
	[GhiChu] [nvarchar](100) NULL,
 CONSTRAINT [PK_ChatLieu] PRIMARY KEY CLUSTERED 
(
	[IDChatLieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietDonHangTuWeb]    Script Date: 7/9/2019 10:37:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonHangTuWeb](
	[idChiTietDonHang] [bigint] IDENTITY(1,1) NOT NULL,
	[idDonHang] [bigint] NULL,
	[idHangHoa] [bigint] NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_ChiTietDonHangTuWeb] PRIMARY KEY CLUSTERED 
(
	[idChiTietDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietGiaTheoKhach]    Script Date: 7/9/2019 10:37:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietGiaTheoKhach](
	[IDChiTietGiaTheoKhach] [bigint] IDENTITY(1,1) NOT NULL,
	[IDKhachHang] [bigint] NULL,
	[IDHangHoa] [bigint] NULL,
	[Gia] [float] NULL,
	[GhiChu] [ntext] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDChiTietGiaTheoKhach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuNhap]    Script Date: 7/9/2019 10:37:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuNhap](
	[IDChiTietPhieuNhap] [bigint] IDENTITY(1,1) NOT NULL,
	[IDHangHoa] [bigint] NULL,
	[IDPhieuNhap] [bigint] NULL,
	[SoLuong] [int] NULL,
	[DonGiaNhap] [float] NULL,
	[GhiChu] [ntext] NULL,
	[NgayNhapChiTiet] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDChiTietPhieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietPhieuXuat]    Script Date: 7/9/2019 10:37:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietPhieuXuat](
	[IDChiTietPhieuXuat] [bigint] IDENTITY(1,1) NOT NULL,
	[IDPhieuXuat] [bigint] NULL,
	[IDHangHoa] [bigint] NULL,
	[SoLuong] [int] NULL,
	[DonGiaXuat] [float] NULL,
	[GiaVon] [float] NULL,
	[IDKhachHang_ChiaHang] [bigint] NULL,
	[GhiChu] [ntext] NULL,
 CONSTRAINT [PK__ChiTietP__A30A71AE17C1588D] PRIMARY KEY CLUSTERED 
(
	[IDChiTietPhieuXuat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHangTuWeb]    Script Date: 7/9/2019 10:37:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHangTuWeb](
	[idDonHang] [bigint] IDENTITY(1,1) NOT NULL,
	[MaDonHang] [nvarchar](500) NULL,
	[HoTenNguoiNhan] [nvarchar](500) NULL,
	[SoDienThoai] [nvarchar](500) NULL,
	[DiaChi] [nvarchar](500) NULL,
	[GhiChu] [nvarchar](500) NULL,
	[NgayDatHang] [datetime] NULL,
	[TinhTrang] [nvarchar](50) NULL,
 CONSTRAINT [PK_DonHangTuWeb] PRIMARY KEY CLUSTERED 
(
	[idDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonViTinh]    Script Date: 7/9/2019 10:37:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonViTinh](
	[IDDonViTinh] [bigint] IDENTITY(1,1) NOT NULL,
	[TenDonViTinh] [nvarchar](max) NULL,
	[GhiChu] [ntext] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDDonViTinh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HangHoa]    Script Date: 7/9/2019 10:37:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HangHoa](
	[IDHangHoa] [bigint] IDENTITY(1,1) NOT NULL,
	[MaHangHoa] [nvarchar](max) NULL,
	[TenHangHoa] [nvarchar](max) NULL,
	[IDSize] [bigint] NULL,
	[IDMauSac] [bigint] NULL,
	[IDKieuDang] [bigint] NULL,
	[IDChatLieu] [int] NULL,
	[GhiChu] [ntext] NULL,
	[IDLoaiHangHoa] [bigint] NULL,
 CONSTRAINT [PK__HangHoa__73D03E02156034A7] PRIMARY KEY CLUSTERED 
(
	[IDHangHoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 7/9/2019 10:37:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[IDKhachHang] [bigint] IDENTITY(1,1) NOT NULL,
	[MaKhachHang] [nvarchar](max) NULL,
	[TenKhachHang] [nvarchar](max) NULL,
	[DienThoai] [nvarchar](max) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[GhiChu] [ntext] NULL,
	[MaSoThue] [nvarchar](50) NULL,
	[SoTaiKhoan] [nvarchar](50) NULL,
	[LoaiKhachHang] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHangNhom]    Script Date: 7/9/2019 10:37:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHangNhom](
	[idNhomKH] [int] NULL,
	[TenNhomKH] [nvarchar](500) NULL,
	[TenLoaiKH] [nvarchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kho]    Script Date: 7/9/2019 10:37:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kho](
	[IDKho] [bigint] IDENTITY(1,1) NOT NULL,
	[MaKho] [nvarchar](max) NULL,
	[TenKho] [nvarchar](max) NULL,
	[GhiChu] [ntext] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDKho] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KieuDang]    Script Date: 7/9/2019 10:37:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KieuDang](
	[IDKieuDang] [bigint] IDENTITY(1,1) NOT NULL,
	[MaKieuDang] [nvarchar](15) NULL,
	[TenKieuDang] [nvarchar](50) NULL,
	[GhiChu] [nvarchar](100) NULL,
 CONSTRAINT [PK_KieuDang] PRIMARY KEY CLUSTERED 
(
	[IDKieuDang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiHangCapCao]    Script Date: 7/9/2019 10:37:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiHangCapCao](
	[IDLoaiHangCapCao] [bigint] IDENTITY(1,1) NOT NULL,
	[TenLoaiHangCapCao] [nvarchar](max) NULL,
	[TenLoaiCap1] [nvarchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDLoaiHangCapCao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiHangHoa]    Script Date: 7/9/2019 10:37:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiHangHoa](
	[IDLoaiHangHoa] [bigint] IDENTITY(1,1) NOT NULL,
	[TenLoaiHangHoa] [nvarchar](max) NULL,
	[Gia] [float] NULL,
	[HinhAnh] [ntext] NULL,
	[IDLoaiHangCapCao] [bigint] NULL,
	[MaLoaiHangHoa] [nvarchar](max) NULL,
	[IDDonViTinh] [bigint] NULL,
	[GiaBanWeb] [float] NULL,
	[isHot] [bit] NULL,
	[isMoi] [bit] NULL,
	[NgayCapNhat] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDLoaiHangHoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MauSac]    Script Date: 7/9/2019 10:37:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MauSac](
	[IDMauSac] [bigint] IDENTITY(1,1) NOT NULL,
	[MaMauSac] [nvarchar](max) NULL,
	[TenMauSac] [nvarchar](max) NULL,
	[GhiChu] [ntext] NULL,
	[Code] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDMauSac] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 7/9/2019 10:37:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[IDNguoiDung] [bigint] IDENTITY(1,1) NOT NULL,
	[TaiKhoan] [nvarchar](250) NULL,
	[MatKhau] [nvarchar](250) NULL,
	[TenNguoiDung] [nvarchar](250) NULL,
	[Quyen] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[IDNguoiDung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 7/9/2019 10:37:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[IDNhaCungCap] [bigint] IDENTITY(1,1) NOT NULL,
	[MaNhaCungCap] [nvarchar](max) NULL,
	[TenNhaCungCap] [nvarchar](max) NULL,
	[SDT] [nvarchar](max) NULL,
	[DiaChi] [nvarchar](max) NULL,
	[GhiChu] [ntext] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDNhaCungCap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhomHangHoa]    Script Date: 7/9/2019 10:37:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhomHangHoa](
	[idNhomHangHoa] [int] IDENTITY(1,1) NOT NULL,
	[MaNhomHangHoa] [nvarchar](50) NULL,
	[TenNhomHangHoa] [nvarchar](50) NULL,
	[GhiChu] [text] NULL,
 CONSTRAINT [PK_NhomHangHoa] PRIMARY KEY CLUSTERED 
(
	[idNhomHangHoa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuNhap]    Script Date: 7/9/2019 10:37:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuNhap](
	[IDPhieuNhap] [bigint] IDENTITY(1,1) NOT NULL,
	[MaPhieuNhap] [nvarchar](max) NULL,
	[NgayNhap] [datetime] NULL,
	[GhiChu] [ntext] NULL,
	[IDNhaCungCap] [bigint] NULL,
	[IDKho] [bigint] NULL,
	[IDKhachHang_TraHang] [bigint] NULL,
	[LoaiPhieuNhap] [nvarchar](10) NULL,
	[TienDaThanhToan] [float] NULL,
 CONSTRAINT [PK__PhieuNha__4A581F6DB1852C39] PRIMARY KEY CLUSTERED 
(
	[IDPhieuNhap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuTraNo]    Script Date: 7/9/2019 10:37:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuTraNo](
	[IDPhieuTraNo] [bigint] IDENTITY(1,1) NOT NULL,
	[MaPhieuTraNo] [nvarchar](max) NULL,
	[Ngay] [datetime] NULL,
	[GhiChu] [ntext] NULL,
	[IDKhachHang] [bigint] NULL,
	[SoTien] [float] NULL,
	[NguoiDung] [nvarchar](500) NULL,
	[NgayThaoTac] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDPhieuTraNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuTraNoChoKhach]    Script Date: 7/9/2019 10:37:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuTraNoChoKhach](
	[IDPhieuTraNo] [bigint] IDENTITY(1,1) NOT NULL,
	[MaPhieuTraNo] [nvarchar](10) NULL,
	[Ngay] [datetime] NULL,
	[GhiChu] [nvarchar](50) NULL,
	[IDKhachHang] [bigint] NULL,
	[SoTien] [float] NULL,
	[NguoiDung] [nvarchar](50) NULL,
	[NgayThaoTac] [datetime] NULL,
 CONSTRAINT [PK_PhieuTraNoChoKhach] PRIMARY KEY CLUSTERED 
(
	[IDPhieuTraNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuTraNoNhaCungCap]    Script Date: 7/9/2019 10:37:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuTraNoNhaCungCap](
	[IDPhieuTraNoNhaCungCap] [bigint] IDENTITY(1,1) NOT NULL,
	[MaPhieuTraNoNhaCungCap] [nvarchar](max) NULL,
	[Ngay] [datetime] NULL,
	[GhiChu] [ntext] NULL,
	[IDNhaCungCap] [bigint] NULL,
	[SoTien] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDPhieuTraNoNhaCungCap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhieuXuat]    Script Date: 7/9/2019 10:37:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhieuXuat](
	[IDPhieuXuat] [bigint] IDENTITY(1,1) NOT NULL,
	[MaPhieuXuat] [nvarchar](max) NULL,
	[NgayXuat] [datetime] NULL,
	[GhiChu] [ntext] NULL,
	[IDKhachHang] [bigint] NULL,
	[TienThanhToan] [float] NULL,
	[LoaiPhieuXuat] [nvarchar](15) NULL,
	[IDKho] [bigint] NULL,
 CONSTRAINT [PK__PhieuXua__BA402C537F54C267] PRIMARY KEY CLUSTERED 
(
	[IDPhieuXuat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Size]    Script Date: 7/9/2019 10:37:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Size](
	[IDSize] [bigint] IDENTITY(1,1) NOT NULL,
	[MaSize] [nvarchar](max) NULL,
	[TenSize] [nvarchar](max) NULL,
	[GhiChu] [ntext] NULL,
PRIMARY KEY CLUSTERED 
(
	[IDSize] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_HinhAnhLoaiHangHoa]    Script Date: 7/9/2019 10:37:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_HinhAnhLoaiHangHoa](
	[IDHinhAnh] [bigint] IDENTITY(1,1) NOT NULL,
	[IDLoaiHangHoa] [bigint] NULL,
	[Url] [nvarchar](max) NULL,
 CONSTRAINT [PK_tb_HinhAnhLoaiHangHoa] PRIMARY KEY CLUSTERED 
(
	[IDHinhAnh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_PhieuThuNoNhaCungCap]    Script Date: 7/9/2019 10:37:02 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_PhieuThuNoNhaCungCap](
	[IDPhieuThuNoNhaCungCap] [bigint] IDENTITY(1,1) NOT NULL,
	[MaPhieuTraNoNhaCungCap] [nvarchar](15) NULL,
	[Ngay] [datetime] NULL,
	[GhiChu] [nvarchar](100) NULL,
	[IDNhaCungCap] [bigint] NULL,
	[SoTien] [float] NULL,
 CONSTRAINT [PK_tb_PhieuThuNoNhaCungCap] PRIMARY KEY CLUSTERED 
(
	[IDPhieuThuNoNhaCungCap] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BangLog] ON 

INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20075, N'admin', N'Thêm mới phiếu nhập hàng PN--2162019142052', CAST(N'2019-06-21T14:22:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20076, N'admin', N'Xóa hết phiếu nhập hàng PN--2162019142052', CAST(N'2019-06-21T14:26:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20077, N'admin', N'Thêm mới phiếu nhập hàng PN--2162019161220', CAST(N'2019-06-21T16:12:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20079, N'admin', N'Thêm mới phiếu nhập hàng PN--2162019161359', CAST(N'2019-06-21T16:14:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20080, N'admin', N'Thêm mới phiếu trả hàng PTH-4-226201991115', CAST(N'2019-06-22T09:11:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20081, N'admin', N'Thêm mới phiếu nhập hàng PN-5-226201991333', CAST(N'2019-06-22T09:13:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20082, N'admin', N'Xóa hết phiếu nhập hàng PN-5-226201991333', CAST(N'2019-06-22T09:13:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20083, N'admin', N'Thêm mới phiếu nhập hàng PN-5-226201995450', CAST(N'2019-06-22T09:54:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20084, N'admin', N'Sửa phiếu nhập hàng PTH-4-226201991115', CAST(N'2019-06-22T10:37:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20085, N'admin', N'Thêm mới phiếu trả hàng PTH-7-226201910426', CAST(N'2019-06-22T10:42:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20086, N'admin', N'Xóa hết phiếu nhập hàng PTH-7-226201910426', CAST(N'2019-06-22T10:43:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20087, N'admin', N'Xóa hết phiếu nhập hàng PN-5-226201995450', CAST(N'2019-06-22T10:52:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20088, N'admin', N'Thêm hàng hóa phiếu nhập hàng PN--2162019161359', CAST(N'2019-06-22T10:53:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20089, N'admin', N'Sửa số lượng phiếu nhập hàng PN--2162019161359', CAST(N'2019-06-22T10:53:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20090, N'admin', N'Thêm hàng hóa phiếu nhập hàng PN--2162019161359', CAST(N'2019-06-22T10:59:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20091, N'admin', N'Sửa phiếu nhập hàng PN--2162019161359', CAST(N'2019-06-22T10:59:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20092, N'admin', N'Thêm mới phiếu xuất PBH--22620191102', CAST(N'2019-06-22T11:00:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20094, N'admin', N'Thêm mới phiếu xuất PBH-2-226201911115', CAST(N'2019-06-22T11:01:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20095, N'admin', N'Thêm hàng hóa phiếu nhập hàng PN--2162019161359', CAST(N'2019-06-22T12:33:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20096, N'admin', N'Thêm hàng hóa phiếu nhập hàng PN--2162019161359', CAST(N'2019-06-22T12:33:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20097, N'admin', N'Thêm hàng hóa phiếu nhập hàng PN--2162019161359', CAST(N'2019-06-22T12:33:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20098, N'admin', N'Thêm hàng hóa phiếu nhập hàng PN--2162019161359', CAST(N'2019-06-22T14:19:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20099, N'admin', N'Sửa phiếu nhập hàng PN--2162019161359', CAST(N'2019-06-22T14:19:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20100, N'admin', N'Thêm hàng hóa phiếu nhập hàng PN--2162019161359', CAST(N'2019-06-22T15:23:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20101, N'admin', N'Sửa số lượng phiếu nhập hàng PN--2162019161359', CAST(N'2019-06-22T15:23:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20102, N'admin', N'Sửa phiếu nhập hàng PN--2162019161359', CAST(N'2019-06-22T15:23:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20105, N'admin', N'Thêm mới phiếu xuất PBH-6-24620191239', CAST(N'2019-06-24T12:03:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20106, N'admin', N'Xóa hết phiếu xuất PBH-2-226201911115', CAST(N'2019-06-24T12:05:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20107, N'admin', N'Xóa hết phiếu xuất PBH--22620191102', CAST(N'2019-06-24T12:05:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20108, N'admin', N'Xóa hết phiếu xuất PBH-6-24620191239', CAST(N'2019-06-24T12:05:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20109, N'admin', N'Thêm mới phiếu nhập hàng PN-4-2462019121512', CAST(N'2019-06-24T12:16:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20110, N'admin', N'Xóa hết phiếu nhập hàng PN-4-2462019121512', CAST(N'2019-06-24T12:24:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20111, N'admin', N'Xóa hết phiếu nhập hàng ', CAST(N'2019-06-24T12:24:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20112, N'admin', N'Thêm mới phiếu nhập hàng PN-4-2562019113016', CAST(N'2019-06-25T11:30:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20113, N'admin', N'Thêm hàng hóa phiếu nhập hàng PN-4-2562019113016', CAST(N'2019-06-25T11:30:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20114, N'admin', N'Sửa phiếu nhập hàng PN-4-2562019113016', CAST(N'2019-06-25T11:30:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20115, N'admin', N'Thêm mới phiếu nhập hàng PN-10-2762019101331', CAST(N'2019-06-27T10:13:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20116, N'admin', N'Thêm mới phiếu nhập hàng PN-11-2762019143955', CAST(N'2019-06-27T14:40:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20117, N'admin', N'Xóa hết phiếu nhập hàng PN-11-2762019143955', CAST(N'2019-06-27T15:46:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20118, N'admin', N'Xóa hết phiếu nhập hàng ', CAST(N'2019-06-27T15:46:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20119, N'admin', N'Thêm mới phiếu nhập hàng PN-11-276201916917', CAST(N'2019-06-27T16:09:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20120, N'admin', N'Thêm mới phiếu nhập hàng PN-13-276201916484', CAST(N'2019-06-27T16:48:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20122, N'admin', N'Thêm mới phiếu trả hàng PTH-14-28620199282', CAST(N'2019-06-28T09:28:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20123, N'admin', N'Thêm mới phiếu nhập hàng PN-15-286201992852', CAST(N'2019-06-28T09:28:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20124, N'admin', N'Xóa hết phiếu nhập hàng PN-15-286201992852', CAST(N'2019-06-28T10:29:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20125, N'admin', N'Xóa hết phiếu nhập hàng ', CAST(N'2019-06-28T10:29:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20126, N'admin', N'Xóa hết phiếu nhập hàng PN-11-276201916917', CAST(N'2019-06-28T10:29:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20127, N'admin', N'Xóa hết phiếu nhập hàng PN-10-2762019101331', CAST(N'2019-06-28T10:29:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20128, N'admin', N'Xóa hết phiếu nhập hàng ', CAST(N'2019-06-28T10:29:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20129, N'admin', N'Thêm mới phiếu trả hàng PTH-15-286201911357', CAST(N'2019-06-28T11:04:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20130, N'admin', N'Thêm hàng hóa phiếu nhập hàng PTH-15-286201911357', CAST(N'2019-06-28T11:04:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20131, N'admin', N'Sửa phiếu nhập hàng PTH-15-286201911357', CAST(N'2019-06-28T11:04:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20132, N'admin', N'Xóa hết phiếu nhập hàng PTH-14-28620199282', CAST(N'2019-06-28T11:05:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20133, N'admin', N'Xóa hết phiếu nhập hàng ', CAST(N'2019-06-28T11:05:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20134, N'admin', N'Thêm mới phiếu trả hàng PTH-17-286201915200', CAST(N'2019-06-28T15:24:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20135, N'admin', N'Thêm hàng hóa phiếu nhập hàng PTH-17-286201915200', CAST(N'2019-06-28T15:45:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20136, N'admin', N'Sửa phiếu nhập hàng PTH-17-286201915200', CAST(N'2019-06-28T15:45:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20139, N'admin', N'Sửa thông tin phiếu xuất hàng PBH-6-2862019155253', CAST(N'2019-06-28T15:58:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20140, N'admin', N'Thêm mới phiếu xuất PBH-8-27201991826', CAST(N'2019-07-02T09:20:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20141, N'admin', N'Thêm mới phiếu xuất PBH-9-37201992350', CAST(N'2019-07-03T09:23:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20142, N'admin', N'Thêm mới phiếu xuất PBH-10-3720199298', CAST(N'2019-07-03T09:29:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20143, N'admin', N'Thêm mới phiếu nhập hàng PN-18-37201994019', CAST(N'2019-07-03T09:40:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20144, N'admin', N'Thêm mới phiếu nhập hàng PN-19-372019154136', CAST(N'2019-07-03T15:41:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20145, N'admin', N'Thêm mới phiếu nhập hàng PN-20-372019154711', CAST(N'2019-07-03T15:47:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20146, N'admin', N'Thêm mới phiếu nhập hàng PN-21-372019165054', CAST(N'2019-07-03T16:50:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20147, N'admin', N'Thêm mới phiếu nhập hàng PN-22-47201992430', CAST(N'2019-07-04T09:24:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20148, N'admin', N'Xóa hết phiếu nhập hàng PN-22-47201992430', CAST(N'2019-07-04T09:32:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20149, N'admin', N'Xóa hết phiếu nhập hàng ', CAST(N'2019-07-04T09:32:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20150, N'admin', N'Xóa hết phiếu nhập hàng PN-21-372019165054', CAST(N'2019-07-04T09:32:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20151, N'admin', N'Xóa hết phiếu nhập hàng PN-20-372019154711', CAST(N'2019-07-04T09:32:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20152, N'admin', N'Xóa hết phiếu nhập hàng ', CAST(N'2019-07-04T09:32:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20153, N'admin', N'Xóa hết phiếu nhập hàng PN-19-372019154136', CAST(N'2019-07-04T09:32:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20154, N'admin', N'Xóa hết phiếu nhập hàng ', CAST(N'2019-07-04T09:33:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20155, N'admin', N'Xóa hết phiếu nhập hàng PN-18-37201994019', CAST(N'2019-07-04T09:33:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20156, N'admin', N'Xóa hết phiếu nhập hàng ', CAST(N'2019-07-04T09:33:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20078, N'admin', N'Xóa hết phiếu nhập hàng PN--2162019161220', CAST(N'2019-06-21T16:13:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20093, N'admin', N'Xóa hết phiếu nhập hàng PTH-4-226201991115', CAST(N'2019-06-22T11:00:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20103, N'admin', N'Thêm hàng hóa phiếu nhập hàng PN--2162019161359', CAST(N'2019-06-22T17:05:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20104, N'admin', N'Sửa phiếu nhập hàng PN--2162019161359', CAST(N'2019-06-22T17:05:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20121, N'admin', N'Thêm hàng hóa phiếu nhập hàng PN-13-276201916484', CAST(N'2019-06-27T16:49:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20137, N'admin', N'Thêm mới phiếu xuất PBH-6-2862019155253', CAST(N'2019-06-28T15:52:00.000' AS DateTime))
INSERT [dbo].[BangLog] ([IDBangLog], [TaiKhoan], [ThaoTac], [NgayGio]) VALUES (20138, N'admin', N'Sửa thông tin phiếu xuất hàng PBH-6-2862019155253', CAST(N'2019-06-28T15:53:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[BangLog] OFF
SET IDENTITY_INSERT [dbo].[BlackList] ON 

INSERT [dbo].[BlackList] ([IDBlackList], [IDLoaiHangHoa]) VALUES (1, 1)
INSERT [dbo].[BlackList] ([IDBlackList], [IDLoaiHangHoa]) VALUES (2, 2)
INSERT [dbo].[BlackList] ([IDBlackList], [IDLoaiHangHoa]) VALUES (4, 4)
INSERT [dbo].[BlackList] ([IDBlackList], [IDLoaiHangHoa]) VALUES (5, 5)
INSERT [dbo].[BlackList] ([IDBlackList], [IDLoaiHangHoa]) VALUES (7, 7)
SET IDENTITY_INSERT [dbo].[BlackList] OFF
SET IDENTITY_INSERT [dbo].[ChatLieu] ON 

INSERT [dbo].[ChatLieu] ([IDChatLieu], [MaChatLieu], [TenChatLieu], [GhiChu]) VALUES (1, N'MCL1', N'Cotton', N'')
INSERT [dbo].[ChatLieu] ([IDChatLieu], [MaChatLieu], [TenChatLieu], [GhiChu]) VALUES (2, N'MCL2', N'Kaki', N'')
INSERT [dbo].[ChatLieu] ([IDChatLieu], [MaChatLieu], [TenChatLieu], [GhiChu]) VALUES (3, N'MCL3', N'Jean', N'')
SET IDENTITY_INSERT [dbo].[ChatLieu] OFF
SET IDENTITY_INSERT [dbo].[ChiTietGiaTheoKhach] ON 

INSERT [dbo].[ChiTietGiaTheoKhach] ([IDChiTietGiaTheoKhach], [IDKhachHang], [IDHangHoa], [Gia], [GhiChu]) VALUES (1, 1, 1, 25000, N'')
INSERT [dbo].[ChiTietGiaTheoKhach] ([IDChiTietGiaTheoKhach], [IDKhachHang], [IDHangHoa], [Gia], [GhiChu]) VALUES (2, 1, 2, 30000, N'')
INSERT [dbo].[ChiTietGiaTheoKhach] ([IDChiTietGiaTheoKhach], [IDKhachHang], [IDHangHoa], [Gia], [GhiChu]) VALUES (3, 1, 7, 20000, N'')
INSERT [dbo].[ChiTietGiaTheoKhach] ([IDChiTietGiaTheoKhach], [IDKhachHang], [IDHangHoa], [Gia], [GhiChu]) VALUES (4, 2, 7, 20000, N'')
INSERT [dbo].[ChiTietGiaTheoKhach] ([IDChiTietGiaTheoKhach], [IDKhachHang], [IDHangHoa], [Gia], [GhiChu]) VALUES (5, 2, 1, 0, N'')
INSERT [dbo].[ChiTietGiaTheoKhach] ([IDChiTietGiaTheoKhach], [IDKhachHang], [IDHangHoa], [Gia], [GhiChu]) VALUES (6, 2, 2, 0, N'')
SET IDENTITY_INSERT [dbo].[ChiTietGiaTheoKhach] OFF
SET IDENTITY_INSERT [dbo].[ChiTietPhieuNhap] ON 

INSERT [dbo].[ChiTietPhieuNhap] ([IDChiTietPhieuNhap], [IDHangHoa], [IDPhieuNhap], [SoLuong], [DonGiaNhap], [GhiChu], [NgayNhapChiTiet]) VALUES (1, 1, 3, 50, 20000, N'', NULL)
INSERT [dbo].[ChiTietPhieuNhap] ([IDChiTietPhieuNhap], [IDHangHoa], [IDPhieuNhap], [SoLuong], [DonGiaNhap], [GhiChu], [NgayNhapChiTiet]) VALUES (3, 4, 3, 15, 36000, N'', NULL)
INSERT [dbo].[ChiTietPhieuNhap] ([IDChiTietPhieuNhap], [IDHangHoa], [IDPhieuNhap], [SoLuong], [DonGiaNhap], [GhiChu], [NgayNhapChiTiet]) VALUES (4, 2, 3, 20, 20000, N'', NULL)
INSERT [dbo].[ChiTietPhieuNhap] ([IDChiTietPhieuNhap], [IDHangHoa], [IDPhieuNhap], [SoLuong], [DonGiaNhap], [GhiChu], [NgayNhapChiTiet]) VALUES (5, 3, 3, 5, 20000, N'', NULL)
INSERT [dbo].[ChiTietPhieuNhap] ([IDChiTietPhieuNhap], [IDHangHoa], [IDPhieuNhap], [SoLuong], [DonGiaNhap], [GhiChu], [NgayNhapChiTiet]) VALUES (6, 1, 9, 3, 20000, N'', NULL)
INSERT [dbo].[ChiTietPhieuNhap] ([IDChiTietPhieuNhap], [IDHangHoa], [IDPhieuNhap], [SoLuong], [DonGiaNhap], [GhiChu], [NgayNhapChiTiet]) VALUES (7, 1, 13, 3, 20000, N'', NULL)
INSERT [dbo].[ChiTietPhieuNhap] ([IDChiTietPhieuNhap], [IDHangHoa], [IDPhieuNhap], [SoLuong], [DonGiaNhap], [GhiChu], [NgayNhapChiTiet]) VALUES (8, 1, 16, 6, 20000, N'', NULL)
INSERT [dbo].[ChiTietPhieuNhap] ([IDChiTietPhieuNhap], [IDHangHoa], [IDPhieuNhap], [SoLuong], [DonGiaNhap], [GhiChu], [NgayNhapChiTiet]) VALUES (9, 3, 17, 12, 20000, N'', NULL)
SET IDENTITY_INSERT [dbo].[ChiTietPhieuNhap] OFF
SET IDENTITY_INSERT [dbo].[ChiTietPhieuXuat] ON 

INSERT [dbo].[ChiTietPhieuXuat] ([IDChiTietPhieuXuat], [IDPhieuXuat], [IDHangHoa], [SoLuong], [DonGiaXuat], [GiaVon], [IDKhachHang_ChiaHang], [GhiChu]) VALUES (2, 4, 1, 20, 20000, NULL, 1, NULL)
INSERT [dbo].[ChiTietPhieuXuat] ([IDChiTietPhieuXuat], [IDPhieuXuat], [IDHangHoa], [SoLuong], [DonGiaXuat], [GiaVon], [IDKhachHang_ChiaHang], [GhiChu]) VALUES (3, 5, 3, 5, 20000, NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[ChiTietPhieuXuat] OFF
SET IDENTITY_INSERT [dbo].[DonViTinh] ON 

INSERT [dbo].[DonViTinh] ([IDDonViTinh], [TenDonViTinh], [GhiChu]) VALUES (1, N'Lô', N'')
SET IDENTITY_INSERT [dbo].[DonViTinh] OFF
SET IDENTITY_INSERT [dbo].[HangHoa] ON 

INSERT [dbo].[HangHoa] ([IDHangHoa], [MaHangHoa], [TenHangHoa], [IDSize], [IDMauSac], [IDKieuDang], [IDChatLieu], [GhiChu], [IDLoaiHangHoa]) VALUES (1, NULL, NULL, 1, 1, 1, 1, N'', 1)
INSERT [dbo].[HangHoa] ([IDHangHoa], [MaHangHoa], [TenHangHoa], [IDSize], [IDMauSac], [IDKieuDang], [IDChatLieu], [GhiChu], [IDLoaiHangHoa]) VALUES (2, NULL, NULL, 2, 2, 2, 2, N'', 1)
INSERT [dbo].[HangHoa] ([IDHangHoa], [MaHangHoa], [TenHangHoa], [IDSize], [IDMauSac], [IDKieuDang], [IDChatLieu], [GhiChu], [IDLoaiHangHoa]) VALUES (3, NULL, NULL, 1, 2, 2, 2, N'', 1)
INSERT [dbo].[HangHoa] ([IDHangHoa], [MaHangHoa], [TenHangHoa], [IDSize], [IDMauSac], [IDKieuDang], [IDChatLieu], [GhiChu], [IDLoaiHangHoa]) VALUES (4, NULL, NULL, 1, 3, 1, 1, N'', 2)
INSERT [dbo].[HangHoa] ([IDHangHoa], [MaHangHoa], [TenHangHoa], [IDSize], [IDMauSac], [IDKieuDang], [IDChatLieu], [GhiChu], [IDLoaiHangHoa]) VALUES (5, NULL, NULL, 3, 1, 1, 1, N'', 4)
INSERT [dbo].[HangHoa] ([IDHangHoa], [MaHangHoa], [TenHangHoa], [IDSize], [IDMauSac], [IDKieuDang], [IDChatLieu], [GhiChu], [IDLoaiHangHoa]) VALUES (8, NULL, NULL, 1, 1, 1, 2, N'', 5)
INSERT [dbo].[HangHoa] ([IDHangHoa], [MaHangHoa], [TenHangHoa], [IDSize], [IDMauSac], [IDKieuDang], [IDChatLieu], [GhiChu], [IDLoaiHangHoa]) VALUES (9, NULL, NULL, 1, 1, 1, 1, N'', 7)
INSERT [dbo].[HangHoa] ([IDHangHoa], [MaHangHoa], [TenHangHoa], [IDSize], [IDMauSac], [IDKieuDang], [IDChatLieu], [GhiChu], [IDLoaiHangHoa]) VALUES (10, NULL, NULL, 1, 2, 1, 1, N'', 7)
SET IDENTITY_INSERT [dbo].[HangHoa] OFF
SET IDENTITY_INSERT [dbo].[KhachHang] ON 

INSERT [dbo].[KhachHang] ([IDKhachHang], [MaKhachHang], [TenKhachHang], [DienThoai], [DiaChi], [GhiChu], [MaSoThue], [SoTaiKhoan], [LoaiKhachHang], [Email]) VALUES (1, N'KH1', N'Hà', N'', N'', N'', NULL, NULL, NULL, NULL)
INSERT [dbo].[KhachHang] ([IDKhachHang], [MaKhachHang], [TenKhachHang], [DienThoai], [DiaChi], [GhiChu], [MaSoThue], [SoTaiKhoan], [LoaiKhachHang], [Email]) VALUES (2, N'MKH2', N'Bảo', N'0868877946', N'175 Quốc Lộ 13, Phường 26, Quận Bình Thạnh', N'', N'23132131', N'0987896543', N'Khách sỉ', N'redromany121@gmail.com')
SET IDENTITY_INSERT [dbo].[KhachHang] OFF
INSERT [dbo].[KhachHangNhom] ([idNhomKH], [TenNhomKH], [TenLoaiKH]) VALUES (1, N'Công ty', N'Khách sỉ')
INSERT [dbo].[KhachHangNhom] ([idNhomKH], [TenNhomKH], [TenLoaiKH]) VALUES (2, N'Sạp Chợ', N'Khách sỉ')
INSERT [dbo].[KhachHangNhom] ([idNhomKH], [TenNhomKH], [TenLoaiKH]) VALUES (3, N'Shop', N'Khách sỉ')
INSERT [dbo].[KhachHangNhom] ([idNhomKH], [TenNhomKH], [TenLoaiKH]) VALUES (4, N'Người bỏ mối', N'Khách sỉ')
INSERT [dbo].[KhachHangNhom] ([idNhomKH], [TenNhomKH], [TenLoaiKH]) VALUES (5, N'Khách mua 1 lần', N'Khách lẻ')
SET IDENTITY_INSERT [dbo].[Kho] ON 

INSERT [dbo].[Kho] ([IDKho], [MaKho], [TenKho], [GhiChu]) VALUES (1, N'MK1', N'Kho Bình Thạnh', N'')
SET IDENTITY_INSERT [dbo].[Kho] OFF
SET IDENTITY_INSERT [dbo].[KieuDang] ON 

INSERT [dbo].[KieuDang] ([IDKieuDang], [MaKieuDang], [TenKieuDang], [GhiChu]) VALUES (1, N'MKD1', N'SlimFit', N'')
INSERT [dbo].[KieuDang] ([IDKieuDang], [MaKieuDang], [TenKieuDang], [GhiChu]) VALUES (2, N'MKD2', N'OutFit', N'')
SET IDENTITY_INSERT [dbo].[KieuDang] OFF
SET IDENTITY_INSERT [dbo].[LoaiHangCapCao] ON 

INSERT [dbo].[LoaiHangCapCao] ([IDLoaiHangCapCao], [TenLoaiHangCapCao], [TenLoaiCap1]) VALUES (1, N'Sida', N'Cơ Bản')
SET IDENTITY_INSERT [dbo].[LoaiHangCapCao] OFF
SET IDENTITY_INSERT [dbo].[LoaiHangHoa] ON 

INSERT [dbo].[LoaiHangHoa] ([IDLoaiHangHoa], [TenLoaiHangHoa], [Gia], [HinhAnh], [IDLoaiHangCapCao], [MaLoaiHangHoa], [IDDonViTinh], [GiaBanWeb], [isHot], [isMoi], [NgayCapNhat]) VALUES (1, N'TEST', 20000, N'HinhAnh/HinhThe1.jpg372019152733636977644539334653.png', 1, N'MH1', 1, 30000, 0, 0, CAST(N'2019-07-03' AS Date))
INSERT [dbo].[LoaiHangHoa] ([IDLoaiHangHoa], [TenLoaiHangHoa], [Gia], [HinhAnh], [IDLoaiHangCapCao], [MaLoaiHangHoa], [IDDonViTinh], [GiaBanWeb], [isHot], [isMoi], [NgayCapNhat]) VALUES (2, N'TEST', 36000, N'', 1, N'MH2', 1, 25000, 0, 0, CAST(N'2019-06-26' AS Date))
INSERT [dbo].[LoaiHangHoa] ([IDLoaiHangHoa], [TenLoaiHangHoa], [Gia], [HinhAnh], [IDLoaiHangCapCao], [MaLoaiHangHoa], [IDDonViTinh], [GiaBanWeb], [isHot], [isMoi], [NgayCapNhat]) VALUES (4, N'TEST', 20000, N'', 1, N'MH3', 1, 25000, 0, 0, CAST(N'2019-06-26' AS Date))
INSERT [dbo].[LoaiHangHoa] ([IDLoaiHangHoa], [TenLoaiHangHoa], [Gia], [HinhAnh], [IDLoaiHangCapCao], [MaLoaiHangHoa], [IDDonViTinh], [GiaBanWeb], [isHot], [isMoi], [NgayCapNhat]) VALUES (5, N'TEST-4', 40000, N'', 1, N'MH4', 1, 50000, 0, 0, CAST(N'2019-06-26' AS Date))
INSERT [dbo].[LoaiHangHoa] ([IDLoaiHangHoa], [TenLoaiHangHoa], [Gia], [HinhAnh], [IDLoaiHangCapCao], [MaLoaiHangHoa], [IDDonViTinh], [GiaBanWeb], [isHot], [isMoi], [NgayCapNhat]) VALUES (7, N'TEST', 0, N'', 1, N'mh6', 1, 0, 0, 0, CAST(N'2019-06-27' AS Date))
SET IDENTITY_INSERT [dbo].[LoaiHangHoa] OFF
SET IDENTITY_INSERT [dbo].[MauSac] ON 

INSERT [dbo].[MauSac] ([IDMauSac], [MaMauSac], [TenMauSac], [GhiChu], [Code]) VALUES (1, N'#ff0000', N'Đỏ', N'', N'#ff0000')
INSERT [dbo].[MauSac] ([IDMauSac], [MaMauSac], [TenMauSac], [GhiChu], [Code]) VALUES (2, N'#000000', N'Đen', N'', N'#000000')
INSERT [dbo].[MauSac] ([IDMauSac], [MaMauSac], [TenMauSac], [GhiChu], [Code]) VALUES (3, N'#001aff', N'Xanh', N'', N'#001aff')
SET IDENTITY_INSERT [dbo].[MauSac] OFF
SET IDENTITY_INSERT [dbo].[NguoiDung] ON 

INSERT [dbo].[NguoiDung] ([IDNguoiDung], [TaiKhoan], [MatKhau], [TenNguoiDung], [Quyen]) VALUES (2, N'admin', N'123', N'Administrator', N'Admin')
SET IDENTITY_INSERT [dbo].[NguoiDung] OFF
SET IDENTITY_INSERT [dbo].[NhaCungCap] ON 

INSERT [dbo].[NhaCungCap] ([IDNhaCungCap], [MaNhaCungCap], [TenNhaCungCap], [SDT], [DiaChi], [GhiChu]) VALUES (1, N'MNCC1', N'NGB', N'', N'', N'')
INSERT [dbo].[NhaCungCap] ([IDNhaCungCap], [MaNhaCungCap], [TenNhaCungCap], [SDT], [DiaChi], [GhiChu]) VALUES (2, N'MNCC2', N'SAM', N'', N'', N'')
SET IDENTITY_INSERT [dbo].[NhaCungCap] OFF
SET IDENTITY_INSERT [dbo].[NhomHangHoa] ON 

INSERT [dbo].[NhomHangHoa] ([idNhomHangHoa], [MaNhomHangHoa], [TenNhomHangHoa], [GhiChu]) VALUES (1, N'MN1', N'Cơ Bản', N'')
SET IDENTITY_INSERT [dbo].[NhomHangHoa] OFF
SET IDENTITY_INSERT [dbo].[PhieuNhap] ON 

INSERT [dbo].[PhieuNhap] ([IDPhieuNhap], [MaPhieuNhap], [NgayNhap], [GhiChu], [IDNhaCungCap], [IDKho], [IDKhachHang_TraHang], [LoaiPhieuNhap], [TienDaThanhToan]) VALUES (3, N'PN--2162019161359', CAST(N'2019-06-21T00:00:00.000' AS DateTime), N'', 1, 1, NULL, NULL, 1000000)
INSERT [dbo].[PhieuNhap] ([IDPhieuNhap], [MaPhieuNhap], [NgayNhap], [GhiChu], [IDNhaCungCap], [IDKho], [IDKhachHang_TraHang], [LoaiPhieuNhap], [TienDaThanhToan]) VALUES (9, N'PN-4-2562019113016', CAST(N'2019-06-25T00:00:00.000' AS DateTime), N'', 1, 1, NULL, NULL, 0)
INSERT [dbo].[PhieuNhap] ([IDPhieuNhap], [MaPhieuNhap], [NgayNhap], [GhiChu], [IDNhaCungCap], [IDKho], [IDKhachHang_TraHang], [LoaiPhieuNhap], [TienDaThanhToan]) VALUES (13, N'PN-13-276201916484', CAST(N'2019-06-27T00:00:00.000' AS DateTime), N'', 1, 1, NULL, NULL, 0)
INSERT [dbo].[PhieuNhap] ([IDPhieuNhap], [MaPhieuNhap], [NgayNhap], [GhiChu], [IDNhaCungCap], [IDKho], [IDKhachHang_TraHang], [LoaiPhieuNhap], [TienDaThanhToan]) VALUES (16, N'PTH-15-286201911357', CAST(N'2019-06-28T00:00:00.000' AS DateTime), N'', 1, 1, 1, N'TraHang', 0)
INSERT [dbo].[PhieuNhap] ([IDPhieuNhap], [MaPhieuNhap], [NgayNhap], [GhiChu], [IDNhaCungCap], [IDKho], [IDKhachHang_TraHang], [LoaiPhieuNhap], [TienDaThanhToan]) VALUES (17, N'PTH-17-286201915200', CAST(N'2019-06-28T00:00:00.000' AS DateTime), N'', 2, 1, 2, N'TraHang', 0)
SET IDENTITY_INSERT [dbo].[PhieuNhap] OFF
SET IDENTITY_INSERT [dbo].[PhieuXuat] ON 

INSERT [dbo].[PhieuXuat] ([IDPhieuXuat], [MaPhieuXuat], [NgayXuat], [GhiChu], [IDKhachHang], [TienThanhToan], [LoaiPhieuXuat], [IDKho]) VALUES (4, N'PBH-3-246201994245', CAST(N'2019-06-24T00:00:00.000' AS DateTime), N'', NULL, NULL, N'PhieuChiaHang', 1)
INSERT [dbo].[PhieuXuat] ([IDPhieuXuat], [MaPhieuXuat], [NgayXuat], [GhiChu], [IDKhachHang], [TienThanhToan], [LoaiPhieuXuat], [IDKho]) VALUES (5, N'PBH-5-2462019111537', CAST(N'2019-06-24T00:00:00.000' AS DateTime), N'', NULL, NULL, N'PhieuChiaHang', 1)
INSERT [dbo].[PhieuXuat] ([IDPhieuXuat], [MaPhieuXuat], [NgayXuat], [GhiChu], [IDKhachHang], [TienThanhToan], [LoaiPhieuXuat], [IDKho]) VALUES (7, N'PBH-6-2862019155253', CAST(N'2019-06-28T00:00:00.000' AS DateTime), N'', 1, 0, NULL, 1)
INSERT [dbo].[PhieuXuat] ([IDPhieuXuat], [MaPhieuXuat], [NgayXuat], [GhiChu], [IDKhachHang], [TienThanhToan], [LoaiPhieuXuat], [IDKho]) VALUES (8, N'PBH-8-27201991826', CAST(N'2019-07-02T00:00:00.000' AS DateTime), N'', 2, 0, NULL, 1)
INSERT [dbo].[PhieuXuat] ([IDPhieuXuat], [MaPhieuXuat], [NgayXuat], [GhiChu], [IDKhachHang], [TienThanhToan], [LoaiPhieuXuat], [IDKho]) VALUES (9, N'PBH-9-37201992350', CAST(N'2019-07-03T00:00:00.000' AS DateTime), N'', 2, 0, NULL, 1)
INSERT [dbo].[PhieuXuat] ([IDPhieuXuat], [MaPhieuXuat], [NgayXuat], [GhiChu], [IDKhachHang], [TienThanhToan], [LoaiPhieuXuat], [IDKho]) VALUES (10, N'PBH-10-3720199298', CAST(N'2019-07-03T00:00:00.000' AS DateTime), N'', 1, 0, NULL, 1)
SET IDENTITY_INSERT [dbo].[PhieuXuat] OFF
SET IDENTITY_INSERT [dbo].[Size] ON 

INSERT [dbo].[Size] ([IDSize], [MaSize], [TenSize], [GhiChu]) VALUES (1, N'MS1', N'Size Nhỏ', N'')
INSERT [dbo].[Size] ([IDSize], [MaSize], [TenSize], [GhiChu]) VALUES (2, N'MS2', N'Size Vừa', N'')
INSERT [dbo].[Size] ([IDSize], [MaSize], [TenSize], [GhiChu]) VALUES (3, N'MS3', N'Size Lớn', N'')
SET IDENTITY_INSERT [dbo].[Size] OFF
SET IDENTITY_INSERT [dbo].[tb_HinhAnhLoaiHangHoa] ON 

INSERT [dbo].[tb_HinhAnhLoaiHangHoa] ([IDHinhAnh], [IDLoaiHangHoa], [Url]) VALUES (2, 7, N'/AnhSanPham/bluewave-white-backgrounds-wallpapers.jpg')
INSERT [dbo].[tb_HinhAnhLoaiHangHoa] ([IDHinhAnh], [IDLoaiHangHoa], [Url]) VALUES (3, 7, N'/AnhSanPham/bluewave-white-backgrounds-wallpapers.jpg')
INSERT [dbo].[tb_HinhAnhLoaiHangHoa] ([IDHinhAnh], [IDLoaiHangHoa], [Url]) VALUES (4, 7, N'/AnhSanPham/bg3.png')
SET IDENTITY_INSERT [dbo].[tb_HinhAnhLoaiHangHoa] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__NguoiDun__D5B8C7F0A9EF7311]    Script Date: 7/9/2019 10:37:03 AM ******/
ALTER TABLE [dbo].[NguoiDung] ADD UNIQUE NONCLUSTERED 
(
	[TaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BlackList]  WITH CHECK ADD FOREIGN KEY([IDLoaiHangHoa])
REFERENCES [dbo].[LoaiHangHoa] ([IDLoaiHangHoa])
GO
ALTER TABLE [dbo].[BlackList]  WITH CHECK ADD FOREIGN KEY([IDLoaiHangHoa])
REFERENCES [dbo].[LoaiHangHoa] ([IDLoaiHangHoa])
GO
ALTER TABLE [dbo].[ChiTietGiaTheoKhach]  WITH CHECK ADD FOREIGN KEY([IDHangHoa])
REFERENCES [dbo].[LoaiHangHoa] ([IDLoaiHangHoa])
GO
ALTER TABLE [dbo].[ChiTietGiaTheoKhach]  WITH CHECK ADD FOREIGN KEY([IDHangHoa])
REFERENCES [dbo].[LoaiHangHoa] ([IDLoaiHangHoa])
GO
ALTER TABLE [dbo].[ChiTietGiaTheoKhach]  WITH CHECK ADD FOREIGN KEY([IDKhachHang])
REFERENCES [dbo].[KhachHang] ([IDKhachHang])
GO
ALTER TABLE [dbo].[ChiTietGiaTheoKhach]  WITH CHECK ADD FOREIGN KEY([IDKhachHang])
REFERENCES [dbo].[KhachHang] ([IDKhachHang])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietPh__IDHan__3C69FB99] FOREIGN KEY([IDHangHoa])
REFERENCES [dbo].[HangHoa] ([IDHangHoa])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK__ChiTietPh__IDHan__3C69FB99]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietPh__IDHan__6477ECF3] FOREIGN KEY([IDHangHoa])
REFERENCES [dbo].[HangHoa] ([IDHangHoa])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK__ChiTietPh__IDHan__6477ECF3]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietPh__IDPhi__3D5E1FD2] FOREIGN KEY([IDPhieuNhap])
REFERENCES [dbo].[PhieuNhap] ([IDPhieuNhap])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK__ChiTietPh__IDPhi__3D5E1FD2]
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietPh__IDPhi__656C112C] FOREIGN KEY([IDPhieuNhap])
REFERENCES [dbo].[PhieuNhap] ([IDPhieuNhap])
GO
ALTER TABLE [dbo].[ChiTietPhieuNhap] CHECK CONSTRAINT [FK__ChiTietPh__IDPhi__656C112C]
GO
ALTER TABLE [dbo].[ChiTietPhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietPh__IDHan__3E52440B] FOREIGN KEY([IDHangHoa])
REFERENCES [dbo].[HangHoa] ([IDHangHoa])
GO
ALTER TABLE [dbo].[ChiTietPhieuXuat] CHECK CONSTRAINT [FK__ChiTietPh__IDHan__3E52440B]
GO
ALTER TABLE [dbo].[ChiTietPhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietPh__IDHan__66603565] FOREIGN KEY([IDHangHoa])
REFERENCES [dbo].[HangHoa] ([IDHangHoa])
GO
ALTER TABLE [dbo].[ChiTietPhieuXuat] CHECK CONSTRAINT [FK__ChiTietPh__IDHan__66603565]
GO
ALTER TABLE [dbo].[ChiTietPhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietPh__IDPhi__3F466844] FOREIGN KEY([IDPhieuXuat])
REFERENCES [dbo].[PhieuXuat] ([IDPhieuXuat])
GO
ALTER TABLE [dbo].[ChiTietPhieuXuat] CHECK CONSTRAINT [FK__ChiTietPh__IDPhi__3F466844]
GO
ALTER TABLE [dbo].[ChiTietPhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK__ChiTietPh__IDPhi__6754599E] FOREIGN KEY([IDPhieuXuat])
REFERENCES [dbo].[PhieuXuat] ([IDPhieuXuat])
GO
ALTER TABLE [dbo].[ChiTietPhieuXuat] CHECK CONSTRAINT [FK__ChiTietPh__IDPhi__6754599E]
GO
ALTER TABLE [dbo].[HangHoa]  WITH CHECK ADD  CONSTRAINT [FK__HangHoa__IDLoaiH__403A8C7D] FOREIGN KEY([IDLoaiHangHoa])
REFERENCES [dbo].[LoaiHangHoa] ([IDLoaiHangHoa])
GO
ALTER TABLE [dbo].[HangHoa] CHECK CONSTRAINT [FK__HangHoa__IDLoaiH__403A8C7D]
GO
ALTER TABLE [dbo].[HangHoa]  WITH CHECK ADD  CONSTRAINT [FK__HangHoa__IDLoaiH__68487DD7] FOREIGN KEY([IDLoaiHangHoa])
REFERENCES [dbo].[LoaiHangHoa] ([IDLoaiHangHoa])
GO
ALTER TABLE [dbo].[HangHoa] CHECK CONSTRAINT [FK__HangHoa__IDLoaiH__68487DD7]
GO
ALTER TABLE [dbo].[HangHoa]  WITH CHECK ADD  CONSTRAINT [FK__HangHoa__IDMauSa__412EB0B6] FOREIGN KEY([IDMauSac])
REFERENCES [dbo].[MauSac] ([IDMauSac])
GO
ALTER TABLE [dbo].[HangHoa] CHECK CONSTRAINT [FK__HangHoa__IDMauSa__412EB0B6]
GO
ALTER TABLE [dbo].[HangHoa]  WITH CHECK ADD  CONSTRAINT [FK__HangHoa__IDMauSa__693CA210] FOREIGN KEY([IDMauSac])
REFERENCES [dbo].[MauSac] ([IDMauSac])
GO
ALTER TABLE [dbo].[HangHoa] CHECK CONSTRAINT [FK__HangHoa__IDMauSa__693CA210]
GO
ALTER TABLE [dbo].[HangHoa]  WITH CHECK ADD  CONSTRAINT [FK__HangHoa__IDSize__4222D4EF] FOREIGN KEY([IDSize])
REFERENCES [dbo].[Size] ([IDSize])
GO
ALTER TABLE [dbo].[HangHoa] CHECK CONSTRAINT [FK__HangHoa__IDSize__4222D4EF]
GO
ALTER TABLE [dbo].[HangHoa]  WITH CHECK ADD  CONSTRAINT [FK__HangHoa__IDSize__6A30C649] FOREIGN KEY([IDSize])
REFERENCES [dbo].[Size] ([IDSize])
GO
ALTER TABLE [dbo].[HangHoa] CHECK CONSTRAINT [FK__HangHoa__IDSize__6A30C649]
GO
ALTER TABLE [dbo].[HangHoa]  WITH CHECK ADD  CONSTRAINT [FK_HangHoa_ChatLieu] FOREIGN KEY([IDChatLieu])
REFERENCES [dbo].[ChatLieu] ([IDChatLieu])
GO
ALTER TABLE [dbo].[HangHoa] CHECK CONSTRAINT [FK_HangHoa_ChatLieu]
GO
ALTER TABLE [dbo].[HangHoa]  WITH CHECK ADD  CONSTRAINT [FK_HangHoa_KieuDang] FOREIGN KEY([IDKieuDang])
REFERENCES [dbo].[KieuDang] ([IDKieuDang])
GO
ALTER TABLE [dbo].[HangHoa] CHECK CONSTRAINT [FK_HangHoa_KieuDang]
GO
ALTER TABLE [dbo].[LoaiHangHoa]  WITH CHECK ADD FOREIGN KEY([IDDonViTinh])
REFERENCES [dbo].[DonViTinh] ([IDDonViTinh])
GO
ALTER TABLE [dbo].[LoaiHangHoa]  WITH CHECK ADD FOREIGN KEY([IDDonViTinh])
REFERENCES [dbo].[DonViTinh] ([IDDonViTinh])
GO
ALTER TABLE [dbo].[LoaiHangHoa]  WITH CHECK ADD FOREIGN KEY([IDLoaiHangCapCao])
REFERENCES [dbo].[LoaiHangCapCao] ([IDLoaiHangCapCao])
GO
ALTER TABLE [dbo].[LoaiHangHoa]  WITH CHECK ADD FOREIGN KEY([IDLoaiHangCapCao])
REFERENCES [dbo].[LoaiHangCapCao] ([IDLoaiHangCapCao])
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK__PhieuNhap__IDKho__44FF419A] FOREIGN KEY([IDKho])
REFERENCES [dbo].[Kho] ([IDKho])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK__PhieuNhap__IDKho__44FF419A]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK__PhieuNhap__IDKho__6D0D32F4] FOREIGN KEY([IDKho])
REFERENCES [dbo].[Kho] ([IDKho])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK__PhieuNhap__IDKho__6D0D32F4]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK__PhieuNhap__IDNha__45F365D3] FOREIGN KEY([IDNhaCungCap])
REFERENCES [dbo].[NhaCungCap] ([IDNhaCungCap])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK__PhieuNhap__IDNha__45F365D3]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK__PhieuNhap__IDNha__6E01572D] FOREIGN KEY([IDNhaCungCap])
REFERENCES [dbo].[NhaCungCap] ([IDNhaCungCap])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK__PhieuNhap__IDNha__6E01572D]
GO
ALTER TABLE [dbo].[PhieuNhap]  WITH CHECK ADD  CONSTRAINT [FK_PhieuNhap_KhachHang] FOREIGN KEY([IDKhachHang_TraHang])
REFERENCES [dbo].[KhachHang] ([IDKhachHang])
GO
ALTER TABLE [dbo].[PhieuNhap] CHECK CONSTRAINT [FK_PhieuNhap_KhachHang]
GO
ALTER TABLE [dbo].[PhieuTraNo]  WITH CHECK ADD FOREIGN KEY([IDKhachHang])
REFERENCES [dbo].[KhachHang] ([IDKhachHang])
GO
ALTER TABLE [dbo].[PhieuTraNo]  WITH CHECK ADD FOREIGN KEY([IDKhachHang])
REFERENCES [dbo].[KhachHang] ([IDKhachHang])
GO
ALTER TABLE [dbo].[PhieuTraNoChoKhach]  WITH CHECK ADD  CONSTRAINT [FK_PhieuTraNoChoKhach_KhachHang] FOREIGN KEY([IDKhachHang])
REFERENCES [dbo].[KhachHang] ([IDKhachHang])
GO
ALTER TABLE [dbo].[PhieuTraNoChoKhach] CHECK CONSTRAINT [FK_PhieuTraNoChoKhach_KhachHang]
GO
ALTER TABLE [dbo].[PhieuTraNoNhaCungCap]  WITH CHECK ADD FOREIGN KEY([IDNhaCungCap])
REFERENCES [dbo].[NhaCungCap] ([IDNhaCungCap])
GO
ALTER TABLE [dbo].[PhieuTraNoNhaCungCap]  WITH CHECK ADD FOREIGN KEY([IDNhaCungCap])
REFERENCES [dbo].[NhaCungCap] ([IDNhaCungCap])
GO
ALTER TABLE [dbo].[PhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK__PhieuXuat__IDKha__48CFD27E] FOREIGN KEY([IDKhachHang])
REFERENCES [dbo].[KhachHang] ([IDKhachHang])
GO
ALTER TABLE [dbo].[PhieuXuat] CHECK CONSTRAINT [FK__PhieuXuat__IDKha__48CFD27E]
GO
ALTER TABLE [dbo].[PhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK__PhieuXuat__IDKha__70DDC3D8] FOREIGN KEY([IDKhachHang])
REFERENCES [dbo].[KhachHang] ([IDKhachHang])
GO
ALTER TABLE [dbo].[PhieuXuat] CHECK CONSTRAINT [FK__PhieuXuat__IDKha__70DDC3D8]
GO
ALTER TABLE [dbo].[PhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK__PhieuXuat__IDKho__49C3F6B7] FOREIGN KEY([IDKho])
REFERENCES [dbo].[Kho] ([IDKho])
GO
ALTER TABLE [dbo].[PhieuXuat] CHECK CONSTRAINT [FK__PhieuXuat__IDKho__49C3F6B7]
GO
ALTER TABLE [dbo].[PhieuXuat]  WITH CHECK ADD  CONSTRAINT [FK__PhieuXuat__IDKho__71D1E811] FOREIGN KEY([IDKho])
REFERENCES [dbo].[Kho] ([IDKho])
GO
ALTER TABLE [dbo].[PhieuXuat] CHECK CONSTRAINT [FK__PhieuXuat__IDKho__71D1E811]
GO
ALTER TABLE [dbo].[tb_HinhAnhLoaiHangHoa]  WITH CHECK ADD  CONSTRAINT [FK_tb_HinhAnhLoaiHangHoa_LoaiHangHoa] FOREIGN KEY([IDLoaiHangHoa])
REFERENCES [dbo].[LoaiHangHoa] ([IDLoaiHangHoa])
GO
ALTER TABLE [dbo].[tb_HinhAnhLoaiHangHoa] CHECK CONSTRAINT [FK_tb_HinhAnhLoaiHangHoa_LoaiHangHoa]
GO
ALTER TABLE [dbo].[tb_PhieuThuNoNhaCungCap]  WITH CHECK ADD  CONSTRAINT [FK_tb_PhieuThuNoNhaCungCap_NhaCungCap] FOREIGN KEY([IDNhaCungCap])
REFERENCES [dbo].[NhaCungCap] ([IDNhaCungCap])
GO
ALTER TABLE [dbo].[tb_PhieuThuNoNhaCungCap] CHECK CONSTRAINT [FK_tb_PhieuThuNoNhaCungCap_NhaCungCap]
GO
