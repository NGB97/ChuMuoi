<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="DanhMucPhongBan.aspx.cs" Inherits="DanhMuc_DanhMucPhongBan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

    <script src="../dist/jquery-ui-1.11.3/jquery-ui.js"></script>
    <link href="../dist/jquery-ui-1.11.3/jquery-ui.css" rel="stylesheet"/>
  
    <script>
        window.onload = function () {
            TenPhongBanAutocomplete(); TenKHAutocomplete();
            //$("#ContentPlaceHolder1_txtTenKhachHang").val("--Chọn--");            
        }
        //
        function XemCuaHang(IDPhongBan) {
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
                       // alert(xmlhttp.responseText);
                        var txt = xmlhttp.responseText ;
                        $("#dvXemSanPham").html(txt);
                        MoXemGiayPhepLaiXe();
                    }
                    else {
                        //alert("Lỗi get tên nhân viên !")
                    }

                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=XemCuaHang&IDPhongBan=" + IDPhongBan, true);
            xmlhttp.send();
        }
        //
        function TenKHAutocomplete() {
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

                        var listKhachHangAutocomplete = eval("(" + txt + ")");
                        //alert(listKhuVucAutocomplete.toString());
                        //listKhuVucAutocomplete = [{ value: 'Công ty CP CT VIỆTTRONICS', label: 'Công ty CP CT VIỆTTRONICS', id: '2' }];
                        $("#ContentPlaceHolder1_txtTenKhachHang").autocomplete({

                            minLength: 0,
                            source: listKhachHangAutocomplete,
                            focus: function (event, ui) {
                                $("#ContentPlaceHolder1_txtTenKhachHang").val(ui.item.label);
                                return false;
                            },
                            select: function (event, ui) {
                                $("#ContentPlaceHolder1_txtTenKhachHang").val(ui.item.value);

                                //$( "#results").text($("#topicID").val());    
                                //alert($("#hdIdKhuVuc").val());
                                return false;
                            }
                        })
                    }
                    else {
                        //alert("Lỗi get tên nhân viên !")
                    }

                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=TenKhachAutocomplete", true);
            xmlhttp.send();
        }
        //
        function DeletePhongBan(IDPhongBan) {
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
                            alert("Lỗi phòng ban này có thể có cửa hàng xin hãy xóa hết cửa hàng của phòng ban muốn xóa,hoặc có thể Khách hàng này vẫn còn đơn hàng xin hãy xóa đi đơn hàng xuất của khách hàng này!")
                    }
                }
                xmlhttp.open("GET", "../Ajax.aspx?Action=DeletePhongBan&IDPhongBan=" + IDPhongBan, true);
                xmlhttp.send();
            }
        }
        //
        function TenPhongBanAutocomplete() {
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

                        var listKhachHangAutocomplete = eval("(" + txt + ")");
                        //alert(listKhuVucAutocomplete.toString());
                        //listKhuVucAutocomplete = [{ value: 'Công ty CP CT VIỆTTRONICS', label: 'Công ty CP CT VIỆTTRONICS', id: '2' }];
                        $("#ContentPlaceHolder1_txtTenPhongBan").autocomplete({

                            minLength: 0,
                            source: listKhachHangAutocomplete,
                            focus: function (event, ui) {
                                $("#ContentPlaceHolder1_txtTenPhongBan").val(ui.item.label);
                                return false;
                            },
                            select: function (event, ui) {
                                $("#ContentPlaceHolder1_txtTenPhongBan").val(ui.item.value);
                                
                                //$( "#results").text($("#topicID").val());    
                                //alert($("#hdIdKhuVuc").val());
                                return false;
                            }
                        })
                    }
                    else {
                        //alert("Lỗi get tên nhân viên !")
                    }

                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=TenPhongBanAutocomplete", true);
            xmlhttp.send();
        }
       

        function MoXemGiayPhepLaiXe() {
            document.getElementById('lightXemGiayPhepLaiXe').style.display = 'block';
            document.getElementById('fadeXemGiayPhepLaiXe').style.display = 'block';
        }
        function DongXemGiayPhepLaiXe() {
            document.getElementById('lightXemGiayPhepLaiXe').style.display = 'none';
            document.getElementById('fadeXemGiayPhepLaiXe').style.display = 'none';
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server">
    <div class="content-wrapper">
    <!-- Main content -->
    <section class="content">
    <div class="title">DANH MỤC PHÒNG BAN</div>
    <div class="box">
        <div class="box-body">
           
            <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                       
                        <div class="coninput1">
                          <div class="titleinput"><b>Tên phòng ban:</b></div>
                          <div class="txtinput">
                                <input class="form-control" data-val="true" placeholder="--Chọn--" data-val-required="" id="txtTenPhongBan" runat="server" name="Content.ContentName" type="text" value=""  />
                          </div>
                        </div>

                          <div class="coninput1">
                          <div class="titleinput"><b>Tên khách hàng:</b></div>
                          <div class="txtinput">
                                <input class="form-control" data-val="true" placeholder="--Chọn--" data-val-required="" id="txtTenKhachHang" runat="server" name="Content.ContentName" type="text" value=""  />
                          </div>
                        </div>
                      </div>
                </div>
              
            <div class="row">
                <div class="col-sm-9">
                    <a class="btn btn-primary btn-flat" href="DanhMucPhongBan-CapNhat.aspx"><i class="glyphicon glyphicon-plus"></i>&nbsp;&nbsp;&nbsp; Thêm mới</a>
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
                          Mã khách hàng
                        </th>
                        <th class='th'>
                          Tên khách hàng
                        </th>
                        <th class='th'>
                          Cấp đại lý			

                        </th>
                       <th class='th'>
                         Số điện thoại
                        </th>
                        <th class='th'>
                         Địa chỉ
                        </th>
                       
                        <th class='th'>
                        </th>
                    </tr>
                    <tr>
                        <td>1</td>
                        <td>ABC</td>
                        <td>ABC</td>
                        <td>ABC</td>
                        <td>ABC</td>
                       <td>ABC</td>
                        <td>Giấy phép lái xe</td>
                        <td>
                            <a href="#"><img class="imgedit" src="../images/edit.png" />Sửa</a>|
                            <a href="#"><img class="imgedit" src="../images/delete.png" />Xóa</a>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>

</section>


    <!-- /.content -->
  </div>
        <!--Popup xem giấy phép lái xe-->
    <div id="lightXemGiayPhepLaiXe" class="white_content" style=" top: 10%; width: 70%; left: 15%; height: 80%;">
        <div class="box">
            <div id="dvGiayPhepLaiXe" class="box-body">
               
                <div id="dvXemSanPham" style="padding:10px; text-align:center">
                   
                        <table class="table table-bordered table-striped">
                                <tr>
                                    <th class="th">
                                        STT
                                    </th>
                                    <th class="th">
                                        Số giấy phép lái xe
                                    </th>
                                    <th class="th">
                                        Hạng xe
                                    </th>
                                    <th class="th">
                                        Ngày hết hạn
                                    </th>
                                </tr>
                                <tr>
                                        <td>
                                            1
                                        </td>
                                        <td>
                                            GPLX0001
                                        </td>
                                        <td>
                                            A1
                                        </td>
                                        <td>
                                            25/05/2015
                                        </td>
                                    </tr>
                                <tr>
                                        <td>
                                            2
                                        </td>
                                        <td>
                                            GPLX0002
                                        </td>
                                        <td>
                                            A2
                                        </td>
                                        <td>
                                            25/05/2020
                                        </td>
                                    </tr>
                            </table>
                    </div>
                </div>
            </div>
        </div>
    <div id="fadeXemGiayPhepLaiXe" onclick="DongXemGiayPhepLaiXe()" class="black_overlay"></div>
    <!--End popup--->
        </form>
</asp:Content>

