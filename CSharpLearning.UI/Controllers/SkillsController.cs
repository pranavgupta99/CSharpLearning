using CSharpLearning.Entities;
using CSharpLearning.Repositories.Interfaces;
using CSharpLearning.UI.ViewModels.CountryViewModels;
using CSharpLearning.UI.ViewModels.SkillViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CSharpLearning.UI.Controllers
{
    public class SkillsController : Controller
    {
        private ISkillRepo _skillRepo;

        public SkillsController(ISkillRepo skillRepo)
        {
            _skillRepo = skillRepo;
        }

        public async Task<IActionResult> Index()
        {
            List<SkillViewModel> vm = new List<SkillViewModel>();
            var skills = await _skillRepo.GetAll();
            foreach (var skill in skills)
            {
                vm.Add(new SkillViewModel { Id = skill.Id, Title = skill.Title });
            }
            return View(vm);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSkillViewModel vm)
        {
            var skill = new Skill
            {
                Title = vm.Title,
            };
            _skillRepo.Save(skill);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var skill = await _skillRepo.GetById(id);
            SkillViewModel vm = new SkillViewModel
            {
                Id = skill.Id,
                Title = skill.Title,
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SkillViewModel vm)
        {
            var skill = new Skill
            {
                Id = vm.Id,
                Title = vm.Title,
            };
            await _skillRepo.Edit(skill);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var skill = await _skillRepo.GetById(id);
            await _skillRepo.RemoveData(skill);
            return RedirectToAction("Index");
        }
    }
}
