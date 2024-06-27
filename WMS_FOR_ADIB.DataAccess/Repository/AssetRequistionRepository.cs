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
    public class AssetRequistionRepository : Repository<AssetRequistion>, IAssetRequisitionRepository
    {
        private ApplicationDbContext _db;

        public AssetRequistionRepository(ApplicationDbContext db): base(db) 
        {
            _db = db;
        }
        public void Update(AssetRequistion assetRequisition)
        {
            var objFromDb = _db.AssetRequistions.FirstOrDefault(a => a.RequisitionID == assetRequisition.RequisitionID);
            if (objFromDb != null)
            {
                objFromDb.BranchCode = assetRequisition.BranchCode;
                objFromDb.Quantity = assetRequisition.Quantity;
                objFromDb.RequestedBy = assetRequisition.RequestedBy;
                objFromDb.DateRequested = assetRequisition.DateRequested;
                objFromDb.ApprovedBy = assetRequisition.ApprovedBy;
                objFromDb.DateApproved = assetRequisition.DateApproved;
                objFromDb.IssuedBy = assetRequisition.IssuedBy;
                objFromDb.DateDispatched = assetRequisition.DateDispatched;
                objFromDb.Status = assetRequisition.Status;

                _db.SaveChanges();
            }
        }
    }
}
