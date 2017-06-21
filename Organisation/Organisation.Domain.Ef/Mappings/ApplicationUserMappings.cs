using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Organisation.Domian.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace Organisation.Domain.Ef.Mappings
{
    class ApplicationUserMappings:EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserMappings()
        {
          
        }
    }
}
