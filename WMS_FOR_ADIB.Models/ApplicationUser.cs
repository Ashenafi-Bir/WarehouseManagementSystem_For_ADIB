using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS_FOR_ADIB.Models
{
    public class ApplicationUser :IdentityUser 
    {
       
        [Required]
        [DisplayName("Employee ID")]
        public string? EmployeeId { get; set; }

        [Required]
        [DisplayName("Full Name")]
        public string? FullName  { get; set; }
        public bool RequiresPasswordChange { get; set; }
        // Foreign key
        public int BranchId { get; set; }

        // Navigation property
        public Branch? Branch { get; set; }


    }
}
