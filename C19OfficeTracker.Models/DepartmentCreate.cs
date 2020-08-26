using C19OfficeTracker.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C19OfficeTracker.Models
{
   public class DepartmentCreate
    {
        public int DeptId { get; set; }
        [Required]
        [MaxLength(60, ErrorMessage = "Please enter up to 60 characters")]
        public string DeptName { get; set; }
        [Required]
        public int Building { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Room { get; set; }
        //public ICollection<Employee> Employees { get; set; }
    }
}
