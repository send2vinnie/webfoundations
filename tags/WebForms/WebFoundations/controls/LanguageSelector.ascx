<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LanguageSelector.ascx.cs" Inherits="controls_LanguageSelector" %>

<asp:DropDownList 
 ID="ddlLanguage" 
 runat="server" 
 AutoPostBack="true" 
 onselectedindexchanged="ddlLanguage_SelectedIndexChanged" />