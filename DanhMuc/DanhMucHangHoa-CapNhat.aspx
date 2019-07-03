<%@ Page Title="" Language="C#" MasterPageFile="~/Layout/MasterPage.master" AutoEventWireup="true" CodeFile="DanhMucHangHoa-CapNhat.aspx.cs" Inherits="DanhMuc_DanhMucHangHoa_CapNhat" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content-wrapper">
    <!-- Main content -->
    <div class="title" id="dvTitle" runat="server">THÊM THÔNG TIN CHI TIẾT HÀNG HÓA</div>
    <div class="title1"><a href="DanhMucHangHoa.aspx"><i class="fa fa-step-backward"></i> Danh sách chi tiết hàng hóa</a></div>
    <section class="content">
    <div class="box">
        <div class="box-body">
            <form class="form-horizontal" runat="server">
               <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Mã chi tiết hàng hóa(*):</b></div>
                          <div class="txtinput">
                              <input class="form-control" data-val="true" data-val-required="" id="txtMaHangHoa" runat="server" name="Content.ContentName" type="text" value="" />
                          </div>
                        </div>
                        <div class="coninput2">
                          <div class="titleinput"><b>Tên chi tiết hàng hóa(*):</b></div>
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
                          <div class="titleinput"><b>Size(*):</b></div>
                          <div class="txtinput">
                                <select class="form-control" data-val="true" data-val-required="" id="txtDVT" runat="server" name="Content.ContentName">

                                  </select>
                          </div>
                        </div>
                        <div class="coninput2">
                          <div class="titleinput"><b>Màu sắc(*):</b></div>
                          <div class="txtinput">
                            
                          <select class="form-control" data-val="true" data-val-required="" id="txtMauSac" runat="server" name="Content.ContentName">

                                  </select>
                          </div>
                        </div>
                      </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Thuộc hàng hóa(*):</b></div>
                          <div class="txtinput">
                                <select class="form-control" data-val="true" data-val-required="" id="txtLoaiHangHoa" runat="server" name="Content.ContentName">

                                  </select>
                          </div>
                        </div>
                       
                      </div>
                </div>
                 <div class="form-group" style="display:none;">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Chủng loại hàng hóa:</b></div>
                          <div class="txtinput">
                               <select class="form-control" data-val="true" data-val-required="" id="txtChungLoai" runat="server" name="Content.ContentName">

                                  </select>
                          </div>
                        </div>
                        <div class="coninput2">
                          <div class="titleinput"><b>Nhóm hàng:</b></div>
                          <div class="txtinput">
                               <select class="form-control" data-val="true" data-val-required="" id="txtNhomHang" runat="server" name="Content.ContentName">

                                  </select>
                         
                          </div>
                        </div>
                      </div>
                </div>

                 <div class="form-group" style="display:none;">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Đóng gói:</b></div>
                          <div class="txtinput">
                             
                              <input class="form-control" data-val="true" data-val-required="" id="txtDongGoi" runat="server" name="Content.ContentName" type="text" value="" />
                          </div>
                        </div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Mã vạch:</b></div>
                          <div class="txtinput">
                             
                              <input class="form-control" data-val="true" data-val-required="" id="txtMaVach" runat="server" name="Content.ContentName" type="text" value="" />
                          </div>
                        </div>
                      
                     </div>                    
                 </div>
                <div class="form-group" style="display:none;">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Barcode SP theo ĐVT:</b></div>
                          <div class="txtinput">
                             
                              <input class="form-control" data-val="true" data-val-required="" id="txtBarcodeSPTheoDVT" runat="server" name="Content.ContentName" type="text" value="" />
                          </div>
                        </div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Barcode Hộp/Lốc/Inner:</b></div>
                          <div class="txtinput">
                             
                              <input class="form-control" data-val="true" data-val-required="" id="txtBarcodeHopLocInner" runat="server" name="Content.ContentName" type="text" value="" />
                          </div>
                        </div>                      
                     </div>                   
                 </div>

                <div class="form-group" style="display:none;">
                    <div class="row">
                        <div class="dvnull">&nbsp;</div>
                        <div class="coninput1">
                          <div class="titleinput"><b>Thuộc mục:</b></div>
                          <div class="txtinput">
                             <select id="txtMuc" class="form-control" data-val="true" data-val-required="" runat="server" name="Content.ContentName">
                                 <option value="VĂN PHÒNG PHẨM">VĂN PHÒNG PHẨM</option>
                                 <option value="GIẤY VĂN PHÒNG">GIẤY VĂN PHÒNG</option>
                                 <option value="VẬT RẺ MAU HỎNG">VẬT RẺ MAU HỎNG</option>
                                 <option value=""></option>
                             </select>
                            
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
                <div class="box-footer">
                                         <a class="btn btn-primary btn-flat" href="../DanhMuc/DanhMucHangHoa.aspx"><i class="glyphicon glyphicon-chevron-left"></i> Quay lại</a>
                    <asp:Button ID="btLuu" runat="server" Text="LƯU" class="btn btn-primary btn-flat" OnClick="btLuu_Click" />
                    <asp:Button ID="btHuy" runat="server" Text="HỦY" class="btn btn-primary btn-flat" OnClick="btHuy_Click" />
                </div>
                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
            </form>
        </div>
    </div>
    </section>
    <!-- /.content -->
  </div>
</asp:Content>

