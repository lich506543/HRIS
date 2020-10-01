using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Teaching
{
    class Units
    {
        public string Code { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return Code + " " + Title;
        }
    }
}
