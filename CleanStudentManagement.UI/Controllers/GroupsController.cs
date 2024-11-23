using CleanStudentManagement.DLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace CleanStudentManagement.UI.Controllers
{
    public class GroupsController : Controller
    {
        private IGroupService groupService;

        public GroupsController(IGroupService groupService)
        {
            this.groupService = groupService;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
