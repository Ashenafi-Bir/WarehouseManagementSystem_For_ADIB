using Microsoft.AspNetCore.Mvc;
using WMS_FOR_ADIB.DataAccess.Repository.IRepository;
using WMS_FOR_ADIB.Models;

namespace WMS_FOR_ADIB_PROJECT.Controllers
{
    public class ItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ItemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Item> objItemList = _unitOfWork.Item.GetAll().ToList();
            return View(objItemList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Item.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Item created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var itemFromDb = _unitOfWork.Item.Get(u => u.ItemID == id);

            if (itemFromDb == null)
            {
                return NotFound();
            }
            return View(itemFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Item obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Item.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Item updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var itemFromDb = _unitOfWork.Item.Get(u => u.ItemID == id);

            if (itemFromDb == null)
            {
                return NotFound();
            }
            return View(itemFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Item.Get(u => u.ItemID == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Item.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Item deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
