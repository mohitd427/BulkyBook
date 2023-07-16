using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Controllers

{


    public class CategoryController : Controller
    {
        // Dependency injection
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {

            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {

            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Error_Mesage", "The display order cannot have same name");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFount();
            }
            //3 ways to extract data from db
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(c => c.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(c => c.Id == id);

            if(categoryFromDb == null)
            {
                return NotFount();
            }
            return View(categoryFromDb);
        }

       

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Error_Mesage", "The display order cannot have same name");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Updated Successfully";

                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFount();
            }
            //3 ways to extract data from db
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(c => c.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(c => c.Id == id);

            if (categoryFromDb == null)
            {
                return NotFount();
            }
            return View(categoryFromDb);
        }

        private IActionResult NotFount()
        {
            throw new NotImplementedException();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePostReq(int? id)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("Error_Mesage", "The display order cannot have same name");
            //}

            //if (ModelState.IsValid)
           // {
           var obj = _db.Categories.Find(id);

            if (obj == null) return NotFount();
               
            _db.Categories.Remove(obj);
                
            _db.SaveChanges();
                
            TempData["Success"] = "Category Deleted Successfully";

            return RedirectToAction("Index");
          //  }
            
        }
       
    }
}


 


