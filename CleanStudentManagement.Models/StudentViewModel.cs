using CleanStudentManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.Models
{
    public class StudentViewModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string UserName { get; set; }
        public string? Contact { get; set; }

        public StudentViewModel(Student student)
        {
            StudentId = student.Id;
            StudentName = student.Name;
            UserName = student.UserName;
            Contact = student.Contact;
        }
    } 
}
