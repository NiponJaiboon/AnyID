using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{
    public static class Messages
    {
        public static class Presentation
        {
        }

        public static class Security
        {
            //public const String NewPasswordsNotConfirmed = "The new and the confirmed passwords are not the same";
            //public static Message PasswordUserIsNull = new Message(new LS("th-TH", ""), new LS("en-US", "The user owning the password is null."));
            /// <summary>
            /// Format()
            /// </summary>
            public static readonly Message FailPasswordHistory = new Message("th-TH", "รหัสผ่านนี้เคยใช้ไปแล้ว", "en-US", "The new password is the same as one of the previous passwords");


            /// <summary>
            /// Format()
            /// </summary>
            public static readonly Message NewPasswordsNotConfirmed = new Message("th-TH", "รหัสผ่านใหม่ทั้งสองไม่ตรงกัน", "en-US", "The new passwords are not the same");

            /// <summary>
            /// Format()
            /// </summary>
            public static readonly Message NoncomformantPassword = new Message("th-TH", "รหัสผ่านที่ตั้งใหม่ ไม่ผ่านข้อกำหนดในการตั้งรหัสผ่านของระบบ(ต้องประกอบด้วย A-Z a-z 0-9 และอักษรพิเศษรวมกัน 8-10 ตัวอักษร)", "en-US", "Your password must be at least 8 character combination of digits, special character, upper and lower case");

            /// <summary>
            /// Format(The number of days)
            /// </summary>

            //Active Directory
            public static readonly Message TheServerCouldNotBeContacted = new Message("th-TH", "ไม่สามารถติดต่อ Active Directory Server", "en-US", "The AD server could not be contacted.");
            public static readonly Message PasswordIsNull = new Message("th-TH", "ไม่มีรหัสผ่าน", "en-US", "The password of the user is null.");
            public static readonly Message PasswordIsExpired = new Message("th-TH", "รหัสผ่านหมดอายุ กรุณาติดต่อผู้ดูแลระบบหรือธนาคาร", "en-US", "Your password has expired.");
            public static readonly Message UserHasBeenInactiveLongerThanLimit = new Message("th-TH", "ผู้ใช้ถูกระงับเนื่องจากไม่ได้ใช้ระบบนานเกิน {0} วัน กรุณาติดต่อธนาคาร", "en-US", "The user has been inactive for more than {0} days.  Please contact your administrator .");
            public static readonly Message UserHasBeenInactiveLongerThanLimitAD = new Message("th-TH", "ผู้ใช้ถูกระงับเนื่องจากไม่ได้ใช้ระบบนานเกิน {0} วัน กรุณาติดต่อผู้ดูแลระบบ", "en-US", "The user has been inactive for more than {0} days.  Please contact your administrator .");

            public static readonly Message UserIsDisable = new Message("th-TH", "ผู้ใช้ถูกระงับการใช้ระบบ กรุณาติดต่อผู้ดูแลระบบ", "en-US", "");
            //public static readonly Message UserIsSuspendedForTooManyConsecutiveLoginFailures = new Message(new LS("th-TH", "เข้าระบบไม่สำเร็จติดต่อกันเกินจำนวนที่อนุญาต กรุณาติดต่อผู้ดูแลระบบ", new LS("en-US", "This user has been disable because the number of consecutive failed login attempts exceeds limit. Please contact your administrator.");
            public static readonly Message UserIsSuspendedForTooManyConsecutiveLoginFailures = new Message("th-TH", "ผู้ใช้ถูกระงับเพราะล็อกอินไม่สำเร็จติดต่อกัน กรุณาติดต่อผู้ดูแลระบบ", "en-US", "This user has been disable because the number of consecutive failed login attempts exceeds limit. Please contact your administrator.");//by kittikun
            public static readonly Message UserIsNotEffective = new Message("th-TH", "ผู้ใช้ยังไม่ได้รับการอนุมัติให้ใช้ระบบได้ กรุณาติดต่อผู้ดูแลระบบ", "en-US", "The user has not been approved.");
            public static readonly Message UserIsExpired = new Message("th-TH", "ผู้ใช้หมดอายุุแล้ว กรุณาติดต่อผู้ดูแลระบบ", "en-US", "The user has been expired.");

            //Add by Kunakorn
            public static readonly Message UserIsDisableForExcessiveConsecutiveFailedLoginUnLimit = new Message("th-TH", "ผู้ใช้เข้าระบบไม่สำเร็จ {0} จาก {1} ครั้ง", "en-US", "This user has been disable because the number of consecutive failed login attempts exceeds {0} times. Please contact your administrator.");

            #region Codes for Self-Authenticated User Login Exceptions

            public static readonly Message UsernameIsInvalidCode = new Message("th-TH", "i001 - ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง", "en-US", "i001 - Invalid user id or password");//"Log on failed.";
            public static readonly Message PasswordIsInvalidCode = new Message("th-TH", "i002 - ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง", "en-US", "i002 - Invalid user id or password");//"Log on failed.";
            public static readonly Message UserIsDisableCode = new Message("th-TH", "i003", "en-US", "i003");
            public static readonly Message UserIsSuspendedForTooManyConsecutiveLoginFailuresCode = new Message("th-TH", "i004", "en-US", "i004");
            public static readonly Message UserIsNotEffectiveCode = new Message("th-TH", "i005", "en-US", "i005");
            public static readonly Message UserIsExpiredCode = new Message("th-TH", "i006", "en-US", "i006");

            #endregion


            //public static readonly Message UserIsDisableForExcessiveConsecutiveFailedLogin = new Message(new LS("th-TH", "This user has been disable because the number of consecutive failed login attempts exceeds limit.", new LS("en-US", "This user has been disable because the number of consecutive failed login attempts exceeds limit.");


            public static readonly Message LoginFailed = new Message("th-TH", "ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง", "en-US", "Login name or password is incorrect.");//"Log on failed.";
            public static readonly Message PasswordIsInvalid = new Message("th-TH", "i002", "en-US", "i002");//"Log on failed.";
            public static readonly Message UserNameViolatesPolicy = new Message("th-TH", "ชื่อผู้ใช้ไม่เป็นไปตามนโยบายความมั่นคง", "en-US", "User name violates the security policy.");
            public static readonly Message UserNameIsNotAllowed = new Message("th-TH", "ชื่อผู้ใช้ว่างเปล่าหรือไม่ถูกต้อง", "en-US", "The user name is not allowed.");
            public static readonly Message UserPersonIsNull = new Message("th-TH", "", "en-US", "The person owning the user account is null.");
            public static readonly Message MultipleLogon = new Message("th-TH", "ชื่อผู้ใช้งานนี้กำลังเข้าใช้บริการอยู่", "en-US", "Multiple Logon Not Allow.");
        }

        public static class Adapter
        {
            // MAPS Adapter
            public static readonly Message NoRecordsFound = new Message("th-TH", "ไม่พบรายการ", "en-US", "No Records Found.");
            public static readonly Message NotAuthorisedToThisAccount = new Message("th-TH", "", "en-US", "Not authorised to this account.");
            public static readonly Message CIFNumberNotFound = new Message("th-TH", "หมายเลข CIF ไม่ถูกต้อง", "en-US", "CIF Number Not Found.");
            public static readonly Message ClosedAccount = new Message("th-TH", "บีญชีปิดแล้ว", "en-US", "Close account.");
            public static readonly Message DormantAccount = new Message("th-TH", "บัญชีไม่เคลื่อนไหว", "en-US", "Dormant Account.");
            public static readonly Message InvalidAccountNumber = new Message("th-TH", "หมายเลขบัญชีไม่ถูกต้อง", "en-US", "Invalid Account Number.");
            public static readonly Message InvalidAccountType = new Message("th-TH", "ประเภทบัญชีไม่ถูกต้อง", "en-US", "Invalid Account Type.");
            public static readonly Message AccountNumberNotFound = new Message("th-TH", "ไม่พบหมายเลขบัญชี", "en-US", "Account Number Not Found.");
            public static readonly Message ChequeBookNotYetIssue = new Message("th-TH", "", "en-US", "Cheque Book Not Yet Issue.");
            public static readonly Message UnabletoInsertLogtoMAPSDB = new Message("th-TH", "ไม่สามารถบันทึกรายการเข้าฐานข้อมูล MAPS", "en-US", "Unable to Insert Log to MAPS DB.");
        }

        public static class Genaral
        {
            //public static readonly Message BillPaymentServiceBankAccountEffectivePeriodIsEmpty = new Message(new LS("th-TH", "ท่านไม่ได้รับอนุญาตให้พิจารณาธุรกรรมนี้", new LS("en-US", "You are not permitted to consider the transaction.");
            public static readonly Message TransactionNotPermitToConsider = new Message("th-TH", "ท่านไม่ได้รับอนุญาตให้พิจารณาธุรกรรมนี้", "en-US", "You are not permitted to consider the transaction.");
            public static readonly Message TransactionApproved = new Message("th-TH", "รายการนี้ได้ถูกส่งไปรออนุมัติเรียบร้อยแล้ว", "en-US", "Transaction is pending approval.");
            public static readonly Message UserTransactionWaitingApproved = new Message("th-TH", "รายการ{0} ถูกส่งไปรออนุมัติเรียบร้อยแล้ว", "en-US", "");
            public static readonly Message TransactionException = new Message("th-TH", "ข้อผิดพลาด : {0}", "en-US", "Error : {0}");
            public static readonly Message Error = new Message("th-TH", "ไม่สามารถทำรายการได้", "en-US", "Error");
            public static readonly Message Success = new Message("th-TH", "เรียบร้อย", "en-US", "success");
            public static readonly Message PendingApproval = new Message("th-TH", "รอการอนุมัติ", "en-US", "Pending Approval.");
            public static readonly Message IsNotMemberFunction = new Message("th-TH", "ไม่มีสิทธิ์ทำรายการ", "en-US", "You not Permistion.");
            public static readonly Message IsNotAddMemberUser = new Message("th-TH", "คุณไม่มีสิทธิ์เพิ่มผู้ใช้งาน", "en-US", "You not Permistion to add user.");
            public static readonly Message IsExistingUserLoginName = new Message("th-TH", "ชื่อเข้าใช้งาน มีอยู่แล้วในระบบ", "en-US", "Login name is system.");
            public static readonly Message IsNotAddMemberGroupUser = new Message("th-TH", "คุณไม่มีสิทธิ์เพิ่มผู้ใช้เข้ากลุ่ม", "en-US", "You not Permistion to add member group user.");
            public static readonly Message IsNotReturnTransaction = new Message("th-TH", "รายการนี้สามารถเลือกอนุมัติหรือไม่อนุมัติเท่านั้น", "en-US", "transaction is not return.");
            
            public static readonly Message InitiateEntityWithNullOrEmptyEffectivePeriod = new Message("th-TH", "กำหนดการเริ่มใช้งานด้วยช่วงเวลาที่ไม่ถูกต้อง {0}", "en-US", "Initiating a temporal entity with null or empty effective period.");
            public static readonly Message TerminateEntityWithNullOrEmptyEffectivePeriod = new Message("th-TH", "ยุติการใช้งานด้วยวันเวลาที่มาก่อนวันที่มีผลใช้งาน {0}", "en-US", "Terminating a temporal entity with expiry date that was before the effective date.");

            #region Approval
            public static readonly Message Approval = new Message("th-TH", "อนุมัติ : {0}", "en-US", "Approval : {0}.");
            public static readonly Message Reject = new Message("th-TH", "ไม่อนุมัติ : {0}", "en-US", "Reject : {0}.");
            public static readonly Message Return = new Message("th-TH", "ส่งแก้ไข : {0}", "en-US", "Return : {0}.");
            public static readonly Message ApprovalSuccess = new Message("th-TH", "สำเร็จ", "en-US", "Success.");
            #endregion
        }

        public static class ChequesDividend
        {
            public static readonly Message UploadCompleted = new Message("th-TH", "อัพโหลด{0} สำเร็จ", "en-US", "Upload {0} completed");
            public static readonly Message UploadFailed = new Message("th-TH", "อัพโหลด{0} ล้มเหลว", "en-US", "Upload {0} failed");
            public static readonly Message UpdateCompleted = new Message("th-TH", "อัพเดท{0} สำเร็จ", "en-US", "Update {0} completed");
            public static readonly Message UpdateFailed = new Message("th-TH", "อัพเดท{0} ล้มเหลว", "en-US", "Update {0} failed");
        }

        public static class UserGroupUser
        {
            public static readonly Message TerminateUserGroupUser = new Message("th-TH", "นำผู้ใช้ {0} ออกจากกลุ่ม {1}", "en-US", "Terminate user {0} from group {1}.");
            public static readonly Message AddUserGroupUser = new Message("th-TH", "นำผู้ใช้ {0} เข้ากลุ่ม {1}", "en-US", "Add user {0} to group {1}.");
            public static readonly Message UserInGroup = new Message("th-TH", "ผู้ใช้งานอยู่ในกลุ่มแล้ว", "en-US", "User is exist to group.");
            public static readonly Message UserInGroupPendingApproval = new Message("th-TH", "ผู้ใช้งานถูกนำเข้ากลุ่มแล้ว รอการอนุมัติ", "en-US", "User is exist to group and pending apporval.");
        }

        public static class MemberUserGroup
        {
            public static readonly Message TerminateMemberUserGroup = new Message("th-TH", "ลบกลุ่ม {0}", "en-US", "Terminate member group {0}.");
            public static readonly Message AddMemberUserGroup = new Message("th-TH", "เพิ่มกลุ่ม {0}", "en-US", "Add member group {0}.");
        }

        public static class Member
        {
            public static readonly Message TerminateMember = new Message("th-TH", "ลบสมาชิก {0}", "en-US", "Terminate member {0}.");
            public static readonly Message AddMember = new Message("th-TH", "เพิ่มสมาชิก {0}", "en-US", "Add member {0}.");
        }

        public static class FunctionWorkFlow
        {
            public static readonly Message TerminateFunctionWorkFlow = new Message("th-TH", "ลบสิทธิ์ {0} ออกจากกลุ่ม {1}", "en-US", "Terminate functionWork flow {0} from group {1}.");
            public static readonly Message TerminateMemberFunction = new Message("th-TH", "ยกเลิกบริการ", "en-US", "Terminate member functionWork.");
            public static readonly Message AddMemberFunction = new Message("th-TH", "สมัครบริการ", "en-US", "Add member functionWork.");
            public static readonly Message AddFunctionWorkFlow = new Message("th-TH", "เพิ่มสิทธิ์ {0} ให้กลุ่ม {1}", "en-US", "Add functionWork flow {0} to group {1}.");
            public static readonly Message OpenTransactionsUsingWorkflow = new Message("th-TH", "ไม่สามารถทำการยกเลิกสิทธิการใช้งานนี้ได้ เนื่องจากมี {0} ธุรกรรมที่ใช้สิทธิ์นี้ และยังดำเนินการไม่แล้วเสร็จ", "en-US", "Don't Terminate FunctionWorkflow {0}.");
        }

        public static class MemberBankAccount
        {
            public static readonly Message TerminateMemberBankAccount = new Message("th-TH", "ลบสิทธิ์ {0} ออกจากกลุ่ม {1}", "en-US", "Terminate functionWork flow {0} from group {1}.");
            public static readonly Message AddMemberBankAccount = new Message("th-TH", "เพิ่มบัญชีปลายทาง {0} หมายเลขบัญชี {1}", "en-US", "Add bank account {0} account no. {1}.");
        }

        public static class ServiceFeeSchdule
        {
            //public static readonly Message TerminateMemberServiceFeeSchdule = new Message(new LS("th-TH", "ลบสิทธิ์ {0} ออกจากกลุ่ม {1}", new LS("en-US", "Terminate functionWork flow {0} from group {1}.");
            public static readonly Message AddMemberServiceFeeSchdule = new Message("th-TH", "แก้ไขตารางค่าธรรมเนียมของสมาชิก {0} ให้กับ {1}", "en-US", "Edit Service Fee Schedule {0} member {1}.");
            public static readonly Message AddServiceFeeSchdule = new Message("th-TH", "เพิ่มตารางค่าธรรมเนียมสำหรับบริการโอนเงิน {0}", "en-US", "Add New Fee Schedule for a Service. {0}");
        }

        public static class MemberUser
        {
            public static readonly Message Active = new Message("th-TH", "ใช้งานได้", "en-US", "Active");
            public static readonly Message Disable = new Message("th-TH", "ระงับใช้งาน", "en-US", "Suspended");
            public static readonly Message Expire = new Message("th-TH", "ยกเลิกใช้งาน", "en-US", "Canceled");
            public static readonly Message Lock = new Message("th-TH", "ระงับใช้งาน", "en-US", "Lock");

            public static readonly Message ExpireUser = new Message("th-TH", "ยกเลิกผู้ใช้งาน : {0}", "en-US", "Expire user : {0}.");
            public static readonly Message DisableUser = new Message("th-TH", "ระงับผู้ใช้ : {0}", "en-US", "Disable user : {0}.");
            public static readonly Message EnableUser = new Message("th-TH", "ยกเลิกระงับใช้งาน : {0}", "en-US", "Enable user : {0}.");
            public static readonly Message ReinStateUser = new Message("th-TH", "ยกเลิกระงับผู้ใช้เนื่องจากไม่ได้ใช้ระบบนานเกิน : {0}", "en-US", " user has been inactive for more than : {0}.");
            public static readonly Message ConseccutiveUser = new Message("th-TH", "ยกเลิกระงับผู้ใช้เนื่องจากพยายามล็อคอิน ไม่สำเร็จติดต่อกันเกินกำหนด : {0}", "en-US", "user has been disable because the number of consecutive failed login attempts : {0}.");
            public static readonly Message AddMemberUser = new Message("th-TH", "เพิ่มผู้ใช้งาน : {0}", "en-US", "Add memberuser : {0}.");
            public static readonly Message EditMemberUser = new Message("th-TH", "แก้ไขผู้ใช้งาน : {0}", "en-US", "Edit memberuser : {0}.");
        }

        public static class Action
        {
            #region user management
            public static readonly Message ModifySecurityPolicy = new Message("th-TH", "เปลี่ยนนโยบายความมั่นคง", "en-US", "Change Policy.");

                #region Bank  system
                public static readonly Message ExpireUserBank = new Message("th-TH", "ยกเลิกผู้ใช้งานของธนาคาร", "en-US", "Expire user of Bank system.");
                public static readonly Message DisableUserBank = new Message("th-TH", "ระงับผู้ใช้ของธนาคาร", "en-US", "Disable user of Bank system.");
                public static readonly Message EnableUserBank = new Message("th-TH", "ยกเลิกระงับใช้งานของธนาคาร", "en-US", "Enable user of Bank system.");
                public static readonly Message ReinStateUserBank = new Message("th-TH", "ยกเลิกระงับผู้ใช้เนื่องจากไม่ได้ใช้ระบบนานเกินของธนาคาร", "en-US", " user has been inactive for more than of Bank system.");
                public static readonly Message ConseccutiveUserBank = new Message("th-TH", "ยกเลิกระงับผู้ใช้ที่พยายามล็อคอินเกินของธนาคาร", "en-US", "user has been disable because the number of consecutive failed login attempts of Bank system.");
                public static readonly Message AddMemberUserBank = new Message("th-TH", "เพิ่มผู้ใช้งานของธนาคาร", "en-US", "Add memberuser of Bank system.");
                public static readonly Message ChangeInformationBank = new Message("th-TH", "แก้ไขข้อมูลผู้ใช้งานของธนาคาร", "en-US", "Change information of Bank system.");
            
                #endregion
                //AddMemberUserBank

                #region Client system
                public static readonly Message ExpireUserClient = new Message("th-TH", "ยกเลิกผู้ใช้งานของลูกค้า", "en-US", "Expire user Client system.");
                public static readonly Message DisableUserClient = new Message("th-TH", "ระงับผู้ใช้ของลูกค้า", "en-US", "Disable user Client system.");
                public static readonly Message EnableUserClient = new Message("th-TH", "ยกเลิกระงับใช้งานของลูกค้า", "en-US", "Enable user Client system.");
                public static readonly Message ReinStateUserClient = new Message("th-TH", "ยกเลิกระงับผู้ใช้เนื่องจากไม่ได้ใช้ระบบนานเกินของลูกค้า", "en-US", " user has been inactive for more than Client system.");
                public static readonly Message ConseccutiveUserClient = new Message("th-TH", "ยกเลิกระงับผู้ใช้ที่พยายามล็อคอินเกินของลูกค้า", "en-US", "user has been disable because the number of consecutive failed login attempts Client system.");
                public static readonly Message AddMemberUserClient = new Message("th-TH", "เพิ่มผู้ใช้งานของลูกค้า", "en-US", "Add memberuser Client system.");
                public static readonly Message ChangeInformationClient = new Message("th-TH", "แก้ไขข้อมูลผู้ใช้งานของลูกค้า", "en-US", "Change information Client system.");
                #endregion
            
            #endregion
                public static readonly Message Approval = new Message("th-TH", "อนุมัติ", "en-US", "Approval");
                public static readonly Message Reject = new Message("th-TH", "ไม่อนุมัติ", "en-US", "Reject");
                public static readonly Message Return = new Message("th-TH", "ส่งแก้ไข", "en-US", "Return");
                public static readonly Message Submit = new Message("th-TH", "ส่งอนุมัติ", "en-US", "Submit");//by kunakorn
        }

        public static class ApproveTransaction
        {
            public static readonly Message WorkflowExpired = new Message("th-TH", "สิทธิ์การใช้งานของบริการ : {0} ถูกยกเลิก", "en-US", ": {0}.");
        }

        #region LDAP Authentication Exceptions

        public const String TheLDAPServerIsUnavailable = "The LDAP server is unavailable.";
        public const String TheServerCouldNotBeContacted = "The server could not be contacted.";

        #endregion

        public const String FileFormatFilePathIsNotDefined = "The file path is not defined.";
        public const String MoneyDifferentCurrencies = "Money amounts are of different currencies.";
        public const String MoneyOneOrBothBothOperandsAreNull = "One or both operands of the money operator '{0}' are null.";
        public const String MLSUndefinedLanguageCode = "The language code is undefined ";

        public const String PersonIsNull = "The user creating or updating data object is null.";

        public const String SecurityNewPasswordsNotConfirmed = "The new and the confirmed passwords are not the same";
        //public const String SecurityPasswordIsNull = "Fatal error: the user has no current password";
        public const String SecurityPasswordIsExpired = "รหัสผ่านหมดอายุ กรุณาติดต่อผู้ดูแลระบบหรือธนาคาร";
        public const String SecurityPasswordIsNull = "The password is null or empty.";
        public const String SecurityPasswordIsWeak = "The password is weak.";
        public const String SecurityPasswordLengthViolatesPolicy = "The length of password violates policy.";
        public const String SecurityPasswordUserIsNull = "The user owning the password is null.";

        public const String SecurityUserIsDisable = "ชื่อผู้ใช้ระบบถูกระงับ กรุณาติดต่อธนาคาร";
        public const String SecurityUserIsExpired = "ชื่อผู้ใช้ระบบถูกยกเลิก กรุณาติดต่อธนาคาร";
        public const String SecurityUserIsNull = "The person owning the user account is null.";
        public const String SecurityUserPersonIsNull = "The person owning the user account is null.";

        public const String SecurityUsernameIsNull = "The user name is null or invisible.";
        public const String SecurityUserNameLengthViolatesPolicy = "The user name is not allowes.";

        public const String SecurityLogonFailed = "ชื่อผู้ใช้ระบบหรือรหัสผ่านไม่ถูกต้อง";//"Log on failed.";
        public const String SecurityFailPasswordHistory = "รหัสผ่านนี้ถูกใช้ไปแล้ว";
        public const String SecurityNoncomformantPassword = "รหัสผ่านที่ตั้งใหม่ ไม่ผ่านข้อกำหนดในการตั้งรหัสผ่านของระบบ(ต้องประกอบด้วย A-Z a-z 0-9 และอักษรพิเศษรวมกัน 8-10 ตัวอักษร)";

        public static String DataLineIsTooShort(int dataLineLength, int fieldLength)
        {
            return String.Format("The length of the data record ({0}) is shorter than the field required ({1}).",
                                dataLineLength, fieldLength);
        }
        public static String DateStringIncorrectFormat(String value, String format)
        {
            return String.Format("The date '{0}' is not in the format '{1}'.", value, format);
        }
        public static String TimeStringIncorrectFormat(String value, String format)
        {
            return String.Format("The time '{0}' is not in the format '{1}'.", value, format);
        }
        public const String DetailRecordFormatNotDefined = "Detail format of the file is null.";

        public const String FundTransferNoSrcOrDstBankAccount = "FundTransfer: No source or desination bank account.";
        //public static String FundTransferNoSrcOrDstBankAccount()
        //{
        //    return fundTransferNoSrcOrDstBankAccount;
        //}

        public static String LiteralFieldConvertFailed(String expected, String actual)
        {
            return String.Format("LiteralField.Convert(): the expected value '{0}' does not match the actual value '{1}'",
                                expected, actual);
        }
        public static String Decimal_x_100FieldConvertFailed(String actual)
        {
            return String.Format("Decimal_x_100Field.Convert(): the field value '{0}' can not be converted to decimal.",
                                actual);
        }

        public static String DecimalFieldConvertFailed(String actual)
        {
            return String.Format("DecimalField.Convert(): the field value '{0}' can not be converted to decimal.",
                                actual);
        }
        public static String IntegerFieldConvertFailed(String actual)
        {
            return String.Format("IntegerField.Convert(): the field value '{0}' can not be converted to integer.",
                                actual);
        }
        public static String LongFieldConvertFailed(String actual)
        {
            return String.Format("LongField.Convert(): the field value '{0}' can not be converted to long integer.",
                                actual);
        }

        public static String NoQualifiedBracket(String amount)
        {
            return String.Format("No qualified rate bracket for {0}.", amount);
        }

        public static String CantReadFile(String filePath)
        {
            return String.Format("Can read file {0}.", filePath);
        }

        public static String CantWriteFile(String filePath)
        {
            return String.Format("Can write file {0}.", filePath);
        }

        //public const String InconsistentHeaderRecordExtractionParameter = "Either the Header record format is not defined.";
    }
}