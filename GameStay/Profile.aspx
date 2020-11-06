<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="GameStay.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/Profile_StyleSheet.css?ver=10" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrap_total">
        <div class="profile_square" >
            <asp:Repeater runat="server" ID="UserInfo">
                <ItemTemplate>
                  <div class="div_profile_img">
                     <img class="img_profile" src='<%# Eval("프로필사진") %>'/>
                  </div>
                  <div class="div_profile_detail">
                      <p class="txt_profile_nickname"><%#Eval("닉네임") %></p>
                      <a class="txt_profile_detail">레벨 : </a> <a class="txt_profile_level" ><%#Eval("레벨") %></a> <br />
                      </ItemTemplate>
            </asp:Repeater>
            <a class="txt_profile_detail">보유한 게임 :</a> <a class="txt_profile_countgame" runat="server" id="txt_profile_countgame"></a> <a class="txt_profile_detail2">개</a>
        </div> 
        <div class="div_profile_edit">
            <div class="wrap_edit_p" runat="server" id="wrap_edit_p"
                onmouseover="this.style.backgroundColor='#70d0a4'" onmouseout="this.style.backgroundColor='#25262b'">
                <p class="p_profile_edit">프로필 수정</p>
            </div>
        </div>
    </div>

    <div class="profile_square_game">
        <p class="txt_profile_game">최근에 구매한 게임</p>

        <div class="div_profile_game-1">
            
        <div class="div_profile_game" >
           <asp:Repeater runat="server" ID="RecentGame1">
                <ItemTemplate>
                    <img src='<%#Eval("메인이미지") %>' class="img_profile_game"/>
                       <p class="txt_profile_game_title"><%#Eval("게임명") %></p>
                       <p class="txt_profile_game_date"><%#Eval("거래일", "{0:yyyy년MM월dd일}") %></p>
                </ItemTemplate>
           </asp:Repeater>
        </div>
        <div class="div_profile_game">
            <asp:Repeater runat="server" ID="RecentGame2">
                    <ItemTemplate>
                        <img src='<%#Eval("메인이미지") %>' class="img_profile_game"/>
                        <p class="txt_profile_game_title"><%#Eval("게임명") %></p>
                        <p class="txt_profile_game_date"><%#Eval("거래일", "{0:yyyy년MM월dd일}") %></p>
                    </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="div_profile_game">
            <asp:Repeater runat="server" ID="RecentGame3">
                    <ItemTemplate>
                        <img src='<%#Eval("메인이미지") %>' class="img_profile_game"/>
                        <p class="txt_profile_game_title"><%#Eval("게임명") %></p>
                        <p class="txt_profile_game_date"><%#Eval("거래일", "{0:yyyy년MM월dd일}") %></p>
                    </ItemTemplate>
                </asp:Repeater>
        </div>
        </div>
    </div>

        <div class="profile_square_screenshot">
            <p class="txt_profile_screenshot">스크린샷</p>
            <div class="div_profile_scs_main">
                <input type="image" src="Images/GameTitleImages/TitleImage_TheElderScrolls5Skyrim.JPG" class="img_profile_scs_main" />
            </div>
            <div class="div_profile_scs_sub">
                <input type="image" src="Images/GameTitleImages/TitleImage_Firewatch.PNG" class="img_profile_scs_sub"/><br />
                <input type="image" src="Images/GameTitleImages/TitleImage_Cyberpunk2077.JPG" class="img_profile_scs_sub"/>
            </div>
        </div>
        <br />
        <br />
    </div>
</asp:Content>
