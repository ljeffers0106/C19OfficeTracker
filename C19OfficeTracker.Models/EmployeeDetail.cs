using C19OfficeTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C19OfficeTracker.Models
{
    public class EmployeeDetail
    {
        [Display(Name = "Employee ID")]
        public int EmpId { get; set; }
        [Display(Name ="Full name            ")]
        public string FullName { get; set; }
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Gender")]
        public string Gender { get; set; }
        [Display(Name = "Position Title")]
        public Position TypeOfPosition { get; set; }
        [Display(Name = "Department Id")]
        public int DeptId { get; set; }
    }   
}
