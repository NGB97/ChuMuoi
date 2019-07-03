<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="MauSac.aspx.cs" Inherits="DanhMuc_DonViTinh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <script src="../dist/jquery-ui-1.11.3/jquery-ui.js"></script>
    <link href="../dist/jquery-ui-1.11.3/jquery-ui.css" rel="stylesheet"/>
      <script>
          window.onload = function () {
              //MauSacAutocomplete();
              //$("#ContentPlaceHolder1_txtTenKhachHang").val("--Chọn--");            
          }
          //
          function DeleteMauSac(IDMauSac) {
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
                  xmlhttp.open("GET", "../Ajax.aspx?Action=DeleteMauSac&IDMauSac=" + IDMauSac, true);
                  xmlhttp.send();
              }
          }
          //
          function MauSacAutocomplete() {
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
                          $("#ContentPlaceHolder1_txtTenMau").autocomplete({

                              minLength: 0,
                              source: listKhachHangAutocomplete,
                              focus: function (event, ui) {
                                  $("#ContentPlaceHolder1_txtTenMau").val(ui.item.label);
                                  return false;
                              },
                              select: function (event, ui) {
                                  $("#ContentPlaceHolder1_txtTenMau").val(ui.item.value);
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
              xmlhttp.open("GET", "../Ajax.aspx?Action=MauSacAutocomplete", true);
              xmlhttp.send();
          }

        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server">
    <div class="content-wrapper">
    <!-- Main content -->
    <section class="content">
    <div class="title">DANH MỤC MÀU SẮC</div>
    <div class="box">
        <div class="box-body">
            <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Tên màu sắc:</b></div>
                          <div class="txtinput">
                                <input class="form-control"  data-val="true" data-val-required="" id="txtTenMau" runat="server" name="Content.ContentName" type="text" value=""   />
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
                    <a class="btn btn-primary btn-flat" href="MauSac-CapNhat.aspx"><i class="glyphicon glyphicon-plus"></i>&nbsp;&nbsp;&nbsp; Thêm mới</a>
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
                          Mã màu
                        </th>
                        <th class='th'>
                          Tên màu
                        </th>
                        
                        <th class='th'>
                          Ghi chú
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
        
        </form>
</asp:Content>

