using System;
using System.Web;
using System.Globalization;
using System.Xml;
using System.Xml.XPath;
/// <summary>
/// Summary description for Language
/// </summary>
public class Language
{
    private static string _LanguageCode;
    private static int _CountryID; 
   
    /// <summary>Get or set language code</summary>
    /// <param name="langaugeValue">languageValue must be only the first two characters e.g. en</param>
    /// <returns>Language code</returns>
    public static string LanguageCode
    {
        get
        {
            string userLanguage = Convert.ToString(System.Web.HttpContext.Current.Session["Language"]);
            if (String.IsNullOrEmpty(userLanguage))
            {
                userLanguage = System.Web.HttpContext.Current.Request.UserLanguages[0].Substring(0, 2); // when loading first time get user language  preference
                if (!LanguageExits(userLanguage))// if user prefer language doesnot exist select the default language
                    userLanguage = System.Configuration.ConfigurationManager.AppSettings["DefaultLanguage"].ToString();
            }
            return userLanguage;
        }
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

    /// <summary>Get country ID from language code</summary>
    public static int CountryID
    {
        get
        {
            //CompareInfo ci = new CultureInfo("fr-FR").CompareInfo;
            //Console.WriteLine("The LCID for {0} is {1}.", ci.Name, ci.LCID);

            if (LanguageCode == "fr")
                _CountryID = 1036;
            else if (LanguageCode == "en")
                _CountryID = 225;
            return _CountryID;
        }
    }

}
