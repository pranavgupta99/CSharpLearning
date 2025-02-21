using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.Data.Entities
{
    public class QnAs
    {
        public int Id { get; set; }
        public string QuestionTitle { get; set; }
        public int ExamsId { get; set; }
        public virtual Exams Exams { get; set; }
        public int Answer { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public ICollection<ExamResults> ExamResults { get; set; } = new List<ExamResults>();
    }
}
