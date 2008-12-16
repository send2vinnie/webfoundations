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
            // binding dropdownlist for language selector
            BindDDLLanguage();
            // keep selected language on !postback 
            if (Session["Language"] != null)
                ddlLanguage.SelectedValue = Convert.ToString(Session["Language"]);
        }

        // using query string to select default language
        if (Request.QueryString["lang"] != null)
        {
            BindDDLLanguage();
            ddlLanguage.SelectedValue = Convert.ToString(Request.QueryString["lang"]);
            Session["Language"] = ddlLanguage.SelectedValue;
            // redirect is necessary in order to  run InitializeCulture in BasePage.cs
            Response.Redirect(Context.Request.Path);

        }
        if (Session["Language"] == null)
        {
            // when loading first time get user language  preference
            string userLanguage = Language.LanguageCodeGet(System.Web.HttpContext.Current.Request.UserLanguages[0]);
            // if user prefer language doesnot exist select the default language
            bool exists = Language.LanguageExits(userLanguage);
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
        Response.Redirect(Context.Request.Url.ToString());
    }
}
