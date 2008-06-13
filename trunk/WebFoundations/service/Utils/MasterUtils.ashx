<%@ WebHandler Language="C#" Class="MasterUtils" %>

using System;
using System.Web;
using System.Web.SessionState;
using System.Web.Security;

using Jayrock.Json;
using Jayrock.JsonRpc;
using Jayrock.JsonRpc.Web;

[JsonRpcHelp("This is JSON-RPC service for masterpage utilities.")]
public class MasterUtils : JsonRpcHandler, IRequiresSessionState
{
    [JsonRpcMethod("keepLogin")]
    [JsonRpcHelp("Do not log the user out.")]
    public int KeepLogin()
    {
        // Just accessing this page should keep them loged in
        int secTimeout = Session.Timeout;
        secTimeout = (secTimeout * 60) - 100; // Convert from min to sec deduct 90 secs for the time out screen (10 secs to play with)
        return secTimeout;
    }
    
    [JsonRpcMethod("forceLogout")]
    [JsonRpcHelp("Serverside logout.")]
    public bool ForceLogout()
    {
        System.Web.Security.FormsAuthentication.SignOut();
        Session.Abandon();
        return true;
    }
}