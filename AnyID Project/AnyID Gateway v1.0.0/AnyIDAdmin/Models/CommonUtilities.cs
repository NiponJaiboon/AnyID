using AnyIDModel;
using iSabaya;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AnyIDAdmin.Models
{
    public class CommonUtilities
    {
        public class Fixed
        {
            public const string MSISDN = "MSISDN";
            public const string NATID = "NATID";
        }

        //public static string ApplicationName(HttpRequestBase request)
        //{
        //    if (request == null) return "";

        //    return request.ApplicationPath.Substring(1);
        //}

        //public static string GetApplicationUrl(HttpRequestBase request, string urlPath)
        //{
        //    string configAppName = CommonUtilities.ApplicationName(request);
        //    return (configAppName == "" ? "" : "/" + configAppName) + urlPath;
        //}

        public static byte[] MergePDF(IList<byte[]> pdf)
        {
            byte[] mergedPdf = null;
            using (MemoryStream ms = new MemoryStream())
            {
                using (Document document = new Document())
                {
                    using (PdfCopy copy = new PdfCopy(document, ms))
                    {
                        document.Open();

                        for (int i = 0; i < pdf.Count; ++i)
                        {
                            PdfReader reader = new PdfReader(pdf[i]);
                            // loop over the pages in that document
                            int n = reader.NumberOfPages;
                            for (int page = 0; page < n;)
                            {
                                copy.AddPage(copy.GetImportedPage(reader, ++page));
                            }
                        }
                    }
                }
                mergedPdf = ms.ToArray();
            }
            return mergedPdf;
        }

        ///// <summary>
        ///// Get C# DateTime from JS Datetime
        ///// </summary>
        ///// <param name="value">String JS DateTime in format yyyy,MM,dd,HH,mm,ss Note. MM equal mounth start at 0 mean January</param>
        ///// <returns>C# DateTime</returns>
        //public static DateTime JsDateTime2DateTimeIsMine(string value, bool defaultValueIsMinDate = true)
        //{
        //    if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
        //    {
        //        if (defaultValueIsMinDate)
        //            return TimeInterval.MinDate;
        //        else
        //            return TimeInterval.MaxDate;
        //    }

        //    string[] datetime = value.Split(',');
        //    return new DateTime(int.Parse(datetime[0]), int.Parse(datetime[1]) + 1, int.Parse(datetime[2]), int.Parse(datetime[3]), int.Parse(datetime[4]), int.Parse(datetime[5]));
        //}

        //public static Color GetExecutiveOrderStateColor(ExecutiveOrderState currentState)
        //{
        //    if (currentState == null)
        //        return Color.Transparent;

        //    if (currentState.StateCategory == HRTransactionStateCategory.Submitted)
        //        return Color.Yellow;
        //    else if (currentState.StateCategory == HRTransactionStateCategory.Rejected)
        //        return Color.Red;
        //    else if (currentState.StateCategory == HRTransactionStateCategory.Approved)
        //        return Color.Green;
        //    else
        //        return Color.Transparent;
        //}

        public static string GetServerIPAddress()
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName()); // `Dns.Resolve()` method is deprecated.
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            return ipAddress.ToString();
        }

        #region Report

        public static byte[] GenerateErrorReport(HttpServerUtilityBase server, string message)
        {
            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            string reportPath = string.Empty;
            DataTable dt = new DataTable();
            dt.Columns.Add("Message");
            dt.Rows.Add(message);

            reportPath = server.MapPath("~/Reports/Error.rdlc");
            ReportViewer viewer = new ReportViewer();
            viewer.ProcessingMode = ProcessingMode.Local;
            viewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            viewer.LocalReport.ReportPath = reportPath;
            byte[] bytes = viewer.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

            return bytes;
        }

        #endregion Report

        #region Encrypt & Decrypt

        private static readonly byte[] KeyByte = Convert.FromBase64String("Rj9IPzU/ARo/Pz8JPz8/Pz8KPz8/cD8/Pz8/Pzw2Wmw="); // 32 byte
        private static readonly byte[] IVByte = Convert.FromBase64String("Pz99Yj81Mz8/Pz8/Pz8/Pw=="); // 16 byte

        public static string Encrypt(string plainText)
        {
            using (Rijndael myRijndael = Rijndael.Create())
            {
                myRijndael.Key = KeyByte;
                myRijndael.IV = IVByte;
                // Encrypt the string to an array of bytes.
                byte[] encrypted = EncryptStringToBytes(plainText, myRijndael.Key, myRijndael.IV);
                return Convert.ToBase64String(encrypted).Replace("+", ":");
            }
        }

        public static string Decrypt(string cipheredText)
        {
            using (Rijndael myRijndael = Rijndael.Create())
            {
                myRijndael.Key = KeyByte;
                myRijndael.IV = IVByte;

                byte[] responseByte = Convert.FromBase64String(cipheredText.Replace(":", "+"));
                return DecryptStringFromBytes(responseByte, myRijndael.Key, myRijndael.IV);
            }
        }

        private static byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] iv)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("key");
            byte[] encrypted;
            // Create an Rijndael object
            // with the specified key and IV.
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = key;
                rijAlg.IV = iv;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        private static string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("key");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext;

            // Create an Rijndael object
            // with the specified key and IV.
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = key;
                rijAlg.IV = iv;

                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }

        public static string RemovePlusAndSpaceSymolFromBase64(string base64Text)
        {
            return base64Text.Replace('+', '-').Replace('/', '_').Replace('=', '.');
        }

        public static string ResotrePlusAndSpaceSymolFromBase64(string base64Text)
        {
            return base64Text.Replace('-', '+').Replace('_', '/').Replace('.', '=');
        }

        #endregion Encrypt & Decrypt

        public static string JSSerializer<T>(T item)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(item);
        }

        public static T JSDeserialize<T>(string JsonText)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(JsonText);
        }

        #region Convert Number & Date To Thai

        public static string ConvertToThaiNumber(int number)
        {
            return CommonUtilities.ConvertToThaiNumber(number.ToString());
        }

        public static string ConvertToThaiNumber(string number)
        {
            string result = "";
            while (number.Length != 0)
            {
                string numText = number.Substring(0, 1);
                #region Get thai number
                switch (numText)
                {
                    case "1":
                        result += "๑";
                        break;
                    case "2":
                        result += "๒";
                        break;
                    case "3":
                        result += "๓";
                        break;
                    case "4":
                        result += "๔";
                        break;
                    case "5":
                        result += "๕";
                        break;
                    case "6":
                        result += "๖";
                        break;
                    case "7":
                        result += "๗";
                        break;
                    case "8":
                        result += "๘";
                        break;
                    case "9":
                        result += "๙";
                        break;
                    case "0":
                        result += "๐";
                        break;
                    default:
                        result += numText;
                        break;
                }
                #endregion Get thai number
                number = number.Substring(1);
            }

            return result;
        }

        //public static string ConvertToDateThai(DateTime date)
        //{
        //    if (date == iSabaya.TimeInterval.MinDate) return "";

        //    string result = "";
        //    string day = date.Day.ToString();
        //    string fullYear = (date.Year + 543).ToString();

        //    result += CommonConstant.ConvertToThaiNumber(day) + " ";
        //    result += CommonConstant.ConvertToThaiMounth(date.Month) + " ";
        //    result += CommonConstant.ConvertToThaiNumber(fullYear);

        //    return result;
        //}

        public static string ConvertToThaiMounth(int mounthNo)
        {
            switch (mounthNo)
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

        public static string ConvertToEnglishMounth(int mounthNo)
        {
            switch (mounthNo)
            {
                case 1:
                    return "January";
                case 2:
                    return "February";
                case 3:
                    return "March";
                case 4:
                    return "April";
                case 5:
                    return "May";
                case 6:
                    return "June";
                case 7:
                    return "July";
                case 8:
                    return "August";
                case 9:
                    return "September";
                case 10:
                    return "October";
                case 11:
                    return "November";
                case 12:
                    return "December";
                default:
                    return "";
            }
        }

        public static int ConvertYearByCode(string code, int year4digit)
        {
            //By default calculate year from A.D.
            if (code == "th-TH")
                return (year4digit + 543);
            else
                return year4digit;
        }

        public static string ConvertFullDateArabic(string languageCode, DateTime date)
        {
            if ("th-TH" == languageCode)
                return date.Day.ToString("00") + " " + ConvertToThaiMounth(date.Month) + " " + ConvertYearByCode(languageCode, date.Year);
            else if ("en-US" == languageCode)
                return date.Day.ToString("00") + " " + ConvertToEnglishMounth(date.Month) + " " + ConvertYearByCode(languageCode, date.Year);
            else
                return "";
        }

        #endregion Convert Number & Date To Thai

        public static string GetUrlFromScreenCode(UrlHelper url, string screenCode)
        {
            if (screenCode == null)
                return url.Content("~/Login");
            else if (screenCode == "SC01")
                return url.Content("~/Login");
            else if (screenCode == "SC02")
                return url.Content("~/SearchCustomer");
            else if (screenCode == "SC03")
                return url.Content("~/ViewCustomer");
            else if (screenCode == "SC04")
                return url.Content("~/CreateRegistration");
            else if (screenCode == "SC06")
                return url.Content("~/MyWork");
            else if (screenCode == "SC07")
                return url.Content("~/ViewRegistration");
            else if (screenCode == "SC08")
                return url.Content("~/ApproveRegistration");
            else if (screenCode == "SC09")
                return url.Content("~/AmendRegistration");
            else if (screenCode == "SC11")
                return url.Content("~/History");
            else if (screenCode == "SC12")
                return url.Content("~/ViewHistory");
            else
                return url.Content("~/Login");
        }

        public static T GetValueOfAnonymousType<T>(object obj, string property)
        {
            return (T)obj.GetType().GetProperty(property).GetValue(obj);
        }

        public static ProxyTransaction GetActualTypeOfTransaction(WebSessionContext context, long transactionID)
        {
            ProxyTransaction transaction = null;
            if (transaction == null)
                transaction = context.PersistenceSession.Get<RegisterTransaction>(transactionID);
            if (transaction == null)
                transaction = context.PersistenceSession.Get<AmendTransaction>(transactionID);
            if (transaction == null)
                transaction = context.PersistenceSession.Get<DeactivateTransaction>(transactionID);

            return transaction;
        }

        #region Static Type of System

        public static string[] CardType(string[] isParam)
        {
            return new string[] {
                "C:Corporate Registration",
                "I:ID Card",
                "P:Passport",
                "R:Bureaucracy ID",
                "O:Other Juristic ID",
                "F:Financial Institution",
                "T:Tax ID",
                "G:Government ID",
            };
        }

        public static Dictionary<string, string> CardType(Dictionary<string, string> isParam)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("C", "Corporate Registration");
            result.Add("I", "ID Card");
            result.Add("P", "Passport");
            result.Add("R", "Bureaucracy ID");
            result.Add("O", "Other Juristic ID");
            result.Add("F", "Financial Institution");
            result.Add("T", "Tax ID");
            result.Add("G", "Government ID");
            return result;
        }

        public static string[] CustomerType(string[] isParam)
        {
            return new string[] { "01:สถาบันการเงินอื􀃉น (บ.ลิสซิ่ง)",
                "02:รัฐวิสาหกิจ และองค์การของรัฐ",
                "03:สหกรณ์",
                "04:บริษัทบัตรเครดิต",
                "05:กองทุนทดแทนความเสียหาย",
                "06:ธนาคารออมสิน",
                "07:ธนาคารแห่งประเทศไทย",
                "08:ธนาคารพาณิชย์ภายในประเทศ",
                "09:ธนาคารเพื่อการส่งออกและนำเข้า",
                "10:สาขาธนาคารต่างประเทศ",
                "11:บริษัทหลักทรัพย์",
                "12:บรรษัทประกันสินเชื􀃉ออุตสาหกรรมขนาดย่อม",
                "13:บริษัทหลักทรัพย์จัดการกองทุนรวม",
                "14:บริษัทเงินทุน",
                "15:บริษัทเครดิตฟองซิเอร์",
                "16:สหกรณ์ออมทรัพย์",
                "17:บริษัทประกันชีวิต",
                "18:บุคคลธรรมดาในประเทศ",
                "19:คณะบุคคลธรรมดาในประเทศ",
                "20:กองทุนรวม",
                "21:กองทุนสำรองเลี้ยงชีพจดทะเบียน",
                "22:กองทุนสะสมพนักงาน",
                "23:กองทุนบำเหน็จบำนาญข้าราชการ",
                "24:นิติบุคคลที่จดทะเบียน",
                "25:นิติบุคคลอื่น (ไม่เสียภาษี)",
                "26:บริษัทประกันภัย",
                "27:มูลนิธิ,สมาคม,วัด,โรงเรียนที􀃉ไม่เสียภาษี",
                "28:มูลนิธิ,สมาคม ที่เสียภาษี",
                "29:บุคคลธรรมดาต่างประเทศ",
                "30:FOREIGN COMPANY ที่ตั้ง ตาม กม.ไทย",
                "31:รัฐบาลไทย",
                "32:โรงรับจำนำ",
                "33:มูลนิธิพิเศษ(ชัยพัฒนา,ส่งเสริมศิลปาชีพฯ)",
                "34:บุคคลธรรมดาที่มีถิ่นที่อยู่ต่างประเทศ"
            };
        }

        public static Dictionary<string, string> CustomerType(Dictionary<string, string> isParam)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("01", "สถาบันการเงินอื􀃉น (บ.ลิสซิ่ง)");
            result.Add("02", "รัฐวิสาหกิจ และองค์การของรัฐ");
            result.Add("03", "สหกรณ์");
            result.Add("04", "บริษัทบัตรเครดิต");
            result.Add("05", "กองทุนทดแทนความเสียหาย");
            result.Add("06", "ธนาคารออมสิน");
            result.Add("07", "ธนาคารแห่งประเทศไทย");
            result.Add("08", "ธนาคารพาณิชย์ภายในประเทศ");
            result.Add("09", "ธนาคารเพื่อการส่งออกและนำเข้า");
            result.Add("10", "สาขาธนาคารต่างประเทศ");
            result.Add("11", "บริษัทหลักทรัพย์");
            result.Add("12", "บรรษัทประกันสินเชื􀃉ออุตสาหกรรมขนาดย่อม");
            result.Add("13", "บริษัทหลักทรัพย์จัดการกองทุนรวม");
            result.Add("14", "บริษัทเงินทุน");
            result.Add("15", "บริษัทเครดิตฟองซิเอร์");
            result.Add("16", "สหกรณ์ออมทรัพย์");
            result.Add("17", "บริษัทประกันชีวิต");
            result.Add("18", "บุคคลธรรมดาในประเทศ");
            result.Add("19", "คณะบุคคลธรรมดาในประเทศ");
            result.Add("20", "กองทุนรวม");
            result.Add("21", "กองทุนสำรองเลี้ยงชีพจดทะเบียน");
            result.Add("22", "กองทุนสะสมพนักงาน");
            result.Add("23", "กองทุนบำเหน็จบำนาญข้าราชการ");
            result.Add("24", "นิติบุคคลที่จดทะเบียน");
            result.Add("25", "นิติบุคคลอื่น (ไม่เสียภาษี)");
            result.Add("26", "บริษัทประกันภัย");
            result.Add("27", "มูลนิธิ,สมาคม,วัด,โรงเรียนที􀃉ไม่เสียภาษี");
            result.Add("28", "มูลนิธิ,สมาคม ที่เสียภาษี");
            result.Add("29", "บุคคลธรรมดาต่างประเทศ");
            result.Add("30", "FOREIGN COMPANY ที่ตั้ง ตาม กม.ไทย");
            result.Add("31", "รัฐบาลไทย");
            result.Add("32", "โรงรับจำนำ");
            result.Add("33", "มูลนิธิพิเศษ(ชัยพัฒนา,ส่งเสริมศิลปาชีพฯ)");
            result.Add("34", "บุคคลธรรมดาที่มีถิ่นที่อยู่ต่างประเทศ");
            return result;
        }

        public static string[] DocumentType()
        {
            return ValidationRules.DocumentType().Split(',');
        }

        public static string[] AnyIDType(string[] isParam)
        {
            return new string[] {
                AnyIDModel.AnyIDType.MSISDN.ToString() + ":เบอร์โทรศัพท์",
                AnyIDModel.AnyIDType.NATID.ToString() + ":บัตรประชาชน"
            };
        }

        public static Dictionary<string, string> AnyIDType(Dictionary<string, string> isParam)
        {
            Dictionary<string, string> resultDict = new Dictionary<string, string>();
            resultDict.Add(AnyIDModel.AnyIDType.MSISDN.ToString(), "เบอร์โทรศัพท์");
            resultDict.Add(AnyIDModel.AnyIDType.NATID.ToString(), "บัตรประชาชน");
            return resultDict;
        }

        public static string[] RegistrationStatus(string[] isParam)
        {
            return new string[] {
                "W:อยู่ระหว่างรออนุมัติ",
                "N:ไม่ได้รับการอนุมัติ",
                "S:สำเร็จ",
                "F:ไม่สำเร็จ",
                "D:Deactivate",
                "T:System Error (Timeout)",
                "O:System Error (Offline)",
                "E:System Error (Exported)",
                "C:ยกเลิก"
            };
        }

        public static Dictionary<string, string> RegistrationStatus(Dictionary<string, string> isParam)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("W", "อยู่ระหว่างรออนุมัติ");
            result.Add("N", "ไม่ได้รับการอนุมัติ");
            result.Add("S", "สำเร็จ");
            result.Add("F", "ไม่สำเร็จ");
            result.Add("D", "Deactivate");
            result.Add("T", "System Error (Timeout)");
            result.Add("O", "System Error (Offline)");
            result.Add("E", "System Error (Exported)");
            result.Add("C", "ยกเลิก");
            return result;
        }

        public static string[] Branch(string[] isParam)
        {
            return new string[] {
                "0001:สำนักงานใหญ่",
                "0002:เพลินจิตเซ็นเตอร์",
                "0003:อโศก",
                "0004:ซีคอนสแควร์ ศรีนครินทร์",
                "0005:เพชรเกษม-กาญจนาภิเษก",
                "0006:เยาวราช",
                "0007:สี่พระยา",
                "0008:รามอินทรา",
                "0009:สุขสวัสดิ์",
                "0010:เมเจอร์ รัชโยธิน",
                "0011:นครราชสีมา",
                "0012:หาดใหญ่",
                "0013:ราชบุรี",
                "0014:พิษณุโลก",
                "0015:เชียงใหม่",
                "0016:ชลบุรี",
                "0017:ขอนแก่น",
                "0018:สุนีย์ ทาวเวอร์",
                "0019:เซ็นทรัลพลาซา ระยอง",
                "0020:สุราษฎร์ธานี",
                "0022:นครสวรรค์",
                "0023:อุดรธานี",
                "0024:นครศรีธรรมราช",
                "0025:เชียงราย",
                "0026:ภูเก็ต",
                "0027:จันทบุรี",
                "0028:ฉะเชิงเทรา",
                "0029:ชุมพร",
                "0030:สระบุรี",
                "0031:นครปฐม",
                "0032:พัทยา",
                "0033:กาญจนบุรี",
                "0034:ลำปาง",
                "0035:กระบี่",
                "0036:สุรินทร์",
                "0037:ร้อยเอ็ด",
                "0038:หัวหิน",
                "0039:ปราจีนบุรี",
                "0040:สุพรรณบุรี",
                "0041:เพชรบูรณ์",
                "0042:ตรัง",
                "0043:พระนครศรีอยุธยา",
                "0044:สมุทรปราการ",
                "0045:ปทุมธานี",
                "0046:นนทบุรี",
                "0047:แพร่",
                "0048:สกลนคร",
                "0049:สมุทรสาคร",
                "0050:ชัยภูมิ",
                "0051:ลพบุรี",
                "0052:กำแพงเพชร",
                "0053:ศรีสะเกษ",
                "0054:เพชรบุรี",
                "0055:เลย",
                "0056:พิจิตร",
                "0057:สีลม",
                "0058:สุวรรณภูมิ",
                "0059:เดอะมอลล์บางกะปิ",
                "0060:เซ็นทรัลเฟสติวัล อีสต์วิลล์",
                "0061:สระแก้ว",
                "0062:เจริญกรุง",
                "0063:กาฬสินธุ์",
                "0064:เซ็นทรัลพลาซา ปิ่นเกล้า",
                "0065:ลำพูน",
                "0066:ยโสธร",
                "0067:พระราม 3",
                "0068:พะเยา",
                "0069:ทองหล่อ",
                "0070:ชัยนาท",
                "0071:หนองคาย",
                "0072:พหลโยธินเพลส",
                "0073:ประจวบคีรีขันธ์",
                "0074:บุรีรัมย์",
                "0075:เซ็นทรัลพลาซา เวสต์เกต",
                "0076:พระราม 4",
                "0077:ปากช่อง",
                "0078:เดอะมอลล์ ท่าพระ",
                "0079:มุกดาหาร",
                "0080:มหานาค",
                "0082:แฟชั่นไอส์แลนด์",
                "0083:เซ็นทรัลพลาซา บางนา",
                "0084:พาราไดซ์พาร์ค",
                "0085:สยามพารากอน",
                "0086:ซีคอนบางแค",
                "0087:บางบอน",
                "0089:ทุ่งสง",
                "0090:สุโขทัย",
                "0091:วงเวียน 22 กรกฎา",
                "0092:อาคารเมืองไทย-ภัทร คอมเพล็กซ์",
                "0093:เซ็นทรัลเฟสติวัล เชียงใหม่",
                "0094:ศรีราชา",
                "0999:INVENTORY DEPARTMENT"
            };
        }

        public static Dictionary<string, string> Branch(Dictionary<string, string> isParam)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("0001", "สำนักงานใหญ่");
            result.Add("0002", "เพลินจิตเซ็นเตอร์");
            result.Add("0003", "อโศก");
            result.Add("0004", "ซีคอนสแควร์ ศรีนครินทร์");
            result.Add("0005", "เพชรเกษม-กาญจนาภิเษก");
            result.Add("0006", "เยาวราช");
            result.Add("0007", "สี่พระยา");
            result.Add("0008", "รามอินทรา");
            result.Add("0009", "สุขสวัสดิ์");
            result.Add("0010", "เมเจอร์ รัชโยธิน");
            result.Add("0011", "นครราชสีมา");
            result.Add("0012", "หาดใหญ่");
            result.Add("0013", "ราชบุรี");
            result.Add("0014", "พิษณุโลก");
            result.Add("0015", "เชียงใหม่");
            result.Add("0016", "ชลบุรี");
            result.Add("0017", "ขอนแก่น");
            result.Add("0018", "สุนีย์ ทาวเวอร์");
            result.Add("0019", "เซ็นทรัลพลาซา ระยอง");
            result.Add("0020", "สุราษฎร์ธานี");
            result.Add("0022", "นครสวรรค์");
            result.Add("0023", "อุดรธานี");
            result.Add("0024", "นครศรีธรรมราช");
            result.Add("0025", "เชียงราย");
            result.Add("0026", "ภูเก็ต");
            result.Add("0027", "จันทบุรี");
            result.Add("0028", "ฉะเชิงเทรา");
            result.Add("0029", "ชุมพร");
            result.Add("0030", "สระบุรี");
            result.Add("0031", "นครปฐม");
            result.Add("0032", "พัทยา");
            result.Add("0033", "กาญจนบุรี");
            result.Add("0034", "ลำปาง");
            result.Add("0035", "กระบี่");
            result.Add("0036", "สุรินทร์");
            result.Add("0037", "ร้อยเอ็ด");
            result.Add("0038", "หัวหิน");
            result.Add("0039", "ปราจีนบุรี");
            result.Add("0040", "สุพรรณบุรี");
            result.Add("0041", "เพชรบูรณ์");
            result.Add("0042", "ตรัง");
            result.Add("0043", "พระนครศรีอยุธยา");
            result.Add("0044", "สมุทรปราการ");
            result.Add("0045", "ปทุมธานี");
            result.Add("0046", "นนทบุรี");
            result.Add("0047", "แพร่");
            result.Add("0048", "สกลนคร");
            result.Add("0049", "สมุทรสาคร");
            result.Add("0050", "ชัยภูมิ");
            result.Add("0051", "ลพบุรี");
            result.Add("0052", "กำแพงเพชร");
            result.Add("0053", "ศรีสะเกษ");
            result.Add("0054", "เพชรบุรี");
            result.Add("0055", "เลย");
            result.Add("0056", "พิจิตร");
            result.Add("0057", "สีลม");
            result.Add("0058", "สุวรรณภูมิ");
            result.Add("0059", "เดอะมอลล์บางกะปิ");
            result.Add("0060", "เซ็นทรัลเฟสติวัล อีสต์วิลล์");
            result.Add("0061", "สระแก้ว");
            result.Add("0062", "เจริญกรุง");
            result.Add("0063", "กาฬสินธุ์");
            result.Add("0064", "เซ็นทรัลพลาซา ปิ่นเกล้า");
            result.Add("0065", "ลำพูน");
            result.Add("0066", "ยโสธร");
            result.Add("0067", "พระราม 3");
            result.Add("0068", "พะเยา");
            result.Add("0069", "ทองหล่อ");
            result.Add("0070", "ชัยนาท");
            result.Add("0071", "หนองคาย");
            result.Add("0072", "พหลโยธินเพลส");
            result.Add("0073", "ประจวบคีรีขันธ์");
            result.Add("0074", "บุรีรัมย์");
            result.Add("0075", "เซ็นทรัลพลาซา เวสต์เกต");
            result.Add("0076", "พระราม 4");
            result.Add("0077", "ปากช่อง");
            result.Add("0078", "เดอะมอลล์ ท่าพระ");
            result.Add("0079", "มุกดาหาร");
            result.Add("0080", "มหานาค");
            result.Add("0082", "แฟชั่นไอส์แลนด์");
            result.Add("0083", "เซ็นทรัลพลาซา บางนา");
            result.Add("0084", "พาราไดซ์พาร์ค");
            result.Add("0085", "สยามพารากอน");
            result.Add("0086", "ซีคอนบางแค");
            result.Add("0087", "บางบอน");
            result.Add("0089", "ทุ่งสง");
            result.Add("0090", "สุโขทัย");
            result.Add("0091", "วงเวียน 22 กรกฎา");
            result.Add("0092", "อาคารเมืองไทย-ภัทร คอมเพล็กซ์");
            result.Add("0093", "เซ็นทรัลเฟสติวัล เชียงใหม่");
            result.Add("0094", "ศรีราชา");
            result.Add("0999", "INVENTORY DEPARTMENT");
            return result;
        }

        public static string TransactionStatus(ProxyTransactionStateCategory transactionStatus)
        {
            switch (transactionStatus)
            {
                case ProxyTransactionStateCategory.Submitted:
                    return "อยู่ระหว่างรออนุมัติ";
                case ProxyTransactionStateCategory.Approved:
                    return "อยู่ระหว่างรออนุมัติ";
                case ProxyTransactionStateCategory.Success:
                    return "สำเร็จ";
                case ProxyTransactionStateCategory.Rejected:
                    return "ไม่ได้รับการอนุมัติ";
                case ProxyTransactionStateCategory.Failed:
                    return "ไม่สำเร็จ";
                case ProxyTransactionStateCategory.Timeout:
                    return "System Error (Timeout)";
                case ProxyTransactionStateCategory.Offline:
                    return "System Error (Offline)";
                case ProxyTransactionStateCategory.Exported:
                    return "System Error (Exported)";
                default:
                    return "N/A";
            }
        }

        #endregion Static Type of System

        public static string GetUserActionNameText(UserAction userAction)
        {
            try
            {
                return userAction.ByUser.Name;
            }
            catch
            {
                return "N/A";
            }
        }
        public static string GetUserActionTimestampText(UserAction userAction)
        {
            if (userAction == null)
                return "N/A";
            else
                return userAction.Timestamp.ToString("dd/MM/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
        }

        public class CustomerInfo
        {
            public static string GetBranchFromCIS(string code)
            {
                try
                {
                    string branchCode = int.Parse(code).ToString("0000");
                    return branchCode + " " + CommonUtilities.Branch(new Dictionary<string, string>())[branchCode];
                }
                catch
                {
                    return code;
                }
            }

            public static string GetBtirthDate(DateTime date)
            {
                return date.ToString("dd/MM/", System.Globalization.CultureInfo.InvariantCulture) + (date.Year + 543).ToString("0000");
            }

            public static string GetNomineeLevel(string code)
            {
                switch (code)
                {
                    case "3":
                        return "ระดับ 3 (สูง)";
                    case "2":
                        return "ระดับ 2 (กลาง)";
                    case "1":
                        return "ระดับ 1 (ต่ำ)";
                    default:
                        return code;
                }
            }

            public static string GetFATCA(string code)
            {
                switch (code)
                {
                    case "1":
                        return "Thai Person";
                    case "2":
                        return "US Person";
                    case "3":
                        return "Non US Person";
                    default:
                        return code;
                }
            }

            public static string GetSanctionListFromCIS(string code)
            {
                switch (code)
                {
                    case "N":
                        return "อนุญาตให้ทำรายการ";
                    case "Y":
                        return "ไม่อนุญาตให้ทำรายการ";
                    default:
                        return code;
                }
            }
        }

        public class TransactionInfo
        {
            public static string ApprovedResult(ProxyTransaction trans)
            {
                try
                {
                    if (trans.CurrentState != null)
                    {
                        if (trans.CurrentStateCategory == ProxyTransactionStateCategory.Rejected)
                        {
                            return "ไม่อนุมัติ";
                        }
                        else if (trans.States != null)
                        {
                            if (trans.States.Any(x => x.StateCategory == ProxyTransactionStateCategory.Approved))
                            {
                                return "อนุมัติ";
                            }
                        }
                    }

                    return "";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }

            public static string ApprovedReason(ProxyTransaction trans)
            {
                try
                {
                    if (trans.CurrentState != null)
                    {
                        if (trans.CurrentStateCategory == ProxyTransactionStateCategory.Rejected)
                        {
                            return trans.CurrentState.Remark;
                        }
                        else if (trans.States != null)
                        {
                            if (trans.States.Any(x => x.StateCategory == ProxyTransactionStateCategory.Approved))
                            {
                                return trans.States.Where(x => x.StateCategory == ProxyTransactionStateCategory.Approved).SingleOrDefault().Remark;
                            }
                        }
                    }

                    return "";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }

            public static string ApprovedBy(ProxyTransaction trans)
            {
                try
                {
                    if (trans.CurrentState != null)
                    {
                        if (trans.CurrentStateCategory == ProxyTransactionStateCategory.Rejected)
                        {
                            return  CommonUtilities.GetUserActionNameText(trans.CurrentState.CreateAction);
                        }
                        else if (trans.States != null)
                        {
                            if (trans.States.Any(x => x.StateCategory == ProxyTransactionStateCategory.Approved))
                            {
                                return CommonUtilities.GetUserActionNameText(trans.States.Where(x => x.StateCategory == ProxyTransactionStateCategory.Approved).SingleOrDefault().CreateAction);
                            }
                        }
                    }

                    return "";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }

            public static string ApprovedTimestamp(ProxyTransaction trans)
            {
                try
                {
                    if (trans.CurrentState != null)
                    {
                        if (trans.CurrentStateCategory == ProxyTransactionStateCategory.Rejected)
                        {
                            return CommonUtilities.GetUserActionTimestampText(trans.CurrentState.CreateAction);
                        }
                        else if (trans.States != null)
                        {
                            if (trans.States.Any(x => x.StateCategory == ProxyTransactionStateCategory.Approved))
                            {
                                return CommonUtilities.GetUserActionTimestampText(trans.States.Where(x => x.StateCategory == ProxyTransactionStateCategory.Approved).SingleOrDefault().CreateAction);
                            }
                        }
                    }

                    return "";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        public class Messages
        {
            public const string CommonErrorText = "ระบบเกิดข้อผิดพลาด กรุณาติดต่อผู้ดูแลระบบ";
        }
    }
}