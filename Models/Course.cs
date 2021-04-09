using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pulse.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public int LecturesPerWeek { get; set; }
        public int Semester { get; set; }
        public string Department { get; set; }

        public int CourseByFacultyId { get; set; }

        [ForeignKey("CourseByFacultyId")]
        public User Faculty { get; set; }

        ICollection<TimeTable> TimeTables { get; set; }
    }
}
