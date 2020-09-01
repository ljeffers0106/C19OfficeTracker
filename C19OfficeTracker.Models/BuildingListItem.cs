using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C19OfficeTracker.Models
{
    public class BuildingListItem
    {
        [Display(Name = "Building ID")]
        public int BuildingId { get; set; }

        [Display(Name = "Building Name")]
        public string BuildingName { get; set; }

        [Display(Name = "Building Address")]
        public string Address { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }
    }
}
