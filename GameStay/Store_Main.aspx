<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Store_Main.aspx.cs" Inherits="GameStay.Store_Main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/StoreMain_StyleSheet.css?ver=11" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js">
    </script>
    <script>
        var features_curIndex = 0;

        $(document).ready(function () {
            $("#btn_features_right").click(function () {
                if (features_curIndex == 3) {
                    return;
                }
                ++features_curIndex;
                $("#div_wrap_image").animate({
                    left: features_curIndex * -715  + 'px'
                }, 300);
                $("#div_wrap_details").animate({
                    left: features_curIndex * -385 + 'px'
                }, 400);
            });
            $("#btn_features_left").click(function () {
                if (features_curIndex == 0) {
                    return;
                }
                --features_curIndex;
                $("#div_wrap_image").animate({
                    left: features_curIndex * -715 + 'px'
                }, 300);
                $("#div_wrap_details").animate({
                    left: features_curIndex * -385 + 'px'
                }, 400);
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrap_total">
        <p class="p_features">특집 및 추천</p>
                <div class="div_wrap_features">
                   <div class="div_features_pic">
                      <div class="div_wrap_image" id="div_wrap_image">
                          <asp:Repeater ID="featuresRepeater1" runat="server">
                              <ItemTemplate>
                                  <img src='<%# Eval("메인이미지") %>'
                                       class="title_image" id="features_image" runat="server"/>
                              </ItemTemplate>
                          </asp:Repeater>
                          
                      </div>
                   </div>
                  <div class="div_features_details">
                      <div class="div_wrap_details" id="div_wrap_details">
                           <asp:Repeater ID="featuresRepeater2" runat="server">
                               <ItemTemplate>
                                   <div class="div_wrap_details2">
                                       <p class="p p_title" id="p_title" runat="server"><%# Eval("게임명") %></p>
                                       <p class="p p_release_date" id="p_release_date" runat="server"><%# Eval("출시일","{0:yyyy/MM/dd}") %></p>
                                       <p class="p p_price" id="p_price" runat="server"><%# Eval("게임가격") %>원</p>
                                   </div>
                               </ItemTemplate>
                           </asp:Repeater>
                      </div>
                  </div>
               </div>
        
        <div class="wrap_features_pagedot">
            <button type="button" class="button_page button_page0" id="button_page0">
                <img class="img_pagedot" src="Images/Icon/PageDot_Selected.png" />
            </button>
            <button type="button" class="button_page button_page1" id="button_page1">
                <img class="img_pagedot" src="Images/Icon/PageDot.png" />
            </button>
            <button type="button" class="button_page button_page2" id="button_page2">
                <img class="img_pagedot" src="Images/Icon/PageDot.png" />
            </button>
            <button type="button" class="button_page button_page3" id="button_page3">
                <img class="img_pagedot" src="Images/Icon/PageDot.png" />
            </button>
        </div>
        <div class="div_wrap_features_button">
            <button type="button" class="button_features_right">
            <img class="btnimg_features_right" id="btn_features_right"
                src="Images/Button/Arrow_Right.png" 
                onmouseover="this.src='Images/Button/Arrow_Right_Hover.png'"
                onmouseout="this.src='Images/Button/Arrow_Right.png'"/>
            </button>
            <button type="button" class="button_features_left">
            <img class="btnimg_features_left" id="btn_features_left" 
                src="Images/Button/Arrow_Left.png" 
                onmouseover="this.src='Images/Button/Arrow_Left_Hover.png'"
                onmouseout="this.src='Images/Button/Arrow_Left.png'"/>
            </button>
        </div>
    </div>

</asp:Content>
