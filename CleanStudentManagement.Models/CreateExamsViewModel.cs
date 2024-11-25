using CleanStudentManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.Models
{
    public class CreateExamsViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int Time { get; set; }
        public int GroupsId { get; set; }
        public Exams ConvertToModel(CreateExamsViewModel vm)
        {
            return new Exams
            {
                Title = vm.Title,
                Description = vm.Description,
                StartDate = vm.StartDate,
                Time = vm.Time,
                GroupsId = vm.GroupsId,
            };
        }
    }
}
