using Organisation.Domian.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Organisation.Web.ViewModels
{
    public class TeamViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ClientName { get; set; }

        public int GroupID { get; set; }

        public IEnumerable<TeamMemberViewModel> TeamMembers { get; set; }
        public bool isTeamView { get; set; }
        public bool isMemberView { get; set; }
        public bool isChartsView { get; set; }
        public string teamactive { get; set; }
        public string billMemberactive { get; set; }
        public string nonBillMemberactive { get; set; }
        public string benchMemberactive { get; set; }
        public string chartsactive { get; set; }

        public int toatalMemberCount { get; set; }
        public int billableMemberCount { get; set; }
        public int nonBillableMemberCount { get; set; }
        public int benchMemberCount { get; set; }
        public IEnumerable<Group> GroupList { get; set; }
        public int pagesize { get; set; }
        public int calledEditFrom { get; set; }
        public int mode { get; set; }

        public string previousUrl { get; set; }

    }
}