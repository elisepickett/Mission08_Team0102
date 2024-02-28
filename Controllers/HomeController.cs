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
        private readonly string _connectionString;

        public HomeController(TaskSubmissionContext temp, IConfiguration configuration)
        {
            _context = temp;
            _connectionString = configuration.GetConnectionString("TaskConnection");
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTask()
        {
            ViewBag.Tasks = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddTask", new Task());
        }

        [HttpPost]
        public IActionResult AddTask(Task response) 
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Add(response); 
                _context.SaveChanges();

                return View("Index", response);
            }
            else //invalid data
            {
                ViewBag.Tasks = _context.Tasks
                    .OrderBy(x => x.TaskName)
                    .ToList();

                return View(response);
            }
        }

        public IActionResult EditTask()
        {
            var tasks = _context.Tasks
                .OrderBy(x => x.TaskName).ToList();

            return View(AddTask);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Tasks
                .Single(x => x.TaskId == id);

            ViewBag.Majors = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("AddTask", recordToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Task updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("EditTask");
        }
           
        public IActionResult DatabaseAction()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

            }

            return View();
        }
    }
}
