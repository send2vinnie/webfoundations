<%@ Page 
Language="C#" 
AutoEventWireup="true" 
CodeFile="Default.aspx.cs" 
Inherits="CMS_Default" 
ValidateRequest="false" 
%>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    
    <meta http-equiv="content-type" content="text/html; charset=iso-8859-1" />
    
    <title />
    
    <script type="text/javascript" language="javascript">
        function RefreshParent()
        {
            window.parent.location.href = window.parent.location.href;
        }
    </script>
    
</head>

<body>
    <form id="form1" runat="server">
    
        <asp:PlaceHolder runat="server" ID="phEditArea">
            
            <fckeditorv2:fckeditor 
            id="fckEditContent" 
            runat="server"
            />
            
            <p><asp:Label runat="server" ID="lblLastEditor" /></p>
            
            <div class="formButtons">
                <asp:Button runat="server" ID="btnSave" Text="Save changes" OnClick="btnSave_Click" />&nbsp;
            </div>

        </asp:PlaceHolder>
        
        
        <p><asp:Label runat="server" ID="lblMsg" /></p>

    </form>
</body>

</html>
