using CleanStudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.DLL.Services
{
    public interface IGroupService
    {
        PageResult<GroupViewModel> GetAll(int pageNUmber, int PageSize);
        IEnumerable<GroupViewModel> GetAllGroups();
        GroupViewModel GetGroup(int id);
        GroupViewModel Addgroup(GroupViewModel group);
    }
}
