using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using System.Xml;
using System.Xml.XPath;

/// <summary>
/// Functions for master page
/// </summary>
public abstract class BaseMaster : System.Web.UI.MasterPage
{
    // Set Master Variables
    private string _RootDir = String.Empty;
    private string _ActivePage;
    private string _JSPageLoad;
    

    protected string _ActiveSection;
    protected string _ActiveTab;
    protected string _PageTitle;
    protected bool _EnableCMS = true;

    // Get references to Master objects
    protected HtmlForm form1;

    public bool EnableCMS
    {
        get
        {
            return _EnableCMS;
        }
        set
        {
            _EnableCMS = value;
        }
    }

    public string PageTitle
    {
        get { return _PageTitle; }
        set { _PageTitle = value; }
    }

	public BaseMaster()
	{
        Init += new EventHandler(BaseMater_Init);

        _RootDir = HttpContext.Current.Request.ApplicationPath;
        if (_RootDir != "/")
            _RootDir += "/";
	}

    protected void BaseMater_Init(object sender, EventArgs e)
    {
    }

    #region "Public Functions"

    #region "Client Javascript Builder"

    public void AddJS(string JSfile)
    {
        Page.Header.Controls.Add(ClientJS(JSfile));
    }

    public void AddJS(string JSfile, int position)
    {
        Page.Header.Controls.AddAt(position, ClientJS(JSfile));
    }

    private HtmlGenericControl ClientJS(string JSfile)
    {
        if (JSfile.Substring(0, 4) != "http")
            JSfile = string.Format("{0}{1}", _RootDir, JSfile);

        HtmlGenericControl hgcJS = new HtmlGenericControl("script");
        hgcJS.Attributes.Add("language", "javascript");
        hgcJS.Attributes.Add("type", "text/javascript");
        hgcJS.Attributes.Add("src", JSfile);

        return hgcJS;
    }

    #endregion

    #region "Client CSS Builder"

    public void AddCSS(string cssFile)
    {
        AddCSS(cssFile, "*");
    }

    public void AddCSS(string cssFile, string media)
    {
        if (cssFile.Substring(0, 4) != "http")
            cssFile = string.Format("{0}{1}", _RootDir, cssFile);

        HtmlGenericControl cssLink = new HtmlGenericControl("style");
        cssLink.Attributes.Add("type", "text/css");
        if (media != "*") cssLink.Attributes.Add("media", media);
        cssLink.InnerHtml = String.Concat("\n<!-- \n", "@import url(\"" + cssFile + "\");", " \n-->\n");
        Page.Header.Controls.Add(cssLink);
    }

    #endregion

    #endregion

    #region "Navigation Builder"
    protected string MainPortalNav(string sitemap)
    {
        XPathDocument xTabs = new XPathDocument(Server.MapPath(sitemap.Replace("~/", _RootDir)));

        string output = String.Empty;

        if (xTabs != null)
        {
            XPathNavigator navTabs = xTabs.CreateNavigator();
            XPathExpression expr = navTabs.Compile("/s:siteMap/s:siteMapNode/s:siteMapNode");
            XmlNamespaceManager mngr = new XmlNamespaceManager(new NameTable());
            mngr.AddNamespace("s", "http://schemas.microsoft.com/AspNet/SiteMap-File-1.0");
            expr.SetContext(mngr);
            XPathNodeIterator tabXIter = navTabs.Select(expr); //"/siteMap/siteMapNode/siteMapNode"

            string url;
            string title;
            string description;
            string LinkClass = "navItemInactive";

            while (tabXIter.MoveNext())
            {
                url = tabXIter.Current.SelectSingleNode("./@url").Value.ToString().Replace("~/", _RootDir);
                title = tabXIter.Current.SelectSingleNode("./@title").Value.ToString();
                description = tabXIter.Current.SelectSingleNode("./@description").Value.ToString();

                if ((_ActivePage == url && _ActiveTab == null) || _ActiveSection == title || _ActiveTab == title)
                {
                    LinkClass = "navItemActive";

                    if (_PageTitle == "")
                        Page.Title = title;
                }

                output += String.Format("<li><a onfocus=\"if(this.blur)this.blur()\" class=\"{0}\" href=\"{1}\" title=\"{3}\" ><span>{2}</span></a></li>", LinkClass, url, title, description);
                LinkClass = "navItemInactive"; //reset li class from active
            }
        }
        return String.Format("<div class=\"nav\"><ul class=\"tabNav\">{0}</ul></div>", output);
    }

    protected string DisplaySiteMapLevelAsBulletedList(SiteMapDataSource smdsNavigation) // This is for the left nav
    {
        //Get the SiteMapDataSourceView from the siteMapData SiteMapDataSource
        SiteMapDataSourceView siteMapView = (SiteMapDataSourceView)smdsNavigation.GetView(String.Empty);
        //Get the SiteMapNodeCollection from the SiteMapDataSourceView
        SiteMapNodeCollection nodes = (SiteMapNodeCollection)siteMapView.Select(DataSourceSelectArguments.Empty);
        ///Recurse through the SiteMapNodeCollection...
        return GetSiteMapLevelAsBulletedList(nodes);
    }

    private string GetSiteMapLevelAsBulletedList(SiteMapNodeCollection nodes)
    {
        string output = String.Empty;
        string LinkClass = "navItemInactive";

        foreach (SiteMapNode node in nodes)
        {
            if ((_ActivePage == node.Url && _ActiveTab == null) || _ActiveSection == node.Title || _ActiveTab == node.Title)
            {
                LinkClass = "navItemActive";

                if (_PageTitle == "")
                    Page.Title = node.Title;
            }

            output += String.Format("<li><a onfocus=\"if(this.blur)this.blur()\" class=\"{0}\" href=\"{1}\" ><span>{2}</span></a></li>", LinkClass, node.Url, node.Title);
            LinkClass = "navItemInactive"; //reset li class from active
        }
        return output;
    }
    #endregion
}
