using AnyIDModel;
using iSabaya;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Web.Script.Serialization;

namespace KiatnakinServices
{
    public class EmailService
    {
        public bool SendEmailRegister(string to, string customerName, ProxyTransaction transaction, out string errorCode, out string description, out string contentResult)
        {
            //string domain = WebConfigurationManager.AppSettings["EmailDomain"].ToString();
            //string port = WebConfigurationManager.AppSettings["EmailPort"].ToString();
            string url = WebConfigurationManager.AppSettings["EmailURL"].ToString();
            string fromSender = WebConfigurationManager.AppSettings["EmailSender"].ToString();
            string toReceiver = WebConfigurationManager.AppSettings["EmailTo"].ToString();

            //string url = "http://" + domain + ":" + port + "/EmailWS/SendEmailService.svc/SendEmail";
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AlwaysMultipartFormData = true;

            request.AddParameter("to", (string.IsNullOrEmpty(toReceiver) ? to : toReceiver));
            request.AddParameter("from", fromSender);
            request.AddParameter("template_id", "anyid_createRegistration.xml");
            // name|option1|option2
            // <option1> transaction date ที่ Register สำเร็จ โดยแสดงเป็นวันที่เต็ม พ.ศ. เช่น 17 พฤษภาคม พ.ศ. 2559");
            // <option2> [หมายเลขประจำตัวประชาชน] / [หมายเลขโทรศัพท์เคลื่อนที่]

            UserAction userAction = transaction.CurrentState.CreateAction;
            request.AddParameter("template_parameter", string.Format("{0}|{1}|{2}",
                customerName,
                (string.Format("{0} {1} {2}", userAction.Timestamp.Day, this.Convert2MonthTextThai(userAction.Timestamp.Month), this.Convert2YearBEText(userAction.Timestamp.Year))),
                (transaction.AccountProxy.AnyID.IDType == AnyIDType.MSISDN ? "หมายเลขโทรศัพท์เคลื่อนที่" : "หมายเลขประจำตัวประชาชน")
            ));
            request.AddParameter("channel_id", "AGW");

            IRestResponse response = client.Execute(request); // execute the request
            string content = response.Content; // raw content as string
            contentResult = content;

            // Response 
            // { "RefID":"15155","ResponseStatus":{ "Description":"","ErrorCode":"","Status":"Success"} }
            // {"RefID":null,"ResponseStatus":{"Description":"(From) Email is not available.","ErrorCode":"ERR-065","Status":"Failed"}}
            if (string.IsNullOrEmpty(content))
            {
                description = "Send email failed." + "Url:" + url + ";TransactionID:" + transaction;
                errorCode = "ISAY-EEMail-001";
                return false;
            }
            else
            {
                try
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    Dictionary<string, object> result = serializer.Deserialize<Dictionary<string, object>>(content);
                    Dictionary<string, object> responseStatus = (Dictionary<string, object>)result["ResponseStatus"];

                    description = responseStatus["Description"].ToString();
                    errorCode = responseStatus["ErrorCode"].ToString();
                    return (responseStatus["Status"].ToString() == "Success");
                }
                catch (Exception ex)
                {
                    description = ex.ToString();
                    errorCode = "ISAY-EEMail-002";
                    return false;
                }
            }
        }

