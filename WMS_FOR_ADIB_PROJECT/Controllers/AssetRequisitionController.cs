using Microsoft.AspNetCore.Mvc;
using WMS_FOR_ADIB.DataAccess.Repository.IRepository;
using WMS_FOR_ADIB.Models;
using System.Linq;

namespace WMS_FOR_ADIB.Controllers
{
    public class AssetRequisitionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssetRequisitionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var assetRequisitions = _unitOfWork.AssetRequisition.GetAll().ToList();
            return View(assetRequisitions);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AssetRequistion assetRequisition)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.AssetRequisition.Add(assetRequisition);
                _unitOfWork.Save();
                TempData["success"] = "Asset Requisition created successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(assetRequisition);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var assetRequisition = _unitOfWork.AssetRequisition.Get(a => a.RequisitionID == id);
            if (assetRequisition == null)
            {
                return NotFound();
            }

            return View(assetRequisition);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AssetRequistion assetRequisition)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.AssetRequisition.Update(assetRequisition);
                _unitOfWork.Save();
                TempData["success"] = "Asset Requisition updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(assetRequisition);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var assetRequisition = _unitOfWork.AssetRequisition.Get(a => a.RequisitionID == id);
            if (assetRequisition == null)
            {
                return NotFound();
            }

            return View(assetRequisition);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            var assetRequisition = _unitOfWork.AssetRequisition.Get(a => a.RequisitionID == id);
            if (assetRequisition == null)
            {
                return NotFound();
            }

            _unitOfWork.AssetRequisition.Remove(assetRequisition);
            _unitOfWork.Save();
            TempData["success"] = "Asset Requisition deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var assetRequisitionFromDb = _unitOfWork.AssetRequisition.Get(a => a.RequisitionID == id);

            if (assetRequisitionFromDb == null)
            {
                return NotFound();
            }
            return View(assetRequisitionFromDb);
        }
    }
}
