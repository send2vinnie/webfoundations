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
using ZetaHtmlTidy;

public partial class CMS_Default : BasePage
{
    // Persist accross postback
    private string _RootDir;

    private int _Instance
    {
        get
        {
            // look for current page in ViewState
            object o = this.ViewState["_Instance"];
            if (o == null)
                return 0;   // default to showing the first page
            else
                return (int)o;
        }

        set
        {
            this.ViewState["_Instance"] = value;
        }
    }

    private string _ScriptName
    {
        get
        {
            // look for current page in ViewState
            object o = this.ViewState["_ScriptName"];
            if (o == null)
                return "";
            else
                return o.ToString();
        }

        set
        {
            this.ViewState["_ScriptName"] = value;
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Convert.ToBoolean(Session["IsAuthenticated"]))
            Server.Transfer("NotAuthorised.aspx");

        _RootDir = HttpContext.Current.Request.ApplicationPath;
        if (_RootDir != "/")
            _RootDir += "/";

        fckEditContent.BasePath = String.Concat(_RootDir, "FCKeditor/");
        fckEditContent.CustomConfigurationsPath = "~/Javascript/fckconfig.js".Replace("~/", _RootDir);
        fckEditContent.EditorAreaCSS = "~/css/edit.css".Replace("~/", _RootDir);
        fckEditContent.StylesXmlPath = "~/cms/fckstyles.xml".Replace("~/", _RootDir);
        fckEditContent.Height = Unit.Pixel(300);
        fckEditContent.ToolbarSet = "Minimal";
        fckEditContent.ForcePasteAsPlainText = true;
        fckEditContent.EnableXHTML = true;
        fckEditContent.FormatOutput = true;

        //lblLastEditor.Text = "~/Javascript/fckconfig.js".Replace("~/", _RootDir);

        if (!IsPostBack)
        {
            _ScriptName = Request.QueryString["SCRIPT_NAME"];

            if (!String.IsNullOrEmpty(Request.QueryString["INSTANCE"]))
                _Instance = Convert.ToInt16(Request.QueryString["INSTANCE"]);

            if (!String.IsNullOrEmpty(_ScriptName))
                fckEditContent.Value = Convert.ToString(CMS.GetCachedContent(_ScriptName, _Instance, true));

        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        phEditArea.Controls.Clear();

        string newText = TidyHTML(fckEditContent.Value);
        //string newText = fckEditContent.Value;

        if (CMS.SetContent(_ScriptName, _Instance, newText))
        {
            lblMsg.Text = newText;
            ClientScript.RegisterStartupScript(this.GetType(), "RefreshParent", "<script language='javascript'>RefreshParent()</script>");
        }
        else
            lblMsg.Text = "Failed to save";
    }

    private string TidyHTML(string html)
    {
        if (!String.IsNullOrEmpty(html))
        {
            using (HtmlTidy tidy = new HtmlTidy())
            {
                try
                {
                    string temp = tidy.CleanHtml(html, HtmlTidyOptions.ConvertToXhtml);
                    return temp.Remove(temp.LastIndexOf("</body>")).Substring(temp.IndexOf("<body>") + 7).Trim();
                }
                catch (Exception)
                {
                    return String.Empty;
                }
            }
        }
        else
        {
            return String.Empty;
        }
    }
}
