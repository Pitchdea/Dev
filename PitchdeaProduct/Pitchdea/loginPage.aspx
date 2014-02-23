<%@ Page AutoEventWireup="true" 
    CodeBehind="loginPage.aspx.cs" 
    Inherits="Pitchdea.LoginPage" 
    Title="Sign in | Pitchdea" 
    Language="C#" 
    MasterPageFile="Main.Master" %>

<asp:Content runat="server" ID="Head" ContentPlaceHolderID="head">
    
</asp:Content>

<asp:Content runat="server" ID="ContentPlaceHolder1" ContentPlaceHolderID="MainContent">
    <asp:TextBox runat="server" ID="emailTextBox"/>
    <asp:TextBox runat="server" ID="passwordTextBox" TextMode="Password"/>
    <asp:Button runat="server" ID="loginButton" OnClick="loginButton_OnClick"/>
    
    <asp:Label runat="server" ID="testLabel"/>
    
    <asp:Label runat="server" ID="errorMessage"/>

<%-- Below temporary textbox for test purpose--%>
    <asp:TextBox runat="server" ID="multiBox" TextMode="MultiLine" />


</asp:Content>
