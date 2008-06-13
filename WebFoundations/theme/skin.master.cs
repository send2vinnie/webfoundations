using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class skin : BaseMaster
{
    

    protected void Page_Init(object sender, EventArgs e)
    {
       
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        cmsDefault.Visible = base._EnableCMS;

        if (Convert.ToBoolean(Session["IsAuthenticated"]))
        {
            lnkSignin.Text = "Logout";
            lnkSignin.NavigateUrl = "~/login.aspx?kill=true";
        }
        else
        {
            lnkSignin.Text = "Login";
            lnkSignin.NavigateUrl = "~/login.aspx";
        }

        #region "Setup navigation"
        //Create the Left Nav bulleted list
        bulletedLeftNav.Text = string.Format("<div class=\"nav\"><ul class=\"mainNav\">{0}</ul></div>", DisplaySiteMapLevelAsBulletedList(smNav));

        #endregion

    }

    public string navClass(string linkPage)
    {
        if (Request.RawUrl.ToLower().Trim() == linkPage.Trim())
            return "nav-active";
        else
            return "nav-inactive";
    }
}
