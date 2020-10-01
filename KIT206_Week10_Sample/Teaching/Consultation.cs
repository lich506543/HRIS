﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Teaching
{
    public class Consultation
    {
        public DayOfWeek Day { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

        public bool Overlaps(DateTime sometime)
        {
            return sometime.DayOfWeek == Day &&
                sometime.TimeOfDay >= Start &&
                sometime.TimeOfDay < End;
        }

        public override string ToString()
        {
            return Day + " " + Start + "--" + End;
        }
    }
}
