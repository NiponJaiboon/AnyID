
using iSabaya;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
namespace TestFramework
{
    [TestClass]
    public class DatabaseSchema : TestBase
    {

        [TestMethod]
        public void Generating_Database_Schema_Script()
        {
            NHibernate.Cfg.Configuration hibernateConfig = new NHibernate.Cfg.Configuration().Configure();
            hibernateConfig.AddAssembly("iSabaya.ORM");
            hibernateConfig.AddAssembly("iSabaya.HRM.ORM");

            //hibernateConfig.AddAssembly(typeof(iSISModel.Party).Assembly);
            SchemaExport schemaGenerator = new SchemaExport(hibernateConfig);
            schemaGenerator.SetOutputFile("schema.sql");
            schemaGenerator.Execute(true, false, false);
        }
        //[TestMethod]
        //public void Test_Schedule()
        //{
          
        //    ScheduleSpecificDate specificDateHelper = new ScheduleSpecificDate();
        //    IList<ScheduleSpecificDate> scheduleDetails = new IList<ScheduleSpecificDate>();
        //    specificDateHelper.Date = ctrlSpecificDate.Date;
        //    // 1. ตรวจสอบว่าสามารถ initial ได้หรือไม่
        //    if (specificDateHelper == null)
        //    {
        //        message = "Cannot Initial Schedule Detail, Please Contact Administrator";
        //        warningCount++;
        //    }

        //    // 1. ตรวจว่าวันที่เพิ่มไม่ใช่วันในอดีต
        //    if (ctrlSpecificDate.Date.Date < DateTime.Now.Date)
        //    {
        //        warningCount++;
        //        message = String.Format("คุณไม่สามารถ {0} ได้ เนื่องจากเป็นวันหยุดในอดีต<br/>", functionName);
        //    }

        //    // 2. ตรวจสอบว่ามีวันที่นี้อยู่ในระบบแล้วหรือยัง?
        //    if (specificDateHelper != null && scheduleDetails != null)
        //    {
        //        checkIsExisting(ref message, ref warningCount, specificDateHelper, scheduleDetails);
        //    }

        //    // 3. ตรวจสอบว่าเป็นรายการที่ยังทำไม่เสร็จหรือไม่?
        //    if (CheckIsNotFinalized(SessionContext, 1, ctrlSpecificDate.Date))
        //    {
        //        warningCount++;
        //        message = String.Format("{0}<br/>", Messages.Genaral.TransactionPendingApproval.Format(lange, functionName));
        //    }

        //    // 4. ตรวจสอบว่ามีสิทธิ์ทำรายการหรือไม่?
        //    MaintenanceWorkflow fw = WebHelper.ServiceLayer.Service.GetFunctionMaintenanceWorkflow(((BizPortalSessionContext)SessionContext).User, functionID);
        //    if (fw.MemberFunction == null)
        //    {
        //        warningCount++;
        //        message = Messages.Genaral.IsNotMemberFunction.Format(lange) + " " + functionName;
        //    }
         

         
        //    if (warningCount == 0)
        //    {
        //        TimeSchedule timeSchedule = getTimeSchedule();
        //        MultilingualString mls = new MultilingualString(SessionContext.CurrentLanguage.Code, txtDescription.Text);
        //        ScheduleSpecificDate specificDate = new ScheduleSpecificDate()
        //        {
        //            Date = ctrlSpecificDate.Date,
        //            Title = mls,
        //        };

        //        IList<ScheduleDetail> targetScheduleDetails = new List<ScheduleDetail>();
        //        targetScheduleDetails.Add(specificDate);

        //        AddMultipleHolidaysTransaction transaction = new AddMultipleHolidaysTransaction(SessionContext, fw, DateTime.Now, ((BizPortalSessionContext)SessionContext).Member, timeSchedule, targetScheduleDetails);
        //        transaction.Transit(SessionContext, fw, functionName, TransitionEventCode.SubmitEvent);
        //        mls.Persist(SessionContext);
        //        transaction.Persist(SessionContext);
        //        tx.Commit();

        //        message = String.Format("รายการ เพิ่มวันหยุดวันที่ {0} ถูกส่งเพื่อรอการอนุมัติ", ctrlSpecificDate.Date.DateTimeFormat("dd/MM/yyyy"));
        //        SessionContext.Log(functionID, pageID, 0, action, "เพิ่มวันหยุดวันที่ " + ctrlSpecificDate.Date.DateTimeFormat("dd/MM/yyyy"));
        //    }
          
        //}



    }
}
