using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using iSabaya;

namespace TestFramework
{
    [TestClass]
    public class Test_ORM : TestBase
    {
        private int errorCount;
        private StringBuilder errorMessages;

        private T Get<T>(object id) where T :class
        { 
            try
            {
                T e = SessionContext.PersistenceSession.Get<T>(id);
                return e;
            }
            catch(Exception exc)
            {
                ++errorCount;
                if (errorMessages == null)
                {
                    errorMessages = new StringBuilder();
                }
                errorMessages.AppendLine(typeof(T).Name);
                errorMessages.AppendLine(exc.ToString());
                return (T)null;
            }
            
        }

        [TestMethod]
        public void Test_Classess_ORM_and_Tables()
        {
            errorCount = 0;
            errorMessages = null;

            Get<Configuration>(1);

            Get<Country>("THA");
            Get<Currency>("THB");
            Get<Language>("th-TH");
            Get<GeographicAddress>(1L);
            Get<MultilingualString>(1L);
            Get<MLSValue>(1L);
            Get<TreeListNode>(1L);

            Get<Appointment>(1L);
            Get<LinkOfCommand>(1L);
            Get<Employee>(1L);
            Get<InterOrgUnitRelation>(1L);
            Get<InterPersonRelation>(1L);
            Get<InterPositionRelation>(1L);
            Get<Organization>(1L);
            Get<OrgUnit>(1L);
            Get<OrgUnitPosition>(1L);
            Get<Person>(1L);
            Get<PersonName>(1L);
            Get<Position>(1L);
            Get<PositionCategory>(1L);
            //Get<ProfessionCategory>(1L);
            Get<SelfAuthenticatedUser>(1L);
            Get<Staff>(1L);
            Get<Subunit>(1L);

            Get<PartyAddress>(1L);
            Get<PartyAttribute>(1L);
            Get<PartyImage>(1L);
            Get<PartyWorkSchedule>(1L);

            //Test<ScheduleDayOfWeek>(1);
            Get<ScheduleMonthlyOnDay>(1);
            Get<ScheduleMonthlyOnDayOfWeek>(1);
            Get<ScheduleMonthlyRelativeToEOM>(1);
            Get<ScheduleRecurring>(1);
            Get<ScheduleSpecificDate>(1);
            Get<ScheduleWeekly>(1);
            Get<ScheduleYearlyOnDate>(1);
            Get<TimeSchedule>(1);

            Get<User>(1L);
            Get<Password>(1L);
            Get<UseCase>(1L);
            Get<Role>(1L);
            Get<RoleUseCase>(1L);
            Get<UserRole>(1L);
            Get<UserSession>(1L);
            Get<UserSessionLog>(1L);

            if (errorCount > 0)
                throw new Exception("There are " + errorCount + " errors.");
        }
    }
}
