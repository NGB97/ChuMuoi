<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="DanhMucNhapHang.aspx.cs" Inherits="QuanLyXuatNhap_DanhMucNhapHang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script src="../dist/jquery-ui-1.11.3/jquery-ui.js"></script>
    <link href="../dist/jquery-ui-1.11.3/jquery-ui.css" rel="stylesheet"/>
    <script>
        window.onload = function () {
            LoadNhaCungCap();

        }
         
        function LoadNhaCungCap() {
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
                        $("#ContentPlaceHolder1_txtNhaCungCap").autocomplete({
                            minLength: 0,
                            source: listKhachHangAutocomplete,

                            focus: function (event, ui) {
                                $("#ContentPlaceHolder1_txtNhaCungCap").val(ui.item.label);
                                return false;
                            },
                            select: function (event, ui) {
                                $("#ContentPlaceHolder1_hdNhaCungCap").val(ui.item.value);
                                return false;
                            }
                        })
                    }
                    else {
                        alert("Lỗi internet!")
                    }

                }
            }
            xmlhttp.open("GET", "../Ajax3.aspx?Action=LoadKhachHang", true);
            xmlhttp.send();
        }





        function Inpdf(IDPhieuNhap) {
           
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
                      
                       // window.open('../Files/'+xmlhttp.responseText);
                    }
                    else {
                        alert("Lỗi tải tên khách hàng!")
                    }

                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=Inpdf&IDPhieuNhap=" + IDPhieuNhap, true);
            xmlhttp.send();
        }
        function LoadChiTietNhapHang(IDPhieuNhap) {
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
                        var txt = xmlhttp.responseText;

                        $("#dvQuyCach").html(txt); MoXemQuyCach();
                     //   window.location.hash = IDPhieuNhap;
                       
                    }
                    else {
                        alert("Lỗi tải tên khách hàng!")
                    }

                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=LoadChiTietNhapHang&IDPhieuNhap=" + IDPhieuNhap, true);
            xmlhttp.send();
        }
        function loadmaphieunhap() {
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


        function DeletePhieuNhap(IDPhieuNhap) {
            if (confirm("Khi xóa phiếu nhập hàng, tất cả hàng hóa trong phiếu nhập đều sẽ bị xóa. Bạn có chắc chắn xóa không?")) {
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
                            alert("Không thể xóa!")
                    }
                }
                xmlhttp.open("GET", "../Ajax.aspx?Action=DeletePhieuNhap&IDPhieuNhap=" + IDPhieuNhap, true);
                xmlhttp.send();
            }
        }

        function MoXemQuyCach() {
            document.getElementById('lightXemQuyCach').style.display = 'block';
            document.getElementById('fadeXemQuyCach').style.display = 'block';
        }
        function DongXemQuyCach() {
            document.getElementById('lightXemQuyCach').style.display = 'none';
            document.getElementById('fadeXemQuyCach').style.display = 'none';
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server">
    <div class="content-wrapper">
    <!-- Main content -->
    <section class="content">
    <div class="title">QUẢN LÝ TRẢ HÀNG</div>
    <div class="box">
        <div class="box-body">
            <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Khách hàng:</b></div>
                          <div class="txtinput">
                                <input class="form-control"  data-val="true" data-val-required="" id="txtMaPhieuNhap" runat="server" name="Content.ContentName" type="hidden" value=""  />

                                <input class="form-control"  data-val="true" data-val-required="" id="txtNhaCungCap" runat="server" name="Content.ContentName" type="text" value="" placeholder="--- Chọn ---"  />

                              <input class="form-control"  data-val="true" data-val-required="" id="hdNhaCungCap" runat="server" name="Content.ContentName" type="hidden" value=""  />

                          </div>
                        </div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Mã hàng hóa:</b></div>
                          <div class="txtinput">
                                <input class="form-control" data-val="true" data-val-required="" id="txtMaHangHoa" runat="server" name="Content.ContentName" type="text" value=""  />
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
                    <a class="btn btn-primary btn-flat" href="DanhMucNhapHang-CapNhat.aspx"><i class="glyphicon glyphicon-plus"></i>&nbsp;&nbsp;&nbsp; Thêm mới</a>
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
                          Mã phiếu nhập
                        </th>
                      
                       
                          <th class='th'>
                      Ngày lập phiếu
                        </th>
                         
                         
                          <th class='th'>
                    	Ghi chú		
                        </th>
                         <th class='th'>
                    
                        </th>
                         <th class='th'>
                    	
                        </th>
                    </tr>
                  
                </table>
            </div>
        </div>
    </div>

</section>


    <!-- /.content -->
  </div>
        <!--Popup xem quy cách-->
    <div id="lightXemQuyCach" class="white_content" style=" top: 10%; width: 70%; left: 15%; height: 80%;">
     
        <div class="box">
            
            <div id="dvQuyCach" class="box-body">
                
            </div>
        </div>
    </div>
    <div id="fadeXemQuyCach" onclick="DongXemQuyCach()" class="black_overlay"></div>
    <!--End popup--->

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
        </form>
</asp:Content>

