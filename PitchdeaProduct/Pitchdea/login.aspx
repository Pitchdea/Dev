﻿<%@ Page AutoEventWireup="true" 
    CodeBehind="login.aspx.cs" 
    Inherits="Pitchdea.Login" 
    Title="Sign in | Pitchdea" 
    Language="C#" 
    MasterPageFile="Main.Master" %>

<asp:Content runat="server" ID="Head" ContentPlaceHolderID="head">
    
</asp:Content>

<asp:Content runat="server" ID="ContentPlaceHolder1" ContentPlaceHolderID="MainContentPlaceHolder">
    <asp:TextBox runat="server" ID="emailTextBox"/>
    <asp:TextBox runat="server" ID="passwordTextBox"/>
    <asp:Button runat="server" ID="loginButton"/>
</asp:Content>
