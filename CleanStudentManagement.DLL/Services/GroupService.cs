using CleanStudentManagement.Data.Entities;
using CleanStudentManagement.Data.UnitOfWork;
using CleanStudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CleanStudentManagement.DLL.Services
{
    public class GroupService : IGroupService
    {
        private IUnitOfWork _unitOfWork;

        public GroupService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public GroupViewModel Addgroup(GroupViewModel groupVM)
        {
            try
            {
                var model = groupVM.ConverttoGroup(groupVM);
                _unitOfWork.GenericRepository<Groups>().Add(model);
                _unitOfWork.Save();
            }
            catch (Exception)
            {
                throw;
            }
            return groupVM;
        }

        public PageResult<GroupViewModel> GetAll(int pageNumber, int PageSize)
        {
            try
            {
                int excludeRecord = (PageSize * pageNumber) - PageSize;
                List<GroupViewModel> groupViewModel = new List<GroupViewModel>();
                var groupList = _unitOfWork.GenericRepository<Groups>()
                    .GetAll()
                    .Skip(excludeRecord).Take(PageSize).ToList();
                groupViewModel = ListInfo(groupList);
                var result = new PageResult<GroupViewModel>
                {
                    Data = groupViewModel,
                    TotalItems = _unitOfWork.GenericRepository<Groups>()
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
        private List<GroupViewModel> ListInfo(List<Groups> groupList)
        {
            return groupList.Select(x => new GroupViewModel(x)).ToList();
        }

        public IEnumerable<GroupViewModel> GetAllGroups()
        {
            try
            {
                List<GroupViewModel> groupViewModel = new List<GroupViewModel>();
                var groupList = _unitOfWork.GenericRepository<Groups>()
                    .GetAll().ToList();
                groupViewModel = ListInfo(groupList);
                return groupViewModel;
            }
            catch (Exception ex) 
            {
                throw;
            }
        }

        public GroupViewModel GetGroup(int id)
        {
            var groups = _unitOfWork.GenericRepository<Groups>().GetById(id);
            var vm =  new GroupViewModel(groups);
            return vm;
        }
    }
}
