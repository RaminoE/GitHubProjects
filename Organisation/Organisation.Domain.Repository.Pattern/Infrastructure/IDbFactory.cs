using Organisation.Domain.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.Domain.Repository.Pattern.Infrastructure
{
    public interface IDbFactory:IDisposable
    {
        OrganisationEntities Init();
    }
}
