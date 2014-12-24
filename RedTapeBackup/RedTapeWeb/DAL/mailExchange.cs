using System;
using System.Collections.Generic;
using System.Web;
using System.Net.Mail;


/// <summary>
/// Summary description for mailExchange
/// </summary>
public class mailExchange
{
    public mailExchange()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string sendMyMail(string sFromWho, string sToWho, string sSubject, string sEmailBody, string sBcc, string sCC)
    {
        SmtpClient client = new SmtpClient("smtp.net4india.com");

        MailMessage message = new MailMessage("Sales Redtape<sales@redtape.com>", sToWho);

        message.Body = sEmailBody;

        if (sBcc != "")
        {
            message.Bcc.Add(sBcc);
        }
        //message.Bcc.Add("himanshu@istrat.in");

        message.Subject = sSubject;

        message.IsBodyHtml = true;

        client.UseDefaultCredentials = true;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.Credentials = new System.Net.NetworkCredential("sales@redtape.com", "sales");

        try
        {
            client.Send(message);
        }

        catch (Exception ex)
        {
            throw ex;
        }
        return "";
    }

    public string sendMyMail1(string sFromWho, string sToWho, string sSubject, string sEmailBody, string sBcc, string sCC)
    {
        SmtpClient client = new SmtpClient("redtapemail.redtapeindia.com");

        //MailMessage message = new MailMessage("Redtape <orders@redtapeindia.com>", "himanshu4ranjan@gmail.com");

        MailMessage message = new MailMessage(sFromWho, sToWho);

        message.Body = sEmailBody;

        message.Bcc.Add(sBcc);

        message.Subject = sSubject;

        message.IsBodyHtml = true;

        client.UseDefaultCredentials = true;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.Port = 25;
        client.Credentials = new System.Net.NetworkCredential("orders", "order");

        try
        {
            client.Send(message);
        }

        catch (Exception ex)
        {
            throw ex;
        }
        return "";
    }

    // for call log

    public string sendMyMailCallLog(string sFromWho, string sToWho, string sSubject, string sEmailBody, string sBcc, string sCC)
    {
        SmtpClient client = new SmtpClient("smtp.net4india.com");

        MailMessage message = new MailMessage("Customer Care Redtape<sales@redtape.com>", sToWho);

        message.ReplyTo = new MailAddress("Customer Care Redtape<customercare@redtapeindia.com>");

        message.Body = sEmailBody;

        if (sBcc != "")
        {
            message.Bcc.Add(sBcc);
        }
        //message.Bcc.Add("himanshu@istrat.in");

        message.Subject = sSubject;

        message.IsBodyHtml = true;

        client.UseDefaultCredentials = true;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.Credentials = new System.Net.NetworkCredential("sales@redtape.com", "sales");

        try
        {
            client.Send(message);
        }

        catch (Exception ex)
        {
            throw ex;
        }
        return "";
    }


}
