using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Layout_MasterPage : System.Web.UI.MasterPage
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
            LoadMenu(mQuyen);
        }
    }
    private void LoadThongTinNguoiDung()
    {
        string html = "";
        string sqlTTND = "select * from NguoiDung where TaiKhoan=N'" + mTenDangNhap + "'";
        DataTable tbTTND = Connect.GetTable(sqlTTND);
        if (tbTTND.Rows.Count > 0)
        {
            mQuyen = tbTTND.Rows[0]["TaiKhoan"].ToString();
            // lbTenDangNhap.InnerHtml = tbTTND.Rows[0]["TenNguoiDung"].ToString();
            html += "<img src='../dist/img/user2-160x160.jpg' class='img-circle' alt='User Image'>";
            html += "<p>" + tbTTND.Rows[0]["TenNguoiDung"].ToString() + "<small>";
            mQuyen = tbTTND.Rows[0]["Quyen"].ToString().Trim();
            if (mQuyen.CompareTo("NhanVien") == 0)
                html += "Quyền: Nhân Viên</small></p>";
            else
                html += "Quyền: " + mQuyen + "</small></p>";
        }
        dvTTND.InnerHtml = html;
    }
    private void LoadMenu(string Quyen)
    {
        string URL = HttpContext.Current.Request.Url.AbsoluteUri.ToUpper();
        string html = "";
        html += @"<ul class='sidebar-menu'>
        <li class='header' style='color:white; background-color: #d56f2a;font-size: 14px;font-family: -webkit-body; font-weight:bold;text-shadow: rgba(0,0,0,0.25) 0 -1px 0;box-shadow: rgba(0,0,0,0.25) 0 1px 0,inset rgba(255,255,255,0.16) 0 1px 0;'><img src='../images/management.png' class='imgcategorymenu'/>DANH MỤC QUẢN LÝ</li>
        <!-- Optionally, you can add icons to the links -->";
        //  
        if (Quyen.Equals("Admin"))
        {
            if (URL.Contains("/QUANLYNGUOIDUNG/"))
                html += "  <li id='dvQuanLyNguoiDung' class='treeview active'>";
            else
                html += "  <li id='dvQuanLyNguoiDung' class='treeview'>";
            html += "  <a href='../QuanLyNguoiDung/QuanLyNguoiDung.aspx'>";
            html += "    <i class='fa fa-user'></i> <span>QUẢN LÝ NGƯỜI DÙNG</span>";
            html += "  </a>";
            html += "</li>";
            
            //Danh mục
            if (URL.Contains("/DANHMUC/"))
                html += "  <li id='dvDanhMuc' class='treeview active'>";
            else
                html += "  <li id='dvDanhMuc' class='treeview'>";
            html += @"<a href='#'><i class='fa fa-list'></i> <span>DANH MỤC</span> <i class='fa fa-angle-left pull-right'></i></a>
              <ul class='treeview-menu'>
                <li><a href='../DanhMuc/DanhMucNhaCungCap.aspx'><i class='fa fa-edit'></i>Danh mục nhà cung cấp</a></li> 
                <li><a href='../DanhMuc/DanhMucKhachHang.aspx'><i class='fa fa-edit'></i>Danh mục khách hàng</a></li> 
                <li><a href='../DanhMuc/DanhMucKhachHangSanPham.aspx'><i class='fa fa-edit'></i>Danh mục giá theo khách</a></li>
                <li><a href='../DanhMuc/DanhMucNhomHangHoa.aspx'><i class='fa fa-edit'></i>Danh mục nhóm hàng hóa</a></li> 
                <li><a href='../DanhMuc/DanhMucLoaiHangCapCao.aspx'><i class='fa fa-edit'></i>Danh mục loại hàng hóa</a></li> 
                <li><a href='../DanhMuc/DanhMucLoaiHangHoa.aspx'><i class='fa fa-edit'></i>Danh mục hàng hóa</a></li>  
                <li><a href='../DanhMuc/DVT.aspx'><i class='fa fa-edit'></i>Đơn vị tính</a></li>
                <li><a href='../DanhMuc/DonViTinh.aspx'><i class='fa fa-edit'></i>Size</a></li>
                <li><a href='../DanhMuc/MauSac.aspx'><i class='fa fa-edit'></i>Màu sắc</a></li>
                <li><a href='../DanhMuc/ChatLieu.aspx'><i class='fa fa-edit'></i>Chất liệu</a></li>
                <li><a href='../DanhMuc/KieuDang.aspx'><i class='fa fa-edit'></i>Kiểu dáng</a></li>
                <li><a href='../DanhMuc/Kho.aspx'><i class='fa fa-edit'></i>Danh mục kho</a></li>
              </ul>
           </li>"; 
            if (URL.Contains("/QUANLYNHAPHANG/"))
            {
                html += @"  <li id='dvQuanLyDungCu' class='treeview active'><a href='../QuanLyNhapHang/DanhMucNhapHang.aspx'><i class='fa fa-download' aria-hidden='true'></i> <span>QUẢN LÝ NHẬP HÀNG</span></a>";
                html += " </li>";
            }
            else
            {
                html += @"  <li id='dvQuanLyDungCu' class='treeview'>
                                 <a href='../QuanLyNhapHang/DanhMucNhapHang.aspx'><i class='fa fa-download' aria-hidden='true'></i> <span>QUẢN LÝ NHẬP HÀNG</span></a>";
                            
                html += " </li>";
            }


//            if (URL.Contains("/DONHANGTUWEB/"))
//            {
//                html += @"  <li id='divWeb' class='treeview active'><a href='../DonHangTuWeb/DonHangTuWeb.aspx'><i class='fa fa-download' aria-hidden='true'></i> <span>ĐƠN HÀNG TỪ WEB</span></a>";
//                html += " </li>";
//            }
//            else
//            {
//                html += @"  <li id='divWeb' class='treeview'>
//            <a href='../DonHangTuWeb/DonHangTuWeb.aspx'><i class='fa fa-download' aria-hidden='true'></i> <span>ĐƠN HÀNG TỪ WEB</span></a>";
//                html += " </li>";
//            }

            if (URL.Contains("/QUANLYTRAHANG/"))
            {
                html += @"  <li id='divTraHang' class='treeview active'><a href='../QuanLyTraHang/DanhMucNhapHang.aspx'><i class='fa fa-refresh' aria-hidden='true'></i> <span>QUẢN LÝ TRẢ HÀNG</span></a>";
                html += " </li>";
            }
            else
            {
                html += @"  <li id='divTraHang' class='treeview'>
                        <a href='../QuanLyTraHang/DanhMucNhapHang.aspx'><i class='fa fa-refresh' aria-hidden='true'></i> <span>QUẢN LÝ TRẢ HÀNG</span></a>";
                html += " </li>";
            }


            //if (URL.Contains("/QUANLYCHIAHANG/"))
            //{
            //    html += @"  <li id='divChiaHang' class='treeview active'><a href='../QuanLyChiaHang/PhieuChiaHang.aspx'><i class='fa fa-refresh' aria-hidden='true'></i> <span>QUẢN LÝ CHIA HÀNG</span></a>";
            //    html += " </li>";
            //}
            //else
            //{
            //    html += @"  <li id='divChiaHang' class='treeview'>
            //            <a href='../QuanLyChiaHang/PhieuChiaHang.aspx'><i class='fa fa-arrows' aria-hidden='true'></i> <span>QUẢN LÝ CHIA HÀNG</span></a>";
            //    html += " </li>";
            //}
            if (URL.Contains("/QUANLYCHIAHANG/"))
                    html += "  <li id='divChiaHang' class='treeview active'>";
            else
                html += "  <li id='divChiaHang' class='treeview'>";
            html += @"<a href='../QuanLyChiaHang/DanhSachChiaHang.aspx'><i class='fa fa-bar-chart'></i> <span>QUẢN LÝ CHIA HÀNG</span> <i class='fa fa-angle-left pull-right'></i></a>
              <ul class='treeview-menu'>
                <li><a href='../QuanLyChiaHang/DanhSachChiaHang.aspx'><i class='fa fa-table'></i>Chia Hàng</a></li>
                <li><a href='../QuanLyChiaHang/PhieuChiaHang.aspx'><i class='fa fa-table'></i>Phiếu Chia Hàng</a></li>
              </ul>
           </li>";


            DataTable a = Connect.GetTable("select convert(nvarchar(20),GETDATE(),103) as 'Ngay'");
            if (URL.Contains("/QUANLYXUATHANG/"))
            {
                html += @"  <li id='dvQuanLyDungCu' class='treeview active'><a href='../QuanLyXuatHang/DanhMucXuatHang.aspx'><i class='fa fa-upload' aria-hidden='true'></i> <span>QUẢN LÝ BÁN HÀNG</span></a>";
                html += " </li>";
            }
            else
            {
                html += @"  <li id='dvQuanLyDungCu' class='treeview'><a href='../QuanLyXuatHang/DanhMucXuatHang.aspx'><i class='fa fa-upload' aria-hidden='true'></i> <span>QUẢN LÝ BÁN HÀNG</span></a>";
                html += " </li>";
            }

            string sql = @"
select count(*) from(select HangHoa.IDHangHoa,HangHoa.TenHangHoa
,(select isnull(sum(ChiTietPhieuNhap.SoLuong),0) from ChiTietPhieuNhap where ChiTietPhieuNhap.IDHangHoa = HangHoa.IDHangHoa) as 'SoLuongNhap'
,(select isnull(sum(ChiTietPhieuXuat.SoLuong),0) from ChiTietPhieuXuat where ChiTietPhieuXuat.IDHangHoa = HangHoa.IDHangHoa) as 'SoLuongXuat'
 from HangHoa) as tb1 where (tb1.SoLuongNhap-tb1.SoLuongXuat <=5) ";
            DataTable tbTotalRows = Connect.GetTable(sql);

            int TotalRows = int.Parse(tbTotalRows.Rows[0][0].ToString());
            if (TotalRows > 0)
            {  
                if (URL.Contains("/BAOCAOHETHAN/"))
                {
                    html += @"  <li id='dvQuanLyDungCu' class='treeview active'><a href='../BaoCaoHetHan/CanhBaoHetHang.aspx'><i class='fa fa-warning' aria-hidden='true'></i> <span>HÀNG SẮP HẾT</span><small class='label pull-right bg-red notication' style='margin-top: -10px;padding: 5px;'>" + TotalRows + @"</small></a>";
                    html += " </li>";
                }
                else
                {
                    html += @"  <li id='dvQuanLyDungCu' class='treeview'><a href='../BaoCaoHetHan/CanhBaoHetHang.aspx'><i class='fa fa-warning' aria-hidden='true'></i> <span>HÀNG SẮP HẾT</span><small class='label pull-right bg-red notication' style='margin-top: -10px;padding: 5px;'>" + TotalRows + @"</small></a>";
                    html += " </li>";
                }
            }
            else
            {
                if (URL.Contains("/BAOCAOHETHAN/"))
                {
                    html += @"  <li id='dvQuanLyDungCu' class='treeview active'><a href='../BaoCaoHetHan/CanhBaoHetHang.aspx'><i class='fa fa-warning' aria-hidden='true'></i> <span>HÀNG SẮP HẾT</span></a>";
                    html += " </li>";
                }
                else
                {
                    html += @"  <li id='dvQuanLyDungCu' class='treeview'><a href='../BaoCaoHetHan/CanhBaoHetHang.aspx'><i class='fa fa-warning' aria-hidden='true'></i> <span>HÀNG SẮP HẾT</span></a>";
                    html += " </li>";
                }
            } 
            ///////// Thống kê
            if (URL.Contains("/BAOCAO/"))
                html += "  <li id='dvThongKe' class='treeview active'>";
            else
                html += "  <li id='dvThongKe' class='treeview'>";
            html += @"<a href='#'><i class='fa fa-bar-chart'></i> <span>THỐNG KÊ-TRẢ NỢ</span> <i class='fa fa-angle-left pull-right'></i></a>
              <ul class='treeview-menu'>
                <li><a href='../BaoCao/NoKhachHang.aspx'><i class='fa fa-table'></i>Thống kê khách hàng nợ</a></li>
                <li><a href='../BaoCao/PhieuTraNoKhachHang.aspx'><i class='fa fa-table'></i>Khách hàng trả nợ</a></li>
                <li><a href='../BaoCao/TraNoKhachHang.aspx'><i class='fa fa-table'></i>Thống kê nợ khách hàng</a></li> 
                <li><a href='../BaoCao/DSNoKhachHang.aspx'><i class='fa fa-table'></i>Trả nợ khách hàng</a></li>
                <li><a href='../BaoCao/NoNhaCungCap.aspx'><i class='fa fa-table'></i>Thống kê thiếu nợ NCC</a></li>
                <li><a href='../BaoCao/PhieuTraNoNhaCungCap.aspx'><i class='fa fa-table'></i>Trả nợ NCC</a></li>
              </ul>
           </li>";



            ///////// Thống kê doanh thu
            DataTable layNgay = Connect.GetTable("select Convert(nvarchar(20),GETDATE(),103)");
            if (URL.Contains("/THONGKEDOANHTHU/"))
                html += "  <li id='dvThongKeDoanhThu' class='treeview active'>";
            else
                html += "  <li id='dvThongKeDoanhThu' class='treeview'>";
            html += @"<a href='#'><i class='fa fa-bar-chart'></i> <span>THỐNG KÊ-DOANH SỐ</span> <i class='fa fa-angle-left pull-right'></i></a>
              <ul class='treeview-menu'>
                <li><a href='../ThongKeDoanhThu/ThongKeTonKho.aspx'><i class='fa fa-table'></i>Thống kê hàng tồn theo kho</a></li>
                <li><a href='../ThongKeDoanhThu/LoiNhuan.aspx?TuNgayNhap=" + layNgay.Rows[0][0].ToString() + @"&DenNgayNhap=" + layNgay.Rows[0][0].ToString() + @"'><i class='fa fa-table'></i>Thống kê lợi nhuận</a></li>  
                <li><a href='../ThongKeDoanhThu/DanhMucXuatHang.aspx'><i class='fa fa-table'></i>Thống kê bán hàng</a></li>
              </ul>
           </li>";


            ///////// Thống kê trong ngay 
            if (URL.Contains("/THONGKETRONGNGAY/"))
                html += "  <li id='dvThongKeTrongNgay' class='treeview active'>";
            else
                html += "  <li id='dvThongKeTrongNgay' class='treeview'>";
            html += @"<a href='#'><i class='fa fa-bar-chart'></i> <span>THỐNG KÊ-TRONG NGÀY</span> <i class='fa fa-angle-left pull-right'></i></a>
              <ul class='treeview-menu'> 
                <li><a href='../ThongKeTrongNgay/DanhMucXuatHang.aspx?TuNgayXuat=" + layNgay.Rows[0][0].ToString() + @"&DenNgayXuat=" + layNgay.Rows[0][0].ToString() + @"'><i class='fa fa-table'></i>Bán hàng hôm nay</a></li>  
                <li><a href='../ThongKeTrongNgay/DanhMucNhapHang.aspx?TuNgayNhap=" + layNgay.Rows[0][0].ToString() + @"&DenNgayNhap=" + layNgay.Rows[0][0].ToString() + @"'><i class='fa fa-table'></i>Nhập hàng hôm nay</a></li>   
                <li><a href='../ThongKeTrongNgay/PhieuTraNoKhachHang.aspx?TuNgayNhap=" + layNgay.Rows[0][0].ToString() + @"&DenNgayNhap=" + layNgay.Rows[0][0].ToString() + @"'><i class='fa fa-table'></i>Khách hàng trả nợ</a></li>
                <li><a href='../ThongKeTrongNgay/DSNoKhachHang.aspx?TuNgayNhap=" + layNgay.Rows[0][0].ToString() + @"&DenNgayNhap=" + layNgay.Rows[0][0].ToString() + @"'><i class='fa fa-table'></i>Trả nợ khách hàng</a></li>"; 

        }
        else if (Quyen.Equals("NhanVien"))
        {
            if (URL.Contains("/DANHMUC/"))
                html += "  <li id='dvDanhMuc' class='treeview active'>";
            else
                html += "  <li id='dvDanhMuc' class='treeview'>";
            html += @"<a href='#'><i class='fa fa-list'></i> <span>DANH MỤC</span> <i class='fa fa-angle-left pull-right'></i></a>
              <ul class='treeview-menu'>
                <li><a href='../DanhMuc/DanhMucNhaCungCap.aspx'><i class='fa fa-edit'></i>Danh mục nhà cung cấp</a></li>
               
                <li><a href='../DanhMuc/DanhMucKhachHang.aspx'><i class='fa fa-edit'></i>Danh mục khách hàng</a></li>

                 <li><a href='../DanhMuc/DanhMucKhachHangSanPham.aspx'><i class='fa fa-edit'></i>Danh mục giá theo khách</a></li>
  <li><a href='../DanhMuc/DanhMucLoaiHangCapCao.aspx'><i class='fa fa-edit'></i>Danh mục loại hàng hóa</a></li> 
<li><a href='../DanhMuc/DanhMucLoaiHangHoa.aspx'><i class='fa fa-edit'></i>Danh mục hàng hóa</a></li> 

<li><a href='../DanhMuc/DVT.aspx'><i class='fa fa-edit'></i>Đơn vị tính</a></li>
                <li><a href='../DanhMuc/DonViTinh.aspx'><i class='fa fa-edit'></i>Size</a></li>
                <li><a href='../DanhMuc/MauSac.aspx'><i class='fa fa-edit'></i>Màu sắc</a></li>
                <li><a href='../DanhMuc/ChatLieu.aspx'><i class='fa fa-edit'></i>Chất liệu</a></li>
                <li><a href='../DanhMuc/KieuDang.aspx'><i class='fa fa-edit'></i>Kiểu dáng</a></li>
        <li><a href='../DanhMuc/Kho.aspx'><i class='fa fa-edit'></i>Danh mục kho</a></li>
              </ul>
           </li>";
            //End danh mục
            //Quản lý dụng cụ
            /*   if (URL.Contains("/QUANLYXUATNHAP/"))
                   html += "  <li id='dvQuanLyDungCu' class='treeview active'>";
               else
                   html += "  <li id='dvQuanLyDungCu' class='treeview'>";
               html += @"<a href='#'><i class='fa fa-refresh' aria-hidden='true'></i> <span>QUẢN LÝ XUẤT NHẬP</span> <i class='fa fa-angle-left pull-right'></i></a>
                     <ul class='treeview-menu'>
        <li><a href='../QuanLyXuatNhap/DanhMucNhapHang.aspx'><i class='fa fa-edit'></i>Danh mục nhập hàng</a></li>
                       <li><a href='../QuanLyXuatNhap/DanhMucXuatHang.aspx'><i class='fa fa-edit'></i>Danh mục xuất hàng</a></li>
               
                     </ul>
                  </li>";*/
            if (URL.Contains("/QUANLYNHAPHANG/"))
            {
                html += @"  <li id='dvQuanLyDungCu' class='treeview active'><a href='../QuanLyNhapHang/DanhMucNhapHang.aspx'><i class='fa fa-download' aria-hidden='true'></i> <span>QUẢN LÝ NHẬP HÀNG</span></a>";
                html += " </li>";
            }
            else
            {
                html += @"  <li id='dvQuanLyDungCu' class='treeview'>
            <a href='../QuanLyNhapHang/DanhMucNhapHang.aspx'><i class='fa fa-download' aria-hidden='true'></i> <span>QUẢN LÝ NHẬP HÀNG</span></a>";
                html += " </li>";
            }


            if (URL.Contains("/DONHANGTUWEB/"))
            {
                html += @"  <li id='divWeb' class='treeview active'><a href='../DonHangTuWeb/DonHangTuWeb.aspx'><i class='fa fa-download' aria-hidden='true'></i> <span>ĐƠN HÀNG TỪ WEB</span></a>";
                html += " </li>";
            }
            else
            {
                html += @"  <li id='divWeb' class='treeview'>
            <a href='../DonHangTuWeb/DonHangTuWeb.aspx'><i class='fa fa-download' aria-hidden='true'></i> <span>ĐƠN HÀNG TỪ WEB</span></a>";
                html += " </li>";
            }



            DataTable a = Connect.GetTable("select convert(nvarchar(20),GETDATE(),103) as 'Ngay'");
            if (URL.Contains("/QUANLYXUATHANG/"))
            {
                html += @"  <li id='dvQuanLyDungCu' class='treeview active'><a href='../QuanLyXuatHang/DanhMucXuatHang.aspx?TuNgayXuat=" + DateTime.Now.ToString("dd/MM/yyyy") + "&DenNgayXuat=" + DateTime.Now.ToString("dd/MM/yyyy") + "&'><i class='fa fa-upload' aria-hidden='true'></i> <span>QUẢN LÝ BÁN HÀNG</span></a>";
                html += " </li>";
            }
            else
            {
                html += @"  <li id='dvQuanLyDungCu' class='treeview'><a href='../QuanLyXuatHang/DanhMucXuatHang.aspx?TuNgayXuat=" + DateTime.Now.ToString("dd/MM/yyyy") + "&DenNgayXuat=" + DateTime.Now.ToString("dd/MM/yyyy") + "&'><i class='fa fa-upload' aria-hidden='true'></i> <span>QUẢN LÝ BÁN HÀNG</span></a>";
                html += " </li>";
            }

            string sql = @"
select count(*) from(select HangHoa.IDHangHoa,HangHoa.TenHangHoa
,(select isnull(sum(ChiTietPhieuNhap.SoLuong),0) from ChiTietPhieuNhap where ChiTietPhieuNhap.IDHangHoa = HangHoa.IDHangHoa) as 'SoLuongNhap'
,(select isnull(sum(ChiTietPhieuXuat.SoLuong),0) from ChiTietPhieuXuat where ChiTietPhieuXuat.IDHangHoa = HangHoa.IDHangHoa) as 'SoLuongXuat'
 from HangHoa) as tb1 where (tb1.SoLuongNhap-tb1.SoLuongXuat <=10) ";
            DataTable tbTotalRows = Connect.GetTable(sql);

            int TotalRows = int.Parse(tbTotalRows.Rows[0][0].ToString());
            if (TotalRows > 0)
            {


                if (URL.Contains("/BAOCAOHETHAN/"))
                {
                    html += @"  <li id='dvQuanLyDungCu' class='treeview active'><a href='../BaoCaoHetHan/CanhBaoHetHang.aspx'><i class='fa fa-warning' aria-hidden='true'></i> <span>HÀNG SẮP HẾT</span><small class='label pull-right bg-red notication' style='margin-top: -10px;padding: 5px;'>" + TotalRows + @"</small></a>";
                    html += " </li>";
                }
                else
                {
                    html += @"  <li id='dvQuanLyDungCu' class='treeview'><a href='../BaoCaoHetHan/CanhBaoHetHang.aspx'><i class='fa fa-warning' aria-hidden='true'></i> <span>HÀNG SẮP HẾT</span><small class='label pull-right bg-red notication' style='margin-top: -10px;padding: 5px;'>" + TotalRows + @"</small></a>";
                    html += " </li>";
                }
            }
            else
            {
                if (URL.Contains("/BAOCAOHETHAN/"))
                {
                    html += @"  <li id='dvQuanLyDungCu' class='treeview active'><a href='../BaoCaoHetHan/CanhBaoHetHang.aspx'><i class='fa fa-warning' aria-hidden='true'></i> <span>HÀNG SẮP HẾT</span></a>";
                    html += " </li>";
                }
                else
                {
                    html += @"  <li id='dvQuanLyDungCu' class='treeview'><a href='../BaoCaoHetHan/CanhBaoHetHang.aspx'><i class='fa fa-warning' aria-hidden='true'></i> <span>HÀNG SẮP HẾT</span></a>";
                    html += " </li>";
                }
            }
            if (URL.Contains("/BAOCAO/"))
                html += "  <li id='dvThongKe' class='treeview active'>";
            else
                html += "  <li id='dvThongKe' class='treeview'>";
            html += @"<li><a href='../BaoCao/ThongKeTonKho.aspx'><i class='fa fa-table'></i>Thống kê hàng tồn theo kho</a></li>";
        }




        html += "</ul>";


        dvMenu.InnerHtml = html;
    }
}
