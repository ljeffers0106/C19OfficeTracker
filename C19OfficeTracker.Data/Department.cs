﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C19OfficeTracker.Data
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        [Required]
        public string DeptName { get; set; }
        [Required]
        public int BuildingId { get; set; }
        [ForeignKey(nameof(BuildingId))]
        public virtual Building Building { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Room { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
