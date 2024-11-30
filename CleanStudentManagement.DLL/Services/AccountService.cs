using CleanStudentManagement.Data.Entities;
using CleanStudentManagement.Data.Repository;
using CleanStudentManagement.Data.UnitOfWork;
using CleanStudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.DLL.Services
{
    public class AccountService : IAccountService
    {
        private IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddTeacher(UserViewModel vm)
        {
            try
            {
                Users model = new Users
                {
                    Name = vm.Name,
                    UserName = vm.UserName,
                    Password = vm.Password,
                    Role = (int)EnumRoles.Teacher
                };
                _unitOfWork.GenericRepository<Users>().Add(model);
                _unitOfWork.Save();
            }
            catch 
            {
                throw;
            }
            return true;
        }

        public PageResult<TeacherViewModel> GetAllTeacher(int pageNumber, int PageSize)
        {
            try
            {
                int excludeRecord = (PageSize * pageNumber) - PageSize;
                List<TeacherViewModel> teacherViewModels = new List<TeacherViewModel>();
                var usersList = _unitOfWork.GenericRepository<Users>()
                    .GetAll().Where(x=>x.Role == (int)EnumRoles.Teacher)
                    .Skip(excludeRecord).Take(PageSize).ToList();
                teacherViewModels = ListInfo(usersList);
                var result = new PageResult<TeacherViewModel>
                {
                    Data = teacherViewModels,
                    TotalItems = _unitOfWork.GenericRepository<Users>()
                    .GetAll().Where(x => x.Role == (int)EnumRoles.Teacher).Count(),
                    PageNumber = pageNumber,
                    PageSize = PageSize
                };
                return result;
            }
            catch(Exception ex) 
            {
                throw;
            }
        }

        private List<TeacherViewModel> ListInfo(List<Users> usersList)
        {
            return usersList.Select(x => new TeacherViewModel(x)).ToList();
        }

        public LoginViewModel Login(LoginViewModel loginViewModel)
        {
            if (loginViewModel.Role == (int)EnumRoles.Teacher || loginViewModel.Role == (int)EnumRoles.Admin)
            {
                var user = _unitOfWork.GenericRepository<Users>().GetAll().
                    FirstOrDefault(a => a.UserName == loginViewModel.UserName.Trim() &&
                    a.Password == loginViewModel.Password && a.Role == loginViewModel.Role);
                if (user != null)
                {
                    loginViewModel.Id = user.Id;
                    return loginViewModel;
                }
            }
            else
            {
                var user = _unitOfWork.GenericRepository<Student>().GetAll().
                    FirstOrDefault(a => a.UserName == loginViewModel.UserName.Trim() &&
                    a.Password == loginViewModel.Password);

                if (user != null)
                {
                    loginViewModel.Id = user.Id;
                    return loginViewModel;
                }
            }
            return null;

        }
    }
}
