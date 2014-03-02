<%@ Page Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="RegisterPage.aspx.cs" 
    Inherits="Pitchdea.ViewIdeaPage"
    MasterPageFile="Main.Master" %>


<asp:Content runat="server" ID="Head" ContentPlaceHolderID="head">
    
</asp:Content>

<asp:Content runat="server" ID="ContentPlaceHolder1" ContentPlaceHolderID="MainContent">
    <asp:TextBox runat="server" ID="emailTextBox"/>
    <asp:TextBox runat="server" ID="usernameTextBox"/>
    <asp:TextBox runat="server" ID="passwordTextBox" TextMode="Password"/>
    <asp:TextBox runat="server" ID="passwordConfirmationTextBox" TextMode="Password"/>

    <asp:Button runat="server" ID="registerButton" OnClick="registerButton_OnClick" Text="Register"/>
    <asp:Label runat="server" ID="errorMessage"/>


</asp:Content>
