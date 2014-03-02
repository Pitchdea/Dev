<%@ Page AutoEventWireup="true" 
    CodeBehind="loginPage.aspx.cs" 
    Inherits="Pitchdea.LoginPage" 
    Title="Sign in | Pitchdea" 
    Language="C#" 
    MasterPageFile="Main.Master" %>

<asp:Content runat="server" ID="Head" ContentPlaceHolderID="head">
    
</asp:Content>

<asp:Content runat="server" ID="ContentPlaceHolder1" ContentPlaceHolderID="MainContent">
    Email or username:
    <asp:TextBox runat="server" ID="emailTextBox"/>
    Password:
    <asp:TextBox runat="server" ID="passwordTextBox" TextMode="Password"/>
    <asp:Button runat="server" ID="loginButton" OnClick="loginButton_OnClick" Text="Log in"/>
    <asp:Label runat="server" ID="errorMessage"/>
</asp:Content>
