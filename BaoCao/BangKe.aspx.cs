using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

using System.Text;
public partial class BaoCao_BaoCaoTongHop : System.Web.UI.Page
{
    string pMaHangHoa = "";
    string pTenHangHoa = "";
    string pNgayDauKy = "";
    string pNgayCuoiKy = "";
    string pTuPhieu = "";
    string pDenPhieu = "";

    string txtFistPage = "1";
    string txtPage1 = "";
    string txtPage2 = "";
    string txtPage3 = "";
    string txtPage4 = "";
    string txtPage5 = "";
    string txtLastPage = "";
    int Page = 0;
    int MaxPage = 0;
    int PageSize2 = 20;
    protected void Page_Load(object sender, EventArgs e)
    {
       /* if (Session["QuanLyNhapXuatHang_Login"] != null && Session["QuanLyNhapXuatHang_Login"].ToString() != "")
        {
            if (Session["QuanLyNhapXuatHang_Quyen"] != null && Session["QuanLyNhapXuatHang_Quyen"].ToString() != "")
            {
                string Quyen = Session["QuanLyNhapXuatHang_Quyen"].ToString().Trim();
                if (Quyen.CompareTo("Admin") == 0)
                {

                }
                else
                {
                    Response.Redirect("../Home/Default.aspx");
                }
            }
        }*/
        if (Request.Cookies["QuanLyNhapXuatHang_Login"] != null && Request.Cookies["QuanLyNhapXuatHang_Login"].Value.Trim() != "")
        {
            if (Request.Cookies["QuanLyNhapXuatHang_Quyen"] != null && Request.Cookies["QuanLyNhapXuatHang_Quyen"].Value.Trim() != "")
            {
                string Quyen = Request.Cookies["QuanLyNhapXuatHang_Quyen"].Value.Trim();
                if (Quyen.CompareTo("Admin") == 0)
                {

                }
                else
                {
                    Response.Redirect("../Home/Default.aspx");
                }
            }
        }
        else
        {
            Response.Redirect("../Home/DangNhap.aspx");
        }
        try
        {
            Page = int.Parse(Request.QueryString["Page"].ToString());
        }
        catch
        {
            Page = 1;
        }
        if (!IsPostBack)
        {

            try
            {
                if (Request.QueryString["NgayDauKy"].Trim() != "")
                {
                    pNgayDauKy = StaticData.ValidParameter(Request.QueryString["NgayDauKy"].Trim());
                    txtNgayDauKy.Value = pNgayDauKy;
                }
            }
            catch { }
            try
            {
                if (Request.QueryString["NgayCuoiKy"].Trim() != "")
                {
                    pNgayCuoiKy = StaticData.ValidParameter(Request.QueryString["NgayCuoiKy"].Trim());
                    txtNgayCuoiKy.Value = pNgayCuoiKy;
                }
            }
            catch { }
            try
            {
                if (Request.QueryString["TuPhieu"].Trim() != "")
                {
                    pTuPhieu = StaticData.ValidParameter(Request.QueryString["TuPhieu"].Trim());
                    txtTuPhieu.Value = pTuPhieu;
                }
            }
            catch { }
            try
            {
                if (Request.QueryString["DenPhieu"].Trim() != "")
                {
                    pDenPhieu = StaticData.ValidParameter(Request.QueryString["DenPhieu"].Trim());
                    txtDenPhieu.Value = pDenPhieu;
                }
            }
            catch { }

            LoadDuAn();
        }
    }
    /* private void LoadQuyen()
     {
         string strSql = "select * from DuAn";
         slQuyen.DataSource = Connect.GetTable(strSql);
         slQuyen.DataTextField = "TenQuyen";
         slQuyen.DataValueField = "MaQuyen";
         slQuyen.DataBind();
         //slQuyen.Items.Add(new ListItem("-- Tất cả --", "0"));
         // slQuyen.Items.FindByText("-- Tất cả --").Selected = true;
     }*/
    #region paging
    private void SetPage()
    {
        string sql = "select count(*) from HangHoa,ChiTietPhieuXuat,PhieuXuat where HangHoa.IDHangHoa = ChiTietPhieuXuat.IDHangHoa and ChiTietPhieuXuat.IDPhieuXuat = PhieuXuat.IDPhieuXuat ";

      //  sql += "select HangHoa.MaHangHoa,HangHoa.TenHangHoa,ChiTietPhieuXuat.NgayXuatChiTiet,ChiTietPhieuNhap.NgayNhapChiTiet,ISNULL(SUM(ChiTietPhieuNhap.SoLuong),0) as 'SoLuongNhap',ISNULL(SUM(ChiTietPhieuNhap.DonGiaNhap),0) as 'DonGiaNhap',ISNULL(SUM(ChiTietPhieuXuat.SoLuong),0) as 'SoLuongXuat',ISNULL(SUM(ChiTietPhieuXuat.DonGiaXuat),0) as 'DonGiaXuat',ChiTietPhieuXuat.IDChiTietPhieuXuat from HangHoa ,ChiTietPhieuNhap,ChiTietPhieuXuat where ChiTietPhieuNhap.IDHangHoa = HangHoa.IDHangHoa and ChiTietPhieuXuat.IDHangHoa = HangHoa.IDHangHoa and ChiTietPhieuXuat.NgayXuatChiTiet is not null";
        if (pNgayDauKy != "")
            sql += " and ChiTietPhieuXuat.NgayXuatChiTiet >='" + StaticData.ConvertDDMMtoMMDD(pNgayDauKy) + " 00:00:00'";
        if (pNgayCuoiKy != "")
            sql += " and ChiTietPhieuXuat.NgayXuatChiTiet <='" + StaticData.ConvertDDMMtoMMDD(pNgayCuoiKy) + " 00:00:00'";
        if (pTuPhieu != "")
            sql += " and PhieuXuat.MaPhieuXuat >= N'" + pTuPhieu + "'";
        if (pDenPhieu != "")
            sql += " and PhieuXuat.MaPhieuXuat <= N'" + pDenPhieu + "'";
       /* if (pMaHangHoa != "")
            sql += " and MaHangHoa like N'%" + pMaHangHoa + "%'";*/
      //  sql += " group by HangHoa.MaHangHoa,HangHoa.TenHangHoa,ChiTietPhieuXuat.NgayXuatChiTiet,ChiTietPhieuNhap.NgayNhapChiTiet,ChiTietPhieuXuat.IDChiTietPhieuXuat";
        //sql += ") as tb1";
        DataTable tbTotalRows = Connect.GetTable(sql);
        //  Response.Write("<script>alert('"+tbTotalRows.Rows[0][0].ToString()+"')</script>");
        int TotalRows = int.Parse(tbTotalRows.Rows[0][0].ToString());
        if (TotalRows % PageSize2 == 0)
            MaxPage = TotalRows / PageSize2;
        else
            MaxPage = TotalRows / PageSize2 + 1;
        txtLastPage = MaxPage.ToString();
        if (Page == 1)
        {
            for (int i = 1; i <= MaxPage; i++)
            {
                if (i <= 5)
                {
                    switch (i)
                    {
                        case 1: txtPage1 = i.ToString(); break;
                        case 2: txtPage2 = i.ToString(); break;
                        case 3: txtPage3 = i.ToString(); break;
                        case 4: txtPage4 = i.ToString(); break;
                        case 5: txtPage5 = i.ToString(); break;
                    }
                }
                else
                    return;
            }
        }
        else
        {
            if (Page == 2)
            {
                for (int i = 1; i <= MaxPage; i++)
                {
                    if (i == 1)
                        txtPage1 = "1";
                    if (i <= 5)
                    {
                        switch (i)
                        {
                            case 2: txtPage2 = i.ToString(); break;
                            case 3: txtPage3 = i.ToString(); break;
                            case 4: txtPage4 = i.ToString(); break;
                            case 5: txtPage5 = i.ToString(); break;
                        }
                    }
                    else
                        return;
                }
            }
            else
            {
                int Cout = 1;
                if (Page <= MaxPage)
                {
                    for (int i = Page; i <= MaxPage; i++)
                    {
                        if (i == Page)
                        {
                            txtPage1 = (Page - 2).ToString();
                            txtPage2 = (Page - 1).ToString();
                        }
                        if (Cout <= 3)
                        {
                            if (i == Page)
                                txtPage3 = i.ToString();
                            if (i == (Page + 1))
                                txtPage4 = i.ToString();
                            if (i == (Page + 2))
                                txtPage5 = i.ToString();
                            Cout++;
                        }
                        else
                            return;
                    }
                }
                else
                {
                    //Page = MaxPage;
                    SetPage();
                }
            }
        }
    }
    #endregion
    private void LoadDuAn()
    {
        string sql = "";
        sql += @"select * from(select ROW_NUMBER() OVER(ORDER BY ChiTietPhieuXuat.NgayXuatChiTiet asc)AS RowNumber,HangHoa.IDHangHoa,ChiTietPhieuXuat.NgayXuatChiTiet,ChiTietPhieuXuat.IDChiTietPhieuXuat,HangHoa.MaHangHoa,HangHoa.TenHangHoa,ChiTietPhieuXuat.SoLuong,ChiTietPhieuXuat.DonGiaXuat,PhieuXuat.MaPhieuXuat from HangHoa,ChiTietPhieuXuat,PhieuXuat where HangHoa.IDHangHoa = ChiTietPhieuXuat.IDHangHoa and ChiTietPhieuXuat.IDPhieuXuat = PhieuXuat.IDPhieuXuat";
        if (pNgayDauKy != "")
            sql += " and ChiTietPhieuXuat.NgayXuatChiTiet >='" + StaticData.ConvertDDMMtoMMDD(pNgayDauKy) + " 00:00:00'";
        if (pNgayCuoiKy != "")
            sql += " and ChiTietPhieuXuat.NgayXuatChiTiet <='" + StaticData.ConvertDDMMtoMMDD(pNgayCuoiKy) + " 00:00:00'";
        if (pTuPhieu != "")
            sql += " and PhieuXuat.MaPhieuXuat >= N'" + pTuPhieu + "'";
        if (pDenPhieu != "")
            sql += " and PhieuXuat.MaPhieuXuat <= N'" + pDenPhieu + "'";
       // sql += "group by HangHoa.MaHangHoa,HangHoa.TenHangHoa,ChiTietPhieuXuat.NgayXuatChiTiet,ChiTietPhieuNhap.NgayNhapChiTiet,ChiTietPhieuXuat.IDChiTietPhieuXuat,HangHoa.IDHangHoa ";
        sql += "  ) as tb1";
        sql += " WHERE RowNumber BETWEEN (" + Page + " - 1) * " + PageSize2 + " + 1 AND (((" + Page + " - 1) * " + PageSize2 + " + 1) + " + PageSize2 + ") - 1";

        DataTable table = Connect.GetTable(sql);

        SetPage();

        string html = @" <table class='table table-bordered table-striped'>
                  <tr>
                     <th class='th'  style='text-align: center;'>
                       STT
                        </th>
                        <th class='th'  style='text-align: center;'>
                         DANH MỤC VPP
                        </th>
                       
                        <th class='th'  style='text-align: center;'>
                         ĐVT
                        </th>
 <th class='th'  style='text-align: center;'>
                         SỐ LƯỢNG
                        </th>
                         <th class='th'  style='text-align: center;'>
                         ĐƠN GIÁ
                        </th>

                        <th class='th'  style='text-align: center;'>
                          THÀNH TIỀN
                        </th>
                        <th class='th' style='text-align: center;'>
                        GHI CHÚ
                        </th>
                       
                    </tr>
                    
                   ";
        // double SoTienPhaiThu = 0;
        for (int i = 0; i < table.Rows.Count; i++)
        {
            html += "       <tr >";
            html += "       <td>" + (((Page - 1) * PageSize2) + i + 1).ToString() + "</td>";



            
            
            html += "       <td>" + table.Rows[i]["TenHangHoa"].ToString() + "</td>";
              html += "       <td>" +  StaticData.getField("DonViTinh", "TenDonViTinh", "IDDonViTinh", StaticData.getField("HangHoa", "IDDonViTinh", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString())) + "</td>";
              double a = double.Parse(table.Rows[i]["SoLuong"].ToString());
              html += "       <td style='text-align: center;'>" + a.ToString("#,##").Replace(",", ".") + "</td>";
            double a1 = double.Parse(table.Rows[i]["DonGiaXuat"].ToString());
            html += "       <td style='text-align: center;'> " + a1.ToString("#,##").Replace(",", ".") + "</td>";
        
               
          
            double Ton = a *a1;

            html += "       <td style='text-align: center;'>" + Ton.ToString("#,##").Replace(",", ".") + "</td>";
          
           // DataTable gc = Connect.GetTable("select GhiChu from ChiTietPhieuXuat where IDChiTietPhieuXuat=" + table.Rows[i]["IDChiTietPhieuXuat"].ToString() + "");
            html += "       <td>&nbsp;</td>";
            html+="     </tr>";

        }
        html += "   <tr>";
        html += "       <td colspan='9' class='footertable'>";
        string url = "BangKe.aspx?";
      if (pNgayDauKy != "")
            url += "NgayDauKy=" + pNgayDauKy + "&";
      if (pNgayCuoiKy != "")
          url += "NgayCuoiKy=" + pNgayCuoiKy + "&";
      if (pTuPhieu != "")
          url += "TuPhieu=" + pTuPhieu + "&";
      if (pDenPhieu != "")
          url += "DenPhieu=" + pDenPhieu + "&";
        url += "Page=";
        html += "           <a class='notepaging' id='page_fist' href='" + url + txtFistPage + "' /><<</a>";
        //Page 1
        if (txtPage1 != "")
        {
            if (Page.ToString() == txtPage1)
                html += "           <a id='page_1' class='notepagingactive' href='" + url + txtPage1 + "' />" + txtPage1 + "</a>";
            else
                html += "           <a id='page_1' class='notepaging' href='" + url + txtPage1 + "' />" + txtPage1 + "</a>";
        }
        else
        {
            html += "           <a id='page_1' class='notepagingnone' href='" + url + txtPage1 + "' />" + txtPage1 + "</a>";
        }
        //Page 2
        if (txtPage2 != "")
        {
            if (Page.ToString() == txtPage2)
                html += "           <a id='page_2' class='notepagingactive' href='" + url + txtPage2 + "' />" + txtPage2 + "</a>";
            else
                html += "           <a id='page_2' class='notepaging' href='" + url + txtPage2 + "' />" + txtPage2 + "</a>";
        }
        else
        {
            html += "           <a id='page_2' class='notepagingnone' href='" + url + txtPage2 + "' />" + txtPage2 + "</a>";
        }
        //Page 3
        if (txtPage3 != "")
        {
            if (Page.ToString() == txtPage3)
                html += "           <a id='page_3' class='notepagingactive' href='" + url + txtPage3 + "' />" + txtPage3 + "</a>";
            else
                html += "           <a id='page_3' class='notepaging' href='" + url + txtPage3 + "' />" + txtPage3 + "</a>";
        }
        else
        {
            html += "           <a id='page_3' class='notepagingnone' href='" + url + txtPage3 + "' />" + txtPage3 + "</a>";
        }
        //Page 4
        if (txtPage4 != "")
        {
            if (Page.ToString() == txtPage4)
                html += "           <a id='page_4' class='notepagingactive' href='" + url + txtPage4 + "' />" + txtPage4 + "</a>";
            else
                html += "           <a id='page_4' class='notepaging' href='" + url + txtPage4 + "' />" + txtPage4 + "</a>";
        }
        else
        {
            html += "           <a id='page_4' class='notepagingnone' href='" + url + txtPage4 + "' />" + txtPage4 + "</a>";
        }
        //Page 5
        if (txtPage5 != "")
        {
            if (Page.ToString() == txtPage5)
                html += "           <a id='page_5' class='notepagingactive' href='" + url + txtPage5 + "' />" + txtPage5 + "</a>";
            else
                html += "           <a id='page_5' class='notepaging' href='" + url + txtPage5 + "' />" + txtPage5 + "</a>";
        }
        else
        {
            html += "           <a id='page_5' class='notepagingnone' href='" + url + txtPage5 + "' />" + txtPage5 + "</a>";
        }

        html += "           <a id='page_last' class='notepaging' href='" + url + txtLastPage + "' />>></a>";
        html += "   </td>";

        html += "</tr>";

        html += "     </table>";

        dvNguoiDung.InnerHtml = html;
    }
    protected void btTimKiem_Click(object sender, EventArgs e)
    {
        string NgayDauKy = txtNgayDauKy.Value.Trim();
        string NgayCuoiKy = txtNgayCuoiKy.Value.Trim();
        string TuPhieu = txtTuPhieu.Value.Trim();
        string DenPhieu = txtDenPhieu.Value.Trim();
        string url = "BangKe.aspx?";
        if (NgayDauKy != "")
            url += "NgayDauKy=" + NgayDauKy + "&";
        if (NgayCuoiKy != "")
            url += "NgayCuoiKy=" + NgayCuoiKy + "&";
        if (TuPhieu != "")
            url += "TuPhieu=" + TuPhieu + "&";
        if (DenPhieu != "")
            url += "DenPhieu=" + DenPhieu + "&";
        Response.Redirect(url);
    }
    protected void btTatCa_Click(object sender, EventArgs e)
    {
        DataTable Muc = Connect.GetTable("select distinct Muc from HangHoa order by Muc desc");

        string sql = "";
        sql += @"select * from(select ROW_NUMBER() OVER(ORDER BY ChiTietPhieuXuat.NgayXuatChiTiet asc)AS RowNumber,HangHoa.Muc,HangHoa.IDHangHoa,ChiTietPhieuXuat.NgayXuatChiTiet,ChiTietPhieuXuat.IDChiTietPhieuXuat,HangHoa.MaHangHoa,HangHoa.TenHangHoa,ChiTietPhieuXuat.SoLuong,ChiTietPhieuXuat.DonGiaXuat,PhieuXuat.MaPhieuXuat from HangHoa,ChiTietPhieuXuat,PhieuXuat where HangHoa.IDHangHoa = ChiTietPhieuXuat.IDHangHoa and ChiTietPhieuXuat.IDPhieuXuat = PhieuXuat.IDPhieuXuat";
        if (txtNgayDauKy.Value.Trim() != "")
            sql += " and ChiTietPhieuXuat.NgayXuatChiTiet >='" + StaticData.ConvertDDMMtoMMDD(txtNgayDauKy.Value.Trim()) + " 00:00:00'";
        if (txtNgayCuoiKy.Value.Trim() != "")
            sql += " and ChiTietPhieuXuat.NgayXuatChiTiet <='" + StaticData.ConvertDDMMtoMMDD(txtNgayCuoiKy.Value.Trim()) + " 00:00:00'";
        if (txtTuPhieu.Value.Trim() != "")
            sql += " and PhieuXuat.MaPhieuXuat >= N'" + txtTuPhieu.Value.Trim() + "'";
        if (txtDenPhieu.Value.Trim() != "")
            sql += " and PhieuXuat.MaPhieuXuat <= N'" + txtDenPhieu.Value.Trim() + "'";
        // sql += "group by HangHoa.MaHangHoa,HangHoa.TenHangHoa,ChiTietPhieuXuat.NgayXuatChiTiet,ChiTietPhieuNhap.NgayNhapChiTiet,ChiTietPhieuXuat.IDChiTietPhieuXuat,HangHoa.IDHangHoa ";
        sql += "  ) as tb1";
    

        DataTable table = Connect.GetTable(sql);

        string HTMLContent = "<html><body encoding=" + BaseFont.IDENTITY_H + " style='font-family:Arial;font-size:10px;'>";
        DataTable NoiToi = Connect.GetTable("select top 1 KhachHang.TenKhachHang,PhongBan.TenPhongBan,CuaHang.TenCuaHang,CuaHang.DiaChi,PhongBan.DiaChiPhongBan,KhachHang.DiaChi as 'DiaChiKH',CuaHang.SoDienThoai,CuaHang.NguoiLienLac from ChiTietPhieuXuat left join KhachHang on ChiTietPhieuXuat.IDKhachHang = KhachHang.IDKhachHang left join PhongBan on ChiTietPhieuXuat.IDPhongBan = PhongBan.IDPhongBan left join CuaHang on ChiTietPhieuXuat.IDCuaHang = CuaHang.IDCuaHang where IDPhieuXuat = '" + StaticData.getField("PhieuXuat", "IDPhieuXuat", "MaPhieuXuat", txtTuPhieu.Value.Trim()) + "'");
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
            <td colspan='5'>" + txtTuPhieu.Value.Trim() + "-" + txtDenPhieu.Value.Trim() + @"</td>
            <td colspan='5' style='text-align: center;'><i>Tp,HCM Ngày&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tháng&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;năm</i></td>  

</tr>

</table>
<table>
        <tr>
            <td style='text-align: center;border-color:white' colspan='7'><h1><b>BẢNG KÊ BÁN HÀNG</b></h1></td> 
        </tr>
</table>
<table>
        <tr>
            <td style='text-align: center;border-color:white'>&nbsp;</td> 
            <td style='text-align: center;border-color:white'>&nbsp;</td>
            <td style='text-align: center;border-color:white'>&nbsp;</td>
            <td style='text-align: center;border-color:white'>&nbsp;</td>
            <td style='text-align: center;border-color:white'>&nbsp;</td>
            <td style='text-align: center;border-color:white'>&nbsp;</td>
            <td style='text-align: center;border-color:white'>&nbsp;</td>
        </tr>  
        <tr>
            <td style='text-align: center;border-color:white' colspan='7'><i>Đính kèm hóa đơn số&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;ngày&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tháng&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;năm&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</i></td> 
        </tr>
        <tr>
            <td></td>
            <td colspan='7' style='text-align: left;'><h4><b>Đơn vị bán hàng: CÔNG TY CỔ PHẦN VIỄN LIÊN</b></h4></td>
         
          
        </tr>  
         <tr>
            <td  >&nbsp;</td> 
            <td colspan='2' ><i>Mã số thuế: 0301 401 291</i></td>
         
            <td  >&nbsp;</td>
            <td  >&nbsp;</td>
            <td  >&nbsp;</td>
            <td  >&nbsp;</td>
        </tr> 
           <tr>
            <td  >&nbsp;</td> 
            <td colspan='7' ><i>Địa chỉ: Số 32 Đường số 8 nhà ở Khu Z756, Phường 12, Q.10, Tp.Hồ Chí Minh</i></td>
         
           
            
        </tr>   
         <tr>
           <td  >&nbsp;</td>
            <td colspan='7' ><i>Điện thoại: 028 3620 8997 - Fax: 028 3620 8997</i></td>
         
            
          
        </tr> 
          <tr>
            <td  >&nbsp;</td> 
             <td  >&nbsp;</td> 
         
            <td  >&nbsp;</td>
            <td  >&nbsp;</td>
            <td  >&nbsp;</td>
            <td  >&nbsp;</td>
           
            <td  >&nbsp;</td>
        </tr> 
         <tr>
            <td ></td> 
             <td colspan='7' ><h4><b>Tên đơn vị mua hàng  :" + BenNhan + @"</b></h4></td> 
         
           
           
        </tr> 
      
           <tr>
            <td  >&nbsp;</td> 
             <td  colspan='7'><i>Địa chỉ :" + DiaChi + @"</i></td> 
         
            
        </tr> 
         <tr>
            <td  >&nbsp;</td> 
             <td colspan='7' ><i>Mã số thuế :    </i></td> 
         
           
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
                        <th style='border-color:black;text-align: center;'><b>STT</b></th>
                        <th style='border-color:black;text-align: center;'><b>DANH MỤC VPP</b></th>                       
                        <th style='border-color:black;text-align: center;'><b>ĐVT</b></th>
                        <th style='border-color:black;text-align: center;'><b>SỐ LƯỢNG</b></th>
                         <th style='border-color:black;text-align: center;'> <b>ĐƠN GIÁ</b></th> 
                        <th style='border-color:black;text-align: center;'><b>THÀNH TIỀN</b></th>
                        <th style='border-color:black;text-align: center;'><b>GHI CHÚ</b></th>                      
                  </tr>";
        double TongCong = 0;
        double TongSoLuong = 0;
        for (int j = 0; j < Muc.Rows.Count; j++)
        {
           
            int stt = 0;
            int xet = 0;
            for (int i = 0; i < table.Rows.Count; i++)
            {

                if (Muc.Rows[j]["Muc"].ToString().Trim().CompareTo(table.Rows[i]["Muc"].ToString().Trim()) == 0)
                {
                    xet += 1;
                }

            }
            if (xet > 0)
            {
                HTMLContent += "<tr><td style='border-color:black;text-align: left;' colspan='7' ><b>" + Muc.Rows[j]["Muc"].ToString() + "</b></td></tr>";
                for (int i = 0; i < table.Rows.Count; i++)
                {

                    if (Muc.Rows[j]["Muc"].ToString().Trim().CompareTo(table.Rows[i]["Muc"].ToString().Trim()) == 0)
                    {
                        stt += 1;
                        HTMLContent += "       <tr >";
                        HTMLContent += "       <td style='border-right-color: black;text-align: center;'>" + stt.ToString() + "</td>";
                        HTMLContent += "       <td style='border-right-color: black;text-align: left;'>" + table.Rows[i]["TenHangHoa"].ToString() + "</td>";
                        HTMLContent += "       <td style='border-right-color: black;text-align: center;'>" + StaticData.getField("DonViTinh", "TenDonViTinh", "IDDonViTinh", StaticData.getField("HangHoa", "IDDonViTinh", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString())) + "</td>";
                        double a = double.Parse(table.Rows[i]["SoLuong"].ToString());
                        HTMLContent += "       <td style='border-right-color: black;text-align: center;'>" + string.Format("{0:N0}", (a)).Replace(",", ".") + "</td>";
                        double a1 = double.Parse(table.Rows[i]["DonGiaXuat"].ToString());
                        HTMLContent += "       <td style='border-right-color: black;text-align: center;'>" + string.Format("{0:N0}", (a1)).Replace(",", ".") + "</td>";

                        TongSoLuong += a;

                        double Ton = a * a1;
                        TongCong += Ton;
                        HTMLContent += "       <td style='border-right-color: black;text-align: center;'>" + string.Format("{0:N0}", (Ton)).Replace(",", ".") + "</td>";

                        // DataTable gc = Connect.GetTable("select GhiChu from ChiTietPhieuXuat where IDChiTietPhieuXuat=" + table.Rows[i]["IDChiTietPhieuXuat"].ToString() + "");
                        HTMLContent += "       <td style='border-right-color: black;text-align: center;'>&nbsp;</td>";
                        HTMLContent += "     </tr>";
                    }

                }
            }
        }


        HTMLContent += @" 
        <tr>
            <td style='border-top-color: black'>&nbsp;</td> 
            <td style='border-top-color: black;text-align: center;'>CỘNG:</td> 
            <td style='border-top-color: black'>&nbsp;</td>
            <td style='border-top-color: black;text-align: center;'>" + string.Format("{0:N0}", (TongSoLuong)).Replace(",", ".") + @"</td>
            <td style='border-top-color: black'>&nbsp;</td>
            <td style='border-top-color: black;text-align: center;'>" + string.Format("{0:N0}", (TongCong)).Replace(",", ".") + @"</td>
             <td style='border-top-color: black'>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td> 
            <td style='text-align: center;'>THUẾ VAT:</td> 
            <td>&nbsp;</td>
            <td >&nbsp;</td>
            <td>&nbsp;</td>
            <td style='text-align: center;'>" + string.Format("{0:N0}", ((TongCong * 10 / 100))).Replace(",", ".") + @"</td>
             <td>&nbsp;</td>
        </tr>
         <tr>
            <td>&nbsp;</td> 
            <td style='text-align: center;'><b>THÀNH TIỀN:</b></td> 
            <td>&nbsp;</td>
            <td >&nbsp;</td>
            <td>&nbsp;</td>
            <td style='text-align: center;'><b>" + string.Format("{0:N0}", ((TongCong + (TongCong * 10 / 100)))).Replace(",", ".") + @"</b></td>
             <td>&nbsp;</td>
        </tr>
</table><table border='0'>
         <tr>
           
           
            <td colspan='7' style='text-align: right;'><i >Tp.HCM, ngày&nbsp;&nbsp;&nbsp;&nbsp;      tháng&nbsp;&nbsp;&nbsp;&nbsp;      năm&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;              </i></td> 
           
            
        </tr>
        <tr>
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
            <td >&nbsp;</td>
           
    
             <td style='text-align: center;' colspan='3'><b><i>TL.Thủ Trưởng đơn vị	</i></b></td>
        </tr>
</table><table border='0'>
        <tr>
           <td><i><b>Người mua hàng</b></i></td> 
            <td><i><b>Người bán hàng</b></i></td>

          <td style='padding:0px 0px 0px 15px;'><font color='white'>abcd</font><i><b>Cửa Hàng Trưởng</b></i></td>
            
        </tr>
       </table>


</body></html>";


          string FileName = "BangKe";
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

        //  string fontpath = Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + "\\ARIALUNI.TTF";        //  "ARIALUNI.TTF" file copied from fonts folder and placed in the folder
          string fontpath = "http://vienlien.lamphanmem.com/Fonts/ARIALUNI.TTF";        //  "ARIALUNI.TTF" file copied from fonts folder and placed in the folder
          BaseFont bf = BaseFont.CreateFont(fontpath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
          FontFactory.RegisterDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), true);
          FontFactory.Register(fontpath, "Arial Unicode MS");

