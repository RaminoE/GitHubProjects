using Organisation.Domian.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Organisation.Web.ViewModels
{
    public class FullView
    {
        public int GroupId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Team> Team { get; set; }
        public IEnumerable<TeamMemberViewModel> TeamMember { get; set; }

        public bool isGroupSelected { get; set; }
    }
}