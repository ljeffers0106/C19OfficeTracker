using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C19OfficeTracker.Models
{
    public class BuildingEdit
    {
        public int BuildingId { get; set; }

        [Required(ErrorMessage = "Building name is required")]
        [Display(Name = "Building Name")]
        [MaxLength(60, ErrorMessage = "Please enter up to 60 characters")]
        public string BuildingName { get; set; }

        [Required(ErrorMessage = "Building address is required")]
        [Display(Name = "Building Address")]
        [MaxLength(60, ErrorMessage = "Please enter up to 60 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "City is required")]
        [Display(Name = "City")]
        [MaxLength(60, ErrorMessage = "Please enter up to 60 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [Display(Name = "State")]
        [MaxLength(2, ErrorMessage = "Please enter 2 char state abbreviation")]
        public string State { get; set; }

        [Required(ErrorMessage = "Postal code is required")]
        [Display(Name = "Postal Code")]
        [MaxLength(13, ErrorMessage = "Please enter up to 13 characters")]
        public string Postal { get; set; }
    }
}
