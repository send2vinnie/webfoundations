using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class controls_LanguageSelector : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDDLLanguage();
            // keep selected language on !postback 
            if (Session["Language"] != null)
              ddlLanguage.SelectedValue = Convert.ToString(Session["Language"]);
        }

        if (Request.QueryString["lang"] != null)
        {
            BindDDLLanguage();
            ddlLanguage.SelectedValue = Convert.ToString(Request.QueryString["lang"]);
            Session["Language"] = ddlLanguage.SelectedValue;
            Response.Redirect(Context.Request.Path);

        }
        if (Session["Language"] == null)
        {
            string userLanguage = CMS.LanguageCodeGet(System.Web.HttpContext.Current.Request.UserLanguages[0]);
           bool exists=CMS.LanguageExits(userLanguage);
           if (!exists)
               ddlLanguage.SelectedValue = System.Configuration.ConfigurationManager.AppSettings["DefaultLanguage"].ToString();
           else
               ddlLanguage.SelectedValue = userLanguage;

           Session["Language"] = ddlLanguage.SelectedValue;
        }

        
    }

    protected void BindDDLLanguage()
    {
        XmlDataSource xmlLanguages = new XmlDataSource();
        xmlLanguages.DataFile = HttpContext.Current.Server.MapPath("~/App_Data/Languages.xml");
        ddlLanguage.DataTextField = "name";
        ddlLanguage.DataValueField = "value";
        ddlLanguage.DataSource = xmlLanguages;
        ddlLanguage.DataBind();
       
       
    }
    protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session.Add("Language", ddlLanguage.SelectedValue);
        // redirect to initialize the cuslture thread on BasePage.cs
        Response.Redirect(Context.Request.Path);
    }
}
