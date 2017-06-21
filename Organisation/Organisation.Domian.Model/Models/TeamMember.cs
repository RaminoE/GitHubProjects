using Organisation.Domian.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.Domian.Model.Models
{
    public enum MemberStatus
    {
        Allocated_to_Team=1,
        Bench=2
    }

    public enum BillableStatus
    {
        Billable=1,
        Non_Billable=2
    }
    public enum Designations
    {
        Junior_Developer = 1,
        Developer = 2,
        Senior_Developer = 3,
        Team_Lead = 4
    }
    public class TeamMember: LogingEntity
    {
        public string Name { get; set; }
        public Designations? Designation { get; set; }
        public DateTime DOB { get; set; }

        public string Image { get; set; }
        public bool IsTeanLead { get; set; }
        public int? TeamId { get; set; }
        public Team Team { get; set; }
        public MemberStatus? MemberStatus { get; set; }
        public BillableStatus? BillableStatus { get; set; }
        public string  BriefDescription { get; set; }

        public string HighestQualification { get; set; }

        public int YearOfPassing { get; set; }
        public DateTime YearofJoiningCCI { get; set; }

        public DateTime YearofJoiningTeam { get; set; }
        public string phoneNumber { get; set; }
        public string Address { get; set; }
        public string Technologies { get; set; }
        public string SkypeId { get; set; }
        public string EmailId { get; set; }
        public string GmailId { get; set; }
        public TeamMember()
        {
            DateCreated = DateTime.Now;
            DateModified= DateTime.Now;
        }
    }
}
