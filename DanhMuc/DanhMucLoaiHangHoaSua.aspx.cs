using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
            if (Request.QueryString["IDLoaiHangHoa"].Trim() != "")
            {
                pIDKhachHang = StaticData.ValidParameter(Request.QueryString["IDLoaiHangHoa"].Trim());

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
                if (Request.QueryString["IDLoaiHangHoa"].Trim() != "")
                {
                    pIDKhachHang = StaticData.ValidParameter(Request.QueryString["IDLoaiHangHoa"].Trim());

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


            LoadHinhAnh();

            if (Page.Length > 0 && pIDKhachHang.Length > 0)
            {
                LoadThongTinKhachHang(); LoadMau(); LoadSize(); LoadKieuDang(); LoadChatLieu();
            }
        }
    }

    private void LoadHinhAnh()
    {
        string html = "";

        string sql = "SELECT * FROM tb_HinhAnhLoaiHangHoa WHERE IDLoaiHangHoa = '" + pIDKhachHang + "'";

        DataTable tb = Connect.GetTable(sql);
        if(tb.Rows.Count > 0)
        {

            html += @" 
            <div style='padding-left:50px; padding-left:50px'>
        <table class='table table-bordered table-striped'>
                    <tr>
                        <th class='th'>
                          Hình Ảnh
                        </th>
<th class='th'>
                        Xóa
                        </th> ";
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                html += "   <tr >";
                html += "       <td style='vertical-align:middle;'> <img src='" + tb.Rows[i]["url"].ToString() +  "' alt='img' height='100px' width='100px'></td>";
                html += " <td style='text-align:center;font-size: 100%;vertical-align:middle;'><a href='#' onclick='DeleteHinhAnh(\"" + tb.Rows[i]["idHinhAnh"].ToString() + "\")'><img title='Xóa' class='imgCommand' src='../Images/delete.png'  />Xóa</a></td>";
                html += " </td>";
            }

            html += " </table> </div>";

        }
        else
        {
            html = "<div style='padding-left:50px; padding-left:50px'> Chưa có hình ảnh nào ... </div>";
        }

        divHinhAnh.InnerHtml = html;
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
    private void LoadMau()
    {
        string sql = "  select * from MauSac"; 
        txtMau.DataSource = Connect.GetTable(sql);
        txtMau.DataTextField = "TenMauSac";
        txtMau.DataValueField = "IDMauSac";
        txtMau.DataBind();

    }
    private void LoadSize()
    {
        string sql = "  select * from Size"; 
        txtSize.DataSource = Connect.GetTable(sql);
        txtSize.DataTextField = "TenSize";
        txtSize.DataValueField = "IDSize";
        txtSize.DataBind();

    }
    private void LoadKieuDang()
    {
        string sql = "  select * from KieuDang"; 
        txtKieuDang.DataSource = Connect.GetTable(sql);
        txtKieuDang.DataTextField = "TenKieuDang";
        txtKieuDang.DataValueField = "IDKieuDang";
        txtKieuDang.DataBind(); 
    }
    private void LoadChatLieu()
    {
        string sql = "  select * from ChatLieu";
        txtChatLieu.DataSource = Connect.GetTable(sql);
        txtChatLieu.DataTextField = "TenChatLieu";
        txtChatLieu.DataValueField = "IDChatLieu";
        txtChatLieu.DataBind();
    }
    private void LoadLenLoaiHangCapCao()
    {
        string sql = "  select * from LoaiHangCapCao"; 
        txtLoaiHangCapCao.DataSource = Connect.GetTable(sql);
        txtLoaiHangCapCao.DataTextField = "TenLoaiHangCapCao";
        txtLoaiHangCapCao.DataValueField = "IDLoaiHangCapCao";
        txtLoaiHangCapCao.DataBind();

    }
    private void LoadThongTinKhachHang()
    {
        string sql = "select * from LoaiHangHoa where IDLoaiHangHoa =" + pIDKhachHang + "";
        DataTable table = Connect.GetTable(sql);
        if (table.Rows.Count > 0)
        {
            dvTitle.InnerHtml = "SỬA THÔNG TIN HÀNG HÓA";
            btLuu.Text = "LƯU";
            txtMaKhachHang.Value = table.Rows[0]["TenLoaiHangHoa"].ToString();
            if(table.Rows[0]["Gia"].ToString()=="0")
                txtTenKhachHang.Value = "0";
            else
                txtTenKhachHang.Value = double.Parse(table.Rows[0]["Gia"].ToString()).ToString("#,##").Replace(",",".");


            if (table.Rows[0]["GiaBanWeb"].ToString() == "0")
                txtGiaBanWeb.Value = "0";
            else
                txtGiaBanWeb.Value = double.Parse(table.Rows[0]["GiaBanWeb"].ToString()).ToString("#,##").Replace(",", ".");

            string ShowHinh = "";
            if (table.Rows[0]["HinhAnh"].ToString().Trim() != "")
                ShowHinh = "<a target='_blank' href='" + table.Rows[0]["HinhAnh"].ToString().Trim() + "'>Xem hình hiện tại</a>";
            showHinhRa.InnerHtml = ShowHinh;

            txtLoaiHangCapCao.Value = table.Rows[0]["IDLoaiHangCapCao"].ToString();

            txtMaLoaiHangHoa.Value = table.Rows[0]["MaLoaiHangHoa"].ToString();

            txtDonViTinh.Value = table.Rows[0]["IDDonViTinh"].ToString();
           // slCapDaiLy.Value = table.Rows[0]["CapDaiLy"].ToString();
            //txtSoDienThoai.Value = table.Rows[0]["DienThoai"].ToString();
            //txtDiaChi.Value = table.Rows[0]["DiaChi"].ToString();
            //txtGhiChu.Value = table.Rows[0]["GhiChu"].ToString();




            if (table.Rows[0]["isHot"].ToString().Trim() == "True")
                ckbHot.Checked = true;

            if (table.Rows[0]["isMoi"].ToString().Trim() == "True")
                ckbMoi.Checked = true;

            DataTable check = Connect.GetTable("select * from BlackList where IDLoaiHangHoa = '" + pIDKhachHang + "'");
            if (check.Rows.Count > 0)
            {
                ckbHienThi.Checked =false ;
            }
            else
            {
                ckbHienThi.Checked = true;
            }
        }
    }
    protected void btLuu_Click(object sender, EventArgs e)
    {
         if (pIDKhachHang.Length <= 0)
         {
             
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
             DataTable a1 = Connect.GetTable("SELECT  * FROM LoaiHangHoa where MaLoaiHangHoa =N'" + MaLoaiHangHoa + "' and IDLoaiHangHoa <> " + pIDKhachHang + "");
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


             if (GiaBanWeb.Length <= 0)
             {
                 Response.Write("<script>alert('Giá bán web không được trống !')</script>");
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
                 string sql = "update LoaiHangHoa set IDDonViTinh=" + IDDonViTinh + ",MaLoaiHangHoa=N'" + MaLoaiHangHoa + "',IDLoaiHangCapCao=" + IDLoaiHangCapCao + ",HinhAnh=N'" + HinhAnh + "',TenLoaiHangHoa = N'" + TenLoaiHangHoa + "',Gia =" + GiaBan + ",GiaBanWeb =" + GiaBanWeb + ", isHot ='" + isHot + "',isMoi ='" + isMoi + "',NgayCapNhat ='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where IDLoaiHangHoa = " + pIDKhachHang + "";
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
                     Response.Write("<script>alert('Lỗi  !!')</script>");
                     return;
                 }
             }
             else
             {
                 string sql = "update LoaiHangHoa set IDDonViTinh=" + IDDonViTinh + ",MaLoaiHangHoa=N'" + MaLoaiHangHoa + "',IDLoaiHangCapCao=" + IDLoaiHangCapCao + ",TenLoaiHangHoa = N'" + TenLoaiHangHoa + "',Gia =" + GiaBan + ",GiaBanWeb =" + GiaBanWeb + ", isHot ='" + isHot + "',isMoi ='" + isMoi + "',NgayCapNhat ='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' where IDLoaiHangHoa = " + pIDKhachHang + "";
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
                     Response.Write("<script>alert('Lỗi  !!')</script>");
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
    protected void btUpLoad_Click(object sender, EventArgs e)
    {

        string filePath = "~/AnhSanPham/" + Path.GetFileName(FileUploadHinhAnh.PostedFile.FileName);
        string url = "/AnhSanPham/" + Path.GetFileName(FileUploadHinhAnh.PostedFile.FileName);
        if (IsPostBack && FileUploadHinhAnh.PostedFile != null)
        {
            if (FileUploadHinhAnh.PostedFile.FileName.Length > 0)
            {
                string extension = Path.GetExtension(FileUploadHinhAnh.PostedFile.FileName);
                if (extension.ToUpper() == ".JPG" || extension.ToUpper() == ".PNG" || extension.ToUpper() == ".BMP")
                {
                    if (FileUploadHinhAnh.HasFile)
                    {
                        FileUploadHinhAnh.SaveAs(Server.MapPath(filePath));

                        string Sql = @"INSERT INTO [tb_HinhAnhLoaiHangHoa] (IdLoaiHangHoa, Url) VALUES ('" + pIDKhachHang + "','" + url + "')";

                        bool kq = Connect.Exec(Sql);
                        if(kq)
                        {
                       
                            Response.Redirect("../DanhMuc/DanhMucLoaiHangHoaSua.aspx?Page=1&IDLoaiHangHoa=" + pIDKhachHang);
                        }
                        else
                        {
                            Response.Write("<script>alert('Lỗi upload hình ảnh!')</script>");
                        }
                    }
                }
                else
                {
                    Response.Write("<script>alert('Bạn vui lòng chọn file hình ảnh!')</script>");
                    //    return;
                }
               
            }
        }



    }
}