﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDate
{
    public class FacadeDate
    {
        public FacadeDate(){}
        public FacadeDate(DateTime date) 
        {
            Years ActiveYear = new Years(date);
            ActiveYear.MonthsAdded(10);
        }
    }
}
