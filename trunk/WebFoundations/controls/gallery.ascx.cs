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
    private string _album = "Example";

    public string Album
    {
        get
        {
            return _album;
        }
        set
        {
            _album = value;
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
        if (Request.QueryString["album"] != null)
        {
            _album = Request.QueryString["album"];
        }

        Page.Title = String.Format("{0} photo galery", _album);

        
        try
        {
            XmlDocument album = new XmlDocument();
            album.PreserveWhitespace = false;
            album.Load(Server.MapPath(string.Format("~/Picasa/{0}/index.xml", _album)));

            xmlGallery.Document = album;
        }
        catch (Exception ex)
        {
            lblMSG.Text = ex.Message;
            lblMSG.ForeColor = System.Drawing.Color.Red;
        }


    }
}
