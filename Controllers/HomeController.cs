using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Mission08_Team0102.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Mission08_Team0102.Controllers
{
    public class HomeController : Controller
    {
        private IRepository _repo;

        public HomeController(IRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddTask", new Tasklist());
        }

        [HttpPost]
        public IActionResult AddTask(Tasklist response) 
        {
            if (ModelState.IsValid)
            {
                _repo.Add(response);

                return View("Index", response);
            }
            else //invalid data
            {
                ViewBag.Categories = _repo.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(response);
            }
        }

        public IActionResult EditTask()
        {
            var tasks = _repo.Tasklists
                .OrderBy(x => x.TaskName).ToList();

            ViewBag.Categories = _repo.Categories
                .ToList();

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _repo.Tasklists
                .Single(x => x.TaskId == id);

            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddTask", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Tasklist updatedInfo)
        {
            _repo.Update(updatedInfo);

            return RedirectToAction("EditTask");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _repo.Tasklists
                .Single(x => x.TaskId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Tasklist tasklist)
        {
            _repo.Remove(tasklist);

            return RedirectToAction("EditTask");
        }

        public IActionResult Quadrant()
        {
            var tasks = _repo.Tasklists
                .OrderBy(x => x.TaskName).ToList();

            ViewBag.Categories = _repo.Categories
                .ToList();

            return View(tasks);
        }
    }
}
