<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="DanhMucHangHoa.aspx.cs" Inherits="DanhMuc_DanhMucHangHoa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
          <script src="../dist/jquery-ui-1.11.3/jquery-ui.js"></script>
    <link href="../dist/jquery-ui-1.11.3/jquery-ui.css" rel="stylesheet"/>

    <script>
        window.onload = function () {
            //TenSanPhamAutocomplete();
            //MaSanPhamAutocomplete();

        }
        function XemTonGiuaCacKho(IDHangHoa) {
            var xmlhttp;
            if (window.XMLHttpRequest) {// code for IE7+, Firefox, Chrome, Opera, Safari
                xmlhttp = new XMLHttpRequest();
            }
            else {// code for IE6, IE5
                xmlhttp = new ActiveXObject("Microsoft.XMLHTTP");
            }
            xmlhttp.onreadystatechange = function () {
                if (xmlhttp.readyState == 4 && xmlhttp.status == 200) {
                   
                        //alert(xmlhttp.responseText);
                        var txt = xmlhttp.responseText;
                        $('#dvXemDungCu2').html(txt);
                      
                        MoXemDungCu2();
                      
                    

                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=XemTonGiuaCacKho&IDHangHoa=" + IDHangHoa, true);
            xmlhttp.send();
        }
        function Mo2(IDHangHoa) {
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
                             ;

                        var listKhachHangAutocomplete = eval("(" + txt + ")");
                        MoXemDungCu2();
                        $("#ContentPlaceHolder1_txtDongGoi").val(listKhachHangAutocomplete[3]);
                        $("#ContentPlaceHolder1_txtDonViTinh").val(listKhachHangAutocomplete[1]);
                        $("#ContentPlaceHolder1_txtChungLoai").val(listKhachHangAutocomplete[2]);
                        $("#ContentPlaceHolder1_txtNhomHangHoa").val(listKhachHangAutocomplete[0]);
                        $("#ContentPlaceHolder1_txtMauSac").val(listKhachHangAutocomplete[5]);
                        $("#ContentPlaceHolder1_txtBarcodeSPTheoDVT").val(listKhachHangAutocomplete[6]);
                        $("#ContentPlaceHolder1_txtBarcodeHopLocInner").val(listKhachHangAutocomplete[7]);
                        $("#ContentPlaceHolder1_txtMuc").val(listKhachHangAutocomplete[8]);
                        $("#ten").html("CHI TIẾT THÔNG TIN SẢN PHẨM "+listKhachHangAutocomplete[4]);
                    }
                    else {
                        //alert("Lỗi get tên nhân viên !")
                    }

                }
            }
            xmlhttp.open("GET", "../Ajax.aspx?Action=Mo2&IDHangHoa=" + IDHangHoa, true);
            xmlhttp.send();
        }
        function MoXemDungCu2() {
            document.getElementById('lightXemDungCu2').style.display = 'block';
            document.getElementById('fadeXemDungCu2').style.display = 'block';
        }
        function DongXemDungCu2() {
            document.getElementById('lightXemDungCu2').style.display = 'none';
            document.getElementById('fadeXemDungCu2').style.display = 'none';
        }
        //
        function DeleteHangHoa(IDHangHoa) {
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
                            alert("Lỗi hàng hóa này có thể nằm trong phiếu nhập hoặc phiếu xuất !")
                    }
                }
                xmlhttp.open("GET", "../Ajax.aspx?Action=DeleteHangHoa&IDHangHoa=" + IDHangHoa, true);
                xmlhttp.send();
            }
        }
        //
        function MaSanPhamAutocomplete() {
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
                        $("#ContentPlaceHolder1_txtMaHangHoa").autocomplete({

                            minLength: 0,
                            source: listKhachHangAutocomplete,
                            focus: function (event, ui) {
                                $("#ContentPlaceHolder1_txtMaHangHoa").val(ui.item.label);
                                return false;
                            },
                            select: function (event, ui) {
                                $("#ContentPlaceHolder1_txtMaHangHoa").val(ui.item.value);
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
            xmlhttp.open("GET", "../Ajax.aspx?Action=MaSanPhamAutocomplete", true);
            xmlhttp.send();
        }

        function TenSanPhamAutocomplete() {
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
                        $("#ContentPlaceHolder1_txtTenHangHoa").autocomplete({

                            minLength: 0,
                            source: listKhachHangAutocomplete,
                            focus: function (event, ui) {
                                $("#ContentPlaceHolder1_txtTenHangHoa").val(ui.item.label);
                                return false;
                            },
                            select: function (event, ui) {
                                $("#ContentPlaceHolder1_txtTenHangHoa").val(ui.item.value);
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
            xmlhttp.open("GET", "../Ajax.aspx?Action=TenSanPhamAutocomplete", true);
            xmlhttp.send();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form runat="server">
    <div class="content-wrapper">
    <!-- Main content -->
    <section class="content">
    <div class="title">DANH MỤC CHI TIẾT HÀNG HÓA</div>
    <div class="box">
        <div class="box-body">
            <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Tên chi tiết hàng hóa:</b></div>
                          <div class="txtinput">
                                <input class="form-control" data-val="true" data-val-required="" id="txtTenHangHoa" runat="server" name="Content.ContentName" type="text" value=""  />
                          </div>
                        </div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Mã chi tiết hàng hóa:</b></div>
                          <div class="txtinput">
                                <input class="form-control" data-val="true" data-val-required="" id="txtMaHangHoa" runat="server" name="Content.ContentName" type="text" value=""  />
                          </div>
                        </div>
                      </div>
                </div>
       
              
            <div class="row">
                <div class="col-sm-9">
                    <a class="btn btn-primary btn-flat" href="DanhMucHangHoa-CapNhat.aspx"><i class="glyphicon glyphicon-plus"></i>&nbsp;&nbsp;&nbsp; Thêm mới</a>
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
                         Mã HH						

                        </th>
                        <th class='th'>
                         Tên sản phẩm
                        </th>
                        <th class='th'>
                         Số lượng đang có hiện tại
                        </th>
                        <th class='th'>
                         Đơn giá nhập hiện tại
                        </th>
                       
                        
                          <th class='th'>Ghi chú			
                        </th>

                          <th class='th'>
                        </th>
                    </tr>
                    <tr>
                        <td>1
                            										


                        </td>
                        <td>SP001</td>
                        <td>giấy văn phòng xanh</td>
                        <td>30</td>
                        
                        <td>xấp</td>
                        <td>xanh</td>
                      
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
         <div id="lightXemDungCu2" class="white_content" style=" top: 30%; width: 40%; left: 31%; height: 40%;">
        <div class="box">
            <div id="dvDungCu2" class="box-body">
                <div style="text-align:center; font-weight:bold; padding:10px" id="ten">XEM TỒN KHO</div>
                <div id="dvXemDungCu2" style="padding:10px; text-align:center">
                   
                  
                    <div class="form-group">
                                    <div class="row">
                                        <div class="dvnull">&nbsp;</div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Nhóm hàng hóa:</b></div>
                                            <div class="txtinput" style="padding-top:0px; text-align:left">
                                              
                                                <input class="form-control" data-val="true" data-val-required="" disabled="disabled" id="txtNhomHangHoa" runat="server" name="Content.ContentName" type="text" value="" />
                                            </div>
                                        </div>
                                      <div class="coninput1">
                                            <div class="titleinput"><b>Màu:</b></div>
                                            <div class="txtinput" style="padding-top:0px; text-align:left">
                                              
                                                <input class="form-control" data-val="true" data-val-required="" disabled="disabled" id="txtMauSac" runat="server" name="Content.ContentName" type="text" value="" />
                                            </div>
                                        </div>
                                    </div>
                        </div>

                    <div class="form-group">
                                    <div class="row">
                                        <div class="dvnull">&nbsp;</div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Barcode SP theo ĐVT:</b></div>
                                            <div class="txtinput" style="padding-top:0px; text-align:left">
                                              
                                                <input class="form-control" data-val="true" data-val-required="" disabled="disabled" id="txtBarcodeSPTheoDVT" runat="server" name="Content.ContentName" type="text" value="" />
                                            </div>
                                        </div>
                                      <div class="coninput1">
                                            <div class="titleinput"><b>Barcode Hộp/Lốc/Inner:</b></div>
                                            <div class="txtinput" style="padding-top:0px; text-align:left">
                                              
                                                <input class="form-control" data-val="true" data-val-required="" disabled="disabled" id="txtBarcodeHopLocInner" runat="server" name="Content.ContentName" type="text" value="" />
                                            </div>
                                        </div>
                                    </div>
                        </div>

                    <div class="form-group">
                                    <div class="row">
                                        <div class="dvnull">&nbsp;</div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Đơn vị tính</b></div>
                                            <div class="txtinput" style="padding-top:0px; text-align:left">

                                                    <input class="form-control" data-val="true" data-val-required="" disabled="disabled" id="txtDonViTinh" runat="server" name="Content.ContentName" type="text" value="" />
                                            </div>
                                        </div>
                                       <div class="coninput1">
                                            <div class="titleinput"><b>Mục</b></div>
                                            <div class="txtinput" style="padding-top:0px; text-align:left">

                                                    <input class="form-control" data-val="true" data-val-required="" disabled="disabled" id="txtMuc" runat="server" name="Content.ContentName" type="text" value="" />
                                            </div>
                                        </div>
                                    </div>
                        </div>

                    
                  
                
                   
                      <div class="form-group">
                            <label class="col-md-2 control-label" for="Content_ContentName">Đóng gói</label>
                                  <div class="col-md-10">
                                        <textarea class="form-control" data-val="true" data-val-required="" disabled="disabled" id="txtDongGoi" runat="server" name="Content.ContentName" type="text" value="" ></textarea> <br /> 
                                  </div>
                               
                                 <label class="col-md-2 control-label" for="Content_ContentName">Chủng loại</label>
                                  <div class="col-md-10">
                                        <textarea class="form-control" data-val="true" data-val-required="" disabled="disabled" id="txtChungLoai" runat="server" name="Content.ContentName" type="text" value="" ></textarea>
                                  </div>

                     </div>
                    
                      
                    </div>
                </div>
        </div>
     
            </div>
       
    <div id="fadeXemDungCu2" onclick="DongXemDungCu2()" class="black_overlay"></div>

    <!-- /.content -->
  </div>
        
        </form>
</asp:Content>

