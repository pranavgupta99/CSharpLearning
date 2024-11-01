using CSharpLearning.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.UI.ViewComponents
{
    public class CountCountryViewComponent : ViewComponent
    {
        private ICountryRepo _countryRepo;

        public CountCountryViewComponent(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var country = await _countryRepo.GetAll();
            int totalCountry = country.Count();
            return View(totalCountry);
        }
    }
}
