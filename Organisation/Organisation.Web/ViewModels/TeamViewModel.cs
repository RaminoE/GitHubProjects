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

        
    }
}