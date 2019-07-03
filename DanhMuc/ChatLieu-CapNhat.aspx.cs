using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DanhMuc_DonViTinh_CapNhat : System.Web.UI.Page
{
    string pIDChatLieu = "";
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
            if (Request.QueryString["IDChatLieu"].Trim() != "")
            {
                pIDChatLieu = StaticData.ValidParameter(Request.QueryString["IDChatLieu"].Trim());

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
                if (Request.QueryString["IDChatLieu"].Trim() != "")
                {
                    pIDChatLieu = StaticData.ValidParameter(Request.QueryString["IDChatLieu"].Trim());

                }
            }
            catch { }
            try
            {
                Page = StaticData.ValidParameter(Request.QueryString["Page"].Trim());
            }
            catch { }

            if (Page.Length > 0 && pIDChatLieu.Length > 0)
            {
                LoadThongDVT();
            }
        }
    }
    private void LoadThongDVT()
    {
        if (pIDChatLieu != "")
        {
            string sql = "select * from ChatLieu where IDChatLieu =" + pIDChatLieu + "";
            DataTable table = Connect.GetTable(sql);
            if (table.Rows.Count > 0)
            {
                dvTitle.InnerHtml = "SỬA THÔNG TIN KIỂU DÁNG";
                btLuu.Text = "SỬA";
                txtMaChatLieu.Value = table.Rows[0]["MaChatLieu"].ToString();
                txtTenChatLieu.Value = table.Rows[0]["TenChatLieu"].ToString();
              
                txtGhiChu.Value = table.Rows[0]["GhiChu"].ToString();

            }
        }
    }
    protected void btLuu_Click(object sender, EventArgs e)
    {
        if (pIDChatLieu.Length <= 0)
        {
            string MaChatLieu = txtMaChatLieu.Value.Trim();
            string TenChatLieu = txtTenChatLieu.Value.Trim();
            string GhiChu = txtGhiChu.Value.Trim();
          
            if (MaChatLieu.Length <= 0)
            {
                Response.Write("<script>alert('Không bỏ trống mã kiểu dáng !')</script>");
                return;
            }
            DataTable a = Connect.GetTable("SELECT * FROM ChatLieu where MaChatLieu = N'" + MaChatLieu + "'");
            if (a.Rows.Count > 0)
            {
                Response.Write("<script>alert('Bạn nhập mã kiểu dáng đã tồn tại !')</script>");
                return;
            }
            if (TenChatLieu.Length <= 0)
            {
                Response.Write("<script>alert('Không bỏ trống tên kiểu dáng !')</script>");
                return;
            }

            string sql = "insert into ChatLieu values(N'" + MaChatLieu + "',N'" + TenChatLieu + "',N'" + GhiChu + "')";
            bool kq = Connect.Exec(sql);
            if (kq)
            {
                Response.Redirect("ChatLieu.aspx");
            }
            else
            {
                Response.Write("<script>alert('Lỗi  !')</script>");
                return;
            }
        }
        else
        {
            string MaChatLieu = txtMaChatLieu.Value.Trim();
            string TenChatLieu = txtTenChatLieu.Value.Trim();
            string GhiChu = txtGhiChu.Value.Trim();
          
            if (MaChatLieu.Length <= 0)
            {
                Response.Write("<script>alert('Không bỏ trống mã kiểu dáng !')</script>");
                return;
            }
            DataTable a = Connect.GetTable("SELECT * FROM ChatLieu where MaChatLieu = N'" + MaChatLieu + "' and IDChatLieu <> " + pIDChatLieu + " ");
            if (a.Rows.Count > 0)
            {
                Response.Write("<script>alert('Bạn nhập mã kiểu dáng đã tồn tại !')</script>");
                return;
            }
            if (TenChatLieu.Length <= 0)
            {
                Response.Write("<script>alert('Không bỏ trống tên kiểu dáng !')</script>");
                return;
            }

            string sql = " update ChatLieu set MaChatLieu = N'" + MaChatLieu + "',TenChatLieu = N'" + TenChatLieu + "', GhiChu = N'" + GhiChu + "' where IDChatLieu = " + pIDChatLieu + "";
            bool kq = Connect.Exec(sql);
            if (kq)
            {
                if (Page.Length > 0)
                    Response.Redirect("ChatLieu.aspx?Page=" + Page);
                else Response.Redirect("ChatLieu.aspx");
            }
            else
            {
                Response.Write("<script>alert('Lỗi mã kiểu dáng này đã được sử dụng !')</script>");
                return;
            }
        }
    }
    protected void btHuy_Click(object sender, EventArgs e)
    {
        if(Page.Length > 0)
        Response.Redirect("ChatLieu.aspx?Page="+Page);
        else Response.Redirect("ChatLieu.aspx");
    }
}