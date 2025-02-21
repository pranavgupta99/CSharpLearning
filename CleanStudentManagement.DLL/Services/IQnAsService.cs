using CleanStudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.BLL.Services
{
    public interface IQnAsService
    {
        void AddQnAs(CreateQnAsViewModel viewModel);
        PagedResult<QnAsViewModel> GetAll(int pageNumber, int pagerSize);
        bool IsAttendExam(int ExamId, int StudentId);
        IEnumerable<QnAsViewModel> GetAllByExamId(int examId);
    }
}
