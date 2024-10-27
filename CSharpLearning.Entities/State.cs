using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearning.Entities
{
    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Default State";
        public int CountryId { get; set; } //Foreign key
        public Country? Country { get; set; }
        public ICollection<City> City { get; set; } = new HashSet<City>();
    }
}
