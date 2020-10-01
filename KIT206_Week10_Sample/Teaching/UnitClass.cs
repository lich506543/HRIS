using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Teaching
{
    public enum Campus { Hobart, Launceston };
    class UnitClass
    {
        public string Room { get; set; }
        public Campus Campus { get; set; }

        public override string ToString()
        {
            return Room + " " + Campus;
        }
    }
}
