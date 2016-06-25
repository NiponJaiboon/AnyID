using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using log4net;

namespace KiatnakinServices
{
    public class SendMailService
    {
        private static HttpClient mailClient;
        private static HttpClient MailClient
        {
            get
            {
                if (mailClient == null)
                {
                    mailClient = new HttpClient();
                    mailClient.BaseAddress = new Uri(@"http://10.192.1.223:61102/EmailWS/SendEmailService.svc/REST/SendEmail");
                }
                return mailClient;
            }
        }

        public async void SendMail(ILog log, string channelID, string from, string to, string templateID, string mail)
        {
            if (!string.IsNullOrEmpty(to))
            {
                //var parameters = "?to=" + to
                //            + "&from=" + from
                //            + "&templateid=" + templateID
                //            + "&channelid=AGW&scheduleType=immediate";
                var parameters = new Dictionary<string, string>();
                parameters.Add("to", to);
                parameters.Add("from", from);
                parameters.Add("templateid", templateID);
                parameters.Add("channelid", "AGW");
                parameters.Add("scheduleType", "immediate");
                parameters.Add("channelid", to);
                var parameterList = new FormUrlEncodedContent(parameters);

                using (var request = new HttpClient())
                {
                    HttpResponseMessage response = null;
                    try
                    {
                        response = await MailClient.PostAsync((string)null, parameterList);  // Blocking call!
                        if (response.StatusCode == HttpStatusCode.OK)
                        {
                            if (log != null) log.Info("Sendmail success:" + response.ToString());
                        }
                        else
                        {
                            if (log != null) log.Error("Sendmail failed:" + response.ToString());
                        }
                    }
                    catch(Exception exc)
                    {
                        if (log != null) log.Fatal("Sendmail error:" + response.ToString(), exc);
                    }
                }
            }
        }
    }
}
