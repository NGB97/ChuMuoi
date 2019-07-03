<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="MauSac-CapNhat.aspx.cs" Inherits="DanhMuc_MauSac_CapNhat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper">
    <!-- Main content -->
    <div class="title" id="dvTitle" runat="server">THÊM THÔNG TIN MÀU SẮC</div>
    <div class="title1"><a href="MauSac.aspx"><i class="fa fa-step-backward"></i> Danh sách màu sắc</a></div>
    <section class="content">
    <div class="box">
        <div class="box-body">
            <form class="form-horizontal" runat="server">
               <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>


                       <%-- <div class="coninput1">
                          <div class="titleinput"><b>Mã màu sắc(*):</b></div>
                          <div class="txtinput">
                              <input class="form-control" data-val="true" data-val-required="" id="txtMaMauSac" runat="server" name="Content.ContentName" type="text" value="" />
                          </div>
                        </div>--%>

                        <div class="coninput1">
                          <div class="titleinput"><b>Code màu sắc(*):</b></div>
                          <div class="txtinput">
                              <input class="form-control" data-val="true" data-val-required="" id="txtMaMauSac" runat="server" name="Content.ContentName" type="text" value="" />
                          </div>
                        </div>



                        <div class="coninput2">
                          <div class="titleinput"><b>Tên màu sắc(*):</b></div>
                          <div class="txtinput">
                              <input class="form-control" data-val="true" data-val-required="" id="txtTenMauSac" runat="server" name="Content.ContentName" type="text" value="" />
                          </div>
                        </div>
                      </div>
                </div>
                <div class="form-group">
                    <label class="col-md-2 control-label" for="Content_ContentName">Ghi chú:</label>
                    <div class="col-md-10">
                        <textarea class="form-control" id="txtGhiChu" runat="server" name="Content.ContentName"></textarea>
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

        <link href="../plugins/colorpicker/bootstrap-colorpicker.min.css" rel="stylesheet" />
        <script src="../plugins/colorpicker/bootstrap-colorpicker.min.js"></script>
        <script>
            $("#ContentPlaceHolder1_txtMaMauSac").colorpicker();
        </script>
  </div>
</asp:Content>

