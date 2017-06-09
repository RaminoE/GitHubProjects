using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Organisation.Web.ViewModels
{
    public class AssigningTeamView
    {
        public int TeamId { get; set; }
        public int TeamMemberId { get; set; }

        public IEnumerable<TeamViewModel> TeamList { get; set; }

        public IEnumerable<TeamMemberViewModel> TeamMemberList { get; set; }

    }
}