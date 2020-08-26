using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C19OfficeTracker.Models
{
    public class TrackingDetail
    {
        [Display(Name = "Tracking ID")]
        public int TrackingId { get; set; }
        public DateTime TrackDate { get; set; }
        [Display(Name = "Symptoms of Covid19")]
        public string SymptomAnswer { get; set; }
        [Display(Name = "Contact with Covid19 positive person")]
        public string ContactAnswer { get; set; }
        [Display(Name = "Temperature taken with 90 mins of start time")]
        public string TempAnswer { get; set; }
        [Display(Name = "Temperature registered")]
        public double Temperature { get; set; }
        [Display(Name = "Practice regular mask usage")]
        public string MaskAnswer { get; set; }
        [Display(Name = "Large group Exposure in past 14 days")]
        public string GroupAnswer { get; set; }
        [Display(Name = "Employee ID")]
        public int EmpId { get; set; }
    }
}
