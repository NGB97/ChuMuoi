using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DanhMuc_DonViTinh_CapNhat : System.Web.UI.Page
{
    string pIDDonViTinh = "";
    string Page = "";
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
            if (Request.QueryString["IDDonViTinh"].Trim() != "")
            {
                pIDDonViTinh = StaticData.ValidParameter(Request.QueryString["IDDonViTinh"].Trim());

            }
        }
        catch { }
        try
        {
            Page = StaticData.ValidParameter(Request.QueryString["Page"].Trim());
        }
        catch
        { }
        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["IDDonViTinh"].Trim() != "")
                {
                    pIDDonViTinh = StaticData.ValidParameter(Request.QueryString["IDDonViTinh"].Trim());

                }
            }
            catch { }
            try
            {
                Page = StaticData.ValidParameter(Request.QueryString["Page"].Trim());
            }
            catch { }

            if (Page.Length > 0 && pIDDonViTinh.Length > 0)
            {
                LoadThongDVT();
            }
        }
    }
    private void LoadThongDVT()
    {
        if (pIDDonViTinh != "")
        {
            string sql = "select * from DonViTinh where IDDonViTinh =" + pIDDonViTinh + "";
            DataTable table = Connect.GetTable(sql);
            if (table.Rows.Count > 0)
            {
                dvTitle.InnerHtml = "SỬA THÔNG TIN ĐƠN VỊ TÍNH";
                btLuu.Text = "SỬA";
             //   txtMaDonViTinh.Value = table.Rows[0]["MaSize"].ToString();
                txtTenDonViTinh.Value = table.Rows[0]["TenDonViTinh"].ToString();
              
                txtGhiChu.Value = table.Rows[0]["GhiChu"].ToString();

            }
        }
    }
    protected void btLuu_Click(object sender, EventArgs e)
    {
        if (pIDDonViTinh.Length <= 0)
        {
          //  string MaDonViTinh = txtMaDonViTinh.Value.Trim();
            string TenDonViTinh = txtTenDonViTinh.Value.Trim();
            string GhiChu = txtGhiChu.Value.Trim();
          
            //if (MaDonViTinh.Length <= 0)
            //{
            //    Response.Write("<script>alert('Không bỏ trống mã size !')</script>");
            //    return;
            //}

            if (TenDonViTinh.Length <= 0)
            {
                Response.Write("<script>alert('Không bỏ trống tên đơn vị tính !')</script>");
                return;
            }
            DataTable a = Connect.GetTable("SELECT * FROM DonViTinh where TenDonViTinh = N'" + TenDonViTinh + "'");
            if (a.Rows.Count > 0)
            {
                Response.Write("<script>alert('Bạn nhập đơn vị tính đã tồn tại !')</script>");
                return;
            }
            string sql = "insert into DonViTinh values(N'" + TenDonViTinh + "',N'" + GhiChu + "')";
            bool kq = Connect.Exec(sql);
            if (kq)
            {
                Response.Redirect("DVT.aspx");
            }
            else
            {
                Response.Write("<script>alert('Lỗi  !')</script>");
                return;
            }
        }
        else
        {
           // string MaDonViTinh = txtMaDonViTinh.Value.Trim();
            string TenDonViTinh = txtTenDonViTinh.Value.Trim();
            string GhiChu = txtGhiChu.Value.Trim();
          
            //if (MaDonViTinh.Length <= 0)
            //{
            //    Response.Write("<script>alert('Không bỏ trống mã size !')</script>");
            //    return;
            //}
         
            if (TenDonViTinh.Length <= 0)
            {
                Response.Write("<script>alert('Không bỏ trống tên đơn vị tính !')</script>");
                return;
            }
            DataTable a = Connect.GetTable("SELECT * FROM DonViTinh where TenDonViTinh = N'" + TenDonViTinh + "' and IDDonViTinh <> " + pIDDonViTinh + " ");
            if (a.Rows.Count > 0)
            {
                Response.Write("<script>alert('Bạn nhập tên đơn vị tính đã tồn tại !')</script>");
                return;
            }
            string sql = " update DonViTinh set TenDonViTinh = N'" + TenDonViTinh + "', GhiChu = N'" + GhiChu + "' where IDDonViTinh = " + pIDDonViTinh + "";
            bool kq = Connect.Exec(sql);
            if (kq)
            {
                if (Page.Length > 0)
                    Response.Redirect("DVT.aspx?Page=" + Page);
                else Response.Redirect("DVT.aspx");
            }
            else
            {
                Response.Write("<script>alert('Lỗi mã đơn vị tính này đã được sử dụng !')</script>");
                return;
            }
        }
    }
    protected void btHuy_Click(object sender, EventArgs e)
    {
        if(Page.Length > 0)
            Response.Redirect("DVT.aspx?Page=" + Page);
        else Response.Redirect("DVT.aspx");
    }
}