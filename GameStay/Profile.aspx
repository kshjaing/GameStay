<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="GameStay.Profile" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <meta http-equiv="content-type" content="text/html; charset=utf-8" />
    <link href="CSS/Profile_StyleSheet.css?ver=11" rel="stylesheet" />
    
    <div class="profile_square" >
        <h1 class="txt_profile" >프로필</h1>
        <h2>
            <asp:Image ID="img_profile" runat="server" CssClass="img_profile" ImageUrl="~/Images/Profile/Profile_Mongkka.png"></asp:Image>
            
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>

        </h2>
        
    </div>

</asp:Content>
