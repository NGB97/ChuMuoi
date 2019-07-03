using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DanhMuc_DanhMucKhachHang_CapNhat : System.Web.UI.Page
{
    string pIDKhachHang = "";
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
            if (Request.QueryString["IDKhachHang"].Trim() != "")
            {
                pIDKhachHang = StaticData.ValidParameter(Request.QueryString["IDKhachHang"].Trim());

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
            LoadLenLoaiHangCapCao();
            try
            {
                if (Request.QueryString["IDKhachHang"].Trim() != "")
                {
                    pIDKhachHang = StaticData.ValidParameter(Request.QueryString["IDKhachHang"].Trim());

                }
            }
            catch { }
            try
            {
                Page = StaticData.ValidParameter(Request.QueryString["Page"].Trim());
            }
            catch
            { }
            LoadLenDonViTinh();
            if (Page.Length > 0 && pIDKhachHang.Length > 0)
            {
                LoadThongTinKhachHang();
            }
        }
    }

    private void LoadLenLoaiHangCapCao()
    {
        string sql = "  select * from LoaiHangCapCao";
        //string strSql = "select * from DonViTinh";
        txtLoaiHangCapCao.DataSource = Connect.GetTable(sql);
        txtLoaiHangCapCao.DataTextField = "TenLoaiHangCapCao";
        txtLoaiHangCapCao.DataValueField = "IDLoaiHangCapCao";
        txtLoaiHangCapCao.DataBind();

    }

    private void LoadLenDonViTinh()
    {
        string sql = "  select * from DonViTinh";
        //string strSql = "select * from DonViTinh";
        txtDonViTinh.DataSource = Connect.GetTable(sql);
        txtDonViTinh.DataTextField = "TenDonViTinh";
        txtDonViTinh.DataValueField = "IDDonViTinh";
        txtDonViTinh.DataBind();

    }
    private void LoadThongTinKhachHang()
    {
        string sql = "select * from LoaiHangHoa where IDLoaiHangHoa =" + pIDKhachHang + "";
        DataTable table = Connect.GetTable(sql);
        if (table.Rows.Count > 0)
        {
            dvTitle.InnerHtml = "SỬA THÔNG TIN HÀNG HÓA";
            btLuu.Text = "SỬA";
            txtMaKhachHang.Value = table.Rows[0]["TenLoaiHangHoa"].ToString();
            if(table.Rows[0]["Gia"].ToString()=="0")
                txtTenKhachHang.Value = "0";
            else
                txtTenKhachHang.Value = double.Parse(table.Rows[0]["Gia"].ToString()).ToString("#,##").Replace(",",".");


            if (table.Rows[0]["GiaBanWeb"].ToString() == "0")
                txtGiaBanWeb.Value = "0";
            else
                txtTenKhachHang.Value = double.Parse(table.Rows[0]["Gia"].ToString()).ToString("#,##").Replace(",", ".");

            string ShowHinh = "";
            if (table.Rows[0]["HinhAnh"].ToString().Trim() != "")
                ShowHinh = "<a target='_blank' href='" + table.Rows[0]["HinhAnh"].ToString().Trim() + "'>Xem hình hiện tại</a>";
            showHinhRa.InnerHtml = ShowHinh;

            txtLoaiHangCapCao.Value = table.Rows[0]["IDLoaiHangCapCao"].ToString();
           // slCapDaiLy.Value = table.Rows[0]["CapDaiLy"].ToString();
            //txtSoDienThoai.Value = table.Rows[0]["DienThoai"].ToString();
            //txtDiaChi.Value = table.Rows[0]["DiaChi"].ToString();
            //txtGhiChu.Value = table.Rows[0]["GhiChu"].ToString();

          
        }
    }
    protected void btLuu_Click(object sender, EventArgs e)
    {
         if (pIDKhachHang.Length <= 0)
         {
             string TenLoaiHangHoa = txtMaKhachHang.Value.Trim();
             string GiaBan = txtTenKhachHang.Value.Trim().Replace(",", "").Replace(".", "");
             string IDLoaiHangCapCao = txtLoaiHangCapCao.Value.Trim();
             string MaLoaiHangHoa = txtMaLoaiHangHoa.Value.Trim();
             string IDDonViTinh = txtDonViTinh.Value.Trim();

             string GiaBanWeb = txtGiaBanWeb.Value.Trim().Replace(",", "").Replace(".", "");
             

             string isHot = "0";
             if (ckbHot.Checked)
                 isHot = "1";

             string isMoi = "0";
             if (ckbMoi.Checked)
                 isMoi = "1";

             if (IDDonViTinh.Length <= 0)
             {
                 Response.Write("<script>alert('Hãy chọn đơn vị tính !')</script>");
                 return;
             }
             if (MaLoaiHangHoa.Length <= 0)
             {
                 Response.Write("<script>alert('Hãy nhập mã hàng !')</script>");
                 return;
             }
             if (IDLoaiHangCapCao.Length <= 0)
             {
                 Response.Write("<script>alert('Hãy chọn loại hàng !')</script>");
                 return;
             }
             if (TenLoaiHangHoa.Length <= 0)
             {
                 Response.Write("<script>alert('Tên hàng hóa không được trống !')</script>");
                 return;
             }
             DataTable a1 = Connect.GetTable("SELECT  * FROM LoaiHangHoa where MaLoaiHangHoa =N'" + MaLoaiHangHoa + "'");
             if (a1.Rows.Count > 0)
             {
                 Response.Write("<script>alert('Mã hàng hóa đã được dùng !')</script>");
                 return;
             }

             //DataTable a = Connect.GetTable("SELECT  * FROM LoaiHangHoa where TenLoaiHangHoa =N'" + TenLoaiHangHoa + "'");
             //if(a.Rows.Count > 0)
             //{
             //    Response.Write("<script>alert('Tên hàng hóa đã được dùng !')</script>");
             //    return;
             //}

             if (GiaBan.Length <= 0)
             {
                 Response.Write("<script>alert('Giá bán không được trống !')</script>");
                 return;
             }

             if (GiaBanWeb.Length <= 0)
             {
                 Response.Write("<script>alert('Giá bán Web không được trống !')</script>");
                 return;
             }

             if(MyStaticData.KiemTraSo(GiaBan) == false)
             {
                 Response.Write("<script>alert('Giá bán phải là số !')</script>");
                 return;
             }


             if (MyStaticData.KiemTraSo(GiaBanWeb) == false)
             {
                 Response.Write("<script>alert('Giá bán web phải là số !')</script>");
                 return;
             }

             string HinhAnh = "";
             if (fileUpload.HasFile)
             {
                 string Ngay = DateTime.Now.Day.ToString();
                 string Thang = DateTime.Now.Month.ToString();
                 string Nam = DateTime.Now.Year.ToString();
                 string Gio = DateTime.Now.Hour.ToString();
                 string Phut = DateTime.Now.Minute.ToString();
                 string Giay = DateTime.Now.Second.ToString();
                 string Khac = DateTime.Now.Ticks.ToString();
                 string luu = fileUpload.FileName + Ngay + Thang + Nam + Gio + Phut + Giay + Khac;

                 fileUpload.SaveAs(Server.MapPath("HinhAnh\\" + luu + ".png"));

                 HinhAnh = "HinhAnh/" + luu + ".png";
             }



             string sql = "insert into LoaiHangHoa values(N'" + TenLoaiHangHoa + "'," + GiaBan + ",N'" + HinhAnh + "'," + IDLoaiHangCapCao + ",N'" + MaLoaiHangHoa + "'," + IDDonViTinh + "," + GiaBanWeb + "," + isHot + "," + isMoi + ",'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')";
             bool kq = Connect.Exec(sql);
             if (kq)
             {
                 if (ckbHienThi.Checked == false)
                 {
                     string sql2 = "insert into BlackList values('" +StaticData.getFieldCoDau("LoaiHangHoa","IDLoaiHangHoa","MaLoaiHangHoa", MaLoaiHangHoa) + "')";
                     bool kq2 = Connect.Exec(sql2);
                 }



                 string IDLoaiHangHoa = StaticData.getFieldCoDau("LoaiHangHoa", "IDLoaiHangHoa", "MaLoaiHangHoa", MaLoaiHangHoa);
                 Response.Redirect("DanhMucLoaiHangHoaSua.aspx?Page=1&IDLoaiHangHoa=" + IDLoaiHangHoa + "");
             }
             else
             {
                 Response.Write("<script>alert('Lỗi !')</script>");
                 return;
             }
         }
         else
         {
             string TenLoaiHangHoa = txtMaKhachHang.Value.Trim();
             string GiaBan = txtTenKhachHang.Value.Trim().Replace(",", "").Replace(".", "");
             string IDLoaiHangCapCao = txtLoaiHangCapCao.Value.Trim();
             string MaLoaiHangHoa = txtMaLoaiHangHoa.Value.Trim();
             string IDDonViTinh = txtDonViTinh.Value.Trim();
             string GiaBanWeb = txtGiaBanWeb.Value.Trim().Replace(",", "").Replace(".", "");


             string isHot = "0";
             if (ckbHot.Checked)
                 isHot = "1";

             string isMoi = "0";
             if (ckbMoi.Checked)
                 isMoi = "1";


             if (IDDonViTinh.Length <= 0)
             {
                 Response.Write("<script>alert('Hãy chọn đơn vị tính !')</script>");
                 return;
             }
             if (MaLoaiHangHoa.Length <= 0)
             {
                 Response.Write("<script>alert('Hãy nhập mã hàng !')</script>");
                 return;
             }
             if (IDLoaiHangCapCao.Length <= 0)
             {
                 Response.Write("<script>alert('Hãy chọn loại hàng !')</script>");
                 return;
             }

             if (TenLoaiHangHoa.Length <= 0)
             {
                 Response.Write("<script>alert('Tên hàng hóa không được trống !')</script>");
                 return;
             }
             DataTable a1 = Connect.GetTable("SELECT  * FROM LoaiHangHoa where MaLoaiHangHoa =N'" + MaLoaiHangHoa + "'");
             if (a1.Rows.Count > 0)
             {
                 Response.Write("<script>alert('Mã hàng hóa đã được dùng !')</script>");
                 return;
             }
             //DataTable a = Connect.GetTable("SELECT  * FROM LoaiHangHoa where TenLoaiHangHoa =N'" + TenLoaiHangHoa + "' and IDLoaiHangHoa<>"+pIDKhachHang+"");
             //if (a.Rows.Count > 0)
             //{
             //    Response.Write("<script>alert('Tên hàng hóa đã được dùng !')</script>");
             //    return;
             //}

             if (GiaBan.Length <= 0)
             {
                 Response.Write("<script>alert('Giá bán không được trống !')</script>");
                 return;
             }
             if (MyStaticData.KiemTraSo(GiaBan) == false)
             {
                 Response.Write("<script>alert('Giá bán phải là số !')</script>");
                 return;
             }

             string HinhAnh = "";
             if (fileUpload.HasFile)
             {
                 string Ngay = DateTime.Now.Day.ToString();
                 string Thang = DateTime.Now.Month.ToString();
                 string Nam = DateTime.Now.Year.ToString();
                 string Gio = DateTime.Now.Hour.ToString();
                 string Phut = DateTime.Now.Minute.ToString();
                 string Giay = DateTime.Now.Second.ToString();
                 string Khac = DateTime.Now.Ticks.ToString();
                 string luu = fileUpload.FileName + Ngay + Thang + Nam + Gio + Phut + Giay + Khac;

                 fileUpload.SaveAs(Server.MapPath("HinhAnh\\" + luu + ".png"));

                 HinhAnh = "HinhAnh/" + luu + ".png";
                 string sql = "update LoaiHangHoa set IDDonViTinh=" + IDDonViTinh + ", MaLoaiHangHoa=N'" + MaLoaiHangHoa + "',IDLoaiHangCapCao=" + IDLoaiHangCapCao + ",HinhAnh=N'" + HinhAnh + "',TenLoaiHangHoa = N'" + TenLoaiHangHoa + "',Gia =" + GiaBan + "',GiaBanWeb =" + GiaBanWeb + " where IDLoaiHangHoa = " + pIDKhachHang + "";
                 bool kq = Connect.Exec(sql);
                 if (kq)
                 {
                     if (ckbHienThi.Checked == false)
                     {
                         DataTable check = Connect.GetTable("select * from BlackList where IDLoaiHangHoa = '" + pIDKhachHang + "'");
                         if (check.Rows.Count > 0)
                         {

                         }
                         else
                         {
                             string sql2 = "insert into BlackList values('" + pIDKhachHang + "')";
                             bool kq2 = Connect.Exec(sql2);
                         }
                     }
                     else
                     {
                         string sql2 = "delete from BlackList where  IDLoaiHangHoa = '" + pIDKhachHang + "'";
                         bool kq2 = Connect.Exec(sql2);
                     }


                     if (Page.Length > 0)
                         Response.Redirect("DanhMucLoaiHangHoa.aspx?Page=" + Page);
                     else Response.Redirect("DanhMucLoaiHangHoa.aspx");
                 }
                 else
                 {
                     Response.Write("<script>alert('Lỗi !!')</script>");
                     return;
                 }
             }
             else
             {
                 string sql = "update LoaiHangHoa set IDDonViTinh=" + IDDonViTinh + ",MaLoaiHangHoa=N'" + MaLoaiHangHoa + "',IDLoaiHangCapCao=" + IDLoaiHangCapCao + ",TenLoaiHangHoa = N'" + TenLoaiHangHoa + "',Gia ='" + GiaBan + "',isHot ='" + isHot + "',isMoi ='" + isMoi + "',NgayCapNhat ='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where IDLoaiHangHoa = " + pIDKhachHang + "";
                 bool kq = Connect.Exec(sql);
                 if (kq)
                 {
                     if (ckbHienThi.Checked == false)
                     {
                         DataTable check = Connect.GetTable("select * from BlackList where IDLoaiHangHoa = '" + pIDKhachHang + "'");
                         if (check.Rows.Count > 0)
                         {

                         }
                         else
                         {
                             string sql2 = "insert into BlackList values('" + pIDKhachHang + "')";
                             bool kq2 = Connect.Exec(sql2);
                         }
                     }
                     else
                     {
                         string sql2 = "delete from BlackList where  IDLoaiHangHoa = '" + pIDKhachHang + "'";
                         bool kq2 = Connect.Exec(sql2);
                     }


                     if (Page.Length > 0)
                         Response.Redirect("DanhMucLoaiHangHoa.aspx?Page=" + Page);
                     else Response.Redirect("DanhMucLoaiHangHoa.aspx");
                 }
                 else
                 {
                     Response.Write("<script>alert('Lỗi !!')</script>");
                     return;
                 }
             }
         }
    }
    protected void btHuy_Click(object sender, EventArgs e)
    {
        if(Page.Length > 0)
            Response.Redirect("DanhMucLoaiHangHoa.aspx?Page=" + Page);
        else Response.Redirect("DanhMucLoaiHangHoa.aspx");
    }
}