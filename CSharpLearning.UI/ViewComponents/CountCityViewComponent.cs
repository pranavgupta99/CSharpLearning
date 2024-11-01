using CSharpLearning.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.UI.ViewComponents
{
    public class CountCityViewComponent : ViewComponent
    {
        private ICityRepo _cityRepo;

        public CountCityViewComponent(ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cities = await _cityRepo.GetAll();
            int totalCities =  cities.Count();
            return View(totalCities);
        }
    }
}
