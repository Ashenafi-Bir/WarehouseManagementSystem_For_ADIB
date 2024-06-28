using Microsoft.AspNetCore.Mvc;
using WMS_FOR_ADIB.DataAccess.Repository.IRepository;
using WMS_FOR_ADIB.Models;
using System.Linq;

namespace WMS_FOR_ADIB_PROJECT.Areas.AssetTransfer.Controllers
{
    [Area("AssetTransfer")]
    public class AssetTransferController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssetTransferController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var assetTransfers = _unitOfWork.AssetTransfer.GetAll().ToList();
            return View(assetTransfers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(WMS_FOR_ADIB.Models.AssetTransfer assetTransfer)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.AssetTransfer.Add(assetTransfer);
                _unitOfWork.Save();
                TempData["success"] = "Asset Transfer created successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(assetTransfer);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var assetTransfer = _unitOfWork.AssetTransfer.Get(a => a.TransferID == id);
            if (assetTransfer == null)
            {
                return NotFound();
            }

            return View(assetTransfer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(WMS_FOR_ADIB.Models.AssetTransfer assetTransfer)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.AssetTransfer.Update(assetTransfer);
                _unitOfWork.Save();
                TempData["success"] = "Asset Transfer updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(assetTransfer);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var assetTransfer = _unitOfWork.AssetTransfer.Get(a => a.TransferID == id);
            if (assetTransfer == null)
            {
                return NotFound();
            }

            return View(assetTransfer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            var assetTransfer = _unitOfWork.AssetTransfer.Get(a => a.TransferID == id);
            if (assetTransfer == null)
            {
                return NotFound();
            }

            _unitOfWork.AssetTransfer.Remove(assetTransfer);
            _unitOfWork.Save();
            TempData["success"] = "Asset Transfer deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var assetTransferFromDb = _unitOfWork.AssetTransfer.Get(a => a.TransferID == id);

            if (assetTransferFromDb == null)
            {
                return NotFound();
            }
            return View(assetTransferFromDb);
        }
    }
}
