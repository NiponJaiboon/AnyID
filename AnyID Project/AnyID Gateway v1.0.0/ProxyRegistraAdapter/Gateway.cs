﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProxyRegistraGateway
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Header", Namespace="http://schemas.datacontract.org/2004/07/ProxyRegistraGateway")]
    public partial class Header : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string channelIdField;
        
        private string referenceNoField;
        
        private string serviceNameField;
        
        private string systemCodeField;
        
        private string transactionDateTimeField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string channelId
        {
            get
            {
                return this.channelIdField;
            }
            set
            {
                this.channelIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string referenceNo
        {
            get
            {
                return this.referenceNoField;
            }
            set
            {
                this.referenceNoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string serviceName
        {
            get
            {
                return this.serviceNameField;
            }
            set
            {
                this.serviceNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string systemCode
        {
            get
            {
                return this.systemCodeField;
            }
            set
            {
                this.systemCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string transactionDateTime
        {
            get
            {
                return this.transactionDateTimeField;
            }
            set
            {
                this.transactionDateTimeField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AccountProxy", Namespace="http://schemas.datacontract.org/2004/07/ProxyRegistraGateway")]
    public partial class AccountProxy : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private ProxyRegistraGateway.AnyID AnyIDField;
        
        private ProxyRegistraGateway.BankAccount BankAccountField;
        
        private ProxyRegistraGateway.Customer CustomerField;
        
        private string DisplayNameField;
        
        private string DummyAccountNoField;
        
        private string RegistrationIDField;
        
        private string RegistrationTimestampField;
        
        private string StatusField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ProxyRegistraGateway.AnyID AnyID
        {
            get
            {
                return this.AnyIDField;
            }
            set
            {
                this.AnyIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ProxyRegistraGateway.BankAccount BankAccount
        {
            get
            {
                return this.BankAccountField;
            }
            set
            {
                this.BankAccountField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ProxyRegistraGateway.Customer Customer
        {
            get
            {
                return this.CustomerField;
            }
            set
            {
                this.CustomerField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DisplayName
        {
            get
            {
                return this.DisplayNameField;
            }
            set
            {
                this.DisplayNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string DummyAccountNo
        {
            get
            {
                return this.DummyAccountNoField;
            }
            set
            {
                this.DummyAccountNoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RegistrationID
        {
            get
            {
                return this.RegistrationIDField;
            }
            set
            {
                this.RegistrationIDField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RegistrationTimestamp
        {
            get
            {
                return this.RegistrationTimestampField;
            }
            set
            {
                this.RegistrationTimestampField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Status
        {
            get
            {
                return this.StatusField;
            }
            set
            {
                this.StatusField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="AnyID", Namespace="http://schemas.datacontract.org/2004/07/ProxyRegistraGateway")]
    public partial class AnyID : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string IDNoField;
        
        private string IDTypeField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IDNo
        {
            get
            {
                return this.IDNoField;
            }
            set
            {
                this.IDNoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IDType
        {
            get
            {
                return this.IDTypeField;
            }
            set
            {
                this.IDTypeField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="BankAccount", Namespace="http://schemas.datacontract.org/2004/07/ProxyRegistraGateway")]
    public partial class BankAccount : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string AccountNameField;
        
        private string AccountNoField;
        
        private string TypeField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AccountName
        {
            get
            {
                return this.AccountNameField;
            }
            set
            {
                this.AccountNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string AccountNo
        {
            get
            {
                return this.AccountNoField;
            }
            set
            {
                this.AccountNoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Type
        {
            get
            {
                return this.TypeField;
            }
            set
            {
                this.TypeField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Customer", Namespace="http://schemas.datacontract.org/2004/07/ProxyRegistraGateway")]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ProxyRegistraGateway.Person))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ProxyRegistraGateway.Organization))]
    public partial class Customer : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string CISIDField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CISID
        {
            get
            {
                return this.CISIDField;
            }
            set
            {
                this.CISIDField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Person", Namespace="http://schemas.datacontract.org/2004/07/ProxyRegistraGateway")]
    public partial class Person : ProxyRegistraGateway.Customer
    {
        
        private string FirstNameField;
        
        private string LastNameField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName
        {
            get
            {
                return this.FirstNameField;
            }
            set
            {
                this.FirstNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName
        {
            get
            {
                return this.LastNameField;
            }
            set
            {
                this.LastNameField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Organization", Namespace="http://schemas.datacontract.org/2004/07/ProxyRegistraGateway")]
    public partial class Organization : ProxyRegistraGateway.Customer
    {
        
        private string NameField;
        
        private string RegisteredDateField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Name
        {
            get
            {
                return this.NameField;
            }
            set
            {
                this.NameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string RegisteredDate
        {
            get
            {
                return this.RegisteredDateField;
            }
            set
            {
                this.RegisteredDateField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Response", Namespace="http://schemas.datacontract.org/2004/07/ProxyRegistraGateway")]
    public partial class Response : object, System.Runtime.Serialization.IExtensibleDataObject
    {
        
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        private string responseCodeField;
        
        private string responseMsgField;
        
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData
        {
            get
            {
                return this.extensionDataField;
            }
            set
            {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string responseCode
        {
            get
            {
                return this.responseCodeField;
            }
            set
            {
                this.responseCodeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string responseMsg
        {
            get
            {
                return this.responseMsgField;
            }
            set
            {
                this.responseMsgField = value;
            }
        }
    }
}


[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IProxyRegistraGateway")]
public interface IProxyRegistraGateway
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyRegistraGateway/Register", ReplyAction="http://tempuri.org/IProxyRegistraGateway/RegisterResponse")]
    RegisterResponse Register(RegisterRequest request);
    
    // CODEGEN: Generating message contract since the operation has multiple return values.
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyRegistraGateway/Register", ReplyAction="http://tempuri.org/IProxyRegistraGateway/RegisterResponse")]
    System.Threading.Tasks.Task<RegisterResponse> RegisterAsync(RegisterRequest request);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyRegistraGateway/Amend", ReplyAction="http://tempuri.org/IProxyRegistraGateway/AmendResponse")]
    AmendResponse Amend(AmendRequest request);
    
    // CODEGEN: Generating message contract since the operation has multiple return values.
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyRegistraGateway/Amend", ReplyAction="http://tempuri.org/IProxyRegistraGateway/AmendResponse")]
    System.Threading.Tasks.Task<AmendResponse> AmendAsync(AmendRequest request);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyRegistraGateway/DeactivateByAccount", ReplyAction="http://tempuri.org/IProxyRegistraGateway/DeactivateByAccountResponse")]
    DeactivateByAccountResponse DeactivateByAccount(DeactivateByAccountRequest request);
    
    // CODEGEN: Generating message contract since the operation has multiple return values.
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyRegistraGateway/DeactivateByAccount", ReplyAction="http://tempuri.org/IProxyRegistraGateway/DeactivateByAccountResponse")]
    System.Threading.Tasks.Task<DeactivateByAccountResponse> DeactivateByAccountAsync(DeactivateByAccountRequest request);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyRegistraGateway/DeactivateByAccountNo", ReplyAction="http://tempuri.org/IProxyRegistraGateway/DeactivateByAccountNoResponse")]
    DeactivateByAccountNoResponse DeactivateByAccountNo(DeactivateByAccountNoRequest request);
    
    // CODEGEN: Generating message contract since the operation has multiple return values.
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyRegistraGateway/DeactivateByAccountNo", ReplyAction="http://tempuri.org/IProxyRegistraGateway/DeactivateByAccountNoResponse")]
    System.Threading.Tasks.Task<DeactivateByAccountNoResponse> DeactivateByAccountNoAsync(DeactivateByAccountNoRequest request);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyRegistraGateway/DeactivateByRegistrationID", ReplyAction="http://tempuri.org/IProxyRegistraGateway/DeactivateByRegistrationIDResponse")]
    DeactivateByRegistrationIDResponse DeactivateByRegistrationID(DeactivateByRegistrationIDRequest request);
    
    // CODEGEN: Generating message contract since the operation has multiple return values.
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyRegistraGateway/DeactivateByRegistrationID", ReplyAction="http://tempuri.org/IProxyRegistraGateway/DeactivateByRegistrationIDResponse")]
    System.Threading.Tasks.Task<DeactivateByRegistrationIDResponse> DeactivateByRegistrationIDAsync(DeactivateByRegistrationIDRequest request);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyRegistraGateway/DeactivateByAnyID", ReplyAction="http://tempuri.org/IProxyRegistraGateway/DeactivateByAnyIDResponse")]
    DeactivateByAnyIDResponse DeactivateByAnyID(DeactivateByAnyIDRequest request);
    
    // CODEGEN: Generating message contract since the operation has multiple return values.
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProxyRegistraGateway/DeactivateByAnyID", ReplyAction="http://tempuri.org/IProxyRegistraGateway/DeactivateByAnyIDResponse")]
    System.Threading.Tasks.Task<DeactivateByAnyIDResponse> DeactivateByAnyIDAsync(DeactivateByAnyIDRequest request);
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.MessageContractAttribute(WrapperName="Register", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
public partial class RegisterRequest
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
    public ProxyRegistraGateway.Header header;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
    public ProxyRegistraGateway.AccountProxy accountProxy;
    
    public RegisterRequest()
    {
    }
    
    public RegisterRequest(ProxyRegistraGateway.Header header, ProxyRegistraGateway.AccountProxy accountProxy)
    {
        this.header = header;
        this.accountProxy = accountProxy;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.MessageContractAttribute(WrapperName="RegisterResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
public partial class RegisterResponse
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
    public ProxyRegistraGateway.Response RegisterResult;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
    public ProxyRegistraGateway.Header header;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
    public string registrationID;
    
    public RegisterResponse()
    {
    }
    
    public RegisterResponse(ProxyRegistraGateway.Response RegisterResult, ProxyRegistraGateway.Header header, string registrationID)
    {
        this.RegisterResult = RegisterResult;
        this.header = header;
        this.registrationID = registrationID;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.MessageContractAttribute(WrapperName="Amend", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
public partial class AmendRequest
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
    public ProxyRegistraGateway.Header header;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
    public ProxyRegistraGateway.AccountProxy accountProxy;
    
    public AmendRequest()
    {
    }
    
    public AmendRequest(ProxyRegistraGateway.Header header, ProxyRegistraGateway.AccountProxy accountProxy)
    {
        this.header = header;
        this.accountProxy = accountProxy;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.MessageContractAttribute(WrapperName="AmendResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
public partial class AmendResponse
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
    public ProxyRegistraGateway.Response AmendResult;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
    public ProxyRegistraGateway.Header header;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
    public string registrationID;
    
    public AmendResponse()
    {
    }
    
    public AmendResponse(ProxyRegistraGateway.Response AmendResult, ProxyRegistraGateway.Header header, string registrationID)
    {
        this.AmendResult = AmendResult;
        this.header = header;
        this.registrationID = registrationID;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.MessageContractAttribute(WrapperName="DeactivateByAccount", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
public partial class DeactivateByAccountRequest
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
    public ProxyRegistraGateway.Header header;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
    public ProxyRegistraGateway.BankAccount account;
    
    public DeactivateByAccountRequest()
    {
    }
    
    public DeactivateByAccountRequest(ProxyRegistraGateway.Header header, ProxyRegistraGateway.BankAccount account)
    {
        this.header = header;
        this.account = account;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.MessageContractAttribute(WrapperName="DeactivateByAccountResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
public partial class DeactivateByAccountResponse
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
    public ProxyRegistraGateway.Response DeactivateByAccountResult;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
    public ProxyRegistraGateway.Header header;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
    public string[] registrationIDs;
    
    public DeactivateByAccountResponse()
    {
    }
    
    public DeactivateByAccountResponse(ProxyRegistraGateway.Response DeactivateByAccountResult, ProxyRegistraGateway.Header header, string[] registrationIDs)
    {
        this.DeactivateByAccountResult = DeactivateByAccountResult;
        this.header = header;
        this.registrationIDs = registrationIDs;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.MessageContractAttribute(WrapperName="DeactivateByAccountNo", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
public partial class DeactivateByAccountNoRequest
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
    public ProxyRegistraGateway.Header header;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
    public string accountNo;
    
    public DeactivateByAccountNoRequest()
    {
    }
    
    public DeactivateByAccountNoRequest(ProxyRegistraGateway.Header header, string accountNo)
    {
        this.header = header;
        this.accountNo = accountNo;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.MessageContractAttribute(WrapperName="DeactivateByAccountNoResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
public partial class DeactivateByAccountNoResponse
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
    public ProxyRegistraGateway.Response DeactivateByAccountNoResult;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
    public ProxyRegistraGateway.Header header;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
    public string[] registrationIDs;
    
    public DeactivateByAccountNoResponse()
    {
    }
    
    public DeactivateByAccountNoResponse(ProxyRegistraGateway.Response DeactivateByAccountNoResult, ProxyRegistraGateway.Header header, string[] registrationIDs)
    {
        this.DeactivateByAccountNoResult = DeactivateByAccountNoResult;
        this.header = header;
        this.registrationIDs = registrationIDs;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.MessageContractAttribute(WrapperName="DeactivateByRegistrationID", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
public partial class DeactivateByRegistrationIDRequest
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
    public ProxyRegistraGateway.Header header;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
    public string registrationID;
    
    public DeactivateByRegistrationIDRequest()
    {
    }
    
    public DeactivateByRegistrationIDRequest(ProxyRegistraGateway.Header header, string registrationID)
    {
        this.header = header;
        this.registrationID = registrationID;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.MessageContractAttribute(WrapperName="DeactivateByRegistrationIDResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
public partial class DeactivateByRegistrationIDResponse
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
    public ProxyRegistraGateway.Response DeactivateByRegistrationIDResult;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
    public ProxyRegistraGateway.Header header;
    
    public DeactivateByRegistrationIDResponse()
    {
    }
    
    public DeactivateByRegistrationIDResponse(ProxyRegistraGateway.Response DeactivateByRegistrationIDResult, ProxyRegistraGateway.Header header)
    {
        this.DeactivateByRegistrationIDResult = DeactivateByRegistrationIDResult;
        this.header = header;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.MessageContractAttribute(WrapperName="DeactivateByAnyID", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
public partial class DeactivateByAnyIDRequest
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
    public ProxyRegistraGateway.Header header;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
    public ProxyRegistraGateway.AnyID anyID;
    
    public DeactivateByAnyIDRequest()
    {
    }
    
    public DeactivateByAnyIDRequest(ProxyRegistraGateway.Header header, ProxyRegistraGateway.AnyID anyID)
    {
        this.header = header;
        this.anyID = anyID;
    }
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.MessageContractAttribute(WrapperName="DeactivateByAnyIDResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
public partial class DeactivateByAnyIDResponse
{
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
    public ProxyRegistraGateway.Response DeactivateByAnyIDResult;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
    public ProxyRegistraGateway.Header header;
    
    [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
    public string registrationID;
    
    public DeactivateByAnyIDResponse()
    {
    }
    
    public DeactivateByAnyIDResponse(ProxyRegistraGateway.Response DeactivateByAnyIDResult, ProxyRegistraGateway.Header header, string registrationID)
    {
        this.DeactivateByAnyIDResult = DeactivateByAnyIDResult;
        this.header = header;
        this.registrationID = registrationID;
    }
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IProxyRegistraGatewayChannel : IProxyRegistraGateway, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class ProxyRegistraGatewayClient : System.ServiceModel.ClientBase<IProxyRegistraGateway>, IProxyRegistraGateway
{
    
    public ProxyRegistraGatewayClient()
    {
    }
    
    public ProxyRegistraGatewayClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public ProxyRegistraGatewayClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public ProxyRegistraGatewayClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public ProxyRegistraGatewayClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    RegisterResponse IProxyRegistraGateway.Register(RegisterRequest request)
    {
        return base.Channel.Register(request);
    }
    
    public ProxyRegistraGateway.Response Register(ref ProxyRegistraGateway.Header header, ProxyRegistraGateway.AccountProxy accountProxy, out string registrationID)
    {
        RegisterRequest inValue = new RegisterRequest();
        inValue.header = header;
        inValue.accountProxy = accountProxy;
        RegisterResponse retVal = ((IProxyRegistraGateway)(this)).Register(inValue);
        header = retVal.header;
        registrationID = retVal.registrationID;
        return retVal.RegisterResult;
    }
    
    public System.Threading.Tasks.Task<RegisterResponse> RegisterAsync(RegisterRequest request)
    {
        return base.Channel.RegisterAsync(request);
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    AmendResponse IProxyRegistraGateway.Amend(AmendRequest request)
    {
        return base.Channel.Amend(request);
    }
    
    public ProxyRegistraGateway.Response Amend(ref ProxyRegistraGateway.Header header, ProxyRegistraGateway.AccountProxy accountProxy, out string registrationID)
    {
        AmendRequest inValue = new AmendRequest();
        inValue.header = header;
        inValue.accountProxy = accountProxy;
        AmendResponse retVal = ((IProxyRegistraGateway)(this)).Amend(inValue);
        header = retVal.header;
        registrationID = retVal.registrationID;
        return retVal.AmendResult;
    }
    
    public System.Threading.Tasks.Task<AmendResponse> AmendAsync(AmendRequest request)
    {
        return base.Channel.AmendAsync(request);
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    DeactivateByAccountResponse IProxyRegistraGateway.DeactivateByAccount(DeactivateByAccountRequest request)
    {
        return base.Channel.DeactivateByAccount(request);
    }
    
    public ProxyRegistraGateway.Response DeactivateByAccount(ref ProxyRegistraGateway.Header header, ProxyRegistraGateway.BankAccount account, out string[] registrationIDs)
    {
        DeactivateByAccountRequest inValue = new DeactivateByAccountRequest();
        inValue.header = header;
        inValue.account = account;
        DeactivateByAccountResponse retVal = ((IProxyRegistraGateway)(this)).DeactivateByAccount(inValue);
        header = retVal.header;
        registrationIDs = retVal.registrationIDs;
        return retVal.DeactivateByAccountResult;
    }
    
    public System.Threading.Tasks.Task<DeactivateByAccountResponse> DeactivateByAccountAsync(DeactivateByAccountRequest request)
    {
        return base.Channel.DeactivateByAccountAsync(request);
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    DeactivateByAccountNoResponse IProxyRegistraGateway.DeactivateByAccountNo(DeactivateByAccountNoRequest request)
    {
        return base.Channel.DeactivateByAccountNo(request);
    }
    
    public ProxyRegistraGateway.Response DeactivateByAccountNo(ref ProxyRegistraGateway.Header header, string accountNo, out string[] registrationIDs)
    {
        DeactivateByAccountNoRequest inValue = new DeactivateByAccountNoRequest();
        inValue.header = header;
        inValue.accountNo = accountNo;
        DeactivateByAccountNoResponse retVal = ((IProxyRegistraGateway)(this)).DeactivateByAccountNo(inValue);
        header = retVal.header;
        registrationIDs = retVal.registrationIDs;
        return retVal.DeactivateByAccountNoResult;
    }
    
    public System.Threading.Tasks.Task<DeactivateByAccountNoResponse> DeactivateByAccountNoAsync(DeactivateByAccountNoRequest request)
    {
        return base.Channel.DeactivateByAccountNoAsync(request);
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    DeactivateByRegistrationIDResponse IProxyRegistraGateway.DeactivateByRegistrationID(DeactivateByRegistrationIDRequest request)
    {
        return base.Channel.DeactivateByRegistrationID(request);
    }
    
    public ProxyRegistraGateway.Response DeactivateByRegistrationID(ref ProxyRegistraGateway.Header header, string registrationID)
    {
        DeactivateByRegistrationIDRequest inValue = new DeactivateByRegistrationIDRequest();
        inValue.header = header;
        inValue.registrationID = registrationID;
        DeactivateByRegistrationIDResponse retVal = ((IProxyRegistraGateway)(this)).DeactivateByRegistrationID(inValue);
        header = retVal.header;
        return retVal.DeactivateByRegistrationIDResult;
    }
    
    public System.Threading.Tasks.Task<DeactivateByRegistrationIDResponse> DeactivateByRegistrationIDAsync(DeactivateByRegistrationIDRequest request)
    {
        return base.Channel.DeactivateByRegistrationIDAsync(request);
    }
    
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    DeactivateByAnyIDResponse IProxyRegistraGateway.DeactivateByAnyID(DeactivateByAnyIDRequest request)
    {
        return base.Channel.DeactivateByAnyID(request);
    }
    
    public ProxyRegistraGateway.Response DeactivateByAnyID(ref ProxyRegistraGateway.Header header, ProxyRegistraGateway.AnyID anyID, out string registrationID)
    {
        DeactivateByAnyIDRequest inValue = new DeactivateByAnyIDRequest();
        inValue.header = header;
        inValue.anyID = anyID;
        DeactivateByAnyIDResponse retVal = ((IProxyRegistraGateway)(this)).DeactivateByAnyID(inValue);
        header = retVal.header;
        registrationID = retVal.registrationID;
        return retVal.DeactivateByAnyIDResult;
    }
    
    public System.Threading.Tasks.Task<DeactivateByAnyIDResponse> DeactivateByAnyIDAsync(DeactivateByAnyIDRequest request)
    {
        return base.Channel.DeactivateByAnyIDAsync(request);
    }
}
