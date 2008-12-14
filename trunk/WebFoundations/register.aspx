<%@ Page 
Title="Register" 
Language="C#" 
AutoEventWireup="true" 
CodeFile="register.aspx.cs" 
Inherits="register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server">
        <WizardSteps>
            <asp:CreateUserWizardStep runat="server" />
            <asp:CompleteWizardStep runat="server" />
        </WizardSteps>
    </asp:CreateUserWizard>

</asp:Content>

