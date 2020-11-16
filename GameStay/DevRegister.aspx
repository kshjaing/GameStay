<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DevRegister.aspx.cs" Inherits="GameStay.DevRegister" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/DevRegister_StyleSheet.css?ver=11" rel="stylesheet" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script>
        function onClickLogo() {
            __doPostBack('div_logo');
        }
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrap">
             <div class="div_logo" id="div_logo" onclick="onClickLogo()" runat="server">
                 <img class="img_logo" src="Images/Logo_GameStay.png" />
             </div>
             <div class="login_square">
                 <h1 class="txt_login">개발사 계정등록</h1>
                 <div class="wrap_idpass">
                     <input type="text" class="input_data" placeholder="아이디" runat="server" ID="inputID" autocomplete="off"/><br />
                     <input type="password" class="input_data" placeholder="비밀번호" runat="server" ID="inputPassword" autocomplete="off"/><br />
                     <input type="password" class="input_data" placeholder="비밀번호 확인" runat="server" ID="inputPasswordDupl" autocomplete="off"/><br />
                     <input type="email" class="input_data" placeholder="이메일" runat="server" ID="inputEmail" autocomplete="off"/><br />
                     <input type="text" class="input_data" placeholder="개발사 이름" runat="server" ID="inputNickname" autocomplete="off"/><br />
                     <input type="text" class="input_data" placeholder="개발사 사이트 링크" runat="server" ID="inputLink" autocomplete="off"/><br />
                     <div class="wrap_input_img">
                    <a class="txt_devreg_img">프로필이미지</a>
                    <asp:FileUpload ID="uploadImg_dev" runat="server" cssclass="txt_devreg_imgselect"/><br />
                     </div>
                      <asp:TextBox ID="txt_explain" runat="server" CssClass="input_explain" TextMode="MultiLine" placeholder="개발사 설명" autocomplete="off"></asp:TextBox><br />
                 </div><br/>
                 <div class="div_button">
                     <a runat="server" id="txtRegistCheck" class="txt_check" draggable="false" ></a><br />
                     <input type="button" runat="server" class="button_register" onserverclick="Register_OnClick" value="가입"/>
                 </div>
                 
             </div>
        </div>
    </form>
</body>
</html>
