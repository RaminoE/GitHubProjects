using Organisation.Domian.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.Domian.Model.Models
{
    public class TeamMember: LogingEntity
    {
        public string Name { get; set; }
        public string Designation { get; set; }
        public DateTime DOB { get; set; }

        public string Image { get; set; }
        public bool IsTeanLead { get; set; }
        public System.Nullable<int> TeamId { get; set; }
        public Team Team { get; set; }
        public TeamMember()
        {
            DateCreated = DateTime.Now;
        }
    }
}
