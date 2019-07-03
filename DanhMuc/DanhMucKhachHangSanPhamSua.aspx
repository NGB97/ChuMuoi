<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="DanhMucKhachHangSanPhamSua.aspx.cs" Inherits="DanhMuc_DanhMucKhachHangSanPham_CapNhat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <script src="../dist/jquery-ui-1.11.3/jquery-ui.js"></script>
    <link href="../dist/jquery-ui-1.11.3/jquery-ui.css" rel="stylesheet"/>
      <script>
          window.onload = function () {
              TenKhachTheoSanPhamAutocomplete();
              TenSanPhamTheoKhachAutocomplete();

          }
          //
          function TenSanPhamTheoKhachAutocomplete() {
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
                          $("#ContentPlaceHolder1_txtTenSanPham").autocomplete({

                              minLength: 0,
                              source: listKhachHangAutocomplete,
                              focus: function (event, ui) {
                                  $("#ContentPlaceHolder1_txtTenSanPham").val(ui.item.label);
                                  return false;
                              },
                              select: function (event, ui) {
                                  $("#ContentPlaceHolder1_txtTenSanPham").val(ui.item.label);
                                  $("#ContentPlaceHolder1_txtIDSanPham").val(ui.item.id);
                                  //$( "#results").text($("#topicID").val());    
                                  //  alert($("#hdIdKhuVuc").val());
                                  return false;
                              }
                          })
                      }
                      else {
                          //alert("Lỗi get tên nhân viên !")
                      }

                  }
              }
              xmlhttp.open("GET", "../Ajax.aspx?Action=TenSanPhamTheoKhachAutocomplete", true);
              xmlhttp.send();
          }
          //
          function TenKhachTheoSanPhamAutocomplete() {
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
                                  $("#ContentPlaceHolder1_txtIDKhachHang").val(ui.item.id);
                                  //$( "#results").text($("#topicID").val());    
                                //  alert($("#hdIdKhuVuc").val());
                                  return false;
                              }
                          })
                      }
                      else {
                          //alert("Lỗi get tên nhân viên !")
                      }

                  }
              }
              xmlhttp.open("GET", "../Ajax.aspx?Action=TenKhachTheoSanPhamAutocomplete", true);
              xmlhttp.send();
          }
          //
          function TinhTien() {
              $('#ContentPlaceHolder1_txtGiaBan').keyup(function () {
                  $('#ContentPlaceHolder1_txtGiaBan').val($('#ContentPlaceHolder1_txtGiaBan').val().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));
                  var SoTien = 0;
                  var Vat = 0;

                  if ($('#ContentPlaceHolder1_txtGiaBan').val() == "")
                      SoTien = 0;
                  else
                      SoTien = $('#ContentPlaceHolder1_txtGiaBan').val().replace(/\./g, '').replace(/\,/g, '');

                  if ($('#ContentPlaceHolder1_txtVAT').val() == "")
                      Vat = 0;
                  else
                      Vat = $('#ContentPlaceHolder1_txtVAT').val().replace(/\./g, '').replace(/\,/g, '');

                  var TongTien = parseInt(parseInt(SoTien) + (parseInt(SoTien) * parseInt(Vat)) / 100);
                  var TienThue = parseInt((parseInt(SoTien) * parseInt(Vat)) / 100);
                  $('#ContentPlaceHolder1_txtTongTien').val(TongTien.toString().replace(/\B(?=(\d{3})+(?!\d))/g, "."));
                  $('#ContentPlaceHolder1_txtTienThue').val(TienThue.toString().replace(/\B(?=(\d{3})+(?!\d))/g, "."));

              }
              );

              $('#ContentPlaceHolder1_txtVAT').keyup(function () {
                  $('#ContentPlaceHolder1_txtVAT').val($('#ContentPlaceHolder1_txtVAT').val().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));

                  var SoTien = 0;
                  var Vat = 0;
                  var TienThue = 0;

                  if ($('#ContentPlaceHolder1_txtVAT').val() == "")
                      Vat = 0;
                  else
                      Vat = $('#ContentPlaceHolder1_txtVAT').val().replace(/\./g, '').replace(/\,/g, '');

                  if ($('#ContentPlaceHolder1_txtSoTien').val() == "")
                      SoTien = 0;
                  else
                      SoTien = $('#ContentPlaceHolder1_txtSoTien').val().replace(/\./g, '').replace(/\,/g, '');

                  var TienThue = parseInt((parseInt(SoTien) * parseInt(Vat)) / 100);
                  var TongTien = parseInt(parseInt(SoTien) + (parseInt(SoTien) * parseInt(Vat)) / 100);
                  $('#ContentPlaceHolder1_txtTongTien').val(TongTien.toString().replace(/\B(?=(\d{3})+(?!\d))/g, "."));
                  $('#ContentPlaceHolder1_txtTienThue').val(TienThue.toString().replace(/\B(?=(\d{3})+(?!\d))/g, "."));

              }
              );

              $('#ContentPlaceHolder1_txtTienThue').keyup(function () {
                  $('#ContentPlaceHolder1_txtTienThue').val($('#ContentPlaceHolder1_txtTienThue').val().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));

                  var SoTien = 0;
                  var Vat = 0;
                  var TienThue = 0;

                  if ($('#ContentPlaceHolder1_txtTienThue').val() == "")
                      TienThue = 0;
                  else
                      TienThue = $('#ContentPlaceHolder1_txtTienThue').val().replace(/\./g, '').replace(/\,/g, '');


                  if ($('#ContentPlaceHolder1_txtSoTien').val() == "")
                      SoTien = 0;
                  else
                      SoTien = $('#ContentPlaceHolder1_txtSoTien').val().replace(/\./g, '').replace(/\,/g, '');

                  if (TienThue != 0) {
                      Vat = parseInt((parseInt(TienThue) / parseInt(SoTien)) * 100);
                  }
                  var TongTien = parseInt(parseInt(SoTien) + (parseInt(SoTien) * parseInt(Vat)) / 100);
                  $('#ContentPlaceHolder1_txtTongTien').val(TongTien.toString().replace(/\B(?=(\d{3})+(?!\d))/g, "."));
                  $('#ContentPlaceHolder1_txtVAT').val(Vat.toString().replace(/\B(?=(\d{3})+(?!\d))/g, "."));

              }
             );
          }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper">
    <!-- Main content -->
    <div class="title" id="dvTitle" runat="server">THÊM THÔNG TIN GIÁ CẢ HÀNG HÓA THEO KHÁCH HÀNG</div>
    <div class="title1"><a href="DanhMucKhachHangSanPham.aspx"><i class="fa fa-step-backward"></i> Danh sách hàng hóa theo khách hàng</a></div>
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
                              <input  class="form-control" data-val="true" data-val-required="" id="txtTenSanPham" runat="server" name="Content.ContentName" type="text" value="" placeholder="--Chọn--" />
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

                <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Giá bán cho khách(*):</b></div>
                          <div class="txtinput">
                              <input class="form-control" data-val="true" data-val-required="" id="txtGiaBan" runat="server" name="Content.ContentName" type="text" value="" onkeyup="TinhTien();" />
                          </div>
                        </div>
                      </div> 
                </div>

                <div class="form-group">
                    <label class="col-md-2 control-label" for="Content_ContentName">Ghi chú:</label>
                    <div class="col-md-10">
                        <textarea class="form-control" runat="server" name="Content.ContentName" id ="txtGhiChu"></textarea>
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

