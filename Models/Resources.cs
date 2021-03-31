using Microsoft.AspNetCore.Http;
using Pulse.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Pulse.Models
{
    public class Resources
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FileName { get; set; }
        [Required]
        public int UserId { get; set; } 
        [Required]
        public int SubjectId { get; set; }
        [NotMapped]
        UploadFileRequest request { get; set; }
        [NotMapped]
        public IFormFile ImagePath { set; get; }

    }
}
