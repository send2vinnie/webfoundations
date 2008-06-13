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

public partial class contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(Request.UrlReferrer != null)
                hdnPrevious.Value = Request.UrlReferrer.ToString();
        }
        if(Request.QueryString["b"] != null)
        {
            phBooking.Visible = true;
        }
    }
    protected void Submit_ServerClick(object sender, EventArgs e)
    {
        string msg_body = body.Value;

        if (msg_body != null)
        {

            string from_email = email.Value;
            string from_name = name.Value;
            string from_tel = telephone.Value;
            string previous = hdnPrevious.Value.ToString();
            string msg = String.Format("<p><strong>Email from:</strong> {0} ({1})<br /><br /><strong>Message:</strong><p>{2}</p><strong>Tel:</strong> {3}<br /><strong>Previous page:</strong> {4}</p>", from_name, from_email, msg_body, from_tel, previous);

            if (people.Value.Length > 0)
            {
                msg += String.Format("<p><strong>Number of people:</strong> {0}<br /><strong>Booking Date:</strong> {1}<br /><strong>Booking Time:</strong> {2}</p>", people.Value, bookingDate.Value, bookingTime.Value);
            }

            if (Email.SendMail(from_email, ConfigurationManager.AppSettings["EmailAddress"].ToString(), ConfigurationManager.AppSettings["EmailSubject"].ToString(), msg, true))
            {
                Response.Redirect("thanks.aspx");
            }
            else
            {
                lblMSG.Text = "Failed to send email!";
            }
        }
        else
        {
            lblMSG.Text = "Please add a message!";
        }
    }
}
