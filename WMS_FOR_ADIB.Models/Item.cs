using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace WMS_FOR_ADIB.Models
{
    internal class Item
    {

        [Key]
        public int ItemID { get; set; }

        [Required]
        [StringLength(200)]
        public string? Description { get; set; }

        [Required]
        [StringLength(50)]
        public string? Unit { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [DisplayName("unit Price")]
        public decimal UnitPrice { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        [DisplayName("Purchase Order Number")]
        public string? PONumber { get; set; }

        [ForeignKey("PONumber")]
        public PurchaseOrder? PurchaseOrder { get; set; }

        public ICollection<AssetRequistion>? AssetRequisitions { get; set; }
        public ICollection<AssetTransfer>? AssetTransfers { get; set; }
        public ICollection<AssetReturn>? AssetReturns { get; set; }
        public ICollection<AssetDisposal>? AssetDisposals { get; set; }
    }
}
