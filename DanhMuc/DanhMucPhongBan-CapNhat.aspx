<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="DanhMucPhongBan-CapNhat.aspx.cs" Inherits="DanhMuc_DanhMucPhongBan_CapNhat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script src="../dist/jquery-ui-1.11.3/jquery-ui.js"></script>
    <link href="../dist/jquery-ui-1.11.3/jquery-ui.css" rel="stylesheet"/>
    <script>
        window.onload = function () {
            TenKhachAutocomplete();
                     
        }
        function TenKhachAutocomplete() {
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
    <div class="content-wrapper">
    <!-- Main content -->
    <div class="title" id="dvTitle" runat="server">THÊM THÔNG TIN PHÒNG BAN</div>
    <div class="title1"><a href="DanhMucPhongBan.aspx"><i class="fa fa-step-backward"></i> Danh sách phòng ban</a></div>
    <section class="content">
    <div class="box">
        <div class="box-body">
            <form class="form-horizontal" runat="server">
               <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Mã phòng ban(*):</b></div>
                          <div class="txtinput">
                              <input class="form-control" data-val="true" data-val-required="" id="txtMaPhongBan" runat="server" name="Content.ContentName" type="text" value="" />
                          </div>
                        </div>
                        <div class="coninput2">
                          <div class="titleinput"><b>Tên phòng ban(*):</b></div>
                          <div class="txtinput">
                              <input class="form-control" data-val="true" data-val-required="" id="txtTenPhongBan" runat="server" name="Content.ContentName" type="text" value="" />
                          </div>
                        </div>
                      </div>
                </div>
                
                <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Số điện thoại:</b></div>
                          <div class="txtinput">
                              <input class="form-control" data-val="true" data-val-required="" id="txtSoDienThoaiPhongBan" runat="server" name="Content.ContentName" type="text" value="" />
                          </div>
                        </div>
                        <div class="coninput2">
                          <div class="titleinput"><b>Địa chỉ:</b></div>
                          <div class="txtinput">
                              <input class="form-control" data-val="true" data-val-required="" id="txtDiaChiPhongBan" runat="server" name="Content.ContentName" type="text" value="" />
                          </div>
                        </div>
                      </div>
                </div>

                <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                       <div class="coninput1">
                              <div class="titleinput"><b>Thuộc Về Khách Hàng:</b></div>
                              <div class="txtinput">
                                  <input class="form-control" placeholder="--Chọn--" data-val="true" data-val-required="" id="txtTenKhachHang" runat="server" name="Content.ContentName" type="text" value="" />
                                   <input class="form-control" data-val="true" data-val-required="" id="txtIDKhachHang" runat="server" name="Content.ContentName" type="hidden" value="" />
                              </div>
                            </div>
                         <div class="coninput2">
                              <div class="titleinput"><b>Người liên lạc:</b></div>
                              <div class="txtinput">
                                  <input class="form-control"  data-val="true" data-val-required="" id="txtNguoiLienLac" runat="server" name="Content.ContentName" type="text" value="" />
                                   
                              </div>
                            
                       </div>
                       </div>
                        
                        
                </div>
              
                    <%--   <div class="form-group">
                    <label class="col-md-2 control-label" for="Content_ContentName">Ghi chú:</label>
                    <div class="col-md-10">
                        <textarea class="form-control" id="txtGhiChu" runat="server" name="Content.ContentName"></textarea>
                    </div>
                </div>--%>
                <%--<div class="form-group">
                    <label class="col-md-2 control-label" for="Content_ContentName">Nơi ở:</label>
                    <div class="col-md-10">
                        <input class="form-control" data-val="true" data-val-required="" id="Text13" runat="server" name="Content.ContentName" type="text" value="" />
                    </div>
                </div>--%>
              <%--   <div class="form-group">
                    <label class="col-md-2 control-label" for="Content_ContentName" >Giấy phép lái xe:</label>
                    <div class="col-md-10">
                        <div>
                            <input type="button" onclick="MoXemGiayPhepLaiXe()" value="Thêm giấy phép lái xe" class="btn btn-primary btn-flat" style="width: 180px;" />
                        </div>
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
                                    <th class="th">
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
                                    <td>
                                        <a href="#"><img class="imgedit" src="../images/edit.png" />Sửa</a>|
                                        <a href="#"><img class="imgedit" src="../images/delete.png" />Xóa</a>
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
                                        <td>
                                            <a href="#"><img class="imgedit" src="../images/edit.png" />Sửa</a>|
                                            <a href="#"><img class="imgedit" src="../images/delete.png" />Xóa</a>
                                        </td>
                                    </tr>
                            </table>
                    </div>
                </div>--%>
                <div class="box-footer">
                    <asp:Button ID="btLuu" runat="server" Text="LƯU" class="btn btn-primary btn-flat" OnClick="btLuu_Click" />
                    <asp:Button ID="btHuy" runat="server" Text="HỦY" class="btn btn-primary btn-flat" OnClick="btHuy_Click" />
                </div>
            </form>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    </div>
    </section>
    <!-- /.content -->
  </div>
    <!--Popup xem giấy phép lái xe-->
    <div id="lightXemGiayPhepLaiXe" class="white_content" style=" top: 10%; width: 70%; left: 15%; height: 80%;">
        <div class="box">
            <div id="dvGiayPhepLaiXe" class="box-body">
                <div style="text-align:center; font-weight:bold; padding:10px">CẬP NHẬT GIẤY PHÉP LÁI XE</div>
                <div id="dvXemSanPham" style="padding:10px; text-align:center">
                    <div class="form-group">
                                    <div class="row">
                                        <div class="dvnull">&nbsp;</div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Số giấy phép lái xe:</b></div>
                                            <div class="txtinput">
                                                <input class="form-control" data-val="true" data-val-required="" name="Content.ContentName" type="text" value="" />
                                            </div>
                                        </div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Hạng xe:</b></div>
                                            <div class="txtinput">
                                                <select class="form-control">
                                                    <option>-- Chọn --</option>
                                                    <option>A1</option>
                                                    <option>A2</option>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                        </div>
                    <div class="form-group">
                                    <div class="row">
                                        <div class="dvnull">&nbsp;</div>
                                        <div class="coninput1">
                                            <div class="titleinput"><b>Ngày hết hạn:</b></div>
                                            <div class="txtinput">
                                                <input class="form-control" data-val="true" data-val-required="" name="Content.ContentName" type="text" value="" />
                                            </div>
                                        </div>
                                        <%--<div class="coninput1">
                                            <div class="titleinput"><b>Hạng xe:</b></div>
                                            <div class="txtinput">
                                                <select class="form-control">
                                                    <option>-- Chọn --</option>
                                                    <option>A1</option>
                                                    <option>A2</option>
                                                </select>
                                            </div>
                                        </div>--%>
                                    </div>
                        </div>
                        <div style="text-align:center">
                            <input type="button" value="Thêm" class="btn btn-primary btn-flat" style="width: 80px;" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    <div id="fadeXemGiayPhepLaiXe" onclick="DongXemGiayPhepLaiXe()" class="black_overlay"></div>
    <!--End popup--->
</asp:Content>

