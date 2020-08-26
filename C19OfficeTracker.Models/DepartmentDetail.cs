using C19OfficeTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C19OfficeTracker.Models
{
    public class DepartmentDetail
    {
        [Display(Name = "Department ID")]
        public int DeptId { get; set; }
        [Display(Name = "Name")]
        public string DeptName { get; set; }
        [Display(Name = "Building Number")]
        public int Building { get; set; }
        [Display(Name = "Location")]
        public string Location { get; set; }
        [Display(Name = "Room")]
        public string Room { get; set; }
        //public ICollection<Employee> Employees { get; set; }
    }
}
