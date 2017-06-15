using AutoMapper;
using Organisation.Domain.Service.Pattern;
using Organisation.Domian.Model.Models;
using Organisation.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using static Organisation.Web.ViewModels.TeamMemberViewModel;
using System.Configuration;

namespace Organisation.Web.Controllers
{
  
    public class HomeController : Controller
    {
        int pagesize = Convert.ToInt32(ConfigurationManager.AppSettings["GridPageSize"].ToString());
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
        [HttpPost]
        public ActionResult Filter(string search)

        {
            IEnumerable<TeamMemberViewModel> viewModelTeammember;
            IEnumerable<TeamMember> member;
            IEnumerable<Group> group;
            if (string.IsNullOrEmpty(search))
            {
                member = teamMemberService.GetAllTeamMember(search).ToList();
            }
            else { member = teamMemberService.GetMany(p => p.Name.ToLower().Contains(search.ToLower()),0,12).ToList(); }


            viewModelTeammember = Mapper.Map<IEnumerable<TeamMember>, IEnumerable<TeamMemberViewModel>>(member);
            return PartialView("_MemberView", viewModelTeammember);
        }

        public ActionResult Group(string groupname = null)
        {
            IEnumerable<GroupViewModel> groupViewModel;
            IEnumerable<Group> group;


            group = groupService.GetAllGroup(groupname).ToList();
            foreach (var item in group)
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

            fullview = Mapper.Map<Group, GroupViewModel>(group);
            fullview.isGroupSelected = true;
            fullview.isTeamView = true;//returns if it is team view or member view to beb diasplayed
            fullview.teamactive = "active";// sets teamview tab to avtive
            fullview.teamCount = teamService.GetAllTeam(null).Where(c => c.GroupId == group.Id).Count();
            fullview.memberCount = teamMemberService.GetAllTeamMember(null).Where(c => c.Team.GroupId == group.Id).Count();
            fullview.pagesize = pagesize;
            return View(fullview);
        }
        [HttpPost]
        public ActionResult Details(string selected, string groupname = null)
        {
            //selected:1=team;2=member;3=chart
            GroupViewModel fullview;
            Group group;

            int skipcount = pagesize ;
            group = groupService.GetGroup(groupname);
            group.Team = teamService.GetAllTeam(null).Where(c => c.GroupId == group.Id);
            group.TeamMember = teamMemberService.GetMany(c => c.Team.GroupId == group.Id, 0,pagesize);

            bool teamview = false; bool memberview = false; bool chartview = false;
            if (Convert.ToInt32(selected) == 1)
            {
                teamview = true;

            }
            else if (Convert.ToInt32(selected) == 2)
            {
                memberview = true;
            }
            else if (Convert.ToInt32(selected) == 3)
            {
                chartview = true;
            }
            fullview = Mapper.Map<Group, GroupViewModel>(group);
            fullview.isTeamView = teamview;//returns if it is team view or member view to beb diasplayed
            fullview.isMemberView = memberview;//returns if it is team view or member view to beb diasplayed
            fullview.isChartsView = chartview;//returns if it is team view or member view to beb diasplayed
            fullview.isGroupSelected = true;
            fullview.teamCount = group.Team.Count();
            fullview.memberCount = teamMemberService.GetMany(c => c.Team.GroupId == group.Id, 0, 100000).Count();
            fullview.pagesize = pagesize;
            if (memberview)
            {
                fullview.memberactive = "active";// sets member tab to avtive
                fullview.teamactive = fullview.chartsactive = "";
                return PartialView("_MemberListView", fullview.TeamMember);
            }
            else if (teamview)
            {
                fullview.teamactive = "active";// sets teamview tab to avtive
                fullview.memberactive = fullview.chartsactive = "";
                return View("GroupDetails", fullview);
            }
            else if (chartview)
            {
                fullview.chartsactive = "active";
                fullview.memberactive = "";// sets member tab to avtive
                fullview.teamactive = "";
                return View("GroupDetails", fullview);
            }

            
            return View("GroupDetails", fullview);
        }
        public ActionResult TeamTabDetails(string selected, string teamname = null)
        {
           
            TeamViewModel fullview;
            Team team;
            team = teamService.GetTeam(teamname);


            bool teamview = false; bool memberview = false; bool chartview = false;
            if (Convert.ToInt32(selected) == 1)
            {
                team.TeamMember = teamMemberService.GetAllTeamMember(null).Where(c => c.TeamId == team.Id);
                teamview = true;

            }
            else if (Convert.ToInt32(selected) == 2)
            {

                team.TeamMember = teamMemberService.GetAllTeamMember(null)
                    .Where(c => c.TeamId == team.Id 
                    && c.MemberStatus.ToString() == MemberStatusselect.Allocated_to_Team.ToString()
                    && c.BillableStatus.ToString() == BillableStatusselect.Billable.ToString()).ToList().Skip(0).Take(pagesize);
                memberview = true;

            }
            else if (Convert.ToInt32(selected) == 3)
            {
                chartview = true;
            }
            else if (Convert.ToInt32(selected) == 4)
            {

                team.TeamMember = teamMemberService.GetAllTeamMember(null).Where(c => c.TeamId == team.Id && c.MemberStatus.ToString() == TeamMemberViewModel.MemberStatusselect.Allocated_to_Team.ToString()
                && c.BillableStatus.ToString() == TeamMemberViewModel.BillableStatusselect.Non_Billable.ToString()).ToList().Skip(0).Take(pagesize);
                memberview = true;
            }
            else if (Convert.ToInt32(selected) == 5)
            {

                team.TeamMember = teamMemberService.GetAllTeamMember(null).Where(c => c.TeamId == team.Id && c.MemberStatus.ToString() == TeamMemberViewModel.MemberStatusselect.Bench.ToString()).ToList().Skip(0).Take(pagesize);
                memberview = true;
            }
            fullview = Mapper.Map<Team, TeamViewModel>(team);
            fullview.isTeamView = teamview;//returns if it is team view or member view to beb diasplayed
            fullview.isMemberView = memberview;//returns if it is team view or member view to beb diasplayed
            fullview.isChartsView = chartview;//returns if it is team view or member view to beb diasplayed

            

            fullview.billableMemberCount = teamMemberService.GetAllTeamMember(null).Where(c => c.TeamId == team.Id && c.MemberStatus.ToString() == TeamMemberViewModel.MemberStatusselect.Allocated_to_Team.ToString()
                && c.BillableStatus.ToString() == TeamMemberViewModel.BillableStatusselect.Billable.ToString()).Count();

            fullview.nonBillableMemberCount = teamMemberService.GetAllTeamMember(null).Where(c => c.TeamId == team.Id && c.MemberStatus.ToString() == TeamMemberViewModel.MemberStatusselect.Allocated_to_Team.ToString()
                && c.BillableStatus.ToString() == TeamMemberViewModel.BillableStatusselect.Non_Billable.ToString()).Count();


            fullview.benchMemberCount = teamMemberService.GetAllTeamMember(null).Where(c => c.TeamId == team.Id && c.MemberStatus.ToString() == TeamMemberViewModel.MemberStatusselect.Bench.ToString()).Count();

            if (memberview && Convert.ToInt32(selected) == 2)
            {
                fullview.billMemberactive = "active";// sets member tab to avtive
                fullview.nonBillMemberactive = fullview.benchMemberactive = fullview.teamactive = fullview.chartsactive = "";

                
                return PartialView("_MemberListView", fullview.TeamMembers);
            }
            else if (memberview && Convert.ToInt32(selected) == 4)
            {
                fullview.nonBillMemberactive = "active";// sets member tab to avtive
                fullview.benchMemberactive = fullview.billMemberactive = fullview.teamactive = fullview.chartsactive = "";
                return PartialView("_MemberListView", fullview.TeamMembers);
            }
            else if (memberview && Convert.ToInt32(selected) == 5)
            {
                fullview.benchMemberactive = "active";// sets member tab to avtive
                fullview.nonBillMemberactive = fullview.billMemberactive = fullview.teamactive = fullview.chartsactive = "";
                return PartialView("_MemberListView", fullview.TeamMembers);
            }
            else if (teamview)
            {
                fullview.teamactive = "active";// sets teamview tab to avtive
                fullview.nonBillMemberactive = fullview.billMemberactive = fullview.chartsactive = "";
                return View("TeamDetails", fullview);
            }
            else if (chartview)
            {
                fullview.chartsactive = "active";
                fullview.benchMemberactive = fullview.nonBillMemberactive = fullview.billMemberactive = "";// sets member tab to avtive
                fullview.teamactive = "";
                return PartialView("_OrgChartView", fullview.TeamMembers);
            }




            return View("TeamDetails", fullview);

        }

