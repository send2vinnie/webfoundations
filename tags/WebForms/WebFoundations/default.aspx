<%@ Page 
Language="C#" 
AutoEventWireup="true" 
CodeFile="default.aspx.cs" 
Inherits="_default" 
Title="Home" MasterPageFile="~/theme/kohout.master" 
%>
<%@ MasterType TypeName="BaseMaster" %>
<%@ Register src="controls/CMS.ascx" tagname="CMS" tagprefix="cms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TopContent" Runat="Server">
    <cms:CMS ID="CMS1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <div class="shadow"> 
         <img src='<%=Page.ResolveClientUrl("~/static/images/image.jpg")%>' alt="image.jpg" title="image.jpg" class="thumb" />
    </div>
    <cms:CMS ID="CMS2" runat="server" Instance="1" /> 
    
  
   
</asp:Content>