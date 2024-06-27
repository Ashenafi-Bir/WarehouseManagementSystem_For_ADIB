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
    public class Item
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

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal TotalPrice { get; private set; }

        [Required]
        [DisplayName("Purchase Order ID")]
        public int POId { get; set; }

        [ForeignKey("POId")]
        public PurchaseOrder? PurchaseOrder { get; set; }

        public ICollection<AssetRequistion>? AssetRequisitions { get; set; }
        public ICollection<AssetTransfer>? AssetTransfers { get; set; }
        public ICollection<AssetReturn>? AssetReturns { get; set; }
        public ICollection<AssetDisposal>? AssetDisposals { get; set; }
    }
}
