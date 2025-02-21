using CleanStudentManagement.Data.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.Models
{
    public class StudentProfileViewModel
    {
        public int Id { get; set; }
        public  string Name { get; set; }
        public  string UserName { get; set; }
        public string? Contact { get; set; }
        public string? CVFileName { get; set; }
        public IFormFile CvFileUrl { get; set; }
        public string? ProfilePicture { get; set; }
        public IFormFile ProfilePictureUrl { get; set; }
        public StudentProfileViewModel()
        {

        }
        public StudentProfileViewModel(Student student)
        {
            Id = student.Id;
            Name = student.Name;
            UserName = student.UserName;
            Contact = student.Contact;
            CVFileName = student.CVFileName;
            ProfilePicture = student.ProfilePicture;
        }
    }
}
