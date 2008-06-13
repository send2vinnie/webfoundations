using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Data;
using System.Xml;
using System.Xml.XPath;
using System.Web.Caching;

/// <summary>
///  CMS data recovery
/// </summary>

public static class CMS
{
    public static string GetCachedContent(string scriptName, int instance, bool killCache)
    {
        string contents;
        string cacheName = String.Format("{0}:{1}", scriptName, Convert.ToString(instance));

        try
        {
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
                string db = HttpContext.Current.Server.MapPath("~/App_Data/Content.xml");
                XPathDocument xpd = new XPathDocument(db);
                XPathNavigator xpn = xpd.CreateNavigator();
                XPathNavigator node = xpn.SelectSingleNode(String.Format("/pages/page[@name='{0}' and @instance={1}]", scriptName, instance));
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
        catch(Exception ex)
        {
            contents = ex.Message;
        }


        return contents;
    }

    public static bool SetContent(string scriptName, int instance, string newText)
    { 
        try
        {
            string cacheName = String.Format("{0}:{1}", scriptName, Convert.ToString(instance));
            string filename = HttpContext.Current.Server.MapPath("~/App_Data/Content.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(filename);

            XmlNode contentPage = doc.SelectSingleNode(String.Format("/pages/page[@name='{0}' and @instance={1}]", scriptName, instance));
            if(contentPage != null)//Edit mode
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
