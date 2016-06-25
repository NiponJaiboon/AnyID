namespace AnyIDModel
{
    public enum RegistraResponseStatus
    {
        Undefined,
        Success,
        Error, //can connect to itmx
        /// <summary>
        /// Failed by ITMX
        /// </summary>
        Failed,
        Timeout, //408 503 504
        //Forbidden = 403,
        //NotFound = 404,
        //InternalServerError = 500,
        //StructureFailure = 602, //incorrect data
        //InvalidProxyType = 802,
        //ProxyNotFound = 801,
        //ProxyRegisteredByOther = 800,
        //RequestedStatusNotfound = 920,
        //AccountNamesMismatched = 926,
        //AccountRegistrationExceedLimit = 944,
        Others = 9999,
    }
}
