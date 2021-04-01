using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pulse.Models
{
    public class DaysSlots
    {
        public int DaysId { get; set; }
        public Days Day { get; set; }

        public int SlotsId { get; set; }
        public Slots Slot { get; set; }


    }
}