          string path = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/ArialUni.TFF");
          iTextSharp.text.Font fnt = new iTextSharp.text.Font();
          FontFactory.Register(path, "Arial Unicode MS");
          fnt = FontFactory.GetFont("Arial Unicode MS", BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 10, Font.NORMAL);


          htmlparser.Parse(sr);
          pdfDoc.Close();
          Response.Write(pdfDoc);
          Response.End();
       /* Response.AppendHeader("content-disposition", "attachment;filename=BangKe.xls");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        this.EnableViewState = false;
        Response.Write(HTMLContent);
        Response.End();*/
        //var strBody = new StringBuilder();

        //strBody.Append("<html " +
        // "xmlns:o='urn:schemas-microsoft-com:office:office' " +
        // "xmlns:w='urn:schemas-microsoft-com:office:word'" +
        //  "xmlns='http://www.w3.org/TR/REC-html40'>" +
        //  "<head><title>Time</title>");

        ////  The setting specifies document's view after it is downloaded as Print
        ////   instead of the default Web Layout
        //strBody.Append("<!--[if gte mso 9]>" +
        // "<xml>" +
        // "<w:WordDocument>" +
        // "<w:View>Print</w:View>" +
        // "<w:Zoom>100</w:Zoom>" +
        // "<w:DoNotOptimizeForBrowser/>" +
        // "</w:WordDocument>" +
        // "</xml>" +
        // "<![endif]-->");

