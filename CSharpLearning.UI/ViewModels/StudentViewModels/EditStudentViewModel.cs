using CSharpLearning.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.UI.ViewModels.StudentViewModels
{
    public class EditStudentViewModel
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public Address PhysicalAddress { get; set; }
        public List<CheckBoxTable> SkillsList { get; set; } = new List<CheckBoxTable>();
    }
}
