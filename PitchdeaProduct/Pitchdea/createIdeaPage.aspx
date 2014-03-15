<%@ Page Language="C#" 
    AutoEventWireup="true"
    CodeBehind="createIdeaPage.aspx.cs"
    Inherits="Pitchdea.CreateIdeaPage"
    MasterPageFile="Main.Master" %>

<asp:Content runat="server" ID="Head" ContentPlaceHolderID="head">
    
</asp:Content>

<asp:Content runat="server" ID="ContentPlaceHolder1" ContentPlaceHolderID="MainContent">
    <asp:Panel runat="server" CssClass="ideaForm" ID="createIdeaPanel">
        <h1>Create your idea</h1>
        <%-- TODO: Ajax file upload! --%>
        <%--<asp:ScriptManager runat="server" ID="MainScriptManager"/>

        <asp:UpdatePanel  runat="server" ID="MainUpdatePanel">
            <ContentTemplate>--%>
                Idea title<br/>
                <asp:TextBox runat="server" ID="titleTextBox"/><br />
                A short summary of the idea <span class="de-emphasis">(~200 characters)</span><br/>
                <asp:TextBox runat="server" ID="summaryTextBox" TextMode="MultiLine" height="100px" /><br />
                The main content for your idea page<br/>
	            <asp:TextBox runat="server" ID="descriptionTextBox" TextMode="MultiLine" height="300px"/><br />  
                The question you want to ask your audience <span class="de-emphasis">(E.g. Would you like to buy a customized smarthone?)</span><br/>
	            <asp:TextBox runat="server" ID="questionTextBox" TextMode="MultiLine" height="50px" /><br />    
	
                <asp:FileUpload id="ImgUpload" runat="server" />  (Max. 500KB) <br />
                <asp:Button runat="server" ID="uploadImageButton" OnClick="uploadImageButton_OnClick" OnClientClick="#todo" Text="Upload a picture"/>
                <br /><asp:Label runat="server" ID="uploadStatusLabel" />
                &nbsp;<asp:Image runat="server" ID="previewImage" />
                <controls:ThumbnailCropControl ID="cropControl" runat="server"/>
                <br />
                <asp:Button runat="server" ID="createIdeaButton" OnClick="createIdeaButton_OnClick" Text="Create your idea"/>
                <asp:Label runat="server" ID="errorMessage"/>
            <%--</ContentTemplate>
        </asp:UpdatePanel>--%>
    </asp:Panel>
    <asp:Panel runat="server" ID="loginFirstPanel">
        Please login first...
    </asp:Panel>
</asp:Content>
