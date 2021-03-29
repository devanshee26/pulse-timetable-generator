using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pulse.Models
{
    public class TimeTable
    {
        public int Id { get; set; }
        public string Day { get; set; }

        public IList<Subject> Subjects { get; set; }
    }
}
