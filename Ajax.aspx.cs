using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using iTextSharp.text;
//using iTextSharp.text.html.simpleparser;
//using iTextSharp.text.pdf;
using System.IO;
using System.Globalization;
using System.Text;

using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Zen.Barcode;
//using Spire.Doc;
//using Spire.Doc.Documents;


public partial class Ajax : System.Web.UI.Page
{
    string sTenDangNhap = "";
    string mQuyen = "";
    public Microsoft.Office.Interop.Word.Document wordDocument { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["QuanLyHoaDongDifoco_Login"] != null && Session["QuanLyHoaDongDifoco_Login"].ToString() != "")
        //{
        //    sTenDangNhap = Session["QuanLyHoaDongDifoco_Login"].ToString();
        //    mQuyen = StaticData.getField("tb_Admin", "MaNhomAdmin", "TenDangNhap", sTenDangNhap);
        //}
        //else
        //{
        //    //Response.Redirect("Home/DangNhap.aspx");
        //}
        /* if (Request.Cookies["QuanLyNhapXuatHang_Login"] != null && Request.Cookies["QuanLyNhapXuatHang_Login"].Value.Trim() != "")
         {
             if (Request.Cookies["QuanLyNhapXuatHang_Quyen"] != null && Request.Cookies["QuanLyNhapXuatHang_Quyen"].Value.Trim() != "")
             {
                 string Quyen = Request.Cookies["QuanLyNhapXuatHang_Quyen"].Value.Trim();
                 if (Quyen.CompareTo("Admin") == 0)
                 {

                 }
                 else
                 {
                     Response.Redirect("Home/Default.aspx");
                 }
             }
         }
         else
         {
             Response.Redirect("Home/Default.aspx");
         }*/
        string action = Request.QueryString["Action"].Trim();
        switch (action)
        {
            case "rsSoLuongTon":
                rsSoLuongTon(); break;
            case "TenPhongBanAutocomplete":
                TenPhongBanAutocomplete(); break;
            case "DeleteNguoiDung":
                DeleteNguoiDung(); break;
            case "DangXuat":
                DangXuat(); break;
            case "DeleteAdmin":
                DeleteAdmin(); break;
            case "NhaCungCapAutocomplete":
                NhaCungCapAutocomplete(); break;
            case "KhachHangAutocomplete":
                KhachHangAutocomplete(); break;
            case "LoadSoDienThoaiAutocomplete":
                LoadSoDienThoaiAutocomplete(); break;

            case "DeleteNhaCungCap":
                DeleteNhaCungCap(); break;
            case "DeletePhieuChia":
                DeletePhieuChia(); break;

            case "TenChungLoaiAutocomplete":
                TenChungLoaiAutocomplete(); break;

            case "DeleteChungLoaiHangHoa":
                DeleteChungLoaiHangHoa(); break;

            case "NhomHangHoaAutocomplete":
                NhomHangHoaAutocomplete(); break;

            case "DeleteNhomHangHoa":
                DeleteNhomHangHoa(); break;

            case "DonViTinhAutocomplete":
                DonViTinhAutocomplete(); break;

            case "DeleteDonViTinh":
                DeleteDonViTinh(); break;

            case "MauSacAutocomplete":
                MauSacAutocomplete(); break;

            case "DeleteMauSac":
                DeleteMauSac(); break;

            case "MaKhachAutocomplete":
                MaKhachAutocomplete(); break;

            case "SoDienThoaiAutocomplete":
                SoDienThoaiAutocomplete(); break;

            case "TenKhachAutocomplete":
                TenKhachAutocomplete(); break;

            case "DeleteKhachHang":
                DeleteKhachHang(); break;

            case "TenSanPhamAutocomplete":
                TenSanPhamAutocomplete(); break;

            case "MaSanPhamAutocomplete":
                MaSanPhamAutocomplete(); break;

            case "DeleteHangHoa":
                DeleteHangHoa(); break;

            case "TenKhachTheoSanPhamAutocomplete":
                TenKhachTheoSanPhamAutocomplete(); break;
            case "TenSanPhamTheoKhachAutocomplete":
                TenSanPhamTheoKhachAutocomplete(); break;

            case "LoadChiTietPhieuNhap":
                LoadChiTietPhieuNhap(); break;
            case "DeleteKhachHangSanPham":
                DeleteKhachHangSanPham(); break;

            case "LoadMa":
                LoadMa(); break;

            case "ABCAutocomplete":
                ABCAutocomplete(); break;
            case "TenNhaCCNhapAutocomplete":
                TenNhaCCNhapAutocomplete(); break;

            case "ThemChiTietPhieuNhap":
                ThemChiTietPhieuNhap(); break;

            case "SuaChiTietNhap":
                SuaChiTietNhap(); break;
            case "SuaChiTietPhieuNhap":
                SuaChiTietPhieuNhap(); break;

            case "DeleteChiTietPhieuNhap":
                DeleteChiTietPhieuNhap(); break;

            case "DeletePhieuNhap":
                DeletePhieuNhap(); break;

            case "LoadChiTietPhieuXuat":
                LoadChiTietPhieuXuat(); break;

            case "LoadChiTietLoiNhuan":
                LoadChiTietLoiNhuan(); break;

            case "LoadChiTietTonKHo":
                LoadChiTietTonKHo(); break;

            case "LoadLenKhachHangAutocomplete":
                LoadLenKhachHangAutocomplete(); break;

            case "LoadLenGiaTheoKhachHang":
                LoadLenGiaTheoKhachHang(); break;

            case "ThemChiTietPhieuXuat":
                ThemChiTietPhieuXuat(); break;

            case "SuaChiTietXuat":
                SuaChiTietXuat(); break;

            case "SuaChiTietPhieuXuat":
                SuaChiTietPhieuXuat(); break;

            case "DeleteChiTietPhieuXuat":
                DeleteChiTietPhieuXuat(); break;

            case "loadmaphieuxuat":
                loadmaphieuxuat(); break;

            case "DeletePhieuXuat":
                DeletePhieuXuat(); break;

            case "loadmaphieunhap":
                loadmaphieunhap(); break;

            case "THHhoa":
                THHhoa(); break;

            case "LoadChiTietNhapHang":
                LoadChiTietNhapHang(); break;
            case "LoadChiTietXuatHang":
                LoadChiTietXuatHang(); break;
            case "LoadTaiKhoan":
                LoadTaiKhoan(); break;
            case "LoadTenNguoiDung":
                LoadTenNguoiDung(); break;
            case "Mo2":
                Mo2(); break;

            case "DeletePhongBan":
                DeletePhongBan(); break;

            case "PhongBanAutocomplete":
                PhongBanAutocomplete(); break;

            case "TenCuaHangAutocomplete":
                TenCuaHangAutocomplete(); break;

            case "PhongBanChoCuaHangAutocomplete":
                PhongBanChoCuaHangAutocomplete(); break;
            case "XemCuaHang":
                XemCuaHang(); break;
            case "XemPhongBan":
                XemPhongBan(); break;

            case "DeleteCuaHang":
                DeleteCuaHang(); break;

            case "LayGiaNhapGanNhat":
                LayGiaNhapGanNhat(); break;

            case "ExportExcel":
                ExportExcel(); break;
            case "ExportExcel2":
                ExportExcel2(); break;

            case "LayIDNhapGanNhat2":
                LayIDNhapGanNhat2(); break;

            case "LayGiaNhapGanNhat2":
                LayGiaNhapGanNhat2(); break;

            case "ABCAutocomplete3":
                ABCAutocomplete3(); break;
            case "Inpdf":
                Inpdf(); break;
            case "LayDGBQGQ":
                LayDGBQGQ(); break;

            case "DeleteKho":
                DeleteKho(); break;

            case "LoadKho":
                LoadKho(); break;

            case "LoadMauSize":
                LoadMauSize(); break;
            case "DeletePhieuTraNo":
                DeletePhieuTraNo(); break;
            case "DeleteLoaiHangHoa":
                DeleteLoaiHangHoa(); break;
            case "ThemTheoLoaiHangHoa":
                ThemTheoLoaiHangHoa(); break;

            case "ThemTheoLoaiHangHoaPhieuXuat":
                ThemTheoLoaiHangHoaPhieuXuat(); break;

            case "DeletePhieuTraNoNhaCungCap":
                DeletePhieuTraNoNhaCungCap(); break;

            case "showChiTietLoiNhuan":
                showChiTietLoiNhuan(); break;

            case "XemTonGiuaCacKho":
                XemTonGiuaCacKho(); break;

            case "InPhieuXuatHang":
                InPhieuXuatHang(); break;

            case "DeleteLoaiHangCapCao":
                DeleteLoaiHangCapCao(); break;

            case "ThemTheoLoaiHangCapCao":
                ThemTheoLoaiHangCapCao(); break;
            case "ThemTheoLoaiHangCapCaoPhieuXuat":
                ThemTheoLoaiHangCapCaoPhieuXuat(); break;

            case "XemChiTietMauSize":
                XemChiTietMauSize(); break;

            case "InPhieuTongHopXuatHang":
                InPhieuTongHopXuatHang(); break;
            case "InPhieuTongHopXuatHang2":
                InPhieuTongHopXuatHang2(); break;
            case "LoadLenGiaTheoKhachThoi":
                LoadLenGiaTheoKhachThoi(); break;

            case "TongTienDonHang":
                TongTienDonHang(); break;

            case "TongTienKhachNo":
                TongTienKhachNo(); break;

            case "CongLai":
                CongLai(); break;

            case "XemChiTietDonHang":
                XemChiTietDonHang(); break;



            case "InPhieuTongHopNhapHang":
                InPhieuTongHopNhapHang(); break;

            case "rsGiaTheoKhach":
                rsGiaTheoKhach(); break;

            case "InChiTietVaSua":
                InChiTietVaSua(); break;
            case "LoaiKhachHang":
                LoaiKhachHang(); break;
        }
    }
    private void LoaiKhachHang()
    {
        string sql = "SELECT * from KhachHangNhom";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";
      
        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";
            listgAutocomplete += "value: '" + table.Rows[i]["TenNhomKH"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["TenNhomKH"].ToString() + "-" + table.Rows[i]["TenLoaiKH"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["idNhomKH"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }

    private void InChiTietVaSua()
    {
        string IDPhieuXuat = StaticData.ValidParameter(Request.QueryString["IDPhieuXuat"].Trim());
        string IDKhachHang = StaticData.ValidParameter(Request.QueryString["IDKhachHang"].Trim());
        string NgayXuat = StaticData.ValidParameter(Request.QueryString["NgayXuat"].Trim());
        string IDKho = StaticData.ValidParameter(Request.QueryString["IDKho"].Trim());
        string GhiChu = StaticData.ValidParameter(Request.QueryString["GhiChu"].Trim());
        string TienThanhToan = StaticData.ValidParameter(Request.QueryString["TienThanhToan"].Trim());
        string MaPhieuXuat = StaticData.ValidParameter(Request.QueryString["MaPhieuXuat"].Trim());
        string sql = "update PhieuXuat set TienThanhToan=" + TienThanhToan.Replace(",", "").Replace(".", "") + ",IDKho=" + IDKho + ",MaPhieuXuat=N'" + MaPhieuXuat + "',NgayXuat='" + StaticData.ConvertDDMMtoMMDD(NgayXuat) + "',GhiChu = N'" + GhiChu + "' where IDPhieuXuat = " + IDPhieuXuat + "";
        bool kq = Connect.Exec(sql);
        if (kq)
        {
            string sql2 = "insert into BangLog(TaiKhoan,ThaoTac,NgayGio) values (N'" + Request.Cookies["BanSiQuanAo_Login"].Value.Trim() + "',N'Sửa thông tin phiếu xuất hàng " + MaPhieuXuat + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "')";
            bool kq2 = Connect.Exec(sql2);

            Response.Write("True");
        }
        else
        {
            Response.Write("False" + sql);

        }

    }
    private void InPhieuTongHopXuatHang2()
    {
        string IDPhieuXuat = StaticData.ValidParameter(Request.QueryString["IDPhieuXuat"].Trim());
        DataTable tablezz = Connect.GetTable("select * from( SELECT ROW_NUMBER() OVER(order by PhieuXuat.IDPhieuXuat DESC)AS RowNumber,PhieuXuat.* FROM PhieuXuat,KhachHang where KhachHang.IDKhachHang=PhieuXuat.IDKhachHang and MaPhieuXuat not like '%-XB' ) as tb1 where IDPhieuXuat = N'" + IDPhieuXuat + "'");
        string sqlk = @"  select isnull(sum(DonGiaXuat*SoLuong),0) as 'Tong' from ChiTietPhieuXuat where ChiTietPhieuXuat.IDPhieuXuat =" + IDPhieuXuat;
        DataTable tblk = Connect.GetTable(sqlk);
        double TongTienDonHang = double.Parse(tblk.Rows[0]["Tong"].ToString());
        string sqlj = @"  select isnull(sum(DonGiaXuat*SoLuong),0) as 'Tong' from ChiTietPhieuXuat where ChiTietPhieuXuat.IDPhieuXuat = " + IDPhieuXuat + " ";
        DataTable tablej = Connect.GetTable(sqlj);
        double ConLai = MyStaticData.GetNoKhachHangNgoaiTruPhieuXuat(tablezz.Rows[0]["IDKhachHang"].ToString(), tablezz.Rows[0]["IDPhieuXuat"].ToString()) - MyStaticData.GetSoTienDaTraCuaKhachHang(tablezz.Rows[0]["IDKhachHang"].ToString());
        string TongTienKhachNo = "";
        string TienKhachThanhToan = "";
        if (ConLai == 0)
        {
            TongTienKhachNo = "0";
        }
        else
        {
            TongTienKhachNo = ConLai.ToString("#,##").Replace(",", ".").Trim();
        }
        double re = TongTienDonHang + ConLai;
        string TongTienPhaiTra = "";
        if (re == 0)
        {
            TongTienPhaiTra = "0";
        }
        else
        {
            TongTienPhaiTra = re.ToString("#,##").Replace(",", ".").Trim();
        }
        string IDKhoi = tablezz.Rows[0]["IDKho"].ToString().Trim();
        if (tablezz.Rows[0]["TienThanhToan"].ToString() == "0")
            TienKhachThanhToan = "0";
        else TienKhachThanhToan = double.Parse(tablezz.Rows[0]["TienThanhToan"].ToString()).ToString("#,##").Replace(",", ".");
        string TongTienDH2 = "";
        if (TongTienDonHang == 0)
            TongTienDH2 = "0";
        else
            TongTienDH2 = TongTienDonHang.ToString("##,0").Replace(",", ".");






        string TienDonHang = TongTienDH2;

        double TongTienKhachNoSo = 0;
        if (TongTienKhachNo.Trim() != "")
        {
            TongTienKhachNoSo = double.Parse(TongTienKhachNo.Replace(",", "").Replace(".", ""));
        }


        string TienThanhToan = TienKhachThanhToan.Trim();

        string IdKho = IDKhoi;


        double TienThanhToanSo = 0;
        if (TienThanhToan != "")
        {
            TienThanhToanSo = double.Parse(TienThanhToan.Replace(",", "").Replace(".", ""));
        }

        string sql = "update PhieuXuat set TienThanhToan=" + TienThanhToanSo.ToString() + ",IDKho= " + IdKho + " where IDPhieuXuat = " + IDPhieuXuat + "";

        bool kq = Connect.Exec(sql);



        BarcodeSymbology s = BarcodeSymbology.Code39C;
        BarcodeDraw drawObject = BarcodeDrawFactory.GetSymbology(s);
        var metrics = drawObject.GetDefaultMetrics(60);
        metrics.Scale = 2;
        var barcodeImage = drawObject.Draw(StaticData.getField("PhieuXuat", "MaPhieuXuat", "IDPhieuXuat", IDPhieuXuat), metrics);

        string barCode = "";

        using (MemoryStream ms = new MemoryStream())
        {
            barcodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] imageBytes = ms.ToArray();

            barCode = Convert.ToBase64String(imageBytes);
        }
        string html = @"
<table style='width:100%;'>
<tr>
<td>

<b>HỆ THỐNG DOLOTGIASI.VN</b><br />
0909 437 977 - 0932 070 729

</td>
<td style='text-align:center;'>
<h3>HÓA ĐƠN BÁN HÀNG</h3>
</td>
</tr>
</table>
<hr />

";

        DataTable table = Connect.GetTable("select * from PhieuXuat where IDPhieuXuat=" + IDPhieuXuat + "");

        string MaPhieuNhap = "-";
        try
        {
            MaPhieuNhap = table.Rows[0]["MaPhieuXuat"].ToString().Substring(table.Rows[0]["MaPhieuXuat"].ToString().Length - 4, 4);
        }
        catch
        {
            MaPhieuNhap = "-";
        }

        html += @"

<table style='width:100%;'>
<tr>
<td style='text-align:left;'><b>Tên khách hàng :</b> " + StaticData.getField("KhachHang", "TenKhachHang", "IDKhachHang", table.Rows[0]["IDKhachHang"].ToString()) + " - " + MaPhieuNhap + @"</td>
<td style='text-align:left;'>&nbsp;</td>

</tr>
<tr>
<td>&nbsp;";
        // if (table.Rows[0]["TienThanhToan"].ToString().Trim() == "0")
        //html += @"<b>Tiền thanh toán :</b> 0";
        //  else
        //     html += "<b>Tiền khách thanh toán :</b> " + double.Parse(table.Rows[0]["TienThanhToan"].ToString()).ToString("#,##").Replace(",", ".") + @"";
        html += @"</td>
<td><b>Ghi chú :</b> " + table.Rows[0]["GhiChu"].ToString().Replace("\n", "<br />") + @"</td>

</tr>

</tr>
<tr>
<td>";
        if (DateTime.Parse(table.Rows[0]["NgayXuat"].ToString()).ToString("dd/MM/yyyy") == "")
            html += @"<b>Ngày :</b> - ";
        else
            html += "<b>Ngày:</b> " + DateTime.Parse(table.Rows[0]["NgayXuat"].ToString()).ToString("dd/MM/yyyy") + @"";
        html += @"</td>
<td>&nbsp;</td>

</tr>

<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>

</tr>
</table>
<div style='text-align:center;'>";

        html += @"<br /><center><table border='1' cellspacing='0' style='width:100%;' ><tr>
             <th class='th'>&nbsp;</th>
             <th class='th'>Hàng hóa</th>
            <th class='th'>ĐVT</th>
             <th class='th'>SL</th>
            <th class='th'>ĐG</th>
            <th class='th'>TT</th>
          </tr>";
        double Tong = 0;
        double sl = 0;

        string query = @"select tb2.IDLoaiHangHoa,tb2.SoLuong,tb2.DonGia,tb2.ThanhTien
from 
(select HangHoa.IDLoaiHangHoa, isnull(sum(ChiTietPhieuXuat.SoLuong),0) as 'SoLuong' , isnull(AVG(ChiTietPhieuXuat.DonGiaXuat),0) as 'DonGia',  isnull(sum(ChiTietPhieuXuat.SoLuong),0) *  isnull(AVG(ChiTietPhieuXuat.DonGiaXuat),0) AS 'ThanhTien' 
from ChiTietPhieuXuat,HangHoa 
where ChiTietPhieuXuat.IDHangHoa=HangHoa.IDHangHoa and IDPhieuXuat=" + IDPhieuXuat + @"
 group by HangHoa.IDLoaiHangHoa) as tb2
 
 ,
( 
select ROW_NUMBER() OVER(ORDER BY ChiTietPhieuXuat.IDChiTietPhieuXuat asc)AS RowNumber,HangHoa.IDLoaiHangHoa from ChiTietPhieuXuat,PhieuXuat,HangHoa 
 where ChiTietPhieuXuat.IDPhieuXuat=PhieuXuat.IDPhieuXuat and ChiTietPhieuXuat.IDHangHoa=HangHoa.IDHangHoa
 and PhieuXuat.IDPhieuXuat = " + IDPhieuXuat + @" 
 ) as tb3
 where tb2.IDLoaiHangHoa = tb3.IDLoaiHangHoa order by tb3.RowNumber";
        DataTable dtTable = Connect.GetTable(query);

        DataTable bang = Connect.GetTable("select HangHoa.IDLoaiHangHoa, isnull(sum(ChiTietPhieuXuat.SoLuong),0) as 'SoLuong' , isnull(AVG(ChiTietPhieuXuat.DonGiaXuat),0) as 'DonGia',  isnull(sum(ChiTietPhieuXuat.SoLuong),0) *  isnull(AVG(ChiTietPhieuXuat.DonGiaXuat),0) AS 'ThanhTien' from ChiTietPhieuXuat,HangHoa where ChiTietPhieuXuat.IDHangHoa=HangHoa.IDHangHoa and IDPhieuXuat=" + IDPhieuXuat + " group by HangHoa.IDLoaiHangHoa");
        bang = MyStaticData.RemoveDuplicateRows(dtTable, "IDLoaiHangHoa");
        for (int i = 0; i < bang.Rows.Count; i++)
        {
            html += "<tr>";
            html += "<td>" + (i + 1).ToString() + "</td>";
            //  html += "<td>" + StaticData.getField("LoaiHangHoa", "MaLoaiHangHoa", "IDLoaiHangHoa", bang.Rows[i]["IDLoaiHangHoa"].ToString()) + "</td>";
            html += "<td>" + StaticData.getField("LoaiHangHoa", "MaLoaiHangHoa", "IDLoaiHangHoa", bang.Rows[i]["IDLoaiHangHoa"].ToString()) + " - " + StaticData.getField("LoaiHangHoa", "TenLoaiHangHoa", "IDLoaiHangHoa", bang.Rows[i]["IDLoaiHangHoa"].ToString()) + "</td>";

            html += "<td>" + StaticData.getField("DonViTinh", "TenDonViTinh", "idDonViTinh", StaticData.getField("LoaiHangHoa", "IDDonViTinh", "IDLoaiHangHoa", bang.Rows[i]["IDLoaiHangHoa"].ToString())) + "</td>";

            if (bang.Rows[i]["SoLuong"].ToString().Trim() == "0")
                html += "<td style='text-align:center;'>" + bang.Rows[i]["SoLuong"].ToString() + "</td>";
            else html += "<td style='text-align:center;'>" + double.Parse(bang.Rows[i]["SoLuong"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";
            sl += double.Parse(bang.Rows[i]["SoLuong"].ToString());
            if (bang.Rows[i]["DonGia"].ToString().Trim() == "0")
                html += "<td style='text-align:right;'>" + bang.Rows[i]["DonGia"].ToString() + "</td>";
            else html += "<td style='text-align:right;'>" + double.Parse(bang.Rows[i]["DonGia"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";

            if (bang.Rows[i]["ThanhTien"].ToString().Trim() == "0")
                html += "<td style='text-align:right;'>" + bang.Rows[i]["ThanhTien"].ToString() + "</td>";
            else html += "<td style='text-align:right;'>" + double.Parse(bang.Rows[i]["ThanhTien"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";

            double thanhTien = double.Parse(bang.Rows[i]["ThanhTien"].ToString());

            Tong += thanhTien;
            html += "</tr>";
        }

        double TongThanhToan = Tong + TongTienKhachNoSo;

        html += "<tr >";
        html += "<td colspan='3' style='text-align:right;'>&nbsp;</td>";
        html += "<td style='text-align:center;' >" + sl.ToString("#,##").Replace(",", ".") + "</td>";
        html += "<td colspan='2' style='text-align:right;'>&nbsp;</td>";
        html += "</tr>";
        html += "<tr >";
        // html += "<td colspan='6' style='text-align:left;'><b>Bằng chữ:</b> " + StaticData.ConvertDecimalToString(decimal.Parse(Tong.ToString())) + "</td>";

        html += "</tr>";
        html += @"</table> 


    

<table style='width:100%'> 
  <tr>
    <td style='width:40%; text-align:center'>

    Ngày ... tháng ... năm 20.... </br>
    <b> Người lập phiếu </b> </br>
    <i> (Ký và ghi rõ họ tên) </i>

</td>
    <td>
<table style='width:100%;' border=1>

  <tr >
    <td><b>Tổng thành tiền: </b> </td>
    <td style='text-align: right'>" + TienDonHang + @"</td>
  </tr>
  <tr>
    <td> <b>Nợ cũ:</b> </td>
    <td style='text-align: right'> " + string.Format("{0:N0}", TongTienKhachNoSo).Replace(",", ".") + @"</td>
  </tr>
  <tr>
    <td> <b> Tổng tiền phải trả: </b> </td>
   <td style='text-align: right'>" + string.Format("{0:N0}", TongTienPhaiTra).Replace(",", ".") + @"</td>
  </tr>


 <tr>
    <td> <b> Tiền khách thanh toán: </b> </td>
   <td style='text-align: right'>" + string.Format("{0:N0}", TienThanhToan).Replace(",", ".") + @"</td>
  </tr>


</table>



</td>
  </tr> 
</table>



        </center> ";


        html += @"</div>";
        //        html += @"</div>
        //        <br /> 
        //
        //        - NH Đông Á: Võ Thị Thu Nga - STK: 0101303801 - (CN quận 5) <br />
        //        - NH Vietcombank:  Võ Thị Thu Nga - STK:007 1000 762 264 - CN Tp. HCM <br />
        //        - NH Agribank: Võ Quang Vinh - STK: 1600 205 26 32 81 - CN Sài Gòn <br />
        //        - NH ACB: Võ Quang Vinh - STK: 182 768 219 -  CN. Lê Quang Định, Q.BT 
        //        
        //        
        //        ";

        Response.Write(html);
    }

    private void rsGiaTheoKhach()
    {
        string idKhachHang = StaticData.ValidParameter(Request.QueryString["IDKhachHang"].Trim());

        string sql = "update ChiTietGiaTheoKhach set Gia=0 where IDKhachHang=" + idKhachHang;
        bool ktDelete = Connect.Exec(sql);

        if (ktDelete)
            Response.Write("True");
        else
            Response.Write("False");
    }
    private void rsSoLuongTon()
    {

        string idLoaiHangHoa = StaticData.ValidParameter(Request.QueryString["idLoaiHangHoa"].Trim());
        string MaHangHoa = StaticData.getField("LoaiHangHoa", "MaLoaiHangHoa", "IDLoaiHangHoa", idLoaiHangHoa);
        string ktsl0 = @"select isnull(sum(TongSLNhap),0)-isnull(sum(TongSLXuat),0) from (select tb1.IDHangHoa,tb1.IDLoaiHangHoa,(
select isnull(sum(SoLuong),0) from ChiTietPhieuNhap where IDHangHoa=tb1.IDHangHoa)as TongSLNhap, 
(select isnull(sum(SoLuong),0) from ChiTietPhieuXuat where IDHangHoa=tb1.IDHangHoa) as TongSLXuat from (select HangHoa.* from HangHoa,LoaiHangHoa where HangHoa.IDLoaiHangHoa=LoaiHangHoa.IDLoaiHangHoa and LoaiHangHoa.IDLoaiHangHoa=" + idLoaiHangHoa + @") as tb1) as tb2";
        DataTable ktsl = Connect.GetTable(ktsl0);
        if (ktsl.Rows.Count > 0)
        {
            int SLConLai = Int32.Parse(ktsl.Rows[0][0].ToString().Trim());
            if (SLConLai != 0)
            {
                string sql2 = "insert into BangLog(TaiKhoan,ThaoTac,NgayGio) values (N'" + Request.Cookies["BanSiQuanAo_Login"].Value.Trim() + "',N'Reset tồn kho số lượng " + SLConLai.ToString() + " về 0 mã hàng " + MaHangHoa + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "')";
                bool kq2 = Connect.Exec(sql2);
                string sql = "select IDHangHoa from HangHoa where IDLoaiHangHoa='" + idLoaiHangHoa + "'";
                DataTable tb = Connect.GetTable(sql);
                if (tb.Rows.Count > 0)
                {
                    string Ngay = DateTime.Now.Day.ToString("00");
                    string Thang = DateTime.Now.Month.ToString("00");
                    string Nam = DateTime.Now.Year.ToString("00");
                    string ng = Thang + "/" + Ngay + "/" + Nam;
                    string maPX = "PBH" + "-" + StaticData.getField("PhieuXuat", "max(IDPhieuXuat)+1", "1", "1").Trim() + "-" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + "-XB";
                    string maPN = "PN" + "-" + StaticData.getField("PhieuNhap", "max(IDPhieuNhap)+1", "1", "1").Trim() + "-" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + "-XB";
                    //double tongtien = 0;
                    string sqlx = "insert into PhieuXuat values(N'" + maPX + "','" + ng + "',''," + 10108 + "," + 0 + "," + 1 + ")";
                    string sqln = "insert into PhieuNhap values (N'" + maPN + "','" + ng + "',''," + 32 + "," + 1 + "," + 0 + ")";
                    bool b = Connect.Exec(sqlx);
                    if (!Connect.Exec(sqln))
                        b = false;
                    string pIDKho = "";
                    string PX = StaticData.getField("PhieuXuat", "IDPhieuXuat", "MaPhieuXuat", maPX);
                    string PN = StaticData.getField("PhieuNhap", "IDPhieuNhap", "MaPhieuNhap", maPN);
                    double gia = 0;
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        string IDHHi = tb.Rows[i]["IDHangHoa"].ToString().Trim();
                        double TSL = TinhSoLuong(pIDKho, IDHHi);
                        string sqli = "";
                        if (TSL > 0)
                        {
                            string sqlgb = "select isnull(Gia,0) from ChiTietGiaTheoKhach where IDHangHoa='" + IDHHi + "' order by IDChiTietGiaTheoKhach DESC";
                            DataTable dtb = Connect.GetTable(sqlgb);
                            if (dtb.Rows.Count != 0)
                                gia = double.Parse(dtb.Rows[0][0].ToString().Trim());
                            else
                                gia = MyStaticData.GetGiaVon(tb.Rows[i]["IDHangHoa"].ToString().Trim());
                            sqli = "insert into ChiTietPhieuXuat values(" + PX + "," + tb.Rows[i]["IDHangHoa"].ToString().Trim() + "," + TSL + "," + gia + "," + MyStaticData.GetGiaVon(tb.Rows[i]["IDHangHoa"].ToString().Trim()) + ",N'')";
                            //tongtien += TSL * gia;
                        }
                        if (TSL < 0)
                        {
                            string sqlgn = "select DonGiaNhap from ChiTietPhieuNhap where IDHangHoa='" + IDHHi + "' order by IDChiTietPhieuNhap DESC";
                            DataTable dtn = Connect.GetTable(sqlgn);
                            if (dtn.Rows.Count != 0)
                                gia = double.Parse(dtn.Rows[0][0].ToString().Trim());
                            sqli = "insert into ChiTietPhieuNhap values(" + tb.Rows[i]["IDHangHoa"].ToString() + "," + PN + "," + (-TSL) + "," + gia + ",N'',null)";
                        }
                        bool s = true;
                        if (sqli != "")
                            s = Connect.Exec(sqli);
                        if (!s)
                            b = false;
                    }
                    if (b)
                    {
                        Response.Write("Thao tác thành công!");
                    }
                    else
                    {

                    }
                }
            }
            else
                Response.Write("Sản phẩm đã bằng 0");
        }
        else
            Response.Write("Không có sản phẩm");
    }
    private void XemChiTietDonHang()
    {
        string html = @" 

            <div style='text-align:center; '> CHI TIẾT ĐƠN HÀNG </div>

            <table class='table table-bordered table-striped'>
                    <tr>
                       
                        <th class='th'>
                         Hàng Hóa
                        </th>
                        <th class='th'>
                          Số lượng
                        </th>           
                          <th class='th'>
                        Giá
                        </th>
                        <th class='th'>
                           Thành tiền
                        </th>
                      
                    </tr>";



        string idDonHang = StaticData.ValidParameter(Request.QueryString["idDonHang"].Trim());

        string sql = @"SELECT * FROM ChiTietDonHangTuWeb WHERE idDonHang = '" + idDonHang + "'";

        DataTable tb = Connect.GetTable(sql);

        if (tb.Rows.Count > 0)
        {
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                string idHangHoa = tb.Rows[i]["idHangHoa"].ToString();
                string SoLuong = tb.Rows[i]["SoLuong"].ToString();

                string idLoaiHangHoa = StaticData.getField("HangHoa", "idLoaiHangHoa", "idHangHoa", idHangHoa);
                string idMauSac = StaticData.getField("HangHoa", "idMauSac", "idHangHoa", idHangHoa);
                string idSize = StaticData.getField("HangHoa", "idSize", "idHangHoa", idHangHoa);

                int Sl = 0;
                double DonGia = 0;

                string Gia = StaticData.getField("LoaiHangHoa", "GiaBanWeb", "IDLoaiHangHoa", idLoaiHangHoa);

                if (Gia.Trim() != "")
                {
                    DonGia = double.Parse(Gia);
                }

                if (SoLuong.Trim() != "")
                {
                    Sl = int.Parse(SoLuong);
                }

                double ThanhTien = Sl * DonGia;

                html += "       <tr>";

                html += "       <td>" + StaticData.getField("LoaiHangHoa", "MaLoaiHangHoa", "IDLoaiHangHoa", idLoaiHangHoa) + " - " + StaticData.getField("LoaiHangHoa", "TenLoaiHangHoa", "IDLoaiHangHoa", idLoaiHangHoa) + " - " + StaticData.getField("MauSac", "TenMauSac", "idMauSac", idMauSac) + " - " + StaticData.getField("Size", "TenSize", "idSize", idSize) + "</td>";
                html += "       <td>" + SoLuong.ToString() + "</td>";
                html += "       <td>" + string.Format("{0:N0}", DonGia).Replace(",", ".") + "</td>";
                html += "       <td>" + string.Format("{0:N0}", ThanhTien).Replace(",", ".") + "</td>";
                html += "       </tr>";

            }

        }

        html += "       </table>";

        Response.Write(html);

    }




    private void LoadChiTietTonKHo()
    {
        string IDLoaiHangHoa = StaticData.ValidParameter(Request.QueryString["IDLoaiHangHoa"].Trim());

        string pIDKho = "";


        DataTable timsize = Connect.GetTable("select distinct Size.MaSize,Size.IDSize from Size,HangHoa where HangHoa.IDSize = Size.IDSize and HangHoa.IDLoaiHangHoa = " + IDLoaiHangHoa + "");
        DataTable timmau = Connect.GetTable("select distinct MauSac.MaMauSac,MauSac.IDMauSac from MauSac,HangHoa where HangHoa.IDMauSac = MauSac.IDMauSac and HangHoa.IDLoaiHangHoa = " + IDLoaiHangHoa + "");


        string html = @"

<div style='font-size: 20px' > TỒN KHO HÀNG HÓA: <span style='color:red'> " + StaticData.getField("LoaiHangHoa", "TenLoaiHangHoa", "IDLoaiHangHoa", IDLoaiHangHoa) + " - " + StaticData.getField("LoaiHangHoa", "MaLoaiHangHoa", "IDLoaiHangHoa", IDLoaiHangHoa) + @"</span> </div>

<table class='table table-bordered' style='width:100%;'>
<tr>";

        html += "<td style='border: 1px solid #151010'> Màu \\ Size </td>";
        for (int i = 0; i < timsize.Rows.Count; i++)
        {
            html += "<td style='background-color: #3C8DBC; color:white; font-weight: bold;border: 1px solid #151010'>";
            html += timsize.Rows[i]["MaSize"].ToString();
            html += "</td>";
        }
        html += @"
</tr> ";

        for (int j = 0; j < timmau.Rows.Count; j++)
        {




            html += "<tr>";
            html += "<td style='background-color: #3C8DBC; color:white; font-weight: bold; border: 1px solid #151010'>";
            html += timmau.Rows[j]["MaMauSac"].ToString();
            html += "</td>";

            for (int k = 0; k < timsize.Rows.Count; k++)
            {
                string sql1 = @"SELECT idHangHoa FROM HangHoa WHERE idMauSac =  '" + timmau.Rows[j]["idMauSac"].ToString() + "' AND idSize = '" + timsize.Rows[k]["idSize"].ToString() + "' AND IdLoaiHangHoa = '" + IDLoaiHangHoa + "'";
                DataTable tb1 = Connect.GetTable(sql1);
                if (tb1.Rows.Count != 0)
                {
                    double t = TinhSoLuong(pIDKho, tb1.Rows[0][0].ToString());
                    if (t != 0)
                    {
                        html += "<td style='border: 1px solid #151010'>";
                        html += t.ToString();
                        html += "</td>";
                    }
                    else
                    {
                        html += "<td style='border: 1px solid #151010'> </td>";
                    }
                }
                else
                {
                    html += "<td style='border: 1px solid #151010'> - </td>";
                }

            }



            html += "</tr>";


        }





        html += @" </table>

";




        //        string sql = "";
        //        sql += @" select ROW_NUMBER() OVER(ORDER BY HangHoa.IDHangHoa asc)AS RowNumber,* from HangHoa where '1'='1' ";

        //        if (IDLoaiHangHoa != "")
        //            sql += " and HangHoa.IDLoaiHangHoa = '" + IDLoaiHangHoa + "'";



        //        DataTable table = Connect.GetTable(sql);

        //        string html = @" <table class='table table-bordered table-striped'>
        //                  <tr>                                                             
        //                        <th class='th'  style='text-align: center;'>
        //                            Tên hàng hóa
        //                        </th>
        // <th class='th'  style='text-align: center;'>
        //                           Size
        //                        </th>
        // <th class='th'  style='text-align: center;'>
        //                            Màu 
        //                        </th>
        //                        <th class='th'  style='text-align: center;'>
        //                            Số lượng
        //                        </th>         
        //                    </tr>";
        //        // double SoTienPhaiThu = 0;
        //        for (int i = 0; i < table.Rows.Count; i++)
        //        {
        //            html += "       <tr >";
        //            html += "       <td>" + StaticData.getField("LoaiHangHoa", "TenLoaiHangHoa", "IDLoaiHangHoa", StaticData.getField("HangHoa", "IDLoaiHangHoa", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString().Trim())) + "-" + StaticData.getField("LoaiHangHoa", "MaLoaiHangHoa", "IDLoaiHangHoa", StaticData.getField("HangHoa", "IDLoaiHangHoa", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString().Trim())) + "</td>";
        //            html += "       <td>" + StaticData.getField("Size", "TenSize", "IDSize", StaticData.getField("HangHoa", "IDSize", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString().Trim())) + "</td>";
        //            html += "       <td>" + StaticData.getField("MauSac", "TenMauSac", "IDMauSac", StaticData.getField("HangHoa", "IDMauSac", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString().Trim())) + "</td>";


        //            if (pIDKho != "")
        //            {
        //                string query = @"select isnull(sum(ChiTietPhieuNhap.SoLuong),0) from PhieuNhap,ChiTietPhieuNhap
        //where PhieuNhap.IDPhieuNhap = ChiTietPhieuNhap.IDPhieuNhap
        //and PhieuNhap.IDKho = " + pIDKho + @" and ChiTietPhieuNhap.IDHangHoa=" + table.Rows[i]["IDHangHoa"].ToString() + @" ";

        //                string query2 = @"select isnull(sum(ChiTietPhieuXuat.SoLuong),0) from PhieuXuat,ChiTietPhieuXuat
        //where PhieuXuat.IDPhieuXuat = ChiTietPhieuXuat.IDPhieuXuat
        //and PhieuXuat.IDKho = " + pIDKho + @" and ChiTietPhieuXuat.IDHangHoa=" + table.Rows[i]["IDHangHoa"].ToString() + @" ";

        //                DataTable SoNhap = Connect.GetTable(query);
        //                DataTable SoXuat = Connect.GetTable(query2);

        //                double Ton = double.Parse(SoNhap.Rows[0][0].ToString()) - double.Parse(SoXuat.Rows[0][0].ToString());
        //                if (Ton == 0)
        //                    html += "<td style='text-align: center;'>0</td>";
        //                else html += "<td style='text-align: center;'>" + Ton.ToString("#,##").Replace(",", ".") + "</td>";
        //            }
        //            else
        //            {
        //                if (MyStaticData.GetSoLuongSanPhamHienTai(table.Rows[i]["IDHangHoa"].ToString()) == 0)
        //                    html += "<td style='text-align: center;'>" + MyStaticData.GetSoLuongSanPhamHienTai(table.Rows[i]["IDHangHoa"].ToString()) + "</td>";
        //                else html += " <td style='text-align: center;'>" + MyStaticData.GetSoLuongSanPhamHienTai(table.Rows[i]["IDHangHoa"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";
        //            }

        //            //html += "       <td style='text-align: center;'>" + Ton.ToString("#,##").Replace(",", ".") + "</td>";


        //            html += "     </tr>";

        //        }

        //        html += "     </table>";






        Response.Write(html);

    }



    private double TinhSoLuong(string pIDKho, string idHangHoa)
    {
        double kq = 0;
        if (pIDKho != "")
        {
            string query = @"select isnull(sum(ChiTietPhieuNhap.SoLuong),0) from PhieuNhap,ChiTietPhieuNhap
where PhieuNhap.IDPhieuNhap = ChiTietPhieuNhap.IDPhieuNhap
and PhieuNhap.IDKho = " + pIDKho + @" and ChiTietPhieuNhap.IDHangHoa=" + idHangHoa + @" ";

            string query2 = @"select isnull(sum(ChiTietPhieuXuat.SoLuong),0) from PhieuXuat,ChiTietPhieuXuat
where PhieuXuat.IDPhieuXuat = ChiTietPhieuXuat.IDPhieuXuat
and PhieuXuat.IDKho = " + pIDKho + @" and ChiTietPhieuXuat.IDHangHoa=" + idHangHoa + @" ";

            DataTable SoNhap = Connect.GetTable(query);
            DataTable SoXuat = Connect.GetTable(query2);

            double Ton = double.Parse(SoNhap.Rows[0][0].ToString()) - double.Parse(SoXuat.Rows[0][0].ToString());
            if (Ton == 0)
                kq = 0;
            else
                kq = Ton;
        }
        else
        {
            if (MyStaticData.GetSoLuongSanPhamHienTai(idHangHoa) == 0)
                kq = 0;

            kq = MyStaticData.GetSoLuongSanPhamHienTai(idHangHoa);
        }

        return kq;


    }




    private void LoadChiTietLoiNhuan()
    {
        string IDLoaiHangHoa = StaticData.ValidParameter(Request.QueryString["IDLoaiHangHoa"].Trim());
        string GiaThoi = StaticData.getField("LoaiHangHoa", "Gia", "IDLoaiHangHoa", IDLoaiHangHoa);

        string TuNgay = StaticData.ValidParameter(Request.QueryString["TuNgay"].Trim());
        string DenNgay = StaticData.ValidParameter(Request.QueryString["DenNgay"].Trim());

        string sql = "";

        sql += @" select *  from ChiTietPhieuXuat where '1'='1'
        

            AND IDHangHoa IN ( SELECT IDHangHoa FROM HangHoa WHERE IDLoaiHangHoa = '" + IDLoaiHangHoa + "' ) ";

        if (TuNgay != "")
            sql += " and ChiTietPhieuXuat.IDPhieuXuat in (select PhieuXuat.IDPhieuXuat from PhieuXuat where '1'='1' and PhieuXuat.MaPhieuXuat not like '%XB%'  and PhieuXuat.NgayXuat >= '" + StaticData.ConvertDDMMtoMMDD(TuNgay) + "' ) ";
        if (DenNgay != "")
            sql += " and ChiTietPhieuXuat.IDPhieuXuat in (select PhieuXuat.IDPhieuXuat from PhieuXuat where '1'='1' and PhieuXuat.MaPhieuXuat not like '%XB%'  and PhieuXuat.NgayXuat <= '" + StaticData.ConvertDDMMtoMMDD(DenNgay) + "' ) ";

        DataTable table = Connect.GetTable(sql);
        string html = @" <table class='table table-bordered table-striped'>
                    <tr>
                        
                        <th class='th'>
                        Hàng hóa
                        </th>
                        <th class='th'>
                         Size
                        </th>
                        <th class='th'>
                         Màu
                        </th>
                         <th class='th'>
                        Số lượng
                        </th>
                        <th class='th'>
                        Giá nhập
                        </th>
                        
                          <th class='th'>
                        Giá bán
                        </th>
                         <th class='th'>
                       Lợi nhuận
                        </th>
                    </tr>";
        // double SoTienPhaiThu = 0;
        for (int i = 0; i < table.Rows.Count; i++)
        {
            html += "       <tr>";
            //html += "       <td>" + (((Page - 1) * PageSize) + i + 1).ToString() + "</td>";


            html += "       <td>" + StaticData.getField("LoaiHangHoa", "TenLoaiHangHoa", "IDLoaiHangHoa", StaticData.getField("HangHoa", "IDLoaiHangHoa", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString())) + "-" + StaticData.getField("LoaiHangHoa", "MaLoaiHangHoa", "IDLoaiHangHoa", StaticData.getField("HangHoa", "IDLoaiHangHoa", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString())) + "</td>";
            html += "       <td>" + StaticData.getField("Size", "TenSize", "IDSize", StaticData.getField("HangHoa", "IDSize", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString())) + "</td>";
            html += "       <td>" + StaticData.getField("MauSac", "TenMauSac", "IDMauSac", StaticData.getField("HangHoa", "IDMauSac", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString())) + "</td>";

            if (table.Rows[i]["SoLuong"].ToString() == "0") html += "<td>0</td>";
            else html += "<td>" + double.Parse(table.Rows[i]["SoLuong"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";


            string sqlquery = @"select ChiTietPhieuNhap.DonGiaNhap from  ChiTietPhieuNhap where IDHangHoa = " + table.Rows[i]["IDHangHoa"].ToString() + " ";

            //if (TuNgay != "")
            //    sqlquery += " and ChiTietPhieuNhap.IDPhieuNhap in (select PhieuNhap.IDPhieuNhap from PhieuNhap where '1'='1'  and PhieuNhap.NgayNhap >= '" + StaticData.ConvertDDMMtoMMDD(TuNgay) + "' ) ";
            //if (DenNgay != "")
            //    sqlquery += " and ChiTietPhieuNhap.IDPhieuNhap in (select PhieuNhap.IDPhieuNhap from PhieuNhap where '1'='1'  and PhieuNhap.NgayNhap <= '" + StaticData.ConvertDDMMtoMMDD(DenNgay) + "' ) ";

            sqlquery += " order by IDChiTietPhieuNhap desc ";
            DataTable LayGiaNhapGanNhat = Connect.GetTable(sqlquery);



            string GiaGoc = "0";
            if (LayGiaNhapGanNhat.Rows.Count > 0)
                GiaGoc = LayGiaNhapGanNhat.Rows[0][0].ToString();
            //string GiaGoc = LayGiaNhapGanNhat.Rows[0][0].ToString();

            if (GiaGoc == "0") html += "<td>0</td>";
            else html += "       <td>" + double.Parse(GiaGoc).ToString("#,##").Replace(",", ".") + "</td>";



            if (table.Rows[i]["DonGiaXuat"].ToString() == "0") html += "<td>" + @"<a target='_blank' href='../QuanLyXuatHang/DanhMucXuatHangSua.aspx?IDPhieuXuat=" + table.Rows[i]["IDPhieuXuat"].ToString() + @"'>0</a></td>";
            else html += "       <td>" + @"<a target='_blank' href='../QuanLyXuatHang/DanhMucXuatHangSua.aspx?IDPhieuXuat=" + table.Rows[i]["IDPhieuXuat"].ToString() + @"'>" + double.Parse(table.Rows[i]["DonGiaXuat"].ToString()).ToString("#,##").Replace(",", ".") + "</a></td>";

            if (GiaGoc == "0" || table.Rows[i]["DonGiaXuat"].ToString() == "0")
            {
                html += "<td>0</td>";
            }

            else
            {
                double LoiNhuan = (double.Parse(table.Rows[i]["DonGiaXuat"].ToString()) - double.Parse(GiaGoc)) * double.Parse(table.Rows[i]["SoLuong"].ToString());

                if (LoiNhuan == 0) html += "<td>0</td>";
                else
                    html += "       <td>" + LoiNhuan.ToString("#,##").Replace(",", ".") + "</td>";
                //

            }
            html += "</tr>";
        }
        html += "   <tr>";
        html += "  </table>";
        Response.Write(html);
    }



    private void CongLai()
    {
        string IDKhachHang = StaticData.ValidParameter(Request.QueryString["IDKhachHang"].Trim());
        string IDPhieuXuat = StaticData.ValidParameter(Request.QueryString["IDPhieuXuat"].Trim());
        double ConLai = MyStaticData.GetNoKhachHangNgoaiTruPhieuXuat(IDKhachHang, IDPhieuXuat) - MyStaticData.GetSoTienDaTraCuaKhachHang(IDKhachHang);


        string sql = "";

        sql += "  select isnull(sum(DonGiaXuat*SoLuong),0) as 'Tong' from ChiTietPhieuXuat where ChiTietPhieuXuat.IDPhieuXuat = " + IDPhieuXuat + " ";
        DataTable table = Connect.GetTable(sql);
        double tong = double.Parse(table.Rows[0]["Tong"].ToString()) + ConLai;


        if (tong == 0)
        {
            Response.Write("0");
        }
        else
        {
            Response.Write(tong.ToString("#,##").Replace(",", "."));

        }
    }
    private void TongTienKhachNo()
    {
        string IDKhachHang = StaticData.ValidParameter(Request.QueryString["IDKhachHang"].Trim());
        string IDPhieuXuat = StaticData.ValidParameter(Request.QueryString["IDPhieuXuat"].Trim());
        double ConLai = MyStaticData.GetNoKhachHangNgoaiTruPhieuXuat(IDKhachHang, IDPhieuXuat) - MyStaticData.GetSoTienDaTraCuaKhachHang(IDKhachHang);
        if (ConLai == 0)
        {
            Response.Write("0");
        }
        else
        {
            Response.Write(ConLai.ToString("#,##").Replace(",", "."));

        }
    }

    private void TongTienDonHang()
    {
        string IDPhieuXuat = StaticData.ValidParameter(Request.QueryString["IDPhieuXuat"].Trim());
        string sql = "";

        sql += "  select isnull(sum(DonGiaXuat*SoLuong),0) as 'Tong' from ChiTietPhieuXuat where ChiTietPhieuXuat.IDPhieuXuat = " + IDPhieuXuat + " ";
        DataTable table = Connect.GetTable(sql);
        if (double.Parse(table.Rows[0]["Tong"].ToString()) == 0)
            Response.Write("0");
        Response.Write(double.Parse(table.Rows[0]["Tong"].ToString()).ToString("#,##").Replace(",", "."));
    }

    private void LoadLenGiaTheoKhachThoi()
    {
        string IDKhachHang = StaticData.ValidParameter(Request.QueryString["IDKhachHang"].Trim());
        string IDHangHoa = StaticData.ValidParameter(Request.QueryString["IDHangHoa"].Trim());

        DataTable Gia = Connect.GetTable("SELECT [Gia] FROM [ChiTietGiaTheoKhach] where IDHangHoa = " + IDHangHoa + " and IDKhachHang=" + IDKhachHang + "");

        if (Gia.Rows.Count > 0)
        {
            if (double.Parse(Gia.Rows[0]["Gia"].ToString()) == 0) Response.Write("0");
            else
                Response.Write(double.Parse(Gia.Rows[0]["Gia"].ToString()).ToString("#,##").Replace(",", "."));
        }
        else
        {
            Response.Write("0");
        }
    }
    private void InPhieuTongHopXuatHang()
    {
        string IDPhieuXuat = StaticData.ValidParameter(Request.QueryString["IDPhieuXuat"].Trim());
        string idKhachHang = StaticData.getField("PhieuXuat", "IDKhachHang", "IDPhieuXuat", IDPhieuXuat);
        string TongTienKhachNo = StaticData.ValidParameter(Request.QueryString["TongTienKhachNo"].Trim());
        string checkTienTT = StaticData.ValidParameter(Request.QueryString["checkTienTT"].Trim());
        string TienDonHang = StaticData.ValidParameter(Request.QueryString["TienDonHang"].Trim());

        string TongTienPhaiTra = StaticData.ValidParameter(Request.QueryString["TongTienPhaiTra"].Trim());

        double TongTienKhachNoSo = 0;
        if (TongTienKhachNo.Trim() != "")
        {
            TongTienKhachNoSo = double.Parse(TongTienKhachNo.Replace(",", "").Replace(".", ""));
        }


        string TienThanhToan = StaticData.ValidParameter(Request.QueryString["TienThanhToan"].Trim());

        string IdKho = StaticData.ValidParameter(Request.QueryString["IdKho"].Trim());


        double TienThanhToanSo = 0;
        if (TienThanhToan != "")
        {
            TienThanhToanSo = double.Parse(TienThanhToan.Replace(",", "").Replace(".", ""));
        }

        string sql = "update PhieuXuat set TienThanhToan=" + TienThanhToanSo.ToString() + ",IDKho= " + IdKho + " where IDPhieuXuat = " + IDPhieuXuat + "";

        bool kq = Connect.Exec(sql);



        BarcodeSymbology s = BarcodeSymbology.Code39C;
        BarcodeDraw drawObject = BarcodeDrawFactory.GetSymbology(s);
        var metrics = drawObject.GetDefaultMetrics(60);
        metrics.Scale = 2;
        var barcodeImage = drawObject.Draw(StaticData.getField("PhieuXuat", "MaPhieuXuat", "IDPhieuXuat", IDPhieuXuat), metrics);

        string barCode = "";

        using (MemoryStream ms = new MemoryStream())
        {
            barcodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] imageBytes = ms.ToArray();

            barCode = Convert.ToBase64String(imageBytes);
        }
        string html = @"
<table style='width:100%;'>
<tr>
<td>

<b>HỆ THỐNG DOLOTGIASI.VN</b><br />
0909 437 977 - 0932 070 729

</td>
<td style='text-align:center;'>
<h3>HÓA ĐƠN BÁN HÀNG</h3>
</td>
</tr>
</table>
<hr />

";

        DataTable table = Connect.GetTable("select * from PhieuXuat where IDPhieuXuat=" + IDPhieuXuat + "");

        string MaPhieuNhap = "-";
        try
        {
            MaPhieuNhap = table.Rows[0]["MaPhieuXuat"].ToString().Substring(table.Rows[0]["MaPhieuXuat"].ToString().Length - 4, 4);
        }
        catch
        {
            MaPhieuNhap = "-";
        }

        html += @"

<table style='width:100%;'>
<tr>
<td style='text-align:left;'><b>Tên khách hàng :</b> " + StaticData.getField("KhachHang", "TenKhachHang", "IDKhachHang", table.Rows[0]["IDKhachHang"].ToString()) + " - " + MaPhieuNhap + @"</td>
<td style='text-align:left;'>&nbsp;</td>

</tr>
<tr>
<td>&nbsp;";
        // if (table.Rows[0]["TienThanhToan"].ToString().Trim() == "0")
        //html += @"<b>Tiền thanh toán :</b> 0";
        //  else
        //     html += "<b>Tiền khách thanh toán :</b> " + double.Parse(table.Rows[0]["TienThanhToan"].ToString()).ToString("#,##").Replace(",", ".") + @"";
        html += @"</td>
<td><b>Ghi chú :</b> " + table.Rows[0]["GhiChu"].ToString().Replace("\n", "<br />") + @"</td>

</tr>

</tr>
<tr>
<td>";
        if (DateTime.Parse(table.Rows[0]["NgayXuat"].ToString()).ToString("dd/MM/yyyy") == "")
            html += @"<b>Ngày :</b> - ";
        else
            html += "<b>Ngày:</b> " + DateTime.Parse(table.Rows[0]["NgayXuat"].ToString()).ToString("dd/MM/yyyy") + @"";
        html += @"</td>
<td>&nbsp;</td>

</tr>

<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>

</tr>
</table>
<div style='text-align:center;'>";

        html += @"<br /><center><table border='1' cellspacing='0' style='width:100%;' ><tr>
             <th class='th'>&nbsp;</th>
             <th class='th'>Hàng hóa</th>
            <th class='th'>ĐVT</th>
             <th class='th'>SL</th>
            <th class='th'>ĐG</th>
            <th class='th'>TT</th>
          </tr>";
        double Tong = 0;
        double sl = 0;

        string query = @"select tb2.IDLoaiHangHoa,tb2.SoLuong,tb2.DonGia,tb2.ThanhTien
from 
(select HangHoa.IDLoaiHangHoa, isnull(sum(ChiTietPhieuXuat.SoLuong),0) as 'SoLuong' , isnull(AVG(ChiTietPhieuXuat.DonGiaXuat),0) as 'DonGia',  isnull(sum(ChiTietPhieuXuat.SoLuong),0) *  isnull(AVG(ChiTietPhieuXuat.DonGiaXuat),0) AS 'ThanhTien' 
from ChiTietPhieuXuat,HangHoa 
where ChiTietPhieuXuat.IDHangHoa=HangHoa.IDHangHoa and IDPhieuXuat=" + IDPhieuXuat + @"
 group by HangHoa.IDLoaiHangHoa) as tb2
 
 ,
( 
select ROW_NUMBER() OVER(ORDER BY ChiTietPhieuXuat.IDChiTietPhieuXuat asc)AS RowNumber,HangHoa.IDLoaiHangHoa from ChiTietPhieuXuat,PhieuXuat,HangHoa 
 where ChiTietPhieuXuat.IDPhieuXuat=PhieuXuat.IDPhieuXuat and ChiTietPhieuXuat.IDHangHoa=HangHoa.IDHangHoa
 and PhieuXuat.IDPhieuXuat = " + IDPhieuXuat + @" 
 ) as tb3
 where tb2.IDLoaiHangHoa = tb3.IDLoaiHangHoa order by tb3.RowNumber";
        DataTable dtTable = Connect.GetTable(query);

        DataTable bang = Connect.GetTable("select HangHoa.IDLoaiHangHoa, isnull(sum(ChiTietPhieuXuat.SoLuong),0) as 'SoLuong' , isnull(AVG(ChiTietPhieuXuat.DonGiaXuat),0) as 'DonGia',  isnull(sum(ChiTietPhieuXuat.SoLuong),0) *  isnull(AVG(ChiTietPhieuXuat.DonGiaXuat),0) AS 'ThanhTien' from ChiTietPhieuXuat,HangHoa where ChiTietPhieuXuat.IDHangHoa=HangHoa.IDHangHoa and IDPhieuXuat=" + IDPhieuXuat + " group by HangHoa.IDLoaiHangHoa");
        bang = MyStaticData.RemoveDuplicateRows(dtTable, "IDLoaiHangHoa");
        for (int i = 0; i < bang.Rows.Count; i++)
        {
            html += "<tr>";
            html += "<td>" + (i + 1).ToString() + "</td>";
            //  html += "<td>" + StaticData.getField("LoaiHangHoa", "MaLoaiHangHoa", "IDLoaiHangHoa", bang.Rows[i]["IDLoaiHangHoa"].ToString()) + "</td>";
            html += "<td>" + StaticData.getField("LoaiHangHoa", "MaLoaiHangHoa", "IDLoaiHangHoa", bang.Rows[i]["IDLoaiHangHoa"].ToString()) + " - " + StaticData.getField("LoaiHangHoa", "TenLoaiHangHoa", "IDLoaiHangHoa", bang.Rows[i]["IDLoaiHangHoa"].ToString()) + "</td>";

            html += "<td>" + StaticData.getField("DonViTinh", "TenDonViTinh", "idDonViTinh", StaticData.getField("LoaiHangHoa", "IDDonViTinh", "IDLoaiHangHoa", bang.Rows[i]["IDLoaiHangHoa"].ToString())) + "</td>";

            if (bang.Rows[i]["SoLuong"].ToString().Trim() == "0")
                html += "<td style='text-align:center;'>" + bang.Rows[i]["SoLuong"].ToString() + "</td>";
            else html += "<td style='text-align:center;'>" + double.Parse(bang.Rows[i]["SoLuong"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";
            sl += double.Parse(bang.Rows[i]["SoLuong"].ToString());
            if (bang.Rows[i]["DonGia"].ToString().Trim() == "0")
                html += "<td style='text-align:right;'>" + bang.Rows[i]["DonGia"].ToString() + "</td>";
            else html += "<td style='text-align:right;'>" + double.Parse(bang.Rows[i]["DonGia"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";

            if (bang.Rows[i]["ThanhTien"].ToString().Trim() == "0")
                html += "<td style='text-align:right;'>" + bang.Rows[i]["ThanhTien"].ToString() + "</td>";
            else html += "<td style='text-align:right;'>" + double.Parse(bang.Rows[i]["ThanhTien"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";

            double thanhTien = double.Parse(bang.Rows[i]["ThanhTien"].ToString());

            Tong += thanhTien;
            html += "</tr>";
        }

        double TongThanhToan = Tong + TongTienKhachNoSo;

        html += "<tr >";
        html += "<td colspan='3' style='text-align:right;'>&nbsp;</td>";
        html += "<td style='text-align:center;' >" + sl.ToString("#,##").Replace(",", ".") + "</td>";
        html += "<td colspan='2' style='text-align:right;'>&nbsp;</td>";
        html += "</tr>";
        html += "<tr >";
        // html += "<td colspan='6' style='text-align:left;'><b>Bằng chữ:</b> " + StaticData.ConvertDecimalToString(decimal.Parse(Tong.ToString())) + "</td>";
        if (checkTienTT.Trim().ToUpper() == "TRUE")
        {
            TienThanhToan = MyStaticData.TongTienDonHang(IDPhieuXuat).ToString();
        }
        else
        {
            TienThanhToan = "0";
        }
        html += "</tr>";
        html += @"</table> 


    

<table style='width:100%'> 
  <tr>
    <td style='width:40%; text-align:center'>

    Ngày ... tháng ... năm 20.... </br>
    <b> Người lập phiếu </b> </br>
    <i> (Ký và ghi rõ họ tên) </i>

</td>
    <td>
<table style='width:100%;' border=1>

  <tr >
    <td><b>Tổng thành tiền: </b> </td>
    <td style='text-align: right'>" + /*TienDonHang*/MyStaticData.TongTienDonHang(IDPhieuXuat).ToString("#,##").Replace(",", ".") + @"</td>
  </tr>
  <tr>
    <td> <b>Nợ cũ:</b> </td>
    <td style='text-align: right'> " + /*string.Format("{0:N0}", TongTienKhachNoSo).Replace(",", ".")*/MyStaticData.TongTienKhachNo(IDPhieuXuat, idKhachHang).ToString("#,##").Replace(",", ".") + @"</td>
  </tr>
  <tr>
    <td> <b> Tổng tiền phải trả: </b> </td>
   <td style='text-align: right'>" + /*string.Format("{0:N0}", TongTienPhaiTra).Replace(",", ".")*/(MyStaticData.TongTienDonHang(IDPhieuXuat) + MyStaticData.TongTienKhachNo(IDPhieuXuat, idKhachHang)).ToString("#,##").Replace(",", ".") + @"</td>
  </tr>


 <tr>
    <td> <b> Tiền khách thanh toán: </b> </td>
   <td style='text-align: right'>" + double.Parse(TienThanhToan).ToString("#,##").Replace(",", ".") + @"</td>
  </tr>


</table>



</td>
  </tr> 
</table>



        </center> ";


        html += @"</div>";
        //        html += @"</div>
        //        <br /> 
        //
        //        - NH Đông Á: Võ Thị Thu Nga - STK: 0101303801 - (CN quận 5) <br />
        //        - NH Vietcombank:  Võ Thị Thu Nga - STK:007 1000 762 264 - CN Tp. HCM <br />
        //        - NH Agribank: Võ Quang Vinh - STK: 1600 205 26 32 81 - CN Sài Gòn <br />
        //        - NH ACB: Võ Quang Vinh - STK: 182 768 219 -  CN. Lê Quang Định, Q.BT 
        //        
        //        
        //        ";

        Response.Write(html);
    }





    private void InPhieuTongHopNhapHang()
    {
        string IDPhieuNhap = StaticData.ValidParameter(Request.QueryString["IDPhieuNhap"].Trim());


        string TienThanhToan = StaticData.ValidParameter(Request.QueryString["TienThanhToan"].Trim());

        string IdKho = StaticData.ValidParameter(Request.QueryString["IdKho"].Trim());


        double TienThanhToanSo = 0;
        if (TienThanhToan != "")
        {
            TienThanhToanSo = double.Parse(TienThanhToan.Replace(",", "").Replace(".", ""));
        }

        string sql = "update PhieuNhap set TienDaThanhToan=" + TienThanhToanSo.ToString() + ",IDKho= " + IdKho + " where IDPhieuNhap = " + IDPhieuNhap + "";

        bool kq = Connect.Exec(sql);



        BarcodeSymbology s = BarcodeSymbology.Code39C;
        BarcodeDraw drawObject = BarcodeDrawFactory.GetSymbology(s);
        var metrics = drawObject.GetDefaultMetrics(60);
        metrics.Scale = 2;
        var barcodeImage = drawObject.Draw(StaticData.getField("PhieuNhap", "MaPhieuNhap", "IDPhieuNhap", IDPhieuNhap), metrics);

        string barCode = "";

        using (MemoryStream ms = new MemoryStream())
        {
            barcodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] imageBytes = ms.ToArray();

            barCode = Convert.ToBase64String(imageBytes);
        }
        string html = @"
<table style='width:100%;'>
<tr>
<td>

<b>HỆ THỐNG DOLOTGIASI.VN</b><br />
HotLine : 0909 437 977 - 0932 070 729

</td>
<td style='text-align:center;'>
<h2>HÓA ĐƠN NHẬP HÀNG</h2>
</td>
</tr>
</table>
<hr />

";

        DataTable table = Connect.GetTable("select * from PhieuNhap where IDPhieuNhap=" + IDPhieuNhap + "");

        html += @"

<table style='width:100%;'>
<tr>
<td style='text-align:left;'><b>Nhà cung cấp :</b> " + StaticData.getField("NhaCungCap", "TenNhaCungCap", "IDNhaCungCap", table.Rows[0]["IDNhaCungCap"].ToString()) + @"</td>
<td style='text-align:left;'><b>Xuất từ kho :</b> " + StaticData.getField("Kho", "TenKho", "IDKho", table.Rows[0]["IDKho"].ToString()) + @"</td>

</tr>
<tr>
<td>";
        if (table.Rows[0]["TienDaThanhToan"].ToString().Trim() == "0")
            html += @"<b>Tiền đã thanh toán :</b> 0";
        else
            html += "<b>Tiền đã thanh toán :</b> " + double.Parse(table.Rows[0]["TienDaThanhToan"].ToString()).ToString("#,##").Replace(",", ".") + @"";
        html += @"</td>
<td><b>Ghi chú :</b> " + table.Rows[0]["GhiChu"].ToString().Replace("\n", "<br />") + @"</td>

</tr>

</tr>
<tr>
<td>";
        if (DateTime.Parse(table.Rows[0]["NgayNhap"].ToString()).ToString("dd/MM/yyyy") == "")
            html += @"<b>Ngày :</b> - ";
        else
            html += "<b>Ngày:</b> " + DateTime.Parse(table.Rows[0]["NgayNhap"].ToString()).ToString("dd/MM/yyyy") + @"";
        html += @"</td>
<td><b>Diển giải :</b> </td>

</tr>

<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>

</tr>
</table>
<div style='text-align:center;'>";

        html += @"<br /><center><table border='1' cellspacing='0' style='width:100%;' ><tr>
             <th class='th'> STT</th>
             <th class='th'>Hàng hóa </th>
            <th class='th'>ĐV Tính </th>
             <th class='th'> SL </th>
            <th class='th'> Đơn giá </th>
            <th class='th'> Thành tiền </th>
          </tr>";
        double Tong = 0;
        string query = @"select tb2.IDLoaiHangHoa,tb2.SoLuong,tb2.DonGia,tb2.ThanhTien
from 
(select HangHoa.IDLoaiHangHoa, isnull(sum(ChiTietPhieuNhap.SoLuong),0) as 'SoLuong' , isnull(AVG(ChiTietPhieuNhap.DonGiaNhap),0) as 'DonGia',  isnull(sum(ChiTietPhieuNhap.SoLuong),0) *  isnull(AVG(ChiTietPhieuNhap.DonGiaNhap),0) AS 'ThanhTien' 
from ChiTietPhieuNhap,HangHoa 
where ChiTietPhieuNhap.IDHangHoa=HangHoa.IDHangHoa and IDPhieuNhap=" + IDPhieuNhap + @"
 group by HangHoa.IDLoaiHangHoa) as tb2
 
 ,
( 
select ROW_NUMBER() OVER(ORDER BY ChiTietPhieuNhap.IDChiTietPhieuNhap asc)AS RowNumber,HangHoa.IDLoaiHangHoa from ChiTietPhieuNhap,PhieuNhap,HangHoa 
 where ChiTietPhieuNhap.IDPhieuNhap=PhieuNhap.IDPhieuNhap and ChiTietPhieuNhap.IDHangHoa=HangHoa.IDHangHoa
 and PhieuNhap.IDPhieuNhap = " + IDPhieuNhap + @" 
 ) as tb3
 where tb2.IDLoaiHangHoa = tb3.IDLoaiHangHoa order by tb3.RowNumber";
        DataTable dbTable = Connect.GetTable(query);
        DataTable bang = Connect.GetTable("select HangHoa.IDLoaiHangHoa, isnull(sum(ChiTietPhieuNhap.SoLuong),0) as 'SoLuong' , isnull(AVG(ChiTietPhieuNhap.DonGiaNhap),0) as 'DonGia',  isnull(sum(ChiTietPhieuNhap.SoLuong),0) *  isnull(AVG(ChiTietPhieuNhap.DonGiaNhap),0) AS 'ThanhTien' from ChiTietPhieuNhap,HangHoa where ChiTietPhieuNhap.IDHangHoa=HangHoa.IDHangHoa and IDPhieuNhap=" + IDPhieuNhap + " group by HangHoa.IDLoaiHangHoa");
        bang = MyStaticData.RemoveDuplicateRows(dbTable, "IDLoaiHangHoa");
        for (int i = 0; i < bang.Rows.Count; i++)
        {
            html += "<tr>";
            html += "<td>" + (i + 1).ToString() + "</td>";
            //  html += "<td>" + StaticData.getField("LoaiHangHoa", "MaLoaiHangHoa", "IDLoaiHangHoa", bang.Rows[i]["IDLoaiHangHoa"].ToString()) + "</td>";
            html += "<td>" + StaticData.getField("LoaiHangHoa", "TenLoaiHangHoa", "IDLoaiHangHoa", bang.Rows[i]["IDLoaiHangHoa"].ToString()) + " - " + StaticData.getField("LoaiHangHoa", "MaLoaiHangHoa", "IDLoaiHangHoa", bang.Rows[i]["IDLoaiHangHoa"].ToString()) + "</td>";

            html += "<td>" + StaticData.getField("DonViTinh", "TenDonViTinh", "idDonViTinh", StaticData.getField("LoaiHangHoa", "IDDonViTinh", "IDLoaiHangHoa", bang.Rows[i]["IDLoaiHangHoa"].ToString())) + "</td>";

            if (bang.Rows[i]["SoLuong"].ToString().Trim() == "0")
                html += "<td style='text-align:center;'>" + bang.Rows[i]["SoLuong"].ToString() + "</td>";
            else html += "<td style='text-align:center;'>" + double.Parse(bang.Rows[i]["SoLuong"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";

            if (bang.Rows[i]["DonGia"].ToString().Trim() == "0")
                html += "<td style='text-align:right;'>" + bang.Rows[i]["DonGia"].ToString() + "</td>";
            else html += "<td style='text-align:right;'>" + double.Parse(bang.Rows[i]["DonGia"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";

            if (bang.Rows[i]["ThanhTien"].ToString().Trim() == "0")
                html += "<td style='text-align:right;'>" + bang.Rows[i]["ThanhTien"].ToString() + "</td>";
            else html += "<td style='text-align:right;'>" + double.Parse(bang.Rows[i]["ThanhTien"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";

            double thanhTien = double.Parse(bang.Rows[i]["ThanhTien"].ToString());

            Tong += thanhTien;
            html += "</tr>";
        }

        // double TongThanhToan = Tong + TongTienKhachNoSo;

        html += "<tr >";
        html += "<td colspan='5' style='text-align:right;'><b>Tổng cộng</b></td>";
        html += "<td ><b>" + Tong.ToString("#,##").Replace(",", ".") + "</b></td>";
        html += "</tr>";
        html += "<tr >";
        html += "<td colspan='6' style='text-align:left;'><b>Bằng chữ:</b> " + StaticData.ConvertDecimalToString(decimal.Parse(Tong.ToString())) + "</td>";

        html += "</tr>";
        html += @"</table> 


    

<table style='width:100%'> 
  <tr>
    <td style='width:50%; text-align:center'>

    Ngày ... tháng ... năm 20.... </br>
    <b> Người lập phiếu </b> </br>
    <i> (Ký và ghi rõ họ tên) </i>

</td>
    <td>
<table style='width:100%;' border=1>

  <tr >
    <td><b>Tổng thành tiền: </b> </td>
    <td style='text-align: right'>" + string.Format("{0:N0}", Tong).Replace(",", ".") + @"</td>
  </tr>
 <tr>
    <td> <b> Tiền khách thanh toán: </b> </td>
   <td style='text-align: right'>" + string.Format("{0:N0}", TienThanhToan).Replace(",", ".") + @"</td>
  </tr>


</table>



</td>
  </tr> 
</table>



        </center> ";

        Response.Write(html);
    }






    private void XemChiTietMauSize()
    {
        string IDLoaiHangHoa = StaticData.ValidParameter(Request.QueryString["IDLoaiHangHoa"].Trim());
        DataTable table = Connect.GetTable("select * from HangHoa where IDLoaiHangHoa=" + IDLoaiHangHoa + "");

        string html = @"";

        html += @"<center><b>CHI TIẾT HÀNG HÓA " + StaticData.getField("LoaiHangHoa", "TenLoaiHangHoa", "IDLoaiHangHoa", IDLoaiHangHoa) + @"</b> </center><table class='table table-bordered table-striped'><tr>
             <th class='th'> STT</th>
             <th class='th'>Màu</th>
             <th class='th'>Size</th>
           </tr>";

        for (int i = 0; i < table.Rows.Count; i++)
        {
            html += "<tr style='text-align:left;'>";
            html += "<td>" + (i + 1).ToString() + "</td>";
            html += "<td>" + StaticData.getField("MauSac", "TenMauSac", "IDMauSac", StaticData.getField("HangHoa", "IDMauSac", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString())) + "</td>";
            html += "<td>" + StaticData.getField("Size", "TenSize", "IDSize", StaticData.getField("HangHoa", "IDSize", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString())) + "</td>";


            html += "</tr>";
        }

        html += "</table> ";


        Response.Write(html);
    }
    private void ThemTheoLoaiHangCapCaoPhieuXuat()
    {

        string SoLuong = StaticData.ValidParameter(Request.QueryString["SoLuong"].Trim());
        string IDLoaiHangCapCao = StaticData.ValidParameter(Request.QueryString["IDLoaiHangCapCao"].Trim());
        string IDPhieuXuat = StaticData.ValidParameter(Request.QueryString["IDPhieuXuat"].Trim());
        string IDKhachHang = StaticData.ValidParameter(Request.QueryString["IDKhachHang"].Trim());
        string GiaBan = StaticData.ValidParameter(Request.QueryString["GiaBan"].Trim());
        string MauSac = StaticData.ValidParameter(Request.QueryString["MauSac"].Trim());

        DataTable LayGiaKhach = Connect.GetTable("select * from ChiTietGiaTheoKhach where IDKhachHang=" + IDKhachHang + " and IDHangHoa=" + IDLoaiHangCapCao + "");
        if (LayGiaKhach.Rows.Count <= 0)
        {
            string sql2 = "insert into ChiTietGiaTheoKhach values(" + IDKhachHang + "," + IDLoaiHangCapCao + "," + GiaBan + ",N'')";
            bool rs2 = Connect.Exec(sql2);
        }
        else
        {
            string sql2 = "update ChiTietGiaTheoKhach set Gia=" + GiaBan + " where IDKhachHang=" + IDKhachHang + " and IDHangHoa=" + IDLoaiHangCapCao + " ";
            bool rs2 = Connect.Exec(sql2);
        }


        DataTable tableHangHoa = Connect.GetTable("select * from HangHoa where IDLoaiHangHoa = " + IDLoaiHangCapCao + " ");
        int check = 0;
        string dm = "";
        for (int i = 0; i < tableHangHoa.Rows.Count; i++)
        {
            DataTable LayGiaTheoKhach = Connect.GetTable("select * from ChiTietGiaTheoKhach where IDKhachHang=" + IDKhachHang + " and IDHangHoa=" + tableHangHoa.Rows[i]["IDLoaiHangHoa"].ToString() + "");
            if (LayGiaTheoKhach.Rows.Count <= 0)
            {
                check = check + 1;
            }


        }

        if (check > 0)
        {
            Response.Write("False");
        }
        else
        {
            int catchloi = 0;
            for (int i = 0; i < tableHangHoa.Rows.Count; i++)
            {
                if (MyStaticData.KiemTraSoLuong(tableHangHoa.Rows[i]["IDHangHoa"].ToString(), double.Parse(SoLuong)))
                {

                }
                else
                {
                    catchloi += 1;
                }
            }
            if (catchloi > 0)
            {
                Response.Write("False");
            }
            else
            {
                string[] arrMauSac = MauSac.Split(',');

                for (int i = 0; i < tableHangHoa.Rows.Count; i++)
                {
                    DataTable LayGiaTheoKhach = Connect.GetTable("select * from ChiTietGiaTheoKhach where IDKhachHang=" + IDKhachHang + " and IDHangHoa=" + tableHangHoa.Rows[i]["IDLoaiHangHoa"].ToString() + "");

                    string DonGiaTheoKhach = LayGiaTheoKhach.Rows[0]["Gia"].ToString();
                    //DataTable tbHangHoa = Connect.GetTable("select * from HangHoa where IDLoaiHangHoa = " + tableHangHoa.Rows[i]["IDLoaiHangHoa"].ToString() + "");
                    //for (int j = 0; j < tbHangHoa.Rows.Count; j++)
                    //{

                    string sql = "insert into ChiTietPhieuXuat values(" + IDPhieuXuat + "," + tableHangHoa.Rows[i]["IDHangHoa"].ToString() + "," + arrMauSac[i] + "," + DonGiaTheoKhach + "," + MyStaticData.GetGiaVon(tableHangHoa.Rows[i]["IDHangHoa"].ToString()) + ",N'')";
                    bool rs = Connect.Exec(sql);
                    //}
                }
                Response.Write("True");
            }
        }

    }
    private void ThemTheoLoaiHangCapCao()
    {
        try
        {
            string GiaNhap = StaticData.ValidParameter(Request.QueryString["GiaNhap"].Trim());

            string IDLoaiHangCapCao = StaticData.ValidParameter(Request.QueryString["IDLoaiHangCapCao"].Trim());
            string IDPhieuNhap = StaticData.ValidParameter(Request.QueryString["IDPhieuNhap"].Trim());
            string SoLuong = StaticData.ValidParameter(Request.QueryString["SoLuong"].Trim());
            DataTable tableHangHoa = Connect.GetTable("select * from HangHoa where IDLoaiHangHoa = " + IDLoaiHangCapCao + " ");
            for (int i = 0; i < tableHangHoa.Rows.Count; i++)
            {
                string query = "update LoaiHangHoa set Gia=" + GiaNhap + " where IDLoaiHangHoa=" + tableHangHoa.Rows[i]["IDLoaiHangHoa"].ToString() + "";
                bool rs1 = Connect.Exec(query);

                string DonGiaNhap = StaticData.getField("LoaiHangHoa", "Gia", "IDLoaiHangHoa", tableHangHoa.Rows[i]["IDLoaiHangHoa"].ToString());
                //DataTable tbHangHoa = Connect.GetTable("select * from HangHoa where IDLoaiHangHoa = " + tableHangHoa.Rows[i]["IDLoaiHangHoa"].ToString() + "");
                //for (int j = 0; j < tbHangHoa.Rows.Count; j++)
                //{
                string sql = "insert into ChiTietPhieuNhap values(" + tableHangHoa.Rows[i]["IDHangHoa"].ToString() + "," + IDPhieuNhap + "," + SoLuong + "," + DonGiaNhap + ",N'',null)";
                bool rs = Connect.Exec(sql);
                //}
            }
            Response.Write("True");
        }
        catch
        {
            Response.Write("False");
        }
    }
    private void DeleteLoaiHangCapCao()
    {
        string IDHangHoa = StaticData.ValidParameter(Request.QueryString["IDHangHoa"].Trim());

        string sql = "delete from LoaiHangCapCao where IDLoaiHangCapCao=" + IDHangHoa;
        bool ktDelete = Connect.Exec(sql);

        if (ktDelete)
            Response.Write("True");
        else
            Response.Write("False");
    }
    private void LoadPrintDonHang()
    {
        //        string idHD = StaticData.ValidParameter(Request.QueryString["idHD"].Trim());
        //        string sqlOrderById = @"SELECT * FROM [tb_DonHang] dh, tb_KhachHang kh WHERE dh.idKhachHang = kh.idKhachHang and idDonHang = " + idHD + "";
        //        DataTable tb = Connect.GetTable(sqlOrderById);
        //        if (tb.Rows.Count > 0)
        //        {
        //            string sqlSP = @"select * from tb_CTDonHang ct, tb_HangHoa hh, tb_CTHangHoa cthh, tb_Mau m, tb_Size s 
        //where hh.idHangHoa = cthh.idHangHoa and cthh.idMau = m.idMau and cthh.idSize = s.idSize and ct.idCTHangHoa = cthh.idCTHangHoa and cthh.idHangHoa = cthh.idHangHoa and idDonHang = '" + idHD + "'";
        //            DataTable data = Connect.GetTable(sqlSP);
        //            if (data.Rows.Count > 0)
        //            {
        //                BarcodeSymbology s = BarcodeSymbology.Code39C;
        //                BarcodeDraw drawObject = BarcodeDrawFactory.GetSymbology(s);
        //                var metrics = drawObject.GetDefaultMetrics(60);
        //                metrics.Scale = 2;
        //                var barcodeImage = drawObject.Draw(tb.Rows[0]["MaDonHang"].ToString(), metrics);

        //                string barCode = "";

        //                using (MemoryStream ms = new MemoryStream())
        //                {
        //                    barcodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        //                    byte[] imageBytes = ms.ToArray();

        //                    barCode = Convert.ToBase64String(imageBytes);
        //                }


        //                string html = @"
        // <div style='width:100%'>
        // <div style='font-family: 'Times New Roman', Times, serif; font-size: 15px; text-align: left; width: 800px; margin-top: -10px; margin-left: -20px;'>
        //            <div style='margin-top: 0; margin-left: 20px'>";
        //                html += MyStaticData.GetTieuDeIn(barCode, tb.Rows[0]["MaDonHang"].ToString(), midCuaHang);
        //                html += @"
        //                <p style='font-size: 20px; text-align: center; font-weight: bold; margin: 0; padding: 10px 0 5px 0;'>
        //                    HÓA ĐƠN BÁN HÀNG
        //                </p>
        //                <p style='text-align: center; font-style: italic; margin: 0; padding: 0 0 10px 0;'> ";

        //                html += "     Ngày " + DateTime.Now.ToString("dd") + " Tháng " + DateTime.Now.ToString("MM") + " Năm " + DateTime.Now.ToString("yyyy");
        //                html += @" </p>
        //                <div style='position: absolute; left: 80%; top: 130px;'>
        //                    Nợ: ...................
        //                    <br />
        //                    Có: ...................
        //                    <br />
        //                    Loại tiền: VNĐ
        //                </div>
        //                <table width='100%' border='0' cellpadding='1'>
        //                    <!--=======================THÔNG TIN NGƯỜI NHẬN HÀNG===============================--> 
        //                
        //                    <tr>
        //                        <td width='20%' align='left'>- Tên khách hàng :</td>
        //                        <td width='30%' align='left'> ";
        //                html += tb.Rows[0]["TenKhachHang"].ToString();
        //                html += "<td width='15%' align='left'> Điện  thoại:</td>";
        //                html += "<td width='30%' align='left'> " + tb.Rows[0]["SoDienThoai"].ToString() + "</td>";
        //                html += @"</td>
        //                    </tr>
        //                    <tr>
        //                        <td width='20%' align='left'>- Địa chỉ :</td>
        //                        <td colspan='3' align='left'> ";
        //                html += tb.Rows[0]["DiaChi"].ToString() + " - " + StaticData.getField("tb_QuanHuyen", "Ten", "id", tb.Rows[0]["idQuanHuyen"].ToString()) + " - " + StaticData.getField("tb_TinhTP", "Ten", "id", tb.Rows[0]["idTinh"].ToString());
        //                html += @"</td>
        //                    </tr>
        //                    <tr>
        //                        <td width='20%' align='left'>- Ghi chú :
        //                        </td>
        //                        <td>
        //                          
        //                        </td>
        //                    </tr>
        //                </table>
        //                <!--=======================DANH SÁCH SẢN PHẨM===============================-->
        //                <table width='100%' border='1' cellpadding='3' cellspacing='0' style='margin-top: 10px; font-size: 14px'>
        //                    <tr>
        //                        <td style='font-size: 12px; background: #ccc; text-align: center; font-weight: bold; width: 40px;'>STT
        //                        </td>
        //                        <td style='font-size: 12px; background: #ccc; text-align: center; font-weight: bold; width: 60px;'>Mã sản phẩm
        //                        </td>
        //                        <td style='font-size: 12px; background: #ccc; text-align: center; font-weight: bold;'>Tên sản phẩm/dịch vụ
        //                        </td>
        //                        <td style='font-size: 12px; background: #ccc; text-align: center; font-weight: bold; width: 90px;'>Đơn giá
        //                        </td>
        //                        <td style='font-size: 12px; background: #ccc; text-align: center; font-weight: bold; width: 60px;'>Số lượng
        //                        </td>
        //                        <td style='font-size: 12px; background: #ccc; text-align: center; font-weight: bold; width: 140px;'>Thành tiền
        //                        </td>
        //                    </tr> ";
        //                decimal TongTien = 0;
        //                for (int i = 0; i < data.Rows.Count; i++)
        //                {
        //                    html += "<tr>";
        //                    html += "<td style='text-align: center;'>" + (i + 1).ToString() + " </td> ";
        //                    html += "<td style='text-align: center;'>" + data.Rows[i]["MaCTHangHoa"].ToString() + " </td> ";
        //                    html += "<td style='text-align: left;'>" + data.Rows[i]["TenHangHoa"].ToString() + " - " + data.Rows[i]["TenMau"] + " - " + data.Rows[i]["Size"] + " </td> ";
        //                    decimal DonGia = (data.Rows[i]["DonGia"] == "" ? 0 : decimal.Parse(data.Rows[i]["DonGia"].ToString()));
        //                    decimal SoLuong = (data.Rows[i]["SoLuong"] == "" ? 0 : decimal.Parse(data.Rows[i]["SoLuong"].ToString()));
        //                    html += "<td style='text-align: center;'>" + DonGia.ToString("N0") + " </td> ";
        //                    html += "<td style='text-align: center;'>" + SoLuong.ToString("N0") + " </td> ";
        //                    html += "<td style='text-align: right;'>" + (DonGia * SoLuong).ToString("N0") + " </td> ";
        //                    html += "</tr>";
        //                    TongTien += (DonGia * SoLuong);
        //                }

        //                html += @"  <tr>
        //                        <td colspan='5' style='text-align: right; height: 25px;'>
        //                            <b>Giảm giá : </b>
        //                        </td>
        //                        <td style='text-align: right;'>
        //
        //                            <b> ";
        //                decimal GiamGia = (tb.Rows[0]["GiamGia"] == "" ? 0 : decimal.Parse(tb.Rows[0]["GiamGia"].ToString()));
        //                html += GiamGia.ToString("N0");
        //                html += @" </b>
        //                        </td>
        //                    </tr>
        //                    <tr>
        //                        <td colspan='5' style='text-align: right; height: 25px;'>
        //                            <b>Phí vận chuyển : </b>
        //                        </td>
        //                        <td style='text-align: right;'>
        //
        //                            <b> ";
        //                decimal PhiVanChuyen = (tb.Rows[0]["PhiVanChuyen"] == "" ? 0 : decimal.Parse(tb.Rows[0]["PhiVanChuyen"].ToString()));
        //                html += PhiVanChuyen.ToString("N0");
        //                html += @" </b>
        //                        </td>
        //                    </tr>
        //                    <tr>
        //                        <td colspan='5' style='text-align: right; height: 25px;'>
        //                            <b>Thu khác : </b>
        //                        </td>
        //                        <td style='text-align: right;'>
        //
        //                            <b>";
        //                decimal ThuKhac = (tb.Rows[0]["ThuKhac"].ToString() == "" ? 0 : decimal.Parse(tb.Rows[0]["ThuKhac"].ToString()));
        //                html += ThuKhac.ToString("N0");
        //                html += @"</b>";
        //            }
        //        }
    }
    private void InPhieuXuatHang()
    {
        string IDPhieuXuat = StaticData.ValidParameter(Request.QueryString["IDPhieuXuat"].Trim());
        string checkTienTT = StaticData.ValidParameter(Request.QueryString["checkTienTT"].Trim()).ToUpper();
        string TienThanhToan = StaticData.ValidParameter(Request.QueryString["TienThanhToan"].Trim());

        string IdKho = StaticData.ValidParameter(Request.QueryString["IdKho"].Trim());
        string idKhachHang = StaticData.getField("PhieuXuat", "IDKhachHang", "IDPhieuXuat", IDPhieuXuat);

        double TienThanhToanSo = 0;
        if (TienThanhToan != "")
        {
            TienThanhToanSo = double.Parse(TienThanhToan.Replace(",", "").Replace(".", ""));
        }

        string sql = "update PhieuXuat set TienThanhToan=" + TienThanhToanSo.ToString() + ",IDKho= " + IdKho + " where IDPhieuXuat = " + IDPhieuXuat + "";

        bool kq = Connect.Exec(sql);


        string TongTienKhachNo = StaticData.ValidParameter(Request.QueryString["TongTienKhachNo"].Trim());

        double TongTienKhachNoSo = 0;
        if (TongTienKhachNo.Trim() != "")
        {
            TongTienKhachNoSo = double.Parse(TongTienKhachNo.Replace(",", "").Replace(".", ""));
        }

        BarcodeSymbology s = BarcodeSymbology.Code39C;
        BarcodeDraw drawObject = BarcodeDrawFactory.GetSymbology(s);
        var metrics = drawObject.GetDefaultMetrics(60);
        metrics.Scale = 2;
        var barcodeImage = drawObject.Draw(StaticData.getField("PhieuXuat", "MaPhieuXuat", "IDPhieuXuat", IDPhieuXuat), metrics);

        string barCode = "";

        using (MemoryStream ms = new MemoryStream())
        {
            barcodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            byte[] imageBytes = ms.ToArray();

            barCode = Convert.ToBase64String(imageBytes);
        }
        string html = @"
<table style='width:100%;'>
<tr>
<td>

<b>HỆ THỐNG DOLOTGIASI.VN</b><br />
HotLine : 0909 437 977 - 0932 070 729

</td>
<td style='text-align:center;'>
<h2>HÓA ĐƠN BÁN HÀNG</h2>
</td>
</tr>
</table>
<hr />

";

        DataTable table = Connect.GetTable("select * from PhieuXuat where IDPhieuXuat=" + IDPhieuXuat + "");

        string MaPhieuNhap = "-";
        try
        {
            MaPhieuNhap = table.Rows[0]["MaPhieuXuat"].ToString().Substring(table.Rows[0]["MaPhieuXuat"].ToString().Length - 4, 4);
        }
        catch
        {
            MaPhieuNhap = "-";
        }

        html += @"
<table style='width:100%;'>
<tr>
<td style='text-align:left;'><b>Tên khách hàng :</b> " + StaticData.getField("KhachHang", "TenKhachHang", "IDKhachHang", table.Rows[0]["IDKhachHang"].ToString()) + " - " + MaPhieuNhap + @"</td>
<td style='text-align:left;'><b>Xuất từ kho :</b> " + StaticData.getField("Kho", "TenKho", "IDKho", table.Rows[0]["IDKho"].ToString()) + @"</td>

</tr>
<tr>
<td>";
        if (table.Rows[0]["TienThanhToan"].ToString().Trim() == "0")
            html += @"<b>Tiền thanh toán :</b> 0";
        else
            html += "<b>Tiền khách thanh toán :</b> " + double.Parse(table.Rows[0]["TienThanhToan"].ToString()).ToString("#,##").Replace(",", ".") + @"";
        html += @"</td>
<td><b>Ghi chú :</b> " + table.Rows[0]["GhiChu"].ToString().Replace("\n", "<br />") + @"</td>

</tr>


<tr>
<td>";
        if (DateTime.Parse(table.Rows[0]["NgayXuat"].ToString()).ToString("dd/MM/yyyy") == "")
            html += @"<b>Ngày :</b> - ";
        else
            html += "<b>Ngày:</b> " + DateTime.Parse(table.Rows[0]["NgayXuat"].ToString()).ToString("dd/MM/yyyy") + @"";
        html += @"</td>
<td><b>Diển giải :</b> </td>

</tr>

<tr>
<td>&nbsp;</td>
<td>&nbsp;</td>

</tr>
</table>
<div style='text-align:center;'>";

        html += @"<br /><center><table border='1' cellspacing='0' style='width:100%;' ><tr>
             <th class='th'> STT</th>
             
             <th class='th'>Hàng hóa</th><th class='th'>Size</th><th class='th'>Màu</th>

                <th class='th'> ĐV Tính </th>
             <th class='th'> SL </th>
            <th class='th'> Đơn giá bán</th>
<th class='th'> Thành tiền</th></tr>";
        double Tong = 0;
        DataTable bang = Connect.GetTable("select * from ChiTietPhieuXuat where IDPhieuXuat=" + IDPhieuXuat + " order by IDChiTietPhieuXuat asc");
        for (int i = 0; i < bang.Rows.Count; i++)
        {
            html += "<tr>";
            html += "<td>" + (i + 1).ToString() + "</td>";
            html += "       <td>" + StaticData.getField("LoaiHangHoa", "TenLoaiHangHoa", "IDLoaiHangHoa", StaticData.getField("HangHoa", "IDLoaiHangHoa", "IDHangHoa", bang.Rows[i]["IDHangHoa"].ToString().Trim())) + "-" + StaticData.getField("LoaiHangHoa", "MaLoaiHangHoa", "IDLoaiHangHoa", StaticData.getField("HangHoa", "IDLoaiHangHoa", "IDHangHoa", bang.Rows[i]["IDHangHoa"].ToString().Trim())) + "</td>";
            html += "<td>" + StaticData.getField("Size", "TenSize", "IDSize", StaticData.getField("HangHoa", "IDSize", "IDHangHoa", bang.Rows[i]["IDHangHoa"].ToString())) + "</td>";
            html += "<td>" + StaticData.getField("MauSac", "TenMauSac", "IDMauSac", StaticData.getField("HangHoa", "IDMauSac", "IDHangHoa", bang.Rows[i]["IDHangHoa"].ToString())) + "</td>";


            html += "<td>" + StaticData.getField("DonViTinh", "TenDonViTinh", "idDonViTinh", StaticData.getField("LoaiHangHoa", "IDDonViTinh", "IDLoaiHangHoa", StaticData.getField("HangHoa", "IDLoaiHangHoa", "IDHangHoa", bang.Rows[i]["IDHangHoa"].ToString()))) + "</td>";


            if (bang.Rows[i]["SoLuong"].ToString().Trim() == "0")
                html += "<td style='text-align:center;'>" + bang.Rows[i]["SoLuong"].ToString() + "</td>";
            else html += "<td style='text-align:center;'>" + double.Parse(bang.Rows[i]["SoLuong"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";

            if (bang.Rows[i]["DonGiaXuat"].ToString().Trim() == "0")
                html += "<td style='text-align:right;'>" + bang.Rows[i]["DonGiaXuat"].ToString() + "</td>";
            else html += "<td style='text-align:right;'>" + double.Parse(bang.Rows[i]["DonGiaXuat"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";

            double thanhTien = double.Parse(bang.Rows[i]["SoLuong"].ToString()) * double.Parse(bang.Rows[i]["DonGiaXuat"].ToString());
            if (thanhTien == 0)
                html += "<td style='text-align:right;'>" + thanhTien.ToString() + "</td>";
            else html += "<td style='text-align:right;'>" + thanhTien.ToString("#,##").Replace(",", ".") + "</td>";

            Tong += thanhTien;
            html += "</tr>";
        }


        double TongThanhToan = Tong + TongTienKhachNoSo;
        html += "<tr >";
        html += "<td colspan='7' style='text-align:right;'><b>Tổng cộng</b></td>";
        html += "<td ><b>" + Tong.ToString("#,##").Replace(",", ".") + "</b></td>";
        html += "</tr>";
        html += "<tr >";
        html += "<td colspan='8' style='text-align:left;'><b>Bằng chữ:</b> " + StaticData.ConvertDecimalToString(decimal.Parse(Tong.ToString())) + "</td>";

        html += "</tr>";

        if (checkTienTT == "TRUE")
        {
            TienThanhToan = MyStaticData.TongTienDonHang(IDPhieuXuat).ToString();
        }
        else
        {
            TienThanhToan = "0";
        }
        // double tienphai Trace = (MyStaticData.TongTienDonHang(IDPhieuXuat) + MyStaticData.TongTienKhachNo(IDPhieuXuat, idKhachHang))
        html += @"</table>




<table style='width:100%'> 
  <tr>
    <td style='width:50%; text-align:center'>

    Ngày ... tháng ... năm 20.... </br>
    <b> Người lập phiếu </b> </br>
    <i> (Ký và ghi rõ họ tên) </i>

</td>
    <td>
<table style='width:100%;' border=1>

  <tr >
    <td><b>Tổng thành tiền: </b> </td>
    <td style='text-align: right'>" + /*string.Format("{0:N0}", Tong).Replace(",", ".")*/MyStaticData.TongTienDonHang(IDPhieuXuat).ToString("#,##").Replace(",", ".") + @"</td>
  </tr>
  <tr>
    <td> <b>Nợ cũ:</b> </td>
    <td style='text-align: right'> " + /*string.Format("{0:N0}", TongTienKhachNoSo).Replace(",", ".")*/MyStaticData.TongTienKhachNo(IDPhieuXuat, idKhachHang).ToString("#,##").Replace(",", ".") + @"</td>
  </tr>
  <tr>
    <td> <b> Tổng tiền phải trả: </b> </td>
   <td style='text-align: right'>" + /*string.Format("{0:N0}", TongThanhToan).Replace(",", ".")*/ (MyStaticData.TongTienDonHang(IDPhieuXuat) + MyStaticData.TongTienKhachNo(IDPhieuXuat, idKhachHang)).ToString("#,##").Replace(",", ".") + @"</td>
  </tr>

<tr>
    <td> <b> Tiền khách thanh toán: </b> </td>
   <td style='text-align: right'>" + double.Parse(TienThanhToan).ToString("#,##").Replace(",", ".") + @"</td>
  </tr>


</table>



</td>
  </tr> 
</table>


</center><br />";

        html += @"</div>";


        //        html += @"</div>
        //        <br /> 
        //
        //        - NH Đông Á: Võ Thị Thu Nga - STK: 0101303801 - (CN quận 5) <br />
        //        - NH Vietcombank:  Võ Thị Thu Nga - STK:007 1000 762 264 - CN Tp. HCM <br />
        //        - NH Agribank: Võ Quang Vinh - STK: 1600 205 26 32 81 - CN Sài Gòn <br />
        //        - NH ACB: Võ Quang Vinh - STK: 182 768 219 -  CN. Lê Quang Định, Q.BT 
        //        
        //        
        //        ";

        Response.Write(html);
    }
    private void XemTonGiuaCacKho()
    {
        string IDHangHoa = StaticData.ValidParameter(Request.QueryString["IDHangHoa"].Trim());
        DataTable tableKho = Connect.GetTable("select * from Kho");
        string html = "";
        for (int i = 0; i < tableKho.Rows.Count; i++)
        {
            html += "Hàng hóa : " + StaticData.getField("HangHoa", "TenHangHoa", "IDHangHoa", IDHangHoa) + " trong " + tableKho.Rows[i]["TenKho"].ToString() + " còn ";
            string sqlLayPhieuNhapTuKho = "select * from PhieuNhap where IDKho=" + tableKho.Rows[i]["IDKho"].ToString() + "";
            DataTable tablePhieuNhap = Connect.GetTable(sqlLayPhieuNhapTuKho);
            double TongNhap = 0;
            for (int j = 0; j < tablePhieuNhap.Rows.Count; j++)
            {
                string sqlSoSPNhapKho = "select isnull(sum(SoLuong),0) from ChiTietPhieuNhap where IDHangHoa='" + IDHangHoa + "' and IDPhieuNhap=" + tablePhieuNhap.Rows[j]["IDPhieuNhap"].ToString() + " ";
                DataTable tbSoSPNhapKho = Connect.GetTable(sqlSoSPNhapKho);
                TongNhap += double.Parse(tbSoSPNhapKho.Rows[0][0].ToString());
            }

            string sqlLayPhieuXuatTuKho = "select * from PhieuXuat where IDKho=" + tableKho.Rows[i]["IDKho"].ToString() + "";
            DataTable tablePhieuXuat = Connect.GetTable(sqlLayPhieuXuatTuKho);
            double TongXuat = 0;
            for (int j = 0; j < tablePhieuXuat.Rows.Count; j++)
            {
                string sqlSoSPXuatKho = "select isnull(sum(SoLuong),0) from ChiTietPhieuXuat where IDHangHoa='" + IDHangHoa + "' and IDPhieuXuat=" + tablePhieuXuat.Rows[j]["IDPhieuXuat"].ToString() + " ";
                DataTable tbSoSPXuatKho = Connect.GetTable(sqlSoSPXuatKho);
                TongXuat += double.Parse(tbSoSPXuatKho.Rows[0][0].ToString());
            }
            html += (TongNhap - TongXuat).ToString() + "<br />";

        }
        Response.Write(html);
    }
    private void showChiTietLoiNhuan()
    {
        string pTuNgayBan = StaticData.ValidParameter(Request.QueryString["TuNgay"].Trim());
        string pDenNgayBan = StaticData.ValidParameter(Request.QueryString["DenNgay"].Trim());

        if (pTuNgayBan.Trim().Length <= 0 || pDenNgayBan.Trim().Length <= 0)
        {
            Response.Write("False");
        }
        else
        {
            string sql = "select * from PhieuXuat where '1'='1'  ";
            if (pTuNgayBan != "")
                sql += " and PhieuXuat.NgayXuat >='" + StaticData.ConvertDDMMtoMMDD(pTuNgayBan) + " 00:00:00'";
            if (pDenNgayBan != "")
                sql += " and PhieuXuat.NgayXuat <='" + StaticData.ConvertDDMMtoMMDD(pDenNgayBan) + " 00:00:00'";
            DataTable TienPhieuXuat = Connect.GetTable(sql);
            string html = @"<center><h2>CHI TIẾT PHIẾU CÁC XUẤT HÀNG</h2></center> <table class='table table-bordered table-striped'><tr>
             <th class='th'> STT</th>
             <th class='th'>Mã phiếu xuất</th>
             <th class='th'> Ngày lập   </th>
             <th class='th'>Tổng tiền đơn hàng</th></tr>";
            double TongTienPhieuXuat = 0;
            for (int i = 0; i < TienPhieuXuat.Rows.Count; i++)
            {
                html += "<tr>";
                html += "<td>" + (i + 1).ToString() + "</td>";
                html += "<td>" + TienPhieuXuat.Rows[i]["MaPhieuXuat"].ToString() + "</td>";
                html += "<td>" + DateTime.Parse(TienPhieuXuat.Rows[i]["NgayXuat"].ToString()).ToString("dd/MM/yyyy") + "</td>";
                if (MyStaticData.TongTienPhieuXuat(TienPhieuXuat.Rows[i]["IDPhieuXuat"].ToString()) == 0)
                    html += "<td>0</td>";
                else
                    html += "<td>" + MyStaticData.TongTienPhieuXuat(TienPhieuXuat.Rows[i]["IDPhieuXuat"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";



                html += "</tr>";

                TongTienPhieuXuat += MyStaticData.TongTienPhieuXuat(TienPhieuXuat.Rows[i]["IDPhieuXuat"].ToString());
            }
            html += "<tr style='background-color:lightgreen;'>";
            html += "<td colspan='3' style='text-align:right;'><b>Tổng cộng</b></td>";
            html += "<td ><b>" + TongTienPhieuXuat.ToString("#,##").Replace(",", ".") + "</b></td>";
            html += "</tr>";
            html += "</table>";
            string query = "select * from PhieuNhap where PhieuNhap.MaPhieuNhap not like '%-XB' ";
            if (pTuNgayBan != "")
                query += " and PhieuNhap.NgayNhap >='" + StaticData.ConvertDDMMtoMMDD(pTuNgayBan) + " 00:00:00'";
            if (pDenNgayBan != "")
                query += " and PhieuNhap.NgayNhap <='" + StaticData.ConvertDDMMtoMMDD(pDenNgayBan) + " 00:00:00'";
            DataTable TienThanhToanPhieuNhap = Connect.GetTable(query);
            double TongTienThanhToanPhieuNhap = 0;
            html += @"<br /><center><h2>CHI TIẾT CÁC PHIẾU NHẬP</h2></center><table class='table table-bordered table-striped'>
                  <tr>
                        <th class='th'>
                          STT
                        </th>
                        <th class='th'>
                         Mã phiếu nhập
                        </th>
                        <th class='th'>
                          Ngày
                        </th>
                         
                       <th class='th'>
                         Tổng tiền đơn hàng
                        </th>
      
                    </tr>";
            for (int i = 0; i < TienThanhToanPhieuNhap.Rows.Count; i++)
            {
                html += "<tr>";
                html += "<td>" + (i + 1).ToString() + "</td>";
                html += "<td>" + TienThanhToanPhieuNhap.Rows[i]["MaPhieuNhap"].ToString() + "</td>";
                html += "<td>" + DateTime.Parse(TienThanhToanPhieuNhap.Rows[i]["NgayNhap"].ToString()).ToString("dd/MM/yyyy") + "</td>";

                if (MyStaticData.TongTienPhieuNhap(TienThanhToanPhieuNhap.Rows[i]["IDPhieuNhap"].ToString()) == 0)
                    html += "<td>0</td>";
                else
                    html += "<td>" + MyStaticData.TongTienPhieuNhap(TienThanhToanPhieuNhap.Rows[i]["IDPhieuNhap"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";
                html += "</tr>";

                TongTienThanhToanPhieuNhap += MyStaticData.TongTienPhieuNhap(TienThanhToanPhieuNhap.Rows[i]["IDPhieuNhap"].ToString());
            }
            html += "<tr style='background-color:lightgreen;'>";
            html += "<td colspan='3' style='text-align:right;'><b>Tổng cộng</b></td>";
            html += "<td ><b>" + TongTienThanhToanPhieuNhap.ToString("#,##").Replace(",", ".") + "</b></td>";
            html += "</tr>";
            html += "</table>";
            Response.Write(html);
        }
    }
    private void DeletePhieuTraNoNhaCungCap()
    {
        string IDChiTietGiaTheoKhach = StaticData.ValidParameter(Request.QueryString["IDChiTietGiaTheoKhach"].Trim());

        string sql = "delete from PhieuTraNoNhaCungCap where IDPhieuTraNoNhaCungCap=" + IDChiTietGiaTheoKhach;
        bool ktDelete = Connect.Exec(sql);

        if (ktDelete)
            Response.Write("True");
        else
            Response.Write("False");
    }
    private void ThemTheoLoaiHangHoaPhieuXuat()
    {

        string IDKhachHang = StaticData.ValidParameter(Request.QueryString["IDKhachHang"].Trim());
        string IDLoaiHangHoa = StaticData.ValidParameter(Request.QueryString["IDLoaiHangHoa"].Trim());
        string IDPhieuXuat = StaticData.ValidParameter(Request.QueryString["IDPhieuXuat"].Trim());
        string IDSize = StaticData.ValidParameter(Request.QueryString["IDSize"].Trim());
        string IDMauSac = StaticData.ValidParameter(Request.QueryString["IDMauSac"].Trim());
        string SoLuong = StaticData.ValidParameter(Request.QueryString["SoLuong"].Trim());
        string GiaDeNghi = StaticData.ValidParameter(Request.QueryString["GiaDeNghi"].Trim());
        string MaPhieuXuat = StaticData.getField("PhieuXuat", "MaPhieuXuat", "IDPhieuXuat", IDPhieuXuat);
        DataTable LayHang = Connect.GetTable("select HangHoa.IDHangHoa from HangHoa where IDLoaiHangHoa = " + IDLoaiHangHoa + " and IDSize=" + IDSize + " and IDMauSac=" + IDMauSac + "");

        // Response.Write(MyStaticData.KiemTraSoLuong(LayHang.Rows[0]["IDHangHoa"].ToString(), double.Parse(SoLuong)).ToString());
        if (MyStaticData.KiemTraSoLuong(LayHang.Rows[0]["IDHangHoa"].ToString(), double.Parse(SoLuong)))
        {

            DataTable LayGiaTheoKhach2 = Connect.GetTable("select * from ChiTietGiaTheoKhach where IDKhachHang=" + IDKhachHang + " and IDHangHoa=" + IDLoaiHangHoa + "");
            if (LayGiaTheoKhach2.Rows.Count <= 0)
            {
                string sql = "insert into ChiTietGiaTheoKhach values(" + IDKhachHang + "," + IDLoaiHangHoa + "," + GiaDeNghi + ",N'')";

                bool rs = Connect.Exec(sql);
            }
            else
            {
                string sql = "update ChiTietGiaTheoKhach set Gia=" + GiaDeNghi + " where IDKhachHang=" + IDKhachHang + " and IDHangHoa=" + IDLoaiHangHoa + " ";

                bool rs = Connect.Exec(sql);
            }


            DataTable LayGiaTheoKhach = Connect.GetTable("select * from ChiTietGiaTheoKhach where IDKhachHang=" + IDKhachHang + " and IDHangHoa=" + IDLoaiHangHoa + "");
            if (LayGiaTheoKhach.Rows.Count > 0)
            {
                string DonGiaTheoKhach = LayGiaTheoKhach.Rows[0]["Gia"].ToString();
                //tableHangHoa.Rows.Count
                DataTable tableHangHoa = Connect.GetTable("select * from HangHoa where IDLoaiHangHoa = " + IDLoaiHangHoa + " and IDSize=" + IDSize + " and IDMauSac=" + IDMauSac + "");
                //for (int i = 0; i < tableHangHoa.Rows.Count; i++)
                //{

                DataTable kiemtra = Connect.GetTable("select * from ChiTietPhieuXuat where IDHangHoa = " + tableHangHoa.Rows[0]["IDHangHoa"].ToString() + " and IDPhieuXuat=" + IDPhieuXuat + "");
                if (kiemtra.Rows.Count > 0)
                {
                    string sql = "update ChiTietPhieuXuat set SoLuong=SoLuong+" + SoLuong + " where IDChiTietPhieuXuat=" + kiemtra.Rows[0]["IDChiTietPhieuXuat"].ToString() + "";
                    bool r = Connect.Exec(sql);
                    if (r)
                    {
                        string sql2 = "insert into BangLog(TaiKhoan,ThaoTac,NgayGio) values (N'" + Request.Cookies["BanSiQuanAo_Login"].Value.Trim() + "',N'Thêm mới hàng phiếu xuất hàng " + MaPhieuXuat + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "')";
                        bool kq2 = Connect.Exec(sql2);
                        Response.Write("True");
                    }
                    else Response.Write("False1");
                }
                else
                {
                    string sql = "insert into ChiTietPhieuXuat values(" + IDPhieuXuat + "," + tableHangHoa.Rows[0]["IDHangHoa"].ToString() + "," + SoLuong + "," + DonGiaTheoKhach + "," + MyStaticData.GetGiaVon(tableHangHoa.Rows[0]["IDHangHoa"].ToString()) + ",N'')";

                    bool rs = Connect.Exec(sql);
                    if (rs)
                    {
                        string sql2 = "insert into BangLog(TaiKhoan,ThaoTac,NgayGio) values (N'" + Request.Cookies["BanSiQuanAo_Login"].Value.Trim() + "',N'Thêm mới hàng phiếu xuất hàng " + MaPhieuXuat + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "')";
                        bool kq2 = Connect.Exec(sql2);
                        Response.Write("True");
                    }
                    else Response.Write("False1");
                }
            }
            else
            {
                Response.Write("False");
            }
        }
        else
        {
            Response.Write("False");
        }


    }
    private void ThemTheoLoaiHangHoa()
    {
        try
        {


            string IDLoaiHangHoa = StaticData.ValidParameter(Request.QueryString["IDLoaiHangHoa"].Trim());
            string IDPhieuNhap = StaticData.ValidParameter(Request.QueryString["IDPhieuNhap"].Trim());
            string DonGiaNhap = StaticData.getField("LoaiHangHoa", "Gia", "IDLoaiHangHoa", IDLoaiHangHoa);
            DataTable tableHangHoa = Connect.GetTable("select * from HangHoa where IDLoaiHangHoa = " + IDLoaiHangHoa + " ");
            for (int i = 0; i < tableHangHoa.Rows.Count; i++)
            {
                string sql = "insert into ChiTietPhieuNhap values(" + tableHangHoa.Rows[i]["IDHangHoa"].ToString() + "," + IDPhieuNhap + ",1," + DonGiaNhap + ",N'',null)";
                bool rs = Connect.Exec(sql);
            }
            Response.Write("True");
        }
        catch
        {
            Response.Write("False");
        }
    }
    private void DeleteLoaiHangHoa()
    {
        string idNguoiDung = StaticData.ValidParameter(Request.QueryString["IDLoaiHangHoa"].Trim());
        string sql2 = "delete from BlackList where IDLoaiHangHoa=" + idNguoiDung;
        bool ktDelete2 = Connect.Exec(sql2);
        string sql = "delete from LoaiHangHoa where IDLoaiHangHoa=" + idNguoiDung;
        bool ktDelete = Connect.Exec(sql);



        if (ktDelete)
            Response.Write("True");
        else
            Response.Write("False");
    }
    private void DeletePhieuTraNo()
    {
        string idNguoiDung = StaticData.ValidParameter(Request.QueryString["IDChiTietGiaTheoKhach"].Trim());

        string sql = "delete from PhieuTraNo where IDPhieuTraNo=" + idNguoiDung;
        bool ktDelete = Connect.Exec(sql);

        if (ktDelete)
            Response.Write("True");
        else
            Response.Write("False");
    }
    private void LoadMauSize()
    {
        string IDHangHoa = StaticData.ValidParameter(Request.QueryString["IDHangHoa"].Trim());

        string IDSize = StaticData.getField("HangHoa", "IDSize", "IDHangHoa", IDHangHoa);
        string TenSize = StaticData.getField("Size", "TenSize", "IDSize", IDSize);

        string IDMauSac = StaticData.getField("HangHoa", "IDMauSac", "IDHangHoa", IDHangHoa);
        string TenMauSac = StaticData.getField("MauSac", "TenMauSac", "IDMauSac", IDMauSac);
        Response.Write(TenSize + "@" + TenMauSac);
    }
    private void LoadKho()
    {

        string sql = "";

        sql += "  select * from Kho";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";

        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";
            listgAutocomplete += "value: '" + table.Rows[i]["TenKho"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["TenKho"].ToString() + "-" + table.Rows[i]["MaKho"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["IDKho"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }
    private void DeleteKho()
    {
        string idNguoiDung = StaticData.ValidParameter(Request.QueryString["IDMauSac"].Trim());

        string sql = "delete from Kho where IDKho=" + idNguoiDung;
        bool ktDelete = Connect.Exec(sql);

        if (ktDelete)
            Response.Write("True");
        else
            Response.Write("False");
    }
    //
    private void LayDGBQGQ()
    {
        string IDHangHoa = StaticData.ValidParameter(Request.QueryString["IDHangHoa"].Trim());

        string sql = "";

        sql += "select isnull(isnull(Sum(SoLuong*DonGiaNHap),0),0)/isnull(isnull(sum(SoLuong),0),0) as 'BQGQ' from ChiTietPhieuNhap  where IDHangHoa =" + IDHangHoa + "";
        DataTable table = Connect.GetTable(sql);
        if (table.Rows.Count > 0)
        {
            string DonGiaNhap = double.Parse(table.Rows[0]["BQGQ"].ToString().Trim()).ToString("#,##").Replace(",", ".");
            // string IDChiTietPhieuNhap = table.Rows[0]["IDChiTietPhieuNhap"].ToString();
            Response.Write(DonGiaNhap);
        }
        else
            Response.Write("False");
    }

    // In phiếu
    private void Inpdf()
    {
        // Response.Write("Đã xuất file pdf ra ");

        string IDPhieuNhap = StaticData.ValidParameter(Request.QueryString["IDPhieuNhap"].Trim());
        string sql = "";
        sql += @"select * from(select ROW_NUMBER() OVER(ORDER BY ChiTietPhieuNhap.NgayNhapChiTiet asc)AS RowNumber,HangHoa.TenHangHoa,HangHoa.IDHangHoa,PhieuNhap.MaPhieuNhap,ChiTietPhieuNhap.SoLuong,ChiTietPhieuNhap.DonGiaNhap,ChiTietPhieuNhap.NgayNhapChiTiet from ChiTietPhieuNhap left join HangHoa on ChiTietPhieuNhap.IDHangHoa = HangHoa.IDHangHoa left join PhieuNhap on ChiTietPhieuNhap.IDPhieuNhap = PhieuNhap.IDPhieuNhap where PhieuNhap.MaPhieuNhap not like '%-XB' ";
        if (IDPhieuNhap.Trim() != "")
            sql += " and PhieuNhap.MaPhieuNhap like N'%" + StaticData.getField("PhieuNhap", "MaPhieuNhap", "IDPhieuNhap", IDPhieuNhap.Trim()) + "%'";
        sql += "  ) as tb1";

        DataTable table = Connect.GetTable(sql);

        string HTMLContent = @"<html><body encoding=" + BaseFont.IDENTITY_H + " style='font-family:Arial;font-size:10px;'>";

        HTMLContent += @"
       <table border='0'>
<tr>
<td style='text-align: right;'><img src='' width='35' height='45' /></td>
<td colspan='5'><br /><b>CÔNG TY CỔ PHẦN VIỄN LIÊN</b><br /><i>Số 32 Đường số 8 nhà ở Khu Z756, Phường 12, Q.10, Tp.Hồ Chí Minh</i></td>
<td style='text-align: center;' colspan='5'><b>CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM</b><br />Độc lập - Tự do - Hạnh phúc</td>
</tr>

</table>
<table border='0'>
<tr>
<td >&nbsp;</td>
<td colspan='5'><b><i><u>Tel</u></i></b> : 028 3620 8997 - <b><i><u>Fax</u></i></b> : 028 3620 8997</td>
<td style='text-align: center;' colspan='5'>**********</td>
</tr>

</table>

<table border='0'>
<tr>
 <td  style='text-align: right;'>Số:</td> 
            <td colspan='5'>" + StaticData.getField("PhieuNhap", "MaPhieuNhap", "IDPhieuNhap", IDPhieuNhap.Trim()) + @"</td>
            <td colspan='5' style='text-align: center;'><i>Tp,HCM Ngày&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tháng&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;năm</i></td>  

</tr>

</table>
<table border='0'>
 <tr>
            <td style='text-align: center;' colspan='7' ><h2><b>BIÊN BẢN NHẬP HÀNG HÓA</b></h2></td> 
        </tr>

</table>
<table>
       
        <tr>
            <td>&nbsp;</td> 
            <td colspan='5' ><h4><b>Bên giao :       CÔNG TY CỔ PHẦN VIỄN LIÊN</b></h4></td>
           <td>&nbsp;</td> 
        </tr>             
          <tr>         <td>&nbsp;</td>     
            <td colspan='5'><i>Cùng tiến hành kiểm tra chất lượng và số lượng của những mặt hàng sau :</i></td>
           <td>&nbsp;</td> 
        </tr>     
             <tr>
            <td style='border-bottom-color:black'>&nbsp;</td> 
            <td style='border-bottom-color:black'>&nbsp;</td>
            <td style='border-bottom-color:black'>&nbsp;</td>
            <td style='border-bottom-color:black'>&nbsp;</td>
            <td style='border-bottom-color:black'>&nbsp;</td>
            <td style='border-bottom-color:black'>&nbsp;</td>
            <td style='border-bottom-color:black'>&nbsp;</td>
        </tr>            
        </table>
            <table border='1'>
                   <tr>
                        <th style='text-align: center;'><b>STT</b></th>
                        <th style='text-align: center;'><b>DANH MỤC HÀNG HÓA</b></th>
                        <th style='text-align: center;'><b>ĐVT</b></th>
                        <th style='text-align: center;'><b>ĐƠN GIÁ</b></th>
                        <th style='text-align: center;'><b>SỐ LƯỢNG</b></th>                       
                        <th style='text-align: center;'><b>THÀNH TIỀN</b></th>
                        <th style='text-align: center;'><b>GHI CHÚ</b></th>
                    </tr> ";
        double TongTien = 0, TongSoLuong = 0;
        for (int i = 0; i < table.Rows.Count; i++)
        {
            HTMLContent += "<tr>";
            HTMLContent += " <td style='text-align: center;border-color: black;'>" + (i + 1).ToString() + "</td>";

            HTMLContent += "<td style='border-color: black'>" + table.Rows[i]["TenHangHoa"].ToString() + "</td>";
            // HTMLContent += "       <td>" + DateTime.Parse(table.Rows[i]["NgayXuatChiTiet"].ToString()).ToString("dd/MM/yyyy") + "</td>";
            // string IDMauSac = StaticData.getField("HangHoa", "IDMauSac", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString());
            // string MauSac = StaticData.getField("MauSac", "TenMauSac", "IDMauSac", IDMauSac);
            // HTMLContent += "       <td>" + MauSac + "</td>";
            string IDDonViTinh = StaticData.getField("HangHoa", "IDDonViTinh", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString());
            string DonViTinh = StaticData.getField("DonViTinh", "TenDonViTinh", "IDDonViTinh", IDDonViTinh);
            HTMLContent += "       <td style='text-align: center;'>" + DonViTinh + "</td>";
            double SoXuat = double.Parse(table.Rows[i]["DonGiaNhap"].ToString());

            HTMLContent += "       <td style='text-align: center;'>" + string.Format("{0:N0}", (SoXuat)).Replace(",", ".")/* SoXuat.ToString("#,##").Replace(",", ".")*/ + "</td>";
            double a = double.Parse(table.Rows[i]["SoLuong"].ToString());

            HTMLContent += "       <td style='text-align: center;'>" + string.Format("{0:N0}", (a)).Replace(",", ".") /*a.ToString("#,##").Replace(",", ".")*/ + "</td>";

            double ThanhTien = SoXuat * a;
            TongTien += ThanhTien; TongSoLuong += a;
            HTMLContent += "<td style='text-align: center;'>" + string.Format("{0:N0}", (ThanhTien)).Replace(",", ".")/*ThanhTien.ToString("#,##").Replace(",", ".")*/ + "</td>";
            //  DataTable gc = Connect.GetTable("select GhiChu from ChiTietPhieuXuat where IDChiTietPhieuXuat=" + table.Rows[i]["IDChiTietPhieuXuat"].ToString() + "");
            HTMLContent += "       <td style='text-align: center;'>&nbsp;</td>";
            HTMLContent += "     </tr>";

        }


        HTMLContent += @"
  <tr >
            <td style='text-align: center;'>&nbsp;</td> 
            <td style='text-align: center;'>TỔNG CỘNG:</td> 
            <td style='text-align: center;'>&nbsp;</td>
            <td style='text-align: center;'>&nbsp;</td>
            <td style='text-align: center;'>" + string.Format("{0:N0}", (TongSoLuong)).Replace(",", ".") + @"</td>
            <td style='text-align: center;'>" + string.Format("{0:N0}", (TongTien)).Replace(",", ".") + @"</td>
            <td style='text-align: center;'>&nbsp;</td>
        </tr>
        

</table></body></html>";
        string FileName = "BBNH";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        Response.AppendHeader("Content-Type", "application/pdf");
        Response.AppendHeader("Content-disposition", "attachment; filename=" + FileName + ".pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        stringWrite.WriteLine(HTMLContent);

        HtmlTextWriter hw = new HtmlTextWriter(stringWrite);
        StringReader sr = new StringReader(stringWrite.ToString());
        Document pdfDoc = new Document(PageSize.A4, 20f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter wi = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();

        //string fontpath = Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + "\\ARIALUNI.TTF";        //  "ARIALUNI.TTF" file copied from fonts folder and placed in the folder
        string fontpath = "http://vienlien.lamphanmem.com/Fonts/ARIALUNI.TTF";        //  "ARIALUNI.TTF" file copied from fonts folder and placed in the folder
        BaseFont bf = BaseFont.CreateFont(fontpath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        FontFactory.RegisterDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), true);
        FontFactory.Register(fontpath, "Arial Unicode MS");

        //string path = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/ArialUni.TFF");
        //iTextSharp.text.Font fnt = new iTextSharp.text.Font();
        //FontFactory.Register(path, "Arial Unicode MS");
        //fnt = FontFactory.GetFont("Arial Unicode MS", BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 10, Font.NORMAL);


        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();





    }
    //
    private void ABCAutocomplete3()
    {

        string sql = "";

        sql += "  select IDHangHoa,MaHangHoa,TenHangHoa from HangHoa";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";
        /*listgAutocomplete += "{";
        listgAutocomplete += "value: 'Chọn',";
        listgAutocomplete += "label: 'Chọn',";
        listgAutocomplete += "id: '0'";
        listgAutocomplete += "},";*/
        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";
            listgAutocomplete += "iid: '" + table.Rows[i]["IDHangHoa"].ToString() + "',";
            listgAutocomplete += "show: '" + table.Rows[i]["MaHangHoa"].ToString() + "',";
            listgAutocomplete += "value: '" + table.Rows[i]["MaHangHoa"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["MaHangHoa"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["TenHangHoa"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }
    private void LayGiaNhapGanNhat2()
    {
        string IDChiTietPhieuXuat = StaticData.ValidParameter(Request.QueryString["IDHangHoa"].Trim());

        string sql = "";

        sql += "select DonGiaNhap,IDChiTietPhieuNhap from ChiTietPhieuNhap where IDChiTietPhieuNhap in (select max(a.IDChiTietPhieuNhap) from ChiTietPhieuNhap a where a.IDHangHoa ='" + IDChiTietPhieuXuat + "')";
        DataTable table = Connect.GetTable(sql);
        if (table.Rows.Count > 0)
        {
            string DonGiaNhap = double.Parse(table.Rows[0]["DonGiaNhap"].ToString().Trim()).ToString("#,##").Replace(",", ".");
            string IDChiTietPhieuNhap = table.Rows[0]["IDChiTietPhieuNhap"].ToString();
            Response.Write(DonGiaNhap + "@" + IDChiTietPhieuNhap);
        }
        else
            Response.Write("False");
    }
    private void LayIDNhapGanNhat2()
    {
        string IDChiTietPhieuXuat = StaticData.ValidParameter(Request.QueryString["IDHangHoa"].Trim());

        string sql = "";

        sql += "select DonGiaNhap,IDChiTietPhieuNhap from ChiTietPhieuNhap where IDPhieuNhap not in (select IDPhieuNhap from PhieuNhap where MaPhieuNhap like '%-XB') IDChiTietPhieuNhap in (select max(a.IDChiTietPhieuNhap) from ChiTietPhieuNhap a where a.IDHangHoa ='" + IDChiTietPhieuXuat + "')";
        DataTable table = Connect.GetTable(sql);
        if (table.Rows.Count > 0)
        {
            //string DonGiaNhap = double.Parse(table.Rows[0]["DonGiaNhap"].ToString().Trim()).ToString("#,##").Replace(",", ".");
            string IDChiTietPhieuNhap = table.Rows[0]["IDChiTietPhieuNhap"].ToString();
            Response.Write(IDChiTietPhieuNhap);
        }
        else
            Response.Write("False");
    }
    private void ExportExcel2()
    {
        string MaPhieuXuat = StaticData.ValidParameter(Request.QueryString["MaPhieuXuat"].Trim());

        string sql = "";
        sql += @"select * from(select ROW_NUMBER() OVER(ORDER BY ChiTietPhieuXuat.NgayXuatChiTiet asc)AS RowNumber,HangHoa.TenHangHoa,HangHoa.IDHangHoa,PhieuXuat.MaPhieuXuat,ChiTietPhieuXuat.SoLuong,ChiTietPhieuXuat.DonGiaXuat,ChiTietPhieuXuat.NgayXuatChiTiet from ChiTietPhieuXuat left join HangHoa on ChiTietPhieuXuat.IDHangHoa = HangHoa.IDHangHoa left join PhieuXuat on ChiTietPhieuXuat.IDPhieuXuat = PhieuXuat.IDPhieuXuat where '1'='1'";
        if (MaPhieuXuat.Trim() != "")
            sql += " and PhieuXuat.MaPhieuXuat like N'%" + MaPhieuXuat.Trim() + "%'";


        // sql += "group by HangHoa.MaHangHoa,HangHoa.TenHangHoa,ChiTietPhieuXuat.NgayXuatChiTiet,ChiTietPhieuNhap.NgayNhapChiTiet,ChiTietPhieuXuat.IDChiTietPhieuXuat,HangHoa.IDHangHoa ";
        sql += "  ) as tb1";


        DataTable table = Connect.GetTable(sql);

        string HTMLContent = "";


        //HTMLContent += "<table border='1'>";
        DataTable NoiToi = Connect.GetTable("select top 1 KhachHang.TenKhachHang,PhongBan.TenPhongBan,CuaHang.TenCuaHang,CuaHang.DiaChi,PhongBan.DiaChiPhongBan,KhachHang.DiaChi as 'DiaChiKH',CuaHang.SoDienThoai,CuaHang.NguoiLienLac from ChiTietPhieuXuat left join KhachHang on ChiTietPhieuXuat.IDKhachHang = KhachHang.IDKhachHang left join PhongBan on ChiTietPhieuXuat.IDPhongBan = PhongBan.IDPhongBan left join CuaHang on ChiTietPhieuXuat.IDCuaHang = CuaHang.IDCuaHang where IDPhieuXuat = '" + StaticData.getField("PhieuXuat", "IDPhieuXuat", "MaPhieuXuat", MaPhieuXuat.Trim()) + "'");
        string NoiGiao = "";
        string DiaChi = "";
        string NoiNhan = "";
        string BenNhan = "";
        if (NoiToi.Rows.Count > 0)
        {

            if (NoiToi.Rows[0]["TenKhachHang"].ToString().Trim() != "")
            {
                if (NoiToi.Rows[0]["TenPhongBan"].ToString().Trim() != "")
                {
                    if (NoiToi.Rows[0]["TenCuaHang"].ToString().Trim() != "")
                    {
                        BenNhan = NoiToi.Rows[0]["TenKhachHang"].ToString().Trim() + "_" + NoiToi.Rows[0]["TenPhongBan"].ToString().Trim();
                        NoiNhan = "Chị/Anh " + NoiToi.Rows[0]["NguoiLienLac"].ToString().Trim() + " + Số điện thoại: " + NoiToi.Rows[0]["SoDienThoai"].ToString().Trim();
                    }
                    else
                    {
                        BenNhan = NoiToi.Rows[0]["TenKhachHang"].ToString().Trim();
                        NoiNhan = NoiToi.Rows[0]["TenPhongBan"].ToString().Trim();
                    }
                }
                else
                {
                    BenNhan = NoiToi.Rows[0]["TenKhachHang"].ToString().Trim();
                }

            }

            DiaChi = NoiToi.Rows[0]["DiaChiKH"].ToString();

        }
        HTMLContent += @"
<html><body encoding=" + BaseFont.IDENTITY_H + " style='font-family:Arial;font-size:10px;'>";
        HTMLContent += @"
 <table border='0'>
<tr>
<td style='text-align: right;'><img src='http://vienlien.lamphanmem.com/images/vienlien.png' width='35' height='45' /></td>
<td colspan='5'><br /><b>CÔNG TY CỔ PHẦN VIỄN LIÊN</b><br /><i>Số 32 Đường số 8 nhà ở Khu Z756, Phường 12, Q.10, Tp.Hồ Chí Minh</i></td>
<td style='text-align: center;' colspan='5'><b>CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM</b><br />Độc lập - Tự do - Hạnh phúc</td>
</tr>

</table>
<table border='0'>
<tr>
<td >&nbsp;</td>
<td colspan='5'><b><i><u>Tel</u></i></b> : 028 3620 8997 - <b><i><u>Fax</u></i></b> : 028 3620 8997</td>
<td style='text-align: center;' colspan='5'>**********</td>
</tr>

</table>

<table border='0'>
<tr>
 <td  style='text-align: right;'>Số:</td> 
            <td colspan='5'>" + MaPhieuXuat + @"</td>
            <td colspan='5' style='text-align: center;'><i>Tp,HCM Ngày&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tháng&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;năm</i></td>  

</tr>

</table><table border='0'>
        <tr>
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td >&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style='text-align: center; padding:15px 0px 15px 0px;' colspan='7' ><h2><b>BIÊN BẢN NGHIỆM THU & BÀN GIAO HÀNG HÓA</b></h2></td> 
        </tr>
        <tr>
            <td>&nbsp;</td> 
            <td colspan='5' ><h4><b>Bên giao :       CÔNG TY CỔ PHẦN VIỄN LIÊN</b></h4></td>
           <td>&nbsp;</td> 
        </tr>
         <tr>
            <td>&nbsp;</td>
      
          <td colspan='5'><h5><b>Bên nhận :" + BenNhan + @"</b></h5></td>
           
        <td>&nbsp;</td> 
        </tr>   
        <tr>
            <td>&nbsp;</td>
  <td colspan='5'>Nơi nhận: " + NoiNhan + @"</td>
         <td>&nbsp;</td> 
        </tr>
        <tr>
            <td>&nbsp;</td> 
            <td colspan='5'>Địa chỉ giao hàng: " + DiaChi + @"</td>
           <td>&nbsp;</td> 
        </tr>
          <tr>          <td>&nbsp;</td>  
            <td colspan='5'><i>Cùng tiến hành kiểm tra chất lượng và số lượng của những mặt hàng sau :</i></td>
           <td>&nbsp;</td> 
        </tr>     
             <tr>
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td >&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr> 
</table><table border='1'>
                   <tr>
                        <th style='text-align: center;'><b>STT</b></th>
                        <th style='text-align: center;'><b>DANH MỤC HÀNG HÓA</b></th>
                      
                       
                        <th style='text-align: center;'><b>ĐVT</b></th>
                         <th style='text-align: center;'><b>SỐ LƯỢNG</b></th>
                      
                        <th style='text-align: center;border-color:black;'><b>GHI CHÚ</b></th>                                         
                    </tr> ";
        for (int i = 0; i < table.Rows.Count; i++)
        {
            HTMLContent += "<tr>";
            HTMLContent += " <td style='text-align: center;'>" + (i + 1).ToString() + "</td>";

            HTMLContent += "       <td style='border-right-color: black'>" + table.Rows[i]["TenHangHoa"].ToString() + "</td>";
            // HTMLContent += "       <td>" + DateTime.Parse(table.Rows[i]["NgayXuatChiTiet"].ToString()).ToString("dd/MM/yyyy") + "</td>";
            // string IDMauSac = StaticData.getField("HangHoa", "IDMauSac", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString());
            // string MauSac = StaticData.getField("MauSac", "TenMauSac", "IDMauSac", IDMauSac);
            //  HTMLContent += "       <td>" + MauSac + "</td>";
            string IDDonViTinh = StaticData.getField("HangHoa", "IDDonViTinh", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString());
            string DonViTinh = StaticData.getField("DonViTinh", "TenDonViTinh", "IDDonViTinh", IDDonViTinh);
            HTMLContent += "       <td style='text-align: center;'>" + DonViTinh + "</td>";

            double a = double.Parse(table.Rows[i]["SoLuong"].ToString());

            HTMLContent += "       <td style='text-align: center;'>" + string.Format("{0:N0}", (a)).Replace(",", ".") + "</td><td>&nbsp;</td>  ";

            //  DataTable gc = Connect.GetTable("select GhiChu from ChiTietPhieuXuat where IDChiTietPhieuXuat=" + table.Rows[i]["IDChiTietPhieuXuat"].ToString() + "");

            HTMLContent += "     </tr>";

        }



        HTMLContent += @"</table><table border='0'>
 <tr>
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
            <td >&nbsp;</td>
            <td>&nbsp;</td>
              <td>&nbsp;</td>
   
        </tr>
        <tr> 
               <td colspan='2' style='text-align: left;'><font  color='white'>abcd</font><b>ĐẠI DIỆN BÊN NHẬN HÀNG</b></td> 
            <td>&nbsp;</td>
           
           
            <td colspan='4' style='text-align: center;'><font  color='white'>abcdefgefgce</font><b><font  color='white'>eee</font>ĐẠI DIỆN BÊN GIAO HÀNG</b></td>
        
        </tr>
        <tr> 
             <td style='text-align: left;' colspan='2'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font  color='white'>abcdabcd</font>Người nhận hàng</td> 
            <td>&nbsp;</td>
           
         
            <td style='text-align: center;' colspan='4'><font  color='white'>abcdefgefgc</font><font  color='white'>eee</font>Người giao hàng</td> 
            
        </tr>

</table>
          

</body></html>";

        //  var strBody = new StringBuilder();

        //  strBody.Append("<html " +
        //   "xmlns:o='urn:schemas-microsoft-com:office:office' " +
        //   "xmlns:w='urn:schemas-microsoft-com:office:word'" +
        //    "xmlns='http://www.w3.org/TR/REC-html40'>" +
        //    "<head><title>Time</title>");

        //  //  The setting specifies document's view after it is downloaded as Print
        //  //   instead of the default Web Layout
        //  strBody.Append("<!--[if gte mso 9]>" +
        //   "<xml>" +
        //   "<w:WordDocument>" +
        //   "<w:View>Print</w:View>" +
        //   "<w:Zoom>100</w:Zoom>" +
        //   "<w:DoNotOptimizeForBrowser/>" +
        //   "</w:WordDocument>" +
        //   "</xml>" +
        //   "<![endif]-->");

        //  strBody.Append("<style>" +
        //   "<!-- /* Style Definitions */" +
        //   "@page Section1" +
        //   "   {size:9.0in 10.0in; " +
        //   "   margin:0.8in 0.7in ; " +
        //   "   mso-header-margin:.1in; " +
        //   "   mso-footer-margin:.5in; mso-paper-source:0;}" +
        //   " div.Section1" +
        //   "   {page:Section1;}" +
        //   "-->" +
        //   "</style></head>");

        //  strBody.Append("<body lang=EN-US style='tab-interval:.5in'>" +
        //   "<div class=Section1>");
        //  strBody.Append(HTMLContent);
        //  //strBody.Append("</div></body></html>");
        //  string TenFile = DateTime.Now.Ticks.ToString();
        //  string strPath2 = Request.PhysicalApplicationPath + @"Files\";
        //  string strPath = Request.PhysicalApplicationPath + @"Files\" + TenFile + ".doc";
        //  FileStream fStream = File.Create(strPath);
        //  fStream.Close();
        //  StreamWriter sWriter = new StreamWriter(strPath, false, Encoding.UTF8);
        //  sWriter.Write(strBody);
        //  sWriter.Close();
        //  // Response.Write(strPath);
        //  /*  Document doc = new Document();

        //    doc.LoadFromFile(@"" + strPath);

        //    doc.SaveToFile(@"" + strPath2 + "636404763499472227.PDF", FileFormat.PDF);

        //    System.Diagnostics.Process.Start(@"" + strPath2 + "636404763499472227.PDF");*/

        //  var wordApp = new Microsoft.Office.Interop.Word.Application();
        //  var wordDocument = wordApp.Documents.Open(@"" + strPath);
        //  string downloadsPath = KnownFolders.GetPath(KnownFolders.KnownFolder.Desktop);
        //  string ten =@"BB2" + DateTime.Now.ToString() + ".PDF";
        //  wordDocument.ExportAsFixedFormat(@"" + downloadsPath + @"\" + ten.Replace(" ", "").Replace("/", "").Replace(":", ""), Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);
        ////  wordDocument.ExportAsFixedFormat(ten, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);
        //  wordDocument.Close(Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges,
        //                     Microsoft.Office.Interop.Word.WdOriginalFormat.wdOriginalDocumentFormat,
        //                     false); //Close document

        //  wordApp.Quit();
        //  //Response.Write(ten.Replace(" ", "").Replace("/", "").Replace(":", ""));
        //  Response.Write("Đã xuất file pdf ra " + downloadsPath);

        string FileName = "BB2";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        Response.AppendHeader("Content-Type", "application/pdf");
        Response.AppendHeader("Content-disposition", "attachment; filename=" + FileName + ".pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        stringWrite.WriteLine(HTMLContent);

        HtmlTextWriter hw = new HtmlTextWriter(stringWrite);
        StringReader sr = new StringReader(stringWrite.ToString());
        Document pdfDoc = new Document(PageSize.A4, 20f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter wi = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();

        //string fontpath = Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + "\\ARIALUNI.TTF";        //  "ARIALUNI.TTF" file copied from fonts folder and placed in the folder
        string fontpath = "http://vienlien.lamphanmem.com/Fonts/ARIALUNI.TTF";        //  "ARIALUNI.TTF" file copied from fonts folder and placed in the folder
        BaseFont bf = BaseFont.CreateFont(fontpath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        FontFactory.RegisterDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), true);
        FontFactory.Register(fontpath, "Arial Unicode MS");

        //string path = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/ArialUni.TFF");
        //iTextSharp.text.Font fnt = new iTextSharp.text.Font();
        //FontFactory.Register(path, "Arial Unicode MS");
        //fnt = FontFactory.GetFont("Arial Unicode MS", BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 10, Font.NORMAL);


        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
        /* Response.AppendHeader("content-disposition", "attachment;filename=BB2.xls");
         Response.Charset = "";
         Response.Cache.SetCacheability(HttpCacheability.NoCache);
         Response.ContentType = "application/vnd.ms-excel";
         this.EnableViewState = false;
         Response.Write(HTMLContent);
         Response.End();*/

    }
    private void ExportExcel()
    {
        string MaPhieuXuat = StaticData.ValidParameter(Request.QueryString["MaPhieuXuat"].Trim());
        string sql = "";
        sql += @"select * from(select ROW_NUMBER() OVER(ORDER BY ChiTietPhieuXuat.NgayXuatChiTiet asc)AS RowNumber,HangHoa.TenHangHoa,HangHoa.IDHangHoa,PhieuXuat.MaPhieuXuat,ChiTietPhieuXuat.SoLuong,ChiTietPhieuXuat.DonGiaXuat,ChiTietPhieuXuat.NgayXuatChiTiet from ChiTietPhieuXuat left join HangHoa on ChiTietPhieuXuat.IDHangHoa = HangHoa.IDHangHoa left join PhieuXuat on ChiTietPhieuXuat.IDPhieuXuat = PhieuXuat.IDPhieuXuat where '1'='1'";
        if (MaPhieuXuat.Trim() != "")
            sql += " and PhieuXuat.MaPhieuXuat like N'%" + MaPhieuXuat.Trim() + "%'";



        sql += "  ) as tb1";


        DataTable table = Connect.GetTable(sql);

        string HTMLContent = "<html><body encoding=" + BaseFont.IDENTITY_H + " style='font-family:Arial;font-size:10px;'>";
        DataTable NoiToi = Connect.GetTable("select top 1 KhachHang.TenKhachHang,PhongBan.TenPhongBan,CuaHang.TenCuaHang,CuaHang.DiaChi,PhongBan.DiaChiPhongBan,KhachHang.DiaChi as 'DiaChiKH',CuaHang.SoDienThoai,CuaHang.NguoiLienLac from ChiTietPhieuXuat left join KhachHang on ChiTietPhieuXuat.IDKhachHang = KhachHang.IDKhachHang left join PhongBan on ChiTietPhieuXuat.IDPhongBan = PhongBan.IDPhongBan left join CuaHang on ChiTietPhieuXuat.IDCuaHang = CuaHang.IDCuaHang where IDPhieuXuat = '" + StaticData.getField("PhieuXuat", "IDPhieuXuat", "MaPhieuXuat", MaPhieuXuat.Trim()) + "'");
        string NoiGiao = "";
        string DiaChi = "";
        string NoiNhan = "";
        string BenNhan = "";
        if (NoiToi.Rows.Count > 0)
        {

            if (NoiToi.Rows[0]["TenKhachHang"].ToString().Trim() != "")
            {
                if (NoiToi.Rows[0]["TenPhongBan"].ToString().Trim() != "")
                {
                    if (NoiToi.Rows[0]["TenCuaHang"].ToString().Trim() != "")
                    {
                        BenNhan = NoiToi.Rows[0]["TenKhachHang"].ToString().Trim() + "_" + NoiToi.Rows[0]["TenPhongBan"].ToString().Trim();
                        NoiNhan = "Chị/Anh " + NoiToi.Rows[0]["NguoiLienLac"].ToString().Trim() + " + Số điện thoại: " + NoiToi.Rows[0]["SoDienThoai"].ToString().Trim();
                    }
                    else
                    {
                        BenNhan = NoiToi.Rows[0]["TenKhachHang"].ToString().Trim();
                        NoiNhan = NoiToi.Rows[0]["TenPhongBan"].ToString().Trim();
                    }
                }
                else
                {
                    BenNhan = NoiToi.Rows[0]["TenKhachHang"].ToString().Trim();
                }

            }

            DiaChi = NoiToi.Rows[0]["DiaChiKH"].ToString();

        }

        HTMLContent += @"
       <table border='0'>
<tr>
<td style='text-align: right;'><img src='http://vienlien.lamphanmem.com/images/vienlien.png' width='35' height='45' /></td>
<td colspan='5'><br /><b>CÔNG TY CỔ PHẦN VIỄN LIÊN</b><br /><i>Số 32 Đường số 8 nhà ở Khu Z756, Phường 12, Q.10, Tp.Hồ Chí Minh</i></td>
<td style='text-align: center;' colspan='5'><b>CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM</b><br />Độc lập - Tự do - Hạnh phúc</td>
</tr>

</table>
<table border='0'>
<tr>
<td >&nbsp;</td>
<td colspan='5'><b><i><u>Tel</u></i></b> : 028 3620 8997 - <b><i><u>Fax</u></i></b> : 028 3620 8997</td>
<td style='text-align: center;' colspan='5'>**********</td>
</tr>

</table>

<table border='0'>
<tr>
 <td  style='text-align: right;'>Số:</td> 
            <td colspan='5'>" + MaPhieuXuat + @"</td>
            <td colspan='5' style='text-align: center;'><i>Tp,HCM Ngày&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tháng&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;năm</i></td>  

</tr>

</table><table>
        
        <tr>
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td >&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style='text-align: center; padding:15px 0px 15px 0px;' colspan='7' ><h2><b>BIÊN BẢN NGHIỆM THU & BÀN GIAO HÀNG HÓA</b></h2></td> 
        </tr>
        <tr>
            <td>&nbsp;</td> 
            <td colspan='5' ><h4><b>Bên giao :       CÔNG TY CỔ PHẦN VIỄN LIÊN</b></h4></td>
           <td>&nbsp;</td> 
        </tr>
         <tr>
            <td>&nbsp;</td> 
            <td colspan='5'><h5><b>Bên nhận : " + BenNhan + @"</b></h5></td>
           <td>&nbsp;</td> 
        </tr>   
        <tr>
            <td>&nbsp;</td> 
                <td colspan='5'><i>Nơi nhận: " + NoiNhan + @"</i></td>
           
           <td>&nbsp;</td> 
        </tr>
        <tr>
            <td>&nbsp;</td> 
            <td colspan='5'><i>Địa chỉ giao hàng: " + DiaChi + @"</i></td>
           <td>&nbsp;</td> 
        </tr>
          <tr>       
            <td>&nbsp;</td>     
            <td colspan='5'><i>Cùng tiến hành kiểm tra chất lượng và số lượng của những mặt hàng sau :</i></td>
           <td>&nbsp;</td> 
        </tr>     
             <tr>
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td >&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>    
</table><table border='1'>        
                   <tr>
                        <th style='text-align: center;'><b>STT</b></th>
                        <th style='text-align: center;'><b>DANH MỤC HÀNG HÓA</b></th>
                        <th style='text-align: center;'><b>ĐVT</b></th>
                        <th style='text-align: center;'><b>ĐƠN GIÁ</b></th>
                        <th style='text-align: center;'><b>SỐ LƯỢNG</b></th>                       
                        <th style='text-align: center;'><b>THÀNH TIỀN</b></th>
                        <th style='text-align: center;'><b>GHI CHÚ</b></th>
                    </tr> ";
        for (int i = 0; i < table.Rows.Count; i++)
        {
            HTMLContent += "<tr>";
            HTMLContent += " <td style='text-align: center;' style='border-right-color: black'>" + (i + 1).ToString() + "</td>";

            HTMLContent += "<td style='border-right-color: black'>" + table.Rows[i]["TenHangHoa"].ToString() + "</td>";
            // HTMLContent += "       <td>" + DateTime.Parse(table.Rows[i]["NgayXuatChiTiet"].ToString()).ToString("dd/MM/yyyy") + "</td>";
            // string IDMauSac = StaticData.getField("HangHoa", "IDMauSac", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString());
            // string MauSac = StaticData.getField("MauSac", "TenMauSac", "IDMauSac", IDMauSac);
            // HTMLContent += "       <td>" + MauSac + "</td>";
            string IDDonViTinh = StaticData.getField("HangHoa", "IDDonViTinh", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString());
            string DonViTinh = StaticData.getField("DonViTinh", "TenDonViTinh", "IDDonViTinh", IDDonViTinh);
            HTMLContent += "       <td style='border-right-color: black'>" + DonViTinh + "</td>";
            double SoXuat = double.Parse(table.Rows[i]["DonGiaXuat"].ToString());

            HTMLContent += "       <td style='text-align: center;'>" + string.Format("{0:N0}", (SoXuat)).Replace(",", ".")/* SoXuat.ToString("#,##").Replace(",", ".")*/ + "</td>";
            double a = double.Parse(table.Rows[i]["SoLuong"].ToString());

            HTMLContent += "       <td style='text-align: center;'>" + string.Format("{0:N0}", (a)).Replace(",", ".") /*a.ToString("#,##").Replace(",", ".")*/ + "</td>";

            double ThanhTien = SoXuat * a;

            HTMLContent += "<td style='text-align: center;'>" + string.Format("{0:N0}", (ThanhTien)).Replace(",", ".")/*ThanhTien.ToString("#,##").Replace(",", ".")*/ + "</td>";
            //  DataTable gc = Connect.GetTable("select GhiChu from ChiTietPhieuXuat where IDChiTietPhieuXuat=" + table.Rows[i]["IDChiTietPhieuXuat"].ToString() + "");
            HTMLContent += "       <td style='text-align: center;'>&nbsp;</td>";
            HTMLContent += "     </tr>";

        }


        HTMLContent += @"
</table><table border='0'>
  <tr>
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
            <td >&nbsp;</td>
            <td>&nbsp;</td>
              <td>&nbsp;</td>
             <td>&nbsp;</td>
        </tr>
        <tr>
                 <td colspan='2' style='text-align: left;'><font  color='white'>abcd</font><b>ĐẠI DIỆN BÊN NHẬN HÀNG</b></td> 
           
            <td>&nbsp;</td>
            <td >&nbsp;</td>
            
            <td colspan='3' style='text-align: center;'><font  color='white'>abcd</font><b>ĐẠI DIỆN BÊN GIAO HÀNG</b></td>
           
        </tr>
        <tr>
             <td style='text-align: left;' colspan='2'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <font  color='white'>abcd</font>Người nhận hàng</td> 
       
            <td>&nbsp;</td>
            <td >&nbsp;</td>
          
            <td colspan='3' style='text-align: center;'><font  color='white'>abcd</font>Người giao hàng</td>
      
        </tr>

</table>";


        string FileName = "BB1";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        Response.AppendHeader("Content-Type", "application/pdf");
        Response.AppendHeader("Content-disposition", "attachment; filename=" + FileName + ".pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        stringWrite.WriteLine(HTMLContent);

        HtmlTextWriter hw = new HtmlTextWriter(stringWrite);
        StringReader sr = new StringReader(stringWrite.ToString());
        Document pdfDoc = new Document(PageSize.A4, 20f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter wi = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();

        //string fontpath = Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + "\\ARIALUNI.TTF";        //  "ARIALUNI.TTF" file copied from fonts folder and placed in the folder
        string fontpath = "http://vienlien.lamphanmem.com/Fonts/ARIALUNI.TTF";        //  "ARIALUNI.TTF" file copied from fonts folder and placed in the folder
        BaseFont bf = BaseFont.CreateFont(fontpath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        FontFactory.RegisterDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), true);
        FontFactory.Register(fontpath, "Arial Unicode MS");

        //string path = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/ArialUni.TFF");
        //iTextSharp.text.Font fnt = new iTextSharp.text.Font();
        //FontFactory.Register(path, "Arial Unicode MS");
        //fnt = FontFactory.GetFont("Arial Unicode MS", BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 10, Font.NORMAL);


        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();


        /* Response.AppendHeader("content-disposition", "attachment;filename=BB1.xls");
         Response.Charset = "";
         Response.Cache.SetCacheability(HttpCacheability.NoCache);
         Response.ContentType = "application/vnd.ms-excel";
         this.EnableViewState = false;
         Response.Write(HTMLContent);
         Response.End();*/

        //  var strBody = new StringBuilder();

        //  strBody.Append("<html " +
        //   "xmlns:o='urn:schemas-microsoft-com:office:office' " +
        //   "xmlns:w='urn:schemas-microsoft-com:office:word'" +
        //    "xmlns='http://www.w3.org/TR/REC-html40'>" +
        //    "<head><title>Time</title>");

        //  //  The setting specifies document's view after it is downloaded as Print
        // //   instead of the default Web Layout
        //  strBody.Append("<!--[if gte mso 9]>" +
        //   "<xml>" +
        //   "<w:WordDocument>" +
        //   "<w:View>Print</w:View>" +
        //   "<w:Zoom>100</w:Zoom>" +
        //   "<w:DoNotOptimizeForBrowser/>" +
        //   "</w:WordDocument>" +
        //   "</xml>" +
        //   "<![endif]-->");

        //  strBody.Append("<style>" +
        //   "<!-- /* Style Definitions */" +
        //   "@page Section1" +
        //   "   {size:9.5in 10.0in; " +
        //   "   margin:0.8in 0.7in ; " +
        //   "   mso-header-margin:.1in; " +
        //   "   mso-footer-margin:.5in; mso-paper-source:0;}" +
        //   " div.Section1" +
        //   "   {page:Section1;}" +
        //   "-->" +
        //   "</style></head>");

        //  strBody.Append("<body lang=EN-US style='tab-interval:.5in'>" +
        //   "<div class=Section1>");
        //  strBody.Append(HTMLContent);
        //  strBody.Append("</div></body></html>");
        //  string TenFile = DateTime.Now.Ticks.ToString();
        //  string strPath2 = Request.PhysicalApplicationPath + @"Files\";
        //  string strPath = Request.PhysicalApplicationPath + @"Files\" + TenFile + ".doc";
        //  FileStream fStream = File.Create(strPath);
        //  fStream.Close();
        //  StreamWriter sWriter = new StreamWriter(strPath, false, Encoding.UTF8);
        //  sWriter.Write(strBody);
        //  sWriter.Close();
        // // Response.Write(strPath);
        ///*  Document doc = new Document();

        //  doc.LoadFromFile(@"" + strPath);

        //  doc.SaveToFile(@"" + strPath2 + "636404763499472227.PDF", FileFormat.PDF);

        //  System.Diagnostics.Process.Start(@"" + strPath2 + "636404763499472227.PDF");*/

        //  var wordApp = new Microsoft.Office.Interop.Word.Application();
        //  var wordDocument = wordApp.Documents.Open(@""+strPath);
        //  string downloadsPath = KnownFolders.GetPath(KnownFolders.KnownFolder.Desktop);
        //  string ten = "BB1" + DateTime.Now.ToString() + ".PDF";

        //  wordDocument.ExportAsFixedFormat(@"" + downloadsPath + @"\" + ten.Replace(" ", "").Replace("/", "").Replace(":", ""), Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);

        //  wordDocument.Close(Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges,
        //                     Microsoft.Office.Interop.Word.WdOriginalFormat.wdOriginalDocumentFormat,
        //                     false); //Close document

        //  wordApp.Quit();

        //  Response.Write("Đã xuất file pdf ra "+downloadsPath);



        //string FileName = "ABC";
        //System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        //Response.AppendHeader("Content-Type", "application/pdf");
        //Response.AppendHeader("Content-disposition", "attachment; filename=" + FileName + ".pdf");
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);

        //stringWrite.WriteLine(HTMLContent);

        //HtmlTextWriter hw = new HtmlTextWriter(stringWrite);
        //StringReader sr = new StringReader(stringWrite.ToString());
        //Document pdfDoc = new Document(PageSize.A4, 20f, 10f, 10f, 0f);
        //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //PdfWriter wi = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //pdfDoc.Open();

        ////string fontpath = Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + "\\ARIALUNI.TTF";        //  "ARIALUNI.TTF" file copied from fonts folder and placed in the folder
        //string fontpath = "http://vienlien.lamphanmem.com/Fonts/ARIALUNI.TTF";        //  "ARIALUNI.TTF" file copied from fonts folder and placed in the folder
        //BaseFont bf = BaseFont.CreateFont(fontpath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        //FontFactory.RegisterDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), true);
        //FontFactory.Register(fontpath, "Arial Unicode MS");

        ////string path = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/ArialUni.TFF");
        ////iTextSharp.text.Font fnt = new iTextSharp.text.Font();
        ////FontFactory.Register(path, "Arial Unicode MS");
        ////fnt = FontFactory.GetFont("Arial Unicode MS", BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 10, Font.NORMAL);


        //htmlparser.Parse(sr);
        //pdfDoc.Close();
        //Response.Write(pdfDoc);
        //Response.End();


    }
    private void LayGiaNhapGanNhat()
    {
        string IDChiTietPhieuXuat = StaticData.ValidParameter(Request.QueryString["IDHangHoa"].Trim());

        string sql = "";

        sql += "select DonGiaNhap,IDChiTietPhieuNhap from ChiTietPhieuNhap where IDChiTietPhieuNhap in (select max(a.IDChiTietPhieuNhap) from ChiTietPhieuNhap a where a.IDHangHoa ='" + IDChiTietPhieuXuat + "')";
        DataTable table = Connect.GetTable(sql);
        if (table.Rows.Count > 0)
        {
            string DonGiaNhap = double.Parse(table.Rows[0]["DonGiaNhap"].ToString().Trim()).ToString("#,##").Replace(",", ".");
            string IDChiTietPhieuNhap = table.Rows[0]["IDChiTietPhieuNhap"].ToString();
            Response.Write(DonGiaNhap);
        }
        else
            Response.Write("False");
    }
    private void DeleteCuaHang()
    {
        string IDChiTietPhieuXuat = StaticData.ValidParameter(Request.QueryString["IDCuaHang"].Trim());

        string sql = "";

        sql += "  delete from CuaHang  where IDCuaHang = " + IDChiTietPhieuXuat + "";
        bool table = Connect.Exec(sql);
        if (table)
            Response.Write("True");
        else
            Response.Write("False");
    }
    private void XemPhongBan()
    {
        string IDKhachHang = StaticData.ValidParameter(Request.QueryString["IDKhachHang"].Trim());
        string sql = "";
        sql += "select * from PhongBan where IDKhachHang = " + IDKhachHang + "";
        DataTable table = Connect.GetTable(sql);
        string html = @"<div style'text-align:center; padding:10px'><b>XEM CHI TIẾT PHÒNG BAN CỦA KHÁCH HÀNG " + StaticData.getField("KhachHang", "TenKhachHang", "IDKhachHang", Request.QueryString["IDKhachHang"].Trim()) + "</b>";
        html += @"</div>
<table class='table table-bordered table-striped'>
                                <tr>
                                    <th class='th' style='text-align:center'>
                                        STT
                                    </th>
                                    <th class='th' style='text-align:center'>
                                       Mã phòng ban
                                    </th>
                                    <th class='th' style='text-align:center'>
                                        Tên phòng ban
                                    </th>
                                    <th class='th' style='text-align:center'>
                                        Xem phòng ban
                                    </th>
                                </tr>
                               ";
        for (int i = 0; i < table.Rows.Count; i++)
        {
            int stt = i + 1;
            html += "       <tr>";
            html += "       <td>" + stt + "</td>";


            html += "       <td>" + table.Rows[i]["MaPhongBan"].ToString() + "</td>";

            html += "       <td>" + table.Rows[i]["TenPhongBan"].ToString() + "</td>";

            html += " <td><a href='DanhMucPhongBan.aspx?TenPhongBan=" + table.Rows[i]["TenPhongBan"].ToString() + "&' >Xem thông tin</a></td>";
            html += "       </tr>";
        }
        html += "          </table>";
        Response.Write(html);
    }
    private void XemCuaHang()
    {
        string IDPhongBan = StaticData.ValidParameter(Request.QueryString["IDPhongBan"].Trim());
        string sql = "";
        sql += "select * from CuaHang where IDPhongBan = " + IDPhongBan + "";
        DataTable table = Connect.GetTable(sql);
        string html = @"<div style'text-align:center; padding:10px'><b>XEM CHI TIẾT CỬA HÀNG CỦA PHÒNG BAN " + StaticData.getField("PhongBan", "TenPhongBan", "IDPhongBan", Request.QueryString["IDPhongBan"].Trim()) + "</b>";
        html += @"</div>
<table class='table table-bordered table-striped'>
                                <tr>
                                    <th class='th' style='text-align:center'>
                                        STT
                                    </th>
                                    <th class='th' style='text-align:center'>
                                       Mã cửa hàng
                                    </th>
                                    <th class='th' style='text-align:center'>
                                        Tên cửa hàng
                                    </th>
                                    <th class='th' style='text-align:center'>
                                      Xem cửa hàng
                                    </th>
                                </tr>
                               ";
        for (int i = 0; i < table.Rows.Count; i++)
        {
            int stt = i + 1;
            html += "       <tr>";
            html += "       <td>" + stt + "</td>";


            html += "       <td>" + table.Rows[i]["MaCuaHang"].ToString() + "</td>";

            html += "       <td>" + table.Rows[i]["TenCuaHang"].ToString() + "</td>";

            html += " <td><a href='DanhMucCuaHang.aspx?TenCuaHang=" + table.Rows[i]["TenCuaHang"].ToString() + "&' >Xem thông tin</a></td>";
            html += "       </tr>";
        }
        html += "          </table>";
        Response.Write(html);
    }
    private void PhongBanChoCuaHangAutocomplete()
    {

        string sql = "";

        sql += "select PhongBan.TenPhongBan,PhongBan.IDPhongBan,KhachHang.TenKhachHang from PhongBan left join KhachHang on PhongBan.IDKhachHang = KhachHang.IDKhachHang where '1'='1'";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";

        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";
            listgAutocomplete += "valuekh: '" + table.Rows[i]["TenKhachHang"].ToString() + "',";
            listgAutocomplete += "value: '" + table.Rows[i]["TenPhongBan"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["TenPhongBan"].ToString() + "-" + table.Rows[i]["TenKhachHang"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["IDPhongBan"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }
    private void TenCuaHangAutocomplete()
    {

        string sql = "";

        sql += "  select * from CuaHang";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";

        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";

            listgAutocomplete += "value: '" + table.Rows[i]["TenCuaHang"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["TenCuaHang"].ToString() + "-" + table.Rows[i]["MaCuaHang"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["IDCuaHang"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }
    private void PhongBanAutocomplete()
    {
        string sql = "";
        sql += "  select * from PhongBan";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";

        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";

            listgAutocomplete += "value: '" + table.Rows[i]["TenPhongBan"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["TenPhongBan"].ToString() + "-" + table.Rows[i]["MaPhongBan"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["IDPhongBan"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }
    private void DeletePhongBan()
    {
        string IDChiTietPhieuXuat = StaticData.ValidParameter(Request.QueryString["IDPhongBan"].Trim());

        string sql = "";

        sql += "  delete from PhongBan  where IDPhongBan = " + IDChiTietPhieuXuat + "";
        bool table = Connect.Exec(sql);
        if (table)
            Response.Write("True");
        else
            Response.Write("False");
    }
    private void TenPhongBanAutocomplete()
    {

        string sql = "";

        sql += "  select * from PhongBan";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";

        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";

            listgAutocomplete += "value: '" + table.Rows[i]["TenPhongBan"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["TenPhongBan"].ToString() + "-" + table.Rows[i]["MaPhongBan"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["IDPhongBan"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }
    private void Mo2()
    {
        string IDHangHoa = StaticData.ValidParameter(Request.QueryString["IDHangHoa"].Trim());
        string NhomHangHoa = StaticData.getField("NhomHangHoa", "TenNhomHangHoa", "IDNhomHangHoa", StaticData.getField("HangHoa", "IDNhomHangHoa", "IDHangHoa", IDHangHoa));
        string DonViTinh = StaticData.getField("DonViTinh", "TenDonViTinh", "IDDonViTinh", StaticData.getField("HangHoa", "IDDonViTinh", "IDHangHoa", IDHangHoa));
        string ChungLoaiHangHoa = StaticData.getField("ChungLoaiHangHoa", "TenChungLoaiHangHoa", "IDChungLoaiHangHoa", StaticData.getField("HangHoa", "IDChungLoaiHangHoa", "IDHangHoa", IDHangHoa));
        string DongGoi = StaticData.getField("HangHoa", "DongGoi", "IDHangHoa", IDHangHoa);
        string Ten = StaticData.getField("HangHoa", "TenHangHoa", "IDHangHoa", IDHangHoa);
        string MauSac = StaticData.getField("MauSac", "TenMauSac", "IDMauSac", StaticData.getField("HangHoa", "IDMauSac", "IDHangHoa", IDHangHoa));
        string BarcodeSPTheoDVT = StaticData.getField("HangHoa", "BarcodeSPTheoDVT", "IDHangHoa", IDHangHoa);
        string BarcodeHopLocInner = StaticData.getField("HangHoa", "BarcodeHopLocInner", "IDHangHoa", IDHangHoa);
        string Muc = StaticData.getField("HangHoa", "Muc", "IDHangHoa", IDHangHoa);
        string listgAutocomplete = "['" + NhomHangHoa + "','" + DonViTinh + "','" + ChungLoaiHangHoa + "','" + DongGoi + "','" + Ten + "','" + MauSac + "','" + BarcodeSPTheoDVT + "','" + BarcodeHopLocInner + "','" + Muc + "']";


        Response.Write(listgAutocomplete);
    }
    private void LoadTenNguoiDung()
    {

        string sql = "";

        sql += @"SELECT
IDLoaiHangHoa, TenLoaiHangHoa + ' - ' + MaLoaiHangHoa AS TenLHH FROM LoaiHangHoa ";

        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";

        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";

            listgAutocomplete += "value: '" + table.Rows[i]["TenLHH"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["IDLoaiHangHoa"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }
    private void LoadTaiKhoan()
    {

        string sql = "";

        sql += "  select TaiKhoan from NguoiDung";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";

        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";

            listgAutocomplete += "value: '" + table.Rows[i]["TaiKhoan"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["TaiKhoan"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["TaiKhoan"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }

    private void DeleteNguoiDung()
    {
        string IDChiTietPhieuXuat = StaticData.ValidParameter(Request.QueryString["IDNguoiDung"].Trim());

        string sql = "";

        sql += "  delete from NguoiDung  where IDNguoiDung = " + IDChiTietPhieuXuat + "";
        bool table = Connect.Exec(sql);
        if (table)
            Response.Write("True");
        else
            Response.Write("False");
    }
    private void LoadChiTietXuatHang()
    {
        string IDPhieuXuat = StaticData.ValidParameter(Request.QueryString["IDPhieuXuat"].Trim());


        string html = @"<h2>HÓA ĐƠN : " + StaticData.getField("PhieuXuat", "MaPhieuXuat", "IDPhieuXuat", IDPhieuXuat) + "</h2><hr />";

        DataTable table = Connect.GetTable("select * from PhieuXuat where IDPhieuXuat=" + IDPhieuXuat + "");


        string IDKhachHang = table.Rows[0]["IDKhachHang"].ToString();

        double ConLai = MyStaticData.GetNoKhachHangNgoaiTruPhieuXuat(IDKhachHang, IDPhieuXuat) - MyStaticData.GetSoTienDaTraCuaKhachHang(IDKhachHang);


        html += @"

<table style='width:100%;'>
<tr>
<td style='text-align:left;'><b>Tên khách hàng :</b> " + StaticData.getField("KhachHang", "TenKhachHang", "IDKhachHang", table.Rows[0]["IDKhachHang"].ToString()) + @"</td>

<td style='text-align:left;'>";
        if (table.Rows[0]["NgayXuat"].ToString() == "")
            html += @"<b>Ngày :</b> - ";
        else
            html += "<b>Ngày:</b> " + DateTime.Parse(table.Rows[0]["NgayXuat"].ToString()).ToString("dd/MM/yyyy") + @"";
        html += @"</td>
</tr>
<tr>
<td style='text-align:left;'><b>Tiền khách thanh toán :</b> " + double.Parse(table.Rows[0]["TienThanhToan"].ToString()).ToString("#,##").Replace(",", ".") + @"
<td style='text-align:left;'><b>Ghi chú :</b> " + table.Rows[0]["GhiChu"].ToString().Replace("\n", "<br />") + @"
</tr>
</table>";


        html += @"
<div style='text-align:center;'>";

        html += @"<br /><center><table border='1' cellspacing='0' style='width:100%;' class='table table-bordered table-striped'><tr>
             <th class='th'>STT</th>
             <th class='th'>Hàng hóa</th>
            <th class='th'>ĐV Tính</th>
             <th class='th'>Số lượng</th>
            <th class='th'>Đơn giá</th>
            <th class='th'>Thành tiền</th>
          </tr>";
        double Tong = 0; double sl = 0;

        string query = @"select tb2.IDLoaiHangHoa,tb2.SoLuong,tb2.DonGia,tb2.ThanhTien
from 
(select HangHoa.IDLoaiHangHoa, isnull(sum(ChiTietPhieuXuat.SoLuong),0) as 'SoLuong' , isnull(AVG(ChiTietPhieuXuat.DonGiaXuat),0) as 'DonGia',  isnull(sum(ChiTietPhieuXuat.SoLuong),0) *  isnull(AVG(ChiTietPhieuXuat.DonGiaXuat),0) AS 'ThanhTien' 
from ChiTietPhieuXuat,HangHoa 
where ChiTietPhieuXuat.IDHangHoa=HangHoa.IDHangHoa and IDPhieuXuat=" + IDPhieuXuat + @"
 group by HangHoa.IDLoaiHangHoa) as tb2
 
 ,
( 
select ROW_NUMBER() OVER(ORDER BY ChiTietPhieuXuat.IDChiTietPhieuXuat asc)AS RowNumber,HangHoa.IDLoaiHangHoa from ChiTietPhieuXuat,PhieuXuat,HangHoa 
 where ChiTietPhieuXuat.IDPhieuXuat=PhieuXuat.IDPhieuXuat and ChiTietPhieuXuat.IDHangHoa=HangHoa.IDHangHoa
 and PhieuXuat.IDPhieuXuat = " + IDPhieuXuat + @" 
 ) as tb3
 where tb2.IDLoaiHangHoa = tb3.IDLoaiHangHoa order by tb3.RowNumber";
        DataTable dbTable = Connect.GetTable(query);


        DataTable bang = Connect.GetTable("select HangHoa.IDLoaiHangHoa, isnull(sum(ChiTietPhieuXuat.SoLuong),0) as 'SoLuong' , isnull(AVG(ChiTietPhieuXuat.DonGiaXuat),0) as 'DonGia',  isnull(sum(ChiTietPhieuXuat.SoLuong),0) *  isnull(AVG(ChiTietPhieuXuat.DonGiaXuat),0) AS 'ThanhTien' from ChiTietPhieuXuat,HangHoa where ChiTietPhieuXuat.IDHangHoa=HangHoa.IDHangHoa and IDPhieuXuat=" + IDPhieuXuat + " group by HangHoa.IDLoaiHangHoa");
        bang = MyStaticData.RemoveDuplicateRows(dbTable, "IDLoaiHangHoa");

        for (int i = 0; i < bang.Rows.Count; i++)
        {
            html += "<tr>";
            html += "<td>" + (i + 1).ToString() + "</td>";
            //  html += "<td>" + StaticData.getField("LoaiHangHoa", "MaLoaiHangHoa", "IDLoaiHangHoa", bang.Rows[i]["IDLoaiHangHoa"].ToString()) + "</td>";
            html += "<td>" + StaticData.getField("LoaiHangHoa", "TenLoaiHangHoa", "IDLoaiHangHoa", bang.Rows[i]["IDLoaiHangHoa"].ToString()) + " - " + StaticData.getField("LoaiHangHoa", "MaLoaiHangHoa", "IDLoaiHangHoa", bang.Rows[i]["IDLoaiHangHoa"].ToString()) + "</td>";

            html += "<td>" + StaticData.getField("DonViTinh", "TenDonViTinh", "idDonViTinh", StaticData.getField("LoaiHangHoa", "IDDonViTinh", "IDLoaiHangHoa", bang.Rows[i]["IDLoaiHangHoa"].ToString())) + "</td>";

            if (bang.Rows[i]["SoLuong"].ToString().Trim() == "0")
                html += "<td style='text-align:center;'>" + bang.Rows[i]["SoLuong"].ToString() + "</td>";
            else html += "<td style='text-align:center;'>" + double.Parse(bang.Rows[i]["SoLuong"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";
            sl += double.Parse(bang.Rows[i]["SoLuong"].ToString());
            if (bang.Rows[i]["DonGia"].ToString().Trim() == "0")
                html += "<td style='text-align:right;'>" + bang.Rows[i]["DonGia"].ToString() + "</td>";
            else html += "<td style='text-align:right;'>" + double.Parse(bang.Rows[i]["DonGia"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";

            if (bang.Rows[i]["ThanhTien"].ToString().Trim() == "0")
                html += "<td style='text-align:right;'>" + bang.Rows[i]["ThanhTien"].ToString() + "</td>";
            else html += "<td style='text-align:right;'>" + double.Parse(bang.Rows[i]["ThanhTien"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";

            double thanhTien = double.Parse(bang.Rows[i]["ThanhTien"].ToString());

            Tong += thanhTien;
            html += "</tr>";
        }
        html += "<tr>";
        html += "<td colspan='3' >&nbsp;</td>";
        html += "<td style='text-align:center;'><b>" + sl.ToString("#,##").Replace(",", ".") + "</b></td>";
        html += "<td colspan='2' >&nbsp;</td>";
        html += "</tr>";
        html += @"</table> ";

        html += @"<div style='text-align:left;'><table border='1'> ";
        html += "<tr style='background-color:white;'>";
        html += "<td colspan='5' style='text-align:right;'><b>Tổng tiền đơn hàng</b></td>";
        html += "<td style='text-align:right;'><b>" + Tong.ToString("#,##").Replace(",", ".") + "</b></td>";
        html += "</tr>";

        html += "<tr style='background-color:white;'>";
        html += "<td colspan='5' style='text-align:right;'><b>Tổng tiền khách nợ</b></td>";
        html += "<td style='text-align:right;'><b>" + ConLai.ToString("#,##").Replace(",", ".") + "</b></td>";
        html += "</tr>";







        string sql = "";
        sql += "  select isnull(sum(DonGiaXuat*SoLuong),0) as 'Tong' from ChiTietPhieuXuat where ChiTietPhieuXuat.IDPhieuXuat = " + IDPhieuXuat + " ";
        DataTable table2 = Connect.GetTable(sql);
        double tong = double.Parse(table2.Rows[0]["Tong"].ToString()) + ConLai;
        html += "<tr style='background-color:white;'>";
        html += "<td colspan='5' style='text-align:right;'><b>Tổng tiền phải trả</b></td>";
        html += "<td style='text-align:right;'><b>" + tong.ToString("#,##").Replace(",", ".") + "</b></td>";
        html += "</tr>";

        html += "<tr style='background-color:white;'>";
        html += "<td colspan='5' style='text-align:right;'><b>Tiền khách thanh toán</b></td>";
        html += "<td style='text-align:right;'><b>" + double.Parse(table.Rows[0]["TienThanhToan"].ToString()).ToString("#,##").Replace(",", ".") + "</b></td>";
        html += "</tr>";




        html += @"</table></div> ";



        Response.Write(html);
    }
    private void LoadChiTietNhapHang()
    {
        string IDPhieuNhap = StaticData.ValidParameter(Request.QueryString["IDPhieuNhap"].Trim());
        string sql = "";

        sql += "select * from ChiTietPhieuNhap where IDPhieuNhap = " + IDPhieuNhap + " order by ChiTietPhieuNhap.IDChiTietPhieuNhap asc";
        DataTable table = Connect.GetTable(sql);
        string html = @"<center><h2>CHI TIẾT " + StaticData.getField("PhieuNhap", "MaPhieuNhap", "IDPhieuNhap", IDPhieuNhap) + @"</h2></center><br /><table class='table table-bordered table-striped' >
                                <tr>
                                    <th class='th'>
                                        STT
                                    </th>  <th class='th'>Mã Hàng hóa</th> 
                                   <th class='th'>Tên Hàng hóa</th>  <th class='th'>Size</th>  <th class='th'> Màu</th>
                                    <th class='th'>
                                      Số lượng
                                    </th>
                                    <th class='th'>
                                       Đơn giá nhập
                                    </th>
                                <th class='th'>
                                      Thành tiền
                                    </th>
                                  
                                   
                                 
                                      
                                </tr> ";
        double Tong = 0;
        for (int i = 0; i < table.Rows.Count; i++)
        {
            html += "       <tr>";
            int stt = i + 1;

            html += "       <td>" + stt + "</td>";
            html += "       <td>" + StaticData.getField("LoaiHangHoa", "MaLoaiHangHoa", "IDLoaiHangHoa", StaticData.getField("HangHoa", "IDLoaiHangHoa", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString().Trim())) + "</td>";
            html += "       <td>" + StaticData.getField("LoaiHangHoa", "TenLoaiHangHoa", "IDLoaiHangHoa", StaticData.getField("HangHoa", "IDLoaiHangHoa", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString().Trim())) + "-" + StaticData.getField("LoaiHangHoa", "MaLoaiHangHoa", "IDLoaiHangHoa", StaticData.getField("HangHoa", "IDLoaiHangHoa", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString().Trim())) + "</td>";
            html += "       <td>" + StaticData.getField("Size", "TenSize", "IDSize", StaticData.getField("HangHoa", "IDSize", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString().Trim())) + "</td>";
            html += "       <td>" + StaticData.getField("MauSac", "TenMauSac", "IDMauSac", StaticData.getField("HangHoa", "IDMauSac", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString().Trim())) + "</td>";

            if (table.Rows[i]["SoLuong"].ToString().Trim() != "0")
                html += "<td>" + double.Parse(table.Rows[i]["SoLuong"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";
            else html += "<td>" + table.Rows[i]["SoLuong"].ToString() + "</td>";

            if (table.Rows[i]["DonGiaNhap"].ToString().Trim() != "0")
                html += "<td>" + double.Parse(table.Rows[i]["DonGiaNhap"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";
            else html += "<td>" + table.Rows[i]["DonGiaNhap"].ToString() + "</td>";

            string SL = table.Rows[i]["SoLuong"].ToString();
            double r = double.Parse(SL);

            double dg = double.Parse(table.Rows[i]["DonGiaNhap"].ToString());

            double thanhtien = r * dg;
            if (thanhtien == 0)
            {
                html += "<td>" + thanhtien.ToString() + "</td>";
            }
            else
            {
                html += "<td>" + thanhtien.ToString("#,##").Replace(",", ".") + "</td>";
            }

            //   html += "       <td>" + table.Rows[i]["GhiChu"].ToString().Trim().Replace("\n", "<br />") + "</td>";
            try
            {
                Tong += thanhtien;
            }
            catch
            {

            }
            // html += "<td style='text-align:center;font-size: 100%;'><a style='cursor:pointer;' onclick='SuaChiTietNhap(\"" + table.Rows[i]["IDChiTietPhieuNhap"].ToString().Trim() + "\");'><img title='Sửa' class='imgCommand' src='../Images/edit.png' onclick='SuaChiTietNhap(\"" + table.Rows[i]["IDChiTietPhieuNhap"].ToString().Trim() + "\");' /></a></td>";

            //  html += "<td style='text-align:center;font-size: 100%;'><a style='cursor:pointer;' onclick='DeleteChiTietPhieuNhap(\"" + table.Rows[i]["IDChiTietPhieuNhap"].ToString() + "\")'><img title='Xóa' class='imgCommand' src='../Images/delete.png'  /></a></td>";
            html += "       </tr>";

        }
        html += "       <tr >";
        html += " <td colspan='7' style='text-align:right;background-color:lightgreen;'><b>Tổng cộng</b>     </td>";
        html += " <td style='background-color:lightgreen;'><b>" + Tong.ToString("#,##").Replace(",", ".") + "</b>      </td>";
        //html += "<td style='background-color:lightgreen;'>&nbsp;</td>";
        html += "       </tr>";
        html += "  </table>";
        Response.Write(html);

    }
    private void THHhoa()
    {

        string sql = "";

        sql += "  select TenHangHoa,MaHangHoa from HangHoa";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";

        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";

            listgAutocomplete += "value: '" + table.Rows[i]["TenHangHoa"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["TenHangHoa"].ToString() + "-" + table.Rows[i]["MaHangHoa"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["TenHangHoa"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }
    //
    private void loadmaphieunhap()
    {
        string sql = "";
        sql += "  select * from PhieuNhap where MaPhieuNhap not like '%-XB'";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";

        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";

            listgAutocomplete += "value: '" + table.Rows[i]["MaPhieuNhap"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["MaPhieuNhap"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["IDPhieuNhap"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }
    //private void DeletePhieuXuat()
    //{
    //    string IDChiTietPhieuXuat = StaticData.ValidParameter(Request.QueryString["IDPhieuXuat"].Trim());


    //    string sqlKiemTra = "SELECT * FROM [ChiTietPhieuXuat] WHERE [IDPhieuXuat] = '" + IDChiTietPhieuXuat + "'";
    //    DataTable tb = Connect.GetTable(sqlKiemTra);

    //    if (tb.Rows.Count == 0)
    //    {
    //        string sql = "";

    //        sql += "  delete PhieuXuat  where IDPhieuXuat = " + IDChiTietPhieuXuat + "";
    //        bool table = Connect.Exec(sql);
    //        if (table)
    //            Response.Write("True");
    //        else
    //            Response.Write("False");
    //    }
    //    else
    //    {
    //        Response.Write("ConHang");
    //    }

    //}
    //


    private void DeletePhieuXuat()
    {
        string IDPhieuXuat = StaticData.ValidParameter(Request.QueryString["IDPhieuXuat"].Trim());
        string MaPhieuXuat = StaticData.getField("PhieuXuat", "MaPhieuXuat", "IDPhieuXuat", IDPhieuXuat);
        string sql21 = "insert into BangLog(TaiKhoan,ThaoTac,NgayGio) values (N'" + Request.Cookies["BanSiQuanAo_Login"].Value.Trim() + "',N'Xóa hết phiếu xuất " + MaPhieuXuat + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "')";
        bool kq12 = Connect.Exec(sql21);
        string sql = "DELETE FROM [ChiTietPhieuXuat] WHERE [IDPhieuXuat] = '" + IDPhieuXuat + "'";

        bool kt = Connect.Exec(sql);
        if (kt)
        {
            string sql2 = "";

            sql2 += "  delete PhieuXuat  where IDPhieuXuat = " + IDPhieuXuat + "";
            bool table = Connect.Exec(sql2);
            if (table)
                Response.Write("True");
            else
                Response.Write("False");
        }
        else
        {
            Response.Write("False");
        }


    }




    private void loadmaphieuxuat()
    {

        string sql = "";

        sql += "  select * from PhieuXuat";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";

        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";

            listgAutocomplete += "value: '" + table.Rows[i]["MaPhieuXuat"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["MaPhieuXuat"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["IDPhieuXuat"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }
    //
    private void DeleteChiTietPhieuXuat()
    {
        string IDChiTietPhieuXuat = StaticData.ValidParameter(Request.QueryString["IDChiTietPhieuXuat"].Trim());
        string MaPhieuXuat = StaticData.getField("PhieuXuat", "MaPhieuXuat", "IDPhieuXuat", StaticData.getField("ChiTietPhieuXuat", "IDPhieuXuat", "IDChiTietPhieuXuat", IDChiTietPhieuXuat));
        string sql = "";

        sql += "  delete ChiTietPhieuXuat  where IDChiTietPhieuXuat = " + IDChiTietPhieuXuat + "";
        bool table = Connect.Exec(sql);
        if (table)
        {


            // string MaPhieuXuat = StaticData.getField("PhieuXuat", "MaPhieuXuat", "IDPhieuXuat", StaticData.getField("ChiTietPhieuXuat", "IDPhieuXuat", "IDChiTietPhieuXuat", IDChiTietPhieuXuat));
            string sql2 = "insert into BangLog(TaiKhoan,ThaoTac,NgayGio) values (N'" + Request.Cookies["BanSiQuanAo_Login"].Value.Trim() + "',N'Xóa chi tiết phiếu xuất hàng " + MaPhieuXuat + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "')";
            bool kq2 = Connect.Exec(sql2);
            Response.Write("True");
        }
        else
            Response.Write("False");




    }
    //
    private void SuaChiTietPhieuXuat()
    {
        string IDPhieuXuat = StaticData.ValidParameter(Request.QueryString["IDPhieuXuat"].Trim());
        string IDHangHoa = StaticData.ValidParameter(Request.QueryString["IDHangHoa"].Trim());

        string SoLuong = StaticData.ValidParameter(Request.QueryString["SoLuong"].Trim());
        string DonGiaXuat = StaticData.ValidParameter(Request.QueryString["DonGiaXuat"].Trim());

        string GhiChu = StaticData.ValidParameter(Request.QueryString["GhiChu"].Trim());

        string IDChiTietPhieuXuat = StaticData.ValidParameter(Request.QueryString["IDChiTietPhieuXuat"].Trim());

        string IDHangHoaCu = StaticData.getField("ChiTietPhieuXuat", "IDHangHoa", "IDChiTietPhieuXuat", IDChiTietPhieuXuat);

        string sql = " update ChiTietPhieuXuat set IDPhieuXuat = " + IDPhieuXuat + ",IDHangHoa=" + IDHangHoa + ",SoLuong=" + SoLuong + ",DonGiaXuat=" + DonGiaXuat + ",GhiChu=N'" + GhiChu + "' where IDChiTietPhieuXuat = " + IDChiTietPhieuXuat + "";
        bool table = Connect.Exec(sql);
        if (table)
        {
            if (IDHangHoa.Trim() == IDHangHoaCu.Trim())
            {

            }
            else
            {
                double GiaVon = MyStaticData.GetGiaVon(IDHangHoa);
                string query = " update ChiTietPhieuXuat set GiaVon=" + GiaVon.ToString() + " where IDChiTietPhieuXuat = " + IDChiTietPhieuXuat + "";
                bool rs = Connect.Exec(query);
            }
            Response.Write("True");
        }
        else
            Response.Write("False");

        // Response.Write(sql);


    }
    //
    private void SuaChiTietXuat()
    {
        string IDChiTietPhieuXuat = StaticData.ValidParameter(Request.QueryString["IDChiTietPhieuXuat"].Trim());
        DataTable table = Connect.GetTable("select * from ChiTietPhieuXuat where IDChiTietPhieuXuat = " + IDChiTietPhieuXuat + "");
        if (table.Rows.Count > 0)
        {

            string TenHangHoa = StaticData.getField("HangHoa", "TenHangHoa", "IDHangHoa", table.Rows[0]["IDHangHoa"].ToString().Trim());
            string SoLuong = "0";
            if (table.Rows[0]["SoLuong"].ToString().Trim() != "0")
            {
                double dg = double.Parse(table.Rows[0]["SoLuong"].ToString().Trim());
                SoLuong = dg.ToString("#,##").Replace(",", ".");
            }
            string DonGiaXuat = "0";
            if (table.Rows[0]["DonGiaXuat"].ToString().Trim() != "0")
            {
                double dgx = double.Parse(table.Rows[0]["DonGiaXuat"].ToString().Trim());
                DonGiaXuat = dgx.ToString("#,##").Replace(",", ".");
            }

            string GhiChu = table.Rows[0]["GhiChu"].ToString().Trim();

            string IDMauSac = StaticData.getField("HangHoa", "IDMauSac", "IDHangHoa", table.Rows[0]["IDHangHoa"].ToString().Trim());
            string TenMauSac = StaticData.getField("MauSac", "TenMauSac", "IDMauSac", IDMauSac);

            string IDSize = StaticData.getField("HangHoa", "IDSize", "IDHangHoa", table.Rows[0]["IDHangHoa"].ToString().Trim());
            string TenSize = StaticData.getField("Size", "TenSize", "IDSize", IDSize);
            //string IDChiTietPhieuXuat = table.Rows[0]["IDChiTietPhieuXuat"].ToString().Trim();



            string rs = "['" + TenHangHoa + "','" + TenMauSac + "','" + TenSize + "','" + SoLuong + "','" + DonGiaXuat + "','" + IDChiTietPhieuXuat + "','" + GhiChu + "','" + table.Rows[0]["IDHangHoa"].ToString().Trim() + "']";
            Response.Write(rs);

        }
        else
        {
            Response.Write("False");
        }



    }
    //
    private void ThemChiTietPhieuXuat()
    {
        string IDPhieuXuat = StaticData.ValidParameter(Request.QueryString["IDPhieuXuat"].Trim());
        string IDHangHoa = StaticData.ValidParameter(Request.QueryString["IDHangHoa"].Trim());

        string SoLuong = StaticData.ValidParameter(Request.QueryString["SoLuong"].Trim());
        string DonGiaXuat = StaticData.ValidParameter(Request.QueryString["DonGiaXuat"].Trim());

        string GhiChu = StaticData.ValidParameter(Request.QueryString["GhiChu"].Trim());
        double GiaVon = MyStaticData.GetGiaVon(IDHangHoa);
        string sql = "";

        sql += "insert into ChiTietPhieuXuat values (" + IDPhieuXuat + "," + IDHangHoa + "," + SoLuong + "," + DonGiaXuat + "," + GiaVon.ToString() + ",N'" + GhiChu + "')";
        bool table = Connect.Exec(sql);
        if (table)
            Response.Write("True");
        else
            Response.Write("False");
    }
    //
    private void LoadLenGiaTheoKhachHang()
    {
        string IDKhachHang = StaticData.ValidParameter(Request.QueryString["IDKhachHang"].Trim());
        string IDHangHoa = StaticData.ValidParameter(Request.QueryString["IDHangHoa"].Trim());
        string IDLoaiHangHoa = StaticData.getField("HangHoa", "IDLoaiHangHoa", "IDHangHoa", IDHangHoa);
        string sql = "select Gia from ChiTietGiaTheoKhach where IDKhachHang = " + IDKhachHang + " and IDHangHoa = " + IDLoaiHangHoa + "";
        DataTable a = Connect.GetTable(sql);
        if (a.Rows.Count <= 0)
        {
            Response.Write("False");
        }
        else
        {
            string Gia = a.Rows[0]["Gia"].ToString();
            double GiaBan = double.Parse(Gia);
            string rs = GiaBan.ToString("#,##").Replace(",", ".");
            Response.Write(rs);
        }

    }
    //
    private void LoadLenKhachHangAutocomplete()
    {

        string sql = "";
        sql += "select KhachHang.IDKhachHang,KhachHang.MaKhachHang,KhachHang.TenKhachHang,PhongBan.IDPhongBan,PhongBan.TenPhongBan,CuaHang.IDCuaHang,CuaHang.TenCuaHang from KhachHang left join PhongBan on KhachHang.IDKhachHang = PhongBan.IDKhachHang left join CuaHang on CuaHang.IDPhongBan = PhongBan.IDPhongBan";
        //sql += "  select IDKhachHang,MaKhachHang,TenKhachHang from KhachHang";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";
        /*listgAutocomplete += "{";
        listgAutocomplete += "value: 'Chọn',";
        listgAutocomplete += "label: 'Chọn',";
        listgAutocomplete += "id: '0'";
        listgAutocomplete += "},";*/
        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";
            listgAutocomplete += "show: '" + table.Rows[i]["TenKhachHang"].ToString() + "',";
            listgAutocomplete += "value: '" + table.Rows[i]["TenKhachHang"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["TenKhachHang"].ToString() + "-" + table.Rows[i]["TenPhongBan"].ToString() + "-" + table.Rows[i]["TenCuaHang"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["IDKhachHang"].ToString() + "',";
            listgAutocomplete += "tenPhongBan: '" + table.Rows[i]["TenPhongBan"].ToString() + "',";
            listgAutocomplete += "tenCuaHang: '" + table.Rows[i]["TenCuaHang"].ToString() + "',";
            listgAutocomplete += "idPhongBan: '" + table.Rows[i]["IDPhongBan"].ToString() + "',";
            listgAutocomplete += "idCuaHang: '" + table.Rows[i]["IDCuaHang"].ToString() + "',";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }
    //
    private void LoadChiTietPhieuXuat()
    {
        string IDPhieuXuat = StaticData.ValidParameter(Request.QueryString["IDPhieuXuat"].Trim());
        string sql = "";

        sql += "  select * from ChiTietPhieuXuat where ChiTietPhieuXuat.IDPhieuXuat = " + IDPhieuXuat + " order by ChiTietPhieuXuat.IDChiTietPhieuXuat asc";
        DataTable table = Connect.GetTable(sql);
        string html = @"<table class='table table-bordered table-striped' >
                                <tr>
                                    <th class='th'>
                                        STT
                                    </th>
                                 <th class='th'>
                                    Tên hàng hóa
                                    </th>
<th class='th'>
                                   Size
                                    </th>
<th class='th'>
                                  Màu
                                    </th>

<th class='th'>
                                  ĐV Tính
                                    </th>
                                <th class='th'>
                                   Số lượng
                                    </th>
                                    <th class='th'>
                                  Đơn giá
                                    </th>

                                    <th class='th'>
                                      Thành tiền
                                    </th>
                                   
                                 
                                <th class='th' style='width:15px;'>
                                      
                                    </th>
 
                                </tr>";
        double Tong = 0;
        for (int i = 0; i < table.Rows.Count; i++)
        {
            html += "       <tr>";
            int stt = i + 1;

            html += "       <td>" + stt + "</td>";

            html += "       <td>" + StaticData.getField("LoaiHangHoa", "TenLoaiHangHoa", "IDLoaiHangHoa", StaticData.getField("HangHoa", "IDLoaiHangHoa", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString().Trim())) + "-" + StaticData.getField("LoaiHangHoa", "MaLoaiHangHoa", "IDLoaiHangHoa", StaticData.getField("HangHoa", "IDLoaiHangHoa", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString().Trim())) + "</td>";
            // html += "       <td>" + StaticData.getField("LoaiHangHoa", "MaLoaiHangHoa", "IDLoaiHangHoa", StaticData.getField("HangHoa", "IDLoaiHangHoa", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString().Trim())) + "</td>";
            html += "       <td>" + StaticData.getField("Size", "TenSize", "IDSize", StaticData.getField("HangHoa", "IDSize", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString().Trim())) + "</td>";
            html += "       <td>" + StaticData.getField("MauSac", "TenMauSac", "IDMauSac", StaticData.getField("HangHoa", "IDMauSac", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString().Trim())) + "</td>";

            html += "<td>" + StaticData.getField("DonViTinh", "TenDonViTinh", "idDonViTinh", StaticData.getField("LoaiHangHoa", "IDDonViTinh", "IDLoaiHangHoa", StaticData.getField("HangHoa", "IDLoaiHangHoa", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString()))) + "</td>";

            if (table.Rows[i]["SoLuong"].ToString().Trim() == "0")
                html += "       <td><input onkeypress='ChuyenSo(" + table.Rows[i]["IDChiTietPhieuXuat"].ToString().Trim() + ");' onkeyup='ChuyenSo(" + table.Rows[i]["IDChiTietPhieuXuat"].ToString().Trim() + ");' disabled='disabled' type='text' id='sl_" + table.Rows[i]["IDChiTietPhieuXuat"].ToString().Trim() + "' style='width:55px;' value='0' /><a style='cursor:pointer;' onclick='SuaSoLuongChiTietPhieuXuat(" + table.Rows[i]["IDChiTietPhieuXuat"].ToString().Trim() + ");'>&nbsp;<label id='hinh_" + table.Rows[i]["IDChiTietPhieuXuat"].ToString().Trim() + "'><img  class='imgCommand' src='../Images/Edit.png'   /></label></a></td>";
            else html += "<td><input onkeypress='ChuyenSo(" + table.Rows[i]["IDChiTietPhieuXuat"].ToString().Trim() + ");' onkeyup='ChuyenSo(" + table.Rows[i]["IDChiTietPhieuXuat"].ToString().Trim() + ");' disabled='disabled' type='text' id='sl_" + table.Rows[i]["IDChiTietPhieuXuat"].ToString().Trim() + "' style='width:55px;' value='" + double.Parse(table.Rows[i]["SoLuong"].ToString()).ToString("#,##").Replace(",", ".") + "' /><a style='cursor:pointer;' onclick='SuaSoLuongChiTietPhieuXuat(" + table.Rows[i]["IDChiTietPhieuXuat"].ToString().Trim() + ");'>&nbsp;<label id='hinh_" + table.Rows[i]["IDChiTietPhieuXuat"].ToString().Trim() + "'><img  class='imgCommand' src='../Images/Edit.png'   /></label></a></td>";
            if (table.Rows[i]["DonGiaXuat"].ToString().Trim() == "0")
                html += "       <td>0</td>";
            else html += "<td>" + double.Parse(table.Rows[i]["DonGiaXuat"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";

            double thanhtien =
                double.Parse(table.Rows[i]["SoLuong"].ToString()) * double.Parse(table.Rows[i]["DonGiaXuat"].ToString());
            if (thanhtien != 0)
                html += "       <td>" + thanhtien.ToString("#,##").Replace(",", ".") + "</td>";
            else
                html += "       <td>0</td>";

            try
            {
                Tong += thanhtien;
            }
            catch
            {

            }
            //string SL = table.Rows[i]["GhiChu"].ToString();

            //html += "       <td>" + SL + "</td>";


            //  html += "<td style='text-align:center;font-size: 100%;'><a style='cursor:pointer;' onclick='SuaChiTietXuat(\"" + table.Rows[i]["IDChiTietPhieuXuat"].ToString().Trim() + "\");'><img title='Sửa' class='imgCommand' src='../Images/edit.png' onclick='SuaChiTietXuat(\"" + table.Rows[i]["IDChiTietPhieuXuat"].ToString().Trim() + "\");' />  </a></td>";

            html += "<td style='text-align:center;font-size: 100%;'><a style='cursor:pointer;' onclick='DeleteChiTietPhieuXuat(\"" + table.Rows[i]["IDChiTietPhieuXuat"].ToString() + "\")'><img title='Xóa' class='imgCommand' src='../Images/delete.png'  /></a></td>";
            html += "       </tr>";

        }
        html += "  <tr style='background-color:lightgreen;'>";
        html += " <td colspan='7' style='text-align:right;'><b>Tổng cộng</b> </td>";
        html += " <td ><b>" + Tong.ToString("#,##").Replace(",", ".") + "</b> </td>";
        html += " <td>&nbsp;</td> ";
        html += "  </tr>";
        html += "  </table>";
        Response.Write(html);
    }
    //
    private void DeletePhieuNhap()
    {
        string idNguoiDung = StaticData.ValidParameter(Request.QueryString["IDPhieuNhap"].Trim());
        string MaPhieuNhap = StaticData.getField("PhieuNhap", "MaPhieuNhap", "IDPhieuNhap", StaticData.ValidParameter(Request.QueryString["IDPhieuNhap"].Trim()));
        string sql = "DELETE FROM [ChiTietPhieuNhap] WHERE [IDPhieuNhap] = '" + idNguoiDung + "'";

        bool kt = Connect.Exec(sql);
        if (kt)
        {
            string sql21 = "insert into BangLog(TaiKhoan,ThaoTac,NgayGio) values (N'" + Request.Cookies["BanSiQuanAo_Login"].Value.Trim() + "',N'Xóa hết phiếu nhập hàng " + MaPhieuNhap + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "')";
            bool kq21 = Connect.Exec(sql21);

            string sql2 = "delete from PhieuNhap where IDPhieuNhap=" + idNguoiDung;
            bool ktDelete = Connect.Exec(sql2);

            if (ktDelete)
                Response.Write("True");
            else
                Response.Write("False");
        }
        else
        {
            Response.Write("False");
        }
    }
    private void DeleteChiTietPhieuNhap()
    {
        string idNguoiDung = StaticData.ValidParameter(Request.QueryString["IDChiTietPhieuNhap"].Trim());
        DataTable getIDHangHoa = Connect.GetTable("select IDHangHoa from ChiTietPhieuNhap where IDChiTietPhieuNhap=" + idNguoiDung);
        string IDHangHoa = getIDHangHoa.Rows[0]["IDHangHoa"].ToString().Trim();
        string MaPhieuNhap = StaticData.getField("PhieuNhap", "MaPhieuNhap", "IDPhieuNhap", StaticData.getField("ChiTietPhieuNhap", "IDPhieuNhap", "IDChiTietPhieuNhap", idNguoiDung));

        string sql = "delete from ChiTietPhieuNhap where IDChiTietPhieuNhap=" + idNguoiDung;
        try
        {
            bool ktDelete = Connect.Exec(sql);

            if (ktDelete)
            {

                DataTable TinhLaiBQGQ = Connect.GetTable("SELECT isnull((ISNULL(sum(SoLuong*DonGiaNhap),0)/ISNULL(sum(SoLuong),0)),0) as 'bqgq' FROM ChiTietPhieuNhap where IDHangHoa=" + IDHangHoa);
                DataTable table2 = Connect.GetTable("SELECT * FROM ChiTietPhieuXuat where IDHangHoa=" + IDHangHoa);
                double BQGQ = double.Parse(TinhLaiBQGQ.Rows[0]["bqgq"].ToString().Trim());
                if (table2.Rows.Count > 0)
                {
                    for (int i = 0; i < table2.Rows.Count; i++)
                    {
                        double SL = double.Parse(table2.Rows[i]["SoLuong"].ToString().Trim());
                        double DGX = double.Parse(table2.Rows[i]["DonGiaXuat"].ToString().Trim());
                        double LN = (DGX * SL) - (SL * BQGQ);
                        string query = "update ChiTietPhieuXuat set LoiNhuan = " + LN + " where IDChiTietPhieuXuat=" + table2.Rows[i]["IDChiTietPhieuXuat"].ToString().Trim() + "";
                        bool rs = Connect.Exec(query);
                    }
                }

                string sql2 = "insert into BangLog(TaiKhoan,ThaoTac,NgayGio) values (N'" + Request.Cookies["BanSiQuanAo_Login"].Value.Trim() + "',N'Xóa Chi tiết phiếu nhập hàng " + MaPhieuNhap + " ','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "')";
                bool kq2 = Connect.Exec(sql2);

                Response.Write("True");

            }
            else
                Response.Write("False");
        }
        catch
        {
            Response.Write("False");
        }
    }
    //
    private void SuaChiTietPhieuNhap()
    {
        string IDHangHoa = StaticData.ValidParameter(Request.QueryString["IDHangHoa"].Trim());
        string IDPhieuNhap = StaticData.ValidParameter(Request.QueryString["IDPhieuNhap"].Trim());
        string SoLuong = StaticData.ValidParameter(Request.QueryString["SoLuong"].Trim());
        string DonGia = StaticData.ValidParameter(Request.QueryString["DonGia"].Trim());

        string GhiChu = StaticData.ValidParameter(Request.QueryString["GhiChu"].Trim());

        string IDChiTietPhieuNhap = StaticData.ValidParameter(Request.QueryString["IDChiTietPhieuNhap"].Trim());
        //string html = IDHangHoa + "-" + IDPhieuNhap + "-" + SoLuong + "-" + DonGia + "-" + HinhThuc + "-" + NgayNhapChiTiet + "-" + GhiChu;
        string sql = "";


        sql += "update ChiTietPhieuNhap set IDHangHoa=" + IDHangHoa + ",IDPhieuNhap=" + IDPhieuNhap + ",SoLuong=" + SoLuong + ",DonGiaNhap=" + DonGia + ",GhiChu=N'" + GhiChu + "' where IDChiTietPhieuNhap = " + IDChiTietPhieuNhap + "";
        bool table = Connect.Exec(sql);
        if (table)
        {
            // DataTable TinhLaiBQGQ = Connect.GetTable("SELECT ISNULL(sum(SoLuong*DonGiaNhap),0)/ISNULL(sum(SoLuong),0) as 'bqgq' FROM ChiTietPhieuNhap where IDHangHoa=" + IDHangHoa);
            //// DataTable table2 = Connect.GetTable("SELECT * FROM ChiTietPhieuXuat where IDHangHoa=" + IDHangHoa);
            // double BQGQ = double.Parse(TinhLaiBQGQ.Rows[0]["bqgq"].ToString().Trim());
            // DataTable mang = Connect.GetTable("select * from ChiTietPhieuXuat where IDHangHoa=" + IDHangHoa);
            // if(mang.Rows.Count > 0)
            // {
            //     for(int i = 0;i<mang.Rows.Count;i++)
            //     {
            //         double ThanhTien = double.Parse(mang.Rows[i]["DonGiaXuat"].ToString()) * double.Parse(mang.Rows[i]["SoLuong"].ToString());
            //         double giaNhapKho = double.Parse(mang.Rows[i]["SoLuong"].ToString()) * BQGQ;
            //         double LoiNhuan = ThanhTien - giaNhapKho;
            //         string query = "update ChiTietPhieuXuat set LoiNhuan=" + LoiNhuan.ToString() + " where IDChiTietPhieuXuat = " + mang.Rows[i]["IDChiTietPhieuXuat"].ToString() + "";
            //         bool rs = Connect.Exec(query);
            //     }
            // }
            Response.Write("True");

        }
        else
        {
            Response.Write("False");
        }

        //Response.Write(sql);


    }
    //
    private void SuaChiTietNhap()
    {
        string IDChiTietPhieuNhap = StaticData.ValidParameter(Request.QueryString["IDChiTietPhieuNhap"].Trim());
        DataTable table = Connect.GetTable("select * from ChiTietPhieuNhap where IDChiTietPhieuNhap = " + IDChiTietPhieuNhap);
        string TenHangHoa = StaticData.getField("HangHoa", "TenHangHoa", "IDHangHoa", table.Rows[0]["IDHangHoa"].ToString());
        string SoLuong = "0";
        double SL = double.Parse(table.Rows[0]["SoLuong"].ToString());
        if (SL != 0)
            SoLuong = SL.ToString("#,##").Replace(",", ".");

        string DonGiaNhap = "0";
        double DG = double.Parse(table.Rows[0]["DonGiaNhap"].ToString());
        if (DG != 0)
            DonGiaNhap = DG.ToString("#,##").Replace(",", ".");
        string GhiChu = table.Rows[0]["GhiChu"].ToString();

        string IDMauSac = StaticData.getField("HangHoa", "IDMauSac", "IDHangHoa", table.Rows[0]["IDHangHoa"].ToString());
        string TenMauSac = StaticData.getField("MauSac", "TenMauSac", "IDMauSac", IDMauSac);
        string IDSize = StaticData.getField("HangHoa", "IDSize", "IDHangHoa", table.Rows[0]["IDHangHoa"].ToString());
        string TenSize = StaticData.getField("Size", "TenSize", "IDSize", IDSize);



        string html = "['" + TenHangHoa + "','" + SoLuong + "','" + DonGiaNhap + "','" + GhiChu + "','" + table.Rows[0]["IDHangHoa"].ToString() + "','" + IDChiTietPhieuNhap + "','" + TenMauSac + "','" + TenSize + "']";
        Response.Write(html);
    }
    private void ThemChiTietPhieuNhap()
    {
        string IDHangHoa = StaticData.ValidParameter(Request.QueryString["IDHangHoa"].Trim());
        string IDPhieuNhap = StaticData.ValidParameter(Request.QueryString["IDPhieuNhap"].Trim());
        string SoLuong = StaticData.ValidParameter(Request.QueryString["SoLuong"].Trim());
        string DonGia = StaticData.ValidParameter(Request.QueryString["DonGia"].Trim());

        string GhiChu = StaticData.ValidParameter(Request.QueryString["GhiChu"].Trim());

        string sql = "";

        sql += "insert into ChiTietPhieuNhap values(" + IDHangHoa + "," + IDPhieuNhap + "," + SoLuong + "," + DonGia + ",N'" + GhiChu + "',null)";
        bool table = Connect.Exec(sql);
        if (table)
        {
            //DataTable TinhLaiBQGQ = Connect.GetTable("SELECT ISNULL(sum(SoLuong*DonGiaNhap),0)/ISNULL(sum(SoLuong),0) as 'bqgq' FROM ChiTietPhieuNhap where IDHangHoa=" + IDHangHoa);
            //DataTable table2 = Connect.GetTable("SELECT * FROM ChiTietPhieuXuat where IDHangHoa=" + IDHangHoa);
            //double BQGQ = double.Parse(TinhLaiBQGQ.Rows[0]["bqgq"].ToString().Trim());
            //if(table2.Rows.Count > 0)
            //{
            //    for(int i = 0 ;i < table2.Rows.Count ; i++)
            //    {
            //        double SL = double.Parse(table2.Rows[i]["SoLuong"].ToString().Trim());
            //        double DGX = double.Parse(table2.Rows[i]["DonGiaXuat"].ToString().Trim());
            //        double LN = (DGX * SL) - (SL * BQGQ);
            //        string query  = "update ChiTietPhieuXuat set LoiNhuan = "+LN+" where IDChiTietPhieuXuat="+table2.Rows[i]["IDChiTietPhieuXuat"].ToString().Trim()+"";
            //        bool rs = Connect.Exec(query);
            //    }
            //}
            Response.Write("True");
        }
        else
            Response.Write("False");




    }
    private void TenNhaCCNhapAutocomplete()
    {

        string sql = "";

        sql += "SELECT [IDNhaCungCap],[MaNhaCungCap],[TenNhaCungCap],[SDT],[DiaChi],[GhiChu] FROM [CongTyVienLien].[dbo].[NhaCungCap]";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";
        /*listgAutocomplete += "{";
        listgAutocomplete += "value: 'Chọn',";
        listgAutocomplete += "label: 'Chọn',";
        listgAutocomplete += "id: '0'";
        listgAutocomplete += "},";*/
        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";
            listgAutocomplete += "show: '" + table.Rows[i]["TenNhaCungCap"].ToString() + "',";
            listgAutocomplete += "value: '" + table.Rows[i]["IDNhaCungCap"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["TenNhaCungCap"].ToString() + "-" + table.Rows[i]["MaNhaCungCap"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["MaNhaCungCap"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }

    //
    private void ABCAutocomplete()
    {

        string sql = "";

        sql += "  select IDHangHoa,MaHangHoa,TenHangHoa from HangHoa";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";
        /*listgAutocomplete += "{";
        listgAutocomplete += "value: 'Chọn',";
        listgAutocomplete += "label: 'Chọn',";
        listgAutocomplete += "id: '0'";
        listgAutocomplete += "},";*/
        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";
            listgAutocomplete += "value: '" + table.Rows[i]["TenHangHoa"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["TenHangHoa"].ToString() + "-" + table.Rows[i]["MaHangHoa"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["IDHangHoa"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }
    //
    private void LoadMa()
    {
        string idNguoiDung = StaticData.ValidParameter(Request.QueryString["MaHangHoa"].Trim());

        string sql = "select * from HangHoa where IDHangHoa=N'" + idNguoiDung + "' ";
        DataTable a = Connect.GetTable(sql);
        string DonViTinh = StaticData.getField("Size", "TenSize", "IDSize", a.Rows[0]["IDSize"].ToString());
        string MauSac = StaticData.getField("MauSac", "TenMauSac", "IDMauSac", a.Rows[0]["IDMauSac"].ToString());

        string Gia = StaticData.getField("LoaiHangHoa", "Gia", "IDLoaiHangHoa", a.Rows[0]["IDLoaiHangHoa"].ToString());
        string DonGiaNhap = "0";
        if (Gia.Trim() != "0")
        {
            DonGiaNhap = double.Parse(Gia).ToString("#,##").Replace(",", ".");
        }
        string rs2 = "['" + DonViTinh + "','" + MauSac + "','" + DonGiaNhap + "']";
        Response.Write(rs2);

    }
    private void DeleteKhachHangSanPham()
    {
        string idNguoiDung = StaticData.ValidParameter(Request.QueryString["IDChiTietGiaTheoKhach"].Trim());

        string sql = "delete from ChiTietGiaTheoKhach where IDChiTietGiaTheoKhach=" + idNguoiDung;
        bool ktDelete = Connect.Exec(sql);

        if (ktDelete)
            Response.Write("True");
        else
            Response.Write("False");
    }
    //
    private void LoadChiTietPhieuNhap()
    {
        string IDPhieuNhap = StaticData.ValidParameter(Request.QueryString["IDPhieuNhap"].Trim());
        string sql = "";

        sql += "select * from ChiTietPhieuNhap where IDPhieuNhap = " + IDPhieuNhap + " order by ChiTietPhieuNhap.IDChiTietPhieuNhap asc";
        DataTable table = Connect.GetTable(sql);
        string html = @"<table class='table table-bordered table-striped' >
                                <tr>
                                    <th class='th'>
                                        STT
                                    </th>
                                   <th class='th'> Hàng hóa</th>
                                    <th class='th'> Size</th>
                                    <th class='th'> Màu</th>
                                    <th class='th'>
                                      Số lượng
                                    </th>
                                    <th class='th'>
                                       Đơn giá nhập
                                    </th>
                                <th class='th'>
                                      Thành tiền
                                    </th>
                                       <th class='th' >
                                    </th>
                                </tr> ";
        double Tong = 0;
        for (int i = 0; i < table.Rows.Count; i++)
        {
            html += "       <tr>";
            int stt = i + 1;

            html += "       <td>" + stt + "</td>";

            html += "       <td>" + StaticData.getField("LoaiHangHoa", "TenLoaiHangHoa", "IDLoaiHangHoa", StaticData.getField("HangHoa", "IDLoaiHangHoa", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString().Trim())) + "-" + StaticData.getField("LoaiHangHoa", "MaLoaiHangHoa", "IDLoaiHangHoa", StaticData.getField("HangHoa", "IDLoaiHangHoa", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString().Trim())) + "</td>";
            html += "       <td>" + StaticData.getField("Size", "TenSize", "IDSize", StaticData.getField("HangHoa", "IDSize", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString().Trim())) + "</td>";
            html += "       <td>" + StaticData.getField("MauSac", "TenMauSac", "IDMauSac", StaticData.getField("HangHoa", "IDMauSac", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString().Trim())) + "</td>";
            if (table.Rows[i]["SoLuong"].ToString().Trim() != "0")
                html += "<td><input onkeypress='ChuyenSo(" + table.Rows[i]["IDChiTietPhieuNhap"].ToString().Trim() + ");' onkeyup='ChuyenSo(" + table.Rows[i]["IDChiTietPhieuNhap"].ToString().Trim() + ");' disabled='disabled' type='text' id='sl_" + table.Rows[i]["IDChiTietPhieuNhap"].ToString().Trim() + "' value='" + double.Parse(table.Rows[i]["SoLuong"].ToString()).ToString("#,##").Replace(",", ".") + "' /><a style='cursor:pointer;' onclick='SuaSoLuongChiTietPhieuNhap(" + table.Rows[i]["IDChiTietPhieuNhap"].ToString().Trim() + ");'>&nbsp;<label id='hinh_" + table.Rows[i]["IDChiTietPhieuNhap"].ToString().Trim() + "'><img  class='imgCommand' src='../Images/Edit.png'   /></label></a></td>";
            else html += "<td><input onkeypress='ChuyenSo(" + table.Rows[i]["IDChiTietPhieuNhap"].ToString().Trim() + ");' onkeyup='ChuyenSo(" + table.Rows[i]["IDChiTietPhieuNhap"].ToString().Trim() + ");' disabled='disabled' type='text' id='sl_" + table.Rows[i]["IDChiTietPhieuNhap"].ToString().Trim() + "' value='" + table.Rows[i]["SoLuong"].ToString() + "' /><a style='cursor:pointer;' onclick='SuaSoLuongChiTietPhieuNhap(" + table.Rows[i]["IDChiTietPhieuNhap"].ToString().Trim() + ");'>&nbsp;<label  id='hinh_" + table.Rows[i]["IDChiTietPhieuNhap"].ToString().Trim() + "'><img  class='imgCommand' src='../Images/Edit.png'  /></label></a></td>";

            if (table.Rows[i]["DonGiaNhap"].ToString().Trim() != "0")
                html += "<td>" + double.Parse(table.Rows[i]["DonGiaNhap"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";
            else html += "<td>" + table.Rows[i]["DonGiaNhap"].ToString() + "</td>";

            string SL = table.Rows[i]["SoLuong"].ToString();
            double r = double.Parse(SL);

            double dg = double.Parse(table.Rows[i]["DonGiaNhap"].ToString());

            double thanhtien = r * dg;
            if (thanhtien == 0)
            {
                html += "<td>" + thanhtien.ToString() + "</td>";
            }
            else
            {
                html += "<td>" + thanhtien.ToString("#,##").Replace(",", ".") + "</td>";
            }

            // html += "       <td>" + table.Rows[i]["GhiChu"].ToString().Trim().Replace("\n", "<br />") + "</td>";
            try
            {
                Tong += thanhtien;
            }
            catch
            {

            }
            // html += "<td style='text-align:center;font-size: 100%;'><a style='cursor:pointer;' onclick='SuaChiTietNhap(\"" + table.Rows[i]["IDChiTietPhieuNhap"].ToString().Trim() + "\");'><img title='Sửa' class='imgCommand' src='../Images/edit.png' onclick='SuaChiTietNhap(\"" + table.Rows[i]["IDChiTietPhieuNhap"].ToString().Trim() + "\");' /></a></td>";

            html += "<td style='text-align:center;font-size: 100%;'><a style='cursor:pointer;' onclick='DeleteChiTietPhieuNhap(\"" + table.Rows[i]["IDChiTietPhieuNhap"].ToString() + "\")'><img title='Xóa' class='imgCommand' src='../Images/delete.png'  /></a></td>";
            html += "       </tr>";

        }
        html += "       <tr >";
        html += " <td colspan='6' style='text-align:right;background-color:lightgreen;'><b>Tổng cộng</b>     </td>";
        if (Tong == 0) html += " <td style='background-color:lightgreen;'><b>0</b>      </td>";
        else html += " <td style='background-color:lightgreen;'><b>" + Tong.ToString("#,##").Replace(",", ".") + "</b>      </td>";
        html += "<td style='background-color:lightgreen;'>&nbsp;</td>";
        html += "       </tr>";
        html += "  </table>";
        Response.Write(html);
    }
    //
    private void TenSanPhamTheoKhachAutocomplete()
    {

        string sql = "";

        sql += "  select IDLoaiHangHoa,TenLoaiHangHoa,MaLoaiHangHoa from LoaiHangHoa";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";
        /*listgAutocomplete += "{";
        listgAutocomplete += "value: 'Chọn',";
        listgAutocomplete += "label: 'Chọn',";
        listgAutocomplete += "id: '0'";
        listgAutocomplete += "},";*/
        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";
            listgAutocomplete += "value: '" + table.Rows[i]["TenLoaiHangHoa"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["TenLoaiHangHoa"].ToString() + "-" + table.Rows[i]["mALoaiHangHoa"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["IDLoaiHangHoa"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }
    private void TenKhachTheoSanPhamAutocomplete()
    {

        string sql = "";

        sql += "  select TenKhachHang,IDKhachHang,MaKhachHang from KhachHang where IDKhachHang !='10108'";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";
        /*listgAutocomplete += "{";
        listgAutocomplete += "value: 'Chọn',";
        listgAutocomplete += "label: 'Chọn',";
        listgAutocomplete += "id: '0'";
        listgAutocomplete += "},";*/
        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";
            listgAutocomplete += "value: '" + table.Rows[i]["TenKhachHang"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["TenKhachHang"].ToString() + "-" + table.Rows[i]["MaKhachHang"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["IDKhachHang"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }
    private void DeleteHangHoa()
    {
        string idNguoiDung = StaticData.ValidParameter(Request.QueryString["IDHangHoa"].Trim());

        string sql = "delete from HangHoa where IDHangHoa=" + idNguoiDung;
        bool ktDelete = Connect.Exec(sql);

        if (ktDelete)
            Response.Write("True");
        else
            Response.Write("False");
    }
    private void MaSanPhamAutocomplete()
    {

        string sql = "";

        sql += "  select MaHangHoa,IDHangHoa from HangHoa";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";
        /*listgAutocomplete += "{";
        listgAutocomplete += "value: 'Chọn',";
        listgAutocomplete += "label: 'Chọn',";
        listgAutocomplete += "id: '0'";
        listgAutocomplete += "},";*/
        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";
            listgAutocomplete += "value: '" + table.Rows[i]["MaHangHoa"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["MaHangHoa"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["IDHangHoa"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }

    private void TenSanPhamAutocomplete()
    {

        string sql = "";

        sql += "  select IDHangHoa,MaHangHoa,TenHangHoa from HangHoa";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";
        /*listgAutocomplete += "{";
        listgAutocomplete += "value: 'Chọn',";
        listgAutocomplete += "label: 'Chọn',";
        listgAutocomplete += "id: '0'";
        listgAutocomplete += "},";*/
        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";
            listgAutocomplete += "value: '" + table.Rows[i]["TenHangHoa"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["TenHangHoa"].ToString() + "-" + table.Rows[i]["MaHangHoa"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["IDHangHoa"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }
    private void DeleteKhachHang()
    {
        string idNguoiDung = StaticData.ValidParameter(Request.QueryString["IDKhachHang"].Trim());

        string sql = "delete from KhachHang where IDKhachHang=" + idNguoiDung;
        bool ktDelete = Connect.Exec(sql);

        if (ktDelete)
            Response.Write("True");
        else
            Response.Write("False");
    }
    private void TenKhachAutocomplete()
    {

        string sql = "";

        sql += "select * from KhachHang where IDKhachHang !='10108'";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";
        /*listgAutocomplete += "{";
        listgAutocomplete += "value: 'Chọn',";
        listgAutocomplete += "label: 'Chọn',";
        listgAutocomplete += "id: '0'";
        listgAutocomplete += "},";*/
        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";
            listgAutocomplete += "value: '" + table.Rows[i]["TenKhachHang"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["TenKhachHang"].ToString() + "-" + table.Rows[i]["MaKhachHang"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["IDKhachHang"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }
    private void SoDienThoaiAutocomplete()
    {

        string sql = "";

        sql += "select * from KhachHang";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";
        /*listgAutocomplete += "{";
        listgAutocomplete += "value: 'Chọn',";
        listgAutocomplete += "label: 'Chọn',";
        listgAutocomplete += "id: '0'";
        listgAutocomplete += "},";*/
        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";
            listgAutocomplete += "value: '" + table.Rows[i]["DienThoai"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["DienThoai"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["IDKhachHang"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }
    private void MaKhachAutocomplete()
    {

        string sql = "";

        sql += "select * from KhachHang";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";
        /*listgAutocomplete += "{";
        listgAutocomplete += "value: 'Chọn',";
        listgAutocomplete += "label: 'Chọn',";
        listgAutocomplete += "id: '0'";
        listgAutocomplete += "},";*/
        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";
            listgAutocomplete += "value: '" + table.Rows[i]["MaKhachHang"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["MaKhachHang"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["IDKhachHang"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }
    private void DeleteMauSac()
    {
        string idNguoiDung = StaticData.ValidParameter(Request.QueryString["IDMauSac"].Trim());

        string sql = "delete from MauSac where IDMauSac=" + idNguoiDung;
        bool ktDelete = Connect.Exec(sql);

        if (ktDelete)
            Response.Write("True");
        else
            Response.Write("False");
    }
    private void MauSacAutocomplete()
    {

        string sql = "";

        sql += "SELECT [IDMauSac] ,[MaMauSac],[TenMauSac],[GhiChu] FROM [CongTyVienLien].[dbo].[MauSac]";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";
        /*listgAutocomplete += "{";
        listgAutocomplete += "value: 'Chọn',";
        listgAutocomplete += "label: 'Chọn',";
        listgAutocomplete += "id: '0'";
        listgAutocomplete += "},";*/
        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";
            listgAutocomplete += "value: '" + table.Rows[i]["TenMauSac"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["TenMauSac"].ToString() + "-" + table.Rows[i]["MaMauSac"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["IDMauSac"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }
    private void DeleteDonViTinh()
    {
        string idNguoiDung = StaticData.ValidParameter(Request.QueryString["IDDonViTinh"].Trim());

        string sql = "delete from Size where IDSize=" + idNguoiDung;
        bool ktDelete = Connect.Exec(sql);

        if (ktDelete)
            Response.Write("True");
        else
            Response.Write("False");
    }
    //
    private void DonViTinhAutocomplete()
    {

        string sql = "";

        sql += "SELECT *  FROM DonViTinh";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";
        /*listgAutocomplete += "{";
        listgAutocomplete += "value: 'Chọn',";
        listgAutocomplete += "label: 'Chọn',";
        listgAutocomplete += "id: '0'";
        listgAutocomplete += "},";*/
        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";
            listgAutocomplete += "value: '" + table.Rows[i]["TenDonViTinh"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["TenDonViTinh"].ToString() + "-" + table.Rows[i]["MaDonViTinh"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["IDDonViTinh"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }
    //
    private void DeleteNhomHangHoa()
    {
        string idNguoiDung = StaticData.ValidParameter(Request.QueryString["IDNhomHangHoa"].Trim());

        string sql = "delete from NhomHangHoa where IDNhomHangHoa=" + idNguoiDung;
        bool ktDelete = Connect.Exec(sql);

        if (ktDelete)
            Response.Write("True");
        else
            Response.Write("False");
    }

    private void NhomHangHoaAutocomplete()
    {

        string sql = "";

        sql += "SELECT *  FROM NhomHangHoa";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";
        /*listgAutocomplete += "{";
        listgAutocomplete += "value: 'Chọn',";
        listgAutocomplete += "label: 'Chọn',";
        listgAutocomplete += "id: '0'";
        listgAutocomplete += "},";*/
        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";
            listgAutocomplete += "value: '" + table.Rows[i]["TenNhomHangHoa"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["TenNhomHangHoa"].ToString() + "-" + table.Rows[i]["MaNhomHangHoa"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["IDNhomHangHoa"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }
    private void DeleteChungLoaiHangHoa()
    {
        string idNguoiDung = StaticData.ValidParameter(Request.QueryString["idChungLoai"].Trim());

        string sql = "delete from ChungLoaiHangHoa where IDChungLoaiHangHoa=" + idNguoiDung;
        bool ktDelete = Connect.Exec(sql);

        if (ktDelete)
            Response.Write("True");
        else
            Response.Write("False");
    }
    private void TenChungLoaiAutocomplete()
    {

        string sql = "";

        sql += "SELECT *  FROM ChungLoaiHangHoa";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";
        /*listgAutocomplete += "{";
        listgAutocomplete += "value: 'Chọn',";
        listgAutocomplete += "label: 'Chọn',";
        listgAutocomplete += "id: '0'";
        listgAutocomplete += "},";*/
        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";
            listgAutocomplete += "value: '" + table.Rows[i]["TenChungLoaiHangHoa"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["TenChungLoaiHangHoa"].ToString() + "-" + table.Rows[i]["MaChungLoaiHangHoa"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["IDChungLoaiHangHoa"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }
    private void DeleteNhaCungCap()
    {
        string idNguoiDung = StaticData.ValidParameter(Request.QueryString["IDNhaCungCap"].Trim());

        string sql = "delete from NhaCungCap where IDNhaCungCap=" + idNguoiDung;
        bool ktDelete = Connect.Exec(sql);

        if (ktDelete)
            Response.Write("True");
        else
            Response.Write("False");
    }
    void DeletePhieuChia()
    {
        string IDPhieuChia = StaticData.ValidParameter(Request.QueryString["IDPhieuChia"].Trim());
        if (Connect.Exec("delete ChiTietPhieuXuat where idPhieuXuat=" + IDPhieuChia))
            if (Connect.Exec("delete PhieuXuat where idPhieuXuat=" + IDPhieuChia))
                Response.Write("True");
    }
    private void LoadSoDienThoaiAutocomplete()
    {

        string sql = "";

        sql += "SELECT SDT  FROM [NhaCungCap]";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";
        /*listgAutocomplete += "{";
        listgAutocomplete += "value: 'Chọn',";
        listgAutocomplete += "label: 'Chọn',";
        listgAutocomplete += "id: '0'";
        listgAutocomplete += "},";*/
        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";
            listgAutocomplete += "value: '" + table.Rows[i]["SDT"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["SDT"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["SDT"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }

    private void NhaCungCapAutocomplete()
    {

        string sql = "";

        sql += "SELECT *  FROM [NhaCungCap] ";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";
        /*listgAutocomplete += "{";
        listgAutocomplete += "value: 'Chọn',";
        listgAutocomplete += "label: 'Chọn',";
        listgAutocomplete += "id: '0'";
        listgAutocomplete += "},";*/
        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";
            listgAutocomplete += "value: '" + table.Rows[i]["TenNhaCungCap"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["TenNhaCungCap"].ToString() + "-" + table.Rows[i]["MaNhaCungCap"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["IDNhaCungCap"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }
    private void KhachHangAutocomplete()
    {

        string sql = "";

        sql += "SELECT *  FROM [KhachHang] ";
        DataTable table = Connect.GetTable(sql);
        string listgAutocomplete = "[";
        /*listgAutocomplete += "{";
        listgAutocomplete += "value: 'Chọn',";
        listgAutocomplete += "label: 'Chọn',";
        listgAutocomplete += "id: '0'";
        listgAutocomplete += "},";*/
        for (int i = 0; i < table.Rows.Count; i++)
        {
            listgAutocomplete += "{";
            listgAutocomplete += "value: '" + table.Rows[i]["tenKhachHang"].ToString() + "',";
            listgAutocomplete += "label: '" + table.Rows[i]["tenKhachHang"].ToString() + "-" + table.Rows[i]["MaKhachHang"].ToString() + "',";
            listgAutocomplete += "id: '" + table.Rows[i]["idKhachHang"].ToString() + "'";
            if (i == table.Rows.Count - 1)
                listgAutocomplete += "}";
            else
                listgAutocomplete += "},";
        }
        listgAutocomplete += "]";
        Response.Write(listgAutocomplete);
    }
    private void DangXuat2()
    {
        HttpCookie cookie_QuanLyNhapXuatHang_Login = new HttpCookie("BanSiQuanAo_Login", "");
        cookie_QuanLyNhapXuatHang_Login.Expires = DateTime.Now;
        Response.Cookies.Add(cookie_QuanLyNhapXuatHang_Login);

        HttpCookie cookie_QuanLyNhapXuatHang_Quyen = new HttpCookie("BanSiQuanAo_Quyen", "");
        cookie_QuanLyNhapXuatHang_Quyen.Expires = DateTime.Now;
        Response.Cookies.Add(cookie_QuanLyNhapXuatHang_Quyen);

        HttpCookie cookie_QuanLyNhapXuatHang_ID = new HttpCookie("BanSiQuanAo_ID", "");
        cookie_QuanLyNhapXuatHang_ID.Expires = DateTime.Now;
        Response.Cookies.Add(cookie_QuanLyNhapXuatHang_ID);

        Response.Write("True");
    }
    private void DangXuat()
    {
        // Session["QuanLyNhapXuatHang_Login"] = null;
        // Session["QuanLyNhapXuatHang_Quyen"] = null;

        HttpCookie cookie_QuanLyNhapXuatHang_Login = new HttpCookie("BanSiQuanAo_Login", "");
        cookie_QuanLyNhapXuatHang_Login.Expires = DateTime.Now;
        Response.Cookies.Add(cookie_QuanLyNhapXuatHang_Login);

        HttpCookie cookie_QuanLyNhapXuatHang_Quyen = new HttpCookie("BanSiQuanAo_Quyen", "");
        cookie_QuanLyNhapXuatHang_Quyen.Expires = DateTime.Now;
        Response.Cookies.Add(cookie_QuanLyNhapXuatHang_Quyen);

        HttpCookie cookie_QuanLyNhapXuatHang_ID = new HttpCookie("BanSiQuanAo_ID", "");
        cookie_QuanLyNhapXuatHang_ID.Expires = DateTime.Now;
        Response.Cookies.Add(cookie_QuanLyNhapXuatHang_ID);

        Response.Write("True");
    }
    private void DeleteAdmin()
    {
        string idAdmin = StaticData.ValidParameter(Request.QueryString["idAdmin"].Trim());
        string sql = "delete from tb_Admin where idAdmin='" + idAdmin + "'";
        bool ktDelete = Connect.Exec(sql);
        if (ktDelete)
            Response.Write("True");
        else
            Response.Write("False");
    }
    private void XuatPDFDonHang()
    {
        /*   string html = "";
           html += "<p style='text-align:center'>ĐƠN HÀNG</p>";
           Document document = new Document(PageSize.A5, 50, 50, 50, 50);

           PdfWriter.GetInstance(document, new FileStream("../DonHang.pdf", FileMode.Create));
           document.Open();

           iTextSharp.text.html.simpleparser.HTMLWorker hw = new iTextSharp.text.html.simpleparser.HTMLWorker(document);*/

        //BaseFont bfUni = BaseFont.CreateFont(Application.StartupPath + @"/ARIALUNI.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        //iTextSharp.text.Font fontUni = new iTextSharp.text.Font(bfUni, 12, iTextSharp.text.Font.NORMAL);
        //FontFactory.Register("/ARIALUNI.ttf");
        //StyleSheet styles = new StyleSheet();
        //styles.LoadTagStyle("body", "face", "Arial Unicode MS");
        //styles.LoadTagStyle("body", "encoding", BaseFont.IDENTITY_H);
        //hw.SetStyleSheet(styles);

        /* hw.Parse(new StringReader(html));
         document.Close();*/
    }
}