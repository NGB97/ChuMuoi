using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Layout_MasterPage_MenuNgang : System.Web.UI.MasterPage
{
    string mTenDangNhap = "";
    string mQuyen = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["BanSiQuanAo_Login"] != null && Request.Cookies["BanSiQuanAo_Login"].Value.Trim() != "")
        {
            mTenDangNhap = Request.Cookies["BanSiQuanAo_Login"].Value.Trim();
            LoadThongTinNguoiDung();
        }
        else
        {
            Response.Redirect("../Home/DangNhap.aspx");
        }
        if (!IsPostBack)
        {
            LoadMenu();
        }
    }
    private void LoadThongTinNguoiDung()
    {
        string html = "";
        string sqlTTND = "select * from NguoiDung where TaiKhoan=N'" + mTenDangNhap + "'";
        DataTable tbTTND = Connect.GetTable(sqlTTND);
        if (tbTTND.Rows.Count > 0)
        {
            mQuyen = tbTTND.Rows[0]["Quyen"].ToString();
            lbTenDangNhap.InnerHtml = tbTTND.Rows[0]["TenNguoiDung"].ToString();
            html += "<img src='../dist/img/user2-160x160.jpg' class='img-circle' alt='User Image'>";
            html += "<p>" + tbTTND.Rows[0]["TenNguoiDung"].ToString() + "<small>";
            html += "Quyền: " + mQuyen + "</small></p>";
        }
    }
    private void LoadMenu()
    {
        string URL = HttpContext.Current.Request.Url.AbsoluteUri.ToUpper();
        string html = "";
        html += @"<a href='#' class='visible-phone'><i class='icon icon-align-justify' style='margin-top: -1px;'></i> <span style='font-size: 14px;'>DANH MỤC QUẢN LÝ</span></a><ul>

     ";
        mQuyen = StaticData.BoDauTiengViet(mQuyen).ToUpper();
        /////////Danh mục
        if (mQuyen == "ADMIN"  )
        {
            if (URL.Contains("/DANHMUC/"))
                html += "  <li id='dvDanhMuc' class='submenu activeMenu'>";
            else
                html += "  <li id='dvDanhMuc' class='submenu'>";
            html += @"<a href='#'><i class='fa fa-list FixIcon'></i> <span>Danh mục</span> </a>
              <ul class='treeview-menu'>";
             

            if (mQuyen == "ADMIN" )
            {
                html += "<li ";
                if (URL.Contains(("/DanhMuc/DanhMucNhaCungCap.aspx").ToUpper()))
                {
                    html += @" class='activeSubMenu'";
                }
                html += @" style='width: 260px;'> <a href='../DanhMuc/DanhMucNhaCungCap.aspx'><i class='fa fa-industry FixIcon'  style='margin-top: 7px; margin-right:8px' ></i>Nhà cung cấp</a></li>";

            }
            if (mQuyen == "ADMIN" )
            {
                html += "<li ";
                if (URL.Contains(("/DanhMuc/DanhMucKhachHang.aspx").ToUpper()))
                {
                    html += @" class='activeSubMenu'";
                }
                html += @" style='width: 260px;'> <a href='../DanhMuc/DanhMucKhachHang.aspx'><i class='fa fa-building FixIcon'  style='margin-top: 7px; margin-right:8px' ></i>Khách hàng</a></li>";
            }
            if (mQuyen == "ADMIN"  )
            {
                html += "<li ";
                if (URL.Contains(("/DanhMuc/DanhMucKhachHangSanPham.aspx").ToUpper()))
                {
                    html += @" class='activeSubMenu'";
                }
                html += @" style='width: 260px;'> <a href='../DanhMuc/DanhMucKhachHangSanPham.aspx'><i class='fa fa-money FixIcon'  style='margin-top: 7px; margin-right:8px' ></i>Khách hàng sản phẩm</a></li>";
            }
            if (mQuyen == "ADMIN")
            {
                html += "<li ";
                if (URL.Contains(("/DanhMuc/NhomHangHoa.aspx").ToUpper()))
                {
                    html += @" class='activeSubMenu'";
                }
                html += @" style='width: 260px;'> <a href='../DanhMuc/NhomHangHoa.aspx'><i class='fa fa-university FixIcon'  style='margin-top: 7px; margin-right:8px' ></i>Nhóm hàng hoá</a></li>";
            }
            if (mQuyen == "ADMIN"  )
            {
                html += "<li ";
                if (URL.Contains(("/DanhMuc/DanhMucLoaiHangCapCao.aspx").ToUpper()))
                {
                    html += @" class='activeSubMenu'";
                }
                html += @" style='width: 260px;'> <a href='../DanhMuc/DanhMucLoaiHangCapCao.aspx'><i class='fa fa-university FixIcon'  style='margin-top: 7px; margin-right:8px' ></i>Loại hàng hoá</a></li>";
            }
            if (mQuyen == "ADMIN")
            {
                html += "<li ";
                if (URL.Contains(("/DanhMuc/DanhMucLoaiHangHoa.aspx").ToUpper()))
                {
                    html += @" class='activeSubMenu'";
                }
                html += @" style='width: 260px;'> <a href='../DanhMuc/DanhMucLoaiHangHoa.aspx'><i class='fa fa-university FixIcon'  style='margin-top: 7px; margin-right:8px' ></i>Hàng hoá</a></li>";
            }
            if (mQuyen == "ADMIN")
            {
                html += "<li ";
                if (URL.Contains(("/DanhMuc/DVT.aspx").ToUpper()))
                {
                    html += @" class='activeSubMenu'";
                }
                html += @" style='width: 260px;'> <a href='../DanhMuc/DVT.aspx'><i class='fa fa-university FixIcon'  style='margin-top: 7px; margin-right:8px' ></i>Đơn vị tính</a></li>";
            }
            if (mQuyen == "ADMIN")
            {
                html += "<li ";
                if (URL.Contains(("/DanhMuc/DonViTinh.aspx").ToUpper()))
                {
                    html += @" class='activeSubMenu'";
                }
                html += @" style='width: 260px;'> <a href='../DanhMuc/DonViTinh.aspx'><i class='fa fa-university FixIcon'  style='margin-top: 7px; margin-right:8px' ></i>Size</a></li>";
            }
            if (mQuyen == "ADMIN")
            {
                html += "<li ";
                if (URL.Contains(("/DanhMuc/MauSac.aspx").ToUpper()))
                {
                    html += @" class='activeSubMenu'";
                }
                html += @" style='width: 260px;'> <a href='../DanhMuc/MauSac.aspx'><i class='fa fa-university FixIcon'  style='margin-top: 7px; margin-right:8px' ></i>Màu sắc</a></li>";
            }
            if (mQuyen == "ADMIN")
            {
                html += "<li ";
                if (URL.Contains(("/DanhMuc/ChatLieu.aspx").ToUpper()))
                {
                    html += @" class='activeSubMenu'";
                }
                html += @" style='width: 260px;'> <a href='../DanhMuc/ChatLieu.aspx'><i class='fa fa-university FixIcon'  style='margin-top: 7px; margin-right:8px' ></i>Chất liệu</a></li>";
            }
            if (mQuyen == "ADMIN")
            {
                html += "<li ";
                if (URL.Contains(("/DanhMuc/KieuDang.aspx").ToUpper()))
                {
                    html += @" class='activeSubMenu'";
                }
                html += @" style='width: 260px;'> <a href='../DanhMuc/KieuDang.aspx'><i class='fa fa-university FixIcon'  style='margin-top: 7px; margin-right:8px' ></i>Kiểu dáng</a></li>";
            }
            if (mQuyen == "ADMIN")
            {
                html += "<li ";
                if (URL.Contains(("/DanhMuc/Kho.aspx").ToUpper()))
                {
                    html += @" class='activeSubMenu'";
                }
                html += @" style='width: 260px;'> <a href='../DanhMuc/Kho.aspx'><i class='fa fa-university FixIcon'  style='margin-top: 7px; margin-right:8px' ></i>Kho</a></li>";
            }
            html += @"</ul>
                </li>";  
        } 


        if (mQuyen == "ADMIN" )
        {
            if (URL.Contains("/QUANLYNGUOIDUNG/QUANLYNGUOIDUNG.ASPX"))
                html += "  <li id='dvquanlyNguoiDung' class='activeMenu li-Tag'>";
            else
                html += "  <li id='dvquanlyNguoiDung' class='li-Tag'>";
            html += "  <a href='../QuanLyNguoiDung/QuanLyNguoiDung.aspx' class=' a-Tag' title='Quản lý người dùng'>";
            html += "    <i class='fa fa-table FixIcon'></i> <span>Quản lý người dùng</span>";
            html += "  </a>";
            html += "</li>";
        }

        if (mQuyen == "ADMIN")
        {
            if (URL.Contains("/QUANLYTRAHANG/DANHMUCNHAPHANG.ASPX"))
                html += "  <li id='dvquanlyTraHang' class='activeMenu li-Tag'>";
            else
                html += "  <li id='dvquanlyTraHang' class='li-Tag'>";
            html += "  <a href='../QuanLyTraHang/DanhMucNhapHang.aspx' class=' a-Tag' title='Quản lý trả hàng'>";
            html += "    <i class='fa fa-table FixIcon'></i> <span>Quản lý trả hàng</span>";
            html += "  </a>";
            html += "</li>";
        }

        if (mQuyen == "ADMIN")
        {
            if (URL.Contains("/QUANLYNHAPHANG/DANHMUCNHAPHANG.ASPX"))
                html += "  <li id='dvquanlyNhapHang' class='activeMenu li-Tag'>";
            else
                html += "  <li id='dvquanlyNhapHang' class='li-Tag'>";
            html += "  <a href='../QuanLyNhapHang/DanhMucNhapHang.aspx' class=' a-Tag' title='Quản lý nhập hàng'>";
            html += "    <i class='fa fa-table FixIcon'></i> <span>Quản lý nhập hàng</span>";
            html += "  </a>";
            html += "</li>";
        }

        if (mQuyen == "ADMIN")
        {
            if (URL.Contains("/QUANLYXUATHANG/DANHMUCXUATHANG.ASPX"))
                html += "  <li id='dvquanlyXuatHang' class='activeMenu li-Tag'>";
            else
                html += "  <li id='dvquanlyXuatHang' class='li-Tag'>";
            html += "  <a href='../QuanLyXuatHang/DanhMucXuatHang.aspx' class=' a-Tag' title='Quản lý xuất hàng'>";
            html += "    <i class='fa fa-table FixIcon'></i> <span>Quản lý xuất hàng</span>";
            html += "  </a>";
            html += "</li>";
        }

        if (mQuyen == "ADMIN")
        {
            if (URL.Contains("/QUANLYCHIAHANG/PHIEUCHIAHANG.ASPX"))
                html += "  <li id='dvQuanLyChiaHang' class='activeMenu li-Tag'>";
            else
                html += "  <li id='dvQuanLyChiaHang' class='li-Tag'>";
            html += "  <a href='../QuanLyChiaHang/PhieuChiaHang.aspx' class=' a-Tag' title='Quản lý chia hàng'>";
            html += "    <i class='fa fa-table FixIcon'></i> <span>Quản lý chia hàng</span>";
            html += "  </a>";
            html += "</li>";
        } 

        if (mQuyen == "ADMIN")
        {
            if (URL.Contains("/BAOCAOHETHAN/CANHBAOHETHANG.ASPX"))
                html += "  <li id='dvCanhBaoHetHang' class='activeMenu li-Tag'>";
            else
                html += "  <li id='dvCanhBaoHetHang' class='li-Tag'>";
            html += "  <a href='../BaoCaoHetHan/CanhBaoHetHang.aspx' class=' a-Tag' title='Cảnh báo hết hàng'>";
            html += "    <i class='fa fa-table FixIcon'></i> <span>Cảnh báo hết hàng</span>";
            html += "  </a>";
            html += "</li>";
        }


        ///////// THỐNG KÊ
        if (mQuyen == "ADMIN")
        {
            if (URL.Contains("/BAOCAO/"))
                html += "  <li id='dvThongKe' class='submenu activeMenu'>";
            else
                html += "  <li id='dvThongKe' class='submenu'>";
            html += @"<a href='#'><i class='fa fa-list FixIcon'></i> <span>THỐNG KÊ-TRẢ NỢ</span> </a>
              <ul class='treeview-menu'>";


            if (mQuyen == "ADMIN")
            {
                html += "<li ";
                if (URL.Contains(("/BaoCao/NoKhachHang.aspx").ToUpper()))
                {
                    html += @" class='activeSubMenu'";
                }
                html += @" style='width: 260px;'> <a href='../BaoCao/NoKhachHang.aspx'><i class='fa fa-industry FixIcon'  style='margin-top: 7px; margin-right:8px' ></i>Thống kê khách hàng nợ</a></li>";

            }
            if (mQuyen == "ADMIN")
            {
                html += "<li ";
                if (URL.Contains(("/BaoCao/PhieuTraNoKhachHang.aspx").ToUpper()))
                {
                    html += @" class='activeSubMenu'";
                }
                html += @" style='width: 260px;'> <a href='../BaoCao/PhieuTraNoKhachHang.aspx'><i class='fa fa-industry FixIcon'  style='margin-top: 7px; margin-right:8px' ></i>Khách hàng trả nợ</a></li>";

            }
            if (mQuyen == "ADMIN")
            {
                html += "<li ";
                if (URL.Contains(("/BaoCao/TraNoKhachHang.aspx").ToUpper()))
                {
                    html += @" class='activeSubMenu'";
                }
                html += @" style='width: 260px;'> <a href='../BaoCao/TraNoKhachHang.aspx'><i class='fa fa-industry FixIcon'  style='margin-top: 7px; margin-right:8px' ></i>Thống kê nợ khách hàng</a></li>";

            }
            if (mQuyen == "ADMIN")
            {
                html += "<li ";
                if (URL.Contains(("/BaoCao/DSNoKhachHang.aspx").ToUpper()))
                {
                    html += @" class='activeSubMenu'";
                }
                html += @" style='width: 260px;'> <a href='../BaoCao/DSNoKhachHang.aspx'><i class='fa fa-industry FixIcon'  style='margin-top: 7px; margin-right:8px' ></i>Trả nợ khách hàng</a></li>";

            }
            if (mQuyen == "ADMIN")
            {
                html += "<li ";
                if (URL.Contains(("/BaoCao/NoNhaCungCap.aspx").ToUpper()))
                {
                    html += @" class='activeSubMenu'";
                }
                html += @" style='width: 260px;'> <a href='../BaoCao/NoNhaCungCap.aspx'><i class='fa fa-industry FixIcon'  style='margin-top: 7px; margin-right:8px' ></i>Thống kê thiếu nợ NCC</a></li>";

            }
            if (mQuyen == "ADMIN")
            {
                html += "<li ";
                if (URL.Contains(("/BaoCao/PhieuTraNoNhaCungCap.aspx").ToUpper()))
                {
                    html += @" class='activeSubMenu'";
                }
                html += @" style='width: 260px;'> <a href='../BaoCao/PhieuTraNoNhaCungCap.aspx'><i class='fa fa-industry FixIcon'  style='margin-top: 7px; margin-right:8px' ></i>Trả nợ NCC</a></li>";

            } 


            html += @"</ul>
                </li>";
        }

        DataTable layNgay = Connect.GetTable("select Convert(nvarchar(20),GETDATE(),103)");
        
        ///////// THỐNG KÊ DOANH THU
        if (mQuyen == "ADMIN")
        {
            if (URL.Contains("/THONGKEDOANHTHU/"))
                html += "  <li id='dvThongKeDoanhThu' class='submenu activeMenu'>";
            else
                html += "  <li id='dvThongKeDoanhThu' class='submenu'>";
            html += @"<a href='#'><i class='fa fa-list FixIcon'></i> <span>THỐNG KÊ-DOANH THU</span> </a>
              <ul class='treeview-menu'>";


            if (mQuyen == "ADMIN")
            {
                html += "<li ";
                if (URL.Contains(("/ThongKeDoanhThu/ThongKeTonKho.aspx").ToUpper()))
                {
                    html += @" class='activeSubMenu'";
                }
                html += @" style='width: 260px;'> <a href='../ThongKeDoanhThu/ThongKeTonKho.aspx'><i class='fa fa-industry FixIcon'  style='margin-top: 7px; margin-right:8px' ></i>Thống kê hàng tồn theo kho</a></li>";
            }
            if (mQuyen == "ADMIN")
            {
                html += "<li ";
                if (URL.Contains(("/ThongKeDoanhThu/LoiNhuan.aspx").ToUpper()))
                {
                    html += @" class='activeSubMenu'";
                }
                html += @" style='width: 260px;'> <a href='../ThongKeDoanhThu/LoiNhuan.aspx?TuNgayNhap=" + layNgay.Rows[0][0].ToString() + @"&DenNgayNhap=" + layNgay.Rows[0][0].ToString() + @"'><i class='fa fa-industry FixIcon'  style='margin-top: 7px; margin-right:8px' ></i>Thống kê lợi nhuận</a></li>";
            }
            if (mQuyen == "ADMIN")
            {
                html += "<li ";
                if (URL.Contains(("/ThongKeDoanhThu/DanhMucXuatHang.aspx").ToUpper()))
                {
                    html += @" class='activeSubMenu'";
                }
                html += @" style='width: 260px;'> <a href='../ThongKeDoanhThu/DanhMucXuatHang.aspx'><i class='fa fa-industry FixIcon'  style='margin-top: 7px; margin-right:8px' ></i>Thống kê bán hàng</a></li>";
            }

            html += @"</ul>
                </li>";
        }

        ///////// THỐNG KÊ DOANH THU
        if (mQuyen == "ADMIN")
        {
            if (URL.Contains("/THONGKETRONGNGAY/"))
                html += "  <li id='dvThongKeTrongNgay' class='submenu activeMenu'>";
            else
                html += "  <li id='dvThongKeTrongNgay' class='submenu'>";
            html += @"<a href='#'><i class='fa fa-list FixIcon'></i> <span>THỐNG KÊ-TRONG NGÀY</span> </a>
              <ul class='treeview-menu'>";


            if (mQuyen == "ADMIN")
            {
                html += "<li ";
                if (URL.Contains(("/ThongKeTrongNgay/DanhMucXuatHang.aspx").ToUpper()))
                {
                    html += @" class='activeSubMenu'";
                }
                html += @" style='width: 260px;'> <a href='../ThongKeTrongNgay/DanhMucXuatHang.aspx?TuNgayXuat=" + layNgay.Rows[0][0].ToString() + @"&DenNgayXuat=" + layNgay.Rows[0][0].ToString() + @"'><i class='fa fa-industry FixIcon'  style='margin-top: 7px; margin-right:8px' ></i>Bán hàng hôm nay</a></li>";
            }
            if (mQuyen == "ADMIN")
            {
                html += "<li ";
                if (URL.Contains(("/ThongKeTrongNgay/DanhMucNhapHang.aspx").ToUpper()))
                {
                    html += @" class='activeSubMenu'";
                }
                html += @" style='width: 260px;'> <a href='../ThongKeTrongNgay/DanhMucNhapHang.aspx?TuNgayNhap=" + layNgay.Rows[0][0].ToString() + @"&TuNgayNhap=" + layNgay.Rows[0][0].ToString() + @"'><i class='fa fa-industry FixIcon'  style='margin-top: 7px; margin-right:8px' ></i>Nhập hàng hôm nay</a></li>";
            }
            if (mQuyen == "ADMIN")
            {
                html += "<li ";
                if (URL.Contains(("/ThongKeTrongNgay/PhieuTraNoKhachHang.aspx").ToUpper()))
                {
                    html += @" class='activeSubMenu'";
                }
                html += @" style='width: 260px;'> <a href='../ThongKeTrongNgay/PhieuTraNoKhachHang.aspx?TuNgayNhap=" + layNgay.Rows[0][0].ToString() + @"&TuNgayNhap=" + layNgay.Rows[0][0].ToString() + @"'><i class='fa fa-industry FixIcon'  style='margin-top: 7px; margin-right:8px' ></i>Khách hàng trả nợ</a></li>";
            }
            if (mQuyen == "ADMIN")
            {
                html += "<li ";
                if (URL.Contains(("/ThongKeTrongNgay/DSNoKhachHang.aspx").ToUpper()))
                {
                    html += @" class='activeSubMenu'";
                }
                html += @" style='width: 260px;'> <a href='../ThongKeTrongNgay/DSNoKhachHang.aspx?TuNgayNhap=" + layNgay.Rows[0][0].ToString() + @"&TuNgayNhap=" + layNgay.Rows[0][0].ToString() + @"'><i class='fa fa-industry FixIcon'  style='margin-top: 7px; margin-right:8px' ></i>Trả nợ khách hàng</a></li>";
            }  

            html += @"</ul>
                </li>";
        }
             
        html += "</ul>";
        sidebar.InnerHtml = html;
    }
}
