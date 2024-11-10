using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.Entities
{
    public class StudentSkills
    {
        public int StudentId { get; set; } // Foreign Key
        public Student Student { get; set; }
        public int SkillId { get; set; } // Foreign Key
        public Skill Skill { get; set; }
    }
}


//Composite key-- If there are two/Multiple primary key and both/all of then are the foreign key for some table then it is 
// caled composite key. 
//And the use of composite is is not to create a duplicate data. 
