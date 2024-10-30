using CSharpLearning.Entities;
using CSharpLearning.Repositories.Interfaces;
using CSharpLearning.UI.ViewModels.StateViewModels;
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
            var vm = new List<StateViewModel>();
            foreach (var state in states)
            {
                vm.Add(new StateViewModel { Id = state.Id, StateName = state.Name, CountryName = state.Country.Name });
            }
            return View(vm);
        }
        [HttpGet]
        public IActionResult Create()
        {
            var countries = _countryRepo.GetAll();
            ViewBag.CountryList = new SelectList(countries, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateStateViewModel vm)
        {
            var state = new State
            {
                Name = vm.StateName,
                CountryId = vm.CountryId,
            };
            _stateRepo.Save(state);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var state = _stateRepo.GetByID(id);
            var vm = new EditStateViewModel
            {
                Id = state.Id,
                StateName = state.Name,
                CountryId = state.CountryId,
            };
            var countries = _countryRepo.GetAll();
            ViewBag.CountryList = new SelectList(countries, "Id", "Name");
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(EditStateViewModel vm)
        {
            var state = new State
            {
                Id = vm.Id,
                Name = vm.StateName,
                CountryId = vm.CountryId,
            };
            _stateRepo.Edit(state);
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
