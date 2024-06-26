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
    public class PurchaseRequisition
    {
        [Key]
        public int PRId { get; set; }

        [DisplayName("Purchase Requisition Number")]
        public string? PRNumber { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [DisplayName("Requested By")]
        public string? RequestedBy{ get; set; }

        [Required]
        [DisplayName("Authorized BY")]
        public string? AuthorizedBy { get; set; }

    
        //navigation
        public ICollection<PurchaseOrder>? PurchaseOrders { get; set; }
    }
}
