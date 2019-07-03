using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QuanLyDungCu_DanhMucNhapHang_CapNhat : System.Web.UI.Page
{
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
        
        if (!IsPostBack)
        {
            DataTable a = Connect.GetTable("SELECT max(IDPhieuNhap)+1 FROM [PhieuNhap]");

            string Ma ="PTH"+"-"+ a.Rows[0][0].ToString().Trim()+"-" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
            txtMaPhieuNhap.Value = Ma;
            txtMaPhieuNhap.Disabled = true;
            LoadLoaiHangCapCao();
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
    protected void btLuu_Click(object sender, EventArgs e)
    {
        string MaPhieuNhap = txtMaPhieuNhap.Value.Trim();
        string GhiChu = txtGhiChu.Value.Trim();
        string NgayNhap = txtNgayNhap.Value.Trim();
        string TenNCC = txtTenNCC.Value.Trim();
        string IDNCC = txtIDNCC.Value.Trim();
        string TenKho = txtKho.Value.Trim();
        string IDKho = txtIDKho.Value.Trim();
        string TienDaThanhToan = txtTienDaThanhToan.Value.Trim().Replace(",", "").Replace(".","");
        if (TienDaThanhToan.Length <= 0)
        {
            Response.Write("<script>alert('Tiền thanh toán không được trống, nếu không có hãy nhập 0 !')</script>");
            return;
        }
        if(MyStaticData.KiemTraSo(TienDaThanhToan) == false)
        {
            Response.Write("<script>alert('Tiền thanh toán phải là số, nếu không có hãy nhập 0 !')</script>");
            return;
        }
        if (NgayNhap.Length <= 0)
        {
            Response.Write("<script>alert('Ngày tạo phiếu trả không được trống !')</script>");
            return;
        }
        if (MaPhieuNhap.Length <= 0)
        {
            Response.Write("<script>alert('Mã phiếu trả không được trống !')</script>");
            return;
        }
        DataTable a = Connect.GetTable("select MaPhieuNhap from PhieuNhap where MaPhieuNhap = N'"+MaPhieuNhap+"'");
        if(a.Rows.Count > 0)
        {
            Response.Write("<script>alert('Lỗi, mã phiếu trả này đã được dùng !')</script>");
            return;
        }
           if(TenNCC.Length <= 0 || IDNCC.Length <= 0)
           {
               Response.Write("<script>alert('Hãy chọn khách hàng !')</script>");
               return;
           }
           if ( IDKho.Length <= 0)
           {
               Response.Write("<script>alert('Hãy chọn kho !')</script>");
               return;
           }
           string sql = "insert into PhieuNhap(MaPhieuNhap,NgayNhap,GhiChu,idKhachHang_TraHang,idKho,TienDaThanhToan,LoaiPhieuNhap) values (N'" + MaPhieuNhap + "','" + StaticData.ConvertDDMMtoMMDD(NgayNhap) + "',N'" + GhiChu + "'," + IDNCC + "," + IDKho + "," + TienDaThanhToan + ",'TraHang')";
        bool kq = Connect.Exec(sql);
        if (kq)
        {
            string sql2 = "insert into BangLog(TaiKhoan,ThaoTac,NgayGio) values (N'" + Request.Cookies["BanSiQuanAo_Login"].Value.Trim() + "',N'Thêm mới phiếu trả hàng " + MaPhieuNhap + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "')";
            bool kq2 = Connect.Exec(sql2);
            string IDPhieuNhap = StaticData.getFieldCoDau("PhieuNhap", "IDPhieuNhap", "MaPhieuNhap", MaPhieuNhap);
            Response.Redirect("DanhMucNhapHangSua.aspx?IDPhieuNhap=" + IDPhieuNhap);
        }
        else
        {
            Response.Write("<script>alert('Lỗi !')</script>");
            return;
        }

    }
    protected void btHuy_Click(object sender, EventArgs e)
    {
       
            Response.Redirect("DanhMucNhapHang.aspx");
        
    }
}