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
    public class AssetDisposalRepository :Repository<AssetDisposal>, IAssetDisposalRepository
    {
        private ApplicationDbContext _db;
        public AssetDisposalRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(AssetDisposal assetDisposal)
        {
            var objFromDb = _db.AssetDisposals.FirstOrDefault(a => a.DisposalID == assetDisposal.DisposalID);
            if (objFromDb != null)
            {
                objFromDb.Quantity = assetDisposal.Quantity;
                objFromDb.DateDisposed = assetDisposal.DateDisposed;
                objFromDb.Reason = assetDisposal.Reason;
                objFromDb.DisposedBy = assetDisposal.DisposedBy;
                objFromDb.ApprovedBy = assetDisposal.ApprovedBy;

                _db.SaveChanges();
            }
        }
    }
}
