using AutoMapper;
using Organisation.Domain.Service.Pattern;
using Organisation.Domian.Model.Models;
using Organisation.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Organisation.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGroupService groupService;
        private readonly ITeamService teamService;
        private readonly ITeamMemberService teamMemberService;

        public HomeController(IGroupService groupService, ITeamService teamService, ITeamMemberService teamMemberService)
        {
            this.groupService = groupService;
            this.teamService = teamService;
            this.teamMemberService = teamMemberService;
        }

        public ActionResult Index(string membername = null)
        {
            IEnumerable<TeamMemberViewModel> viewModelTeammember;
            IEnumerable<TeamMember> member;
            IEnumerable<Group> group;

            member = teamMemberService.GetAllTeamMember(membername).ToList();

            viewModelTeammember = Mapper.Map<IEnumerable<TeamMember>, IEnumerable<TeamMemberViewModel>>(member);
            return View(viewModelTeammember);
        }

        public ActionResult Group(string groupname = null)
        {
            IEnumerable<GroupViewModel> groupViewModel;
            IEnumerable<Group> group;
            
            
            group = groupService.GetAllGroup(groupname).ToList();
            foreach(var item in group)
            item.Team = teamService.GetAllTeam(null).Where(c => c.GroupId == item.Id);

            groupViewModel = Mapper.Map<IEnumerable<Group>, IEnumerable<GroupViewModel>>(group);
            return View(groupViewModel);
        }

        public ActionResult GroupDetails(string selected, string groupname = null)
        {
            GroupViewModel fullview;
            Group group;

            //IEnumerable<Team> team;
            //IEnumerable<TeamMember> member;
            group = groupService.GetGroup(groupname);
            group.Team = teamService.GetAllTeam(null).Where(c => c.GroupId == group.Id);
            group.TeamMember = teamMemberService.GetAllTeamMember(null).Where(c => c.Team.GroupId == group.Id);
            fullview = Mapper.Map<Group, GroupViewModel>(group);
            fullview.isGroupSelected = true;
            fullview.teamCount = teamService.GetAllTeam(null).Where(c => c.GroupId == group.Id).Count();
            fullview.memberCount = teamMemberService.GetAllTeamMember(null).Where(c => c.Team.GroupId == group.Id).Count();
            //if (selected.Equals(1))
            //{
            //    fullview.isTeamView = true;
            //    group.Team = teamService.GetAllTeam(null).Where(c => c.GroupId == group.Id);
            //}
            //if (selected.Equals(2))
            //{
            //    fullview.isMemberView = false;
            //    group.TeamMember = teamMemberService.GetAllTeamMember(null).Where(c => c.Team.GroupId == group.Id);
            //}
            return View(fullview);
        }
        [HttpPost]
        public ActionResult Details(string selected, string groupname = null)
        {
            GroupViewModel fullview;
            Group group;

            //IEnumerable<Team> team;
            //IEnumerable<TeamMember> member;
            group = groupService.GetGroup(groupname);
            group.Team = teamService.GetAllTeam(null).Where(c => c.GroupId == group.Id);
            group.TeamMember = teamMemberService.GetAllTeamMember(null).Where(c => c.Team.GroupId == group.Id);

            bool teamview = false; bool memberview = false;
            if (Convert.ToInt32(selected) == 1)
            {
                teamview = true;

            }
            if (Convert.ToInt32(selected) == 2)
            {
                memberview = true;


            }
            fullview = Mapper.Map<Group, GroupViewModel>(group);
            fullview.isTeamView = teamview;
            fullview.isMemberView = memberview;
            fullview.isGroupSelected = true;
            fullview.teamCount = group.Team.Count();
            fullview.memberCount = group.TeamMember.Count();
            return View("GroupDetails", fullview);
        }


        public ActionResult Team(string groupname = null)
        {
            IEnumerable<TeamViewModel> teamViewModel;
            IEnumerable<Team> team;

            team = teamService.GetAllTeam(groupname).ToList();

            teamViewModel = Mapper.Map<IEnumerable<Team>, IEnumerable<TeamViewModel>>(team);
            return View(teamViewModel);
        }

        public ActionResult TeamDetails(string selected, string teamname = null)
        {
            TeamViewModel fullview;
            Team team;

            //IEnumerable<Team> team;
            //IEnumerable<TeamMember> member;
            team = teamService.GetTeam(teamname);
            team.TeamMember = teamMemberService.GetAllTeamMember(null).Where(c => c.TeamId == team.Id);
            fullview = Mapper.Map<Team, TeamViewModel>(team);


            return View(fullview);
        }

        public ActionResult EditMember(int id,int mode)
        {
            if (mode == 2)
            {
                return View();
            }
            else
            {
                TeamMemberViewModel fullview;
                TeamMember teammember;
                List<TeamViewModel> team;
                //IEnumerable<Team> team;
                //IEnumerable<TeamMember> member;
                teammember = teamMemberService.GetTeamMember(id);
                fullview = Mapper.Map<TeamMember, TeamMemberViewModel>(teammember);
                fullview.mode = mode;
                fullview.TeamList = teamService.GetAllTeam(null).ToList();
                return View(fullview);
            }
        }

        [HttpPost]
        public ActionResult EditCreatTeamMember(TeamMemberViewModel tm)
        {
            if(tm.mode!=2)
            {
                string ddd = tm.DOB.ToString().Substring(0, tm.DOB.ToString().IndexOf(' '));
                DateTime dt = DateTime.ParseExact(ddd, "dd-MM-yyyy",
                                  CultureInfo.InvariantCulture);
                dt.ToString("yyyy-MM-dd");
                tm.DOB = dt;

                
                if (tm.File!=null)
                {
                
                    string memberPicture = System.IO.Path.GetFileName(tm.File.FileName);
                    tm.Image = tm.File.FileName;
                    string path = System.IO.Path.Combine(Server.MapPath("~/images/"), memberPicture);
                    tm.File.SaveAs(path);
                }
                var teammember = Mapper.Map<TeamMemberViewModel, TeamMember>(tm);
                teamMemberService.UpdateTeamMember(teammember);


                teamMemberService.SaveTeamMember();
            }
            return RedirectToAction("Index", new { membername="" });
        }
    }
}