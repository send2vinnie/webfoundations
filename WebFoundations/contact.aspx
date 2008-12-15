<%@ Page 
Language="C#" 
AutoEventWireup="true" 
CodeFile="contact.aspx.cs" 
Inherits="contact" 
Title="Contact us" %>
<%@ Register Src="Controls/CMS.ascx" TagName="CMS" TagPrefix="cms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TopContent" Runat="Server">
    <cms:CMS ID="CMS1" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <cms:CMS id="cmsEmailSuccess" runat="server" instance="2" Visible="false" />

    <asp:Label runat="server" ID="lblMSG" BackColor="lightYellow" />
    
    <asp:PlaceHolder runat="server" ID="phBooking" Visible="false">
        <cms:CMS id="cmsBooking" runat="server" instance="10" Visible="true" />
        <fieldset><legend>Booking</legend>
            <label for="cottage">Number of people: <br />
                <input runat="server" name="people" type="text" id="people" size="30" />
            </label>
            <br />
            <label for="startdate">Booking date: <br />
                <input runat="server" name="bookingDate" type="text" id="bookingDate" size="30" />
            </label>
            <br />
            <label for="enddate">Booking time: <br />
                <input runat="server" name="bookingTime" type="text" id="bookingTime" size="30" />
            </label>
        </fieldset>
        <br />
    </asp:PlaceHolder>
    
    <fieldset><legend> <asp:Literal ID="litContactDetails" runat="server" meta:resourceKey="litContactDetails"/></legend>
    
	<label for="email"><asp:Literal ID="litEmail" runat="server" meta:resourceKey="litEmail"/>:<br />
    <input runat="server" name="email" type="text" id="email" size="30" />
        <asp:RequiredFieldValidator 
        ID="RequiredFieldValidator1" 
        runat="server" 
        ControlToValidate="email"
        ErrorMessage="Please enter your email address" 
        Display="Dynamic" 
        ValidationGroup="Contact"
        />
    </label><br />

    <label for="name"><asp:Literal ID="litYourName" runat="server" meta:resourceKey="litYourName"/>: <br />
    <input runat="server" name="name" type="text" id="name" size="30" />
        <asp:RequiredFieldValidator 
        ID="RequiredFieldValidator2" 
        runat="server" 
        ControlToValidate="name"
        ErrorMessage="Please enter your name" 
        Display="Dynamic"
        ValidationGroup="Contact"
        />
    </label><br />

    <label for="telephone"><asp:Literal ID="litTelephone" runat="server" meta:resourceKey="litTelephone"/>: <br />
    <input runat="server" name="telephone" type="text" id="telephone" size="30" />
	
	</label><br />

    <asp:Literal ID="litMessage" runat="server" meta:resourceKey="litMessage"/> <br />
    <textarea runat="server" name="body" cols="40" rows="5" id="body" ></textarea>
	
    <asp:RequiredFieldValidator 
    ID="RequiredFieldValidator3" 
    runat="server" 
    ControlToValidate="body"
    ErrorMessage="Please enter a message" 
    Display="Dynamic"
    ValidationGroup="Contact"
    />

  </fieldset>
  
  <p>
    <input runat="server" type="submit" name="Submit"  id="Submit" onserverclick="Submit_ServerClick" meta:resourceKey="Submit"/>
    <asp:HiddenField runat="server" ID="hdnPrevious" />

  </p>
  
  <cms:CMS id="cmsEmailFooter" runat="server" instance="1" />

</asp:Content>

