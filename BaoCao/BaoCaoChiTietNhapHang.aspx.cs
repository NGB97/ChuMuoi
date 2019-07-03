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
public partial class BaoCao_BienBanGiaoHangMot : System.Web.UI.Page
{
    string pMaPhieu = "";
    string pTenHangHoa = "";
    string pTuNgayNhap = "";
    string pDenNgayNhap = "";
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
      /*  if (Session["QuanLyNhapXuatHang_Login"] != null && Session["QuanLyNhapXuatHang_Login"].ToString() != "")
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
                if (Request.QueryString["MaPhieuNhap"].Trim() != "")
                {
                    pMaPhieu = StaticData.ValidParameter(Request.QueryString["MaPhieuNhap"].Trim());
                    txtMaPhieu.Value = pMaPhieu;
                }
            }
            catch { }
            try
            {
                if (Request.QueryString["TenHangHoa"].Trim() != "")
                {
                    pTenHangHoa = Request.QueryString["TenHangHoa"].Trim().ToString().Replace("\\", "");
                    txtTenHangHoa.Value = pTenHangHoa;
                }
            }
            catch { }
            try
            {
                if (Request.QueryString["TuNgayNhap"].Trim() != "")
                {
                    pTuNgayNhap = Request.QueryString["TuNgayNhap"].Trim().ToString();
                    txtTuNgayNhap.Value = pTuNgayNhap;
                }
            }
            catch { }
            try
            {
                if (Request.QueryString["DenNgayNhap"].Trim() != "")
                {
                    pDenNgayNhap = Request.QueryString["DenNgayNhap"].Trim().ToString();
                    txtDenNgayNhap.Value = pDenNgayNhap;
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
        string sql = "select count(*) from ChiTietPhieuNhap left join HangHoa on ChiTietPhieuNhap.IDHangHoa = HangHoa.IDHangHoa left join PhieuNhap on ChiTietPhieuNhap.IDPhieuNhap = PhieuNhap.IDPhieuNhap where '1'='1'";

      //  sql += "select HangHoa.MaHangHoa,HangHoa.TenHangHoa,ChiTietPhieuXuat.NgayXuatChiTiet,ChiTietPhieuNhap.NgayNhapChiTiet,ISNULL(SUM(ChiTietPhieuNhap.SoLuong),0) as 'SoLuongNhap',ISNULL(SUM(ChiTietPhieuNhap.DonGiaNhap),0) as 'DonGiaNhap',ISNULL(SUM(ChiTietPhieuXuat.SoLuong),0) as 'SoLuongXuat',ISNULL(SUM(ChiTietPhieuXuat.DonGiaXuat),0) as 'DonGiaXuat',ChiTietPhieuXuat.IDChiTietPhieuXuat from HangHoa ,ChiTietPhieuNhap,ChiTietPhieuXuat where ChiTietPhieuNhap.IDHangHoa = HangHoa.IDHangHoa and ChiTietPhieuXuat.IDHangHoa = HangHoa.IDHangHoa and ChiTietPhieuXuat.NgayXuatChiTiet is not null";
        if (pMaPhieu != "")
            sql += " and PhieuNhap.MaPhieuNhap like N'" + pMaPhieu + "'";
        if (pTenHangHoa != "")
            sql += " and HangHoa.TenHangHoa like N'" + pTenHangHoa + "'";
        if (pTuNgayNhap != "")
            sql += " and ChiTietPhieuNhap.NgayNhapChiTiet >='" + StaticData.ConvertDDMMtoMMDD(pTuNgayNhap) + " 00:00:00'";
        if (pDenNgayNhap != "")
            sql += " and ChiTietPhieuNhap.NgayNhapChiTiet <='" + StaticData.ConvertDDMMtoMMDD(pDenNgayNhap) + " 00:00:00'";
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
        sql += @"select * from(select ROW_NUMBER() OVER(ORDER BY ChiTietPhieuNhap.IDChiTietPhieuNhap asc)AS RowNumber,ChiTietPhieuNhap.IDNhaCungCap,HangHoa.MaVach,HangHoa.MaHangHoa,HangHoa.TenHangHoa,HangHoa.IDHangHoa,PhieuNhap.MaPhieuNhap,ChiTietPhieuNhap.SoLuong,ChiTietPhieuNhap.DonGiaNhap,ChiTietPhieuNhap.NgayNhapChiTiet,ChiTietPhieuNhap.GhiChu from ChiTietPhieuNhap left join HangHoa on ChiTietPhieuNhap.IDHangHoa = HangHoa.IDHangHoa left join PhieuNhap on ChiTietPhieuNhap.IDPhieuNhap = PhieuNhap.IDPhieuNhap where '1'='1'";
        if (pMaPhieu != "")
            sql += " and PhieuNhap.MaPhieuNhap like N'" + pMaPhieu + "'";
        if (pTenHangHoa != "")
            sql += " and HangHoa.TenHangHoa like N'" + pTenHangHoa + "'";
        if (pTuNgayNhap != "")
            sql += " and ChiTietPhieuNhap.NgayNhapChiTiet >='" + StaticData.ConvertDDMMtoMMDD(pTuNgayNhap) + " 00:00:00'";
        if (pDenNgayNhap != "")
            sql += " and ChiTietPhieuNhap.NgayNhapChiTiet <='" + StaticData.ConvertDDMMtoMMDD(pDenNgayNhap) + " 00:00:00'";
       // sql += "group by HangHoa.MaHangHoa,HangHoa.TenHangHoa,ChiTietPhieuXuat.NgayXuatChiTiet,ChiTietPhieuNhap.NgayNhapChiTiet,ChiTietPhieuXuat.IDChiTietPhieuXuat,HangHoa.IDHangHoa ";
        sql += "  ) as tb1";
        DataTable sluong = Connect.GetTable("select isnull(sum(tb2.SoLuong),0) as 'SL' from ("+sql+") as tb2");
        DataTable dgnhap = Connect.GetTable("select isnull(sum(tb2.DonGiaNhap),0) as 'SL' from (" + sql + ") as tb2");
        DataTable ttien = Connect.GetTable("select isnull(sum(tb2.DonGiaNhap*tb2.SoLuong),0) as 'SL' from (" + sql + ") as tb2");
        sql += " WHERE RowNumber BETWEEN (" + Page + " - 1) * " + PageSize2 + " + 1 AND (((" + Page + " - 1) * " + PageSize2 + " + 1) + " + PageSize2 + ") - 1";

        DataTable table = Connect.GetTable(sql);

        SetPage();

        string html = @"

<table class='table table-bordered table-striped'>
                  <tr>
                        <th class='th'   style='text-align: center;'>
                         STT
                        </th>
                        <th class='th'   style='text-align: center;'>
                        Mã phiếu nhập
                        </th>
                     
                       
                        <th class='th'   style='text-align: center;'>
                         Mã vạch
                        </th>
                        <th class='th'   style='text-align: center;'>
                         Mã hàng hóa
                        </th>
                         <th class='th'  style='text-align: center;'>
                           Tên sản phẩm
                        </th>
                        
                        <th class='th'   style='text-align: center;'>
                       Số lượng
                        </th>
                          <th class='th'   style='text-align: center;'>
                       Đơn giá nhập
                        </th>
                          <th class='th'   style='text-align: center;'>
                       Thành tiền
                        </th>
                        <th class='th'   style='text-align: center;'>
                       Ngày nhập
                        </th>
                         <th class='th'   style='text-align: center;'>
                       Nhà cung cấp
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
            html += "<td style='text-align: center;'>" + (((Page - 1) * PageSize2) + i + 1).ToString() + "</td>";
            html += "       <td>" + table.Rows[i]["MaPhieuNhap"].ToString() + "</td>";
            html += "       <td>" + table.Rows[i]["MaVach"].ToString() + "</td>";
            html += "       <td>" + table.Rows[i]["MaHangHoa"].ToString() + "</td>";
            html += "       <td>" + table.Rows[i]["TenHangHoa"].ToString() + "</td>";
           // html += "       <td>" + DateTime.Parse(table.Rows[i]["NgayXuatChiTiet"].ToString()).ToString("dd/MM/yyyy") + "</td>";
           // string IDMauSac = StaticData.getField("HangHoa", "IDMauSac", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString());
           // string MauSac = StaticData.getField("MauSac", "TenMauSac", "IDMauSac", IDMauSac);
            //html += "       <td>" + MauSac + "</td>";
            //string IDDonViTinh = StaticData.getField("HangHoa", "IDDonViTinh", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString());
           // string DonViTinh = StaticData.getField("DonViTinh", "TenDonViTinh", "IDDonViTinh", IDDonViTinh);
          //  html += "       <td>" + DonViTinh + "</td>";
          //  double SoXuat = double.Parse(table.Rows[0]["DonGiaXuat"].ToString());

           // html += "       <td>" + SoXuat.ToString("#,##").Replace(",", ".") + "</td>";
            double a = double.Parse(table.Rows[i]["SoLuong"].ToString());

            html += "       <td>" + a.ToString("#,##").Replace(",", ".") + "</td>";
            double a2 = double.Parse(table.Rows[i]["DonGiaNhap"].ToString());

            html += "       <td>" + a2.ToString("#,##").Replace(",", ".") + "</td>";            
            double ThanhTien = a2 * a;          
            html += "       <td>" + ThanhTien.ToString("#,##").Replace(",", ".") + "</td>";
            html += "       <td>" + DateTime.Parse(table.Rows[i]["NgayNhapChiTiet"].ToString()).ToString("dd/MM/yyyy") + "</td>";
         //  DataTable gc = Connect.GetTable("select GhiChu from ChiTietPhieuXuat where IDChiTietPhieuXuat=" + table.Rows[i]["IDChiTietPhieuXuat"].ToString() + "");
            html += "       <td>" + StaticData.getField("NhaCungCap", "TenNhaCungCap", "IDNhaCungCap", table.Rows[i]["IDNhaCungCap"].ToString()) + "</td>";
            html += "       <td>" + table.Rows[i]["GhiChu"].ToString() + "</td>";
            html+="     </tr>";

        }
        html += "   <tr>";
        html += "       <td colspan='11' class='footertable'>";
        string url = "BaoCaoChiTietNhapHang.aspx?";
        if (pMaPhieu != "")
            url += "MaPhieuNhap=" + pMaPhieu + "&";
        if (pTenHangHoa != "")
            url += "TenHangHoa=" + pTenHangHoa + "&";
        if (pTuNgayNhap != "")
            url += "TuNgayNhap=" + pTuNgayNhap + "&";
        if (pDenNgayNhap != "")
            url += "DenNgayNhap=" + pDenNgayNhap + "&";
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
        html += "<tr style='background-color: #00ff00;'>";
        html += "<td colspan='5' style='text-align:right;'><b>Tổng cộng</b></td>";
      
        html += "<td><b>"+double.Parse(sluong.Rows[0]["SL"].ToString()).ToString("#,##").Replace(",", ".")+"</b></td>";
        html += "<td><b>" + double.Parse(dgnhap.Rows[0]["SL"].ToString()).ToString("#,##").Replace(",", ".") + "</b></td>";
        html += "<td><b>" + double.Parse(ttien.Rows[0]["SL"].ToString()).ToString("#,##").Replace(",", ".") + "</b></td>";
        html += "<td colspan='3'>&nbsp;</td>";
       
        html += "</tr>";
        html += "     </table>";

        dvNguoiDung.InnerHtml = html;
    }
    protected void btTimKiem_Click(object sender, EventArgs e)
    {
        string MaPhieu = txtMaPhieu.Value.Trim();
        string TenHangHoa = txtTenHangHoa.Value.Trim();
        string TuNgayNhap = txtTuNgayNhap.Value.Trim();
        string DenNgayNhap = txtDenNgayNhap.Value.Trim();
        string url = "BaoCaoChiTietNhapHang.aspx?";
        if (MaPhieu != "")
            url += "MaPhieuNhap=" + MaPhieu + "&";
        if (TenHangHoa != "")
            url += "TenHangHoa=" + TenHangHoa + "&";
        if (TuNgayNhap != "")
            url += "TuNgayNhap=" + TuNgayNhap + "&";
        if (DenNgayNhap != "")
            url += "DenNgayNhap=" + DenNgayNhap + "&";
        Response.Redirect(url);
    }
    protected void btTatCa_Click(object sender, EventArgs e)
    {
     /*  string sql = "";
       sql += @"select * from(select ROW_NUMBER() OVER(ORDER BY ChiTietPhieuNhap.IDChiTietPhieuNhap asc)AS RowNumber,HangHoa.MaVach,HangHoa.MaHangHoa,HangHoa.TenHangHoa,HangHoa.IDHangHoa,PhieuNhap.MaPhieuNhap,ChiTietPhieuNhap.SoLuong,ChiTietPhieuNhap.DonGiaNhap,ChiTietPhieuNhap.NgayNhapChiTiet,ChiTietPhieuNhap.GhiChu from ChiTietPhieuNhap left join HangHoa on ChiTietPhieuNhap.IDHangHoa = HangHoa.IDHangHoa left join PhieuNhap on ChiTietPhieuNhap.IDPhieuNhap = PhieuNhap.IDPhieuNhap where '1'='1'";
       if (txtMaPhieu.Value.Trim() != "")
           sql += " and PhieuNhap.MaPhieuNhap like N'" + txtMaPhieu.Value.Trim() + "'";
       if (txtTenHangHoa.Value.Trim() != "")
           sql += " and HangHoa.TenHangHoa like N'" + txtTenHangHoa.Value.Trim() + "'";
       if (txtTuNgayNhap.Value.Trim() != "")
           sql += " and ChiTietPhieuNhap.NgayNhapChiTiet >='" + StaticData.ConvertDDMMtoMMDD(txtTuNgayNhap.Value.Trim()) + " 00:00:00'";
       if (txtDenNgayNhap.Value.Trim() != "")
           sql += " and ChiTietPhieuNhap.NgayNhapChiTiet <='" + StaticData.ConvertDDMMtoMMDD(txtDenNgayNhap.Value.Trim()) + " 00:00:00'";

       
        sql += "  ) as tb1";
    

        DataTable table = Connect.GetTable(sql);

        string HTMLContent = "<html><body encoding=" + BaseFont.IDENTITY_H + " style='font-family:Arial Unicode MS;font-size:12;'>";         
        HTMLContent += @"
<table border='1'>
        <tr>
            <td rowspan='3'><img src='http://vienlien.lamphanmem.com/images/vienlien.png'></td> 
            <td><b>CÔNG TY CỔ PHẦN ViỄN LIÊN</b></td>
            <td colspan='5' style='text-align: center;'><b>CỘNG HÒA XÃ HỘI CHỦ NGHĨA ViỆT NAM</b></td>              
        </tr>
        <tr>
          
            <td>Số 32 Đường số 8 nhà ở Khu Z756, Phường 12, Q.10, Tp.Hồ Chí Minh</td>
            <td colspan='5' style='text-align: center;'>Độc lập - Tự do - Hạnh phúc</td>
        </tr>
        <tr>
          
            <td><b><i><u>Tel</u></i></b> : 028 3620 8997  -  <b><i><u>Fax</u></i></b> : 028 3620 8997</td>
            <td colspan='5' style='text-align: center;'>&nbsp;</td>
        </tr>
        <tr>
            <td style='text-align: right;'  >Số:</td> 
            <td>" + txtMaPhieu.Value.Trim() + @"</td>
            <td>&nbsp;</td>
                <td colspan='4' style='text-align: right;'><i>Tp,HCM Ngày&nbsp;&nbsp;&nbsp;&nbsp;tháng&nbsp;&nbsp;&nbsp;&nbsp;năm&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</i></td>
          
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
            <td style='text-align: center;' colspan='7'><h3><b>BIÊN BẢN NGHIỆM THU & BÀN GIAO HÀNG HÓA</b></h3></td> 
        </tr>
        <tr>
            <td>&nbsp;</td> 
            <td colspan='5'><h4><b>Bên giao :       CÔNG TY CỔ PHẦN ViỄN LIÊN</b></h4></td>
           <td>&nbsp;</td> 
        </tr>
         <tr>
            <td>&nbsp;</td> 
            <td colspan='5'><h5><b>Bên nhận :&nbsp;</b></h5></td>
           <td>&nbsp;</td> 
        </tr>   
        <tr>
            <td>&nbsp;</td> 
            <td colspan='5'><i>Địa chỉ giao hàng:</i></td>
           <td>&nbsp;</td> 
        </tr>
        <tr>
            <td>&nbsp;</td> 
            <td colspan='5'><i>Nơi nhận:</i></td>
           <td>&nbsp;</td> 
        </tr>
          <tr>           
            <td colspan='5'><i>Cùng tiến hành kiểm tra chất lượng và số lượng của những mặt hàng sau :</i></td>
           <td>&nbsp;</td> 
        </tr>                 
                   <tr>
                        <th>STT</th>
                        <th>DANH MỤC HÀNG HÓA</th>
                        <th>ĐVT</th>
                        <th>ĐƠN GIÁ</th>
                        <th>SỐ LƯỢNG</th>                       
                        <th>THÀNH TIỀN</th>
                        <th>GHI CHÚ</th>
                    </tr> ";
        for (int i = 0; i < table.Rows.Count; i++)
        {
            HTMLContent += "<tr>";
            HTMLContent += " <td style='text-align: center;'>" + (((Page - 1) * PageSize2) + i + 1).ToString() + "</td>";

            HTMLContent += "<td>" + table.Rows[i]["TenHangHoa"].ToString() + "</td>";
            // HTMLContent += "       <td>" + DateTime.Parse(table.Rows[i]["NgayXuatChiTiet"].ToString()).ToString("dd/MM/yyyy") + "</td>";
           // string IDMauSac = StaticData.getField("HangHoa", "IDMauSac", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString());
           // string MauSac = StaticData.getField("MauSac", "TenMauSac", "IDMauSac", IDMauSac);
           // HTMLContent += "       <td>" + MauSac + "</td>";
            string IDDonViTinh = StaticData.getField("HangHoa", "IDDonViTinh", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString());
            string DonViTinh = StaticData.getField("DonViTinh", "TenDonViTinh", "IDDonViTinh", IDDonViTinh);
            HTMLContent += "       <td>" + DonViTinh + "</td>";
            double SoXuat = double.Parse(table.Rows[0]["DonGiaXuat"].ToString());

            HTMLContent += "       <td>" + SoXuat.ToString("#,##").Replace(",", ".") + "</td>";
            double a = double.Parse(table.Rows[i]["SoLuong"].ToString());

            HTMLContent += "       <td>" + a.ToString("#,##").Replace(",", ".") + "</td>";
           
           






            double ThanhTien = SoXuat * a;

            HTMLContent += "<td>" + ThanhTien.ToString("#,##").Replace(",", ".") + "</td>";
            //  DataTable gc = Connect.GetTable("select GhiChu from ChiTietPhieuXuat where IDChiTietPhieuXuat=" + table.Rows[i]["IDChiTietPhieuXuat"].ToString() + "");
            HTMLContent += "       <td>&nbsp;</td>";
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
             <td>&nbsp;</td>
        </tr>
        <tr>
                 <td colspan='2' style='text-align: center;'><b>ĐẠI DIỆN BÊN NHẬN HÀNG</b></td> 
           
            <td>&nbsp;</td>
            <td >&nbsp;</td>
            <td>&nbsp;</td>
             <td>&nbsp;</td>
            <td><b>ĐẠI DIỆN BÊN GIAO HÀNG</b></td>
           
        </tr>
        <tr>
             <td style='text-align: center;' colspan='2'>Người nhận hàng</td> 
       
            <td>&nbsp;</td>
            <td >&nbsp;</td>
            <td>&nbsp;</td>
<td>&nbsp;</td>
            <td style='text-align: center;'>Người giao hàng</td>
      
        </tr>

</table>          
";
       

      /*  string FileName = "BienBanGiaoHangMot";
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
        Response.End();*/

      /*  Response.AppendHeader("content-disposition", "attachment;filename=BienBanGiaoHangMot.xls");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        this.EnableViewState = false;
        Response.Write(HTMLContent);
        Response.End();*/
    }
    protected void TC_Click(object sender, EventArgs e)
    {
        Response.Redirect("BaoCaoChiTietNhapHang.aspx");
    }
}