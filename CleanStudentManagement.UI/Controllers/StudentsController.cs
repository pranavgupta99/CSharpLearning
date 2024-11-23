using Microsoft.AspNetCore.Mvc;

namespace CleanStudentManagement.UI.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
