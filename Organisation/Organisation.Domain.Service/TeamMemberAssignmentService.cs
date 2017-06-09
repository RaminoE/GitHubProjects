using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Organisation.Domain.Service.Pattern;
using Organisation.Domian.Model.Models;
using Organisation.Domain.Repository;
using Organisation.Domain.Repository.Pattern.Infrastructure;

namespace Organisation.Domain.Service
{
    class TeamMemberAssignmentService : ITeamMemberAssignmentService
    {
        private readonly ITeamRepository teamRepository;
        private readonly ITeamMemberAssignmentRepository teammemberAssignmentRepository;
        private readonly IUnitOfWork unitOfWork;

        public TeamMemberAssignmentService(ITeamMemberAssignmentRepository teammemberRepository, IUnitOfWork unitOfWork)
        {
            this.teammemberAssignmentRepository = teammemberRepository;
            this.unitOfWork = unitOfWork;
        }
        public void CreateTeamMemberAssignment(TeamMemberAssignment TeamMemberAssignment)
        {
            teammemberAssignmentRepository.Add(TeamMemberAssignment);
        }

        public void DeleteTeamMemberAssignment(TeamMemberAssignment TeamMemberAssignment)
        {
            teammemberAssignmentRepository.Delete(TeamMemberAssignment);
        }

        public IEnumerable<TeamMemberAssignment> GetAllTeamMemberAssignment(string name = null)
        {
           
                return teammemberAssignmentRepository.GetAll().ToList();
           
        }

      

        public TeamMemberAssignment GetTeamMemberAssignment(int id)
        {
            return teammemberAssignmentRepository.GetById(id);
        }

        public IEnumerable<TeamMemberAssignment> GetTeamMemberAssignmentByTeam(string teamname, string TeamMemberAssignmentname = null)
        {
            var team = teamRepository.GetTeamByName(teamname);
            return teammemberAssignmentRepository.GetMany(t => t.TeamId == team.Id);
        }

        public void SaveTeamMemberAssignment()
        {
            unitOfWork.Commit();
        }

        public void UpdateTeamMemberAssignment(TeamMemberAssignment TeamMemberAssignment)
        {
            teammemberAssignmentRepository.Update(TeamMemberAssignment);
        }
    }
}
