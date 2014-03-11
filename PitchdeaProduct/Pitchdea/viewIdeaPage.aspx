<%@ Page Language="C#"
    AutoEventWireup="true"
    CodeBehind="viewIdeaPage.aspx.cs"
    Inherits="Pitchdea.ViewIdeaPage"
    MasterPageFile="Main.Master" %>


<asp:Content runat="server" ID="Head" ContentPlaceHolderID="head">
</asp:Content>

<asp:Content runat="server" ID="ContentPlaceHolder1" ContentPlaceHolderID="MainContent">
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
    <asp:Literal runat="server" ID="loggedIn"/>
    <div class="ideaWrapper">
        <asp:Panel runat="server" ID="ideaNotFoundPanel">
            Idea not found...
        
            <a href="mainPage.aspx">Return to main page.</a>
        </asp:Panel>
        
        <asp:Panel runat="server" ID="ideaPanel">
            <script>
                function IsUserLoggedIn()
                {
                    var field = document.getElementById("loggedIn");
                    if (field.value == "True") {
                        return true;
                    }
                    alert("Please login first.");
                    return false;
                }
            </script>
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

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="ideabuttons">
                            <asp:Button ID="yesButton" runat="server" CssClass="yesbutton" OnClick="yesButton_OnClick" OnClientClick="return IsUserLoggedIn();" Text="&nbsp; I like this! &nbsp;"/>
                            <asp:Button ID="noButton" runat="server" CssClass="nobutton" OnClick="noButton_OnClick" OnClientClick="return IsUserLoggedIn();" Text="Not my thing!"/>
    	      	            <asp:label runat="server" ID="ideaLikeLabel" CssClass="idealikes" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <asp:Panel runat="server" CssClass="ideaOwner" ID="ideaOwnerPanel">
                    Idea owner: &nbsp;
                    <asp:Label runat="server" ID="ideaOwner" />
                </asp:Panel>
                <div class="commentplaceholder">
                    <textarea disabled="disabled">
                           Commenting coming soon!
                    </textarea>
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
