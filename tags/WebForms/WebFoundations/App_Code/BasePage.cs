using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Threading;
using System.Globalization;

/// <summary>
/// Summary description for BasePage
/// </summary>
public class BasePage : System.Web.UI.Page
{
    public BasePage()
    {
        Init += new EventHandler(BasePage_Init);
        PreInit += new EventHandler(BasePage_PreInit);
    }

    protected void BasePage_PreInit(object sender, EventArgs e)
    {
    }

    protected void BasePage_Init(object sender, EventArgs e)
    {
    }
    protected override void InitializeCulture()
    {
        if (Session["Language"] != null)
        {
            string lang = Session["Language"].ToString();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(lang);
        }
        base.InitializeCulture();
        
    }
}
