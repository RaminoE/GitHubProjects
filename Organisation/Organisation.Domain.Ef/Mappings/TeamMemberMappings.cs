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
            Property(t => t.Designation).IsRequired();
            Property(t => t.DOB).IsRequired();
            Property(t => t.TeamId).IsRequired();
            Property(t => t.SkypeId).IsRequired();
            Property(t => t.EmailId).IsRequired();
            Property(t => t.GmailId).IsRequired();
           
            Property(t => t.HighestQualification).IsRequired();
            Property(t => t.phoneNumber).IsRequired().HasMaxLength(10);
            Property(t => t.Address).IsRequired();
            Property(t => t.YearOfPassing).IsRequired();
            Property(t => t.YearofJoiningTeam).IsRequired();
            Property(t => t.YearofJoiningCCI).IsRequired();
            Property(t => t.Technologies).IsRequired();
            Property(t => t.BillableStatus).HasColumnName("EmployeeStatus");
            Property(t => t.MemberStatus).HasColumnName("BillableStatus");

        }
    }
}
