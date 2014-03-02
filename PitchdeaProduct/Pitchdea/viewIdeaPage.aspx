<%@ Page Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="viewIdeaPage.aspx.cs" 
    Inherits="Pitchdea.ViewIdeaPage"
    MasterPageFile="Main.Master" %>


<asp:Content runat="server" ID="Head" ContentPlaceHolderID="head">
    
</asp:Content>

<asp:Content runat="server" ID="ContentPlaceHolder1" ContentPlaceHolderID="MainContent">
    <asp:Label runat="server" ID="statusMessage" />
    
    <asp:Label runat="server" ID="titleLabel"/>
    <asp:Label runat="server" ID="summaryLabel" />
    <asp:Label runat="server" ID="descriptionLabel" />
</asp:Content>
