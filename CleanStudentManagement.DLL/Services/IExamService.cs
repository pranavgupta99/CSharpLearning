using CleanStudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.BLL.Services
{
    public interface IExamService
    {
        PagedResult<ExamViewModel> GetAll(int pageNumber, int pageSize);
        void AddExam(CreateExamsViewModel viewModel);
        IEnumerable<ExamViewModel> GetAllExams();
    }
}
