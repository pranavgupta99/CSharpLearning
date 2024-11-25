using CleanStudentManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.Models
{
    public class ExamViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int Time { get; set; }
        public int GroupsId { get; set; }
        public ExamViewModel(Exams model)
        {
            Id = model.Id;
            Title = model.Title;
            Description = model.Description;
            StartDate = model.StartDate;
            Time = model.Time;
            GroupsId = model.GroupsId;
        }
    }
}
