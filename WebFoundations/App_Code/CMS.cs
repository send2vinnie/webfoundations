using System;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data;
using System.Xml;
using System.Xml.XPath;
using System.Web.Caching;
using System.Globalization;


/// <summary>
///  CMS data recovery
/// </summary>

public static class CMS
{
    public static string GetCachedContent(string scriptName, int instance, bool killCache, string language)
    {
        string contents;
        string cacheName = String.Format("{0}:{1}:{2}", scriptName, Convert.ToString(instance), language);

        try
        {
            HttpContext.Current.Cache.Remove(cacheName);
            if (killCache)
            {
                HttpContext.Current.Cache.Remove(cacheName);
            }

            if (HttpContext.Current.Cache[cacheName] != null)
            {
                contents = Convert.ToString(HttpContext.Current.Cache[cacheName]);
            }
            else
            {


                string currentCulture =string.Empty;
                if (System.Web.HttpContext.Current.Session["Language"] == null)
                    currentCulture = LanguageCodeGet(Convert.ToString(System.Web.HttpContext.Current.Request.UserLanguages[0]));
                else
                    currentCulture = Convert.ToString(System.Web.HttpContext.Current.Session["Language"]);
                if (!LanguageExits(currentCulture.ToString()))
                {
                    language = System.Configuration.ConfigurationManager.AppSettings["DefaultLanguage"];
                }
                if (string.IsNullOrEmpty(language))
                    language = currentCulture.ToString();

                string db = HttpContext.Current.Server.MapPath("~/App_Data/Content.xml");
                XPathDocument xpd = new XPathDocument(db);
                XPathNavigator xpn = xpd.CreateNavigator();
                XPathNavigator node = xpn.SelectSingleNode(String.Format("/pages/page[@name='{0}' and @instance={1} and @language='{2}']", scriptName, instance, language));
                if (node != null)
                {
                    contents = Convert.ToString(node.TypedValue); // node.InnerXml;
                    HttpContext.Current.Cache.Insert(cacheName, contents, null, DateTime.Now.AddDays(1), Cache.NoSlidingExpiration);
                }
                else
                {
                    contents = String.Empty;
                }
            }
        }
        catch (Exception ex)
        {
            contents = ex.Message;
        }


        return contents;
    }
    public static bool LanguageExits(string langaugeValue)
    {
        bool exists = false;
        XPathDocument xpd = new XPathDocument(HttpContext.Current.Server.MapPath("~/App_Data/Languages.xml"));
        XPathNavigator xpn = xpd.CreateNavigator();
        XPathNavigator xmlNode = xpn.SelectSingleNode(string.Format("languages/language[@value='{0}']", langaugeValue));
        if (xmlNode != null)
            exists = true;
        return exists;
    }
    public static string LanguageCodeGet(string language)
    {
        return language.Substring(0, 2);
    }

    public static bool SetContent(string scriptName, int instance, string newText, string language)
    {
        try
        {
            string cacheName = String.Format("{0}:{1}:{2}", scriptName, Convert.ToString(instance), language);
            string filename = filename = HttpContext.Current.Server.MapPath("~/App_Data/Content.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);
            // setting default langauge
            if (string.IsNullOrEmpty(language))
                language = "en-GB";
            XmlNode contentPage = doc.SelectSingleNode(String.Format("/pages/page[@name='{0}' and @instance={1} and @language='{2}']", scriptName, instance, language));
            if (contentPage != null)//Edit mode
            {
                contentPage.InnerXml = String.Format("<![CDATA[{0}]]>", newText);
            }
            else //new page
            {
                XmlNode newPage = doc.CreateNode(XmlNodeType.Element, "page", "");
                XmlNode attName = doc.CreateAttribute("name");
                attName.Value = scriptName;
                XmlNode attInstance = doc.CreateAttribute("instance");
                attInstance.Value = instance.ToString();
                newPage.InnerXml = String.Format("<![CDATA[{0}]]>", newText);
                newPage.Attributes.SetNamedItem(attName);
                newPage.Attributes.SetNamedItem(attInstance);
                doc.DocumentElement.AppendChild(newPage);
            }
            doc.Save(filename);
            HttpContext.Current.Cache.Remove(cacheName);
            return true;
        }
        catch (Exception ex)
        {
            HttpContext.Current.Response.Write(ex.Message);
            return false;
        }
    }

    




}
