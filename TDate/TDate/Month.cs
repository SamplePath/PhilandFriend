using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDate
{
    public class Month:IMonth
    {
        protected string monthName = string.Empty;
        public string MonthName
        {
            get
            {
                return monthName;
            }
            set
            {
                monthName = value;
            }
        }

        protected int monthIndex = 0;
        public int MonthIndex
        {
            get
            {
                return monthIndex;
            }
            set
            {
                monthIndex = value;
            }
        }

        protected int numberOfDays = 28;
        public int NumberOfDays
        {
            get
            {
                return numberOfDays;
            }
            set
            {
                numberOfDays = value;
            }
        }

        protected int currentDay = 1;
        public int CurrentDay
        {
            get
            {
                return currentDay;
            }
            set
            {
                if (currentDay != value)
                {
                    currentDay = value;
                    CurrentDate = DateTime.Parse(
                        string.Format("{0}/{1}/{2} {3}:{4}:{5}"
                        , this.CurrentDay.ToString("00")
                        , this.CurrentDate.Month.ToString("00")
                        , this.CurrentDate.Year.ToString()
                        , this.CurrentDate.Hour.ToString("00")
                        , this.CurrentDate.Minute.ToString("00")
                        , this.CurrentDate.Second.ToString("00")));                    
                }

            }
        }

        int carriedDay = 0;
        public int CarriedDay
        {
            get
            {
                return carriedDay;
            }
            set
            {
                carriedDay = value;
            }
        }

        public void AddDayToMonth(int Days)
        {
            if ((CurrentDay + Days) > NumberOfDays)
            {
                
                RaiseNextMonth(Days);
            }
            else if ((CurrentDay + Days) <= 0)
            {

                RaisePreviousMonth(CurrentDay - Math.Abs(Days));
            }
            else
            {
                this.CurrentDay += Days;
            }
        }

        public delegate void NextMonthHandler(IMonth sender, EventArgs e);
        public event NextMonthHandler NextMonth;        
        public void RaiseNextMonth(int Days)
        {
            CarriedDay = (Days + CurrentDay) - NumberOfDays;
            if (NextMonth != null)
            {
                NextMonth(this, new EventArgs());
            }
        }

        public delegate void PreviousMonthHandler(IMonth sender, EventArgs e);
        public event PreviousMonthHandler PreviousMonth;
        public void RaisePreviousMonth(int Days)
        {
            CarriedDay = Days;
            if (PreviousMonth != null)
            {
                PreviousMonth(this, new EventArgs());
            }
        }

        DateTime currentDate = DateTime.Now;
        public DateTime CurrentDate
        {
            get
            {
                return currentDate;
            }
            set
            {
                currentDate = value;
            }
        }
    }
}
