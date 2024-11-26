using CleanStudentManagement.Data.Entities;
using CleanStudentManagement.Data.UnitOfWork;
using CleanStudentManagement.Models;

namespace CleanStudentManagement.DLL.Services
{
    public class ExamService : IExamService
    {
        private IUnitOfWork _unitOfWork;

        public ExamService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddExam(CreateExamsViewModel viewModel)
        {
            try
            {
                var model = viewModel.ConvertToModel(viewModel);
                _unitOfWork.GenericRepository<Exams>().Add(model);
                _unitOfWork.Save();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public PageResult<ExamViewModel> GetAll(int pageNumber, int pageSize)
        {
            try
            {
                int excludeRecords = (pageSize * pageNumber) - pageSize;
                List<ExamViewModel> examViewModel = new List<ExamViewModel>();

                var examList = _unitOfWork.GenericRepository<Exams>()
                    .GetAll(includeProperties: "Groups")
                    .Skip(excludeRecords).Take(pageSize).ToList();

                examViewModel = ListInfo(examList);
                var result = new PageResult<ExamViewModel>
                {
                    Data = examViewModel,
                    TotalItems = _unitOfWork.GenericRepository<Exams>()
                    .GetAll().Count(),
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
                return result;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ExamViewModel> GetAllExams()
        {
            List<ExamViewModel> examList = new List<ExamViewModel> ();
            var exams = _unitOfWork.GenericRepository<Exams>().GetAll().ToList();
            examList = ListInfo(exams);
            return examList;
        }

        private List<ExamViewModel> ListInfo(List<Exams> examList)
        {
            return examList.Select(x => new ExamViewModel(x)).ToList();
        }
    }
}
