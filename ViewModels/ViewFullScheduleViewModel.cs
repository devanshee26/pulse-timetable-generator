using Pulse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pulse.ViewModels
{
    public class ViewFullScheduleViewModel
    {
        public Schedule Schedule { get; set; }
        public List<TimeTable> Days { get; set; }


    }
}
