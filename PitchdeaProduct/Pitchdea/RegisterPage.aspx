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
                Email:<br/>
                <asp:TextBox runat="server" ID="emailTextBox"/>
                <br />Beta access key:<br />
                <asp:TextBox runat="server" ID="betaAccessKeyTextBox" /><br />
                Don't have a key? Request one <a href="http://pitchdea.com/#newsletter">here</a>.
                <br />
                <br />Username:<br />
                <asp:TextBox runat="server" ID="usernameTextBox"/>
                <br />Password:<br />
                <asp:TextBox runat="server" ID="passwordTextBox" TextMode="Password"/>
                <br />Confirm password:<br />
                <asp:TextBox runat="server" ID="passwordConfirmationTextBox" TextMode="Password"/>
                <br/>
                <br/>
                <asp:Button runat="server" ID="registerButton" OnClick="registerButton_OnClick"  Text="Register"/>
                <asp:Label runat="server" ID="errorMessage"/>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
