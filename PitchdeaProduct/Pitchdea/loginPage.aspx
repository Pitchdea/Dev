<%@ Page AutoEventWireup="true" 
    CodeBehind="loginPage.aspx.cs" 
    Inherits="Pitchdea.LoginPage" 
    Title="Sign in | Pitchdea" 
    Language="C#" 
    MasterPageFile="Main.Master" %>

<asp:Content runat="server" ID="Head" ContentPlaceHolderID="head">
    
</asp:Content>

<asp:Content runat="server" ID="ContentPlaceHolder1" ContentPlaceHolderID="MainContent">
    
    <asp:ScriptManager runat="server" ID="MainScriptManager"/>

    <asp:UpdatePanel  runat="server" ID="MainUpdatePanel">
        <ContentTemplate>
            <div class="generalForm">
                  <h1>Login</h1>
                  Email or username:<br/>
                  <asp:TextBox runat="server" ID="emailTextBox"/>
                  <br/>Password:<br/>
                  <asp:TextBox runat="server" ID="passwordTextBox" TextMode="Password"/><br/>
                  <asp:Button runat="server" ID="loginButton" OnClick="loginButton_OnClick" Text="Log in"/><br/>
                  <asp:Label runat="server" ID="errorMessage"/>
              </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
