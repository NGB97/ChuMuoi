<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="DoiTra.aspx.cs" Inherits="QuanLyDoiTra_DoiTra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <script src="../dist/jquery-ui-1.11.3/jquery-ui.js"></script>
    <link href="../dist/jquery-ui-1.11.3/jquery-ui.css" rel="stylesheet"/>
    <script>
        window.onload = function () {
            THH(); THHhoa();

        }

        function THH() {
            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    if (xmlhttp.responseText != "") {
                        //alert(xmlhttp.responseText);
                        var txt = xmlhttp.responseText
                              .replace(/[\"]/g, '\\"')
                              .replace(/[\\]/g, '\\\\')
                              .replace(/[\/]/g, '\\/')
                              .replace(/[\b]/g, '\\b')
                              .replace(/[\f]/g, '\\f')
                              .replace(/[\n]/g, '\\n')
                              .replace(/[\r]/g, '\\r')
                              .replace(/[\t]/g, '\\t');
                        listKhachHangAutocomplete = eval("(" + txt + ")");
                        $("#ContentPlaceHolder1_txtMaPhieuNhap").autocomplete({
                            minLength: 0,
                            source: listKhachHangAutocomplete,

                            focus: function (event, ui) {
                                $("#ContentPlaceHolder1_txtMaPhieuNhap").val(ui.item.label);
                                return false;
                            },
                            select: function (event, ui) {
                                $("#ContentPlaceHolder1_txtMaPhieuNhap").val(ui.item.value);


                                //$( "#results").text($("#topicID").val());    
                                //alert($("#hdIdKhuVuc").val());
                                return false;
                            }
                        })
                    }
                    else {
                        alert("Lỗi tải tên khách hàng!")
                    }

                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=loadmaphieunhap", true);
            xmlhttp.send();
        }

        function THHhoa() {
            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                    if (xmlhttp.responseText != "") {
                        //alert(xmlhttp.responseText);
                        var txt = xmlhttp.responseText
                              .replace(/[\"]/g, '\\"')
                              .replace(/[\\]/g, '\\\\')
                              .replace(/[\/]/g, '\\/')
                              .replace(/[\b]/g, '\\b')
                              .replace(/[\f]/g, '\\f')
                              .replace(/[\n]/g, '\\n')
                              .replace(/[\r]/g, '\\r')
                              .replace(/[\t]/g, '\\t');
                        listKhachHangAutocomplete = eval("(" + txt + ")");
                        $("#ContentPlaceHolder1_txtTenHangHoa").autocomplete({
                            minLength: 0,
                            source: listKhachHangAutocomplete,

                            focus: function (event, ui) {
                                $("#ContentPlaceHolder1_txtTenHangHoa").val(ui.item.label);
                                return false;
                            },
                            select: function (event, ui) {
                                $("#ContentPlaceHolder1_txtTenHangHoa").val(ui.item.value);


                                //$( "#results").text($("#topicID").val());    
                                //alert($("#hdIdKhuVuc").val());
                                return false;
                            }
                        })
                    }
                    else {
                        alert("Lỗi tải tên khách hàng!")
                    }

                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=THHhoa", true);
            xmlhttp.send();
        }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server">
    <div class="content-wrapper">
    <!-- Main content -->
    <section class="content">
    <div class="title">DANH MỤC TRẢ HÀNG</div>
    <div class="box">
        <div class="box-body">
           <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Mã phiếu nhập:</b></div>
                          <div class="txtinput">
                               <input class="form-control" placeholder="--Chọn--" data-val="true" data-val-required="" id="txtMaPhieuNhap" runat="server" name="Content.ContentName" type="text" value=""  />
                          </div>
                        </div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Tên hàng hóa:</b></div>
                          <div class="txtinput">
                                <input class="form-control" placeholder="--Chọn--" data-val="true" data-val-required="" id="txtTenHangHoa" runat="server" name="Content.ContentName" type="text" value=""  />
                          </div>
                        </div>
                      </div>
                </div> 
             <div class="form-group">
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
                <table class='table table-bordered table-striped'>
                    <tr>
                        <th class='th'>
                        			STT 						 								
                        </th>
                       
                         
                        <th class='th'>
                        Tên khách hàng
                        </th>
                        <th class='th'>
                         Tên hàng hóa
                        </th>
                         <th class='th'>
                         Hình thức
                        </th>
                       
                          <th class='th'>
                   Số lượng
                        </th>
                         <th class='th'>
                        	Ngày đổi/trả						
	 								

                        </th>
                         <th class='th'>
               Nội dung
                        </th>
                           <th class='th'>
                  Ghi chú	
                      </th>
                          <th class='th'>
              Sửa
                        </th>

                          <th class='th'>
              Xóa
                        </th>
                    </tr>
                  
                </table>
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

