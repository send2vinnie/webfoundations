<%@ 
Page Title="" 
Language="C#" 
AutoEventWireup="true" 
CodeFile="pages.aspx.cs" 
Inherits="pages" %>

<%@ Register src="controls/CMS.ascx" tagname="CMS" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <uc1:CMS ID="CMS1" runat="server" Instance="1" />

</asp:Content>

