using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pulse.Models
{
    public class Days
    {
        [Key]
        public int DaysId { get; set; }
        public string Day { get; set; }

        public IList<DaysSlots> DaysSlots { get; set; }
    }
}
