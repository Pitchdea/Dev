﻿<%@ Page Language="C#" 
    AutoEventWireup="true" 
    CodeBehind="editIdeaPage.aspx.cs" 
    Inherits="Pitchdea.EditIdeaPage"
    MasterPageFile="Main.Master"  %>

<asp:Content runat="server" ID="ContentPlaceHolder1"  ContentPlaceHolderID="MainContent">
    <asp:Panel runat="server" CssClass="ideaForm" ID="editIdeaPanel">
        <h1>Edit your idea</h1>
        <div class="ideaImage">
            <asp:Image runat="server" ID="ideaImage" />
        </div>

        <asp:FileUpload id="ImgUpload" runat="server" />  (Max. 500KB) <br />
        <asp:Button runat="server" ID="uploadImageButton" OnClick="uploadImageButton_OnClick" OnClientClick="#todo" Text="Upload a picture"/>
        <br /><asp:Label runat="server" ID="uploadStatusLabel" />
        &nbsp;<asp:Image runat="server" ID="previewImage" />
        <controls:ThumbnailCropControl ID="cropControl" runat="server"/>
        <br />
        

        <asp:TextBox runat="server" ID="ideaTitleTextBox"/>
        <asp:TextBox runat="server" ID="ideaSummaryTextBox" TextMode="MultiLine"/>
        <asp:TextBox runat="server" ID="ideaDescriptionTextBox" TextMode="MultiLine"/>
        <asp:TextBox runat="server" ID="ideaQuestionTextBox" TextMode="MultiLine"/>
        <asp:Button runat="server" ID="submitChangesButton" Text="Save changes" OnClick="submitChangesButton_OnClick"/>
    </asp:Panel>
</asp:Content>