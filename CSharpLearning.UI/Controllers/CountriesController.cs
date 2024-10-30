using CSharpLearning.Entities;
using CSharpLearning.Repositories.Interfaces;
using CSharpLearning.UI.ViewModels.CountryViewModels;
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
            List<CountryViewModels> vm = new List<CountryViewModels>();
            var countries = _countryRepo.GetAll();
            foreach(var country in countries)
            {
                vm.Add(new CountryViewModels { Id = country.Id, Name = country.Name});
            }
            return View(vm);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreateCountryViewModel country = new CreateCountryViewModel();
            return View(country);
        }

        [HttpPost]
        public IActionResult Create(CreateCountryViewModel vm)
        {
            var country = new Country
            {
                Name = vm.Name,
            };
            _countryRepo.Save(country);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {   
            var country = _countryRepo.GetById(id);
            CountryViewModels vm = new CountryViewModels
            {
                Id = country.Id,
                Name = country.Name,
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(CountryViewModels vm)
        {
            var country = new Country
            {
                Id= vm.Id,
                Name = vm.Name,
            };
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
