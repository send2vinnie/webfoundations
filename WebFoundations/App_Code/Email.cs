using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

/// <summary>
/// Email class
/// </summary>
public static class Email
{
    public static bool SendMail(string msgFrom, string msgTo, string msgSubject, string msgBody, bool highPriority)
    {
        MailMessage mailMsg = new MailMessage();
        SmtpClient smtp = new SmtpClient();
        mailMsg.From = new MailAddress(msgFrom);
        mailMsg.To.Add(msgTo);
        mailMsg.Subject = msgSubject;
        mailMsg.Body = msgBody;
        mailMsg.IsBodyHtml = true;
        if (highPriority) mailMsg.Priority = MailPriority.High;

        try
        {
            smtp.Send(mailMsg);
            return true;
        }
        catch (Exception myEx)
        {
            //General.ErrorDAL myErr = new DABL.General.ErrorDAL();
            //myErr.ErrAddNew("Email.cs", "Error Sending Mail", myEx);
            return false;
        }
    }
}
