using Microsoft.AspNetCore.Mvc;
using WMS_FOR_ADIB.DataAccess.Repository.IRepository;
using WMS_FOR_ADIB.Models;
using System.Linq;

namespace WMS_FOR_ADIB_PROJECT.Areas.AssetReturn.Controllers
{
    [Area("AssetReturn")]
    public class AssetReturnController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssetReturnController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var assetReturns = _unitOfWork.AssetReturn.GetAll().ToList();
            return View(assetReturns);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(WMS_FOR_ADIB.Models.AssetReturn assetReturn)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.AssetReturn.Add(assetReturn);
                _unitOfWork.Save();
                TempData["success"] = "Asset Return created successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(assetReturn);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var assetReturn = _unitOfWork.AssetReturn.Get(a => a.ReturnID == id);
            if (assetReturn == null)
            {
                return NotFound();
            }

            return View(assetReturn);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(WMS_FOR_ADIB.Models.AssetReturn assetReturn)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.AssetReturn.Update(assetReturn);
                _unitOfWork.Save();
                TempData["success"] = "Asset Return updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(assetReturn);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var assetReturn = _unitOfWork.AssetReturn.Get(a => a.ReturnID == id);
            if (assetReturn == null)
            {
                return NotFound();
            }

            return View(assetReturn);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            var assetReturn = _unitOfWork.AssetReturn.Get(a => a.ReturnID == id);
            if (assetReturn == null)
            {
                return NotFound();
            }

            _unitOfWork.AssetReturn.Remove(assetReturn);
            _unitOfWork.Save();
            TempData["success"] = "Asset Return deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var assetReturnFromDb = _unitOfWork.AssetReturn.Get(a => a.ReturnID == id);

            if (assetReturnFromDb == null)
            {
                return NotFound();
            }
            return View(assetReturnFromDb);
        }
    }
}
