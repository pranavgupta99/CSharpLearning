using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.Models
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "User Name Field is Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password Field is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public int  Role { get; set; }
    }
}
