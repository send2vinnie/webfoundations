<%@ Control 
Language="C#" 
AutoEventWireup="true" 
CodeFile="CMS.ascx.cs" 
Inherits="Controls_CMS" 
%>

<asp:PlaceHolder runat="server" id="phCMS">
        <asp:Literal runat="server" ID="litContent" />
        <asp:Button 
        runat="server" 
        ID="btnEditContent" 
        Visible="false" 
        Text="Edit content" 
        OnClick="butEditContent_Click" 
        />
</asp:PlaceHolder>