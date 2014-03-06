<%@ Page AutoEventWireup="true" 
    CodeBehind="mainPage.aspx.cs" 
    Inherits="Pitchdea.MainPage" 
    Title="Pitchdea - Where ideas evolve!" 
    Language="C#" 
    MasterPageFile="Main.Master" %>

<asp:Content runat="server" ID="Head" ContentPlaceHolderID="head">
    
</asp:Content>

<asp:Content runat="server" ID="MainContent" ContentPlaceHolderID="MainContent">
    <asp:Panel runat="server" ID="ideaPanel"/>
    <a href="createIdeaPage.aspx">Submit an Idea</a>
</asp:Content>
