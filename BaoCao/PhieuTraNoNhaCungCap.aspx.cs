﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DanhMuc_DanhMucKhachHangSanPham : System.Web.UI.Page
{
    
    string pTenKhachHang = "";
    string pTenSanPham = "";
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
    int PageSize = 10;
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
        if (!IsPostBack)
        {
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
            try
            {
                if (Request.QueryString["TenKhachHang"].Trim() != "")
                {
                    pTenKhachHang = StaticData.ValidParameter(Request.QueryString["TenKhachHang"].Trim());
                    txtTenKhachHang.Value = pTenKhachHang;
                }
            }
            catch { }

            try
            {
                if (Request.QueryString["TenSanPham"].Trim() != "")
                {
                    pTenSanPham = Request.QueryString["TenSanPham"].Trim().ToString().Replace("\\", ""); 
                    txtTenSanPham.Value = pTenSanPham;

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

        sql += "   select count(*)   from  PhieuTraNoNhaCungCap  where '1'='1' ";

        if (pTenKhachHang != "")
            sql += " and PhieuTraNoNhaCungCap.IDNhaCungCap in (select NhaCungCap.IDNhaCungCap from NhaCungCap where NhaCungCap.TenNhaCungCap like N'%" + pTenKhachHang + "%' ) ";
        if (pTenSanPham != "")
            sql += " and PhieuTraNoNhaCungCap.MaPhieuTraNoNhaCungCap like N'%" + pTenSanPham + "%'";
        if (pTuNgayNhap != "")
            sql += " and PhieuTraNoNhaCungCap.Ngay >='" + StaticData.ConvertDDMMtoMMDD(pTuNgayNhap) + " 00:00:00'";
        if (pDenNgayNhap != "")
            sql += " and PhieuTraNoNhaCungCap.Ngay <='" + StaticData.ConvertDDMMtoMMDD(pDenNgayNhap) + " 00:00:00'";
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
        sql += @"select * from( SELECT ROW_NUMBER() OVER(ORDER BY PhieuTraNoNhaCungCap.IDPhieuTraNoNhaCungCap desc)AS RowNumber,* from  PhieuTraNoNhaCungCap where '1'='1' ";
        if (pTenKhachHang != "")
            sql += " and PhieuTraNoNhaCungCap.IDNhaCungCap in (select NhaCungCap.IDNhaCungCap from NhaCungCap where NhaCungCap.TenNhaCungCap like N'%" + pTenKhachHang + "%' ) ";
        if (pTenSanPham != "")
            sql += " and PhieuTraNoNhaCungCap.MaPhieuTraNoNhaCungCap like N'%" + pTenSanPham + "%'";
        if (pTuNgayNhap != "")
            sql += " and PhieuTraNoNhaCungCap.Ngay >='" + StaticData.ConvertDDMMtoMMDD(pTuNgayNhap) + " 00:00:00'";
        if (pDenNgayNhap != "")
            sql += " and PhieuTraNoNhaCungCap.Ngay <='" + StaticData.ConvertDDMMtoMMDD(pDenNgayNhap) + " 00:00:00'";

        sql += "  ) as tb1";

        DataTable showTien = Connect.GetTable("select isnull(sum(tb2.SoTien),0) from ("+sql+") as tb2");
        sql += " WHERE RowNumber BETWEEN (" + Page + " - 1) * " + PageSize + " + 1 AND (((" + Page + " - 1) * " + PageSize + " + 1) + " + PageSize + ") - 1";

        DataTable table = Connect.GetTable(sql);

        SetPage();

        string html = @" <table class='table table-bordered table-striped'>
                    <tr>
                        <th class='th'>
                          STT
                        </th>
                        <th class='th'>
                         Mã phiếu trả
                        </th>
                        <th class='th'>
                          Ngày
                        </th>
                          <th class='th'>
                         Trả cho nhà cung cấp
                        </th>
                       <th class='th'>
                         Số tiền
                        </th>
                          <th class='th'>
                         Ghi chú
                        </th>

                        <th class='th'>
                           
                        </th>"
                        //<th class='th'>
                           
                        //</th>
                        +@"
                    </tr>";
        // double SoTienPhaiThu = 0;
        for (int i = 0; i < table.Rows.Count; i++)
        {
            html += "       <tr>";
            html += "       <td>" + (((Page - 1) * PageSize) + i + 1).ToString() + "</td>";


            html += "       <td>" + table.Rows[i]["MaPhieuTraNoNhaCungCap"].ToString() + "</td>";
          


            html += "       <td>" + DateTime.Parse(table.Rows[i]["Ngay"].ToString()).ToString("dd/MM/yyyy") + "</td>";
            html += "       <td>" + StaticData.getField("NhaCungCap", "TenNhaCungCap", "IDNhaCungCap", table.Rows[i]["IDNhaCungCap"].ToString().Trim()) + "</td>";
            string Gia = table.Rows[i]["SoTien"].ToString().Trim();
            if (Gia.Trim() == "0")
            {
                html += "<td>0</td>";
            }
            else 
            html += "<td>" + double.Parse(Gia).ToString("#,##").Replace(",", ".") + "</td>";

            html += "       <td>" + table.Rows[i]["GhiChu"].ToString().Replace("\n", "<br />") + "</td>";

            //html += " <td style='text-align:center;font-size: 100%;'><a href='#' onclick='window.location=\"PhieuTraNoNhaCungCap-CapNhat.aspx?Page=" + Page.ToString() + "&IDChiTietGiaTheoKhach=" + table.Rows[i]["IDPhieuTraNoNhaCungCap"].ToString() + "\"'><img title='Sửa' class='imgCommand' src='../Images/edit.png'  /> Sửa </a></td>";
            html += " <td style='text-align:center;font-size: 100%;'><a href='#' onclick='DeleteKhachHangSanPham(\"" + table.Rows[i]["IDPhieuTraNoNhaCungCap"].ToString() + "\")'><img title='Xóa' class='imgCommand' src='../Images/delete.png' />Xóa</a></td>";
            html += "       </tr>";

        }
        html += "   <tr>";
        html += "       <td colspan='12' class='footertable'>";
        string url = "PhieuTraNoNhaCungCap.aspx?";
        if (pTenKhachHang != "")
            url += "TenKhachHang=" + pTenKhachHang + "&";
        if (pTenSanPham != "")
            url += "TenSanPham=" + pTenSanPham + "&";
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
        html += "<td colspan='4' style='text-align:right;'>Tổng cộng</td>";
      
        if (showTien.Rows[0][0].ToString().Trim() == "0")
            html += "<td>0</td>";
        else html += "<td >" + double.Parse(showTien.Rows[0][0].ToString()).ToString("#,##").Replace(",",".") + "</td>";
        html += "<td>&nbsp;</td>"; html += "<td>&nbsp;</td>"; 
        //html += "<td>&nbsp;</td>";
        html += "</tr>";
        html += "     </table>";

        dvNguoiDung.InnerHtml = html;
    }
    protected void btTimKiem_Click(object sender, EventArgs e)
    {
        string TenKhachHang = txtTenKhachHang.Value.Trim();
        string TenSanPham = txtTenSanPham.Value.Trim();
        string TuNgayNhap = txtTuNgayNhap.Value.Trim();
        string DenNgayNhap = txtDenNgayNhap.Value.Trim();
        string url = "PhieuTraNoNhaCungCap.aspx?";
        if (TenKhachHang != "")
            url += "TenKhachHang=" + TenKhachHang + "&";
        if (TenSanPham != "")
            url += "TenSanPham=" + TenSanPham + "&";
        if (TuNgayNhap != "")
            url += "TuNgayNhap=" + TuNgayNhap + "&";
        if (DenNgayNhap != "")
            url += "DenNgayNhap=" + DenNgayNhap + "&";
        Response.Redirect(url);
    }
    protected void btTatCa_Click(object sender, EventArgs e)
    {
        Response.Redirect("PhieuTraNoNhaCungCap.aspx");
    }
}