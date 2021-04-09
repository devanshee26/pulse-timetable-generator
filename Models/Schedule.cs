using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pulse.Models
{
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }
        public int Semester { get; set; }
        public string Branch { get; set; }
        public int StartTime { get; set; }
        public int EachSlotTime { get; set; }

        public int NoOfWorkingDays { get; set; }
        public int NoOfSlotsEachDay { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true)]
        public int MondayTTId { get; set; }
        [ForeignKey("MondayTTId")]
        public TimeTable MondayTT { get; set; }
        

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true)]
        public int TuesdayTTId { get; set; }
        [ForeignKey("TuesdayTTId")]
        public TimeTable TuesdayTT { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true)]
        public int WednesdayTTId { get; set; }
        [ForeignKey("WednesdayTTId")]
        public TimeTable WednesdayTT { get; set; }



        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true)]
        public int ThursdayTTId { get; set; }
        [ForeignKey("ThursdayTTId")]
        public TimeTable ThursdayTT { get; set; }


        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true)]
        public int FridayTTId { get; set; }
        [ForeignKey("FridayTTId")]
        public TimeTable FridayTT { get; set; }
    }
}
