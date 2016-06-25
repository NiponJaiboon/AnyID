using System;
using iSabaya;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestFramework
{
    [TestClass]
    public class TestiSabaya
    {
        [TestMethod]
        public void Test_YearMonthDuration()
        {
            TestYearMonthDuration(new DateTime(2010, 10, 31), new DateTime(2010, 11, 30), 0, 1);

            TestYearMonthDuration(new DateTime(2005, 4, 30), new DateTime(2010, 1, 31), 4, 9);
            TestYearMonthDuration(new DateTime(2006, 4, 30), new DateTime(2010, 2, 28), 3, 10);
            TestYearMonthDuration(new DateTime(2007, 4, 30), new DateTime(2010, 3, 29), 2, 11);
            TestYearMonthDuration(new DateTime(2008, 4, 30), new DateTime(2010, 4, 30), 2, 0);
            TestYearMonthDuration(new DateTime(2009, 4, 30), new DateTime(2010, 5, 28), 1, 0);
            TestYearMonthDuration(new DateTime(2009, 4, 30), new DateTime(2010, 5, 29), 1, 1);
            TestYearMonthDuration(new DateTime(2009, 4, 30), new DateTime(2010, 5, 30), 1, 1);
            TestYearMonthDuration(new DateTime(2009, 4, 30), new DateTime(2010, 5, 31), 1, 1);

            TestYearMonthDuration(new DateTime(2010, 10, 30), new DateTime(2010, 11, 28), 0, 0);
            TestYearMonthDuration(new DateTime(2010, 10, 30), new DateTime(2010, 11, 29), 0, 1);
            TestYearMonthDuration(new DateTime(2010, 10, 30), new DateTime(2010, 11, 30), 0, 1);

            TestYearMonthDuration(new DateTime(2010, 10, 31), new DateTime(2011, 4, 28), 0, 5);
            TestYearMonthDuration(new DateTime(2010, 10, 31), new DateTime(2011, 4, 29), 0, 5);
            TestYearMonthDuration(new DateTime(2010, 10, 31), new DateTime(2011, 4, 30), 0, 6);

            TestYearMonthDuration(new DateTime(2008, 01, 29), new DateTime(2010, 02, 28), 2, 1);

            TestYearMonthDuration(new DateTime(2010, 01, 01), new DateTime(2010, 01, 01), 0, 0);
            TestYearMonthDuration(new DateTime(2010, 01, 05), new DateTime(2010, 02, 04), 0, 1);
            TestYearMonthDuration(new DateTime(2010, 01, 01), new DateTime(2010, 12, 31), 1, 0);
            TestYearMonthDuration(new DateTime(2010, 01, 05), new DateTime(2010, 02, 28), 0, 1);
            TestYearMonthDuration(new DateTime(2010, 01, 31), new DateTime(2010, 02, 28), 0, 1);
            TestYearMonthDuration(new DateTime(2010, 02, 14), new DateTime(2011, 08, 06), 1, 5);
            TestYearMonthDuration(new DateTime(2006, 10, 07), new DateTime(2010, 12, 31), 4, 2);
            TestYearMonthDuration(new DateTime(2007, 10, 01), new DateTime(2010, 12, 31), 3, 3);
            TestYearMonthDuration(new DateTime(2008, 10, 02), new DateTime(2010, 12, 30), 2, 2);
            TestYearMonthDuration(new DateTime(2009, 10, 05), new DateTime(2010, 12, 03), 1, 1);
            TestYearMonthDuration(new DateTime(2010, 10, 05), new DateTime(2010, 12, 04), 0, 2);
        }

        private static void TestYearMonthDuration(DateTime beginDate, DateTime endDate, int expectedYears, int expectedMonths)
        {

            YearMonthDuration dur = new YearMonthDuration(beginDate, endDate);
            Assert.AreEqual<int>(expectedYears, dur.Years);
            Assert.AreEqual<int>(expectedMonths, dur.Months);
            YearMonthDuration newDur = new YearMonthDuration(beginDate, beginDate + dur);
            Assert.IsTrue(dur == newDur,
                String.Format("Begin date {0:yyyy-MM-dd}, End date {1:yyyy-MM-dd}", beginDate, endDate));
        }

        [TestMethod]
        public void Test_TimeDuration()
        {
            TestTimeDuration(new DateTime(2010, 10, 31), new DateTime(2010, 11, 30), 0, 1, 1);

            TestTimeDuration(new DateTime(2009, 9, 30), new DateTime(2010, 1, 31), 0, 4, 1);
            TestTimeDuration(new DateTime(2009, 9, 30), new DateTime(2010, 10, 28), 1, 0, 29);
            TestTimeDuration(new DateTime(2009, 9, 30), new DateTime(2010, 10, 29), 1, 1, 0);
            TestTimeDuration(new DateTime(2009, 9, 30), new DateTime(2010, 10, 30), 1, 1, 1);
            TestTimeDuration(new DateTime(2009, 9, 30), new DateTime(2010, 10, 31), 1, 1, 1);

            TestTimeDuration(new DateTime(2010, 10, 30), new DateTime(2010, 11, 28), 0, 0, 30);
            TestTimeDuration(new DateTime(2010, 10, 30), new DateTime(2010, 11, 29), 0, 1, 0);
            TestTimeDuration(new DateTime(2010, 10, 30), new DateTime(2010, 11, 30), 0, 1, 2);

            TestTimeDuration(new DateTime(2010, 10, 31), new DateTime(2011, 4, 28), 0, 5, 29);
            TestTimeDuration(new DateTime(2010, 10, 31), new DateTime(2011, 4, 29), 0, 5, 30);
            TestTimeDuration(new DateTime(2010, 10, 31), new DateTime(2011, 4, 30), 0, 6, 1);

            TestTimeDuration(new DateTime(2010, 01, 29), new DateTime(2010, 02, 28), 0, 1, 3);

            TestTimeDuration(new DateTime(2010, 01, 01), new DateTime(2010, 01, 01), 0, 0, 1);
            TestTimeDuration(new DateTime(2010, 01, 05), new DateTime(2010, 02, 04), 0, 1, 0);
            TestTimeDuration(new DateTime(2010, 01, 01), new DateTime(2010, 12, 31), 1, 0, 0);
            TestTimeDuration(new DateTime(2010, 01, 05), new DateTime(2010, 02, 28), 0, 1, 27); 
            TestTimeDuration(new DateTime(2010, 01, 31), new DateTime(2010, 02, 28), 0, 1, 1);
            TestTimeDuration(new DateTime(2010, 02, 14), new DateTime(2011, 08, 06), 1, 5, 21);
            TestTimeDuration(new DateTime(2010, 10, 07), new DateTime(2010, 12, 31), 0, 2, 25);
            TestTimeDuration(new DateTime(2010, 10, 01), new DateTime(2010, 12, 31), 0, 3, 0);
            TestTimeDuration(new DateTime(2010, 10, 02), new DateTime(2010, 12, 30), 0, 2, 29);
            TestTimeDuration(new DateTime(2010, 10, 05), new DateTime(2010, 12, 03), 0, 1, 30);
            TestTimeDuration(new DateTime(2010, 10, 05), new DateTime(2010, 12, 04), 0, 2, 0);
        }

        private static void TestTimeDuration(DateTime beginDate, DateTime endDate, int expectedYears, int expectedMonths, int expectedDays)
        {

            TimeDuration dur = new TimeDuration(beginDate, endDate);
            Assert.AreEqual<int>(expectedYears, dur.Years);
            Assert.AreEqual<int>(expectedMonths, dur.Months);
            Assert.AreEqual<int>(expectedDays, dur.Days);
            DateTime actualEndDate = beginDate + dur;
            TimeDuration newDur = new TimeDuration(beginDate, actualEndDate);
            Assert.IsTrue(endDate == actualEndDate || dur == newDur, 
                String.Format("Begin date {0:yyyy-MM-dd}, End date {1:yyyy-MM-dd}", beginDate, endDate));
        }
    }
}
