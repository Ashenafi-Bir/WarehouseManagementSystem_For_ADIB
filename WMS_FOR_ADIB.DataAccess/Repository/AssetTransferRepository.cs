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
    public class AssetTransferRepository: Repository<AssetTransfer> ,IAssetTransferRepository
    {
        private ApplicationDbContext _db;
        public AssetTransferRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(AssetTransfer assetTransfer)
        {
            var objFromDb = _db.AssetTransfers.FirstOrDefault(a => a.TransferID == assetTransfer.TransferID);
            if (objFromDb != null)
            {
                objFromDb.FromBranchCode = assetTransfer.FromBranchCode;
                objFromDb.ToBranchCode = assetTransfer.ToBranchCode;
                objFromDb.Quantity = assetTransfer.Quantity;
                objFromDb.DateTransferred = assetTransfer.DateTransferred;
                objFromDb.Status = assetTransfer.Status;
                objFromDb.RequestedBy = assetTransfer.RequestedBy;
                objFromDb.ApprovedBy = assetTransfer.ApprovedBy;
                objFromDb.ReceivedBy = assetTransfer.ReceivedBy;

                _db.SaveChanges();
            }
        }
    }
}
