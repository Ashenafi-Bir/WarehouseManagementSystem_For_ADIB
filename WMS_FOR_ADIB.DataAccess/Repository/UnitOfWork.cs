using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS_FOR_ADIB.DataAccess.Data;
using WMS_FOR_ADIB.DataAccess.Repository.IRepository;

namespace WMS_FOR_ADIB.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
   
        public IItemRepository Item { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Item = new ItemRepository(_db);
           
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
