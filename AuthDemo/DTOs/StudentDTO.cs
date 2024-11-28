using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuthDemo.DTOs
{
    public class StudentDTO
    {
        [Required(ErrorMessage = "First Name Required")]
        public string FName { get; set; }

        [Required(ErrorMessage = "Last Name Required")]
        public string LName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Range(1, 3, ErrorMessage = "Semester Must be selected")]
        public int Semester { get; set; }
    }
}