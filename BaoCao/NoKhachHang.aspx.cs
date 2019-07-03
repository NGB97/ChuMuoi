﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QuanLyDoiTra_DoiTra : System.Web.UI.Page
{
    string pMaPhieuNhap = "";
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
    int PageSize = MyStaticData.GetSoKH();
    protected void Page_Load(object sender, EventArgs e)
    {
        /*if (Session["QuanLyNhapXuatHang_Login"] != null && Session["QuanLyNhapXuatHang_Login"].ToString() != "")
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
        if (Request.Cookies["BanSiQuanAo_Login"] != null && Request.Cookies["BanSiQuanAo_Login"].Value.Trim() != "")
        {
            if (Request.Cookies["BanSiQuanAo_Quyen"] != null && Request.Cookies["BanSiQuanAo_Quyen"].Value.Trim() != "")
            {
                string Quyen = Request.Cookies["BanSiQuanAo_Quyen"].Value.Trim();
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
                if (Request.QueryString["TenHangHoa"].Trim() != "")
                {
                    pTenHangHoa = Request.QueryString["TenHangHoa"].Trim().ToString().Replace("\\", "");
                    txtTenHangHoa.Value = pTenHangHoa;
                }
            }
            catch { }
            try
            {
                if (Request.QueryString["MaPhieuNhap"].Trim() != "")
                {
                    pMaPhieuNhap = StaticData.ValidParameter(Request.QueryString["MaPhieuNhap"].Trim());
                    txtMaPhieuNhap.Value = pMaPhieuNhap;
                }
            }
            catch { }
            try
            {
                if (Request.QueryString["TuNgayNhap"].Trim() != "")
                {
                    pTuNgayNhap = StaticData.ValidParameter(Request.QueryString["TuNgayNhap"].Trim());
                    txtTuNgayNhap.Value = pTuNgayNhap;
                }
            }
            catch { }
            try
            {
                if (Request.QueryString["DenNgayNhap"].Trim() != "")
                {
                    pDenNgayNhap = StaticData.ValidParameter(Request.QueryString["DenNgayNhap"].Trim());
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
        string sql = "";

        sql += "select count(*)  from KhachHang where '1'='1' ";

        if (pMaPhieuNhap != "")
            sql += " and KhachHang.TenKhachHang like N'%" + pMaPhieuNhap + "%'";
        //if (pMaPhieuNhap != "")
        //    sql += " and PhieuNhap.MaPhieuNhap like N'%" + pMaPhieuNhap + "%'";
        //if (pTuNgayNhap != "")
        //    sql += " and ChiTietPhieuNhap.NgayNhapChiTiet >='" + StaticData.ConvertDDMMtoMMDD(pTuNgayNhap) + " 00:00:00'";
        //if (pDenNgayNhap != "")
        //    sql += " and ChiTietPhieuNhap.NgayNhapChiTiet <='" + StaticData.ConvertDDMMtoMMDD(pDenNgayNhap) + " 00:00:00'";
        DataTable tbTotalRows = Connect.GetTable(sql);
        //  Response.Write("<script>alert('"+tbTotalRows.Rows[0][0].ToString()+"')</script>");
        int TotalRows = int.Parse(tbTotalRows.Rows[0][0].ToString());
        if (TotalRows % PageSize == 0)
            MaxPage = TotalRows / PageSize;
        else
            MaxPage = TotalRows / PageSize + 1;
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
        sql += @"select * from( SELECT ROW_NUMBER() OVER(ORDER BY KhachHang.IDKhachHang desc)AS RowNumber,*  from KhachHang where '1'='1'  ";
        if (pMaPhieuNhap != "")
            sql += " and KhachHang.TenKhachHang like N'%" + pMaPhieuNhap + "%'";
        //if (pMaPhieuNhap != "")
        //    sql += " and PhieuNhap.MaPhieuNhap like N'%" + pMaPhieuNhap + "%'";
        //if (pTuNgayNhap != "")
        //    sql += " and ChiTietPhieuNhap.NgayNhapChiTiet >='" + StaticData.ConvertDDMMtoMMDD(pTuNgayNhap) + " 00:00:00'";
        //if (pDenNgayNhap != "")
        //    sql += " and ChiTietPhieuNhap.NgayNhapChiTiet <='" + StaticData.ConvertDDMMtoMMDD(pDenNgayNhap) + " 00:00:00'";
        sql += "  ) as tb1";
        string chuoi = @"
select isnull(sum(tb4.SoTienDaMua),0) as 'SoTienDaMua',isnull(sum(tb4.DaTra),0) as 'DaTra',isnull(sum(tb4.ConLai),0) as 'ConLai' from
(

select tb3.IDKhachHang,tb3.SoTienDaMua,tb3.TienThanhToan+tb3.SoTien as 'DaTra'
,tb3.SoTienDaMua-(tb3.TienThanhToan+tb3.SoTien) as 'ConLai'
from
(
select 
 tb2.IDKhachHang,(select isnull(sum(ChiTietPhieuXuat.SoLuong*ChiTietPhieuXuat.DonGiaXuat),0) from PhieuXuat,ChiTietPhieuXuat
where PhieuXuat.MaPhieuXuat not like N'%-XB' and PhieuXuat.IDPhieuXuat = ChiTietPhieuXuat.IDPhieuXuat and PhieuXuat.IDKhachHang = tb2.IDKhachHang) as 'SoTienDaMua',
(select isnull(sum(TienThanhToan),0) from PhieuXuat where PhieuXuat.MaPhieuXuat not like N'%-XB' and IDKhachHang=tb2.IDKhachHang) as 'TienThanhToan',
(select isnull(sum(SoTien),0) from PhieuTraNo where IDKhachHang=tb2.IDKhachHang) as 'SoTien'
from 
(" + sql + @") 
as tb2) as tb3 ) as tb4
";
        DataTable showTien = Connect.GetTable(chuoi);
        sql += " WHERE RowNumber BETWEEN (" + Page + " - 1) * " + PageSize + " + 1 AND (((" + Page + " - 1) * " + PageSize + " + 1) + " + PageSize + ") - 1";
        Label1.Text = @"select * from(select tb3.IDKhachHang,tb3.SoTienDaMua,tb3.TienThanhToan+tb3.SoTien as 'DaTra'
,tb3.SoTienDaMua-(tb3.TienThanhToan+tb3.SoTien) as 'ConLai'
from
(
select 
 tb2.IDKhachHang,(select isnull(sum(ChiTietPhieuXuat.SoLuong*ChiTietPhieuXuat.DonGiaXuat),0) from PhieuXuat,ChiTietPhieuXuat
where PhieuXuat.MaPhieuXuat not like N'%-XB' and PhieuXuat.IDPhieuXuat = ChiTietPhieuXuat.IDPhieuXuat and PhieuXuat.IDKhachHang = tb2.IDKhachHang) as 'SoTienDaMua',
(select isnull(sum(TienThanhToan),0) from PhieuXuat where PhieuXuat.MaPhieuXuat not like N'%-XB' and IDKhachHang=tb2.IDKhachHang) as 'TienThanhToan',
(select isnull(sum(SoTien),0) from PhieuTraNo where IDKhachHang=tb2.IDKhachHang) as 'SoTien'
from 
(" + sql + @") 
as tb2) as tb3) as tb4
order by tb4.ConLai desc";
        sql = Label1.Text;
        DataTable table = Connect.GetTable(sql);

        SetPage();

        string html = @" <table class='table table-bordered table-striped'>
                    <tr>
                        <th class='th'>
                          STT
                        </th>
                        <th class='th'>
                         Mã khách hàng
                        </th>
                        <th class='th'>
                         Tên khách hàng
                        </th>
                        <th class='th'>
                          Số tiền đã mua
                        </th>
                         <th class='th'>
                          Đã trả
                        </th>
                        <th class='th'>
                        Còn lại
                        </th>
                        
                          <th class='th'>
                        
                        </th>
                      
                    </tr>";
        //double[] mang = new double[table.Rows.Count];
        //for (int i = 0; i < table.Rows.Count; i++)
        //{

        //    double ConLai = MyStaticData.TongTienTrenPhieuXuatCuaKhach(table.Rows[i]["IDKhachHang"].ToString()) - MyStaticData.TongDaTraCuaKhach(table.Rows[i]["IDKhachHang"].ToString());
        //    mang[i] = ConLai;
        //}
         
        // for (int i = 0; i < mang.Length; i++)
        // {
        //     for (int j = 0; j < mang.Length; j++)
        //     {
        //         if(mang[i] > mang[j])
        //         {
        //             double temp = mang[i];
        //             mang[i] = mang[j];
        //             mang[j] = temp;
        //         }
        //     }
        // }
        //
       
             for (int i = 0; i < table.Rows.Count; i++)
             {
                  double ConLai = MyStaticData.TongTienTrenPhieuXuatCuaKhach(table.Rows[i]["IDKhachHang"].ToString()) - MyStaticData.TongDaTraCuaKhach(table.Rows[i]["IDKhachHang"].ToString());

                 

                      html += "       <tr>";
                      html += "       <td>" + (((Page - 1) * PageSize) + i + 1).ToString() + "</td>";


                      html += "       <td>" +StaticData.getField("KhachHang","MaKhachHang","IDKhachHang", table.Rows[i]["IDKhachHang"].ToString()) + "</td>";
                      html += "       <td><a href='PhieuTraNoKhachHang.aspx?TenKhachHang=" + StaticData.getField("KhachHang", "TenKhachHang", "IDKhachHang", table.Rows[i]["IDKhachHang"].ToString()) + "&'>" + StaticData.getField("KhachHang", "TenKhachHang", "IDKhachHang", table.Rows[i]["IDKhachHang"].ToString()) + "</a></td>";

                      if (table.Rows[i]["SoTienDaMua"].ToString().Trim() == "0")
                          html += "       <td>0</td>";
                      else html += "<td>" +double.Parse(table.Rows[i]["SoTienDaMua"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";
                      if (table.Rows[i]["DaTra"].ToString().Trim() == "0")
                          html += "       <td>0</td>";
                      else html += "<td>" + double.Parse(table.Rows[i]["DaTra"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";

                      if (table.Rows[i]["ConLai"].ToString().Trim() == "0")
                          html += "       <td>0</td>";
                      else html += "<td>" + double.Parse(table.Rows[i]["ConLai"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";
                      //if (MyStaticData.GetNoKhachHang(table.Rows[i]["IDKhachHang"].ToString()) == 0)
                      //{
                      //    html += "<td>0</td>"; html += "<td>0</td>";
                      //}
                      //else
                      ////{
                      //if (MyStaticData.TongDaTraCuaKhach(table.Rows[i]["IDKhachHang"].ToString()) == 0)
                      //    html += "<td>0</td>";
                      //else html += "<td>" + MyStaticData.TongDaTraCuaKhach(table.Rows[i]["IDKhachHang"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";



                      // double ConLai = MyStaticData.TongTienTrenPhieuXuatCuaKhach(table.Rows[i]["IDKhachHang"].ToString()) - MyStaticData.TongDaTraCuaKhach(table.Rows[i]["IDKhachHang"].ToString());

                      //if (ConLai == 0)
                      //{
                      //    html += "<td>0</td>";
                      //}
                      //else html += "<td>" + ConLai.ToString("#,##").Replace(",", ".") + "</td>";
                      // }
                      html += " <td style='text-align:center;font-size: 100%;'><a href='#' onclick='window.location=\"PhieuTraNoKhachHang-CapNhat.aspx?IDKhachHang=" + table.Rows[i]["IDKhachHang"].ToString() + "\"'>Thu nợ </a></td>";
                      //  html += " <td style='text-align:center;font-size: 100%;'><a href='#' onclick='DeleteHangHoa(\"" + table.Rows[i]["IDHangHoa"].ToString() + "\")'><img title='Xóa' class='imgCommand' src='../Images/delete.png' onclick='DeleteHangHoa(\"" + table.Rows[i]["IDHangHoa"].ToString() + "\")' />Xóa</a></td>";
                      html += "       </tr>";
                  

             
         }
        html += "   <tr>";
        html += "       <td colspan='9' class='footertable'>";
        string url = "NoKhachHang.aspx?";
        if (pTenHangHoa != "")
            url += "TenHangHoa=" + pTenHangHoa + "&";
        if (pMaPhieuNhap != "")
            url += "MaPhieuNhap=" + pMaPhieuNhap + "&";
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
        html += "<tr style='background-color:yellow;font-weight: bold;'>";
        html += "<td colspan='3' style='text-align:right;'><b>Tổng cộng</b></td>";
        if (showTien.Rows[0]["SoTienDaMua"].ToString().Trim() == "0")
        html += "<td>"+showTien.Rows[0]["SoTienDaMua"].ToString()+"</td>";
        else html += "<td>" +double.Parse( showTien.Rows[0]["SoTienDaMua"].ToString()).ToString("#,##").Replace(",",".") + "</td>";

        if (showTien.Rows[0]["DaTra"].ToString().Trim() == "0")
            html += "<td>" + showTien.Rows[0]["DaTra"].ToString() + "</td>";
        else html += "<td>" + double.Parse(showTien.Rows[0]["DaTra"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";

        if (showTien.Rows[0]["ConLai"].ToString().Trim() == "0")
            html += "<td>" + showTien.Rows[0]["ConLai"].ToString() + "</td>";
        else html += "<td>" + double.Parse(showTien.Rows[0]["ConLai"].ToString()).ToString("#,##").Replace(",", ".") + "</td>";

        html += "<td>&nbsp;</td>";
        html += "</tr>";
        html += "     </table>";

        dvNguoiDung.InnerHtml = html;
    }
    protected void btTimKiem_Click(object sender, EventArgs e)
    {
        string MaPhieuNhap = txtMaPhieuNhap.Value.Trim();
        string TuNgayNhap = txtTuNgayNhap.Value.Trim();
        string DenNgayNhap = txtDenNgayNhap.Value.Trim();
        string TenHangHoa = txtTenHangHoa.Value.Trim();
        string url = "NoKhachHang.aspx?";
        if (MaPhieuNhap != "")
            url += "MaPhieuNhap=" + MaPhieuNhap + "&";
        if (TuNgayNhap != "")
            url += "TuNgayNhap=" + TuNgayNhap + "&";
        if (DenNgayNhap != "")
            url += "DenNgayNhap=" + DenNgayNhap + "&";
        if (TenHangHoa != "")
            url += "TenHangHoa=" + TenHangHoa + "&";

        Response.Redirect(url);
    }
    protected void btTatCa_Click(object sender, EventArgs e)
    {
        string url = "NoKhachHang.aspx";
        Response.Redirect(url);
    }
}