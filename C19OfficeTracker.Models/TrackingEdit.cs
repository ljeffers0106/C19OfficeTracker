using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C19OfficeTracker.Models
{
    public class TrackingEdit
    {
        public int TrackingId { get; set; }
        [Required(ErrorMessage = "Track Date is required")]
        public DateTime TrackDate { get; set; }
        [Required(ErrorMessage = "Response is required")]
        [MaxLength(3, ErrorMessage = "Please enter ( Yes or No ) only.")]
        [Display(Name = "Any symptoms of Covid19 in last 24 hours? \n" +
            " * Sore Throat, \n" +
            " * Dry Cough, \n" +
            " * Body Ache, \n" +
            " * Fatigue,\n" +
            " * Shortness of Breath")]
        public string SymptomAnswer { get; set; }
        [Required(ErrorMessage = "Response is required")]
        [MaxLength(3, ErrorMessage = "Please enter ( Yes or No ) only.")]
        [Display(Name = "Have you been in direct contact with \n" +
           "a confirmed COVID-19 patient with the last 14 days?")]
        public string ContactAnswer { get; set; }
        [Required(ErrorMessage = "Response is required")]
        [MaxLength(3, ErrorMessage = "Please enter ( Yes or No ) only.")]
        [Display(Name = "Did you take your temperature within 90 minutes \n" +
            "of your scheduled start time?")]
        public string TempAnswer { get; set; }
        [Required(ErrorMessage = "Temperature is required")]
        [Display(Name = "Record your temperature reading:")]
        [Range(88.0, 105.5,
        ErrorMessage = "Value for:  {0} must be between {1} and {2}.")]
        public double Temperature { get; set; }
        [Required(ErrorMessage = "Response is required")]
        [MaxLength(3, ErrorMessage = "Please enter ( Yes or No ) only.")]
        [Display(Name = "Do you consistently wear a mask in public?")]
        public string MaskAnswer { get; set; }
        [Required(ErrorMessage = "Response is required")]
        [MaxLength(3, ErrorMessage = "Please enter ( Yes or No ) only.")]
        [Display(Name = "Have you attended any gatherings > 12 \n" +
            "people in the past 14 days?")]
        public string GroupAnswer { get; set; }
        [Required(ErrorMessage = "Employee is required")]
        [Display(Name = "Employee ID")]
        public int EmpId { get; set; }
    }
}
