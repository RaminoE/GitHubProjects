﻿using Organisation.Domian.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.Domain.Service.Pattern
{
    public interface ITeamMemberService
    {
        IEnumerable<TeamMember> GetAllTeamMember(string name = null);
        IEnumerable<TeamMember> GetTeamMemberByTeam(string teamname, string TeamMembername = null);
        TeamMember GetTeamMember(int id);
        TeamMember GetTeamMember(string name);
        void CreateTeamMember(TeamMember teamMember);
        void UpdateTeamMember(TeamMember teamMember);
        void DeleteTeamMember(TeamMember teamMember);
        void SaveTeamMember();
    }
}
