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

public partial class _Login : System.Web.UI.Page
{
    private string referer;

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["referer"] == null)
        {
            if (!IsPostBack)
            {
                if (Request.UrlReferrer != null)
                {
                    referer = Request.UrlReferrer.ToString();
                    Session["referer"] = referer;
                }
            }
        }
        else
        {
            referer = Session["referer"].ToString();
        }

        if (Convert.ToBoolean(Request.QueryString["kill"]))
        {
            Session["IsAuthenticated"] = false;
            if (referer != null)
                Response.Redirect(referer);

        }


    }
    protected void btnSignIn_Click(object sender, EventArgs e)
    {
        if (ConfigurationManager.AppSettings["SignInPassword"].ToString() == txtPassword.Text)
        {
            Session["IsAuthenticated"] = true;
            if (!String.IsNullOrEmpty(referer))
            {
                Session["referer"] = null;
                Response.Redirect(referer);
            }
            else
            {
                lblLabel.Text = "Signin successfull";
                txtPassword.Visible = false;
                btnSignIn.Visible = false;
            }
        }
        else
        {
            Session["IsAuthenticated"] = false;
            lblLabel.Text = "Invalid password";
        }
    }
}
