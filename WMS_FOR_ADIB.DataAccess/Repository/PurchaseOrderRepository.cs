using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS_FOR_ADIB.DataAccess.Data;
using WMS_FOR_ADIB.DataAccess.Repository.IRepository;
using WMS_FOR_ADIB.Models;

namespace WMS_FOR_ADIB.DataAccess.Repository
{
    public class PurchaseOrderRepository : Repository<PurchaseOrder>,IPurchaseOrderRepository
    {
        private readonly ApplicationDbContext _db;

        public PurchaseOrderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        // Define the Update method
        public void Update(PurchaseOrder order)
        {
            // Assuming _db is your DbContext or similar context instance
            var objFromDb = _db.PurchaseOrders.FirstOrDefault(po => po.POId == order.POId);
            if (objFromDb != null)
            {
                objFromDb.PONumber = order.PONumber;
                objFromDb.PRNumber = order.PRNumber;
                objFromDb.SupplierName = order.SupplierName;
                objFromDb.SupplierID = order.SupplierID;
                objFromDb.Date = order.Date;
                objFromDb.OrderedBy = order.OrderedBy;
                objFromDb.AuthorizedBy = order.AuthorizedBy;
                // Update other properties as needed
            }
        }
    }
}
