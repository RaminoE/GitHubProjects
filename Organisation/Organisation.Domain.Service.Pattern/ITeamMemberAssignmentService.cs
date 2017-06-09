using Organisation.Domian.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.Domain.Service.Pattern
{
    public interface ITeamMemberAssignmentService
    {
        IEnumerable<TeamMemberAssignment> GetAllTeamMemberAssignment(string name = null);
        IEnumerable<TeamMemberAssignment> GetTeamMemberAssignmentByTeam(string teamname, string TeamMemberAssignmentname = null);
        TeamMemberAssignment GetTeamMemberAssignment(int id);
        void CreateTeamMemberAssignment(TeamMemberAssignment TeamMemberAssignment);
        void UpdateTeamMemberAssignment(TeamMemberAssignment TeamMemberAssignment);
        void DeleteTeamMemberAssignment(TeamMemberAssignment TeamMemberAssignment);
        void SaveTeamMemberAssignment();
    }
}
