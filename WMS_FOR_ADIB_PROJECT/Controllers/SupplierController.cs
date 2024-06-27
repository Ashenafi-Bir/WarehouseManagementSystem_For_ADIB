using Microsoft.AspNetCore.Mvc;
using WMS_FOR_ADIB.DataAccess.Repository.IRepository;
using WMS_FOR_ADIB.Models;
using System.Linq;

namespace WMS_FOR_ADIB.Controllers
{
    public class SupplierController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public SupplierController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var suppliers = _unitOfWork.Supplier.GetAll().ToList();
            return View(suppliers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Supplier.Add(supplier);
                _unitOfWork.Save();
                TempData["success"] = "Supplier created successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var supplier = _unitOfWork.Supplier.Get(s => s.SupplierID == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Supplier.Update(supplier);
                _unitOfWork.Save();
                TempData["success"] = "Supplier updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(supplier);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var supplier = _unitOfWork.Supplier.Get(s => s.SupplierID == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            var supplier = _unitOfWork.Supplier.Get(s => s.SupplierID == id);
            if (supplier == null)
            {
                return NotFound();
            }

            _unitOfWork.Supplier.Remove(supplier);
            _unitOfWork.Save();
            TempData["success"] = "Supplier deleted successfully";
            return RedirectToAction(nameof(Index));
        }
        // Add the Details action method here
        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var supplierFromDb = _unitOfWork.Supplier.Get(s => s.SupplierID == id);

            if (supplierFromDb == null)
            {
                return NotFound();
            }
            return View(supplierFromDb);
        }
    }
}
