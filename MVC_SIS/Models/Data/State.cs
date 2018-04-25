using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Exercises.Models.Data
{
    public class State
    {
        [Required(ErrorMessage = "need an abbreviation")]
        public string StateAbbreviation { get; set; }
   
        public string StateName { get; set; }
    }
}