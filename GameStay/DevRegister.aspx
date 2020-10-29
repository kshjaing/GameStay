<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DevRegister.aspx.cs" Inherits="GameStay.DevRegister" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/DevRegister_StyleSheet.css?ver=15" rel="stylesheet" />
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
                     <div class="wrap_input_id">
                        <input type="text" class="input_id" placeholder="아이디"
                            runat="server" id="inputID" autocomplete="off"/>
                        <img class="icon_id" src="Images/Icon/Login/Icon_ID.png" />
                         
                     </div>
                     <div class="wrap_input_password">
                        <input type="password" class="input_password" placeholder="비밀번호"
                            runat="server" id="inputPassword" autocomplete="off"/>
                        <img class="icon_password" src="Images/Icon/Login/Icon_Password.png" />
                     </div>

                     <div class="wrap_input_password_dupl">
                        <input type="password" class="input_password" placeholder="비밀번호 확인"
                            runat="server" id="inputPasswordDupl" autocomplete="off"/>
                        <img class="icon_password" src="Images/Icon/Login/Icon_Password.png" />
                     </div>
                                          <div class="wrap_input_email">
                        <input type="email" class="input_email" placeholder="이메일"
                            runat="server" id="inputEmail" autocomplete="off"/>
                        <img class="icon_email" src="Images/Icon/Login/Icon_Email.png" />
                     </div>
                     <div class="wrap_input_nickname">
                        <input type="text" class="input_name" placeholder="개발사 이름"
                            runat="server" id="inputNickname" autocomplete="off"/>
                        <img class="icon_email" src="Images/Icon/Login/Icon_Email.png" />
                     </div>                     
                 </div>
                 <div class="wrap_input_img">
                     <p class="txt_devreg_img">개발사 이미지 등록</p>
                     <input type="image" id="img_profile" runat="server" class="img_profile" />
                     <br />
                     <asp:FileUpload ID="uploadImg_dev" runat="server" CssClass="txt_devreg_imgselect" OnPropertyChanged="Image1" />
                 </div>

                 <br /><br /><br />

                     <div class="wrap_input_explain">
                        
                         <asp:TextBox ID="txt_explain" runat="server" CssClass="input_explain" TextMode="MultiLine" placeholder="개발사 설명" autocomplete="off"></asp:TextBox>
                         <br />
                         <a runat="server" id="txtRegistCheck" class="txt_check" draggable="false" >
                            
                        </a>
                     </div>
                     
                 <input type="button" runat="server" class="button_register" onserverclick="Register_OnClick" value="가입"/>
             </div>
        </div>
    </form>
</body>
</html>

