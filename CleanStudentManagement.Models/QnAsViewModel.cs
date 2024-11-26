using CleanStudentManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.Models
{
    public class QnAsViewModel
    {
        public int Id { get; set; }
        public string QuestionTitle { get; set; }
        public int ExamsId { get; set; }
        public int Answer { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }

        public QnAsViewModel(QnAs model)
        {
            Id = model.Id;
            QuestionTitle = model.QuestionTitle;
            ExamsId = model.ExamsId;
            Answer = model.Answer;
            Option1 = model.Option1;
            Option2 = model.Option2;
            Option3 = model.Option3;
            Option4 = model.Option4;

        }

    }
}
