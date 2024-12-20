﻿using CleanStudentManagement.Data.Entities;
using CleanStudentManagement.Data.UnitOfWork;
using CleanStudentManagement.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.DLL.Services
{
    public class StudentService : IStudentService
    {
        private IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddStudentAsync(CreateStudentViewModel vm)
        {
            try
            {
                Student obj = vm.ConvertToModel(vm);
                await _unitOfWork.GenericRepository<Student>().AddAsync(obj);
                _unitOfWork.Save();
                return 1;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<StudentsViewModel> GetAll()
        {
            try
            {
                var students = _unitOfWork.GenericRepository<Student>().GetAll().ToList();
                List<StudentsViewModel> studentViewModelList = new List<StudentsViewModel>();
                studentViewModelList = ListInfo(students);
                return studentViewModelList;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<ResultViewModel> GetExamResult(int studentId)
        {
            throw new NotImplementedException();
        }

        public bool SetExamResult(AttendExamViewModel viewModel)
        {
            try
            {
                foreach (var items in viewModel.QnAsList)
                {
                    ExamResults result = new ExamResults();
                    result.StudentId = viewModel.StudentId;
                    result.ExamId = items.ExamsId;
                    //result.QnAsId = items.Id;
                    result.Answer = items.Answer;
                    _unitOfWork.GenericRepository<ExamResults>().Add(result);
                    _unitOfWork.Save();
                    return true;
                }
            }
            catch (Exception ex) { 
                throw;
            }
            return false;
        }

        public bool SetGroupIdToStudent(GroupStudentViewModel viewModel)
        {
            try
            {
                foreach(var item in viewModel.StudentList)
                {
                    var student = _unitOfWork.GenericRepository<Student>().GetById(item.Id);
                    if(item.IsChecked)
                    {
                        student.GroupId = viewModel.GroupId;
                        _unitOfWork.GenericRepository<Student>().Update(student);
                    }
                    else
                    {
                        student.GroupId = null;
                    }
                }
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        PageResult<StudentViewModel> IStudentService.GetAllStudents(int pageNumber, int PageSize)
        {
            try
            {
                int excludeRecord = (PageSize * pageNumber) - PageSize;
                List<StudentViewModel> studentViewModel = new List<StudentViewModel>();
                var studentList = _unitOfWork.GenericRepository<Student>()
                    .GetAll()
                    .Skip(excludeRecord).Take(PageSize).ToList();
                studentViewModel = ConvertToStudentVM(studentList);
                var result = new PageResult<StudentViewModel>
                {
                    Data = studentViewModel,
                    TotalItems = _unitOfWork.GenericRepository<Student>()
                    .GetAll().Count(),
                    PageNumber = pageNumber,
                    PageSize = PageSize
                };
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private List<StudentViewModel> ConvertToStudentVM(List<Student> studentList)
        {
            return studentList.Select(x => new StudentViewModel(x)).ToList();
        }

        private List<StudentsViewModel> ListInfo(List<Student> studentList)
        {
            return studentList.Select(x => new StudentsViewModel(x)).ToList();
        }

        public StudentProfileViewModel GetStudentById(int studentId)
        {
            var student = _unitOfWork.GenericRepository<Student>().GetById(studentId);
            var studentProfile = new StudentProfileViewModel(student);
            return studentProfile;
        }

        public void UpdateProfile(StudentProfileViewModel studentProfile)
        {
            try
            {
                var student = _unitOfWork.GenericRepository<Student>().GetById(studentProfile.Id);
                if (student != null)
                {
                    student.Name = studentProfile.Name;
                    student.Contact = studentProfile.Contact;
                    student.ProfilePicture = studentProfile.ProfilePicture != null ? studentProfile.ProfilePicture : student.ProfilePicture;
                    student.CVFileName = studentProfile.CVFileName != null ? studentProfile.CVFileName : student.CVFileName;


                    _unitOfWork.GenericRepository<Student>().Add(student);
                    _unitOfWork.Save();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
