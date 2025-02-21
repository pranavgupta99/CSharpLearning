using CleanStudentManagement.Data.Entities;
using CleanStudentManagement.Data.UnitOfWork;
using CleanStudentManagement.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.BLL.Services
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

        public IEnumerable<ResultViewModel> GetExamResults(int studentId)
        {
            try
            {
                var examResults = _unitOfWork.GenericRepository<ExamResults>().GetAll().Where(x => x.StudentId == studentId);
                var students = _unitOfWork.GenericRepository<Student>().GetAll();
                var exams = _unitOfWork.GenericRepository<Exams>().GetAll();
                var qnas = _unitOfWork.GenericRepository<QnAs>().GetAll();

                var requiredData = examResults.Join(students, er => er.StudentId, s => s.Id, (er, st) => new { er, st })
                    .Join(exams, erj => erj.er.ExamId, ex => ex.Id, (erj, ex) => new { erj, ex })
                    .Join(qnas, exj => exj.erj.er.QnAsId, q => q.Id, (exj, q) =>
                    new ResultViewModel()
                    {
                        StudentId = studentId,
                        ExamName = exj.ex.Title,
                        TotalQuestion = examResults.Count(a => a.StudentId == studentId && a.ExamId == exj.ex.Id),
                        CorrectAnswer = examResults.Count(a => a.StudentId == studentId && a.ExamId == exj.ex.Id
                         && a.Answer == q.Answer),
                        WrongAnswer = examResults.Count(a => a.StudentId == studentId && a.ExamId == exj.ex.Id
                         && a.Answer != q.Answer)
                    });
                return requiredData;
            }
            catch (Exception)
            {
                throw;
            }
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
                    result.QnAsId = items.Id;
                    result.Answer = items.SelectedAnswer;
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
                        student.GroupsId = viewModel.GroupId;
                        _unitOfWork.GenericRepository<Student>().Update(student);
                    }
                    else
                    {
                        student.GroupsId = null;
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

        public PagedResult<StudentViewModel>GetAllStudents(int pageNumber, int pageSize)
        {
            try
            {
                int excludeRecords = (pageSize * pageNumber) - pageSize;
                List<StudentViewModel> studentViewModel = new List<StudentViewModel>();
                var studentList = _unitOfWork.GenericRepository<Student>()
                    .GetAll()
                    .Skip(excludeRecords).Take(pageSize).ToList();

                studentViewModel = ConvertToStudentVM(studentList);
                var result = new PagedResult<StudentViewModel>
                {
                    Data = studentViewModel,
                    TotalItems = _unitOfWork.GenericRepository<Student>()
                    .GetAll().Count(),
                    PageNumber = pageNumber,
                    PageSize = pageSize
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
                    _unitOfWork.GenericRepository<Student>().Update(student);
                    _unitOfWork.Save();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
