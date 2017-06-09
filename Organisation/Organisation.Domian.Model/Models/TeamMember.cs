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
        Allocated_to_Team,
        Bench
    }

    public enum BillableStatus
    {
        Billable,
        Non_Billable
    }
    public class TeamMember: LogingEntity
    {
        public string Name { get; set; }
        public string Designation { get; set; }
        public DateTime DOB { get; set; }

        public string Image { get; set; }
        public bool IsTeanLead { get; set; }
        public System.Nullable<int> TeamId { get; set; }
        public Team Team { get; set; }
        public MemberStatus? MemberStatus { get; set; }
        public BillableStatus? BillableStatus { get; set; }
        public string  BriefDescription { get; set; }

        public string HighestQualification { get; set; }

        public string YearOfPassing { get; set; }
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
