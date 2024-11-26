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
        public int QnAsId { get; set; }
        public int ExamId { get; set; }
        public int Answer { get; set; }
    }
}
