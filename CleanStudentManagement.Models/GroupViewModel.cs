using CleanStudentManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.Models
{
    public class GroupViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public GroupViewModel() 
        {
                
        }

        public GroupViewModel(Groups groups)
        {
            Id = groups.Id;
            Name = groups.Name;
            Description = groups.Description;
        }

        public Groups ConverttoGroup( GroupViewModel groupViewModel)
        {
            return new Groups
            {
                Id = groupViewModel.Id,
                Name = groupViewModel.Name,
                Description = groupViewModel.Description,
            };
        }
    }
}
