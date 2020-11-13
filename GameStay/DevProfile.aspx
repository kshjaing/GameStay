<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="DevProfile.aspx.cs" Inherits="GameStay.DevProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/DevProfile_StyleSheet.css?ver=12" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrap_total">
        <div class="profile_square" >
            <asp:Repeater runat="server" ID="DevInfo">
                <ItemTemplate>
                    <div class="div_profile_top">
                        <div class="div_profile_img">
                            <input type="image" id="Image1" runat="server" class="img_profile" src='<%# Eval("개발사로고") %>'/>
                        </div>
                        <div class="div_profile_detail">
                            <p class="txt_profile_nickname"><%#Eval("개발사이름") %></p>
                            <p class="txt_profile_Link">링크</p>
                        </div>
                        </ItemTemplate>
            </asp:Repeater>
                        <div class="div_profile_edit">
                            <input type="button" runat="server" class="button_profile" onserverclick="registGame_click" id="btn_registgame" value="게임 등록"/>
                        </div>
                    </div>
        <asp:Repeater runat="server" ID="DevInfo1">
                <ItemTemplate>
                    <div class="div_explain">
                        <p class="txt_profile_explain"><%#Eval("개발사소개") %></p>
                    </div>
                    </ItemTemplate>
            </asp:Repeater>
            <p class="txt_newgame_title ">신규출시</p>
            <div class="profile_newgame">
                <asp:Repeater runat="server" ID="NewGame1">
                    <ItemTemplate>
                        <div class="div_newgames1">
                            <input type="image" id="Img1" runat="server" class="img_newgame" src='<%# Eval("메인이미지") %>' />
                                <p class="txt_profile_game_title"><%#Eval("게임명") %></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
        <div class="div_wrap_list">
            <p class="txt_newgame_title ">게임 목록</p>
                      <asp:Repeater ID="Devgamelist" runat="server">
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
                                          <p class="p_best_tags">출시일 : <%# Eval("출시일") %></p>       
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
        </div>
</asp:Content>
