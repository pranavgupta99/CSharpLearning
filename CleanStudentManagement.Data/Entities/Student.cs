using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.Data.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public string? Contact { get; set; }
        public string? CVFileName { get; set; }
        public string? ProfilePicture { get; set; }
        public int? GroupId { get; set; }
        public virtual Groups Groups { get; set; }
        public virtual ICollection<ExamResults> ExamResults { get; set; }
    }
}
