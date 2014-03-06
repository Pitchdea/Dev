<%@ Control 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="LoginStatusControl.ascx.cs" 
	Inherits="Pitchdea.Controls.LoginStatusControl" %>
<div class="loginstatus">
<asp:Label runat="server" CssClass="de-emphasis" ID="loggedInAsLabel">Logged in as</asp:Label>  <span class="loginname"><asp:Label runat="server" ID="activeUserLabel"/></span>
<asp:LinkButton runat="server" Text="Login" Visible="False" ID="loginLink" OnClick="loginLink_OnClick" />
<asp:LinkButton runat="server" Text="Register" Visible="False" ID="registerLink" OnClick="registerLink_OnClick" />
<asp:LinkButton runat="server" Text="Logout" Visible="False" ID="logoutLink" OnClick="logoutLink_OnClick"/>
</div>