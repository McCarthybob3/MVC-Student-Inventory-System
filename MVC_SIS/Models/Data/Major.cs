using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Exercises.Models.Data
{
    public class Major
    {
        [Required(ErrorMessage = "major needs a name")]
        public int MajorId { get; set; }
      
        public string MajorName { get; set; }
    }
}