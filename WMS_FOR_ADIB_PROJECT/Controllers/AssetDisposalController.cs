using Microsoft.AspNetCore.Mvc;
using WMS_FOR_ADIB.DataAccess.Repository.IRepository;
using WMS_FOR_ADIB.Models;
using System.Linq;

namespace WMS_FOR_ADIB.Controllers
{
    public class AssetDisposalController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssetDisposalController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var assetDisposals = _unitOfWork.AssetDisposal.GetAll().ToList();
            return View(assetDisposals);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AssetDisposal assetDisposal)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.AssetDisposal.Add(assetDisposal);
                _unitOfWork.Save();
                TempData["success"] = "Asset Disposal created successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(assetDisposal);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var assetDisposal = _unitOfWork.AssetDisposal.Get(a => a.DisposalID == id);
            if (assetDisposal == null)
            {
                return NotFound();
            }

            return View(assetDisposal);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AssetDisposal assetDisposal)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.AssetDisposal.Update(assetDisposal);
                _unitOfWork.Save();
                TempData["success"] = "Asset Disposal updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(assetDisposal);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var assetDisposal = _unitOfWork.AssetDisposal.Get(a => a.DisposalID == id);
            if (assetDisposal == null)
            {
                return NotFound();
            }

            return View(assetDisposal);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            var assetDisposal = _unitOfWork.AssetDisposal.Get(a => a.DisposalID == id);
            if (assetDisposal == null)
            {
                return NotFound();
            }

            _unitOfWork.AssetDisposal.Remove(assetDisposal);
            _unitOfWork.Save();
            TempData["success"] = "Asset Disposal deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var assetDisposalFromDb = _unitOfWork.AssetDisposal.Get(a => a.DisposalID == id);

            if (assetDisposalFromDb == null)
            {
                return NotFound();
            }
            return View(assetDisposalFromDb);
        }
    }
}
