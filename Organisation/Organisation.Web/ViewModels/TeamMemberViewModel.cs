using Organisation.Domian.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Organisation.Web.ViewModels
{
    public class TeamMemberViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public DateTime DOB { get; set; }
        public string Image { get; set; }
        public bool IsTeanLead { get; set; }
        public System.Nullable<int> TeamId { get; set; }
        public IEnumerable<Team> TeamList { get; set; }

        public HttpPostedFileBase File { get; set; }
        public int mode { get; set; }
    }
}