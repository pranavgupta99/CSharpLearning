using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Default City";
        public int StateId { get; set; }
        public State State { get; set; }
    }
}
