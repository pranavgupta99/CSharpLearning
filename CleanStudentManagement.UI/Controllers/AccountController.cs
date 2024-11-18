using Microsoft.AspNetCore.Mvc;

namespace CleanStudentManagement.UI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
