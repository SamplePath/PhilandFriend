using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDate
{
    public static class Ext_Date
    {
        public static DateTime GetDate(this DateTime value)
        {
            return DateTime.Now.AddDays(5);
        }


        public enum DataAddPart
        {
            Day,
            Month,
            Year
        }


        public static DateTime DateAdd(this DateTime value, DataAddPart DatePart, Int32 span)
        {
            Years ActiveYear = new Years(value);
            switch (DatePart)
            {
                case DataAddPart.Day:
                    return ActiveYear.DaysAdded(span);
                case DataAddPart.Month:
                    return ActiveYear.MonthsAdded(span);
                case DataAddPart.Year:                
                    return ActiveYear.YearsAdded(span);
            }

            return DateTime.Now;
        }

    }
}
