<%@ Page Language="C#" 
    AutoEventWireup="true"
    CodeBehind="createIdeaPage.aspx.cs"
    Inherits="Pitchdea.CreateIdeaPage"
    MasterPageFile="Main.Master" %>

<asp:Content runat="server" ID="Head" ContentPlaceHolderID="head">
    
</asp:Content>

<asp:Content runat="server" ID="ContentPlaceHolder1" ContentPlaceHolderID="MainContent">
    <div class="generalForm">
        <h1>Create your idea</h1>
        Idea title<br/>
        <asp:TextBox runat="server" ID="titleTextBox"/>
        A short summary of the idea <span class="de-emphasis">(~200 characters)</span><br/>
        <asp:TextBox runat="server" ID="summaryTextBox" TextMode="MultiLine" height="100px" />
        The main content for your idea page<br/>
	    <asp:TextBox runat="server" ID="descriptionTextBox" TextMode="MultiLine" height="300px"/>    
        The question you want to ask your audience <span class="de-emphasis">(E.g. Would you like to buy a customized smarthone?)</span><br/>
	    <asp:TextBox runat="server" ID="questionTextBox" TextMode="MultiLine" height="50px" />    
	
    
        <asp:FileUpload id="ImgUpload" runat="server" /><br />
        <asp:Button runat="server" ID="uploadImageButton" OnClick="uploadImageButton_OnClick" Text="Upload a picture"/>
        <asp:Label runat="server" ID="uploadStatusLabel" />
        <asp:Image runat="server" ID="previewImage" />

        <asp:Button runat="server" ID="createIdeaButton" OnClick="createIdeaButton_OnClick" Text="Create your idea"/>
        <asp:Label runat="server" ID="errorMessage"/>
    </div>
</asp:Content>
