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
using System.Security;

public partial class Controls_CMS : System.Web.UI.UserControl
{
    private string _ScriptName;
    private int _Instance;
    private string _RootDir;

    public int Instance
    {
        get { return _Instance; }
        set { _Instance = value; }
    }

    public string ScriptName
    {
        get {
            if (!String.IsNullOrEmpty(_ScriptName))
                return _ScriptName.ToLower();
            else
            {
                _ScriptName = Request.ServerVariables["SCRIPT_NAME"];
                _ScriptName = _ScriptName.Replace(_RootDir, "~/").ToLower();
                return _ScriptName;
            }
        }
        set { _ScriptName = value.ToLower(); }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        _RootDir = HttpContext.Current.Request.ApplicationPath;
        if (_RootDir != "/")
            _RootDir += "/";

        lblContent.Attributes.Add("style","display: block;");
        lblContent.Text = CMS.GetCachedContent(this.ScriptName, this.Instance, false);  //Set to false b4 going live

        if (Convert.ToBoolean(HttpContext.Current.Session["IsAuthenticated"]))  // Authentication - (to do)
        {
            contentArea.Attributes["class"] = "contentArea";
            btnEditContent.Visible = true;
        }
    }

    protected void butEditContent_Click(object sender, EventArgs e)
    {
        HtmlGenericControl editFrame = new HtmlGenericControl("iframe");
        string iframesrc = "~/CMS/Default.aspx".Replace("~/", _RootDir);
        editFrame.Attributes.Add("src", String.Format("{0}?SCRIPT_NAME={1}&INSTANCE={2}", iframesrc, this.ScriptName, this.Instance));
        editFrame.Attributes.Add("height", "400");
        editFrame.Attributes.Add("width", "100%");
        editFrame.Attributes.Add("frameborder", "0");
        editFrame.Attributes.Add("marginwidth", "0px");
        editFrame.Attributes.Add("marginheight", "0px");
        phCMS.Controls.Clear();
        phCMS.Controls.Add(editFrame);
    }
}
