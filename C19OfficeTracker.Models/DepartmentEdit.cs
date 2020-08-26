using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C19OfficeTracker.Models
{
    public class DepartmentEdit
    {
        public int DeptId { get; set; }
        [Required]
        [MaxLength(60, ErrorMessage = "Please enter up to 60 characters")]
        [Display(Name = "Department Name")]
        public string DeptName { get; set; }
        [Required]
        [Display(Name = "Building Number")]
        public int Building { get; set; }
        [Required]
        [Display(Name = "Location")]
        public string Location { get; set; }
        [Required]
        [Display(Name = "Room")]
        public string Room { get; set; }
    }
}
