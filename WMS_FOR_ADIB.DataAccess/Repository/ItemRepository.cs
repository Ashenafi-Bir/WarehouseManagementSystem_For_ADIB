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
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        private ApplicationDbContext _db;
        public ItemRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(Item item)
        {
            var objFromDb = _db.Items.FirstOrDefault(i => i.ItemID == item.ItemID);
            if (objFromDb != null)
            {
                objFromDb.Description = item.Description;
                objFromDb.Unit = item.Unit;
                objFromDb.Quantity = item.Quantity;
                objFromDb.UnitPrice = item.UnitPrice;
                objFromDb.POId = item.POId;
                // TotalPrice is computed and should not be manually updated.
            }
        }
    }
   
}
