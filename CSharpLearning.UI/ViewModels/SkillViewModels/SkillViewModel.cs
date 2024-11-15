using CSharpLearning.UI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.UI.ViewModels.SkillViewModels
{
    public class SkillViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class PageSkillViewModel
    {
        public List<SkillViewModel> Skills { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
