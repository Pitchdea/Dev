<%@ Page Language="C#" 
    AutoEventWireup="true"
    CodeBehind="createIdeaPage.aspx.cs"
    Inherits="Pitchdea.CreateIdeaPage"
    MasterPageFile="Main.Master" %>

<asp:Content runat="server" ID="Head" ContentPlaceHolderID="head">
    
</asp:Content>

<asp:Content runat="server" ID="HeaderContentPlaceHolder" ContentPlaceHolderID="HeaderContent">
    <controls:LoginStatusControl ID="loginStatusControl" runat="server"/>
</asp:Content>

<asp:Content runat="server" ID="ContentPlaceHolder1" ContentPlaceHolderID="MainContent">

    <asp:TextBox runat="server" ID="titleTextBox"/>
    <asp:TextBox runat="server" ID="summaryTextBox" TextMode="MultiLine" />
	<asp:TextBox runat="server" ID="descriptionTextBox" TextMode="MultiLine" />    
	<asp:TextBox runat="server" ID="questionTextBox" TextMode="MultiLine" />    
	
    <asp:Button runat="server" ID="createIdeaButton" OnClick="createIdeaButton_OnClick" />
    
</asp:Content>
