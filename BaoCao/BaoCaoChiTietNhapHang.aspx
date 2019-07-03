<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="BaoCaoChiTietNhapHang.aspx.cs" Inherits="BaoCao_BienBanGiaoHangMot" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
          <script src="../dist/jquery-ui-1.11.3/jquery-ui.js"></script>
    <link href="../dist/jquery-ui-1.11.3/jquery-ui.css" rel="stylesheet"/>

    <script>
        window.onload = function () {
            TenSanPhamAutocomplete();
            MaSanPhamAutocomplete();

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
                            alert("Lỗi !")
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
                        $("#ContentPlaceHolder1_txtMaPhieu").autocomplete({

                            minLength: 0,
                            source: listKhachHangAutocomplete,
                            focus: function (event, ui) {
                                $("#ContentPlaceHolder1_txtMaPhieu").val(ui.item.label);
                                return false;
                            },
                            select: function (event, ui) {
                                $("#ContentPlaceHolder1_txtMaPhieu").val(ui.item.value);
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
            xmlhttp.open("GET", "../Ajax.aspx?Action=loadmaphieunhap", true);
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
    <div class="title">BÁO CÁO CHI TIẾT NHẬP HÀNG</div>
    <div class="box">
        <div class="box-body">
           
                <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Mã Phiếu Nhập:</b></div>
                          <div class="txtinput">
                                <input class="form-control" placeholder="--Chọn--" data-val="true" data-val-required="" id="txtMaPhieu" runat="server" name="Content.ContentName" type="text" value=""  />
                          </div>
                        </div>
                       <div class="coninput1">
                          <div class="titleinput"><b>Tên sản phẩm:</b></div>
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
                          <div class="titleinput"><b>Từ ngày nhập:</b></div>
                          <div class="txtinput">
                                <input class="form-control" placeholder="--Chọn--" data-val="true" data-val-required="" id="txtTuNgayNhap" runat="server" name="Content.ContentName" type="text" value=""  />
                          </div>
                        </div>
                       <div class="coninput1">
                          <div class="titleinput"><b>Đến ngày nhập:</b></div>
                          <div class="txtinput">
                                <input class="form-control" placeholder="--Chọn--" data-val="true" data-val-required="" id="txtDenNgayNhap" runat="server" name="Content.ContentName" type="text" value=""  />
                          </div>
                        </div>
                      </div>
                </div>
              
            <div class="row">
            <div class="col-sm-9">
                    <%--  <asp:Button ID="btTatCa" class="btn btn-primary btn-flat" runat="server" Text="Xuất báo cáo" OnClick="btTatCa_Click" />--%>
                 <%--    <a class="btn btn-primary btn-flat" href="DanhMucHangHoa-CapNhat.aspx"><i class="glyphicon glyphicon-plus"></i>&nbsp;&nbsp;&nbsp; Thêm mới</a>--%>
                  </div>
                <div class="col-sm-3">
                        <div style="text-align:right;">
                            <asp:Button ID="btTimKiem" class="btn btn-primary btn-flat" runat="server" Text="Xem" OnClick="btTimKiem_Click" />
                            
                            <asp:Button ID="TC" runat="server" Text="Tất cả" class="btn btn-primary btn-flat" OnClick="TC_Click" />
                        </div>
                    </div>
            </div>
           
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            <div id="dvNguoiDung" runat="server">
                <table class='table table-bordered table-striped'>
                    <tr>
                        <th style='background-color:white;' rowspan='3'>
                            <img src="../dist/img/UNI.png" height='100' width='70' />
                        </th>
                        <th style='background-color:white;' colspan='2'>
                         CÔNG TY CỔ PHẦN ViỄN LIÊN			

                        </th>
                      
                        <th style='background-color:white;'>&nbsp;
                         
                        </th>
                        <th style='background-color:white;'>&nbsp;
                         
                        </th>
                       
                        
                          <th style='background-color:white;'>		&nbsp;
                        </th>

                          <th style='background-color:white;'>&nbsp;
                        </th>
                           <th style='background-color:white;'>		&nbsp;
                        </th>

                          <th style='background-color:white;'>&nbsp;
                        </th>
                    </tr>
                     <tr>
                       
                        <td style='background-color:white;font-style:normal' colspan='4'>
                         Số 32 Đường số 8 nhà ở Khu Z756, Phường 12, Q.10, Tp.Hồ Chí Minh		

                        </td>
                      
                       
                        <td style='background-color:white;'>&nbsp;
                        </td>

                          <td style='background-color:white;'>&nbsp;
                        </td>
                           <td style='background-color:white;'>		&nbsp;
                        </td>

                          <td style='background-color:white;'>&nbsp;
                        </td>
                    </tr>
                     <tr>
                       
                        <td style='background-color:white;' colspan='2'>
                        <b><i><u>Tel</u></i></b> : 028 3620 8997  -  <b><i><u>Fax</u></i></b> : 028 3620 8997

                        </td>
                      
                        <td style='background-color:white;'>&nbsp;
                         
                        </td>
                        <td style='background-color:white;'>&nbsp;
                         
                        </td>
                       
                        
                          <td style='background-color:white;'>	&nbsp;	
                        </td>

                          <td style='background-color:white;'>&nbsp;
                        </td>
                           <td style='background-color:white;'>		&nbsp;
                        </td>

                          <td style='background-color:white;'>&nbsp;
                        </td>
                    </tr>
                    <tr>
                    
                      <td style='background-color:white;'>&nbsp;	</td>		
                           <td style='background-color:white;'>	&nbsp;	</td>	
                                <td style='background-color:white;'>&nbsp;	</td>		
                                     <td style='background-color:white;'>&nbsp;	</td>		
                                          <td style='background-color:white;'>&nbsp;	</td>		
                                               <td style='background-color:white;'>	&nbsp;</td>		
                                                    <td style='background-color:white;'>	&nbsp;</td>		
                                                         <td style='background-color:white;'>	&nbsp;</td>	
                         <td style='background-color:white;'>	&nbsp;</td>		
                    </tr>
                      <tr>
                        <td colspan='4' style='background-color:white;font-size:25px;text-align:left;'><b> BẢNG KÊ CHI TIẾT NHẬP-XUẤT-TỒN</b></td>
                       <td style='background-color:white;'>&nbsp;	</td>	
                         <td style='background-color:white;'>&nbsp;	</td>		
                          <td style='background-color:white;'>&nbsp;	</td>		
                           <td style='background-color:white;'>&nbsp;	</td>		
                           <td style='background-color:white;'>	&nbsp;</td>	
                    </tr>
                     <tr  style="height:30px;">
                     <td style='background-color:white;' >&nbsp;	</td>	
                      <td style='background-color:white;'>&nbsp;	</td>		
                           <td style='background-color:white;'>	&nbsp;	</td>	
                                <td style='background-color:white;'>&nbsp;	</td>		
                                     <td style='background-color:white;'>&nbsp;	</td>		
                                          <td style='background-color:white;'>	&nbsp;</td>		
                                               <td style='background-color:white;'>&nbsp;	</td>		
                                                    <td style='background-color:white;'>	&nbsp;</td>		
                                                         <td style='background-color:white;'>	&nbsp;</td>		
                    </tr>
                     <tr>
                     <td style='background-color:white;text-align:center;' rowspan='2'><b>Ngày</b>	</td>	
                      <td style='background-color:white;text-align:center;' rowspan='2'><b>Mã hàng<br/> xuất</b>	</td>		
                          <td style='background-color:white;text-align:center;' rowspan='2'><b>Tên hàng xuất</b>	</td>	
                        <td style='background-color:white;text-align:center;' rowspan='2'><b>KIỂM KÊ<br/>ĐẦU KỲ</b>	</td>	
                       <td style='background-color:white;text-align:center;' colspan='3'><b>NHẬP XUẤT TRONG KỲ</b>	</td>	
                      <td style='background-color:white;text-align:center;' rowspan='2'><b>Thành<br/> tiền</b>	</td>
                       <td style='background-color:white;text-align:center;'><b>Ghi chú</b></td>		
                    </tr>

                     <tr>        
                                           <td style='background-color:white;text-align:center;'><b>NHẬP</b></td>			
                                               <td style='background-color:white;text-align:center;'><b>XUẤT</b></td>			
                                                    <td style='background-color:white;text-align:center;'><b>TỒN</b></td>		
                                                         <td style='background-color:white;'>	</td>		
                    </tr>
                </table>
            </div>
        </div>
    </div>

</section>


    <!-- /.content -->
  </div>
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

