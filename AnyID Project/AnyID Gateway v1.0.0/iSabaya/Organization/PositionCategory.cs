using iSabaya;
using System;
using System.Collections.Generic;
using System.Text;

namespace iSabaya
{

    public class PositionCategory : PersistentTemporalTitledEntity
    {
        #region persistent
        public virtual int MaxPersonnelLevel { get; set; }
        public virtual int MinPersonnelLevel { get; set; }
        public virtual PositionCategory Parent { get; set; }
        public virtual TreeListNode ProfessionCategory { get; set; }
        public virtual Money MaxSalary { get; set; }
        public virtual Money MinSalary { get; set; }

        /// <summary>
        /// The maximum number of years a person may hold the position.  
        /// 0 indicates indefinite term.
        /// </summary>
        public virtual int TermLimit { get; set; }

        private IList<PositionLevel> levels;
        public virtual IList<PositionLevel> Levels
        {
            get
            {
                if (this.levels == null)
                    this.levels = new List<PositionLevel>();
                return this.levels;
            }
            set
            {
                this.levels = value;
            }
        }

        private IList<PositionCategory> children;
        public virtual IList<PositionCategory> Children
        {
            get
            {
                if (this.children == null)
                    this.children = new List<PositionCategory>();
                return this.children;
            }
            set
            {
                this.children = value;
            }
        }

        //private IList<Position> positions;
        //public virtual IList<Position> Positions
        //{
        //    get
        //    {
        //        if (this.positions == null)
        //            this.positions = new List<Position>();
        //        return this.positions;
        //    }
        //    set
        //    {
        //        this.positions = value;
        //    }
        //}

        #endregion

        public virtual PositionCategory GetCategory(params String[] codes)
        {
            PositionCategory d = null;
            if (codes == null || codes.Length == 0)
                return d;

            string code = codes[0];
            foreach (PositionCategory c in this.Children)
            {
                if (c.Code == code)
                    d = c.GetDescendant(codes, 1);
            }
            return d;
        }

        private PositionCategory GetDescendant(string[] codes, int i)
        {
            PositionCategory d = this;
            if (codes == null || codes.Length <= i)
                return d;

            string code = codes[i];
            foreach (PositionCategory c in this.Children)
            {
                if (c.Code == code)
                    d = c.GetDescendant(codes, i + 1);
            }
            return d;
        }

        public override void Persist(Context context)
        {
            base.Persist(context);
            if (this.Levels != null)
                foreach (var i in this.Levels)
                {
                    i.Category = this;
                    i.Persist(context);
                }

            if (this.Children != null)
                foreach (var i in this.Children)
                {
                    i.Parent = this;
                    i.Persist(context);
                }

            //if (this.Positions != null)
            //    foreach (var i in this.Positions)
            //    {
            //        i.PositionCategory = this;
            //        i.Persist(context);
            //    }
        }
    }
}
