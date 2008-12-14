<%@ Page 
Language="C#" 
AutoEventWireup="true" 
CodeFile="default.aspx.cs" 
Inherits="_default" 
Title="Home" 
%>
<%@ MasterType TypeName="BaseMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <div class="shadow"> 
         <img src='<%=Page.ResolveClientUrl("~/static/images/image.jpg")%>' alt="image.jpg" title="image.jpg" class="thumb" />
    </div>
    
    <p>These foundations allow me to very quickly build simple sites   that provide my clients with the ability to click an edit button   and get write access to the text on their websites. I find it   cleaner and simpler than more comprehensive solutions like   Macromedia Contribute or DotNetNuke. Its also great for inexpensive   hosting as there are no Database requirements.</p>
    <p>Its basically an XML Content Management System. It uses the   Spring URL Rewriting library for search-engine URL's. FCKEditor   provides the WYSIWYG and a C# port of HTML tidy is employed to   sanitise users text.</p>
    <p>I've also built a Lightbox Image Gallery that consumes Picasa   generated XML. This is included as a control so it's really easy to   drop on any page.</p>
    <p>It's all build on ASP.Net Master Pages so its familiar and easy   to extend.</p>
    <div class="introText">To try it youeself login with the password   &quot;<strong>WebFoundations</strong>&quot; (you can change this in the   web.config)</div>
    <p><strong>Courtenay Probert</strong><br />
    <em>Web Foundations Lead Developer</em><br />
    &nbsp;</p>
            
</asp:Content>