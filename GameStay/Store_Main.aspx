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

                document.getElementById("img_features_pagedot" + features_curIndex).src = 'Images/Icon/PageDot_Selected.png';
                switch (features_curIndex) {
                    case 0:
                        document.getElementById("img_features_pagedot1").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_features_pagedot2").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_features_pagedot3").src = 'Images/Icon/PageDot.png';
                        break;
                    case 1:
                        document.getElementById("img_features_pagedot0").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_features_pagedot2").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_features_pagedot3").src = 'Images/Icon/PageDot.png';
                        break;
                    case 2:
                        document.getElementById("img_features_pagedot0").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_features_pagedot1").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_features_pagedot3").src = 'Images/Icon/PageDot.png';
                        break;
                    case 3:
                        document.getElementById("img_features_pagedot0").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_features_pagedot1").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_features_pagedot2").src = 'Images/Icon/PageDot.png';
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

                document.getElementById("img_features_pagedot" + features_curIndex).src = 'Images/Icon/PageDot_Selected.png';
                switch (features_curIndex) {
                    case 0:
                        document.getElementById("img_features_pagedot1").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_features_pagedot2").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_features_pagedot3").src = 'Images/Icon/PageDot.png';
                        break;
                    case 1:
                        document.getElementById("img_features_pagedot0").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_features_pagedot2").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_features_pagedot3").src = 'Images/Icon/PageDot.png';
                        break;
                    case 2:
                        document.getElementById("img_features_pagedot0").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_features_pagedot1").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_features_pagedot3").src = 'Images/Icon/PageDot.png';
                        break;
                    case 3:
                        document.getElementById("img_features_pagedot0").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_features_pagedot1").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_features_pagedot2").src = 'Images/Icon/PageDot.png';
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
    
    <!-----------------------------------할인게임 부분 클릭메서드 및 페이징 --------------------------------------->
    <script>
        var discount_curIndex = 0;
        var count_total_discount = 0;

        $(document).ready(function () {
            $("#btn_discount_right").click(function () {
                if (discount_curIndex == 3) {
                    return;
                }
                ++discount_curIndex;
                $("#div_contents_list").animate({
                    left: discount_curIndex * -1100 + 'px'
                }, 300);


                document.getElementById("img_discount_pagedot" + discount_curIndex).src = 'Images/Icon/PageDot_Selected.png';
                switch (discount_curIndex) {
                    case 0:
                        document.getElementById("img_discount_pagedot1").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_discount_pagedot2").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_discount_pagedot3").src = 'Images/Icon/PageDot.png';
                        break;
                    case 1:
                        document.getElementById("img_discount_pagedot0").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_discount_pagedot2").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_discount_pagedot3").src = 'Images/Icon/PageDot.png';
                        break;
                    case 2:
                        document.getElementById("img_discount_pagedot0").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_discount_pagedot1").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_discount_pagedot3").src = 'Images/Icon/PageDot.png';
                        break;
                    case 3:
                        document.getElementById("img_discount_pagedot0").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_discount_pagedot1").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_discount_pagedot2").src = 'Images/Icon/PageDot.png';
                        break;
                }
            });

            $("#btn_discount_left").click(function () {
                if (discount_curIndex == 0) {
                    return;
                }
                --discount_curIndex;
                $("#div_contents_list").animate({
                    left: discount_curIndex * -1100 + 'px'
                }, 300);

                document.getElementById("img_discount_pagedot" + discount_curIndex).src = 'Images/Icon/PageDot_Selected.png';
                switch (discount_curIndex) {
                    case 0:
                        document.getElementById("img_discount_pagedot1").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_discount_pagedot2").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_discount_pagedot3").src = 'Images/Icon/PageDot.png';
                        break;
                    case 1:
                        document.getElementById("img_discount_pagedot0").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_discount_pagedot2").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_discount_pagedot3").src = 'Images/Icon/PageDot.png';
                        break;
                    case 2:
                        document.getElementById("img_discount_pagedot0").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_discount_pagedot1").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_discount_pagedot3").src = 'Images/Icon/PageDot.png';
                        break;
                    case 3:
                        document.getElementById("img_discount_pagedot0").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_discount_pagedot1").src = 'Images/Icon/PageDot.png';
                        document.getElementById("img_discount_pagedot2").src = 'Images/Icon/PageDot.png';
                        break;
                }
            });

            
        });
    </script>

    <script>
        function onClickDivDiscount1() {
            __doPostBack('div_discount_contentbox1');
        }

        function onClickDivDiscount2() {
            __doPostBack('div_discount_contentbox2');
        }

        function onClickDivDiscount3() {
            __doPostBack('div_discount_contentbox3');
        }

        function onClickDivDiscount4() {
            __doPostBack('div_discount_contentbox4');
        }

        function onMouseMore() {
            document.getElementById("div_wrap_p_discount_more").style.background = "#FFFFFF";
            document.getElementById("p_discount_more").style.color= "#000000";
        }

        function onMouseoutMore() {
            document.getElementById("div_wrap_p_discount_more").style.background = "transparent";
            document.getElementById("p_discount_more").style.color= "#FFFFFF";
        }
    </script>
    <!-------------------------------------------------------------------------------------------------------------->


    <!-----------------------------------인기게임파트 클릭메서드 및 페이징 --------------------------------------->
    <script>
        function onMouseBestMore() {
            document.getElementById("div_wrap_p_moregames").style.background = "#FFFFFF";
            document.getElementById("p_moregames").style.color = "#000000";
        }

        function onMouseoutBestMore() {
            document.getElementById("div_wrap_p_moregames").style.background = "transparent";
            document.getElementById("p_moregames").style.color = "#FFFFFF";
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrap_total">



        <!-----------------------------------특집 및 추천  --------------------------------------->
        <p class="p_features">특집 및 추천</p>
                <div class="div_wrap_features" id="div_wrap_features" runat="server"
                    onmouseover="onMouseDivFeature()" onmouseout="onMouseoutDivFeature()"
                    onclick="onClickDivFeature()">
                   <div class="div_features_pic">
                      <div class="div_wrap_image" id="div_wrap_image">
                          <asp:Repeater ID="featuresRepeater1" runat="server">
                              <ItemTemplate>
                                  <asp:HyperLink runat="server" NavigateUrl='<%# String.Concat("~/Store_ProductDetail.aspx?title=", Eval("영어게임명")) %>'>
                                      <img src='<%# Eval("메인이미지") %>'
                                           class="title_image" id="features_image" runat="server"/>
                                  </asp:HyperLink>
                              </ItemTemplate>
                          </asp:Repeater>
                      </div>
                   </div>
                  <div class="div_features_details">
                      <div class="div_wrap_details" id="div_wrap_details">
                           <asp:Repeater ID="featuresRepeater2" runat="server">
                               <ItemTemplate>
                                   <asp:HyperLink runat="server" NavigateUrl='<%# String.Concat("~/Store_ProductDetail.aspx?title=", Eval("영어게임명")) %>'>
                                       <div class="div_wrap_details2">
                                          <p class="p p_title" id="p_title" runat="server"><%# Eval("게임명") %></p>
                                          <p class="p p_release_date" id="p_release_date" runat="server"><%# DataBinder.Eval(Container.DataItem, "출시일", "{0:D}") %></p>
                                          <p class="p p_price" id="p_price" runat="server">&#8361;<%# Convert.ToInt32(Eval("게임가격"))
                                             - Convert.ToInt32(Eval("게임가격")) * Convert.ToDouble(Eval("할인율")) %>원</p>
                                       </div>
                                   </asp:HyperLink>
                               </ItemTemplate>
                           </asp:Repeater>
                      </div>
                  </div>
               </div>
        
        <div class="wrap_features_pagedot">
            <img class="img_pagedot" src="Images/Icon/PageDot_Selected.png" 
                 id="img_features_pagedot0"/>
            <img class="img_pagedot" src="Images/Icon/PageDot.png"
                 id="img_features_pagedot1"/>
            <img class="img_pagedot" src="Images/Icon/PageDot.png"
                 id="img_features_pagedot2"/>
            <img class="img_pagedot" src="Images/Icon/PageDot.png"
                 id="img_features_pagedot3"/>
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



        <!--------------------------------------할인게임파트----------------------------------------------->
        <div class="div_wrap_discount">
            <asp:Repeater runat="server" ID="countDiscountRepeater">
                <ItemTemplate>
                    <p class="p_discount" id="p_discount" runat="server">할인중 (<%# Eval("총 할인게임 개수") %>)</p>
                </ItemTemplate>
            </asp:Repeater>
            <div class="div_wrap_p_discount_more" id="div_wrap_p_discount_more"
                onmouseover="onMouseMore()" onmouseout="onMouseoutMore()">
                <p class="p_discount_more" id="p_discount_more">더보기</p>
            </div>
            <div class="div_wrap_contents">
                <div class="div_contents_list" id="div_contents_list">
                    <!----------------------1페이지 ----------------------->
                    <div class="div_wrap_discount_contentbox div_wrap_discount_contentbox1"
                         id="div_wrap_discount_contentbox1">
                        <asp:Repeater runat="server" ID="discountRepeater1">
                            <ItemTemplate>
                                <asp:HyperLink ID="discountLink1" 
                                     NavigateUrl='<%# String.Concat("~/Store_ProductDetail.aspx?title=", Eval("영어게임명")) %>'
                                               runat="server">
                                    <div class="div_discount_contentbox" id="div_discount_contentbox1"
                                         onmouseover="this.style.backgroundColor='#35373A'" onmouseout="this.style.backgroundColor='#1B1C1E'"
                                          runat="server">
                                        <div class="div_wrap_discount_image">
                                            <img src='<%# Eval("메인이미지") %>'
                                                 class="discount_image" id="discount_image" runat="server" />
                                        </div>
                                        <div class="div_discount_title">
                                           <p class="p p_discount_title" id="p_discount_title" runat="server"><%# Eval("게임명") %></p>
                                        </div>
                                   
                                        <div class="div_discount_price">
                                           <div class="div_wrap_discount_rate">
                                              <img src="Images/Icon/Icon_Discount.png" class="icon_discount"/>
                                              <p class="p p_discount_rate"><%# Convert.ToDouble(Eval("할인율")) * 100 %>%</p>
                                           </div>
                                           <div class="div_wrap_discount_price2">
                                              <p class="p p_discount_price"><strike>&#8361;<%# Eval("게임가격") %>원</strike></p><br />
                                              <p class="p p_discounted_price" id="p_price" runat="server">&#8361;<%# Convert.ToInt32(Eval("게임가격"))
                                                 - Convert.ToInt32(Eval("게임가격")) * Convert.ToDouble(Eval("할인율")) %>원</p>
                                           </div>
                                        </div>
                                    </div>
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <!----------------------2페이지 ----------------------->
                    <div class="div_wrap_discount_contentbox div_wrap_discount_contentbox2">
                        <asp:Repeater runat="server" ID="discountRepeater2">
                            <ItemTemplate>
                                <asp:HyperLink ID="discountLink1" 
                                               NavigateUrl='<%# String.Concat("~/Store_ProductDetail.aspx?title=", Eval("영어게임명")) %>'
                                               runat="server">
                                    <div class="div_discount_contentbox" id="div_discount_contentbox2"
                                         onmouseover="this.style.backgroundColor='#35373A'" onmouseout="this.style.backgroundColor='#1B1C1E'"
                                         runat="server">
                                       <div class="div_wrap_discount_image">
                                          <img src='<%# Eval("메인이미지") %>'
                                               class="discount_image" id="discount_image" runat="server" />
                                       </div>
                                       <div class="div_discount_title">
                                          <p class="p p_discount_title"><%# Eval("게임명") %></p>
                                       </div>
                                   
                                       <div class="div_discount_price">
                                          <div class="div_wrap_discount_rate">
                                             <img src="Images/Icon/Icon_Discount.png" class="icon_discount"/>
                                             <p class="p p_discount_rate"><%# Convert.ToDouble(Eval("할인율")) * 100 %>%</p>
                                          </div>
                                          <div class="div_wrap_discount_price2">
                                             <p class="p p_discount_price"><strike>&#8361;<%# Eval("게임가격") %>원</strike></p><br />
                                             <p class="p p_discounted_price" id="p_price" runat="server">&#8361;<%# Convert.ToInt32(Eval("게임가격"))
                                                - Convert.ToInt32(Eval("게임가격")) * Convert.ToDouble(Eval("할인율")) %>원</p>
                                          </div>
                                       </div>
                                   </div>
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <!----------------------3페이지 ----------------------->
                    <div class="div_wrap_discount_contentbox div_wrap_discount_contentbox3">
                        <asp:Repeater runat="server" ID="discountRepeater3">
                            <ItemTemplate>
                                <asp:HyperLink ID="discountLink1" 
                                               NavigateUrl='<%# String.Concat("~/Store_ProductDetail.aspx?title=", Eval("영어게임명")) %>'
                                               runat="server">
                                    <div class="div_discount_contentbox" id="div_discount_contentbox3"
                                         onmouseover="this.style.backgroundColor='#35373A'" onmouseout="this.style.backgroundColor='#1B1C1E'"
                                         runat="server">
                                       <div class="div_wrap_discount_image">
                                          <img src='<%# Eval("메인이미지") %>'
                                               class="discount_image" id="discount_image" runat="server" />
                                       </div>
                                       <div class="div_discount_title">
                                          <p class="p p_discount_title"><%# Eval("게임명") %></p>
                                       </div>
                                   
                                       <div class="div_discount_price">
                                          <div class="div_wrap_discount_rate">
                                             <img src="Images/Icon/Icon_Discount.png" class="icon_discount"/>
                                             <p class="p p_discount_rate"><%# Convert.ToDouble(Eval("할인율")) * 100 %>%</p>
                                          </div>
                                          <div class="div_wrap_discount_price2">
                                              <p class="p p_discount_price"><strike>&#8361;<%# Eval("게임가격") %>원</strike></p><br />
                                              <p class="p p_discounted_price" id="p_price" runat="server">&#8361;<%# Convert.ToInt32(Eval("게임가격"))
                                                 - Convert.ToInt32(Eval("게임가격")) * Convert.ToDouble(Eval("할인율")) %>원</p>
                                          </div>
                                      </div>
                                   </div>
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                    <!----------------------4페이지 ----------------------->
                    <div class="div_wrap_discount_contentbox div_wrap_discount_contentbox4">
                        <asp:Repeater runat="server" ID="discountRepeater4">
                            <ItemTemplate>
                                <asp:HyperLink ID="discountLink1" 
                                               NavigateUrl='<%# String.Concat("~/Store_ProductDetail.aspx?title=", Eval("영어게임명")) %>'
                                               runat="server">
                                    <div class="div_discount_contentbox" id="div_discount_contentbox4"
                                         onmouseover="this.style.backgroundColor='#35373A'" onmouseout="this.style.backgroundColor='#1B1C1E'"
                                         runat="server">
                                       <div class="div_wrap_discount_image">
                                          <img src='<%# Eval("메인이미지") %>'
                                               class="discount_image" id="discount_image" runat="server" />
                                       </div>
                                       <div class="div_discount_title">
                                          <p class="p p_discount_title"><%# Eval("게임명") %></p>
                                       </div>
                                   
                                       <div class="div_discount_price">
                                          <div class="div_wrap_discount_rate">
                                             <img src="Images/Icon/Icon_Discount.png" class="icon_discount"/>
                                             <p class="p p_discount_rate"><%# Convert.ToDouble(Eval("할인율")) * 100 %>%</p>
                                          </div>
                                          <div class="div_wrap_discount_price2">
                                             <p class="p p_discount_price"><strike>&#8361;<%# Eval("게임가격") %>원</strike></p><br />
                                             <p class="p p_discounted_price" id="p_price" runat="server">&#8361;<%# Convert.ToInt32(Eval("게임가격"))
                                                - Convert.ToInt32(Eval("게임가격")) * Convert.ToDouble(Eval("할인율")) %>원</p>
                                          </div>
                                       </div>
                                   </div>
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
        <div class="wrap_discount_pagedot">
               <img class="img_pagedot" src="Images/Icon/PageDot_Selected.png"
                   id="img_discount_pagedot0"/>
               <img class="img_pagedot" src="Images/Icon/PageDot.png"
                   id="img_discount_pagedot1"/>
               <img class="img_pagedot" src="Images/Icon/PageDot.png"
                   id="img_discount_pagedot2"/>
               <img class="img_pagedot" src="Images/Icon/PageDot.png"
                   id="img_discount_pagedot3"/>
            </div>
            <div class="div_wrap_discount_button">
                <button type="button" class="button_discount_left">
                   <img class="btnimg_features_left" id="btn_discount_left" 
                        src="Images/Button/Arrow_Left.png" 
                        onmouseover="this.src='Images/Button/Arrow_Left_Hover.png'"
                        onmouseout="this.src='Images/Button/Arrow_Left.png'"/>
                </button>
                <button type="button" class="button_discount_right">
                   <img class="btnimg_features_left" id="btn_discount_right" 
                        src="Images/Button/Arrow_Right.png" 
                        onmouseover="this.src='Images/Button/Arrow_Right_Hover.png'"
                        onmouseout="this.src='Images/Button/Arrow_Right.png'"/>
                </button>
           </div>

    <!------------------------------------------------------------------------------------------->

    <!---------------------------------최고 인기 게임 리스트------------------------------------->
        
           <asp:ScriptManager ID="ScriptManager" runat="server" EnablePartialRendering="true" />
           <asp:UpdatePanel ID="UpdatePanel" runat="server">
               <ContentTemplate>
                   <div class="div_wrap_p_bestgames" id="div_wrap_p_bestgames" runat="server">
                      <asp:Button ID="btn_bestgames" runat="server" Text="최고인기" CssClass="btn_bestgames"
                                  OnClick="BestGames_OnClick"/>
                   </div>
                   <div class="div_wrap_p_newgames" id="div_wrap_p_newgames" runat="server">
                      <asp:Button ID="btn_newgames" runat="server" Text="신규출시" CssClass="btn_newgames"
                                  OnClick="NewGames_OnClick"/>
                   </div>
                   <div class="div_wrap_p_moregames" onmouseover="onMouseBestMore()" onmouseout="onMouseoutBestMore()"
                        id="div_wrap_p_moregames">
                       <p class="p_moregames" id="p_moregames">더보기</p>
                   </div>
                   <div class="div_wrap_list">
                      <asp:Repeater ID="bestgamesRepeater" runat="server">
                         <ItemTemplate>
                            <asp:HyperLink NavigateUrl='<%# String.Concat("~/Store_ProductDetail.aspx?title=", Eval("영어게임명")) %>'
                                runat="server">
                                  <div class="div_wrap_best_contentbox" onmouseover="this.style.background='#35373A'"
                                       onmouseout="this.style.background='#1B1C1E'" id="div_wrap_best_contentbox">
                                       <div class="div_wrap_best_image">
                                          <img src='<%# Eval("와이드이미지") %>' class="best_image"/>
                                       </div>
                                       <div class="div_wrap_p_best_title">
                                          <p class="p_best_title"><%# Eval("게임명") %></p>
                                          <p class="p_best_tags">온라인 멀티플레이어, 귀여운, 유머</p>       
                                       </div>
                                       <div class="div_wrap_p_best_price">
                                          <p class="p_best_price">&#8361;<%# Eval("게임가격") %>원</p>
                                       </div>
                                       <div class="div_wrap_rating">
                                          <div class="div_ratingbox">
                                            <p class="p_rating"><%# Eval("평점") %></p>
                                          </div>
                                       </div>
                                 </div>
                            </asp:HyperLink>
                        </ItemTemplate>
                     </asp:Repeater>
                  </div>
             </ContentTemplate>
             <Triggers>
                 <asp:AsyncPostBackTrigger ControlID="btn_newgames" />
                 <asp:AsyncPostBackTrigger ControlID="btn_bestgames" />
             </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
