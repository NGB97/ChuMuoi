using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DanhMuc_DonViTinh_CapNhat : System.Web.UI.Page
{
    string pIDPhieuXuat = "";
    string Page = "1";
    string pIDPhieuNhap = "";
    string idHHNhap = "";
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
            Page = StaticData.ValidParameter(Request.QueryString["Page"].Trim());
        }
        catch
        { }

        try
        {
            pIDPhieuNhap = StaticData.ValidParameter(Request.QueryString["IDPhieuNhap"].Trim());
        }
        catch
        { }

        if (!IsPostBack)
        {
            LoadHangHoa();
            try
            {
                if (Request.QueryString["IDPhieuChia"].Trim() != "")
                {
                    pIDPhieuXuat = StaticData.ValidParameter(Request.QueryString["IDPhieuChia"].Trim());
                    txtPX.Value = pIDPhieuXuat;
                }
            }
            catch { }

            try
            {
                pIDPhieuNhap = StaticData.ValidParameter(Request.QueryString["IDPhieuNhap"].Trim());
            }
            catch
            { }

            try
            {
                Page = StaticData.ValidParameter(Request.QueryString["Page"].Trim());
            }
            catch { }
            try
            {
                idHHNhap = Request.QueryString["idHHNhap"].ToString();
            }
            catch
            { }
            //LoadSize();
            LoadKho();
            //LoadMauSac();
            LoadKhachHang();
            
            LoadChiTietPhieuChia();
        }
    }
    private void LoadKho()
    {
        string strSql = "select kh.IDKHo,kh.TenKho from Kho kh, PhieuNhap pn where kh.IDKho = pn.IDKho and pn.IDPhieuNhap = '"+pIDPhieuNhap+"'";
        txtIDKho.DataSource = Connect.GetTable(strSql);
        txtIDKho.DataTextField = "TenKho";
        txtIDKho.DataValueField = "IDKHo";
        txtIDKho.DataBind();
    }
    //private void LoadSize()
    //{
    //    string strSql = "select * from Size";
    //    slSize.DataSource = Connect.GetTable(strSql);
    //    slSize.DataTextField = "TenSize";
    //    slSize.DataValueField = "IDSize";
    //    slSize.DataBind();
    //}
    private void LoadHangHoa()
    {
        string strSql = "select DISTINCT  hh.IDLoaiHangHoa,(LHH.TenLoaiHangHoa + ' ' + MaLoaiHangHoa) as TenHangHoa from PhieuNhap PN,LoaiHangHoa LHH,HangHoa HH, ChiTietPhieuNhap CT where HH.idLoaiHangHoa = LHH.idLoaiHangHoa and CT.IDPhieuNhap = '" + pIDPhieuNhap + "' and CT.IDHangHoa = HH.IDHangHoa and HH.IDLoaiHangHoa = LHH.IDLoaiHangHoa";
        slHangHoa.DataSource = Connect.GetTable(strSql);
        slHangHoa.DataTextField = "TenHangHoa";
        slHangHoa.DataValueField = "IDLoaiHangHoa";
        slHangHoa.DataBind();
        slHangHoa.Items.Add(new ListItem("--Chọn--", "0"));
        slHangHoa.Items.FindByText("--Chọn--").Selected = true;
    }
    protected void LoadSize_SelectedIndexChanged(object sender, EventArgs e)
    {
        string Size = slHangHoa.SelectedValue.ToString();
        if (Size != "" && Size != "0")
        {
            //slSize.Disabled = false;
            slSize.Attributes.Remove("Disabled");
            slSize.DataSource = Connect.GetTable("select DISTINCT sz.IDSize,TenSize from Size sz, ChiTietPhieuNhap ct, HangHoa hh Where ct.IDPhieuNhap = '"+pIDPhieuNhap+ "' and ct.IDHangHoa = hh.IDHangHoa and hh.IDSize = sz.IDSize and IDLoaiHangHoa = '" + Size + "'");
            slSize.DataTextField = "TenSize";
            slSize.DataValueField = "IDSize";
            slSize.DataBind();
            slSize.Items.Add(new ListItem("--Chọn--", "0"));
            slSize.Items.FindByText("--Chọn--").Selected = true;
        }
        else
        {
            //slSize.Disabled = true;
            slSize.Attributes.Add("Disabled", "");
            string sqlHuyen = "";
            slSize.DataSource = Connect.GetTable(sqlHuyen);
            slSize.DataTextField = "";
            slSize.DataValueField = "";
            slSize.DataBind();
            slSize.Items.Add(new ListItem("", "0"));
            slSize.Items.FindByText("").Selected = true;
        }
    }
    protected void LoadMauSac_SelectedIndexChanged(object sender, EventArgs e)
    {
        slSize.Attributes.Remove("Disabled");
        string MauSac = slHangHoa.SelectedValue.ToString();
        string Size = slSize.SelectedValue.ToString();
        if (MauSac != "" && MauSac != "0")
        {
            //slSize.Attributes.Remove("Disabled");
            //slSize.Disabled = false;
            slMauSac.Attributes.Remove("Disabled");
            slMauSac.DataSource = Connect.GetTable("select DISTINCT ms.IDMauSac,TenMauSac from MauSac ms, ChiTietPhieuNhap ct, HangHoa hh Where ct.IDPhieuNhap = '"+pIDPhieuNhap+ "' and hh.IDSize = '"+Size+"' and ct.IDHangHoa = hh.IDHangHoa and hh.IDMauSac = ms.IDMauSac and IDLoaiHangHoa = '" + MauSac + "' ");
            slMauSac.DataTextField = "TenMauSac";
            slMauSac.DataValueField = "IDMauSac";
            slMauSac.DataBind();
            slMauSac.Items.Add(new ListItem("--Chọn--", "0"));
            slMauSac.Items.FindByText("--Chọn--").Selected = true;
        }
        else
        {
            //slSize.Disabled = true;
            slMauSac.Attributes.Add("Disabled", "");
            string sqlHuyen = "";
            slMauSac.DataSource = Connect.GetTable(sqlHuyen);
            slMauSac.DataTextField = "";
            slMauSac.DataValueField = "";
            slMauSac.DataBind();
            slMauSac.Items.Add(new ListItem("", "0"));
            slMauSac.Items.FindByText("").Selected = true;
        }
    }
    protected void LoadIDHH_SelectedIndexChanged(object sender, EventArgs e)
    {
        string IDLoaiHH = slHangHoa.SelectedValue.ToString();
        string MauSac = slMauSac.SelectedValue.ToString();
        string Size = slSize.SelectedValue.ToString();
        if (IDLoaiHH != "" && IDLoaiHH != "0" && MauSac != "" && MauSac != "0" && Size != "" && Size !="0")
        {
            slSize.Attributes.Remove("Disabled");
            slMauSac.Attributes.Remove("Disabled");
            idslHangHoa.DataSource = Connect.GetTable("select IDHangHoa from HangHoa where IDSize = '"+Size+"' and IDMauSac = '"+MauSac+"' and IDLoaiHangHoa = '"+IDLoaiHH+"'");
            idslHangHoa.DataTextField = "IDHangHoa";
            idslHangHoa.DataValueField = "IDHangHoa";
            idslHangHoa.DataBind();
        }
        else
        {
            slSize.Attributes.Remove("Disabled");
            slMauSac.Attributes.Remove("Disabled");
            string sqlHuyen = "";
            idslHangHoa.DataSource = Connect.GetTable(sqlHuyen);
            idslHangHoa.DataTextField = "";
            idslHangHoa.DataValueField = "";
            idslHangHoa.DataBind();
        }
    }
    private void LoadKhachHang()
    {
        string strSql = "select * from KhachHang";
        slKhachHang.DataSource = Connect.GetTable(strSql);
        slKhachHang.DataTextField = "TenKhachHang";
        slKhachHang.DataValueField = "IDKhachHang";
        slKhachHang.DataBind();
    }
   
    void LoadChiTietPhieuChia()
    {
        if (pIDPhieuXuat.Trim() != "")
        {
            DataTable table_PhieuChia = Connect.GetTable("select *,(select sum(SoLuong*DOnGiaXuat) from ChiTietPhieuXuat where idPhieuXuat='"+pIDPhieuXuat+"' ) as TongTien from PhieuXuat where idPhieuXuat=" + pIDPhieuXuat);
            if (table_PhieuChia != null)
                if (table_PhieuChia.Rows.Count > 0)
                {
                    txtGhiChu.Value = table_PhieuChia.Rows[0]["GhiChu"].ToString();
                    txtMaPhieuXuat.Value = table_PhieuChia.Rows[0]["MaPhieuXuat"].ToString();
                    txtNgayTao.Value = StaticData.ConvertMMDDYYtoDDMMYY(table_PhieuChia.Rows[0]["NgayXuat"].ToString());
                    txtIDKho.Value = table_PhieuChia.Rows[0]["idKho"].ToString();
                    txtTongTienDonHang.Value = decimal.Parse(KiemTraKhongNhap_LoadLen(table_PhieuChia.Rows[0]["TongTien"].ToString())).ToString("N0");

                    //Chi tiet phiếu chia
                    DataTable table_ChiTietPhieuChia = Connect.GetTable("select *,(TenLoaiHangHoa +' '+ MaLoaiHangHoa) as TenloaiHangHoa2 from ChiTietPhieuXuat CT,HangHoa HH,LoaiHangHoa LHH where HH.idLoaiHangHoa=LHH.idLoaiHangHoa and HH.idHangHoa=CT.idHangHoa and CT.idPhieuXuat=" + pIDPhieuXuat);
                    txtSTT.Value = table_ChiTietPhieuChia.Rows.Count.ToString();
                    string html = "";
                    if (table_ChiTietPhieuChia != null)
                        if (table_ChiTietPhieuChia.Rows.Count > 0)
                        {
                            for (int i = 0; i < table_ChiTietPhieuChia.Rows.Count; i++)
                            {
                                html += "<tr id='tr_" + (i + 1) + "'>";
                                html += "       <td style='display: none;' id='td_ChuoiDuLieu'>" + table_ChiTietPhieuChia.Rows[i]["idHangHoa"] + "@_@" + table_ChiTietPhieuChia.Rows[i]["idSize"] + "@_@" + table_ChiTietPhieuChia.Rows[i]["idSize"] + "@_@" + table_ChiTietPhieuChia.Rows[i]["idKhachHang_ChiaHang"] + "@_@" + table_ChiTietPhieuChia.Rows[i]["SoLuong"] + "@_@" + table_ChiTietPhieuChia.Rows[i]["DonGiaXuat"] + "</td>";
                                html += "       <td>" + table_ChiTietPhieuChia.Rows[i]["TenLoaiHangHoa2"] + "</td>";
                                html += "       <td>" + StaticData.getField("Size", "TenSize", "idSize", table_ChiTietPhieuChia.Rows[i]["idSize"].ToString()) + "</td>";
                                html += "       <td>" + StaticData.getField("MauSac", "TenMauSac", "idMauSac", table_ChiTietPhieuChia.Rows[i]["idMauSac"].ToString()) + "</td>";
                                html += "       <td>" + KiemTraKhongNhap_LoadLen(table_ChiTietPhieuChia.Rows[i]["SoLuong"].ToString()) + "</td>";
                                html += "       <td>" + decimal.Parse(KiemTraKhongNhap_LoadLen(table_ChiTietPhieuChia.Rows[i]["DonGiaXuat"].ToString())).ToString("N0") + "</td>";
                                html += "       <td>" + (decimal.Parse(KiemTraKhongNhap_LoadLen(table_ChiTietPhieuChia.Rows[i]["SoLuong"].ToString())) * decimal.Parse(KiemTraKhongNhap_LoadLen(table_ChiTietPhieuChia.Rows[i]["DonGiaXuat"].ToString()))).ToString("N0") + "</td>";
                                html += "       <td>" + StaticData.getField("KhachHang", "TenKhachHang", "idKhachHang", table_ChiTietPhieuChia.Rows[i]["idKhachHang_ChiaHang"].ToString()) + "</td>";
                                //html += "       <td>";
                                //html += "         <a href='#'  onclick='SuaHangHoa(" + (i + 1) + ")'> <img title='Sửa' class='imgCommand' src='../Images/edit.png' /> Sửa </a>";
                                //html += "       </td>";
                                html += "       <td>";
                                html += "          <a href='#' onclick='XoaHangHoa(" + (i + 1) + ")'> <img title='Xoá' class='imgCommand' src='../Images/Delete.png' /> Xoá </a>";
                                html += "       </td>";
                                html += " </tr>";
                            }
                        }
                    tbody_ChiTietPhieuChia.InnerHtml = html;
                }
        }
        else
        {
            DataTable a = Connect.GetTable("SELECT max(IDPhieuXuat)+1 FROM [PhieuXuat]");

            string Ma = "PCH" + "-" + a.Rows[0][0].ToString().Trim() + "-" + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Year + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second;
            txtMaPhieuXuat.Value = Ma;
        }
    }
    protected void btLuu_Click(object sender, EventArgs e)
    {
        string maPhieuXuat = txtMaPhieuXuat.Value.Trim();
        string NgayXuat = StaticData.ConvertDDMMtoMMDD(txtNgayTao.Value);
        string IDKho = txtIDKho.Value;
        string GhiChu = txtGhiChu.Value.Trim();
        pIDPhieuXuat = txtPX.Value.Trim();

        if (pIDPhieuXuat.Trim() != "")//cap nhat
        {

            string sql_UpdateChiaHang = @"update PhieuXuat
                                          set
                                                MaPhieuXuat='" + maPhieuXuat +@"',
                                                NgayXuat = '" + NgayXuat +@"',
                                                GhiChu = N'" + GhiChu +@"',
                                                idKho = " + IDKho +@"
                                           where idPhieuXuat=" + pIDPhieuXuat;

            if (Connect.Exec(sql_UpdateChiaHang))
            {
                string sql_ChiTiet = "";
                string[] ChuoiDuLieu = txtChuoiDuLieu.Value.Split(new[] { "|~~|" }, StringSplitOptions.None);

                Connect.Exec("Delete ChiTietPhieuXuat where idPhieuXuat=" + pIDPhieuXuat);
                for (int i = 0; i < ChuoiDuLieu.Length; i++)
                {
                    string[] arr = ChuoiDuLieu[i].Split(new[] { "@_@" }, StringSplitOptions.None);
                    if (arr.Length > 1)
                    {
                        sql_ChiTiet += @" insert into ChiTIetPhieuXuat(idPhieuXuat,idHangHoa,idKhachHang_ChiaHang,SoLuong,DonGiaXuat) 
                                          values(
                                                '" + pIDPhieuXuat + @"',
                                                '" + arr[0] + @"',
                                                '" + arr[3] + @"',
                                                '" + arr[4] + @"',
                                                '" + arr[5] + @"'
                                            )";

                    }
                }
                if (Connect.Exec(sql_ChiTiet))
                {

                    if (Page.Length > 0)
                        Response.Redirect("PhieuChiaHang.aspx?Page=" + Page);
                    else Response.Redirect("PhieuChiaHang.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Lỗi !')</script>");
                }
            }
        }
        else//them moi
        {
            string sql_ChiaHang = @"insert into PhieuXuat(MaPhieuXuat,NgayXuat,GhiChu,idKho,LoaiPhieuXuat) values(N'" + maPhieuXuat + "','" + (NgayXuat) + "',N'" + GhiChu + "','" + IDKho + @"','PhieuChiaHang')
                                    select SCOPE_IDENTITY()";
            object idPhieuXuat_MoiNhat = Connect.FirstResulfExec(sql_ChiaHang);
            if (idPhieuXuat_MoiNhat != null)
            {
                string sql_ChiTiet = "";
                string[] ChuoiDuLieu = txtChuoiDuLieu.Value.Split(new[] { "|~~|" }, StringSplitOptions.None);
                for (int i = 0; i < ChuoiDuLieu.Length; i++)
                {
                    string[] arr = ChuoiDuLieu[i].Split(new[] { "@_@" }, StringSplitOptions.None);
                    if (arr.Length > 1)
                    {
                        sql_ChiTiet += @" insert into ChiTIetPhieuXuat(idPhieuXuat,idHangHoa,idKhachHang_ChiaHang,SoLuong,DonGiaXuat) 
                                      values(
                                            '" + idPhieuXuat_MoiNhat + @"',
                                            '" + arr[0] + @"',
                                            '" + arr[3] + @"',
                                            '" + arr[4] + @"',
                                            '" + arr[5] + @"'
                                        )";

                    }
                }
                if (Connect.Exec(sql_ChiTiet))
                {

                    if (Page.Length > 0)
                        Response.Redirect("PhieuChiaHang.aspx?Page=" + Page);
                    else Response.Redirect("PhieuChiaHang.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Lỗi !')</script>");
                }
            }
        }
    }
    protected void btHuy_Click(object sender, EventArgs e)
    {
        if (Page.Length > 0)
            Response.Redirect("PhieuChiaHang.aspx?Page=" + Page);
        else Response.Redirect("PhieuChiaHang.aspx");
    }
    string KiemTraKhongNhap_LoadLen(string SoTien)
    {
        string KQ = "0";
        try
        {
            KQ = decimal.Parse(SoTien).ToString();
        }
        catch { }
        return KQ;
    }
}