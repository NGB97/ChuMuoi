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
public partial class BaoCao_BienBanGiaoHangHai : System.Web.UI.Page
{
    string pMaPhieu = "";
   
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
                if (Request.QueryString["MaPhieu"].Trim() != "")
                {
                    pMaPhieu = StaticData.ValidParameter(Request.QueryString["MaPhieu"].Trim());
                    txtMaPhieu.Value = pMaPhieu;
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
        string sql = "select count(*) from ChiTietPhieuXuat left join HangHoa on ChiTietPhieuXuat.IDHangHoa = HangHoa.IDHangHoa left join PhieuXuat on ChiTietPhieuXuat.IDPhieuXuat = PhieuXuat.IDPhieuXuat where '1'='1' ";

      //  sql += "select HangHoa.MaHangHoa,HangHoa.TenHangHoa,ChiTietPhieuXuat.NgayXuatChiTiet,ChiTietPhieuNhap.NgayNhapChiTiet,ISNULL(SUM(ChiTietPhieuNhap.SoLuong),0) as 'SoLuongNhap',ISNULL(SUM(ChiTietPhieuNhap.DonGiaNhap),0) as 'DonGiaNhap',ISNULL(SUM(ChiTietPhieuXuat.SoLuong),0) as 'SoLuongXuat',ISNULL(SUM(ChiTietPhieuXuat.DonGiaXuat),0) as 'DonGiaXuat',ChiTietPhieuXuat.IDChiTietPhieuXuat from HangHoa ,ChiTietPhieuNhap,ChiTietPhieuXuat where ChiTietPhieuNhap.IDHangHoa = HangHoa.IDHangHoa and ChiTietPhieuXuat.IDHangHoa = HangHoa.IDHangHoa and ChiTietPhieuXuat.NgayXuatChiTiet is not null";
        if (pMaPhieu != "")
            sql += " and PhieuXuat.MaPhieuXuat like N'" + pMaPhieu + "'";
       
      
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
        sql += @"select * from(select ROW_NUMBER() OVER(ORDER BY ChiTietPhieuXuat.NgayXuatChiTiet asc)AS RowNumber,HangHoa.TenHangHoa,HangHoa.IDHangHoa,PhieuXuat.MaPhieuXuat,ChiTietPhieuXuat.SoLuong,ChiTietPhieuXuat.DonGiaXuat,ChiTietPhieuXuat.NgayXuatChiTiet from ChiTietPhieuXuat left join HangHoa on ChiTietPhieuXuat.IDHangHoa = HangHoa.IDHangHoa left join PhieuXuat on ChiTietPhieuXuat.IDPhieuXuat = PhieuXuat.IDPhieuXuat where '1'='1'";
        if (pMaPhieu != "")
            sql += " and PhieuXuat.MaPhieuXuat like N'" + pMaPhieu + "'";
       

       // sql += "group by HangHoa.MaHangHoa,HangHoa.TenHangHoa,ChiTietPhieuXuat.NgayXuatChiTiet,ChiTietPhieuNhap.NgayNhapChiTiet,ChiTietPhieuXuat.IDChiTietPhieuXuat,HangHoa.IDHangHoa ";
        sql += "  ) as tb1";
        sql += " WHERE RowNumber BETWEEN (" + Page + " - 1) * " + PageSize2 + " + 1 AND (((" + Page + " - 1) * " + PageSize2 + " + 1) + " + PageSize2 + ") - 1";

        DataTable table = Connect.GetTable(sql);

        SetPage();

        string html = @" <table class='table table-bordered table-striped'>
                  <tr>
                        <th class='th'   style='text-align: center;width: 100px;'>
                         STT
                        </th>
                        <th class='th'   style='text-align: center;'>
                        DANH MỤC HÀNG HÓA
                        </th>
                     
                       
                        <th class='th'   style='text-align: center;'>
                         ĐVT
                        </th>
                         <th class='th'  style='text-align: center;'>
                           SỐ LƯỢNG
                        </th>
                       
                        <th class='th'   style='text-align: center;'>
                         GHI CHÚ
                        </th>
                    </tr>
                    
                   ";
        // double SoTienPhaiThu = 0;
        for (int i = 0; i < table.Rows.Count; i++)
        {
            html += "       <tr >";
            html += "<td style='text-align: center;width: 100px;'>" + (((Page - 1) * PageSize2) + i + 1).ToString() + "</td>";

            html += "       <td>" + table.Rows[i]["TenHangHoa"].ToString() + "</td>";
           // html += "       <td>" + DateTime.Parse(table.Rows[i]["NgayXuatChiTiet"].ToString()).ToString("dd/MM/yyyy") + "</td>";
           // string IDMauSac = StaticData.getField("HangHoa", "IDMauSac", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString());
           // string MauSac = StaticData.getField("MauSac", "TenMauSac", "IDMauSac", IDMauSac);
            //html += "       <td>" + MauSac + "</td>";
            string IDDonViTinh = StaticData.getField("HangHoa", "IDDonViTinh", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString());
            string DonViTinh = StaticData.getField("DonViTinh", "TenDonViTinh", "IDDonViTinh", IDDonViTinh);
            html += "       <td style='text-align: center;'>" + DonViTinh + "</td>";
         
            double a = double.Parse(table.Rows[i]["SoLuong"].ToString());

            html += "       <td  style='text-align: center;'>" + a.ToString("#,##").Replace(",", ".") + "</td>";
      
         //  DataTable gc = Connect.GetTable("select GhiChu from ChiTietPhieuXuat where IDChiTietPhieuXuat=" + table.Rows[i]["IDChiTietPhieuXuat"].ToString() + "");
            html += "       <td>&nbsp;</td>";
            html+="     </tr>";

        }
        html += "   <tr>";
        html += "       <td colspan='9' class='footertable'>";
        string url = "BienBanGiaoHangHai.aspx?";
        if (pMaPhieu != "")
            url += "MaPhieu=" + pMaPhieu + "&";
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
        string MaPhieu = txtMaPhieu.Value.Trim();

        string url = "BienBanGiaoHangHai.aspx?";
        if (MaPhieu != "")
            url += "MaPhieu=" + MaPhieu + "&";
     
        Response.Redirect(url);
    }
    protected void btTatCa_Click(object sender, EventArgs e)
    {
       
        string sql = "";
        sql += @"select * from(select ROW_NUMBER() OVER(ORDER BY ChiTietPhieuXuat.NgayXuatChiTiet asc)AS RowNumber,HangHoa.TenHangHoa,HangHoa.IDHangHoa,PhieuXuat.MaPhieuXuat,ChiTietPhieuXuat.SoLuong,ChiTietPhieuXuat.DonGiaXuat,ChiTietPhieuXuat.NgayXuatChiTiet from ChiTietPhieuXuat left join HangHoa on ChiTietPhieuXuat.IDHangHoa = HangHoa.IDHangHoa left join PhieuXuat on ChiTietPhieuXuat.IDPhieuXuat = PhieuXuat.IDPhieuXuat where '1'='1'";
        if (txtMaPhieu.Value.Trim() != "")
            sql += " and PhieuXuat.MaPhieuXuat like N'%" + txtMaPhieu.Value.Trim() + "%'";
      

        // sql += "group by HangHoa.MaHangHoa,HangHoa.TenHangHoa,ChiTietPhieuXuat.NgayXuatChiTiet,ChiTietPhieuNhap.NgayNhapChiTiet,ChiTietPhieuXuat.IDChiTietPhieuXuat,HangHoa.IDHangHoa ";
        sql += "  ) as tb1";
    

        DataTable table = Connect.GetTable(sql);

        string HTMLContent = "";
      

        //HTMLContent += "<table border='1'>";
        DataTable NoiToi = Connect.GetTable("select top 1 KhachHang.TenKhachHang,PhongBan.TenPhongBan,CuaHang.TenCuaHang,CuaHang.DiaChi,PhongBan.DiaChiPhongBan,KhachHang.DiaChi as 'DiaChiKH' from ChiTietPhieuXuat left join KhachHang on ChiTietPhieuXuat.IDKhachHang = KhachHang.IDKhachHang left join PhongBan on ChiTietPhieuXuat.IDPhongBan = PhongBan.IDPhongBan left join CuaHang on ChiTietPhieuXuat.IDCuaHang = CuaHang.IDCuaHang where IDPhieuXuat = '" + StaticData.getFieldCoDau("PhieuXuat", "IDPhieuXuat", "MaPhieuXuat", txtMaPhieu.Value.Trim()) + "'");
        string NoiGiao = "";
        string DiaChi = "";
        string NoiNhan = "";
        if (NoiToi.Rows.Count > 0)
        {
            NoiGiao = NoiToi.Rows[0]["TenCuaHang"].ToString();
            if (NoiToi.Rows.Count > 0)
            {
                NoiGiao = NoiToi.Rows[0]["TenCuaHang"].ToString();
                if (NoiToi.Rows[0]["DiaChi"].ToString().Trim() != "")
                {
                    DiaChi = NoiToi.Rows[0]["DiaChi"].ToString();
                }
                else
                {
                    if (NoiToi.Rows[0]["DiaChiPhongBan"].ToString().Trim() != "")
                        DiaChi = NoiToi.Rows[0]["DiaChiPhongBan"].ToString();
                    else DiaChi = NoiToi.Rows[0]["DiaChiKH"].ToString();
                }
                NoiNhan = NoiToi.Rows[0]["TenKhachHang"].ToString() + "_" + NoiToi.Rows[0]["TenPhongBan"].ToString();
            }
            NoiNhan = NoiToi.Rows[0]["TenKhachHang"].ToString() + "_" + NoiToi.Rows[0]["TenPhongBan"].ToString();
        }
        HTMLContent += @"
<html><body encoding=" + BaseFont.IDENTITY_H + " style='font-family:Arial;font-size:10px;'>";
        HTMLContent += @"
<table style='border-color:#d4d4d4;border-collapse: collapse;' BORDERCOLOR='#d4d4d4' width='100%'>
        <tr>
            <td  border='1' width='10%' ><img src='http://vienlien.lamphanmem.com/images/vienlien.png' width='30' height = '30'></td> 
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td style='text-align: left;' border='1' width='42%'><div><b>CÔNG TY CỔ PHẦN VIỄN LIÊN</b><div></td>
           <td style='text-align: center;' border='1' width='43%'><b>CỘNG HÒA XÃ HỘI CHỦ NGHĨA ViỆT NAM	<b></td>
     
        </tr>
</table>
<br />
<table>
        <tr>         
            <td style='font-size:15px;'>Số 32 Đường số 8 nhà ở Khu Z756, Phường 12, Q.10, Tp.Hồ Chí Minh</td>
            <td colspan='5' style='text-align: center;'><div>Độc lập - Tự do - Hạnh phúc
            
</div></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style='height:27px;width:306px;'><b><i><u>Tel</u></i></b> : 028 3620 8997 - <b><i><u>Fax</u></i></b> : 028 3620 8997</td>
            <td colspan='5' >&nbsp;</td>
        </tr>
        <tr>
            <td style='text-align: right;'  >Số:</td> 
            <td>" + txtMaPhieu.Value.Trim() + @"</td>
            <td>&nbsp;</td>
                <td colspan='4' style='text-align: right;'><i>Tp,HCM Ngày&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;tháng&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;năm&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</i></td>
          
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
        <tr>
            <td style='text-align: center; padding:15px 0px 15px 0px;' colspan='7' ><h2><b>BIÊN BẢN NGHIỆM THU & BÀN GIAO HÀNG HÓA</b></h2></td> 
        </tr>
        <tr>
            <td>&nbsp;</td> 
            <td colspan='5' ><h4><b>Bên giao :       CÔNG TY CỔ PHẦN ViỄN LIÊN</b></h4></td>
           <td>&nbsp;</td> 
        </tr>
         <tr>
            <td>&nbsp;</td>
      
          <td colspan='5'><h5><b>Bên nhận :" + NoiNhan + @"</b></h5></td>
           
        <td>&nbsp;</td> 
        </tr>   
        <tr>
            <td>&nbsp;</td><td colspan='5'>Địa chỉ giao hàng: " + DiaChi + @"</td>
  
         <td>&nbsp;</td> 
        </tr>
        <tr>
            <td>&nbsp;</td> 
            <td colspan='5'>Nơi nhận: " + NoiGiao + @"</td>
           <td>&nbsp;</td> 
        </tr>
          <tr>           
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

                   <tr>
                        <th style='border-color:black'>STT</th>
                        <th style='border-color:black'>DANH MỤC HÀNG HÓA</th>
                      
                       
                        <th style='border-color:black'>ĐVT</th>
                         <th style='border-color:black'>SỐ LƯỢNG</th>
                      
                        <th colspan='3' style='text-align: center;border-color:black;'>GHI CHÚ</th>                                         
                    </tr> ";
        for (int i = 0; i < table.Rows.Count; i++)
        {
            HTMLContent += "       <tr >";
            HTMLContent += " <td style='border-right-color: black'>" + (((Page - 1) * PageSize2) + i + 1).ToString() + "</td>";

            HTMLContent += "       <td style='border-right-color: black'>" + table.Rows[i]["TenHangHoa"].ToString() + "</td>";
            // HTMLContent += "       <td>" + DateTime.Parse(table.Rows[i]["NgayXuatChiTiet"].ToString()).ToString("dd/MM/yyyy") + "</td>";
           // string IDMauSac = StaticData.getField("HangHoa", "IDMauSac", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString());
           // string MauSac = StaticData.getField("MauSac", "TenMauSac", "IDMauSac", IDMauSac);
          //  HTMLContent += "       <td>" + MauSac + "</td>";
            string IDDonViTinh = StaticData.getField("HangHoa", "IDDonViTinh", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString());
            string DonViTinh = StaticData.getField("DonViTinh", "TenDonViTinh", "IDDonViTinh", IDDonViTinh);
            HTMLContent += "       <td style='border-right-color: black'>" + DonViTinh + "</td>";
         
            double a = double.Parse(table.Rows[i]["SoLuong"].ToString());

            HTMLContent += "       <td style='border-right-color: black'>" + string.Format("{0:N0}", (a)).Replace(",", ".") + "</td><td colspan='3' style='border-right-color: black'>&nbsp;</td>  ";

            //  DataTable gc = Connect.GetTable("select GhiChu from ChiTietPhieuXuat where IDChiTietPhieuXuat=" + table.Rows[i]["IDChiTietPhieuXuat"].ToString() + "");
        
            HTMLContent += "     </tr>";

        }



        HTMLContent += @"
 <tr>
            <td>&nbsp;</td> 
            <td>&nbsp;</td> 
            <td>&nbsp;</td>
            <td >&nbsp;</td>
            <td>&nbsp;</td>
              <td>&nbsp;</td>
   
        </tr>
        <tr>
               <td colspan='2' style='text-align: left;'><b>ĐẠI DIỆN BÊN NHẬN HÀNG</b></td> 
            <td>&nbsp;</td>
           
           
            <td colspan='4' style='text-align: center;'><b>ĐẠI DIỆN BÊN GIAO HÀNG</b></td>
        
        </tr>
        <tr>
             <td style='text-align: left;' colspan='2'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Người nhận hàng</td> 
            <td>&nbsp;</td>
           
         
            <td style='text-align: center;' colspan='4'>Người giao hàng</td> 
            
        </tr>

</table>
          

</body></html>";
       

        string FileName = "BienBanGiaoHangHai";
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
      /*  Response.AppendHeader("content-disposition", "attachment;filename=BienBanGiaoHangHai.xls");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        this.EnableViewState = false;
        Response.Write(HTMLContent);
        Response.End();*/
    }
    protected void TC_Click(object sender, EventArgs e)
    {
        Response.Redirect("BienBanGiaoHangHai.aspx");
    }
}