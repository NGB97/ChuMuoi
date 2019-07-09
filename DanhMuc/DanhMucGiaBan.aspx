<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Layout/MasterPage.master" CodeFile="DanhMucGiaBan.aspx.cs" Inherits="DanhMuc_DanhMucGiaBan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="../dist/jquery-ui-1.11.3/jquery-ui.js"></script>
    <link href="../dist/jquery-ui-1.11.3/jquery-ui.css" rel="stylesheet" />
    <script>
        window.onload = function () {
         <%--   listsanpham('<%=Request.QueryString["IDHangHoa"].Trim()%>');--%>
        }
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="content-wrapper">
        <!-- Main content -->
        <div class="title" id="dvTitle" runat="server">SỬA GIÁ CẢ HÀNG HÓA THEO KHÁCH HÀNG</div>
        <div class="title1"><a href="DanhMucKhachHangSanPham.aspx"><i class="fa fa-step-backward"></i>Danh sách hàng hóa theo khách hàng</a></div>
        <section class="content">
            <div class="box">
                <div class="box-body">
                    <form class="form-horizontal" runat="server">
                        <div class="form-group">
                            <div class="row">
                                <div class="dvnull">&nbsp;</div>
                                <div class="coninput1">
                                    <div class="titleinput"><b>Hàng hóa(*):</b></div>
                                    <div class="txtinput">
                                        <input class="form-control" data-val="true" data-val-required="" id="txtTenSanPham" runat="server" name="Content.ContentName" type="text" value="" placeholder="--Chọn--" />
                                        <input type="hidden" id="txtIDSanPham" class="form-control" runat="server" name="Content.ContentName" />
                                    </div>
                                </div>
                                <div class="coninput2">
                                    <div class="titleinput"><b>Tên khách hàng(*):</b></div>
                                    <div class="txtinput">
                                        <input class="form-control" data-val="true" data-val-required="" id="txtTenKhachHang" runat="server" name="Content.ContentName" type="text" value="" placeholder="--Chọn--" />
                                        <input id="txtIDKhachHang" type="hidden" runat="server" name="Content.ContentName" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div id="listsanpham">
                        </div>
                        <div class="box-footer">
                            <%-- <asp:Button ID="btLuu" runat="server" Text="LƯU" class="btn btn-primary btn-flat" OnClick="btLuu_Click" />--%>
                            <%-- <asp:Button ID="btHuy" runat="server" Text="HỦY" class="btn btn-primary btn-flat" OnClick="btHuy_Click" />--%>
                        </div>
                    </form>
                </div>
            </div>
        </section>
        <!-- /.content -->
    </div>
</asp:Content>