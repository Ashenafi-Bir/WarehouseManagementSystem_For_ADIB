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
    public class AssetReturnRepository :Repository<AssetReturn>, IAssetReturnRepository
    {
        private ApplicationDbContext _db;
        public AssetReturnRepository(ApplicationDbContext db) :base(db) 
        {
            _db = db;
        }
        public void Update(AssetReturn assetReturn)
        {
            var objFromDb = _db.AssetReturns.FirstOrDefault(a => a.ReturnID == assetReturn.ReturnID);
            if (objFromDb != null)
            {
                objFromDb.BranchCode = assetReturn.BranchCode;
                objFromDb.DateReturned = assetReturn.DateReturned;
                objFromDb.Status = assetReturn.Status;
                objFromDb.ReturnedBY = assetReturn.ReturnedBY;
                objFromDb.ApprovedBY = assetReturn.ApprovedBY;
                objFromDb.ReceivedBy = assetReturn.ReceivedBy;

                _db.SaveChanges();
            }
        }
    }
}
