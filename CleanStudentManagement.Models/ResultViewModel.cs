using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.Models
{
    public class ResultViewModel
    {
        public int StudentId { get; set; }
        public string ExamId { get; set; }
        public int ToralQuestion { get; set; }
        public int CorrectAnswer { get; set; }
        public int WrongAnswer { get; set; }
    }
}
