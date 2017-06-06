
using Organisation.Domain.Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Organisation.Domian.Model.Models;
using Organisation.Domain.Repository;
using Organisation.Domain.Repository.Pattern.Infrastructure;

namespace Organisation.Domain.Service
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository teamRepository;
        private readonly IGroupRepository groupRepository;
        private readonly IUnitOfWork unitOfWork;

        public TeamService(ITeamRepository teamRepository, IGroupRepository groupRepository, IUnitOfWork unitOfWork)
        {
            this.teamRepository=teamRepository;
            this.groupRepository=groupRepository;
            this.unitOfWork = unitOfWork;
        }
        public void CreateTeam(Team team)
        {
            teamRepository.Add(team);
        }

        public void DeleteTeam(Team team)
        {
            teamRepository.Delete(team);
        }

        public IEnumerable<Team> GetAllTeam(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return teamRepository.GetAll();
            else
                return teamRepository.GetAll().Where(c => c.Name == name);
        }

        public Team GetTeam(string name)
        {
            return teamRepository.GetTeamByName(name);
        }

        public Team GetTeam(int id)
        {
            return teamRepository.GetById(id);
        }

        public IEnumerable<Team> GetTeamByGroup(string groupname, string teamname = null)
        {
            var group = groupRepository.GetGroupByName(groupname);
            return teamRepository.GetMany(t => t.GroupId==group.Id);
        }

        public void SaveTeam()
        {
            unitOfWork.Commit();
        }

        public void UpdateTeam(Team team)
        {
            teamRepository.Update(team);
        }
    }
}
