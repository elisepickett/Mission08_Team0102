using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Mission08_Team0102.Models;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Mission08_Team0102.Controllers
{
    public class HomeController : Controller
    {
        private TaskSubmissionContext _context;

        public HomeController(TaskSubmissionContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddTask", new Tasklist());
        }

        [HttpPost]
        public IActionResult AddTask(Tasklist response) 
        {
            if (ModelState.IsValid)
            {
                _context.Tasklists.Add(response); 
                _context.SaveChanges();

                return View("Index", response);
            }
            else //invalid data
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(response);
            }
        }

        public IActionResult EditTask()
        {
            var tasks = _context.Tasklists
                .OrderBy(x => x.TaskName).ToList();

            ViewBag.Categories = _context.Categories
                .ToList();

            return View(tasks);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Tasklists
                .Single(x => x.TaskId == id);

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddTask", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Tasklist updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("EditTask");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Tasklists
                .Single(x => x.TaskId == id);

            return View(recordToDelete);
        }

        [HttpPost]
        public IActionResult Delete(Tasklist tasklist)
        {
            _context.Tasklists.Remove(tasklist);
            _context.SaveChanges();

            return RedirectToAction("TasklistView");
        }
    }
}