        //strBody.Append("<style>" +
        // "<!-- /* Style Definitions */" +
        // "@page Section1" +
        // "   {size:8.5in 10.0in; " +
        // "   margin:0.8in 0.7in ; " +
        // "   mso-header-margin:.1in; " +
        // "   mso-footer-margin:.5in; mso-paper-source:0;}" +
        // " div.Section1" +
        // "   {page:Section1;}" +
        // "-->" +
        // "</style></head>");

        //strBody.Append("<body lang=EN-US style='tab-interval:.5in'>" +
        // "<div class=Section1>");
        //strBody.Append(HTMLContent);
        ////strBody.Append("</div></body></html>");
        //string TenFile = DateTime.Now.Ticks.ToString();
        //string strPath2 = Request.PhysicalApplicationPath + @"Files\";
        //string strPath = Request.PhysicalApplicationPath + @"Files\" + TenFile + ".doc";
        //FileStream fStream = File.Create(strPath);
        //fStream.Close();
        //StreamWriter sWriter = new StreamWriter(strPath, false, Encoding.UTF8);
        //sWriter.Write(strBody);
        //sWriter.Close();
        //// Response.Write(strPath);
        ///*  Document doc = new Document();
      
        //  doc.LoadFromFile(@"" + strPath);
  
        //  doc.SaveToFile(@"" + strPath2 + "636404763499472227.PDF", FileFormat.PDF);
     
