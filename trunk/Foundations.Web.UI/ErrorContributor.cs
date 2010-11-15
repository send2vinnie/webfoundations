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
using OpenRasta.Pipeline;
using OpenRasta.Web;
using Elmah;
using Foundations.Web.UI.Resources;
using System.Collections.Generic;

namespace Foundations.Web.UI {
  public class ErrorContributor : IPipelineContributor {


    #region IPipelineContributor Members

    public void Initialize(IPipeline pipelineRunner) {
      pipelineRunner.Notify(RendorErrors).Before<KnownStages.ICodecResponseSelection>();
      //pipelineRunner.Notify(RendorErrors)
      //      .After<KnownStages.IOperationResultInvocation>(); 
    }

    #endregion
    private static PipelineContinuation RendorErrors(ICommunicationContext context) {
      if (context.ServerErrors.Count > 0)
      {
        var serverError = context.ServerErrors[0];
        var message = serverError.Exception.Message ?? serverError.Message;

        ErrorSignal
         .FromCurrentContext()
         .Raise(context.ServerErrors[0].Exception);
        
        //HttpContext.Current.Response.Redirect("/elmah.axd"); // Temp fix for error resource issue above

        //if (context.ServerErrors.Count > 10)//stop infinate loops
        //  return PipelineContinuation.Finished;

        //context.Request.CodecParameters.AddRange(matchingSegments);
        //context.Request.CodecParameters = new List<string>().Add("index");

        context.Response.Entity.Instance = new ErrorResource(serverError);
        context.ServerErrors.Clear();
      }
      return PipelineContinuation.Continue;
    }


  }
}
