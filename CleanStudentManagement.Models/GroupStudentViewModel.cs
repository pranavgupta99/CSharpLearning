using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.Models
{
    public class GroupStudentViewModel
    {
        public int GroupId { get; set; }
        public List<CheckBoxTable> StudentList { get; set; } = new();
    }
}
