using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QuanLyDungCu_DanhMucNhapHang_CapNhat : System.Web.UI.Page
{
    string pIDPhieuNhap = "";
    string Page = "";
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
            if (Request.QueryString["IDPhieuNhap"].Trim() != "")
            {
                pIDPhieuNhap = StaticData.ValidParameter(Request.QueryString["IDPhieuNhap"].Trim());

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
                if (Request.QueryString["IDPhieuNhap"].Trim() != "")
                {
                    pIDPhieuNhap = StaticData.ValidParameter(Request.QueryString["IDPhieuNhap"].Trim());

                }
            }
            catch { }
            try
            {
                Page = StaticData.ValidParameter(Request.QueryString["Page"].Trim());
            }
            catch
            { }
            LoadLoaiHangHoa();
            LoadLoaiHangCapCao();
            if(pIDPhieuNhap.Length > 0)
            {
                LoadPhieuNhap(); LoadHangHoa();
            }
            else
            {
                Response.Redirect("DanhMucNhapHang.aspx");
            }
           
        }
    }
    private void LoadLoaiHangCapCao()
    {
        string strSql = "select * from Kho";
        txtIDKho.DataSource = Connect.GetTable(strSql);
        txtIDKho.DataTextField = "TenKho";
        txtIDKho.DataValueField = "IDKho";
        txtIDKho.DataBind();



        //slLoaiHangCapCao.DataSource = Connect.GetTable(strSql);
        //slLoaiHangCapCao.DataTextField = "TenLoaiHangCapCao";
        //slLoaiHangCapCao.DataValueField = "IDLoaiHangCapCao";
        //slLoaiHangCapCao.DataBind();
        //slLoaiHangCapCao.Items.Add(new ListItem("", ""));
        //slLoaiHangCapCao.Items.FindByText("").Selected = true;
    }
    private void LoadLoaiHangHoa()
    {
        //string strSql = "select * from LoaiHangHoa";
        //slLoaiHangHoa.DataSource = Connect.GetTable(strSql);
        //slLoaiHangHoa.DataTextField = "TenLoaiHangHoa";
        //slLoaiHangHoa.DataValueField = "IDLoaiHangHoa";
        slLoaiHangHoa.DataBind();
        //  txtDVT.Items.Add(new ListItem("", ""));
        // slQuyen.Items.FindByText("-- Tất cả --").Selected = true;
    }
    private void LoadHangHoa()
    {
       /* string strSql = "select * from HangHoa";
        txtTenHangHoa.DataSource = Connect.GetTable(strSql);
        txtTenHangHoa.DataTextField = "TenHangHoa";
        txtTenHangHoa.DataValueField = "MaHangHoa";
        txtTenHangHoa.DataBind();
        txtTenHangHoa.Items.Add(new ListItem("", ""));
        txtTenHangHoa.Items.FindByText("").Selected = true;*/
    }
    private void LoadPhieuNhap()
    {
        if (pIDPhieuNhap != "")
        {
            string sql = " select * from PhieuNhap where IDPhieuNhap = " + pIDPhieuNhap + "";
            DataTable table = Connect.GetTable(sql);
            if (table.Rows.Count > 0)
            {

                txtMaPhieuNhap.Value = table.Rows[0]["MaPhieuNhap"].ToString();
                txtNgayNhap.Value = DateTime.Parse(table.Rows[0]["NgayNhap"].ToString()).ToString("dd/MM/yyyy");
              
                txtGhiChu.Value = table.Rows[0]["GhiChu"].ToString();
                txtIDNCC.Value = table.Rows[0]["IDNhaCungCap"].ToString();
                txtTenNCC.Value = StaticData.getField("NhaCungCap", "TenNhaCungCap", "IDNhaCungCap", table.Rows[0]["IDNhaCungCap"].ToString());
                txtIDKho.Value = table.Rows[0]["IDKho"].ToString();
                txtKho.Value = StaticData.getField("Kho", "TenKho", "IDKho", table.Rows[0]["IDKho"].ToString());

                if(table.Rows[0]["TienDaThanhToan"].ToString().Trim() == "0")
                {
                    txtTienDaThanhToan.Value = "0";
                }
                else
                {
                    txtTienDaThanhToan.Value = double.Parse(table.Rows[0]["TienDaThanhToan"].ToString().Trim()).ToString("#,##").Replace(",", ".");
                }
                txtMaPhieuNhap.Disabled = true;
                //txtNgayNhapChiTiet.Value = DateTime.Parse(table.Rows[0]["NgayNhap"].ToString()).ToString("dd/MM/yyyy");

            }
        }
    }

    protected void btLuu_Click(object sender, EventArgs e)
    {
        string MaPhieuNhap = txtMaPhieuNhap.Value.Trim();
        string GhiChu = txtGhiChu.Value.Trim();
        string NgayNhap = txtNgayNhap.Value.Trim();
        string TenNCC = txtTenNCC.Value.Trim();
        string IDNCC = txtIDNCC.Value.Trim();
        string TenKho = txtKho.Value.Trim();
        string IDKho = txtIDKho.Value.Trim();
        string TienDaThanhToan = txtTienDaThanhToan.Value.Trim().Replace(",", "").Replace(".", "");
        if (TienDaThanhToan.Length <= 0)
        {
            Response.Write("<script>alert('Tiền thanh toán không được trống, nếu không có hãy nhập 0 !')</script>");
            return;
        }
        if (MyStaticData.KiemTraSo(TienDaThanhToan) == false)
        {
            Response.Write("<script>alert('Tiền thanh toán phải là số, nếu không có hãy nhập 0 !')</script>");
            return;
        }
        if (NgayNhap.Length <= 0)
        {
            Response.Write("<script>alert('Ngày tạo phiếu nhập không được trống !')</script>");
            return;
        }
        if (MaPhieuNhap.Length <= 0)
        {
            Response.Write("<script>alert(' mã phiếu nhập không được trống !')</script>");
            return;
        }
        DataTable a = Connect.GetTable("select MaPhieuNhap from PhieuNhap where MaPhieuNhap = N'" + MaPhieuNhap + "' and IDPhieuNhap <> "+pIDPhieuNhap+"");
        if (a.Rows.Count > 0)
        {
            Response.Write("<script>alert('Lỗi mã phiếu nhập này đã được dùng !')</script>");
            return;
        }
        if (TenNCC.Length <= 0 || IDNCC.Length <= 0)
        {
            Response.Write("<script>alert('Hãy chọn nhà cung cấp !')</script>");
            return;
        }
        if (IDKho.Length <= 0)
        {
            Response.Write("<script>alert('Hãy chọn Kho !')</script>");
            return;
        }
        string sql = "update PhieuNhap set MaPhieuNhap=N'" + MaPhieuNhap + "',NgayNhap='" + StaticData.ConvertDDMMtoMMDD(NgayNhap) + "',GhiChu = N'" + GhiChu + "',IDKho=" + IDKho + ",IDNhaCungCap=" + IDNCC + ",TienDaThanhToan="+TienDaThanhToan+" where IDPhieuNhap = " + StaticData.ValidParameter(Request.QueryString["IDPhieuNhap"].Trim()) + "";
        bool kq = Connect.Exec(sql);
        if (kq)
        {
            string sql2 = "insert into BangLog(TaiKhoan,ThaoTac,NgayGio) values (N'" + Request.Cookies["BanSiQuanAo_Login"].Value.Trim() + "',N'Sửa phiếu nhập hàng " + MaPhieuNhap + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "')";
            bool kq2 = Connect.Exec(sql2);
            if (Page.Length > 0)
                Response.Redirect("DanhMucNhapHang.aspx?Page=" + Page);
            else
            {
                Response.Redirect("DanhMucNhapHang.aspx");
            }
        }
        else
        {
            Response.Write("<script>alert('Lỗi internet!')</script>");
            return;
        }
    }
    protected void btHuy_Click(object sender, EventArgs e)
    {
        if (Page.Length > 0)
            Response.Redirect("DanhMucNhapHang.aspx?Page=" + Page);
        else
        {
            Response.Redirect("DanhMucNhapHang.aspx");
        }
    }
}