using WMS_FOR_ADIB.DataAccess.Data;
using WMS_FOR_ADIB.DataAccess.Repository.IRepository;
using WMS_FOR_ADIB.Models;
using System.Linq;

namespace WMS_FOR_ADIB.DataAccess.Repository
{
    public class BranchRepository : Repository<Branch>, IBranchRepository
    {
        private readonly ApplicationDbContext _db;

        public BranchRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Branch branch)
        {
            var objFromDb = _db.Branches.FirstOrDefault(b => b.BranchID == branch.BranchID);
            if (objFromDb != null)
            {
                objFromDb.BranchName = branch.BranchName;
                objFromDb.BranchCode = branch.BranchCode;

                _db.SaveChanges();
            }
        }
    }
}
