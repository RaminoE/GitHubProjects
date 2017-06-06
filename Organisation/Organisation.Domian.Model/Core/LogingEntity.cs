using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.Domian.Model.Core
{
    public abstract class LogingEntity:PersistantEntity
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
