using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C19OfficeTracker.Models
{
    public class TrackingListItem
    {
        [Display(Name = "Tracking ID")]
        public int TrackingId { get; set; }
        [Display(Name = "Date of Record")]
        public DateTime TrackDate { get; set; }
        [Display(Name = "Symptoms")]
        public string SymptomAnswer { get; set; }
        [Display(Name = "Contact with Covid19")]
        public string ContactAnswer { get; set; }
        [Display(Name = "Temperature Taken")]
        public string TempAnswer { get; set; }
        [Display(Name = "Temperature")]
        public double Temperature { get; set; }
        [Display(Name = "Employee ID")]
        public int EmpId { get; set; }
    }
}
