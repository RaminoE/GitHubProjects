using Organisation.Domian.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.Domain.EF.Mappings
{
    class TeamMemberMappings : EntityTypeConfiguration<TeamMember>
    {
        public TeamMemberMappings()
        {
            ToTable("TeamMember");
            Property(t => t.Name).IsRequired().HasMaxLength(50);
            Property(t => t.Designation).IsRequired().HasMaxLength(50);
            Property(t => t.DOB).IsRequired();
            Property(t => t.TeamId).IsRequired();

        }
    }
}
