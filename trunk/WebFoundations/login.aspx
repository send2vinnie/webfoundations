<%@ Page 
Language="C#" 
MasterPageFile="~/Theme/skin.master" 
AutoEventWireup="true" 
CodeFile="login.aspx.cs" 
Inherits="_Login" 
Title="Sign-in" 
%>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Sign in</h1>
    <p>
    <label><asp:Label ID="lblLabel" runat="server" Text="Enter password" /><br />
    <asp:TextBox TextMode="Password" runat="server" ID="txtPassword" />
    </label>
    <asp:Button Text="Sign In" runat="server" ID="btnSignIn" OnClick="btnSignIn_Click" />
    </p>
   
</asp:Content>

