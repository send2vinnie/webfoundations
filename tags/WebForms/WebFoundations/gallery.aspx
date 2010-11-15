<%@ Page 
Language="C#" 
AutoEventWireup="true" 
CodeFile="gallery.aspx.cs" 
Inherits="Galery" 
Title="Galleria example" 
%>
<%@ MasterType TypeName="BaseMaster" %>
<%@ Register src="controls/CMS.ascx" tagname="CMS" tagprefix="cms" %>
<%@ Register src="plugins/gallery/galleria.ascx" tagname="galleria" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TopContent" Runat="Server">
    <cms:CMS ID="CMS1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <uc1:galleria ID="galleria1" runat="server" PicasaFeed="~/static/picasa/example/index.xml"/>
</asp:Content>