        public ActionResult MemberPartial(int id ,int type,int calledfrom,int? isdelete,int?memberid,int? page)
        {
            IEnumerable<TeamMemberViewModel> viewModelTeammember;
            IEnumerable<TeamMember> member = null;

            if(isdelete==1)
            { if (memberid.HasValue)
                {
                    int id1 = memberid ?? 1;
                  
                    teamMemberService.DeleteTeamMember(id1);
                    teamMemberService.SaveTeamMember();
                    
                }
            }

            int skipcount = pagesize * ((page ?? 1) - 1);
            if (calledfrom == 1)
            {
                             member = teamMemberService.GetMany(c => c.Team.GroupId==id, skipcount, pagesize);
                
            }
            else if (calledfrom == 2)
            {
                if (type == 2)
                {
                    member = teamMemberService.GetMany(c => c.TeamId == id
                        && c.MemberStatus.ToString() == MemberStatusselect.Allocated_to_Team.ToString()
                        && c.BillableStatus.ToString() == BillableStatusselect.Billable.ToString(), skipcount, pagesize);


                }
                else if (type == 4)
                {
                    member = teamMemberService.GetMany(c => c.TeamId == id
                        && c.MemberStatus.ToString() == MemberStatusselect.Allocated_to_Team.ToString()
                        && c.BillableStatus.ToString() == BillableStatusselect.Non_Billable.ToString(), skipcount, pagesize);

                }
                else if (type == 5)
                {
                    member = teamMemberService.GetMany(c => c.TeamId == id
                        && c.MemberStatus.ToString() == MemberStatusselect.Allocated_to_Team.ToString()
                        && c.BillableStatus.ToString() == BillableStatusselect.Non_Billable.ToString(), skipcount, pagesize);

                }
   
            }
            viewModelTeammember = Mapper.Map<IEnumerable<TeamMember>, IEnumerable<TeamMemberViewModel>>(member);

            return PartialView("_MemberListView", viewModelTeammember.ToList());
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
            //team.TeamMember = teamMemberService.GetAllTeamMember(null).Where(c => c.TeamId == team.Id);
            fullview = Mapper.Map<Team, TeamViewModel>(team);
            fullview.teamactive = "active";
            fullview.isTeamView = true;
            fullview.isMemberView = false;
            fullview.pagesize = pagesize;
            fullview.toatalMemberCount = teamMemberService.GetAllTeamMember(null).Where(c => c.TeamId == team.Id).Count();

            fullview.billableMemberCount = teamMemberService.GetAllTeamMember(null).Where(c => c.TeamId == team.Id && c.MemberStatus.ToString() == TeamMemberViewModel.MemberStatusselect.Allocated_to_Team.ToString()
                && c.BillableStatus.ToString() == TeamMemberViewModel.BillableStatusselect.Billable.ToString()).Count();

            fullview.nonBillableMemberCount = teamMemberService.GetAllTeamMember(null).Where(c => c.TeamId == team.Id && c.MemberStatus.ToString() == TeamMemberViewModel.MemberStatusselect.Allocated_to_Team.ToString()
                && c.BillableStatus.ToString() == TeamMemberViewModel.BillableStatusselect.Non_Billable.ToString()).Count();

            fullview.benchMemberCount = teamMemberService.GetAllTeamMember(null).Where(c => c.TeamId == team.Id && c.MemberStatus.ToString() == TeamMemberViewModel.MemberStatusselect.Bench.ToString()).Count();
            return View(fullview);
        }

