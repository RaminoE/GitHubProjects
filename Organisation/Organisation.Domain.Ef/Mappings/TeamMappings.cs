using Organisation.Domian.Model;
using Organisation.Domian.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.Domain.EF.Mappings
{
    public class TeamMappings : EntityTypeConfiguration<Team>
    {
        public TeamMappings()
        {
            ToTable("Team");
            Property(t => t.Name).IsRequired().HasMaxLength(50);
            Property(t => t.ClientName).IsRequired().HasMaxLength(50);
            Property(t => t.GroupId).IsRequired();
            
        }
    }
}
