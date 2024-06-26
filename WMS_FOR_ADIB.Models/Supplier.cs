using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMS_FOR_ADIB.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierID { get; set; }

        [Required]
        [StringLength(100)]
        public string? Name { get; set; }

        [Required]
        [StringLength(100)]
        public string? InvoiceNumber { get; set; } // Make sure to add unique constraint in the context

        //navigation
        public ICollection<PurchaseOrder>? PurchaseOrders { get; set; }
    }
}
