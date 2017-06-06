using Organisation.Domian.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.Domain.Service.Pattern
{
    public interface ITeamService
    {
        IEnumerable<Team> GetAllTeam(string name = null);
        IEnumerable<Team> GetTeamByGroup(string groupname,string teamname = null);
        Team GetTeam(int id);
        Team GetTeam(string name);
        void CreateTeam(Team team);
        void UpdateTeam(Team team);
        void DeleteTeam(Team team);
        void SaveTeam();
    }
}
