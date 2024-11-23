using CleanStudentManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.Models
{
    public class TeacherViewModel
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Role { get; set; }

        public TeacherViewModel(Users user)
        {
            Name = user.Name;
            UserName = user.UserName;
            EnumRoles enumRole = (EnumRoles)user.Role;
            Role = enumRole.ToString();
        }
    }
}
