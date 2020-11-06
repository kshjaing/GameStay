<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="UploadGame.aspx.cs" Inherits="GameStay.UploadGame" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="CSS/UploadGame_StyleSheet.css?ver=16" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="wrap_total">
        <div class="square">
            <div class="div_upload_title">
                <a class="txt_upload_title">게임 등록 및 수정</a>
            </div>
            <a class="txt_upload_subtitle">게임 기본 정보</a>
            <div class="div_upload_data">
                <input type="text" class="input_data" placeholder="게임 한글명" runat="server" id="inputTitleKor" autocomplete="off"/><br />
                <input type="text" class="input_data" placeholder="게임 영문명" runat="server" id="inputTitleEng" autocomplete="off"/><br />
                <input type="text" class="input_data" placeholder="게임 원가 (:원)" runat="server" id="inputPrice" autocomplete="off"/><br />
                <input type="text" class="input_data" placeholder="게임 할인율 ( % )" runat="server" id="inputDiscount" autocomplete="off"/><br />
                <input type="text" class="input_data" placeholder="게임 발매일" runat="server" id="inputDate" autocomplete="off"/><br />
                <asp:TextBox ID="txt_explain" runat="server" CssClass="input_explain" TextMode="MultiLine" placeholder="개발사 설명" autocomplete="off"></asp:TextBox>
            </div>
            
            <div>
                <a class="txt_upload_subtitle">게임 이미지</a><br />
                <div class="div_upload_subimg">
                    <a class="txt_upload_imgtitle">대표이미지</a>
                    <asp:FileUpload ID="FileUpload1" runat="server" cssclass="txt_upload_imgselect"/>
                </div>
                <div class="div_upload_subimg">
                    <a class="txt_upload_imgtitle">와이드이미지</a>
                    <asp:FileUpload ID="FileUpload2" runat="server" cssclass="txt_upload_imgselect"/>
                </div>
                <div class="div_upload_subimg">
                    <a class="txt_upload_imgtitle">이미지1</a>
                    <asp:FileUpload ID="FileUpload3" runat="server" cssclass="txt_upload_imgselect"/>
                    
                </div>
                <asp:ListBox ID="ListBox1" runat="server" CssClass="lbox_imglist"></asp:ListBox>
            </div>
        </div>
    </div>
</asp:Content>
