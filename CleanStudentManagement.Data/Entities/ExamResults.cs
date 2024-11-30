using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.Data.Entities
{
    public class ExamResults
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int ExamId { get; set; }
        public virtual Exams Exams { get; set; }
        public int Answer { get; set; }
    }
}
