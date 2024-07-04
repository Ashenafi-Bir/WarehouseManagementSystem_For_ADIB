using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WMS_FOR_ADIB.Models
{
    public class AssetReturn
    {
        [Key]
        public int ReturnID { get; set; }

        [Required]
        [DisplayName(" Branch Code")]
        public string?  BranchCode { get; set; }

        public ICollection<Item>?Items { get; set; }

        
        [DisplayName("Return Date")]
        public DateTime DateReturned { get; set; }

        
        [StringLength(50)]
        public string? Status { get; set; }

        
        [DisplayName("Returned by")]
        public string? ReturnedBY { get; set; }

        
        [DisplayName("Approved by")]
        public string? ApprovedBY { get; set; }

        
        [DisplayName("Received By")]
        public string? ReceivedBy { get; set; }

     
    }
}
