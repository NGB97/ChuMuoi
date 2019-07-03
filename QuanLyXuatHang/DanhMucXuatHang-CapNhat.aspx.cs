using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QuanLyDungCu_DanhMucXuatHang_CapNhat : System.Web.UI.Page
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
           
            NgayTieuDe.InnerHtml=" <a href='DanhMucXuatHang.aspx'  ><i class='fa fa-step-backward'></i> Danh sách bán hàng</a> ";
            QuayLai.InnerHtml = " <a class='btn btn-primary btn-flat' href='DanhMucXuatHang.aspx'  ><i class='glyphicon glyphicon-chevron-left'></i>Quay lại</a> ";
            
            DataTable a = Connect.GetTable("SELECT max(IDPhieuXuat)+1 FROM [PhieuXuat]");

            string Ma = "PBH" + "-" + a.Rows[0][0].ToString().Trim() + "-" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
            txtMaPhieuXuat.Value = Ma;
            txtMaPhieuXuat.Disabled = true;
            LoadLoaiHangCapCao();
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
        string KhachHang = txtKhachHang.Value.Trim();
        string IDKhachHang = txtIDKhachHang.Value.Trim();
        string MaPhieuXuat = txtMaPhieuXuat.Value.Trim();
        string GhiChu = txtGhiChu.Value.Trim();
        string NgayXuat = txtNgayXuat.Value.Trim();
        string TienThanhToan = txtTienKhachThanhToan.Value.Trim().Replace(",", "").Replace(".", "");
        string TenKho = txtKho.Value.Trim();
        string IDKho = txtIDKho.Value.Trim();
        if (IDKho.Length <= 0)
        {
            Response.Write("<script>alert('Hãy chọn kho !')</script>");
            return;
        }
        if (KhachHang.Length <= 0 || IDKhachHang.Length <= 0)
        {
            Response.Write("<script>alert('Hãy chọn khách !')</script>");
            return;
        }
        if (TienThanhToan.Length <= 0)
        {
            Response.Write("<script>alert('Tiền thanh toán không được trống, nếu không thì hãy nhập = 0 !')</script>");
            return;
        }
        if (MyStaticData.KiemTraSo(TienThanhToan) == false)
        {
            Response.Write("<script>alert('Tiền thanh toán phải là số tự nhiên !')</script>");
            return;
        }
        if (NgayXuat.Length <= 0)
        {
            Response.Write("<script>alert('Ngày lập phiếu không được trống !')</script>");
            return;
        }
        if (MaPhieuXuat.Length <= 0)
        {
            Response.Write("<script>alert(' mã phiếu không được trống !')</script>");
            return;
        }
        DataTable a = Connect.GetTable("select MaPhieuXuat from PhieuXuat where MaPhieuXuat = N'" + MaPhieuXuat + "'");
        if (a.Rows.Count > 0)
        {
            Response.Write("<script>alert('Lỗi mã phiếu này đã được dùng !')</script>");
            return;
        }
      

        string sql = "insert into PhieuXuat(MaPhieuXuat,NgayXuat,GhiChu,idKhachHang,TienThanhToan,idKho) values(N'" + MaPhieuXuat + "','" + StaticData.ConvertDDMMtoMMDD(NgayXuat) + "',N'"+GhiChu+"',"+IDKhachHang+","+TienThanhToan+","+IDKho+")";
        bool kq = Connect.Exec(sql);
        if (kq)
        {
            string sql2 = "insert into BangLog(TaiKhoan,ThaoTac,NgayGio) values (N'" + Request.Cookies["BanSiQuanAo_Login"].Value.Trim() + "',N'Thêm mới phiếu xuất " + MaPhieuXuat + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "')";
            bool kq2 = Connect.Exec(sql2);

            string IDPhieuXuat = StaticData.getFieldCoDau("PhieuXuat", "IDPhieuXuat", "MaPhieuXuat", MaPhieuXuat);
            Response.Redirect("DanhMucXuatHangSua.aspx?IDPhieuXuat=" + IDPhieuXuat);
        }
        else
        {
            Response.Write("<script>alert('Lỗi !')</script>");
            return;
        }
    }
    protected void btHuy_Click(object sender, EventArgs e)
    {
        Response.Redirect("DanhMucXuatHang.aspx");
    }
}