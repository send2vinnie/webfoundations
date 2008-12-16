using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using System.Xml.XPath;
/// <summary>
/// Summary description for Language
/// </summary>
public class Language
{
   
    /// <summary>
    /// varify that language exists in  XML file or not
    /// </summary>
    /// <param name="langaugeValue">langaugeValue must consisit only first two character e.g en </param>
    /// <returns></returns>
    /// 

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
    /// <summary>
    /// Gets the culture from lamguage code
    /// </summary>
    /// <param name="language"></param>
    /// <returns>returns string as culture</returns>
    public static string LanguageCodeGet(string language)
    {
        return language.Substring(0, 2);
    }

}
