﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.Entities
{
    //Student  ----> multiple skills
    //skill ---> multiple student -- Many to Many relationship
    public class Skill
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public ICollection<StudentSkills> StudentSkills { get; set; } = new List<StudentSkills>();
    }
}
