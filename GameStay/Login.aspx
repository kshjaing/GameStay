<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GameStay.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/Login_StyleSheet.css?ver=2" rel="stylesheet" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script type="text/javascript">
        function imgLogin_Click() {
            __doPostBack('login_Click', '');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrap">
             <div class="div_logo">
                 <img class="img_logo" src="Images/Logo_GameStay.png" />
             </div>
             <div class="login_square">
                 <h1 class="txt_login">로그인</h1>
                 <div class="wrap_idpass">
                     <div class="wrap_input_id">
                        <input type="text" class="input_id" placeholder="아이디"
                             runat="server" id="inputID"/>
                        <img class="icon_id" src="Images/Icon/Icon_ID.png" />
                     </div>
                     <br/><br/><br/>

                     <div class="wrap_input_password">
                        <input type="password" class="input_password" placeholder="비밀번호"
                            runat="server" id="inputPassword"/>
                        <img class="icon_password" src="Images/Icon/Icon_Password.png" />
                     </div> 
                     <br /><br />

                     <div class="wrap_login">
                         <input type="checkbox" class="check_autologin" />
                         <a class="a_autologin" onclick="">자동 로그인</a>
                         <div class="div_icon_login" >
                             <asp:ImageButton runat="server" ID="imgbtnLogin" ImageUrl="Images/Icon/Icon_Login_NotHover.png" 
                                 onMouseOver="this.src='Images/Icon/Icon_Login_Hover.png'"
                                 onMouseOut="this.src='Images/Icon/Icon_Login_NotHover.png'"
                                 CausesValidation="True" CssClass="imgbutton_login" OnClick="imgbtnLogin_Click" />
                         </div>
                     </div>
                     <br /><br /><br /><br />
                     <a runat="server" id="txtLoginCheck" class="a_login_check" draggable="false">가입하지 않은 아이디이거나,<br /> 잘못된 비밀번호입니다.</a>
                     <br /><br /><br /><br />

                     <a class="a_register" href="Register.aspx">회원이 아니신가요?</a>
                     <br /><br />
                 </div>
             </div>
        </div>
    </form>
</body>
</html>
