using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.UI.ViewModels.CitiesViewModel
{
    public class EditCityViewModel
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        [Display(Name = "State Names")]
        public int StateId{ get; set; }
    }
}
