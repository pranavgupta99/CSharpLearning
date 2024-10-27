using CSharpLearning.Entities;
using CSharpLearning.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CSharpLearning.UI.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountryRepo _countryRepo;

        public CountriesController(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }

        public IActionResult Index()
        {
            var countries = _countryRepo.GetAll();
            return View(countries);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Country country = new Country();
            return View(country);
        }

        [HttpPost]
        public IActionResult Create(Country country)
        {
            _countryRepo.Save(country);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {   
            var country = _countryRepo.GetById(id);
            return View(country);
        }

        [HttpPost]
        public IActionResult Edit(Country country)
        {
            _countryRepo.Edit(country);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var country = _countryRepo.GetById(id);
            _countryRepo.RemoveData(country);
            return RedirectToAction("Index");
        }
    }
}
