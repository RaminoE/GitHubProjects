using Organisation.Domian.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.Domain.Ef.Mappings
{
  public   class RegisterMappings : EntityTypeConfiguration<Register>
    {
        public RegisterMappings()
        {
            ToTable("Register");
            Property(t => t.Email).IsRequired().HasMaxLength(50);
            Property(t => t.Password).IsRequired().HasMaxLength(50);
            Property(t => t.ConfirmPassword).HasMaxLength(50);

        }
    }
}
