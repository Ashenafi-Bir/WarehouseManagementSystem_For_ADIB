using Microsoft.AspNetCore.Mvc;
using WMS_FOR_ADIB.DataAccess.Repository.IRepository;
using WMS_FOR_ADIB.Models;
using System.Collections.Generic;
using System.Linq;

namespace WMS_FOR_ADIB.Controllers
{
    public class BranchController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public BranchController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var branches = _unitOfWork.Branch.GetAll().ToList();
            return View(branches);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Branch branch)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Branch.Add(branch);
                _unitOfWork.Save();
                TempData["success"] = "Branch created successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(branch);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var branch = _unitOfWork.Branch.Get(b => b.BranchID == id);
            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Branch branch)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Branch.Update(branch);
                _unitOfWork.Save();
                TempData["success"] = "Branch updated successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(branch);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var branch = _unitOfWork.Branch.Get(b => b.BranchID == id);
            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            var branch = _unitOfWork.Branch.Get(b => b.BranchID == id);
            if (branch == null)
            {
                return NotFound();
            }

            _unitOfWork.Branch.Remove(branch);
            _unitOfWork.Save();
            TempData["success"] = "Branch deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var branch = _unitOfWork.Branch.Get(b => b.BranchID == id);
            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }
    }
}
