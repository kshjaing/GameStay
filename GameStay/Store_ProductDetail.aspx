<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Store_ProductDetail.aspx.cs" Inherits="GameStay.Store_ProductDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Store_ProductDetail_StyleSheet.css?ver=6" rel="stylesheet" />
    <script>
        function onClickPlaceholder(_self) {
            _sefl.style.border = "3px solid #FFFFFF";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrap_total">
        <div class="wrap_total_images">
            <asp:Repeater runat="server" ID="detailTitleRepeater">
                <ItemTemplate>
                    <p class="p_title"><%# Eval("게임명") %></p>
                </ItemTemplate>
            </asp:Repeater>
            <div class="div_main_image">
                <asp:Repeater runat="server" ID="detailVideoRepeater1">
                    <ItemTemplate>
                        <iframe width="750" height="422" src='<%# Eval("영상링크") %>'
                                frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" 
                                allowfullscreen style="display: normal" id="main_video">
                        </iframe>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater runat="server" ID="detailImageRepeater1">
                    <ItemTemplate>
                        <img src='<%# Eval("스크린샷") %>' width="750" height="422"
                             style="display: none" id="img_screenshot"/>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            
            <div class="div_wrap_small_images" id="div_wrap_small_images" runat="server">
                <div class="div_wrap_small_boxes" id="div_wrap_small_boxes" runat="server">
                    <asp:Repeater runat="server" ID="detailVideoRepeater2" OnDataBinding="divSmallImages_Resize">
                       <ItemTemplate>
                       <div class="div_wrap_placeholder" onclick="this.style.border='2px solid #FFFFFF'">
                           <img src='<%# Eval("미리보기이미지") %>' class="img_small_placeholder" onclick="onClickPlaceholder(this);"
                                id="img_placeholder"/>
                           <div class="div_wrap_playbutton">
                               <img src="Images/Img_Playbutton.png" class="img_playbutton"/>
                           </div>
                       </div>
                   </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater runat="server" ID="detailImageRepeater2" OnDataBinding="SmallImage_OnBind">
                   <ItemTemplate>
                       <div class="div_wrap_screenshot" onclick="this.style.border='2px solid #FFFFFF'"
                            id="div_wrap_screenshot" runat="server">
                           <img src='<%# Eval("스크린샷") %>' class="img_screenshot" onclick="onClickScreenshot(this);"
                               id="img_small_screenshot" runat="server" alt="0"/>
                       </div>
                   </ItemTemplate>
                </asp:Repeater>
                </div>
                
            </div>
            
            
            
        </div>
        <div class="wrap_total_infobox">
            <div class="div_infobox_image">
                
            </div>
        </div>
    </div>
</asp:Content>
