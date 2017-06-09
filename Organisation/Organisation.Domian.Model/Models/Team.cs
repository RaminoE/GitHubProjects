using Organisation.Domian.Model.Core;
using Organisation.Domian.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.Domian.Model.Models
{
    public class Team :LogingEntity
    {
        public string Name { get; set; }
        public string ClientName { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public virtual IEnumerable<TeamMember> TeamMember { get; set; }
        public Team()
        {
            DateCreated = DateTime.Now;
            DateModified = DateTime.Now;
        }

    }
}
