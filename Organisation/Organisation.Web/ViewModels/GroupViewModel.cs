using Organisation.Domian.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Organisation.Web.ViewModels
{
    public class GroupViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TeamViewModel> Team { get; set; }
        public IEnumerable<TeamMemberViewModel> TeamMember { get; set; }

        public bool isGroupSelected { get; set; }
        public bool isTeamView { get; set; }
        public bool isMemberView { get; set; }

        public int teamCount { get; set; }
        public int memberCount { get; set; }
    }
}