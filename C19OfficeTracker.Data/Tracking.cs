using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C19OfficeTracker.Data
{
    public class Tracking
    {
        [Key]
        public int TrackingId { get; set; }
        [Required]
        public DateTime TrackDate { get; set; }
        [Required]
        [MaxLength(3, ErrorMessage = "Please enter ( yes or no ) only.")]
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

        public string Id { get; set; }
        [ForeignKey(nameof(Id))]
        public virtual Employee Employee { get; set; }
    }
}
