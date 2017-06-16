using Organisation.Domain.Repository;
using Organisation.Domain.Repository.Pattern.Infrastructure;
using Organisation.Domain.Service.Pattern;
using Organisation.Domian.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.Domain.Service
{
    public class GroupService : IGroupService
    {

        private readonly IGroupRepository groupRepository;
        private readonly IUnitOfWork unitOfWork;

        public GroupService(IGroupRepository groupRepository, IUnitOfWork unitOfWork)
        {
            this.groupRepository = groupRepository;
            this.unitOfWork = unitOfWork;
        }
        public void CreateGroup(Group group)
        {
            groupRepository.Add(group);
        }
        public void DeleteGroup(int id)
        {
            groupRepository.Delete(id);
        }
        public void DeleteGroup(Group group)
        {
            groupRepository.Delete(group);
        }

        public IEnumerable<Group> GetAllGroup(string name)
        {
            if (string.IsNullOrEmpty(name))
                return groupRepository.GetAll();
            else
                return groupRepository.GetAll().Where(c => c.Name == name);
        }

        public Group GetGroup(string name)
        {
            return groupRepository.GetGroupByName(name);
        }

        public Group GetGroup(int id)
        {
           return groupRepository.GetById(id);
        }

        void IGroupService.SaveGroup()
        {
            unitOfWork.Commit();
        }

        void IGroupService.UpdateGroup(Group group)
        {
            groupRepository.Update(group);
        }
    }
}
