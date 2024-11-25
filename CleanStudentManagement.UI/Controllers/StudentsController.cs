using AspNetCoreGeneratedDocument;
using CleanStudentManagement.DLL.Services;
using CleanStudentManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CleanStudentManagement.UI.Controllers
{
    public class StudentsController : Controller
    {
        private IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentViewModel vm)
        {
            var success = await _studentService.AddStudentAsync(vm);
            if (success > 0)
            {
                return RedirectToAction("Index");
            }
            return View(vm);
        }
        public IActionResult Index()
        {
            return View();
            //return View(_studentService.GetAllStudents(pageNumber, pageSize));
        }
    }
}
