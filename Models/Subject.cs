using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pulse.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Semester { get; set; }
        [Required]
        public string Branch { get; set; }

        IList<User> Faculties { get; set; }
        IList<TimeTable> TimeTables { get; set; }
    }
}
