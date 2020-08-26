using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C19OfficeTracker.Models
{
    public class TrackingCreate
    {
        public int TrackingId { get; set; }
        [Required]
        public DateTime TrackDate { get; set; }
        [Required]
        [MaxLength(3, ErrorMessage = "Please enter ( yes or no ) only.")]
        [Display(Name = "Symptoms of Covid19 ")]
        public string SymptomAnswer { get; set; }
        [Required]
        [MaxLength(3, ErrorMessage = "Please enter ( yes or no ) only.")]
        public string ContactAnswer { get; set; }
        [Required]
        [MaxLength(3, ErrorMessage = "Please enter ( yes or no ) only.")]
        public string TempAnswer { get; set; }
        [Required]
        public double Temperature { get; set; }
        [Required]
        [MaxLength(3, ErrorMessage = "Please enter ( yes or no ) only.")]
        public string MaskAnswer { get; set; }
        [Required]
        [MaxLength(3, ErrorMessage = "Please enter ( yes or no ) only.")]
        public string GroupAnswer { get; set; }
        [Required]
        public int EmpId { get; set; }
        
    }
}
