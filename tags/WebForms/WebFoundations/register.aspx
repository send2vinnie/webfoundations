<%@ Page 
Title="Register" 
Language="C#" 
AutoEventWireup="true" 
CodeFile="register.aspx.cs" 
Inherits="register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    
    <h1>Registration</h1>
    
    <asp:PlaceHolder ID="phRegistration" runat="server">
    
        <h2>Please fill out the following details to complete your registration.</h2>

        <span class="inputHeader">First name:*</span>
        <asp:TextBox ID="txtFirstName" runat="server" ValidationGroup="valUserDetails" TextMode="SingleLine" />
        <asp:RequiredFieldValidator
            ID="rfvFirstName"
            runat="server"
            ControlToValidate="txtFirstName"
            ValidationGroup="valUserDetails"
            SetFocusOnError="true"
            Text="Please enter your first name"
            Display="Dynamic" />
        
        <span class="inputHeader">Surname:*</span>
        <asp:TextBox ID="txtSurname" runat="server" ValidationGroup="valUserDetails" TextMode="SingleLine" />
        <asp:RequiredFieldValidator
            ID="rfvSurname"
            runat="server"
            ControlToValidate="txtSurname"
            ValidationGroup="valUserDetails"
            SetFocusOnError="true"
            Text="Please enter your surname"
            Display="Dynamic" />
        
        <span class="inputHeader">Email address:*</span>
        <asp:TextBox ID="txtEmailAddress" runat="server" ValidationGroup="valUserDetails" TextMode="SingleLine" />
        <asp:RequiredFieldValidator 
            ID="rfvEmailAddress" 
            runat="server" 
            ControlToValidate="txtEmailAddress"
            ValidationGroup="valUserDetails"
            SetFocusOnError="true"
            Text="Please enter your email address"
            Display="Dynamic" />
        <asp:RegularExpressionValidator
            ID="revEmailAddress"
            runat="server"
            ControlToValidate="txtEmailAddress"
            ValidationGroup="valUserDetails"
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
            SetFocusOnError="true"
            Text="Please enter a valid email address"
            Display="Dynamic" />
        <asp:Label ID="lblEmailExists" runat="server" Text="Email address entered already exists" Visible="false" CssClass="errorMessage" />   
        
        <span class="inputHeader">Password:*</span>
        <asp:TextBox ID="txtPassword" runat="server" ValidationGroup="valUserDetails" TextMode="Password" />
        <asp:RequiredFieldValidator 
            ID="rfvPassword"
            runat="server"
            ControlToValidate="txtPassword"
            ValidationGroup="valUserDetails"
            SetFocusOnError="true"
            Text="Please enter your password"
            Display="Dynamic" />
        <asp:RegularExpressionValidator
            ID="revPassword"
            runat="server"
            ControlToValidate="txtPassword"
            ValidationGroup="valUserDetails"
            ValidationExpression="\b\w{6,}\b"
            SetFocusOnError="true"
            Text="Passwords must be at least 6 characters"
            Display="Dynamic" />
        
        <span class="inputHeader">Confirm password:*</span>
        <asp:TextBox ID="txtConfirmPassword" runat="server" ValidationGroup="valUserDetails" TextMode="Password" />
        <asp:RequiredFieldValidator
            ID="rfvConfirmPassword"
            runat="server"
            ControlToValidate="txtConfirmPassword"
            ValidationGroup="valUserDetails"
            SetFocusOnError="true"
            Text="Please confirm your password"
            Display="Dynamic" />
        <asp:CompareValidator 
            id="cvConfirmPassword" 
            runat="server" 
            ControlToValidate="txtConfirmPassword" 
            ControlToCompare="txtPassword" 
            ValidationGroup="valUserDetails" 
            Text="Your password and confirmed passwords do not match"
            Display="Dynamic" />
        
        <span class="inputHeader">Country:*</span>
        <asp:DropDownList ID="ddlCountry" runat="server" ValidationGroup="valUserDetails" DataTextField="Name" DataValueField="CountryID" />
        <asp:RequiredFieldValidator
            ID="rfvPostalCountry"
            runat="server"
            ControlToValidate="ddlCountry"
            ValidationGroup="valUserDetails"
            InitialValue="0"
            SetFocusOnError="true"
            Text="Please enter your country"
            Display="Dynamic" />
        
        <asp:Button ID="btnRegister" runat="server" ValidationGroup="valUserDetails" Text="Continue" OnClick="btnRegister_Click"  />
    
    </asp:PlaceHolder>
    
    <asp:PLaceholder ID="phRegistrationComplete" runat="server" Visible="false">
    
        <h2>Registration complete, <a href="default.aspx">return to homepage</a>.</h2>
    
    </asp:Placeholder>

</asp:Content>
