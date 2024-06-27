using System.Linq;
using WMS_FOR_ADIB.DataAccess.Data;
using WMS_FOR_ADIB.DataAccess.Repository.IRepository;
using WMS_FOR_ADIB.Models;

namespace WMS_FOR_ADIB.DataAccess.Repository
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        private readonly ApplicationDbContext _db;

        public SupplierRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Supplier supplier)
        {
            var objFromDb = _db.Suppliers.FirstOrDefault(s => s.SupplierID == supplier.SupplierID);
            if (objFromDb != null)
            {
                objFromDb.Name = supplier.Name;
                objFromDb.InvoiceNumber = supplier.InvoiceNumber;
                // Update other properties as needed
            }
        }
    }
}
