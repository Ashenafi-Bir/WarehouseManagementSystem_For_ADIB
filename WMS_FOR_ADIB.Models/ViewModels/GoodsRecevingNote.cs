using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace WMS_FOR_ADIB.Models.ViewModels
{
    internal class GoodsRecevingNote
    {
        [Required]
        [DisplayName("Purchase Order Number")]
        public int PONumber { get; set; }

        [ForeignKey("PONumber")]
        public PurchaseOrder? PurchaseOrder { get; set; }

        [Required]
        [DisplayName("Recieved Date")]
        public DateTime DateReceived { get; set; }

        [Required]
        [DisplayName("Delivered BY")]
        public string? DeliveredBy { get; set; }

        [Required]
        [DisplayName("Inspecetd By")]
        public int InspectedBy { get; set; }

        [Required]
        [DisplayName("Recived BY")]
        public int ReceivedBy { get; set; }

        }
}
