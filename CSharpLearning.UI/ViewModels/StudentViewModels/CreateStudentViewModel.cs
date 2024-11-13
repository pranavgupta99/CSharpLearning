using CSharpLearning.Entities;

namespace CSharpLearning.UI.ViewModels.StudentViewModels
{
    public class CreateStudentViewModel
    {
        public string StudentName { get; set; }
        public Address PhysicalAddress { get; set; }
        public List<CheckBoxTable> SkillsList { get; set; } = new List<CheckBoxTable>();
    }
    public class CheckBoxTable
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; } = "Default";
        public bool IsChecked { get; set; }
    }
}
