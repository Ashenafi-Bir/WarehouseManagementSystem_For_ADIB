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

        [Required]
        [DisplayName("Return Date")]
        public DateTime DateReturned { get; set; }

        [Required]
        [StringLength(50)]
        public string? Status { get; set; }

        [Required]
        [DisplayName("Returned by")]
        public string? ReturnedBY { get; set; }

        [Required]
        [DisplayName("Approved by")]
        public string? ApprovedBY { get; set; }

        [Required]
        [DisplayName("Received By")]
        public string? ReceivedBy { get; set; }

     
    }
}
