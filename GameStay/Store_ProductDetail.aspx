<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Store_ProductDetail.aspx.cs" Inherits="GameStay.Store_ProductDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Store_ProductDetail_StyleSheet.css?ver=12" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js">
    </script>
    <script>

        function onClickPlaceholder(link) {
            document.getElementById("img_screenshot").style.display = "none";
            document.getElementById("main_video").src = link;
            document.getElementById("main_video").style.display = "block";
        }

        function onClickScreenshot(_self) {
            var imagename = _self.src.toString();
            document.getElementById("main_video").style.display = "none";
            document.getElementById("img_screenshot").src = imagename.substring(imagename.indexOf("Images"));
            document.getElementById("img_screenshot").style.display = "block";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrap_total">
        <div class="wrap_total_images">
            <asp:Repeater runat="server" ID="detailTitleRepeater">
                <ItemTemplate>
                    <p class="p_title"><%# Eval("게임명") %></p>
                    <p class="p_title" id="text"></p>
                </ItemTemplate>
            </asp:Repeater>
            <div class="div_main_image">
                <iframe width="750" height="422" src="empty"
                        frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" 
                        allowfullscreen style="display: block" id="main_video" runat="server">
                </iframe>
                <img src="empty" width="750" height="422" style="display: none" id="img_screenshot"/>
            </div>
            
            <div class="div_wrap_small_images" id="div_wrap_small_images" runat="server">
                <div class="div_wrap_small_boxes" id="div_wrap_small_boxes" runat="server">
                    <asp:Repeater runat="server" ID="detailVideoRepeater" OnDataBinding="divSmallImages_Resize">
                       <ItemTemplate>
                       <div class="div_wrap_placeholder">
                           <img src='<%# Eval("미리보기이미지") %>' class="img_small_placeholder" 
                               onclick='<%# String.Format("onClickPlaceholder(\"{0}\");", Eval("영상링크").ToString()) %>'
                                id="img_placeholder"/>
                           <div class="div_wrap_playbutton">
                               <img src="Images/Img_Playbutton.png" class="img_playbutton"/>
                           </div>
                       </div>
                   </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater runat="server" ID="detailImageRepeater" OnDataBinding="SmallImage_OnBind">
                   <ItemTemplate>
                       <div class="div_wrap_screenshot" id="div_wrap_screenshot" runat="server">
                           <img src='<%# Eval("스크린샷") %>' class="img_screenshot" onclick="onClickScreenshot(this);"
                               id="img_small_screenshot"/>
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
