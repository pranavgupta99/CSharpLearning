using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.Data.Entities
{
    public class Exams
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public int Time { get; set; }
        public int GroupsId { get; set; }
        public virtual Groups Groups { get; set; }
        public ICollection<ExamResults> ExamResults { get; set; }
        public ICollection<QnAs> QnAs { get; set; }
    }
}
