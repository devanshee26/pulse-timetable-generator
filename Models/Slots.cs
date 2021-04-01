using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pulse.Models
{
    public class Slots
    {
        public int SlotsId { get; set; }
        public int NoOfSlotsEachDay { get; set; }
        public int DurationOfEachSlot { get; set; }

        public DateTime StartTime { get; set; }

        public IList<DaysSlots> DaysSlots { get; set; }

    }
}
