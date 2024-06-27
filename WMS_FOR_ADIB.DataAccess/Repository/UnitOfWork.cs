using System;
using WMS_FOR_ADIB.DataAccess.Data;
using WMS_FOR_ADIB.DataAccess.Repository.IRepository;
using WMS_FOR_ADIB.Models;

namespace WMS_FOR_ADIB.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public IItemRepository Item { get; private set; }
        public ISupplierRepository Supplier { get; private set; }
        public IPurchaseOrderRepository PurchaseOrder { get; private set; }
        public IPurchaseRequisitionRepository PurchaseRequisition { get; private set; }
        public IAssetTransferRepository AssetTransfer { get; private set; }
        public IAssetDisposalRepository AssetDisposal { get; private set; }
        public IAssetRequisitionRepository AssetRequisition { get; private set; }
        public IAssetReturnRepository AssetReturn { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Item = new ItemRepository(_db);
            Supplier = new SupplierRepository(_db);
            PurchaseOrder = new PurchaseOrderRepository(_db);
            PurchaseRequisition = new PurchaseRequisitionRepository(_db);
            AssetTransfer = new AssetTransferRepository(_db);
            AssetDisposal = new AssetDisposalRepository(_db);
            AssetReturn = new AssetReturnRepository(_db);
            AssetRequisition= new AssetRequistionRepository(_db);
            
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
