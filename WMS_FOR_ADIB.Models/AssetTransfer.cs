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
    public class AssetTransfer
    {
        [Key]
        public int TransferID { get; set; }

        
        [DisplayName("From Brranch Code")]
        public string?  FromBranchCode { get; set; }

        
        [DisplayName("To Branch Code")]
        public string? ToBranchCode { get; set; }

        public ICollection<Item>? Items { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [DisplayName("Transfer Date")]
        public DateTime DateTransferred { get; set; }

        
        [StringLength(50)]
        public string? Status { get; set; }

        
        [DisplayName("Requested By")]
        public string ? RequestedBy { get; set; }

        
        [DisplayName("Approved By")]
        public string? ApprovedBy { get; set; }

        
        [DisplayName("Received By")]
        public string? ReceivedBy { get; set; }

    }
}
