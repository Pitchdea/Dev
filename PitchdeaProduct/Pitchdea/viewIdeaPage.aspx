<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="viewIdeaPage.aspx.cs"
    Inherits="Pitchdea.ViewIdeaPage"
    MasterPageFile="Main.Master" %>


<asp:Content runat="server" ID="Head" ContentPlaceHolderID="head">
</asp:Content>

<asp:Content runat="server" ID="ContentPlaceHolder1" ContentPlaceHolderID="MainContent">

    <div class="ideaWrapper">
        <asp:Panel runat="server" ID="ideaNotFoundPanel">
            Idea not found...
        
        <a href="mainPage.aspx">Return to main page.</a>
        </asp:Panel>

        <asp:Label runat="server" ID="statusMessage" />
        <div class="ideaImage">
            <asp:Image runat="server" ID="ideaImage" />
        </div>
        <div class="ideatextwrapper">
            <div class="ideaTitle">
                <h1>
                    <asp:Label runat="server" ID="titleLabel" /></h1>
            </div>
            <div class="ideaSummary">
                <h3>
                    <asp:Label runat="server" ID="summaryLabel" /></h3>
            </div>
            <div class="ideaDescription">
                <asp:Label runat="server" ID="descriptionLabel" />
            </div>
            <div class="ideaQuestion">
                <h3>
                    <asp:Label runat="server" ID="questionLabel" /></h3>
            </div>
            <%--<div class="ideabuttons">
               	<asp:Button ID="noButton" runat="server" CssClass="nobutton"></asp:Button>
               	<asp:Button ID="yesButton" runat="server" CssClass="yesbutton"></asp:Button>
    	      	<asp:label runat="server" ID="ideaLikeLabel" CssClass="idealikes" />
            </div>--%>
            <asp:Panel runat="server" CssClass="ideaOwner" ID="ideaOwnerPanel">
                Idea owner: &nbsp;
                <asp:Label runat="server" ID="ideaOwner" />
            </asp:Panel>
        </div>
    </div>
</asp:Content>
