using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDate
{
    public class Years
    {
        public Years()
        { }

        public Years(DateTime date)
        {
            if (DateTime.IsLeapYear(date.Year))
            {
                YearAsMonths = new List<Month>() 
                { 
                    new January(), 
                    new FebuaryLeap(),
                    new March(),
                    new April(),
                    new May(),
                    new June(),
                    new July(),
                    new August(),
                    new September(),
                    new October(),
                    new November(),
                    new December()
                };

            }
            else
            {
                YearAsMonths = new List<Month>() 
                { 
                    new January(), 
                    new Febuary(),
                    new March(),
                    new April(),
                    new May(),
                    new June(),
                    new July(),
                    new August(),
                    new September(),
                    new October(),
                    new November(),
                    new December()
                };
            }

            CurrentMonth = (from month in YearAsMonths where month.MonthIndex == date.Month select month).FirstOrDefault();
            CurrentMonth.CurrentDay = date.Day;
            CurrentYear = date.Year;
            DateNow = date;
        }

        DateTime dateNow = DateTime.Now;
        public DateTime DateNow
        {
            get { return dateNow; }
            set { dateNow = value; }
        }


        Month currentMonth = new January();
        public Month CurrentMonth
        {
            get 
            {
                return currentMonth;
            }
            set
            {
                if (currentMonth != value)
                {
                    currentMonth = value;

                    currentMonth.CurrentDate = DateTime.Parse(
                        string.Format("{0}/{1}/{2} {3}:{4}:{5}"
                        , this.DateNow.Day.ToString("00")
                        , this.CurrentMonth.MonthIndex.ToString("00")
                        , this.DateNow.Year.ToString()
                        , this.DateNow.Hour.ToString("00")
                        , this.DateNow.Minute.ToString("00")
                        , this.DateNow.Second.ToString("00")));

                    try { currentMonth.NextMonth -= this.NextMonthHandler; }
                    catch { }

                    try { currentMonth.PreviousMonth -= this.PreviousMonthHandler; }
                    catch { }

                    currentMonth.NextMonth += new Month.NextMonthHandler(this.NextMonthHandler);
                    currentMonth.PreviousMonth += new Month.PreviousMonthHandler(this.PreviousMonthHandler);
                }
            }
        }

        void NextMonthHandler(object sender, EventArgs e)
        {
            IMonth imonth = sender as IMonth;
            int carried = imonth.CarriedDay;
            int dayinmonth = CurrentMonth.CurrentDay;
            for (int i = CurrentMonth.MonthIndex + 1; i >= 12; i -= 12)
            {
                if ((i) > 12)
                {
                    YearNext();
                }
                else if ((i) < 1)
                {
                    YearPrevious();
                }
            }


            CurrentMonth = (from month in YearAsMonths where month.MonthIndex == (CurrentMonth.MonthIndex + 1) % 12 select month).FirstOrDefault();

            if (carried > CurrentMonth.NumberOfDays)
            {
                CurrentMonth.AddDayToMonth(carried);
            }
            else
            {
                CurrentMonth.CurrentDay = CurrentMonth.NumberOfDays - carried;
            }

            

        }

        void PreviousMonthHandler(object sender, EventArgs e)
        {
            IMonth imonth = sender as IMonth;
            int carried = imonth.CarriedDay;
            int dayinmonth = CurrentMonth.CurrentDay;
            
            CurrentMonth = (from month in YearAsMonths where month.MonthIndex == (CurrentMonth.MonthIndex - 1) % 12 select month).FirstOrDefault();

            if ((CurrentMonth.NumberOfDays + carried) < 1)
            {
                CurrentMonth.AddDayToMonth(CurrentMonth.NumberOfDays + carried);
            }
            else
            {
                CurrentMonth.CurrentDay = CurrentMonth.NumberOfDays + carried;
            }
        }

        int currentYear = 1;
        public int CurrentYear
        {
            get { return currentYear; }
            set { currentYear = value; }
        }


        List<Month> yearAsMonths = new List<Month>();
        public List<Month> YearAsMonths
        {
            get { return yearAsMonths; }
            set { yearAsMonths = value; }
        }

        public DateTime DaysAdded(int days)
        {
            CurrentMonth.AddDayToMonth(days);
            return CurrentMonth.CurrentDate;
        }

        public DateTime MonthsAdded(int months)
        {
            int dayinmonth = CurrentMonth.CurrentDay;
            for (int i = CurrentMonth.MonthIndex + months; i >= 12; i -= 12)
            {
                if ((i) > 12)
                {
                    YearNext();                    
                }
                else if ((i) < 1)
                {
                    YearPrevious();
                }
            }

            CurrentMonth = (from month in YearAsMonths where month.MonthIndex == (CurrentMonth.MonthIndex + months) % 12 select month).FirstOrDefault();

            if (dayinmonth > CurrentMonth.NumberOfDays)
            {
                CurrentMonth.AddDayToMonth(dayinmonth);
            }
            else
            {
                CurrentMonth.CurrentDay = dayinmonth;
            }

            return CurrentMonth.CurrentDate;
        }

        private void YearNext()
        {

            Years year = new Years(DateTime.Parse(string.Format("01/01/{0}", CurrentYear + 1)));
            this.YearAsMonths = year.YearAsMonths;
            this.CurrentYear = year.CurrentYear;
            this.currentMonth = year.CurrentMonth;
        }

        private void YearPrevious()
        {
            Years year = new Years(DateTime.Parse(string.Format("01/01/{0}", CurrentYear - 1)));
            this.YearAsMonths = year.YearAsMonths;
            this.CurrentYear = year.CurrentYear;
            this.currentMonth = year.CurrentMonth;
        }

        public DateTime YearsAdded(int span)
        {
            Years year = new Years(
                DateTime.Parse(
                string.Format("{0}/{1}/{2} {3}:{4}:{5}"
                , this.CurrentMonth.CurrentDay.ToString("00")
                , this.CurrentMonth.MonthIndex.ToString("00"), (this.DateNow.Year + span).ToString()
                , this.DateNow.Hour.ToString("00")
                , this.DateNow.Minute.ToString("00")
                , this.DateNow.Second.ToString("00"))));

            this.YearAsMonths = year.YearAsMonths;
            this.CurrentYear = year.CurrentYear;
            this.currentMonth = year.CurrentMonth;
            this.DateNow = year.DateNow;


            return this.DateNow;
        }
    }
}
