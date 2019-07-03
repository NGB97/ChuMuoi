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
public partial class BaoCao_BaoCaoXuatNhapTon : System.Web.UI.Page
{
    string pMaHangHoa = "";
   // string pTenHangHoa = "";
    string pNgayDauKy = "";
    string pNgayCuoiKy = "";
    string pTenHangHoa = "";
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
                if (Request.QueryString["TenHangHoa"].Trim() != "")
                {
                    pTenHangHoa = StaticData.ValidParameter(Request.QueryString["TenHangHoa"].Trim());
                    txtTenHangHoa.Value = pTenHangHoa;
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
        string sql = "select count(*) from HangHoa where '1'='1' ";
        if (pTenHangHoa != "")
            sql += " and TenHangHoa like N'%" + pTenHangHoa + "%'";
      //  sql += "select HangHoa.MaHangHoa,HangHoa.TenHangHoa,ChiTietPhieuXuat.NgayXuatChiTiet,ChiTietPhieuNhap.NgayNhapChiTiet,ISNULL(SUM(ChiTietPhieuNhap.SoLuong),0) as 'SoLuongNhap',ISNULL(SUM(ChiTietPhieuNhap.DonGiaNhap),0) as 'DonGiaNhap',ISNULL(SUM(ChiTietPhieuXuat.SoLuong),0) as 'SoLuongXuat',ISNULL(SUM(ChiTietPhieuXuat.DonGiaXuat),0) as 'DonGiaXuat',ChiTietPhieuXuat.IDChiTietPhieuXuat from HangHoa ,ChiTietPhieuNhap,ChiTietPhieuXuat where ChiTietPhieuNhap.IDHangHoa = HangHoa.IDHangHoa and ChiTietPhieuXuat.IDHangHoa = HangHoa.IDHangHoa and ChiTietPhieuXuat.NgayXuatChiTiet is not null";
       /* if (pNgayDauKy != "")
            sql += " and ChiTietPhieuXuat.NgayXuatChiTiet >='" + StaticData.ConvertDDMMtoMMDD(pNgayDauKy) + " 00:00:00'";
        if (pNgayCuoiKy != "")
            sql += " and ChiTietPhieuXuat.NgayXuatChiTiet <='" + StaticData.ConvertDDMMtoMMDD(pNgayCuoiKy) + " 00:00:00'";*/
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
        sql += @"select * from(  select ROW_NUMBER() OVER(ORDER BY HangHoa.IDHangHoa desc)AS RowNumber,* from HangHoa where '1'='1' ";
        if (pTenHangHoa != "")
            sql += " and TenHangHoa like N'%" + pTenHangHoa + "%'";
     /*   if (pNgayDauKy != "")
            sql += " and ChiTietPhieuXuat.NgayXuatChiTiet >='" + StaticData.ConvertDDMMtoMMDD(pNgayDauKy) + " 00:00:00'";
        if (pNgayCuoiKy != "")
            sql += " and ChiTietPhieuXuat.NgayXuatChiTiet <='" + StaticData.ConvertDDMMtoMMDD(pNgayCuoiKy) + " 00:00:00'";*/

       // sql += "group by HangHoa.MaHangHoa,HangHoa.TenHangHoa,ChiTietPhieuXuat.NgayXuatChiTiet,ChiTietPhieuNhap.NgayNhapChiTiet,ChiTietPhieuXuat.IDChiTietPhieuXuat,HangHoa.IDHangHoa ";
        sql += "  ) as tb1";
        sql += " WHERE RowNumber BETWEEN (" + Page + " - 1) * " + PageSize2 + " + 1 AND (((" + Page + " - 1) * " + PageSize2 + " + 1) + " + PageSize2 + ") - 1";
        if (pNgayDauKy != "" && pNgayCuoiKy != "")
        {
            DataTable testNgay = Connect.GetTable("  SELECT DATEDIFF(day, '" + StaticData.ConvertDDMMtoMMDD(pNgayDauKy) + "', '" + StaticData.ConvertDDMMtoMMDD(pNgayCuoiKy) + "') AS DateDiff");
            double test = double.Parse(testNgay.Rows[0]["DateDiff"].ToString());
            if (test < 0)
            {
                Label2.Text = "Xin Nhập ngày đầu kỳ phải nhỏ hơn hoặc bằng ngày cuối kỳ để có kết quả chính xác";

            }
        }

        DataTable table = Connect.GetTable(sql);

        SetPage();

        string html = @" <table class='table table-bordered table-striped'>
                  <tr>
                        <th class='th' rowspan='2' style='text-align: center;'>
                       SỐ TT
                        </th>
                        
                        <th class='th' rowspan='2' style='text-align: center;'>
                        Mã vạch 
                        </th>
                        <th class='th' rowspan='2' style='text-align: center;'>
                        Mã hàng 
                        </th>
                        <th class='th' rowspan='2' style='text-align: center;'>
                         Tên hàng 
                        </th>
                        <th class='th' rowspan='2' style='text-align: center;'>
                        ĐVT
                        </th>
                         
                        <th class='th' rowspan='2' style='text-align: center;'>
                         KIỂM KÊ ĐẦU KỲ
                        </th>
                         <th class='th' colspan='3' style='text-align: center;'>
                          SỐ LƯỢNG
                        </th>
                      
                      
                       
                    </tr>
                     <tr>
                       <th class='th' style='text-align: center;'>NHẬP KHO</td>
                        <th class='th' style='text-align: center;'>XUẤT</td>
                        <th class='th' style='text-align: center;'>TỒN KHO</td>
                    </tr>

                   ";
        // double SoTienPhaiThu = 0;
        for (int i = 0; i < table.Rows.Count; i++)
        {
            html += "       <tr >";
            html += "       <td style='text-align: center;'>" + (((Page - 1) * PageSize2) + i + 1).ToString() + "</td>";


           // html += "       <td>" + DateTime.Parse(table.Rows[i]["NgayXuatChiTiet"].ToString()).ToString("dd/MM/yyyy") + "</td>";
            html += "       <td style='text-align: center;'>" + table.Rows[i]["MaVach"].ToString() + "</td>";
            html += "       <td style='text-align: center;'>" + table.Rows[i]["MaHangHoa"].ToString() + "</td>";
            html += "       <td style='text-align: center;'>" + table.Rows[i]["TenHangHoa"].ToString() + "</td>";
            html += "       <td style='text-align: center;'>" + StaticData.getField("DonViTinh", "TenDonViTinh", "IDDonViTinh", StaticData.getField("HangHoa", "IDDonViTinh", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString())) + "</td>";
     
            double kk = 0;
            if (pNgayDauKy != "")
            {
                DataTable sn = Connect.GetTable("select isnull(SUM(SoLuong),0) as 'sn' from ChiTietPhieuNhap where IDHangHoa=" + table.Rows[i]["IDHangHoa"].ToString() + " and ChiTietPhieuNhap.NgayNhapChiTiet <= '" + StaticData.ConvertDDMMtoMMDD(pNgayDauKy) + "'");
                DataTable sz = Connect.GetTable("select isnull(SUM(SoLuong),0) as 'sx' from ChiTietPhieuXuat where IDHangHoa=" + table.Rows[i]["IDHangHoa"].ToString() + " and ChiTietPhieuXuat.NgayXuatChiTiet <= '" + StaticData.ConvertDDMMtoMMDD(pNgayDauKy) + "'");

                double a = double.Parse(sn.Rows[0]["sn"].ToString());
                double b = double.Parse(sz.Rows[0]["sx"].ToString());
                kk = a - b;
            }
            if(kk > 0)
                html += "       <td style='text-align: center;'>" + kk.ToString("#,##").Replace(",", ".") + "</td>";
            else html += "       <td style='text-align: center;'>0</td>";



           // DataTable dongx = Connect.GetTable("select isnull(SUM(DonGiaXuat*SoLuong),0) as 'dgx' from ChiTietPhieuXuat where IDHangHoa=" + table.Rows[i]["IDHangHoa"].ToString() + " and ChiTietPhieuXuat.NgayXuatChiTiet >= '" + StaticData.ConvertDDMMtoMMDD(pNgayDauKy) + "' and ChiTietPhieuXuat.NgayXuatChiTiet <= '" + StaticData.ConvertDDMMtoMMDD(pNgayCuoiKy) + "'");
           // double dongx2 = double.Parse(dongx.Rows[0]["dgx"].ToString());
            
            string sqlsln ="select isnull(SUM(SoLuong),0) as 'sn' from ChiTietPhieuNhap where IDHangHoa=" + table.Rows[i]["IDHangHoa"].ToString()+"";
            if (pNgayDauKy != "")
            {
                sqlsln += " and ChiTietPhieuNhap.NgayNhapChiTiet >= '" + StaticData.ConvertDDMMtoMMDD(pNgayDauKy) + "'";

            }
            if (pNgayCuoiKy != "")
            {
                 sqlsln +=" and ChiTietPhieuNhap.NgayNhapChiTiet <= '" + StaticData.ConvertDDMMtoMMDD(pNgayCuoiKy) + "'";
            }
            DataTable sln = Connect.GetTable(sqlsln);
            double SoNhap = double.Parse(sln.Rows[0]["sn"].ToString());

            string sqlslx = "select isnull(SUM(SoLuong),0) as 'sx' from ChiTietPhieuXuat where IDHangHoa=" + table.Rows[i]["IDHangHoa"].ToString() + "";
            if (pNgayDauKy != "")
            {
                sqlslx += " and ChiTietPhieuXuat.NgayXuatChiTiet >= '" + StaticData.ConvertDDMMtoMMDD(pNgayDauKy) + "'";
            }
            if (pNgayCuoiKy != "")
            {
                sqlslx += " and ChiTietPhieuXuat.NgayXuatChiTiet <= '" + StaticData.ConvertDDMMtoMMDD(pNgayCuoiKy) + "'";
            }
            DataTable slz = Connect.GetTable(sqlslx);
            double SoXuat = double.Parse(slz.Rows[0]["sx"].ToString());
            double Ton = SoNhap - SoXuat;
            if (SoNhap > 0)
            {
                html += "       <td style='text-align: center;'><a href='#' onclick='window.location=\"BaoCaoChiTietNhapHang.aspx?TenHangHoa=" + table.Rows[i]["TenHangHoa"].ToString() + "&TuNgayNhap=" + pNgayDauKy + "&DenNgayNhap=" + pNgayCuoiKy + "&" + "\"'>" + SoNhap.ToString("#,##").Replace(",", ".") + "</a></td>";
            }
            else
            {
               /* DataTable sln2 = Connect.GetTable("select isnull(SUM(SoLuong),0) as 'sn' from ChiTietPhieuNhap where IDHangHoa=" + table.Rows[i]["IDHangHoa"].ToString()  + "");
                double SoNhap2 = double.Parse(sln2.Rows[0]["sn"].ToString());
                if (SoNhap2.ToString("#,##").Replace(",", ".").Trim() != "")
                html += "       <td>" + SoNhap2.ToString("#,##").Replace(",", ".") + "</td>";*/
                html += "       <td style='text-align: center;'>0</td>";
            }
            if (SoXuat > 0)
                html += "       <td style='text-align: center;'><a href='#' onclick='window.location=\"BaoCaoChiTietXuatHang.aspx?TenHangHoa=" + table.Rows[i]["TenHangHoa"].ToString() + "&TuNgayXuat=" + pNgayDauKy + "&DenNgayXuat=" + pNgayCuoiKy + "&" + "\"'>" + SoXuat.ToString("#,##").Replace(",", ".") + "</a></td>";
            else
            {
               /* DataTable slz2 = Connect.GetTable("select isnull(SUM(SoLuong),0) as 'sx' from ChiTietPhieuXuat where IDHangHoa=" + table.Rows[i]["IDHangHoa"].ToString() + "");
                double SoXuat2 = double.Parse(slz2.Rows[0]["sx"].ToString());
                if (SoXuat2.ToString("#,##").Replace(",", ".").Trim() != "")
                html += "       <td>" + SoXuat2.ToString("#,##").Replace(",", ".") + "</td>";*/
                html += "       <td style='text-align: center;'>0</td>";
            }
            if (Ton > 0)
            {
                html += "       <td style='text-align: center;'>" + Ton.ToString("#,##").Replace(",", ".") + "</td>";
            }
            else
            {
              /*  DataTable sln22 = Connect.GetTable("select isnull(SUM(SoLuong),0) as 'sn' from ChiTietPhieuNhap where IDHangHoa=" + table.Rows[i]["IDHangHoa"].ToString() + "");
                double SoNhap22 = double.Parse(sln22.Rows[0]["sn"].ToString());
                DataTable slz22 = Connect.GetTable("select isnull(SUM(SoLuong),0) as 'sx' from ChiTietPhieuXuat where IDHangHoa=" + table.Rows[i]["IDHangHoa"].ToString() + "");
                double SoXuat22 = double.Parse(slz22.Rows[0]["sx"].ToString());
                if ((SoNhap22 - SoXuat22).ToString("#,##").Replace(",", ".").Trim() != "")
                html += "       <td>" + (SoNhap22 - SoXuat22).ToString("#,##").Replace(",", ".") + "</td>";*/
                html += "       <td style='text-align: center;'>0</td>";
            }
          //  double DonGiaXuat = double.Parse(table.Rows[i]["DonGiaXuat"].ToString());
          //  double ThanhTien = SoXuat * DonGiaXuat;
          /*  if(dongx2>0)
            html += "       <td>" + dongx2.ToString("#,##").Replace(",", ".") + "</td>";
            else html += "       <td>0</td>";*/
           // DataTable gc = Connect.GetTable("select GhiChu from ChiTietPhieuXuat where IDChiTietPhieuXuat=" + table.Rows[i]["IDChiTietPhieuXuat"].ToString() + "");
           // html += "       <td>&nbsp;</td>";
            html+="     </tr>";

        }
        html += "   <tr>";
        html += "       <td colspan='12' class='footertable'>";
        string url = "XNT.aspx?";
        if (pTenHangHoa != "")
            url += "TenHangHoa="+pTenHangHoa+"&";
    
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
        string TenHangHoa = txtTenHangHoa.Value.Trim();
        string url = "XNT.aspx?";
        if (NgayDauKy != "")
            url += "NgayDauKy=" + NgayDauKy + "&";
        if (NgayCuoiKy != "")
            url += "NgayCuoiKy=" + NgayCuoiKy + "&";
        if (TenHangHoa != "")
            url += "TenHangHoa=" + TenHangHoa + "&";
        Response.Redirect(url);
    }
    protected void btTatCa_Click(object sender, EventArgs e)
    {
        string sql = "";
        sql += @"select * from(  select ROW_NUMBER() OVER(ORDER BY HangHoa.IDHangHoa desc)AS RowNumber,* from HangHoa where '1'='1' ";
        if (txtTenHangHoa.Value.Trim() != "")
            sql += " and TenHangHoa like N'%" + txtTenHangHoa.Value.Trim() + "%'";

        // sql += "group by HangHoa.MaHangHoa,HangHoa.TenHangHoa,ChiTietPhieuXuat.NgayXuatChiTiet,ChiTietPhieuNhap.NgayNhapChiTiet,ChiTietPhieuXuat.IDChiTietPhieuXuat,HangHoa.IDHangHoa ";
        sql += "  ) as tb1";
    

        DataTable table = Connect.GetTable(sql);

        string HTMLContent = "<html><body encoding=" + BaseFont.IDENTITY_H + " style='font-family:Arial;font-size:10;'><u><b>CÔNG TY CỔ PHẦN VIỄN LIÊN</b></u>";

        HTMLContent += "<div style='text-align:center; padding-bottom:20px height:auto; overflow:hidden'><br /><h2><b>BÁO CÁO XUẤT NHẬP TỒN</b></h2></div>";

        HTMLContent += @"             
                   <table border='1' >
                          <tr>
                         <td style='text-align: center;' rowspan='2'   ><b>SỐ TT</b></td>                       
                        <td  style='text-align: center;' rowspan='2'  ><b>Mã vạch </b></td>
                        <td style='text-align: center;' rowspan='2' ><b>Mã hàng</b> </td>
                        <td style='text-align: center;' rowspan='2' ><b>Tên hàng</b> </td>
                        <td style='text-align: center;' rowspan='2' ><b>ĐVT</b></td>                         
                        <td  style='text-align: center;' rowspan='2'><b>KIỂM KÊ ĐẦU KỲ</b></td>                      
                        <td style='text-align: center;' colspan='3'><b>SỐ LƯỢNG</b></td>
                         <td style='text-align: center;' rowspan='2'><b>DIỄN GIẢI</b></td>
                        <td style='text-align: center;' rowspan='2'><b>GHI CHÚ</b></td>
                     </tr>
                        <tr>    
                            <td><b>NHẬP KHO</b></td><td><b>XUẤT</b> </td><td><b>TỒN KHO</b></td>
                        </tr>
                    ";
        for (int i = 0; i < table.Rows.Count; i++)
        {
            HTMLContent += "       <tr >";
            HTMLContent += "       <td style='text-align: center;'>" + (i + 1).ToString() + "</td>";


            HTMLContent += "       <td style='text-align: center;'>" + table.Rows[i]["MaVach"].ToString() + "</td>";
            HTMLContent += "       <td style='text-align: center;'>" + table.Rows[i]["MaHangHoa"].ToString() + "</td>";
            HTMLContent += "       <td>" + table.Rows[i]["TenHangHoa"].ToString() + "</td>";
            HTMLContent += "       <td style='text-align: center;'>" + StaticData.getField("DonViTinh", "TenDonViTinh", "IDDonViTinh", StaticData.getField("HangHoa", "IDDonViTinh", "IDHangHoa", table.Rows[i]["IDHangHoa"].ToString())) + "</td>";

            double kk = 0;
            if (txtNgayDauKy.Value.Trim() != "")
            {

                DataTable sn = Connect.GetTable("select isnull(SUM(SoLuong),0) as 'sn' from ChiTietPhieuNhap where IDHangHoa=" + table.Rows[i]["IDHangHoa"].ToString() + " and ChiTietPhieuNhap.NgayNhapChiTiet <= '" + StaticData.ConvertDDMMtoMMDD(txtNgayDauKy.Value.Trim()) + "'");
                DataTable sz = Connect.GetTable("select isnull(SUM(SoLuong),0) as 'sx' from ChiTietPhieuXuat where IDHangHoa=" + table.Rows[i]["IDHangHoa"].ToString() + " and ChiTietPhieuXuat.NgayXuatChiTiet <= '" + StaticData.ConvertDDMMtoMMDD(txtNgayDauKy.Value.Trim()) + "'");

                double a = double.Parse(sn.Rows[0]["sn"].ToString());
                double b = double.Parse(sz.Rows[0]["sx"].ToString());
                kk = a - b;
            }
            if (kk > 0)
                HTMLContent += "       <td style='text-align: center;'>" + kk.ToString("#,##").Replace(",", ".") + "</td>";
            else HTMLContent += "       <td style='text-align: center;'>0</td>";



            string sqlsln = "select isnull(SUM(SoLuong),0) as 'sn' from ChiTietPhieuNhap where IDHangHoa=" + table.Rows[i]["IDHangHoa"].ToString() + "";
            if (txtNgayDauKy.Value.Trim() != "")
            {
                sqlsln += " and ChiTietPhieuNhap.NgayNhapChiTiet >= '" + StaticData.ConvertDDMMtoMMDD(txtNgayDauKy.Value.Trim()) + "'";

            }
            if (txtNgayCuoiKy.Value.Trim() != "")
            {
                sqlsln += " and ChiTietPhieuNhap.NgayNhapChiTiet <= '" + StaticData.ConvertDDMMtoMMDD(txtNgayCuoiKy.Value.Trim()) + "'";
            }
            DataTable sln = Connect.GetTable(sqlsln);
            double SoNhap = double.Parse(sln.Rows[0]["sn"].ToString());

            string sqlslx = "select isnull(SUM(SoLuong),0) as 'sx' from ChiTietPhieuXuat where IDHangHoa=" + table.Rows[i]["IDHangHoa"].ToString() + "";
            if (txtNgayDauKy.Value.Trim() != "")
            {
                sqlslx += " and ChiTietPhieuXuat.NgayXuatChiTiet >= '" + StaticData.ConvertDDMMtoMMDD(txtNgayDauKy.Value.Trim()) + "'";
            }
            if (txtNgayCuoiKy.Value.Trim() != "")
            {
                sqlslx += " and ChiTietPhieuXuat.NgayXuatChiTiet <= '" + StaticData.ConvertDDMMtoMMDD(txtNgayCuoiKy.Value.Trim()) + "'";
            }
            DataTable slz = Connect.GetTable(sqlslx);
            double SoXuat = double.Parse(slz.Rows[0]["sx"].ToString());
            double Ton = SoNhap - SoXuat;
            if (SoNhap > 0)
            {
                HTMLContent += "       <td style='text-align: center;'>" + SoNhap.ToString("#,##").Replace(",", ".") + "</td>";
            }
            else
            {
                /* DataTable sln2 = Connect.GetTable("select isnull(SUM(SoLuong),0) as 'sn' from ChiTietPhieuNhap where IDHangHoa=" + table.Rows[i]["IDHangHoa"].ToString()  + "");
                 double SoNhap2 = double.Parse(sln2.Rows[0]["sn"].ToString());
                 if (SoNhap2.ToString("#,##").Replace(",", ".").Trim() != "")
                 HTMLContent += "       <td>" + SoNhap2.ToString("#,##").Replace(",", ".") + "</td>";*/
                HTMLContent += "       <td style='text-align: center;'>0</td>";
            }
            if (SoXuat > 0)
                HTMLContent += "       <td style='text-align: center;'>" + SoXuat.ToString("#,##").Replace(",", ".") + "</td>";
            else
            {
                /* DataTable slz2 = Connect.GetTable("select isnull(SUM(SoLuong),0) as 'sx' from ChiTietPhieuXuat where IDHangHoa=" + table.Rows[i]["IDHangHoa"].ToString() + "");
                 double SoXuat2 = double.Parse(slz2.Rows[0]["sx"].ToString());
                 if (SoXuat2.ToString("#,##").Replace(",", ".").Trim() != "")
                 HTMLContent += "       <td>" + SoXuat2.ToString("#,##").Replace(",", ".") + "</td>";*/
                HTMLContent += "       <td style='text-align: center;'>0</td>";
            }
            if (Ton > 0)
            {
                HTMLContent += "       <td style='text-align: center;'>" + Ton.ToString("#,##").Replace(",", ".") + "</td>";
            }
            else
            {
                /*  DataTable sln22 = Connect.GetTable("select isnull(SUM(SoLuong),0) as 'sn' from ChiTietPhieuNhap where IDHangHoa=" + table.Rows[i]["IDHangHoa"].ToString() + "");
                  double SoNhap22 = double.Parse(sln22.Rows[0]["sn"].ToString());
                  DataTable slz22 = Connect.GetTable("select isnull(SUM(SoLuong),0) as 'sx' from ChiTietPhieuXuat where IDHangHoa=" + table.Rows[i]["IDHangHoa"].ToString() + "");
                  double SoXuat22 = double.Parse(slz22.Rows[0]["sx"].ToString());
                  if ((SoNhap22 - SoXuat22).ToString("#,##").Replace(",", ".").Trim() != "")
                  HTMLContent += "       <td>" + (SoNhap22 - SoXuat22).ToString("#,##").Replace(",", ".") + "</td>";*/
                HTMLContent += "       <td style='text-align: center;'>0</td>";
            }
            HTMLContent += "       <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>";
            HTMLContent += "       <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>";
            HTMLContent += "     </tr>";

        }



        HTMLContent += "</table></body></html>";
       

       //string FileName = "BaoCaoXuatNhapTon";
       // System.IO.StringWriter stringWrite = new System.IO.StringWriter();
       // Response.AppendHeader("Content-Type", "application/pdf");
       // Response.AppendHeader("Content-disposition", "attachment; filename=" + FileName + ".pdf");
       // Response.Cache.SetCacheability(HttpCacheability.NoCache);

       // stringWrite.WriteLine(HTMLContent);

       // HtmlTextWriter hw = new HtmlTextWriter(stringWrite);
       // StringReader sr = new StringReader(stringWrite.ToString());
       // Document pdfDoc = new Document(PageSize.A4, 20f, 10f, 10f, 0f);
       // HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
       // PdfWriter wi = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
       // pdfDoc.Open();

       // //string fontpath = Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + "\\ARIALUNI.TTF";        //  "ARIALUNI.TTF" file copied from fonts folder and placed in the folder
       // string fontpath = "http://vienlien.lamphanmem.com/Fonts/ARIALUNI.TTF";        //  "ARIALUNI.TTF" file copied from fonts folder and placed in the folder
       // BaseFont bf = BaseFont.CreateFont(fontpath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
       // FontFactory.RegisterDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), true);
       // FontFactory.Register(fontpath, "Arial Unicode MS");

       // //string path = System.Web.HttpContext.Current.Server.MapPath("~/Fonts/ArialUni.TFF");
       // //iTextSharp.text.Font fnt = new iTextSharp.text.Font();
       // //FontFactory.Register(path, "Arial Unicode MS");
       // //fnt = FontFactory.GetFont("Arial Unicode MS", BaseFont.IDENTITY_H, BaseFont.EMBEDDED, 10, Font.NORMAL);


       // htmlparser.Parse(sr);
       // pdfDoc.Close();
       // Response.Write(pdfDoc);
       // Response.End();
        Response.AppendHeader("content-disposition", "attachment;filename=XuatNhapTon.xls");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        this.EnableViewState = false;
        Response.Write(HTMLContent);
        Response.End();
    }
    protected void TC_Click(object sender, EventArgs e)
    {
        Response.Redirect("XNT.aspx");
    }
}