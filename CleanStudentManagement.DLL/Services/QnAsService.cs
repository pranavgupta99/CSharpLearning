using CleanStudentManagement.Data.Entities;
using CleanStudentManagement.Data.UnitOfWork;
using CleanStudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.DLL.Services
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

        public PageResult<QnAsViewModel> GetAll(int pageNumber, int PageSize)
        {
            try
            {
                int excludeRecord = (PageSize * pageNumber) - PageSize;
                List<QnAsViewModel> qnAsViewModel = new List<QnAsViewModel>();
                var groupList = _unitOfWork.GenericRepository<QnAs>()
                    .GetAll()
                    .Skip(excludeRecord).Take(PageSize).ToList();
                qnAsViewModel = ListInfo(groupList);
                var result = new PageResult<QnAsViewModel>
                {
                    Data = qnAsViewModel,
                    TotalItems = _unitOfWork.GenericRepository<QnAs>()
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

        public IEnumerable<QnAsViewModel> GetAllByExamId(int examId)
        {
            var QnAs = _unitOfWork.GenericRepository<QnAs>().GetAll()
                .Where(x=>x.ExamsId == examId).ToList();
            return ListInfo(QnAs);
        }

        public bool IsAttendExam(int examId, int studentId)
        {
            var result = _unitOfWork.GenericRepository<ExamResults>().GetAll()
                .Where(x=>x.ExamId == examId && x.StudentId == studentId);
            return  result == null? false: true;
        }

        private List<QnAsViewModel> ListInfo(List<QnAs> modelList)
        {
            return modelList.Select(x => new QnAsViewModel(x)).ToList();
        }
    }
}
