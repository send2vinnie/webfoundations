<%@ Control 
Language="C#" 
AutoEventWireup="true" 
CodeFile="signin.ascx.cs" 
Inherits="controls_signin" %>

<h1>Sign in to your account</h1>

<h2>Please enter the email address an password that you used when you registered.</h2>

<span class="inputHeader">Email address:*</span>
<asp:TextBox ID="txtEmail" runat="server" ValidationGroup="valSignIn" TextMode="SingleLine" />
<asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ValidationGroup="valSignIn" Text="Please enter your email address" Display="Dynamic" />
<asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" ValidationGroup="valSignIn" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Text="Invalid email address entered" Display="Dynamic" />

<span class="inputHeader">Password*</span>
<asp:TextBox ID="txtPassword" runat="server" ValidationGroup="valSignIn" TextMode="Password" />
<asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword" ValidationGroup="valSignIn" Text="Please enter your password" Display="Dynamic" />

<asp:Label ID="lblMessage" runat="server" CssClass="errorMessage" />
<asp:Button ID="btnSignIn" runat="server" ValidationGroup="valSignIn" Text="Continue" OnClick="btnSignIn_Click" />