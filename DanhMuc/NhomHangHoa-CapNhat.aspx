<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="NhomHangHoa-CapNhat.aspx.cs" Inherits="DanhMuc_DonViTinh_CapNhat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-wrapper">
        <!-- Main content -->
        <div class="title" id="dvTitle" runat="server">THÊM THÔNG TIN NHÓM HÀNG HOÁ</div>
        <div class="title1"><a href="NhomHangHoa.aspx"><i class="fa fa-step-backward"></i>Danh sách nhóm hàng hoá</a></div>
        <section class="content">
            <div class="box">
                <div class="box-body">
                    <form class="form-horizontal" runat="server">
                        <div class="form-group">
                            <div class="row">
                                <div class="dvnull">&nbsp;</div> 
                                <div class="coninput1">
                                    <div class="titleinput"><b>Tên nhóm hàng hoá(*):</b></div>
                                    <div class="txtinput">
                                        <input class="form-control" data-val="true" data-val-required="" id="txtTenNhomHangHoa" runat="server" name="Content.ContentName" type="text" value="" />
                                    </div>
                                </div>
                            </div>
                        </div> 
                        <div class="box-footer">
                            <asp:Button ID="btLuu" runat="server" Text="LƯU" class="btn btn-primary btn-flat" OnClick="btLuu_Click" />
                            <asp:Button ID="btHuy" runat="server" Text="HỦY" class="btn btn-primary btn-flat" OnClick="btHuy_Click" />
                        </div>
                    </form>
                </div>
            </div>
        </section>
        <!-- /.content -->
    </div>
</asp:Content>

