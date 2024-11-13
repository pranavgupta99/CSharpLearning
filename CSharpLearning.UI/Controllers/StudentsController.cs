using CSharpLearning.Entities;
using CSharpLearning.Repositories.Interfaces;
using CSharpLearning.UI.ViewModels.StudentViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CSharpLearning.UI.Controllers
{
    public class StudentsController : Controller
    {
        private IStudentRepo _studentRepo;
        private ISkillRepo _skillRepo;

        public StudentsController(IStudentRepo studentRepo, ISkillRepo skillRepo)
        {
            _studentRepo = studentRepo;
            _skillRepo = skillRepo;
        }

        public async Task<IActionResult> Index()
        {
            var students = await _studentRepo.GetAll();
            List<StudentViewModel> studentList = new List<StudentViewModel>();
            foreach (var student in students)
            {
                studentList.Add(new StudentViewModel { Id = student.Id, Name = student.Name });
            }
            return View(studentList);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CreateStudentViewModel vm = new CreateStudentViewModel();
            var skills = await _skillRepo.GetAll();
            foreach (var skill in skills)
            {
                vm.SkillsList.Add(new CheckBoxTable { SkillId = skill.Id, SkillName = skill.Title, IsChecked = false });
            }
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentViewModel vm)
        {
            var student = new Student
            {
                Name = vm.StudentName,
                PermanentAddress = vm.PhysicalAddress
            };
            var selectedSkillIds = vm.SkillsList.Where(x => x.IsChecked == true)
                .Select(y => y.SkillId).ToList();
            foreach (var skillId in selectedSkillIds)
            {
                student.StudentSkills.Add(new StudentSkills
                {
                    SkillId = skillId
                });
            }
            await _studentRepo.Save(student);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit (int id)
        {
            EditStudentViewModel vm = new EditStudentViewModel();
            var student = await _studentRepo.GetById(id);
            vm.StudentName = student.Name;
            vm.PhysicalAddress = student.PermanentAddress;
            var existtingSkillIds = student.StudentSkills.Select(x => x.SkillId).ToList();

            var skills = await _skillRepo.GetAll();
            foreach (var skill in skills)
            {
                vm.SkillsList.Add(new CheckBoxTable 
                {
                    SkillId = skill.Id, 
                    SkillName = skill.Title,
                    IsChecked = existtingSkillIds.Contains(skill.Id)
                });
            }
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditStudentViewModel vm)
        {
            var student = await _studentRepo.GetById(vm.Id);
            var existtingSkillIds = student.StudentSkills.Select(x => x.SkillId).ToList();
            student.Name = vm.StudentName;
            student.PermanentAddress = vm.PhysicalAddress;
            var selectedSkillIds = vm.SkillsList.Where(x => x.IsChecked == true)
                .Select(y => y.SkillId).ToList();
            
            var toRemove = existtingSkillIds.Except(selectedSkillIds).ToList();
            var toAdd = selectedSkillIds.Except(existtingSkillIds).ToList();
            foreach (var skillId in toRemove)
            {
                var studentSkill = student.StudentSkills.FirstOrDefault(x=>x.SkillId == skillId);
                student.StudentSkills.Remove(studentSkill);
            }
            foreach (var skillId in toAdd)
            {
                student.StudentSkills.Add(new StudentSkills
                {
                    SkillId = skillId
                });
            }
            await _studentRepo.Edit(student);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _studentRepo.GetById(id);
            await _studentRepo.RemoveData(student);
            return RedirectToAction("Index");
        }
    }
}
