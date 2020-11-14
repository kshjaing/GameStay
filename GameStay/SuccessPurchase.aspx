<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="SuccessPurchase.aspx.cs" Inherits="GameStay.SuccessPurchase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/SuccessPurchase_StyleSheet.css?ver=13" rel="stylesheet" />
    <script>
        function goStoreOnClick() {
            __doPostBack('p_goStore');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="wrap_total">
        <div class="request_square">
            <img src="" class="bg_image" runat="server" id="bg_image" />
            <div class="wrap_p">
                <p class="p_guide">게임 구매 완료!</p>
                <p class="p_content" runat="server" id="p_content"></p>
                <p class="p_gostore" id="p_goStore" onclick="goStoreOnClick()">상점으로 이동</p>
            </div>
        </div>
    </div>
</asp:Content>