        public ActionResult EditMember(int id, int mode)
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
            if (tm.mode != 2)
            {
                string ddd = tm.DOB.ToString().Substring(0, tm.DOB.ToString().IndexOf(' '));
                DateTime dt = DateTime.ParseExact(ddd, "dd-MM-yyyy",
                                  CultureInfo.InvariantCulture);
                dt.ToString("yyyy-MM-dd");
                tm.DOB = dt;


                if (tm.File != null)
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
            else
            {
                if (ModelState.IsValid)
                {
                    if (tm.File == null)
                    {
                        tm.Image = "Capture.png";
                    }
                    else
                    {
                        string memberPicture = System.IO.Path.GetFileName(tm.File.FileName);
                        tm.Image = tm.File.FileName;
                        string path = System.IO.Path.Combine(Server.MapPath("~/images/"), memberPicture);
                        tm.File.SaveAs(path);
                    }
                    var t = Mapper.Map<TeamMemberViewModel, TeamMember>(tm);
                    teamMemberService.CreateTeamMember(t);
                    teamMemberService.SaveTeamMember();
                }
                else
                {
                    return View("CreateTeamMember", tm);
                }
            }
            return RedirectToAction("Index", new { membername = "" });
        }

        [HttpPost]
        public ActionResult CreateTeamMember(TeamMemberViewModel tm)
        {
            if (tm.mode != 2)
            {


                if (tm.File != null)
                {

                    string memberPicture = tm.Name + ".png";
                    tm.Image = memberPicture;
                    string path = System.IO.Path.Combine(Server.MapPath("~/images/"), memberPicture);
                    tm.File.SaveAs(path);
                }
                var teammember = Mapper.Map<TeamMemberViewModel, TeamMember>(tm);
                teamMemberService.UpdateTeamMember(teammember);


                teamMemberService.SaveTeamMember();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    if (tm.File == null)
                    {
                        tm.Image = "Capture.png";

                    }
                    else
                    {
                        string memberPicture = tm.Name + ".png";
                        tm.Image = memberPicture;
                        string path = System.IO.Path.Combine(Server.MapPath("~/images/"), memberPicture);
                        tm.File.SaveAs(path);
                    }
                    var t = Mapper.Map<TeamMemberViewModel, TeamMember>(tm);
                    teamMemberService.CreateTeamMember(t);
                    teamMemberService.SaveTeamMember();
                }
                else
                {
                    tm.File = null;
                    int year = DateTime.UtcNow.Year;
                    int last = year - 70;
                    int count = 0;
                    List<string> yearpass = new List<string>();

                    for (int i = year; i > last; i--)
                    {
                        yearpass.Add("" + i);
                        count++;
                    }
                    tm.YearPass = yearpass.ToList();

                    tm.TeamList = teamService.GetAllTeam(null).ToList();
                    return View(tm);
                }
            }
            return RedirectToAction("Index", new { membername = "" });
        }
        public ActionResult CreateTeamMember(int id, int mode)
        {
            if (mode == 2)
            {
                TeamMemberViewModel fullview = new TeamMemberViewModel();
                TeamMember teammember;
                List<TeamViewModel> team;
                //IEnumerable<Team> team;
                //IEnumerable<TeamMember> member;
                int year = DateTime.UtcNow.Year;
                int last = year - 70;
                int count = 0;
                List<string> yearpass = new List<string>();

                for (int i = year; i > last; i--)
                {
                    yearpass.Add("" + i);
                    count++;
                }

                fullview.DOB = DateTime.UtcNow;
                fullview.YearofJoiningCCI = DateTime.UtcNow;
                fullview.YearofJoiningTeam = DateTime.UtcNow;
                fullview.YearPass = yearpass.ToList();
                fullview.mode = mode;
                fullview.TeamList = teamService.GetAllTeam(null).ToList();
                fullview.Image = "Capture.png";
                return View(fullview);

            }
            else
            {
                TeamMemberViewModel fullview;
                TeamMember teammember;
                List<TeamViewModel> team;
                //IEnumerable<Team> team;
                //IEnumerable<TeamMember> member;
                int year = DateTime.UtcNow.Year;
                int last = year - 70;
                int count = 0;
                List<string> yearpass = new List<string>();

                for (int i = year; i > last; i--)
                {
                    yearpass.Add("" + i);
                    count++;
                }





                teammember = teamMemberService.GetTeamMember(id);
                fullview = Mapper.Map<TeamMember, TeamMemberViewModel>(teammember);
                fullview.YearPass = yearpass.ToList();
                fullview.mode = mode;
                fullview.TeamList = teamService.GetAllTeam(null).ToList();

                return View(fullview);
            }
        }
    }
}