using CleanStudentManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanStudentManagement.BLL.Services
{
    public interface IGroupService
    {
        PagedResult<GroupViewModel> GetAll(int pageNUmber, int pageSize);
        IEnumerable<GroupViewModel> GetAllGroups();
        GroupViewModel GetGroup(int id);
        GroupViewModel Addgroup(GroupViewModel group);
    }
}
