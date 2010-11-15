<%@ Page 
Title="Sign in" 
Language="C#" 
AutoEventWireup="true" 
CodeFile="signin.aspx.cs" 
Inherits="signin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Login 
    ID="Login1" 
    runat="server" 
    DestinationPageUrl="~/default.aspx" 
    DisplayRememberMe="False" 
    VisibleWhenLoggedIn="False">
    </asp:Login>
    
    <asp:LoginName ID="LoginName1" runat="server" />
    
    <br />
    
    <asp:LoginStatus ID="LoginStatus1" runat="server" />
    <br />
    
    <asp:LoginView ID="LoginView1" runat="server">
        <LoggedInTemplate>
            <asp:ChangePassword ID="ChangePassword1" runat="server" />
        </LoggedInTemplate>
    </asp:LoginView>
    
</asp:Content>

