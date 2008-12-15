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
    
    <ul class="columns">
      <li class="col1">
        <h3>KISS (Keep It Simple Stupid)</h3>
        <p>
        These ASP.NET Foundations allow me to very quickly build simple content managed site. Web Foundation sites can be hosted on <em>inexpensive hosting</em> as there is <strong>NO Database requirement</strong> (all the data is stored in XML files).       
        </p>   
      </li>
      <li class="col2">
        <h3>Features:</h3>
        <p>
        * A WYSIWYG CMS (FCKEditor)<br />
        * Multi language support (.net globalisation)<br />
        * A gallery plugin (XML Picasa exports)<br/>
        * Search engine friendly UL's (url rewriting)<br />
        * Easily themable (ASP.Net Master Pages)<br />
        </p> 
      </li>
      <li class="col3">
        <h3>Enjoy</h3>
        <p>
        To try it yourself login with the password "WebFoundations" <br />(you can change this in the web.config) 
        </p> 
      </li>
    </ul>
    
    <br style="clear: both;" />
   <p><strong>Courtenay Probert</strong><br /><em>Web Foundations Lead Developer</em><br /></p>     
   
</asp:Content>