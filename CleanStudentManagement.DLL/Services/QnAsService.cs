using CleanStudentManagement.Data.Entities;
using CleanStudentManagement.Data.UnitOfWork;
using CleanStudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.BLL.Services
{
    public class QnAsService : IQnAsService
    {
        private IUnitOfWork _unitOfWork;

        public QnAsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddQnAs(CreateQnAsViewModel viewModel)
        {
            try
            {
                var model = viewModel.ConvertToModel(viewModel);
                _unitOfWork.GenericRepository<QnAs>().Add(model);
                _unitOfWork.Save();
            }
            catch(Exception e) 
            {
                throw;
            }
        }

        public PagedResult<QnAsViewModel> GetAll(int pageNumber, int pageSize)
        {
            try
            {
                int excludeRecords = (pageSize * pageNumber) - pageSize;
                List<QnAsViewModel> qnAsViewModel = new List<QnAsViewModel>();
                var groupList = _unitOfWork.GenericRepository<QnAs>()
                    .GetAll()
                    .Skip(excludeRecords).Take(pageSize).ToList();
                qnAsViewModel = ListInfo(groupList);
                var result = new PagedResult<QnAsViewModel>
                {
                    Data = qnAsViewModel,
                    TotalItems = _unitOfWork.GenericRepository<QnAs>()
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

        public IEnumerable<QnAsViewModel> GetAllByExamId(int examId)
        {
            var QnAs = _unitOfWork.GenericRepository<QnAs>().GetAll()
                .Where(x => x.ExamsId == examId).ToList();
            return ListInfo(QnAs);
        }

        public bool IsAttendExam(int examId, int studentId)
        {
            var result = _unitOfWork.GenericRepository<ExamResults>().GetAll()
                .Any(x => x.ExamId == examId && x.StudentId == studentId);
            return  result == false? false: true;
        }

        private List<QnAsViewModel> ListInfo(List<QnAs> modelList)
        {
            return modelList.Select(x => new QnAsViewModel(x)).ToList();
        }
    }
}
