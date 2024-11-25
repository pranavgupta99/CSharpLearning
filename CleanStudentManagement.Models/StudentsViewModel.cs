using CleanStudentManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.Models
{
    public class StudentsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StudentsViewModel(Student student)
        {
            Id = student.Id;
            Name = student.Name;
        }

    }
    public class CheckBoxTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }
}
