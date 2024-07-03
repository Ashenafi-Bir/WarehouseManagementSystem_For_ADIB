using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS_FOR_ADIB.Models
{
    public class Branch
    {

        [Key]
        public int BranchID { get; set; }

        [Required]
        [DisplayName("Branch Name")]
        public string? BranchName { get; set; }

        [Required]
        [DisplayName("Branch Code")]
        public string? BranchCode { get; set; }

        // Navigation property
        public ICollection<ApplicationUser>? ApplicationUsers { get; set; }
        
    }
}
