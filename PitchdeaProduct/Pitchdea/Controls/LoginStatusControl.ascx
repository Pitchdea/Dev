<%@ Control 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="LoginStatusControl.ascx.cs" 
	Inherits="Pitchdea.Controls.LoginStatusControl" %>
<div class="loginstatus">
<span class="logintext">Logged in as</span>  <span class="loginname"><asp:Label runat="server" ID="activeUserLabel"/></span>
<asp:HyperLink runat="server" Text="Login" Visible="False" ID="loginLink" NavigateUrl="..\loginPage.aspx"/>
<asp:LinkButton runat="server" Text="Logout" Visible="False" ID="logoutLink"/>
</div>