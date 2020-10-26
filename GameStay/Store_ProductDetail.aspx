<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Store_ProductDetail.aspx.cs" Inherits="GameStay.Store_ProductDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Store_ProductDetail_StyleSheet.css?ver=10" rel="stylesheet" />
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
            <asp:Repeater runat="server" ID="detailTitleRepeater1">
                <ItemTemplate>
                    <p class="p_title"><%# Eval("게임명") %></p>

                    <!--메인이미지 파트-->
                    <div class="div_main_image">
                       <iframe width="750" height="422" src='<%# Eval("대표영상링크") %>'
                               frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" 
                               allowfullscreen style="display: block" id="main_video">
                       </iframe>
                       <img src="empty" width="750" height="422" style="display: none" id="img_screenshot"/>
                    </div>
                </ItemTemplate>
            </asp:Repeater>


            
            

            <!--작은 크기의 미리보기 이미지 파트-->
            <div class="div_wrap_small_images" id="div_wrap_small_images" runat="server">
                <div class="div_wrap_small_boxes" id="div_wrap_small_boxes" runat="server">
                    <asp:Repeater runat="server" ID="detailVideoRepeater" OnDataBinding="divSmallImages_Resize">
                       <ItemTemplate>
                       <div class="div_wrap_placeholder">
                           <img src='<%# Eval("미리보기이미지") %>' class="img_small_placeholder" 
                               onclick='<%# String.Format("onClickPlaceholder(\"{0}\");", Eval("영상링크").ToString()) %>'
                                id="img_placeholder"/>
                           <div class="div_wrap_playbutton">
                               <img src="Images/Img_Playbutton.png" class="img_playbutton"
                                   onclick='<%# String.Format("onClickPlaceholder(\"{0}\");", Eval("영상링크").ToString()) %>'/>
                           </div>
                       </div>
                   </ItemTemplate>
                </asp:Repeater>
                <asp:Repeater runat="server" ID="detailImageRepeater">
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


        




        <!--게임정보파트-->
        <asp:Repeater ID="detailTitleRepeater2" runat="server">
            <ItemTemplate>
                <!--검색기능(추후추가예정)-->
                <div class="div_wrap_searchbutton"></div>



                <div class="wrap_total_infobox">
                   <div class="div_infobox_image">
                      <img src='<%# Eval("이미지4대3") %>' class="img_title"/>
                   </div>
                   <div class="div_info div_rating">
                       <p class="p_info1 p_info_rating">유저평점</p>
                       <p class="p_info2"><%# Eval("평점") %></p>
                   </div>
                   <div class="div_info div_releasedate">
                       <p class="p_info1">출시일</p>
                       <p class="p_info2"><%# DataBinder.Eval(Container.DataItem, "출시일", "{0:D}") %></p>
                   </div>
                   <div class="div_info div_developer">
                       <p class="p_info1">개발사</p>
                       <p class="p_info2"><%# Eval("개발사") %></p>
                   </div>
               </div>
               <div class="div_empty"></div>

               <!--게임소개 및 구매파트-->
               <p class="p_purchase">게임 구매</p>
               <div class="div_wrap_total_purchase">
                   <div class="div_wrap_purchase_text">
                       <p class="p_purchase_title"><%# Eval("게임명") %></p>
                       <p class="p_purchase_introduce_text"><%# Eval("게임소개") %></p>
                   </div>
                   <div class="div_wrap_purchase_buttons">

                   </div>
               </div>
            </ItemTemplate>
        </asp:Repeater>



        <!--시스템 요구사양파트-->
        <p class="p_requirement">시스템 요구사양</p>
        <div class="div_wrap_total_requirement">
            <div class="div_wrap_minimun">
              <asp:Repeater ID="detailMinRequireRepeater" runat="server">
                <ItemTemplate>
                   <p class="p_require_title">최소사양</p> <br />
                   <p class="p_require1">운영체제: </p><p class="p_require2 p_require_os"><%# Eval("운영체제") %></p><br /><br />
                   <p class="p_require1">CPU: </p><p class="p_require2 p_require_cpu"><%# Eval("CPU") %></p><br /><br />
                   <p class="p_require1">그래픽카드: </p><p class="p_require2 p_require_vga"><%# Eval("그래픽카드") %></p><br /><br />
                   <p class="p_require1">메모리: </p><p class="p_require2 p_require_ram"><%# Eval("메모리") %></p><br /><br />
                   <p class="p_require1">저장공간: </p><p class="p_require2 p_require_hdd"><%# Eval("저장공간") %></p>
                </ItemTemplate>
              </asp:Repeater>
            </div>
            <div class="div_wrap_recommend">
                <asp:Repeater ID="detailRecRequireRepeater" runat="server">
                    <ItemTemplate>
                        <p class="p_require_title">권장사양</p> <br />
                        <p class="p_require1">운영체제: </p><p class="p_require2 p_require_os"><%# Eval("운영체제") %></p><br /><br />
                        <p class="p_require1">CPU: </p><p class="p_require2 p_require_cpu"><%# Eval("CPU") %></p><br /><br />
                        <p class="p_require1">그래픽카드: </p><p class="p_require2 p_require_vga"><%# Eval("그래픽카드") %></p><br /><br />
                        <p class="p_require1">메모리: </p><p class="p_require2 p_require_ram"><%# Eval("메모리") %></p><br /><br />
                        <p class="p_require1">저장공간: </p><p class="p_require2 p_require_hdd"><%# Eval("저장공간") %></p>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>





        <!--리뷰파트-->
        




       <div class="footer"></div>
    </div>
</asp:Content>
