<%@ Page 
Language="C#" 
MasterPageFile="~/Theme/skin.master" 
AutoEventWireup="true" 
CodeFile="gallery.aspx.cs" 
Inherits="Galery" 
Title="Untitled Page" 
%>
<%@ MasterType TypeName="BaseMaster" %>
<%@ Register Src="Controls/gallery.ascx" TagName="gallery" TagPrefix="pics" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <pics:gallery ID="Gallery1" runat="server" />
    <pics:gallery ID="Gallery2" runat="server" Album="Heroes" LoadLibrarys="false" />

</asp:Content>

