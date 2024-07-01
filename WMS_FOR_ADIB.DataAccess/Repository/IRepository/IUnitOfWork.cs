namespace WMS_FOR_ADIB.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IItemRepository Item { get; }
        ISupplierRepository Supplier { get; }
        IPurchaseOrderRepository PurchaseOrder { get; }
        IPurchaseRequisitionRepository PurchaseRequisition { get; }
        IAssetDisposalRepository AssetDisposal { get; }
        IAssetReturnRepository AssetReturn { get; } 
        IAssetTransferRepository AssetTransfer { get; }
       IAssetRequisitionRepository AssetRequisition { get; }
        IBranchRepository Branch { get; }
        void Save();
    }
}
