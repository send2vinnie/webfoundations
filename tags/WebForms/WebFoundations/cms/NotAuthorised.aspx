<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NotAuthorised.aspx.cs" Inherits="cms_NotAuthorised" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Not Authorised</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1 style="color: Red;">Not Authorised</h1>
    <p style="color: Red;">You do not have permission to edit content on this site</p>
    <h2><a href="../login.aspx" target="_parent">Please login!</a></h2>
    </div>
    </form>
</body>
</html>
