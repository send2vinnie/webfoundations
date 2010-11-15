<%@ 
Page Title="" 
Language="C#" 
AutoEventWireup="true" 
CodeFile="pages.aspx.cs" 
Inherits="pages" %>
<%@ Register src="controls/CMS.ascx" tagname="CMS" tagprefix="cms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TopContent" Runat="Server">
    <cms:CMS ID="CMS2" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <cms:CMS ID="CMS1" runat="server" Instance="1" />
</asp:Content>

