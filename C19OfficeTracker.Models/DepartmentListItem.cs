using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C19OfficeTracker.Models
{
    public class DepartmentListItem
    {
        [Display(Name = "Dept ID")]
        public int DeptId { get; set; }
        [Display(Name = "Name")]
        public string DeptName { get; set; }
        [Display(Name = "Building Name")]
        public string BuildingName { get; set; }
        [Display(Name = "Location")]
        public string Location { get; set; }
        [Display(Name = "Room")]
        public string Room { get; set; }
    }
}
