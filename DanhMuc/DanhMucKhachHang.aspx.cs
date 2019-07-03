using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DanhMuc_DanhMucKhachHang : System.Web.UI.Page
{
    string pMaKhachHang = "";
    string pTenKhachHang = "";
    string pCapDaiLy = "";
    string pSoDienThoai = "";

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
        if (Request.Cookies["BanSiQuanAo_Login"] != null && Request.Cookies["BanSiQuanAo_Login"].Value.Trim() != "")
        {
            if (Request.Cookies["BanSiQuanAo_Quyen"] != null && Request.Cookies["BanSiQuanAo_Quyen"].Value.Trim() != "")
            {
                string Quyen = Request.Cookies["BanSiQuanAo_Quyen"].Value.Trim();
                if (Quyen.CompareTo("Admin") == 0 || Quyen.CompareTo("NhanVien") == 0)
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
                if (Request.QueryString["MaKhachHang"].Trim() != "")
                {
                    pMaKhachHang = StaticData.ValidParameter(Request.QueryString["MaKhachHang"].Trim());
                    txtMaKhachHang.Value = pMaKhachHang;
                }
            }
            catch { }
            try
            {
                if (Request.QueryString["CapDaiLy"].Trim() != "")
                {
                    pCapDaiLy = StaticData.ValidParameter(Request.QueryString["CapDaiLy"].Trim());
                    //slCapDaiLy.Value = pCapDaiLy;
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
                if (Request.QueryString["SoDienThoai"].Trim() != "")
                {
                    pSoDienThoai = StaticData.ValidParameter(Request.QueryString["SoDienThoai"].Trim());
                    txtSoDienThoai.Value = pSoDienThoai;

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

        sql += "select count(*) from KhachHang where '1' = '1' ";

        if (pMaKhachHang != "")
            sql += " and MaKhachHang like N'%" + pMaKhachHang + "%'";
        if (pSoDienThoai != "")
            sql += " and DienThoai like N'%" + pSoDienThoai + "%'";
      
        if (pTenKhachHang != "")
            sql += " and TenKhachHang like N'%" + pTenKhachHang + "%'";
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
        sql += @"select * from( SELECT ROW_NUMBER() OVER(ORDER BY TenKhachHang asc)AS RowNumber,* FROM KhachHang where '1'='1'";
        if (pMaKhachHang != "")
            sql += " and MaKhachHang like N'%" + pMaKhachHang + "%'";
        if (pSoDienThoai != "")
            sql += " and DienThoai like N'%" + pSoDienThoai + "%'";
      
        if (pTenKhachHang != "")
            sql += " and TenKhachHang like N'%" + pTenKhachHang + "%'";

        sql += " ) as tb1 ";
        sql += " WHERE RowNumber BETWEEN (" + Page + " - 1) * " + PageSize + " + 1 AND (((" + Page + " - 1) * " + PageSize + " + 1) + " + PageSize + ") - 1";

        DataTable table = Connect.GetTable(sql);

        SetPage();

        string html = @" <table class='table table-bordered table-striped'>
                    <tr>
                        <th class='th' style='text-align:center'>
                          STT
                        </th>
                        <th class='th' style='text-align:center'>
                         Mã khách hàng
                        </th>
                        <th class='th' style='text-align:center'>
                          Tên khách hàng
                        </th>
                        <th class='th' style='text-align:center'>
                         Số điện thoại
                        </th>
                        <th class='th' style='text-align:center'>
                         Loại khách hàng
                        </th>
                        <th class='th' style='text-align:center'>
                        Số tài khoản
                        </th>
                        <th class='th' style='text-align:center'>
                         Mã số thuế
                        </th>
                        <th class='th' style='text-align:center'>
                         Email
                        </th>
                        <th class='th' style='text-align:center'>
                         Địa chỉ
                        </th>
                       <th class='th' style='text-align:center'>
                         Ghi chú		
                        </th>
                        <th class='th'>
                        </th>
                        <th class='th'>
                        </th>

                    </tr>";
        // double SoTienPhaiThu = 0;
        for (int i = 0; i < table.Rows.Count; i++)
        {
            html += "       <tr style='text-align:center'>";
            html += "       <td>" + (((Page - 1) * PageSize) + i + 1).ToString() + "</td>";


            html += "       <td>" + table.Rows[i]["MaKhachHang"].ToString() + "</td>";

            html += "       <td>" + table.Rows[i]["TenKhachHang"].ToString() + "</td>";

           
            html += "       <td>" + table.Rows[i]["DienThoai"].ToString().Trim() + "</td>";
            html += "       <td>" + table.Rows[i]["LoaiKhachHang"].ToString().Trim() + "</td>";
            html += "       <td>" + table.Rows[i]["SoTaiKhoan"].ToString().Trim() + "</td>";
            html += "       <td>" + table.Rows[i]["MaSoThue"].ToString().Trim() + "</td>";
            html += "       <td>" + table.Rows[i]["Email"].ToString().Trim() + "</td>";
            html += "       <td>" + table.Rows[i]["DiaChi"].ToString().Trim() + "</td>";
            html += "       <td>" + table.Rows[i]["GhiChu"].ToString().Trim().Replace("\n","<br />") + "</td>";
           
            html += " <td style='text-align:center;font-size: 100%;'><a href='#' onclick='window.location=\"DanhMucKhachHang-CapNhat.aspx?Page=" + Page.ToString() + "&IDKhachHang=" + table.Rows[i]["IDKhachHang"].ToString() + "\"'><img title='Sửa' class='imgCommand' src='../Images/edit.png' onclick='window.location=\"DanhMucKhachHang-CapNhat.aspx?Page=" + Page.ToString() + "&IDKhachHang=" + table.Rows[i]["IDKhachHang"].ToString() + "\"' /> Sửa </a></td>";
            html += " <td style='text-align:center;font-size: 100%;'><a href='#' onclick='DeleteKhachHang(\"" + table.Rows[i]["IDKhachHang"].ToString() + "\")'><img title='Xóa' class='imgCommand' src='../Images/delete.png' onclick='DeleteKhachHang(\"" + table.Rows[i]["IDKhachHang"].ToString() + "\")' />Xóa</a></td>";
            //html += " <td style='text-align:center;font-size: 100%;'><a href='#' onclick='rsGiaTheoKhach(\"" + table.Rows[i]["IDKhachHang"].ToString() + "\");'><i class='fa fa-refresh fa-2x'></i>XGiá </a> </td>";
            html += "       </tr>";

        }
        html += "   <tr>";
        html += "       <td colspan='12' class='footertable'>";
        string url = "DanhMucKhachHang.aspx?";
        if (pMaKhachHang != "")
            url += "MaKhachHang=" + pMaKhachHang + "&";
        if (pSoDienThoai != "")
            url += "SoDienThoai=" + pSoDienThoai + "&";
       
        if (pTenKhachHang != "")
            url += "TenKhachHang=" + pTenKhachHang + "&";

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
        string MaKhachHang = txtMaKhachHang.Value.Trim();
        string SoDienThoai = txtSoDienThoai.Value.Trim();
     
       
        string TenKhachHang = txtTenKhachHang.Value.Trim();
        string url = "DanhMucKhachHang.aspx?";
        if (MaKhachHang != "")
            url += "MaKhachHang=" + MaKhachHang + "&";
        if (SoDienThoai != "")
            url += "SoDienThoai=" + SoDienThoai + "&";
     
        if (TenKhachHang != "")
            url += "TenKhachHang=" + TenKhachHang + "&";
        Response.Redirect(url);
    }
    protected void btTatCa_Click(object sender, EventArgs e)
    {
      

        string url = "DanhMucKhachHang.aspx?";
       

        Response.Redirect(url);
    }
}