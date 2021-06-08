using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class ShowingSpecParams: SpecParams
    {
        public DateTime DateOfToday { get; set; }

        public int RangeOfDays { get; set; } = 14;
    }
}
