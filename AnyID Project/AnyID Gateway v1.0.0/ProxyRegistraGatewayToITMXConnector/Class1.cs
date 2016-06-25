//using log4net;
//using System;
//using System.Diagnostics;
//using ProxyRegistraGateway;
//using ITMXConnector;

//namespace ProxyRegistraGatewayToITMXConnector
//{
//    public class Bridge
//    {
//        public Response Amend(ref Header header, AccountProxy accountProxy, out string registrationID)
//        {
//            AnyIDModel.AccountProxy a = accountProxy.ToAnyIDModel();
//            log.Info("send - " + a.ToString());
//            var itmx = new ITMXConnector.Itmx();
//            return itmx.Amend(log, a, out registrationID);
//        }

//        public Response DeactivateByAccount(ref Header header, BankAccount account, out string[] registrationIDs)
//        {
//            var log = GetLogger("DeactivateByAccount - " + header.LogTitle);
//            registrationIDs = null;
//            Response response = null;
//            if (XMLConfiguration.Configuration.IsAuthorized(header))
//            {
//                if (account == null)
//                    response = ResponseMapper.GetOrCreateResponse("1101", "Account");
//                else if (string.IsNullOrEmpty(account.AccountNo))
//                    response = ResponseMapper.GetOrCreateResponse("1101", "Account number");
//                if (response == null)
//                {
//                    log.Info("send - " + account.AccountNo);
//                    var itmx = new ITMXConnector.Itmx();
//                    var itmxResponse = itmx.Deactivate(log, account.ToAnyIDModel(), out registrationIDs);
//                    response = ResponseMapper.Map(itmxResponse);
//                    log.Info("receive - " + response.Code);
//                }
//                else
//                {
//                    log.Warn(response.Description);
//                }
//            }
//            else
//            {
//                log.Warn("Channel or system is not authorized to use the gateway.");
//                response = ResponseMapper.GetOrCreateResponse("NotAuthorized");
//            }
//            return response;
//        }

//        public Response DeactivateByAccountNo(ref Header header, string accountNo, out string[] registrationIDs)
//        {
//            var log = GetLogger("DeactivateByAccountNo - " + header.LogTitle);
//            registrationIDs = null;
//            Response response;
//            if (XMLConfiguration.Configuration.IsAuthorized(header))
//            {
//                if (string.IsNullOrEmpty(accountNo))
//                {
//                    response = ResponseMapper.GetOrCreateResponse("1101", "Account number");
//                    log.Warn(response.Description);
//                }
//                else
//                {
//                    log.Info("send - " + accountNo);
//                    var itmx = new ITMXConnector.Itmx();
//                    var itmxResponse = itmx.Deactivate(log, new iSabaya.BankAccount { AccountNo = accountNo }, out registrationIDs);
//                    response = ResponseMapper.Map(itmxResponse);
//                    log.Info("receive - " + response.Code);
//                }
//            }
//            else
//            {
//                log.Warn("Channel or system is not authorized to use the gateway.");
//                response = ResponseMapper.GetOrCreateResponse("NotAuthorized");
//            }
//            return response;
//        }

//        public Response DeactivateByAnyID(ref Header header, AnyID anyID, out string registrationID)
//        {
//            var log = GetLogger("DeactivateByAnyID - " + header.LogTitle);
//            registrationID = null;
//            Response response = null;
//            if (XMLConfiguration.Configuration.IsAuthorized(header))
//            {
//                if (anyID == null)
//                {
//                    response = ResponseMapper.GetOrCreateResponse("1101", "anyID");
//                    log.Warn(response.Description);
//                }
//                else
//                {

//                    log.Info("send - " + anyID.ToString());
//                    var itmx = new ITMXConnector.Itmx();
//                    var itmxResponse = itmx.Deactivate(log, anyID.ToAnyIDModel(), out registrationID);
//                    response = ResponseMapper.Map(itmxResponse);
//                    log.Info("receive - " + response.Code);
//                }
//            }
//            else
//            {
//                log.Warn("Channel or system is not authorized to use the gateway.");
//                response = ResponseMapper.GetOrCreateResponse("NotAuthorized");
//            }
//            return response;
//        }

//        public Response DeactivateByRegistrationID(ref Header header, string registrationID)
//        {
//            var log = GetLogger("DeactivateByRegistrationID");
//            log.Info(header.LogTitle);
//            Response response;
//            if (XMLConfiguration.Configuration.IsAuthorized(header))
//            {
//                if (string.IsNullOrEmpty(registrationID))
//                {
//                    response = ResponseMapper.GetOrCreateResponse("1101", "registration ID");
//                    log.Warn(response.Description);
//                }
//                else
//                {
//                    log.Info("send - " + registrationID);
//                    var itmx = new ITMXConnector.Itmx();
//                    var itmxResponse = itmx.Deactivate(log, registrationID);
//                    response = ResponseMapper.Map(itmxResponse);
//                    log.Info("receive - " + response.Code);
//                }
//            }
//            else
//            {
//                log.Warn("Channel or system is not authorized to use the gateway.");
//                response = ResponseMapper.GetOrCreateResponse("NotAuthorized");
//            }
//            return response;
//        }

//        public Response Register(ref Header header, AccountProxy accountProxy, out string registrationID)
//        {
//            var log = GetLogger("Register - " + header.LogTitle);
//            registrationID = null;
//            Response response = null;
//            if (XMLConfiguration.Configuration.IsAuthorized(header))
//            {
//                if (accountProxy == null)
//                    response = ResponseMapper.GetOrCreateResponse("1101", "Account proxy");
//                if (accountProxy.AnyID == null)
//                    response = ResponseMapper.GetOrCreateResponse("1101", "AccountID in account proxy");
//                if (accountProxy.BankAccount == null)
//                    response = ResponseMapper.GetOrCreateResponse("1101", "Account in account proxy");
//                if (response == null)
//                {
//                    AnyIDModel.AccountProxy a = accountProxy.ToAnyIDModel();
//                    log.Info("send - " + a.ToString());
//                    var itmx = new ITMXConnector.Itmx();
//                    var itmxResponse = itmx.Register(log, a, out registrationID);
//                    response = ResponseMapper.Map(itmxResponse);
//                    log.Info("receive - " + response.Code);
//                }
//                else
//                    log.Warn(response.Description);
//            }
//            else
//            {
//                log.Warn("Channel or system is not authorized to use the gateway.");
//                response = ResponseMapper.GetOrCreateResponse("NotAuthorized");
//            }
//            return response;
//        }
//    }
//}

//}
