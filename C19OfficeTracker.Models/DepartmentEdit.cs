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
        [Required(ErrorMessage = "Department Name is required")]
        [Display(Name = "Department Name")]
        [MaxLength(60, ErrorMessage = "Please enter up to 60 characters")]
        public string DeptName { get; set; }
        [Required(ErrorMessage = "Building Number is required")]
        [Display(Name = "Building Number")]
        public int Building { get; set; }
        [Required(ErrorMessage = "Location is required")]
        [Display(Name = "Location")]
        [MaxLength(60, ErrorMessage = "Please enter up to 60 characters")]
        public string Location { get; set; }
        [Required(ErrorMessage = "Room is required")]
        [Display(Name = "Room")]
        [MaxLength(20, ErrorMessage = "Please enter up to 20 characters")]
        public string Room { get; set; }
    }
}
