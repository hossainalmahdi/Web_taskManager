﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using taskManagerWeb.Data;
using taskManagerWeb.Models;

namespace taskManagerWeb.Controllers
{
    public class CategoryController : Controller
    {
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
        //-----------------------CREATE-----------------------
        //GET
        public IActionResult Create()
        {
            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString()) 
            {
                ModelState.AddModelError("Name", "The Name field cannot be the same as the Display Order field.");
            
            }
            if (obj.Name == obj.Comments.ToString())
            {
                ModelState.AddModelError("Name", "The Name field cannot be the same as the Display Order field.");
                ModelState.AddModelError("Comments", "The Task Notes field cannot be the same as the Name field.");

            }
            if (ModelState.IsValid) //server side validation
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "The Entry has been created successfully.";
                return RedirectToAction("Index");
            }   
            return View();
        }

        //-----------------------EDIT-----------------------
        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            
            return View(categoryFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Name field cannot be the same as the Display Order field.");

            }
            if (obj.Name == obj.Comments.ToString())
            {
                ModelState.AddModelError("Name", "The Name field cannot be the same as the Display Order field.");
                ModelState.AddModelError("Comments", "The Task Notes field cannot be the same as the Name field.");

            }
            if (ModelState.IsValid) //server side validation
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "The Entry has been updated successfully.";
                return RedirectToAction("Index");
            }
            return View();
        }

        //-----------------------Delete-----------------------
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Categories.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
           
             _db.Categories.Remove(obj);
             _db.SaveChanges();
            TempData["success"] = "The Entry has been deleted successfully.";
            return RedirectToAction("Index");
        }
    }
}
