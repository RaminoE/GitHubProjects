using Organisation.Domian.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.Domian.Model.Models
{
    public class TeamMemberAssignment :LogingEntity
    {

        public int TeamId { get; set; }
        public int TeamMemberId { get; set; }

        public virtual  IEnumerable<Team> TeamList { get; set; }

        public virtual IEnumerable<TeamMember> TeamMemberList { get; set; }
        public TeamMemberAssignment()
        {
            DateCreated = DateTime.Now;
        }
    }
}