        //  System.Diagnostics.Process.Start(@"" + strPath2 + "636404763499472227.PDF");*/

        //var wordApp = new Microsoft.Office.Interop.Word.Application();
        //var wordDocument = wordApp.Documents.Open(@"" + strPath);
        //string downloadsPath = KnownFolders.GetPath(KnownFolders.KnownFolder.Desktop);
        //string ten = @"BBKE" + DateTime.Now.ToString() + ".PDF";
        //wordDocument.ExportAsFixedFormat(@"" + downloadsPath + @"\" + ten.Replace(" ", "").Replace("/", "").Replace(":", ""), Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);
        ////  wordDocument.ExportAsFixedFormat(ten, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);
        //wordDocument.Close(Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges,
        //                   Microsoft.Office.Interop.Word.WdOriginalFormat.wdOriginalDocumentFormat,
        //                   false); //Close document

        //wordApp.Quit();
        //if (File.Exists(@"" + strPath))
        //{
        //    File.Delete(@"" + strPath);
        //}
 
        //Response.Write("<script>alert('Đã xuất file pdf ra " + downloadsPath.Replace("\\","\\\\")+@"')</script>");
    }
    protected void TC_Click(object sender, EventArgs e)
    {
        Response.Redirect("BangKe.aspx");
    }
}