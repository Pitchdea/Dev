<%@ Page Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="viewIdeaPage.aspx.cs" 
    Inherits="Pitchdea.ViewIdeaPage"
    MasterPageFile="Main.Master" %>


<asp:Content runat="server" ID="Head" ContentPlaceHolderID="head">
    
</asp:Content>

<asp:Content runat="server" ID="ContentPlaceHolder1" ContentPlaceHolderID="MainContent">
    
    <asp:Panel runat="server" ID="ideaNotFoundPanel">
        Idea not found...
        
        <a href="mainPage.aspx">Return to main page.</a>
    </asp:Panel>

    <asp:Label runat="server" ID="statusMessage" />
    
    <asp:Label runat="server" ID="titleLabel"/>

    <asp:Image runat="server" ID="ideaImage"/>

    <asp:Label runat="server" ID="summaryLabel"/>
    <asp:Label runat="server" ID="descriptionLabel" />
    <asp:Label runat="server" ID="questionLabel"/>
    <asp:Label runat="server" ID="ideaOwner"/>
</asp:Content>
