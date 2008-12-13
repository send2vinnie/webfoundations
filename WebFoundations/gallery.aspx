<%@ Page 
Language="C#" 
MasterPageFile="~/Theme/skin.master" 
AutoEventWireup="true" 
CodeFile="gallery.aspx.cs" 
Inherits="Galery" 
Title="Galleria example" 
%>
<%@ MasterType TypeName="BaseMaster" %>
<%@ Register src="controls/galleria.ascx" tagname="galleria" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <uc1:galleria ID="galleria1" runat="server" Album="Example" />
</asp:Content>

