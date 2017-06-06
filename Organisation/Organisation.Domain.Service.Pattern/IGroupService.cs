using Organisation.Domian.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.Domain.Service.Pattern
{
    public interface IGroupService
    {
        IEnumerable<Group> GetAllGroup(string name=null);
        Group GetGroup(int id);
        Group GetGroup(string name);
        void CreateGroup(Group group);
        void UpdateGroup(Group group);
        void DeleteGroup(Group group);
        void SaveGroup();
    }
}
