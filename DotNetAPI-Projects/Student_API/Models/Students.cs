using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Student_API.CustomAttributes;

namespace Student_API.Models
{
    public class Student
    { 
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [SchoolAge(5,22)]
        public DateTime BirthDate { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Phone { get; set; }
    } 
}
