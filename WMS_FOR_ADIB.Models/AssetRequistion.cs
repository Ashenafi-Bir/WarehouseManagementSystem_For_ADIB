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
    public class AssetRequistion
    {
        [Key]
        public int RequisitionID { get; set; }
       
        [Required]
        [DisplayName("Branch Code")]
        public int BranchCode { get; set; }

        public ICollection<Item>? Items { get; set; }

        [Required]
        
        public int Quantity { get; set; }


        [Required]
        [DisplayName("Requested By")]
        public string? RequestedBy { get; set; }
       
        [Required]
        public DateTime DateRequested { get; set; }
       
        [Required]
        [DisplayName("Approved By")]
        public string? ApprovedBy { get; set; }
        public DateTime? DateApproved { get; set; }
        
        [Required]
        [DisplayName("Issued By")]
        public string? IssuedBy { get; set; }
        public DateTime? DateDispatched { get; set; }

        [Required]
        [StringLength(50)]
        public string? Status { get; set; }

        
       
       
        

    }
}
