using Microsoft.AspNetCore.Mvc;
using WMS_FOR_ADIB.DataAccess.Repository.IRepository;
using WMS_FOR_ADIB.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace WMS_FOR_ADIB_PROJECT.Areas.PurchaseRequisition.Controllers
{
    [Area("PurchaseRequistion")]
    public class PurchaseRequisitionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<IdentityUser> _userManager;

        public PurchaseRequisitionController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
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
        public IActionResult Create(WMS_FOR_ADIB.Models.PurchaseRequisition requisition)
        {
            if (ModelState.IsValid)
            {
                var currentUser = _userManager.GetUserName(User);
                requisition.RequestedBy = currentUser;
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
        public IActionResult Edit(WMS_FOR_ADIB.Models.PurchaseRequisition requisition)
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

            return PartialView("_AuthorizePartialView", requisition);
        }

        [HttpPost]
        public IActionResult Authorize(int id, string authorizedBy)
        {
            var requisition = _unitOfWork.PurchaseRequisition.Get(r => r.PRId == id);
            if (requisition == null)
            {
                return NotFound();
            }

            requisition.AuthorizedBy = authorizedBy;
            _unitOfWork.PurchaseRequisition.Update(requisition);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Requisition authorized successfully" });
        }
    }
}
