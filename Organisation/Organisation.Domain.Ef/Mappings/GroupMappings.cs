using Organisation.Domian.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.Domain.EF.Mappings
{
    public class GroupMappings:EntityTypeConfiguration<Group>
    {
        public GroupMappings()
        {
            ToTable("Group");
            Property(c => c.Name).IsRequired().HasMaxLength(50);
        }
    }
}
