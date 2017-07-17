using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDate
{
    public interface IMonth
    {
       string MonthName{get;set;}
       Int32 MonthIndex { get; set; }
       Int32 NumberOfDays { get; set; }
       Int32 CurrentDay { get; set; }
       Int32 CarriedDay { get; set; }
       void AddDayToMonth(Int32 Days);
       void RaiseNextMonth(Int32 Days);
       void RaisePreviousMonth(Int32 Days);
       DateTime CurrentDate { get; set; }


    }
}
