using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.Entities
{
    //Student(1- one) -------(*-Many)StudentSkill ------- (1) Skill
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address PermanentAddress { get; set; }
        public ICollection<StudentSkills> StudentSkills { get; set; } = new List<StudentSkills>();
    }
}
