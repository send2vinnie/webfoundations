<%@ Control 
Language="C#" 
AutoEventWireup="true" 
CodeFile="CMS.ascx.cs" 
Inherits="Controls_CMS" 
%>

<asp:PlaceHolder runat="server" id="phCMS">
    <div runat="server" id="contentArea">
        <asp:Label runat="server" ID="lblContent" />
        <asp:Button 
        runat="server"
        ID="btnEditContent" 
        Visible="false" 
        Text="Edit content" 
        OnClick="butEditContent_Click" 
        />
    </div><br />
</asp:PlaceHolder>