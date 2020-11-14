<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="BuyGame.aspx.cs" Inherits="GameStay.BuyGame" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/BuyGame_StyleSheet.css?ver=10" rel="stylesheet" />
    <script>
        function onClickBuy() {
            __doPostBack('buy_button');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrap_total">
        <asp:Repeater runat="server" ID="titleRepeater">
            <ItemTemplate>
                <div class="div_wrap_contentbox" id="div_wrap_contentbox">
                     <div class="div_wrap_image">
                         <img src='<%# Eval("와이드이미지") %>' class="image"/>
                     </div>
                     <div class="div_wrap_p_title">
                         <p class="p_title"><%# Eval("게임명") %></p>
                     </div>
                     <div class="div_wrap_p_price">
                         <p class="p_price">금액 : &#8361;<%# Convert.ToInt32(Eval("게임가격"))
                            - Convert.ToInt32(Eval("게임가격")) * Convert.ToDouble(Eval("할인율")) %>원</p>
                     </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="div_wrap_button">
             <div class="div_buy_button">
                  <button class="buy_button" onclick="onClickBuy()" runat="server" id="buy_button">구매</button>
             </div>
        </div>
    </div>
</asp:Content>
