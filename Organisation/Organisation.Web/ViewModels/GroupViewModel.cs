﻿using Organisation.Domian.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Organisation.Web.ViewModels
{
    public class GroupViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Fill")]
        public string Name { get; set; }
        public IEnumerable<TeamViewModel> Team { get; set; }
        public IEnumerable<TeamMemberViewModel> TeamMember { get; set; }

        public bool isGroupSelected { get; set; }
        public bool isTeamView { get; set; }
        public bool isMemberView { get; set; }
        public bool isChartsView { get; set; }


        public int teamCount { get; set; }
        public int memberCount { get; set; }
        public string teamactive { get; set; }
        public string memberactive { get; set; }
        public string chartsactive { get; set; }

        public int pagesize { get; set; }
        public string previousUrl { get; set; }
        public int mode { get; set; }
    }
}