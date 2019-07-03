<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="NoNhaCungCap.aspx.cs" Inherits="QuanLyDoiTra_DoiTra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <script src="../dist/jquery-ui-1.11.3/jquery-ui.js"></script>
    <link href="../dist/jquery-ui-1.11.3/jquery-ui.css" rel="stylesheet"/>
    <script>
        window.onload = function () {
            //THH(); THHhoa();

        }

        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Label" style="display:none;"></asp:Label>
    <form runat="server">
    <div class="content-wrapper">
    <!-- Main content -->
    <section class="content">
    <div class="title">THỐNG KÊ THIẾU NỢ NHÀ CUNG CẤP</div>
    <div class="box">
        <div class="box-body">
           <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Tên nhà cung cấp:</b></div>
                          <div class="txtinput">
                               <input class="form-control" data-val="true" data-val-required="" id="txtMaPhieuNhap" runat="server" name="Content.ContentName" type="text" value=""  />
                          </div>
                        </div>
                        <div class="coninput1" style="display:none;">
                          <div class="titleinput"><b>Tên hàng hóa:</b></div>
                          <div class="txtinput">
                                <input class="form-control" placeholder="--Chọn--" data-val="true" data-val-required="" id="txtTenHangHoa" runat="server" name="Content.ContentName" type="text" value=""  />
                          </div>
                        </div>
                      </div>
                </div> 
             <div class="form-group" style="display:none;">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Từ ngày:</b></div>
                          <div class="txtinput">
                                 <input class="form-control" data-val="true" data-val-required="" id="txtTuNgayNhap" runat="server" name="Content.ContentName" type="text" value=""  />
                          </div>
                        </div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Đến ngày:</b></div>
                          <div class="txtinput">
                                <input class="form-control" data-val="true" data-val-required="" id="txtDenNgayNhap" runat="server" name="Content.ContentName" type="text" value=""  />
                          </div>
                        </div>
                      </div>
                </div> 


            <div class="row">
               <div class="col-sm-9">
                   <%--   <a class="btn btn-primary btn-flat" href="#"><i class="glyphicon glyphicon-plus"></i>&nbsp;&nbsp;&nbsp; Thêm mới</a>--%>
                </div>
                <div class="col-sm-3">
                        <div style="text-align:right;">
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
      <script src="../plugins/datetimePicker1/build/jquery.datetimepicker.full.js"></script>
    <script type="text/javascript">
        $('#ContentPlaceHolder1_txtTuNgayNhap').datetimepicker({
            //dayOfWeekStart : 1,
            //todayBtn: "linked",
            language: "it",
            autoclose: true,
            todayHighlight: true,
            timepicker: false,
            dateFormat: 'dd/mm/yyyy',
            format: 'd/m/Y',
            formatDate: 'Y/m/d',
            //value: 'today'
        });
        $('#ContentPlaceHolder1_txtDenNgayNhap').datetimepicker({
            //dayOfWeekStart : 1,
            //todayBtn: "linked",
            language: "it",
            autoclose: true,
            todayHighlight: true,
            timepicker: false,
            dateFormat: 'dd/mm/yyyy',
            format: 'd/m/Y',
            formatDate: 'Y/m/d',
            //value: 'today'
        });

    </script>
</asp:Content>

