using CSharpLearning.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CSharpLearning.Web.Controllers
{
    //localhost:port/Controllername/actionname
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<People> people = new List<People>();
            people.Add(new People { Id = 1, Name = "Pranav" , City = "Delhi"});
            people.Add(new People { Id = 2, Name = "Ram" , City = "Chennai"});
            people.Add(new People { Id = 3, Name = "Aastha" , City = "Chandigarh"});
            people.Add(new People { Id = 4, Name = "Piya" , City = "Nagpur"});
            return View("Index",people);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
