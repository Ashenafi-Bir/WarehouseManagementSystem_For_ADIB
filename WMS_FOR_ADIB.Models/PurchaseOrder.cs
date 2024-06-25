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
    internal class PurchaseOrder
    {
        [Key]
        public int POId { get; set; }

        [Required]
        [DisplayName("Purchase Order Number")]
        public int PONumber { get; set; }

        [Required]
        [DisplayName("Purchase Requistion Number")]
        public int PRNumber { get; set; }

        [ForeignKey("PRNumber")]
        public PurchaseRequisition? PurchaseRequisition { get; set; }

        [Required]
        [DisplayName("Supplier Name")]
        public string? SupplierName { get; set; }

        [ForeignKey("SupplierID")]
        public Supplier? Supplier { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [DisplayName("Ordered By")]
        public string? OrderedBy { get; set; }

        [DisplayName("Authorized By")]
        public string? AuthorizedBy { get; set; }
       
        // Navigation property for the related items
        public ICollection<Item>? Items { get; set; }

    }
}