        public bool SendEmailAmend(string to, string customerName, ProxyTransaction transaction, out string errorCode, out string description, out string contentResult)
        {
            string url = WebConfigurationManager.AppSettings["EmailURL"].ToString();
            string fromSender = WebConfigurationManager.AppSettings["EmailSender"].ToString();
            string toReceiver = WebConfigurationManager.AppSettings["EmailTo"].ToString();

            string parameter = "";
            AmendTransaction amendTransaction = (AmendTransaction)transaction;
            if (amendTransaction.OldAccountProxy.BankAccount.AccountNo != amendTransaction.AccountProxy.BankAccount.AccountNo)
            {
                parameter = "หมายเลขบัญชีเงินฝาก";
            }
            else
            {
                if (amendTransaction.AccountProxy.AnyID.IDType == AnyIDType.MSISDN)
                    parameter = "เป็นผูกหมายเลขโทรศัพท์เคลื่อนที่ของท่านกับบัญชีเงินฝาก";
                else
                    parameter = "เป็นผูกหมายเลขประจำตัวประชาชนของท่านกับบัญชีเงินฝาก";
            }


            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AlwaysMultipartFormData = true;

            request.AddParameter("to", (string.IsNullOrEmpty(toReceiver) ? to : toReceiver));
            request.AddParameter("from", fromSender);
            request.AddParameter("template_id", "anyid_amendRegistration.xml");
            // name|option1
            // "หมายเลขบัญชีเงินฝาก"  เมื่อเป็นการแก้ไข หมายเลขบัญชีเงินฝาก
            // "เป็นผูกหมายเลขประจำตัวประชาชนของท่านกับบัญชีเงินฝาก" เมื่อเป็นการแก้ไข AnyID ด้วย บัตรประชาชน (NATID)
            // "เป็นผูกหมายเลขโทรศัพท์เคลื่อนที่ของท่านกับบัญชีเงินฝาก" เมื่อเป็นการแก้ไข AnyID ด้วย เบอร์โทรศัพท์(MSISDN)
            request.AddParameter("template_parameter", string.Format("{0}|{1}", customerName, parameter));
            request.AddParameter("channel_id", "AGW");

            IRestResponse response = client.Execute(request); // execute the request
            string content = response.Content; // raw content as string
            contentResult = content;

            if (string.IsNullOrEmpty(content))
            {
                description = "Send email failed." + "Url:" + url + ";TransactionID:" + transaction;
                errorCode = "ISAY-EEMail-001";
                return false;
            }
            else
            {
                try
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    Dictionary<string, object> result = serializer.Deserialize<Dictionary<string, object>>(content);
                    Dictionary<string, object> responseStatus = (Dictionary<string, object>)result["ResponseStatus"];

                    description = responseStatus["Description"].ToString();
                    errorCode = responseStatus["ErrorCode"].ToString();
                    return (responseStatus["Status"].ToString() == "Success");
                }
                catch (Exception ex)
                {
                    description = ex.ToString();
                    errorCode = "ISAY-EEMail-002";
                    return false;
                }
            }
        }

        public bool SendEmailDeactivate(string to, string customerName, ProxyTransaction transaction, out string errorCode, out string description, out string contentResult)
        {
            string url = WebConfigurationManager.AppSettings["EmailURL"].ToString();
            string fromSender = WebConfigurationManager.AppSettings["EmailSender"].ToString();
            string toReceiver = WebConfigurationManager.AppSettings["EmailTo"].ToString();

            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AlwaysMultipartFormData = true;

            request.AddParameter("to", (string.IsNullOrEmpty(toReceiver) ? to : toReceiver));
            request.AddParameter("from", fromSender);
            request.AddParameter("template_id", "anyid_deactivateRegistration.xml");
            // name|option1
            // <option1> transaction date ที่ Register สำเร็จ โดยแสดงเป็นวันที่เต็ม พ.ศ. เช่น 17 พฤษภาคม พ.ศ. 2559");
            UserAction userAction = transaction.CurrentState.CreateAction;
            request.AddParameter("template_parameter", string.Format("{0}|{1}",
               customerName,
               (string.Format("{0} {1} {2}", userAction.Timestamp.Day, this.Convert2MonthTextThai(userAction.Timestamp.Month), this.Convert2YearBEText(userAction.Timestamp.Year)))
            ));
            request.AddParameter("channel_id", "AGW");

            IRestResponse response = client.Execute(request); // execute the request
            string content = response.Content; // raw content as string
            contentResult = content;

            if (string.IsNullOrEmpty(content))
            {
                description = "Send email failed." + "Url:" + url + ";TransactionID:" + transaction;
                errorCode = "ISAY-EEMail-001";
                return false;
            }
            else
            {
                try
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    Dictionary<string, object> result = serializer.Deserialize<Dictionary<string, object>>(content);
                    Dictionary<string, object> responseStatus = (Dictionary<string, object>)result["ResponseStatus"];

                    description = responseStatus["Description"].ToString();
                    errorCode = responseStatus["ErrorCode"].ToString();
                    return (responseStatus["Status"].ToString() == "Success");
                }
                catch (Exception ex)
                {
                    description = ex.ToString();
                    errorCode = "ISAY-EEMail-002";
                    return false;
                }
            }
        }





        private string Convert2MonthTextThai(int month)
        {
            switch (month)
            {
                case 1:
                    return "มกราคม";
                case 2:
                    return "กุมภาพันธ์";
                case 3:
                    return "มีนาคม";
                case 4:
                    return "เมษายน";
                case 5:
                    return "พฤษภาคม";
                case 6:
                    return "มิถุนายน";
                case 7:
                    return "กรกฎาคม";
                case 8:
                    return "สิงหาคม";
                case 9:
                    return "กันยายน";
                case 10:
                    return "ตุลาคม";
                case 11:
                    return "พฤศจิกายน";
                case 12:
                    return "ธันวาคม";
                default:
                    return "";
            }
        }

        private string Convert2YearBEText(int yearAD)
        {
            return "พ.ศ. " + (yearAD + 543).ToString();
        }
    }
}
