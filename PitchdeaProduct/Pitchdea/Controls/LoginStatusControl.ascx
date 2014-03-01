<%@ Control 
	Language="C#" 
	AutoEventWireup="true" 
	CodeBehind="LoginStatusControl.ascx.cs" 
	Inherits="Pitchdea.Controls.LoginStatusControl" %>

<asp:Label runat="server" ID="activeUserLabel"/>
<asp:HyperLink runat="server" Text="Login" Visible="False" ID="loginLink" NavigateUrl="..\loginPage.aspx"/>
<asp:LinkButton runat="server" Text="Logout" Visible="False" ID="logoutLink"/>