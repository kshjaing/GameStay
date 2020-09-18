<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Store_Main.aspx.cs" Inherits="GameStay.Store_Main" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/StoreMain_StyleSheet.css?ver=12" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="wrap_total">
        <p class="p_features">특집 및 추천</p>
        <div class="div_wrap_features">
            <div class="div_features_pic">
                <input type="image" src="Images/GameTitleImages/TitleImage_Cyberpunk2077.JPG" 
                    class="title_image"/>
            </div>
            <div class="div_feautres_details">
                <p class="p p_title">사이버펑크 2077</p>
                <p class="p p_status">출시예정 11/19</p>
                <p class="p p_preorder">사전주문</p>
                <p class="p p_price">\66,000</p>
            </div>
        </div>
    </div>
</asp:Content>
