<%@ Control Language="C#" AutoEventWireup="true" CodeFile="gallery.ascx.cs" Inherits="Controls_gallery" %>

<asp:PlaceHolder ID="phLibrarys" runat="server">
    <link rel="stylesheet" href="/css/lightbox.css" type="text/css" media="screen" />
    <script src="../javascript/libs/prototype/prototype-1.6.0.2.js" type="text/javascript"></script>
    <script src="../javascript/libs/scriptaculous/scriptaculous.js?load=effects,builder" type="text/javascript"></script>
    <script src="../javascript/libs/3rdparty/lightbox.js" type="text/javascript"></script>
</asp:PlaceHolder>
    
<asp:xml runat="server" id="xmlGallery" TransformSource="../XSL/Lightbox.xsl" />
<asp:Label ID="lblMSG" runat="server" />