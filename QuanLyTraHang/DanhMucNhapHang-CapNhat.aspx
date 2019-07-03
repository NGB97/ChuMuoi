<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="DanhMucNhapHang-CapNhat.aspx.cs" Inherits="QuanLyDungCu_DanhMucNhapHang_CapNhat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
              <script src="../dist/jquery-ui-1.11.3/jquery-ui.js"></script>
    <link href="../dist/jquery-ui-1.11.3/jquery-ui.css" rel="stylesheet"/>
    <script>
        window.onload = function () {
            //TenSanPhamAutocomplete();
            LoadNhaCungCap();
            LoadKho();
        }
        var sttq1 = "";
        function LoadKho() {
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
                        $("#ContentPlaceHolder1_txtKho").autocomplete({

                            minLength: 0,
                            source: listKhachHangAutocomplete,
                            focus: function (event, ui) {
                                $("#ContentPlaceHolder1_txtKho").val(ui.item.label);
                                return false;
                            },
                            select: function (event, ui) {
                                $("#ContentPlaceHolder1_txtKho").val(ui.item.value);
                                $("#ContentPlaceHolder1_txtIDKho").val(ui.item.id);
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
            xmlhttp.open("GET", "../Ajax.aspx?Action=LoadKho", true);
            xmlhttp.send();
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

                        var listKhachHangAutocomplete = eval("(" + txt + ")");
                        //alert(listKhuVucAutocomplete.toString());
                        //listKhuVucAutocomplete = [{ value: 'Công ty CP CT VIỆTTRONICS', label: 'Công ty CP CT VIỆTTRONICS', id: '2' }];
                        $("#ContentPlaceHolder1_txtTenNCC").autocomplete({

                            minLength: 0,
                            source: listKhachHangAutocomplete,
                            focus: function (event, ui) {
                                $("#ContentPlaceHolder1_txtTenNCC").val(ui.item.label);
                                return false;
                            },
                            select: function (event, ui) {
                                $("#ContentPlaceHolder1_txtTenNCC").val(ui.item.value);
                                $("#ContentPlaceHolder1_txtIDNCC").val(ui.item.id);
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
            xmlhttp.open("GET", "../Ajax.aspx?Action=KhachHangAutocomplete", true);
            xmlhttp.send();
        }
        function MoXemQuyCach() {
            document.getElementById('lightXemQuyCach').style.display = 'block';
            document.getElementById('fadeXemQuyCach').style.display = 'block';
        }
        function DongXemQuyCach() {
            document.getElementById('lightXemQuyCach').style.display = 'none';
            document.getElementById('fadeXemQuyCach').style.display = 'none';
        }

        function MoXemDungCu() {
            document.getElementById('lightXemDungCu').style.display = 'block';
            document.getElementById('fadeXemDungCu').style.display = 'block';
        }
        function DongXemDungCu() {
            document.getElementById('lightXemDungCu').style.display = 'none';
            document.getElementById('fadeXemDungCu').style.display = 'none';
        }
        function TinhTien() {
            $('#ContentPlaceHolder1_txtTienDaThanhToan').keyup(function () {
                $('#ContentPlaceHolder1_txtTienDaThanhToan').val($('#ContentPlaceHolder1_txtTienDaThanhToan').val().replace(/\./g, '').replace(/\,/g, '').replace(/\B(?=(\d{3})+(?!\d))/g, "."));
                }
            );
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper">
    <!-- Main content -->
    <div class="title" id="dvTitle" runat="server">THÊM THÔNG TIN PHIẾU TRẢ HÀNG</div>
    <div class="title1"><a href="DanhMucNhapHang.aspx"><i class="fa fa-step-backward"></i> Danh sách phiếu trả hàng</a></div>
    <section class="content">
    <div class="box">
        <div class="box-body">
            <form class="form-horizontal" runat="server">
               <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Mã phiếu trả(*):</b></div>
                          <div class="txtinput">
                              <input class="form-control" data-val="true" data-val-required="" id="txtMaPhieuNhap" runat="server" name="Content.ContentName" type="text" value="" />
                          </div>
                        </div>
                        <div class="coninput2">
                          <div class="titleinput"><b>Ngày tạo phiếu trả(*):</b></div>
                          <div class="txtinput">
                              <input class="form-control" data-val="true" data-val-required="" id="txtNgayNhap" runat="server" name="Content.ContentName" type="text" value="" />
                          </div>
                        </div>
                      </div>
                </div> 
                <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Trả từ khách hàng(*):</b></div>
                          <div class="txtinput">
                              <input class="form-control" data-val="true" data-val-required="" id="txtTenNCC" runat="server" name="Content.ContentName" type="text" value="" placeholder="--Chọn--" />
                               <input class="form-control" data-val="true" data-val-required="" id="txtIDNCC" runat="server" name="Content.ContentName" type="hidden" value="" />
                          </div>
                        </div>
                        <div class="coninput2">
                          <div class="titleinput"><b>Trả vào kho(*):</b></div>
                          <div class="txtinput">
                              <input class="form-control" data-val="true" data-val-required="" id="txtKho" runat="server" name="Content.ContentName" type="hidden" value="" placeholder="--Chọn--" />
                               <select class="form-control" data-val="true" data-val-required="" id="txtIDKho" runat="server" name="Content.ContentName" ></select>
                          </div>
                        </div>
                      </div>
                </div> 
                <div class="form-group" style="display:none;">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Tiền thanh toán(*):</b></div>
                          <div class="txtinput">
                              <input onkeyup="TinhTien();" class="form-control" data-val="true" data-val-required="" id="txtTienDaThanhToan" runat="server" name="Content.ContentName" type="text" value="0" />
                             
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


                  <div class="form-group">
                   <%--    <label class="col-md-2 control-label" for="Content_ContentName" >Hàng hóa:</label> --%>
                    <div class="col-md-10">
                      <%--   <div>
                            <input type="button" onclick="MoXemDungCu()" value="Thêm hàng hóa" class="btn btn-primary btn-flat" style="width: 130px;" />
                        </div>--%>
                         <%--start --%>
                       <%--  <div id="hh">
                 <table class="table table-bordered table-striped">
                                <tr>
                                    <th class="th">
                                        STT
                                    </th>
                                     <th class="th">
                                        Mã phiếu nhập
                                    </th>
                                     <th class="th">
                                      Nhà cung cấp
                                    </th>
                                    <th class="th">
                                        Mã hàng hóa
                                    </th>
                                    <th class="th">
                                       Tên hàng hóa
                                    </th>
                                     <th class="th">
                                      Số lượng
                                    </th>
                                     <th class="th">
                                     Đơn giá nhập
                                    </th>
                                     <th class="th">
                                    Chủng loại
                                    </th>
                                       <th class="th">
                                    Nhóm hàng hóa
                                    </th>
                                       <th class="th">
                                   Đơn vị tính
                                    </th>
                                       <th class="th">
                                   Màu sắc
                                    </th>
                                       <th class="th">
                                   Đóng gói
                                    </th>
                                    <th class="th" >
                                        Ngày nhập
                                    </th>
                                      <th class="th" style="width:110px;">
                                      
                                    </th>
                                </tr>
                                <tr style="background-color: #b0daff;">
                                     <td rowspan="2" style="vertical-align: inherit;">&nbsp;</td>
                                      <td rowspan="2" style="vertical-align: inherit;">&nbsp;</td>
                                    <td rowspan="2" style="vertical-align: inherit;">&nbsp;</td>
                                   <td rowspan="2" style="vertical-align: inherit;">&nbsp;</td>
                                    <td rowspan="2" style="vertical-align: inherit;">&nbsp;</td>
                                    <td rowspan="2" style="vertical-align: inherit;">&nbsp;</td>
                                    <td rowspan="2" style="vertical-align: inherit;">&nbsp;</td>
                                    <td rowspan="2" style="vertical-align: inherit;">&nbsp;</td>
                                    <td rowspan="2" style="vertical-align: inherit;">&nbsp;</td>
                                    <td rowspan="2" style="vertical-align: inherit;">&nbsp;</td>
                                    <td rowspan="2" style="vertical-align: inherit;">&nbsp;</td>
                                    <td rowspan="2" style="vertical-align: inherit;">&nbsp;</td>
                                    <td rowspan="2" style="vertical-align: inherit;">&nbsp;</td>
                                     <td rowspan="2" style="vertical-align: inherit;">&nbsp;</td>
                                  </tr>
                                 
                            </table>
                            </div>--%>
                <%-- end--%>
                      </div>
                </div>

               
             
                <div class="box-footer">

                         <a class="btn btn-primary btn-flat" href="../QuanLyTraHang/DanhMucNhapHang.aspx"><i class="glyphicon glyphicon-chevron-left"></i> Quay lại</a>

                    <asp:Button ID="btLuu" runat="server" Text="LƯU" class="btn btn-primary btn-flat" OnClick="btLuu_Click" />
                    <asp:Button ID="btHuy" runat="server" Text="HỦY" class="btn btn-primary btn-flat" OnClick="btHuy_Click" />
                </div>




            </form>
        </div>
    </div>
    </section>
    <!-- /.content -->
  </div>
   

      <!--Popup xem dụng cụ-->
    <div id="lightXemDungCu" class="white_content" style=" top: 10%; width: 70%; left: 15%; height: 80%;">
        <div class="box">
            <div id="dvDungCu" class="box-body">
                <div style="text-align:center; font-weight:bold; padding:10px">THÊM HÀNG HÓA</div>
                <div id="dvXemDungCu" style="padding:10px; text-align:center">
                    <div class="form-group">
                                    <div class="row">
                                        <div class="dvnull">&nbsp;</div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Mã hàng hóa:</b></div>
                                            <div class="txtinput">
                                                 <input class="form-control" data-val="true" data-val-required="" id="txtMaHangHoa" runat="server" name="Content.ContentName" type="text" value="" />
                                            </div>
                                        </div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Tên hàng hóa:</b></div>
                                            <div class="txtinput">
                                                <input class="form-control" data-val="true" data-val-required="" id="txtTenHangHoa" runat="server" name="Content.ContentName" type="text" value="" />
                                            </div>
                                        </div>
                                    </div>
                        </div>
                    <div class="form-group">
                                    <div class="row">
                                        <div class="dvnull">&nbsp;</div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Số lượng:</b></div>
                                            <div class="txtinput" style="padding-top:0px; text-align:left">
                                               <input class="form-control" data-val="true" data-val-required="" id="txtSoLuong" runat="server" name="Content.ContentName" type="text" value="" />
                                            </div>
                                        </div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Đơn giá trả:</b></div>
                                            <div class="txtinput" style="padding-top:0px; text-align:left">
                                               <input class="form-control" data-val="true" data-val-required="" id="txtDonGiaNhap" runat="server" name="Content.ContentName" type="text" value="" />
                                            </div>
                                        </div>
                                    </div>
                        </div>
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
                                            <div class="titleinput"><b>Chủng loại hàng hóa:</b></div>
                                           <div class="txtinput" style="padding-top:0px; text-align:left">
                                               
                                                 <input class="form-control" data-val="true" data-val-required="" disabled="disabled" id="txtChungLoai" runat="server" name="Content.ContentName" type="text" value="" />
                                              
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
                                            <div class="titleinput"><b>Màu sắc</b></div>
                                            <div class="txtinput" style="padding-top:0px; text-align:left">
                                                <input class="form-control" data-val="true" data-val-required="" disabled="disabled" id="txtMauSac" runat="server" name="Content.ContentName" type="text" value="" />
                                            </div>
                                        </div>
                                    </div>
                        </div>

                    <%-- start--%>
                     <div class="form-group">
                                    <div class="row">
                                        <div class="dvnull">&nbsp;</div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Đóng gói</b></div>
                                            <div class="txtinput" style="padding-top:0px; text-align:left">
                                                 <input class="form-control" data-val="true" data-val-required="" disabled="disabled" id="txtDongGoi" runat="server" name="Content.ContentName" type="text" value="" />
                                            </div>
                                        </div>

                                        <div class="coninput1">
                                              <div class="titleinput"><b>Tên khách hàng:</b></div>
                                                 <div class="txtinput">
                                                    <input class="form-control" data-val="true" data-val-required="" id="txtTenNhaCungCap" runat="server" name="Content.ContentName" type="text" value="" />
                                                </div>
                                         </div>
                                     
                                    </div>
                        </div>


                        <div style="text-align:center">
                            <input type="button" value="Thêm" class="btn btn-primary btn-flat" style="width: 80px;" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    <div id="fadeXemDungCu" onclick="DongXemDungCu()" class="black_overlay"></div>
    <!--End popup--->

     <script src="../plugins/datetimePicker1/build/jquery.datetimepicker.full.js"></script>
    <script type="text/javascript">
        $('#ContentPlaceHolder1_txtNgayNhap').datetimepicker({
            //dayOfWeekStart : 1,
            //todayBtn: "linked",
            language: "it",
            autoclose: true,
            todayHighlight: true,
            timepicker: false,
            dateFormat: 'dd/mm/yyyy',
            format: 'd/m/Y',
            formatDate: 'Y/m/d',
            value: 'today'
        });

    </script>
</asp:Content>

