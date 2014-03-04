<%@ Page Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="registerPage.aspx.cs" 
    Inherits="Pitchdea.RegisterPage"
    MasterPageFile="Main.Master" %>


<asp:Content runat="server" ID="Head" ContentPlaceHolderID="head">
    
</asp:Content>

<asp:Content runat="server" ID="ContentPlaceHolder1" ContentPlaceHolderID="MainContent">
    <div class="generalForm">
        Email:<br/>
        <asp:TextBox runat="server" ID="emailTextBox"/>
        Username:<br />
        <asp:TextBox runat="server" ID="usernameTextBox"/>
        Password:<br />
        <asp:TextBox runat="server" ID="passwordTextBox" TextMode="Password"/>
        Confirm password:<br />
        <asp:TextBox runat="server" ID="passwordConfirmationTextBox" TextMode="Password"/>

        <asp:Button runat="server" ID="registerButton" OnClick="registerButton_OnClick"  Text="Register"/>
        <asp:Label runat="server" ID="errorMessage"/>
    </div>

</asp:Content>
