using CSharpLearning.UI.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.UI.ViewModels.SkillViewModels
{
    public class CreateSkillViewModel
    {
        [UpperCase]
        public string Title { get; set; }
    }
}
