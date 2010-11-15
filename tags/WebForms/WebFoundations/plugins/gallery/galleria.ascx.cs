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
using System.Xml;

public partial class Controls_gallery : System.Web.UI.UserControl
{
    private string _picasaXML;

    public string PicasaFeed
    {
        get
        {
            return _picasaXML;
        }
        set
        {
            _picasaXML = value;
        }
    }

    public bool LoadLibrarys
    {
        set
        {
            phLibrarys.Visible = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!String.IsNullOrEmpty(_picasaXML)){
        try
        {
            XmlDocument album = new XmlDocument();
            album.PreserveWhitespace = false;
            album.Load(Server.MapPath(_picasaXML));

            System.Xml.Xsl.XsltArgumentList xargs = new System.Xml.Xsl.XsltArgumentList();
            string absPath = Page.ResolveClientUrl(_picasaXML.ToLower().Replace("/index.xml", ""));
            xargs.AddParam("path", "", absPath);
            xmlGallery.TransformArgumentList = xargs;
            xmlGallery.Document = album;
            xmlGallery.TransformSource = "galleria.xsl";
        }
        catch (Exception ex)
        {
            lblMSG.Text = ex.Message;
            lblMSG.ForeColor = System.Drawing.Color.Red;
        }
        }else{
            lblMSG.Text = "Property 'PicasaFeed' is empty";
            lblMSG.ForeColor = System.Drawing.Color.Red;
        }

    }
}
