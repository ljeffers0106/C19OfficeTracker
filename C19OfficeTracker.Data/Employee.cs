using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C19OfficeTracker.Data
{
    public enum Position
    {
        VP = 1,
        Director = 2,
        Manager = 3,
        Associate = 4
    }
    public class Employee : ApplicationUser
    {
        
        public Guid IndiviualId { get; set; }
        [Required]
        [MaxLength(13, ErrorMessage = "Please enter up to 10 numbers with (-,())")]
        public string Phone { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public Position TypeOfPosition { get; set; }
        [Required]
        public int DeptId { get; set; }
        [ForeignKey(nameof(DeptId))]
        public virtual Department Department { get; set; }
    }
}
