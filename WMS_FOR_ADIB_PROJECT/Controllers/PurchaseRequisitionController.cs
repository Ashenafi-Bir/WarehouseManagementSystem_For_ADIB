using Microsoft.AspNetCore.Mvc;
using WMS_FOR_ADIB.DataAccess.Repository.IRepository;
using WMS_FOR_ADIB.Models;
using System.Linq;

namespace WMS_FOR_ADIB.Controllers
{
    public class PurchaseRequisitionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseRequisitionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var requisitions = _unitOfWork.PurchaseRequisition.GetAll().ToList();
            return View(requisitions);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PurchaseRequisition requisition)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.PurchaseRequisition.Add(requisition);
                _unitOfWork.Save();
                TempData["success"] = "Purchase Requisition created successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(requisition);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var requisition = _unitOfWork.PurchaseRequisition.Get(r => r.PRId == id);

            if (requisition == null)
            {
                return NotFound();
            }

            return View(requisition);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(PurchaseRequisition requisition)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.PurchaseRequisition.Update(requisition);
                _unitOfWork.Save();
                TempData["success"] = "Purchase Requisition updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(requisition);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var requisition = _unitOfWork.PurchaseRequisition.Get(r => r.PRId == id);

            if (requisition == null)
            {
                return NotFound();
            }

            return View(requisition);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            var requisition = _unitOfWork.PurchaseRequisition.Get(p => p.PRId == id!.Value);
            if (requisition == null)
            {
               
                return NotFound();
            }

            _unitOfWork.PurchaseRequisition.Remove(requisition);
            _unitOfWork.Save();
            TempData["success"] = "Purchase Requisition deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        // Add the Details action method here
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var requisition = _unitOfWork.PurchaseRequisition.Get(r => r.PRId == id);

            if (requisition == null)
            {
                return NotFound();
            }

            return View(requisition);
        }
    }
}
