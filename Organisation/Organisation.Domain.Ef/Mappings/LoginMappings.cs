using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Organisation.Domian.Model.Models;
using System.Data.Entity.ModelConfiguration;
namespace Organisation.Domain.Ef.Mappings
{
    public class LoginMappings : EntityTypeConfiguration<Login>
    {
        public LoginMappings()
        {
            ToTable("Login");
            Property(t => t.Email).IsRequired().HasMaxLength(50);
            Property(t => t.Password).IsRequired().HasMaxLength(50);
            Property(t => t.Name).IsRequired().HasMaxLength(50);


        }
    }
}
