using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Organisation.Domain.Service.Pattern;
using Organisation.Domain.Repository;
using Organisation.Domain.Repository.Pattern.Infrastructure;
using Organisation.Domian.Model.Models;
using System.Linq.Expressions;

namespace Organisation.Domain.Service
{
    public class TeamMemberService :ITeamMemberService
    {
        private readonly ITeamMemberRepository teamMemberRepository;
        private readonly ITeamRepository teamRepository;
        private readonly IUnitOfWork unitOfWork;

        public TeamMemberService(ITeamMemberRepository teamMemberRepository, ITeamRepository teamRepository, IUnitOfWork unitOfWork)
        {
            this.teamMemberRepository = teamMemberRepository;
            this.teamRepository = teamRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<TeamMember> GetAllTeamMember(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return teamMemberRepository.GetAll();
            else
                return teamMemberRepository.GetAll().Where(c => c.Name == name);
        }

        public IEnumerable<TeamMember> GetTeamMemberByTeam(string teamname, string TeamMembername = null)
        {
            var team = teamRepository.GetTeamByName(teamname);
            return team.TeamMember.Where(tm => tm.Name.ToLower().Contains(TeamMembername.ToLower().Trim()));
        }

        public TeamMember GetTeamMember(int id)
        {
            return teamMemberRepository.GetById(id);
        }

        public TeamMember GetTeamMember(string name)
        {
            throw new NotImplementedException();
        }

        public void CreateTeamMember(TeamMember teamMember)
        {
            teamMemberRepository.Add(teamMember);
        }

        public void UpdateTeamMember(TeamMember teamMember)
        {
            teamMemberRepository.Update(teamMember);
        }

        public void DeleteTeamMember(TeamMember teamMember)
        {
            teamMemberRepository.Delete(teamMember);
        }

        public void DeleteTeamMember(int id)
        {
            teamMemberRepository.Delete(id);
        }

        public IEnumerable<TeamMember> GetMany(Expression<Func<TeamMember, bool>> where ,int skip,int take)
        {
           return  teamMemberRepository.GetMany(where, skip,  take);
        }

        public void SaveTeamMember()
        {
            unitOfWork.Commit();
        }
    }
}
