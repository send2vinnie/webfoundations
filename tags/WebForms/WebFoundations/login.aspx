<%@ Page 
Language="C#" 
AutoEventWireup="true" 
CodeFile="login.aspx.cs" 
Inherits="_Login" 
Title="Sign-in" 
%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Sign in</h1>
    <p>
    <label><asp:Label ID="lblLabel" runat="server"  meta:resourceKey="lblLabel"/><br />
    <asp:TextBox TextMode="Password" runat="server" ID="txtPassword" />
    </label>
    <asp:Button Text="Sign In" runat="server" ID="btnSignIn" OnClick="btnSignIn_Click" />
    </p>
   
</asp:Content>

