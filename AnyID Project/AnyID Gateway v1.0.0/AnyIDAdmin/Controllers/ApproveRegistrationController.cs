using AnyIDAdmin.Models;
using AnyIDModel;
using iSabaya;
using KiatnakinServices;
using NHibernate;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace AnyIDAdmin.Controllers
{
    [SessionTimeoutFilter]
    public class ApproveRegistrationController : BaseController
    {
        private Dictionary<string, string> sessionParam { get; set; }

        // GET: ApproveRegistration
        public ActionResult Index()
        {
            if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 2 })) { ViewData["InsufficientPrivilege"] = true; }
            else
            {
                try
                {
                    if (Request["k"] == null) { throw new Exception("Parameter is null."); }
                    else
                    {
                        string referance = "SC06-" + CommonUtilities.Decrypt(CommonUtilities.ResotrePlusAndSpaceSymolFromBase64(Request["k"].ToString()));
                        if (Session[referance] == null) { throw new Exception("Customer parameter is null."); }
                        else
                        {
                            this.sessionParam = (Dictionary<string, string>)Session[referance];
                            ProxyTransaction transactions;
                            IList<TransactionDocument> documents;
                            GetQueryTransaction(long.Parse(this.sessionParam["TransactionID"]), out transactions, out documents);
                            transactions = CommonUtilities.GetActualTypeOfTransaction(SessionContext, transactions.ID);

                            ViewData["Cust_Data"] = this.BaseGetCustomerInfomation_Data(this.sessionParam["CISID"]);
                            ViewData["Transaction_Data"] = transactions;
                            ViewData["AccountProxy_Data"] = transactions.AccountProxy;
                            ViewData["File_Data"] = documents;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ViewData["ExceptionOnLoad"] = ex.ToString();
                }
            }

            return View();
        }



        [HttpPost]
        public JsonResult ApproverEvent(string reference, string approverChoice, string reason)
        {
            ProxyTransaction trans = null;
            try
            {
                #region Validate

                if (!IsSessionAlive() || !IsCanAccess(Session[ViewConstant.Role], new int[] { 2 }))
                    return Json(new { responseCode = "500", responseText = "Session Expire.", html = Url.Content("~/Login") }, JsonRequestBehavior.AllowGet);

                if (!string.IsNullOrEmpty(approverChoice))
                {
                    if (approverChoice == "0" || approverChoice == "1")
                    {
                        if (approverChoice == "0" && string.IsNullOrEmpty(reason))
                        {
                            return Json(new { responseCode = "100", responseText = "Reject without reason." }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json(new { responseCode = "101", responseText = "Approver event incorrect value." }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { responseCode = "102", responseText = "Approver event in null." }, JsonRequestBehavior.AllowGet);
                }

                #endregion Validate

                bool isSendEmail = false;
                long transID = long.Parse(reference);
                if (trans == null)
                    trans = SessionContext.PersistenceSession.QueryOver<RegisterTransaction>().Where(x => x.ID == transID).SingleOrDefault();
                if (trans == null)
                    trans = SessionContext.PersistenceSession.QueryOver<DeactivateTransaction>().Where(x => x.ID == transID).SingleOrDefault();
                if (trans == null)
                    trans = SessionContext.PersistenceSession.QueryOver<AmendTransaction>().Where(x => x.ID == transID).SingleOrDefault();
                SessionContext.PersistenceSession.Refresh(trans);

                #region Transit Transaction
                string textResponse = "";
                using (ITransaction tx = SessionContext.PersistenceSession.BeginTransaction())
                {
                    try
                    {
                        if (approverChoice == "1") // Approved
                        {
                            trans.Transit(SessionContext, "", reason, ProxyTransactionTransitionEvent.Approve);
                            isSendEmail = true && trans.CurrentStateCategory == ProxyTransactionStateCategory.Success;

                            if (trans.CurrentStateCategory == ProxyTransactionStateCategory.Success)
                                textResponse = "ทำรายการสำเร็จ";
                            else
                                textResponse = "ทำรายการไม่สำเร็จ เพราะ " + trans.CurrentState.Remark;
                        }
                        else // Rejected
                        {
                            trans.Transit(SessionContext, "", reason, ProxyTransactionTransitionEvent.Reject);
                        }

                        trans.Persist(SessionContext);
                        tx.Commit();
                        SessionContext.Log.Info("Approved Registration - " + (approverChoice == "1" ? "Approved" : "Rejected") + ". " + trans.GetType().ToString() + " TransactionID:" + trans.ID);
                    }
                    catch (Exception ex)
                    {
                        tx.Rollback();
                        isSendEmail = isSendEmail & false;
                        SessionContext.PersistenceSession.Clear();
                        throw new Exception("Approved Registration - Transaction process failed (Transaction will rollback)." + ex.ToString());
                    }
                }
                #endregion Transit Transaction

#if !DEBUG

                if (isSendEmail)
                {
                    #region Send Email
                    Customer cust = this.BaseGetCustomerInfomation_Data(trans.AccountProxy.CISID);
                    if (!string.IsNullOrEmpty(cust.EmailAddress))
                    {
                        string errorCode = "";
                        string description = "";
                        string content = "";
                        string custName = cust.FullNameThai;
                        EmailService emailService = new EmailService();
                        bool isSendMailSuccess = false;
                        if (trans is RegisterTransaction)
                        {
                            isSendMailSuccess = emailService.SendEmailRegister(cust.EmailAddress, custName, trans, out errorCode, out description, out content);
                        }
                        else if (trans is AmendTransaction)
                        {
                            isSendMailSuccess = emailService.SendEmailAmend(cust.EmailAddress, custName, trans, out errorCode, out description, out content);
                        }
                        else if (trans is DeactivateTransaction)
                        {
                            isSendMailSuccess = emailService.SendEmailDeactivate(cust.EmailAddress, custName, trans, out errorCode, out description, out content);
                        }
                        else
                        {
                            errorCode = "ISAY-EEMail-003";
                            description = "couldn't find template email id";
                        }

                        if (!isSendMailSuccess)
                        {
                            SessionContext.Log.Error("Approved Registration: Send email failed with error code: " + errorCode + " - " + description + ";Content:" + content + "TransactionID:" + trans.ID);
                            return Json(new { responseCode = "200", responseText = textResponse + "แต่ไม่สามารถส่ง Email ได้" }, JsonRequestBehavior.AllowGet);
                        }
                    }
                    #endregion Send Email
                }
#endif
                return Json(new { responseCode = "000", responseText = textResponse, html = Url.Content("~/MyWork") }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                string errorText = "Approved Registration - Transaction process failed (will rollback)." + ex.ToString();
                SessionContext.Log.Error((errorText.Length > 4000 ? errorText.Substring(0, 4000) : errorText));
                return Json(new { responseCode = "999", responseText = "Exception.", html = ex.ToString() }, JsonRequestBehavior.AllowGet);
            }
        }



        private void GetQueryTransaction(long transactionID, out ProxyTransaction transactions, out IList<TransactionDocument> documents)
        {
            ProxyTransaction transaction = SessionContext.PersistenceSession.Get<ProxyTransaction>(transactionID);
            List<TransactionDocument> docList = new List<TransactionDocument>();
            SessionContext.PersistenceSession.Refresh(transaction);

            if (string.IsNullOrEmpty(transaction.AccountProxy.RegistrationID))
            {
                foreach (ProxyTransaction item in transaction.AccountProxy.GetAllTransactionsByAccountProxyID(SessionContext))
                {
                    SessionContext.PersistenceSession.Refresh(item);
                    docList.AddRange(item.Documents);
                }
            }
            else
            {
                foreach (ProxyTransaction item in transaction.AccountProxy.GetAllTransactionsByRegistrationID(SessionContext))
                {
                    SessionContext.PersistenceSession.Refresh(item);
                    docList.AddRange(item.Documents);
                }
            }

            transactions = transaction;
            documents = docList.OrderBy(x => x.ID).ToList();
        }
    }
}