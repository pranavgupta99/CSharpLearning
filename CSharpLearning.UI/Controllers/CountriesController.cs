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

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetInt32("userId") != null)
            {
                List<CountryViewModels> vm = new List<CountryViewModels>();
                var countries = await _countryRepo.GetAll();
                foreach (var country in countries)
                {
                    vm.Add(new CountryViewModels { Id = country.Id, Name = country.Name });
                }
                return View(vm);
            }
            return RedirectToAction("Login", "Auth");
        }
        [HttpGet]
        public IActionResult Create()
        {
            CreateCountryViewModel country = new CreateCountryViewModel();
            return View(country);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCountryViewModel vm)
        {
            var country = new Country
            {
                Name = vm.Name,
            };
            _countryRepo.Save(country);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {   
            var country = await _countryRepo.GetById(id);
            CountryViewModels vm = new CountryViewModels
            {
                Id = country.Id,
                Name = country.Name,
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CountryViewModels vm)
        {
            var country = new Country
            {
                Id= vm.Id,
                Name = vm.Name,
            };
            await _countryRepo.Edit(country);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var country = await _countryRepo.GetById(id);
            await _countryRepo.RemoveData(country);
            return RedirectToAction("Index");
        }
    }
}
