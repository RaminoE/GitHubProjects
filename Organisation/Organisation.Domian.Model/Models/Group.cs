using Organisation.Domian.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.Domian.Model.Models
{
    public class Group : LogingEntity
    {
        public string Name { get; set; }

        public virtual IEnumerable<Team> Team { get; set; }
        public virtual IEnumerable<TeamMember> TeamMember { get; set; }
        public Group()
        {
            DateCreated = DateTime.Now;
            DateModified = DateTime.Now;
        }
    }
}
