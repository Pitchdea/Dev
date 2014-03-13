<%@ Page Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="registerPage.aspx.cs" 
    Inherits="Pitchdea.RegisterPage"
    MasterPageFile="Main.Master" %>


<asp:Content runat="server" ID="Head" ContentPlaceHolderID="head">
    
</asp:Content>

<asp:Content runat="server" ID="ContentPlaceHolder1" ContentPlaceHolderID="MainContent">
    
    <asp:ScriptManager runat="server" ID="MainScriptManager"/>

    <asp:UpdatePanel  runat="server" ID="MainUpdatePanel">
        <ContentTemplate>
            <div class="generalForm">
                <h1>Register</h1>
                <div class="de-emphasis"><p>Closed beta PreGame registration is only open until 16.3.2014</p></div>
                Email:<br/>
                <asp:TextBox runat="server" ID="emailTextBox"/>
                <br />Username:<br />
                <asp:TextBox runat="server" ID="usernameTextBox"/>
                <br />Password:<br />
                <asp:TextBox runat="server" ID="passwordTextBox" TextMode="Password"/>
                <br />Confirm password:<br />
                <asp:TextBox runat="server" ID="passwordConfirmationTextBox" TextMode="Password"/><br />

                <asp:Button runat="server" ID="registerButton" OnClick="registerButton_OnClick"  Text="Register"/>
                <asp:Label runat="server" ID="errorMessage"/>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
