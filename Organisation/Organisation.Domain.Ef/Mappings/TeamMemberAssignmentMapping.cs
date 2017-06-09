using Organisation.Domian.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.Domain.Ef.Mappings
{
    public class TeamMemberAssignmentMapping : EntityTypeConfiguration<TeamMemberAssignment>
    {
        public TeamMemberAssignmentMapping()
        {
            ToTable("TeamMemberAssignment");
            Property(c => c.TeamId).IsRequired();
            Property(c => c.TeamMemberId).IsRequired();
        }
    }
}
