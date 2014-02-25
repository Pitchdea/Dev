<%@ Page Language="C#" 
    AutoEventWireup="true"
    CodeBehind="createIdeaPage.aspx.cs"
    Inherits="Pitchdea.createIdeaPage"
    MasterPageFile="Main.Master" %>

<asp:Content runat="server" ID="Head" ContentPlaceHolderID="head">
    
</asp:Content>

<asp:Content runat="server" ID="ContentPlaceHolder1" ContentPlaceHolderID="MainContent">

    <asp:TextBox runat="server" ID="titleTextBox"/>
    <asp:TextBox runat="server" ID="summaryTextBox"/>
	<asp:TextBox runat="server" ID="descriptionTextBox"/>    
	
    <asp:Button runat="server" ID="createIdeaButton" />
    
</asp:Content>
