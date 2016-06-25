using System;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace ITMXConnector
{
    public class Security
    {
        static Security()
        {
        }

        public static String CertificateFolder = @"C:\AnyIDGateway\ITMXTests\Certificates";
        //public static String CertificateFolder = @"C:\Users\supoj\Documents\Projects\Kiatnakin\Tests";
        public static String SigningCertificateFileName = "KKBCertificate.pfx";
        //public static String ITMXCertificateFileName = "NITMXCA-G2_Test.cer";
        //public static String SigningCertificateFileName = "ITMXANYID069.p7b";
        //public static String KKBCertificateFileName = "TDIDRootCA-G3_Test.cer";

        //private static X509Certificate2 iTMXCert;
        //public static X509Certificate2 ITMXCert
        //{
        //    get
        //    {
        //        if (iTMXCert == null)
        //            iTMXCert = new X509Certificate2(Path.Combine(CertificateFolder, ITMXCertificateFileName));
        //        return iTMXCert;
        //    }
        //}

        //public static X509Certificate2 kkbCert;
        //public static X509Certificate2 KKBCert
        //{
        //    get
        //    {
        //        if (kkbCert == null)
        //            kkbCert = new X509Certificate2(Path.Combine(CertificateFolder, KKBCertificateFileName));
        //        return kkbCert;
        //    }
        //}

        private static X509Certificate2Collection signingCertChain;
        public static X509Certificate2 SigningCert
        {
            get
            {
                if (signingCertChain == null)
                {
                        string certFilePath = Path.Combine(CertificateFolder, SigningCertificateFileName);
                    try
                    {
                        signingCertChain = new X509Certificate2Collection();
                        signingCertChain.Import(certFilePath, "1234", X509KeyStorageFlags.DefaultKeySet);
                    }
                    catch (Exception exc)
                    {
                        string message = "Cannot import certificate file - [" + certFilePath + "]";
                        throw new Exception(message, exc);
                    }
                }

                if (signingCertChain.Count == 0)
                {
                    string message = "Certificate chain is empty.";
                    throw new Exception(message);
                }

                //return signingCertChain.Find(X509FindType.FindBySubjectName, "ITMXANYID069", true);
                return signingCertChain[2];
            }
        }

        public static string Sign(string content, X509Certificate2 certificate)
        {
            return Sign(System.Text.Encoding.UTF8.GetBytes(content), certificate);
        }

        public static string Sign(byte[] utf8Bytes, X509Certificate2 certificate)
        {
            if (utf8Bytes == null)
                throw new ArgumentNullException("utf8Bytes is null");

            if (certificate == null)
                throw new ArgumentNullException("certificate is null.");


            // setup the data to sign
            ContentInfo contentInfo = new ContentInfo(utf8Bytes);
            SignedCms signedCms = new SignedCms(contentInfo);
            CmsSigner signer = new CmsSigner(SubjectIdentifierType.IssuerAndSerialNumber, certificate);
            var privateKey = certificate.PrivateKey;
            // create the signature
            signedCms.ComputeSignature(signer);
            return Convert.ToBase64String(signedCms.Encode());
        }
    }
}
