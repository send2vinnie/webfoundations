using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

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
}
