<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="PhieuChiaHang.aspx.cs" Inherits="DanhMuc_DonViTinh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <script src="../dist/jquery-ui-1.11.3/jquery-ui.js"></script>
    <link href="../dist/jquery-ui-1.11.3/jquery-ui.css" rel="stylesheet" />
    <script>
        window.onload = function () {          
        }
        //
        function DeletePhieuChia(IDPhieuChia) {
            if (confirm("Bạn có muốn xóa không ?")) {
                var xmlhttp;
                if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                    xmlhttp = new XMLHttpRequest();
                }
                else {// code for IE6, IE5
                    xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
                }
                xmlhttp.onreadystatechange = function () {
                    if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                        if (xmlhttp.responseText == "True") {
                            window.location.reload();
                        }
                        else
                            alert("Lỗi !")
                    }
                }
                xmlhttp.open("GET", "../Ajax.aspx?Action=DeletePhieuChia&IDPhieuChia=" + IDPhieuChia, true);
                xmlhttp.send();
            }
        } 

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <form runat="server">
        <div class="content-wrapper">
            <!-- Main content -->
            <section class="content">
                <div class="title">DANH SÁCH PHIẾU CHIA HÀNG</div>
                <div class="box">
                    <div class="box-body">
                        <div class="form-group">
                            <div class="row">
                                <div class="dvnull">&nbsp;</div>
                                <div class="coninput1">
                                    <div class="titleinput"><b>Mã phiếu:</b></div>
                                    <div class="txtinput">
                                        <input class="form-control" data-val="true" data-val-required="" id="txtMaPhieu" runat="server" name="Content.ContentName" type="text" value="" />
                                    </div>
                                </div>
                                <%--<div class="coninput1">
                          <div class="titleinput"><b>Biệt danh:</b></div>
                          <div class="txtinput">
                                <input class="form-control" data-val="true" data-val-required="" id="Text1" runat="server" name="Content.ContentName" type="text" value=""  />
                          </div>
                        </div>--%>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-9">
                                <a class="btn btn-primary btn-flat" href="PhieuChiaHang-ChinhSua.aspx"><i class="glyphicon glyphicon-plus"></i>&nbsp;&nbsp;&nbsp; Thêm mới</a>
                            </div>
                            <div class="col-sm-3">
                                <div style="text-align: right;">
                                    <asp:Button ID="btTimKiem" class="btn btn-primary btn-flat" runat="server" Text="Tìm kiếm" OnClick="btTimKiem_Click" />
                                    <asp:Button ID="btTatCa" class="btn btn-primary btn-flat" runat="server" Text="Tất cả" OnClick="btTatCa_Click" />
                                </div>
                            </div>
                        </div>
                        <div id="dvNguoiDung" runat="server">
                        </div>
                    </div>
                </div>

            </section>


            <!-- /.content -->
        </div>

    </form>
</asp:Content>

