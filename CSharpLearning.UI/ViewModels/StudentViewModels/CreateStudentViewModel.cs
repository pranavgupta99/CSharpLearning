using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.UI.ViewModels.StudentViewModels
{
    public class CreateStudentViewModel
    {
        public string StudentName { get; set; }
        public List<CheckBoxTable> SkillsList { get; set; } = new List<CheckBoxTable>();
    }
    public class CheckBoxTable
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }
        public bool IsChecked { get; set; }
    }
}
