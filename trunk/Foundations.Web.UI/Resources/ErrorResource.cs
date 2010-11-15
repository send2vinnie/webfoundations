using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace Foundations.Web.UI.Resources {
  public class ErrorResource {
    public string Title { get; set; }
    public string Message { get; set; }
    public string Ref { get; set; }
    public Exception Exception { get; set; }

    public ErrorResource() {

    }

    public ErrorResource(OpenRasta.Error error) {
      Title = error.Title;
      Message = error.Message;
      Exception = error.Exception;

      if (Exception != null)
      {
        Message = Exception.Message;
        if (Exception.InnerException != null)
        {
          Message = Exception.InnerException.Message;
          Exception = Exception.InnerException;
        }
      }

    }

  }
}
