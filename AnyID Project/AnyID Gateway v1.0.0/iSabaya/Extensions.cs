using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iSabaya
{
    public static class Extensions
    {
        public static Money Clone(this Money original)
        {
            if (null == original)
                return null;
            else
                return new Money(original);
        }

        public static MultilingualString Clone(this MultilingualString original)
        {
            if (MultilingualString.IsNullOrEmpty(original))
                return null;
            else
                return new MultilingualString(original);
        }

        public static bool IsNullOrZero(this Money m)
        {
            return (null == m || m.Amount == 0m);
        }

        public static IList<Employee> FindCurrentEmployments(this Person person, Context context)
        {
            DateTime now = DateTime.Now;
            return context.PersistenceSession.QueryOver<Employee>()
                .Where(e => e.Person == person && e.EffectivePeriod.From <= now && now <= e.EffectivePeriod.To)
                .List();
        }

        public static String GetUserInfo(this User user, Context context)
        {
            StringBuilder name = new StringBuilder();
            //Name info
            if (null == user.Person)
            {
                if (null != user.Name)
                    name.Append(user.Name.ToString());
                else
                    name.Append(user.LoginName.ToUpper());
            }
            else
                name.Append(user.Person.FullName);

            //Org info
            if (null != user.Organization)
            {
                name.Append(", ");
                name.Append(user.Organization.ToString());
            }
            else if (null != user.Person)
            {
                foreach (Employee employee in user.Person.FindCurrentEmployments(context))
                {
                    name.Append(", ");
                    name.Append(employee.Employer.ToString());
                }
            }
            return name.ToString();
        }

        /// <summary>
        /// Addition of years and months only.
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="duration"></param>
        /// <returns></returns>
        public static DateTime Add(this DateTime fromDate, TimeDuration duration)
        {
            DateTime toDate = new DateTime(fromDate.Year + duration.Years, fromDate.Month, 1);

            if (duration.Months > 0)
                toDate = toDate.AddMonths(duration.Months);

            int toDay = fromDate.Day - 1;
            if (toDay == 0)
                toDate = toDate.AddDays(-1);
            else
            {
                int toDateLastDayOfMonth = toDate.LastDayOfMonth();
                if (toDay <= toDateLastDayOfMonth)
                    toDate = new DateTime(toDate.Year, toDate.Month, toDay);
                else
                    toDate = new DateTime(toDate.Year, toDate.Month, toDateLastDayOfMonth);
            }
            return toDate;
        }
    }
}
