using Microsoft.AspNetCore.Mvc;

namespace CleanStudentManagement.UI.Controllers
{
    public class ExamsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
