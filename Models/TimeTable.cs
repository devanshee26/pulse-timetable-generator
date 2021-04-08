using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pulse.Models
{
    public class TimeTable
    {
        [Key]
        public int TimeTableId { get; set; }
        public string Day { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true)]
        
        public int Course1Id { get; set; }
        [ForeignKey("Course1Id")]
        public Course Course1 { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true)]
        
        public int Course2Id { get; set; }
        [ForeignKey("Course2Id")]
        public Course Course2 { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true)]
        
        public int Course3Id { get; set; }
        [ForeignKey("Course3Id")]
        public Course Course3 { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true)]
        
        public int Course4Id { get; set; }
        [ForeignKey("Course4Id")]
        public Course Course4 { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true)]
        
        public int Course5Id { get; set; }
        [ForeignKey("Course5Id")]
        public Course Course5 { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(AllowEmptyStrings = true)]
        
        public int Course6Id { get; set; }
        [ForeignKey("Course6Id")]
        public Course Course6 { get; set; }



    }
}
