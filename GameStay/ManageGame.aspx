<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ManageGame.aspx.cs" Inherits="GameStay.RegistGame" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/ManageGame_StyleSheet.css?ver=21" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrap_total">
        <div class="profile_square" >
            <div class="div_profile_detail">
            <asp:Repeater runat="server" ID="Devname">
                    <ItemTemplate>
                    <p class="txt_profile_nickname"><%#Eval("개발사이름") %></p>
                </ItemTemplate>
            </asp:Repeater>
                        <a class="txt_manage_info" runat="server" id="txt_manageinfo"></a>
                <asp:Repeater runat="server" ID="DevInfo">
                    <ItemTemplate>
                    <a class="txt_manage_info">월 수익 : </a><a class="txt_manage_info"><%#Eval("매출액") %></a><a class="txt_manage_info">원</a><br />
                    <a class="txt_manage_info">총 수익 : </a><a class="txt_manage_info"><%#Eval("매출액") %></a><a class="txt_manage_info">원</a>
                </ItemTemplate>
            </asp:Repeater>
            </div>
        </div>
        <div class="div_list_title">
                 <p class="txt_newgame_title ">게임 목록</p>
            
            </div>
        <div class="div_list_btn">
            <input type="button" runat="server" class="button_resist" onserverclick="resistGame_click" id="btn_resistgame" value="게임등록"/>
        </div>

        <div class="div_wrap_list">
            
                      <asp:Repeater ID="Devgamelist" runat="server">
                         <ItemTemplate>

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
                                          <p class="p_best_price">원가 : &#8361;<%# Eval("게임가격") %>원</p>
                                          <p class="p_best_price">판매가 : &#8361;<%# Convert.ToInt32(Eval("게임가격"))
                                                 - Convert.ToInt32(Eval("게임가격")) * Convert.ToDouble(Eval("할인율")) %>원</p>
                                       </div>
                                       <div class="div_wrap_rating">
                                          <div class="div_ratingbox">
                                            <p class="p_rating"><%# Convert.ToDouble(Eval("할인율")) * 100 %>%</p>
                                          </div>
                                       </div>
                                      <div class="div_wrap_edit">
                                               <input type="button" runat="server" class="button_edit" onserverclick="editGame_click" id="btn_editgame" value="수정"/>
                                           </div>
                                 </div>

                        </ItemTemplate>
                      </asp:Repeater>
        </div>
    </div>
</asp:Content>
