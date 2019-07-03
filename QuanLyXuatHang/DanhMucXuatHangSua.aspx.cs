using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class QuanLyXuatNhap_DanhMucXuatHangSua : System.Web.UI.Page
{
    string pIDPhieuXuat = "";
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
            if (Request.QueryString["IDPhieuXuat"].Trim() != "")
            {
                pIDPhieuXuat = StaticData.ValidParameter(Request.QueryString["IDPhieuXuat"].Trim());

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
            NgayTieuDe.InnerHtml = " <a href='DanhMucXuatHang.aspx?TuNgayXuat=" + DateTime.Now.ToString("dd/MM/yyyy") + "&DenNgayXuat=" + DateTime.Now.ToString("dd/MM/yyyy") + "&'  ><i class='fa fa-step-backward'></i> Danh sách bán hàng</a> ";
           // QuayLai.InnerHtml = " <a class='btn btn-primary btn-flat' href='DanhMucXuatHang.aspx?TuNgayXuat=" + DateTime.Now.ToString("dd/MM/yyyy") + "&DenNgayXuat=" + DateTime.Now.ToString("dd/MM/yyyy") + "&'  ><i class='glyphicon glyphicon-chevron-left'></i>Quay lại</a> ";
            
            try
            {
                if (Request.QueryString["IDPhieuXuat"].Trim() != "")
                {
                    pIDPhieuXuat = StaticData.ValidParameter(Request.QueryString["IDPhieuXuat"].Trim());

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
            if (pIDPhieuXuat.Length > 0)
            {
                LoadPhieuXuat(); 
            }
            else
            {
                Response.Redirect("DanhMucXuatHang.aspx");
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
        //  txtDVT.Items.Add(new ListItem("", ""));
        // slQuyen.Items.FindByText("-- Tất cả --").Selected = true;

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
        //slLoaiHangHoaCapCao.DataSource = Connect.GetTable(strSql);
        //slLoaiHangHoaCapCao.DataTextField = "TenLoaiHangHoa";
        //slLoaiHangHoaCapCao.DataValueField = "IDLoaiHangHoa";
        //slLoaiHangHoaCapCao.DataBind();
        //  txtDVT.Items.Add(new ListItem("", ""));
        // slQuyen.Items.FindByText("-- Tất cả --").Selected = true;
    }
    private void LoadPhieuXuat()
    {
        if (pIDPhieuXuat != "")
        {
            string sql = " select * from PhieuXuat where IDPhieuXuat = " + pIDPhieuXuat + "";
            DataTable table = Connect.GetTable(sql);
            if (table.Rows.Count > 0)
            {

                txtMaPhieuXuat.Value = table.Rows[0]["MaPhieuXuat"].ToString();
                txtMaPhieuXuat.Disabled = true;
                txtNgayXuat.Value = DateTime.Parse(table.Rows[0]["NgayXuat"].ToString()).ToString("dd/MM/yyyy");

                txtGhiChu.Value = table.Rows[0]["GhiChu"].ToString();
                if (table.Rows[0]["TienThanhToan"].ToString() == "0")
                    txtTienKhachThanhToan.Value = "0";
                else txtTienKhachThanhToan.Value = double.Parse(table.Rows[0]["TienThanhToan"].ToString()).ToString("#,##").Replace(",", ".");
                txtIDKhachHang.Value = table.Rows[0]["IDKhachHang"].ToString();
                txtKhachHang.Value = StaticData.getField("KhachHang", "TenKhachHang", "IDKhachHang", table.Rows[0]["IDKhachHang"].ToString());
                txtIDKho.Value = table.Rows[0]["IDKho"].ToString().Trim();
                txtKho.Value = StaticData.getField("Kho", "TenKho", "IDKho", table.Rows[0]["IDKho"].ToString().Trim());


                string sql2 = "";

                sql2 += "  select isnull(sum(DonGiaXuat*SoLuong),0) as 'Tong' from ChiTietPhieuXuat where ChiTietPhieuXuat.IDPhieuXuat = " + pIDPhieuXuat + " ";

                DataTable table2 = Connect.GetTable(sql2);

                double TongTienDonHang = double.Parse(table2.Rows[0]["Tong"].ToString());

                double ConLai = MyStaticData.GetNoKhachHangNgoaiTruPhieuXuat(table.Rows[0]["IDKhachHang"].ToString(), pIDPhieuXuat) - MyStaticData.GetSoTienDaTraCuaKhachHang(table.Rows[0]["IDKhachHang"].ToString());
                if (ConLai == 0)
                {
                    txtTongTienKhachNo.Value = "0";
                }
                else
                {
                    txtTongTienKhachNo.Value = ConLai.ToString("#,##").Replace(",", ".");
                }

                double re = TongTienDonHang + ConLai;

                if (re == 0)
                {
                    txtTongTienPhaiTra.Value = "0";
                }
                else
                {
                    txtTongTienPhaiTra.Value = re.ToString("#,##").Replace(",", ".");
                }
                if (double.Parse(table.Rows[0]["TienThanhToan"].ToString()) <= 0)
                {
                    CongNo.Checked = true;
                    txtTienKhachThanhToan.Value = "0";
                }
                else
                {
                    ThanhToanTienMat.Checked = true;

                    txtTienKhachThanhToan.Value = TongTienDonHang.ToString("#,##").Replace(",", ".");
                }
            }
        }
    }
    protected void btHuy_Click(object sender, EventArgs e)
    {
        if (Page.Length > 0)
            Response.Redirect("DanhMucXuatHang.aspx?Page=" + Page + "&TuNgayXuat=" + DateTime.Now.ToString("dd/MM/yyyy") + "&DenNgayXuat=" + DateTime.Now.ToString("dd/MM/yyyy") + "&");
        else
        {
            Response.Redirect("DanhMucXuatHang.aspx?TuNgayXuat=" + DateTime.Now.ToString("dd/MM/yyyy") + "&DenNgayXuat=" + DateTime.Now.ToString("dd/MM/yyyy") + "&");
        }

    }
    protected void btLuu_Click(object sender, EventArgs e)
    {
       

        string MaPhieuXuat = txtMaPhieuXuat.Value.Trim();
        string GhiChu = txtGhiChu.Value.Trim();
        string NgayXuat = txtNgayXuat.Value.Trim();
        string TenKho = txtKho.Value.Trim();
        string IDKho = txtIDKho.Value.Trim();
        string TienThanhToan = txtTienKhachThanhToan.Value.Trim().Replace(",", "").Replace(".", "");
        if ( IDKho.Length <= 0)
        {
            Response.Write("<script>alert('Hãy chọn kho !')</script>");
            return;
        }
        if (NgayXuat.Length <= 0)
        {
            Response.Write("<script>alert('Ngày lập phiếu xuất không được trống !')</script>");
            return;
        }
        string[] p = NgayXuat.Split('/');
        NgayXuat = p[2] + "/" + p[1] + "/" + p[0];

        if (MaPhieuXuat.Length <= 0)
        {
            Response.Write("<script>alert(' mã phiếu xuất không được trống !')</script>");
            return;
        }
        DataTable a = Connect.GetTable("select MaPhieuXuat from PhieuXuat where MaPhieuXuat = N'" + MaPhieuXuat + "' and IDPhieuXuat <> " + Request.QueryString["IDPhieuXuat"].Trim() + " ");
        if (a.Rows.Count > 0)
        {
            Response.Write("<script>alert('Lỗi mã phiếu xuất này đã được dùng !')</script>");
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
        string sql = "update PhieuXuat set TienThanhToan=" + TienThanhToan + ",IDKho=" + IDKho + ",MaPhieuXuat=N'" + MaPhieuXuat + "',NgayXuat='" + NgayXuat + "',GhiChu = N'" + GhiChu + "' where IDPhieuXuat = " + StaticData.ValidParameter(Request.QueryString["IDPhieuXuat"].Trim()) + "";
        bool kq = Connect.Exec(sql);
        if (kq)
        {
            string sql2 = "insert into BangLog(TaiKhoan,ThaoTac,NgayGio) values (N'" + Request.Cookies["BanSiQuanAo_Login"].Value.Trim() + "',N'Sửa thông tin phiếu xuất hàng " + MaPhieuXuat + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "')";
            bool kq2 = Connect.Exec(sql2);

            if (Page.Length > 0)
                Response.Redirect("DanhMucXuatHang.aspx?Page=" + Page + "&TuNgayXuat=" + DateTime.Now.ToString("dd/MM/yyyy") + "&DenNgayXuat=" + DateTime.Now.ToString("dd/MM/yyyy") + "&");
            else
            {
                Response.Redirect("DanhMucXuatHang.aspx?TuNgayXuat=" + DateTime.Now.ToString("dd/MM/yyyy") + "&DenNgayXuat=" + DateTime.Now.ToString("dd/MM/yyyy") + "&");
            }
        }
        else
        {
            Response.Write("<script>alert('Lỗi mã phiếu này đã dùng rồi!')</script>");
            return;
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        string MaPhieuXuat = txtMaPhieuXuat.Value.Trim();
        string GhiChu = txtGhiChu.Value.Trim();
        string NgayXuat = txtNgayXuat.Value.Trim();
        string TenKho = txtKho.Value.Trim();
        string IDKho = txtIDKho.Value.Trim();
        string TienThanhToan = txtTienKhachThanhToan.Value.Trim().Replace(",", "").Replace(".", "");
        if (IDKho.Length <= 0)
        {
            Response.Write("<script>alert('Hãy chọn kho !')</script>");
            return;
        }
        if (NgayXuat.Length <= 0)
        {
            Response.Write("<script>alert('Ngày lập phiếu xuất không được trống !')</script>");
            return;
        }
        string[] p = NgayXuat.Split('/');
        NgayXuat = p[2] + "/" + p[1] + "/" + p[0];

        if (MaPhieuXuat.Length <= 0)
        {
            Response.Write("<script>alert(' mã phiếu xuất không được trống !')</script>");
            return;
        }
        DataTable a = Connect.GetTable("select MaPhieuXuat from PhieuXuat where MaPhieuXuat = N'" + MaPhieuXuat + "' and IDPhieuXuat <> " + Request.QueryString["IDPhieuXuat"].Trim() + " ");
        if (a.Rows.Count > 0)
        {
            Response.Write("<script>alert('Lỗi mã phiếu xuất này đã được dùng !')</script>");
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
        string sql = "update PhieuXuat set TienThanhToan=" + TienThanhToan + ",IDKho=" + IDKho + ",MaPhieuXuat=N'" + MaPhieuXuat + "',NgayXuat='" + NgayXuat + "',GhiChu = N'" + GhiChu + "' where IDPhieuXuat = " + StaticData.ValidParameter(Request.QueryString["IDPhieuXuat"].Trim()) + "";
        bool kq = Connect.Exec(sql);
        if (kq)
        {
            string sql2 = "insert into BangLog(TaiKhoan,ThaoTac,NgayGio) values (N'" + Request.Cookies["BanSiQuanAo_Login"].Value.Trim() + "',N'Sửa thông tin phiếu xuất hàng " + MaPhieuXuat + "','" + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + "')";
            bool kq2 = Connect.Exec(sql2);

            if (Page.Length > 0)
                Response.Redirect("DanhMucXuatHang.aspx?Page=" + Page + "&TuNgayXuat=" + DateTime.Now.ToString("dd/MM/yyyy") + "&DenNgayXuat=" + DateTime.Now.ToString("dd/MM/yyyy") + "&");
            else
            {
                Response.Redirect("DanhMucXuatHang.aspx?TuNgayXuat=" + DateTime.Now.ToString("dd/MM/yyyy") + "&DenNgayXuat=" + DateTime.Now.ToString("dd/MM/yyyy") + "&");
            }
        }
        else
        {
            Response.Write("<script>alert('Lỗi mã phiếu này đã dùng rồi!')</script>");
            return;
        }
    }
}