using C19OfficeTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C19OfficeTracker.Models
{
    public class EmployeeEdit
    {
        [Display(Name = "Employee ID")]
        public int EmpId { get; set; }
        [Required]
        [Display(Name = "Full name            ")]
        public string FullName { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Required]
        [Display(Name = "Position Title")]
        public Position TypeOfPosition { get; set; }
        [Required]
        [Display(Name = "Department Id")]
        public int DeptId { get; set; }
    }
}
