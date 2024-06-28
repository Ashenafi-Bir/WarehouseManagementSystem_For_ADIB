using Microsoft.AspNetCore.Mvc;
using WMS_FOR_ADIB.DataAccess.Repository.IRepository;
using WMS_FOR_ADIB.Models;
using System.Linq;

namespace WMS_FOR_ADIB_PROJECT.Areas.PurchaseOrder.Controllers
{
    [Area("PurchaseOrder")]
    public class PurchaseOrderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseOrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var purchaseOrders = _unitOfWork.PurchaseOrder.GetAll(includeProperties: "Supplier").ToList();
            return View(purchaseOrders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(WMS_FOR_ADIB.Models.PurchaseOrder purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.PurchaseOrder.Add(purchaseOrder);
                _unitOfWork.Save();
                TempData["success"] = "Purchase Order created successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(purchaseOrder);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var purchaseOrder = _unitOfWork.PurchaseOrder.Get(p => p.POId == id, includeProperties: "Supplier");

            if (purchaseOrder == null)
            {
                return NotFound();
            }

            return View(purchaseOrder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(WMS_FOR_ADIB.Models.PurchaseOrder purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.PurchaseOrder.Update(purchaseOrder);
                _unitOfWork.Save();
                TempData["success"] = "Purchase Order updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(purchaseOrder);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var purchaseOrder = _unitOfWork.PurchaseOrder.Get(p => p.POId == id, includeProperties: "Supplier");

            if (purchaseOrder == null)
            {
                return NotFound();
            }

            return View(purchaseOrder);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            var purchaseOrder = _unitOfWork.PurchaseOrder.Get(p => p.POId == id!.Value);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            _unitOfWork.PurchaseOrder.Remove(purchaseOrder);
            _unitOfWork.Save();
            TempData["success"] = "Purchase Order deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        // Add the Details action method here
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var purchaseOrderFromDb = _unitOfWork.PurchaseOrder.Get(p => p.POId == id, includeProperties: "Supplier");

            if (purchaseOrderFromDb == null)
            {
                return NotFound();
            }

            return View(purchaseOrderFromDb);
        }
    }
}
