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
    public class AssetDisposal
    {
        [Key]
        public int DisposalID { get; set; }

        public ICollection<Item>? Items { get; set; }

        [Required]
        public int Quantity { get; set; }

       
        [DisplayName("Disposed Date")]
        public DateTime DateDisposed { get; set; }

        [Required]
        [StringLength(500)]
        public string? Reason { get; set; }

        
        [DisplayName(" Disposed BY")]
        public string? DisposedBy { get; set; }

        
        [DisplayName("Approved By")]
        public string? ApprovedBy { get; set; }

       }
}
