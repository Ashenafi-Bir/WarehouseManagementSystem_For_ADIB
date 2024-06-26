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



        public void Update(Item obj)
        {
            _db.Items.Update(obj);
        }
    }
   
}
