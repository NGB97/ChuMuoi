﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="SoSanhGiaNhap.aspx.cs" Inherits="QuanLyNguoiDung_QuanLyNguoiDung" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server"> <script src="../dist/jquery-ui-1.11.3/jquery-ui.js"></script>
    <link href="../dist/jquery-ui-1.11.3/jquery-ui.css" rel="stylesheet"/>
     <script>
         window.onload = function () {
             //LoadTaiKhoan(); 
             LoadTenNguoiDung();
         }

         function LoadTenNguoiDung() {
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
                         $("#ContentPlaceHolder1_txtTenNguoiDung").autocomplete({

                             minLength: 0,
                             source: listKhachHangAutocomplete,
                             focus: function (event, ui) {
                                 $("#ContentPlaceHolder1_txtTenNguoiDung").val(ui.item.value);
                                 return false;
                             },
                             select: function (event, ui) {
                                 $("#ContentPlaceHolder1_txtTenNguoiDung").val(ui.item.value);
                                 $("#ContentPlaceHolder1_hiden1").val(ui.item.id);
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
             xmlhttp.open("GET", "../Ajax.aspx?Action=LoadTenNguoiDung", true);
             xmlhttp.send();
         }



         function LoadTaiKhoan() {
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
                         $("#ContentPlaceHolder1_txtTaiKhoan").autocomplete({

                             minLength: 0,
                             source: listKhachHangAutocomplete,
                             focus: function (event, ui) {
                                 $("#ContentPlaceHolder1_txtTaiKhoan").val(ui.item.label);
                                 return false;
                             },
                             select: function (event, ui) {
                                 $("#ContentPlaceHolder1_txtTaiKhoan").val(ui.item.value);
                                 //  $("#ContentPlaceHolder1_idNCC").val(ui.item.id);
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
             xmlhttp.open("GET", "../Ajax.aspx?Action=LoadTaiKhoan", true);
             xmlhttp.send();
         }
         //

         function DeleteNguoiDung(IDNguoiDung) {
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
                 xmlhttp.open("GET", "../Ajax.aspx?Action=DeleteNguoiDung&IDNguoiDung=" + IDNguoiDung, true);
                 xmlhttp.send();
             }
         }


         </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server">
    <div class="content-wrapper">
    <!-- Main content -->
    <section class="content">
    <div class="title">SO SÁNH GIÁ NHẬP CÁC NHÀ CUNG CẤP</div>
    <div class="box">
        <div class="box-body">
            <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Hàng Hóa:</b></div>
                          <div class="txtinput">
                                <input class="form-control"  data-val="true" data-val-required="" id="txtTenNguoiDung" runat="server" name="Content.ContentName" type="text" value=""  />
                                <input class="form-control"  data-val="true" data-val-required="" id="hiden1" runat="server" name="Content.ContentName" type="hidden" value=""  />

                          </div>
                        </div>
                        <div class="coninput1">

                          <div class="titleinput" style="margin-top:-5px" ><asp:Button ID="btTimKiem" class="btn btn-primary btn-flat" runat="server" Text="Xem giá nhập" OnClick="btTimKiem_Click" /></div>

                           

                          <div class="txtinput" style="display:none" >
                                
                                <select class="form-control" id="txtQuyen" runat="server" name="Content.ContentName">
                                   <option value="">&nbsp;</option>
                                    <option value="NhanVien">Nhân viên</option>
                                    <option value="Admin">Admin</option>
                                </select>
                          </div>
                        </div>
                      </div>
                </div>
            <div class="form-group" style="display:none">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Tài khoản:</b></div>
                          <div class="txtinput">


                                <input class="form-control"  data-val="true" data-val-required="" id="txtTaiKhoan" runat="server" name="Content.ContentName" type="text" value=""  />
                          </div>
                        </div>
                        
                      </div>
                </div>
        
              
            <div class="row" style="display:none">
                <div class="col-sm-9">
                    <a class="btn btn-primary btn-flat" href="QuanLyNguoiDung-CapNhat.aspx"><i class="glyphicon glyphicon-plus"></i>&nbsp;&nbsp;&nbsp; Thêm mới</a>
                </div>
                <div class="col-sm-3">
                        <div style="text-align:right;">
                           
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

