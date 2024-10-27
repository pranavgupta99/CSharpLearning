using CSharpLearning.Entities;
using CSharpLearning.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CSharpLearning.UI.Controllers
{
    public class StatesController : Controller
    {
        //Viewbag -- Dynamic variable , //viewdata-- ["key"]=Value,     //tempdata["key"]=value
        private readonly IStateRepo _stateRepo;

        private readonly ICountryRepo _countryRepo;

        public StatesController(IStateRepo stateRepo, ICountryRepo countryRepo)
        {
            _stateRepo = stateRepo;
            _countryRepo = countryRepo;
        }

        public IActionResult Index()
        {
            var states = _stateRepo.GetAll();
            return View(states);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var countries = _countryRepo.GetAll();
            ViewBag.CountryList = new SelectList(countries, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(State states)
        {
            _stateRepo.Save(states);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var states = _stateRepo.GetByID(id);
            return View(states);
        }

        [HttpPost]
        public IActionResult Edit(State states)
        {
            _stateRepo.Edit(states);
            var countries = _countryRepo.GetAll();
            ViewBag.CountryList = new SelectList(countries, "Id", "Name");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var states = _stateRepo.GetByID(id);
            _stateRepo.RemoveData(states);
            return RedirectToAction("Index");
        }
    }
}
