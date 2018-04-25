using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Exercises.Models.Data
{
    public class Student
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Please enter a First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter a Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter a GPA")]
        public decimal GPA { get; set; }
   
        public Address Address { get; set; }
        [Required(ErrorMessage = "Please enter a major")]
        public Major Major { get; set; }

        public List<Course> Courses { get; set; }
    }
}