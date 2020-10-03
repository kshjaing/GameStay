<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Store_Main.aspx.cs" Inherits="GameStay.Store_Main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/StoreMain_StyleSheet.css?ver=11" rel="stylesheet" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js">
    </script>



    <!-----------------------------------특집 및 추천 부분 클릭메서드 및 페이징 --------------------------------------->
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

                document.getElementById("img_pagedot" + features_curIndex).src = 'Images/Icon/PageDot_Selected.png';
                switch (features_curIndex) {
                    case 0:
                        document.getElementById("img_pagedot1").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_pagedot2").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_pagedot3").src = 'Images/Icon/PageDot.png';
                        break;
                    case 1:
                        document.getElementById("img_pagedot0").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_pagedot2").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_pagedot3").src = 'Images/Icon/PageDot.png';
                        break;
                    case 2:
                        document.getElementById("img_pagedot0").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_pagedot1").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_pagedot3").src = 'Images/Icon/PageDot.png';
                        break;
                    case 3:
                        document.getElementById("img_pagedot0").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_pagedot1").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_pagedot2").src = 'Images/Icon/PageDot.png';
                        break;
                }
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

                document.getElementById("img_pagedot" + features_curIndex).src = 'Images/Icon/PageDot_Selected.png';
                switch (features_curIndex) {
                    case 0:
                        document.getElementById("img_pagedot1").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_pagedot2").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_pagedot3").src = 'Images/Icon/PageDot.png';
                        break;
                    case 1:
                        document.getElementById("img_pagedot0").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_pagedot2").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_pagedot3").src = 'Images/Icon/PageDot.png';
                        break;
                    case 2:
                        document.getElementById("img_pagedot0").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_pagedot1").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_pagedot3").src = 'Images/Icon/PageDot.png';
                        break;
                    case 3:
                        document.getElementById("img_pagedot0").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_pagedot1").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_pagedot2").src = 'Images/Icon/PageDot.png';
                        break;
                }
            });
        });
    </script>

    <script>
        function onClickDivFeature() {
            __doPostBack('div_wrap_features');
        }

        function onMouseDivFeature() {
            document.getElementById("div_wrap_details").style.background = "#35373A"
        }

        function onMouseoutDivFeature() {
            document.getElementById("div_wrap_details").style.background = "#1B1C1E"
        }
    </script>
    <!-------------------------------------------------------------------------------------------------------------->
    

    


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrap_total">



        <!-----------------------------------특집 및 추천  --------------------------------------->
        <p class="p_features">특집 및 추천</p>
                <div class="div_wrap_features" id="div_wrap_features" runat="server"
                    onmouseover="onMouseDivFeature()" onmouseout="onMouseoutDivFeature();"
                    onclick="onClickDivFeature()">
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
                                       <p class="p p_release_date" id="p_release_date" runat="server"><%# Eval("출시일") %></p>
                                       <p class="p p_price" id="p_price" runat="server">&#8361;<%# Eval("게임가격") %>원</p>
                                   </div>
                               </ItemTemplate>
                           </asp:Repeater>
                      </div>
                  </div>
               </div>
        
        <div class="wrap_features_pagedot">
            <img class="img_pagedot" src="Images/Icon/PageDot_Selected.png" 
                 id="img_pagedot0"/>
            <img class="img_pagedot" src="Images/Icon/PageDot.png"
                 id="img_pagedot1"/>
            <img class="img_pagedot" src="Images/Icon/PageDot.png"
                 id="img_pagedot2"/>
            <img class="img_pagedot" src="Images/Icon/PageDot.png"
                 id="img_pagedot3"/>
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
        <!------------------------------------------------------------------------------------------->



        <!--------------------------------------할인중----------------------------------------------->
        <div class="div_wrap_discount">
            <p class="p_discount">할인중</p>
        </div>
        

    </div>

</asp:Content>
