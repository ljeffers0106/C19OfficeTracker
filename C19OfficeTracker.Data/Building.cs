using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C19OfficeTracker.Data
{
    public class Building
    {
        [Key]
        public int BuildingId { get; set; }
        [Required]
        public string BuildingName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Postal { get; set; }
        
    }
}
