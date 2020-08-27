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
        [Required(ErrorMessage = "Full Name is required")]
        [Display(Name = "Full Name")]
        [MaxLength(60, ErrorMessage = "Please enter up to 60 characters")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        [Display(Name = "Phone Number")]
        [MaxLength(13, ErrorMessage = "Please enter up to 10 numbers with (-,())")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Hire date is required")]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }
        [Required(ErrorMessage = "Birth date is required")]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Position is required")]
        [Display(Name = "Position")]
        public Position TypeOfPosition { get; set; }
        [Required(ErrorMessage = "Department Id is required")]
        [Display(Name = "Department Id")]
        public int DeptId { get; set; }
    }
}
