using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{

    public class SingleStepRate<T>
    {
        public SingleStepRate()
        {
        }

        public SingleStepRate(Object owner, int seqNo, string code, MultilingualString title, MultilingualString description,
                    float percentageRate, T fixedRateAmount, User updatedBy)
        //: base(owner, seqNo, code, title, description, updatedBy)
        {
            this.fixedAmountRate = fixedRateAmount;
            this.percentageRate = percentageRate;
        }

        #region persistent

        protected T fromAmount;
        public virtual T FromAmount
        {
            get { return fromAmount; }
            set { fromAmount = value; }
        }

        protected T toAmount;
        public virtual T ToAmount
        {
            get { return toAmount; }
            set { toAmount = value; }
        }

        private T fixedAmountRate;
        public virtual T FixedAmountRate
        {
            get { return fixedAmountRate; }
            set { fixedAmountRate = value; }
        }

        private float percentageRate;
        public virtual float PercentageRate
        {
            get { return percentageRate; }
            set { percentageRate = value; }
        }

        public virtual int SeqNo { get; set; }

        #endregion persistent

        ///// <summary>
        ///// Calculate fee based on investment units
        ///// </summary>
        ///// <param name="inv"></param>
        ///// <param name="unitNAV"></param>
        ///// <returns></returns>
        //public virtual double ApplyRate(double baseAmount, double percentageRateDivisor)
        //{
        //    return baseAmount * this.PercentageRate / (100.0 + percentageRateDivisor);
        //}

        public virtual void Persist(Context context)
        {
            context.PersistenceSession.SaveOrUpdate(this);
        }

        //public static SingleStepRate<T> Find(Context context, int FeeItemID)
        //{
        //    return (SingleStepRate<T>)context.PersistenceSession.Get(typeof(SingleStepRate<T>), FeeItemID);
        //}

        public virtual void Update(Context context)
        {
            context.PersistenceSession.Update(this);
        }
    }
}
