using C19OfficeTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C19OfficeTracker.Models
{
    public class EmployeeCreate
    {
        [Required]
        [MaxLength(60, ErrorMessage = "Please enter up to 60 characters")]
        public string FullName { get; set; }
        [MaxLength(13, ErrorMessage = "Please enter up to 10 numbers with (-,())")]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public Position TypeOfPosition { get; set; }
       
        public int DeptId { get; set; }
    }
}
