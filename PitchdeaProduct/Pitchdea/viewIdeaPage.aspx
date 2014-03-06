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
     <div class="ideaTitle"   >
        <h1><asp:Label runat="server" ID="titleLabel"/></h1>
    </div>
     <div class="ideaImage"   >
        <asp:Image runat="server" ID="ideaImage"/>
    </div>
     <div class="ideaSummary"   >
        <h3><asp:Label runat="server" ID="summaryLabel"/></h3>
    </div>
     <div class="ideaDescription"   >
    <asp:Label runat="server" ID="descriptionLabel" />
    </div>
     <div class="ideaQuestion"   >
    <asp:Label runat="server" ID="questionLabel"/>
    </div>
     <div class="ideaOwner"   >
        Submitted by:<br />
    <asp:Label runat="server" ID="ideaOwner"/>
    </div>
</asp:Content>
