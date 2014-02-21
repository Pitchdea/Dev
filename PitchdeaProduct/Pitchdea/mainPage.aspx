<%@ Page AutoEventWireup="true" 
    CodeBehind="mainPage.aspx.cs" 
    Inherits="Pitchdea.MainPage" 
    Title="Pitchdea - Where ideas evolve!" 
    Language="C#" 
    MasterPageFile="Main.Master" %>

<asp:Content runat="server" ID="Head" ContentPlaceHolderID="head">
    
</asp:Content>

<asp:Content runat="server" ID="ContentPlaceHolder1" ContentPlaceHolderID="MainContent">
    <asp:Label runat="server" ID="activeUserLabel"/>
</asp:Content>
