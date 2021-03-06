using NHibernate.Type;

namespace iSabaya
{
	public enum RescheduleOption
	{
		NoReschedule,
		ScheduledDayBefore,
		ScheduledDayAfter
	}

    public class EnumRescheduleOption : EnumStringType
    {
        public EnumRescheduleOption()
            : base(typeof(RescheduleOption))
        {
        }
    }

}