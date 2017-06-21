using Organisation.Domian.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Organisation.Web.ViewModels
{
    public class TeamMemberViewModel
    {
        public enum MemberStatusselect
        {
            Allocated_to_Team=1,
            Bench=2
        }

        public enum BillableStatusselect
        {
            Billable=1,
            Non_Billable=2
        }

        public enum Designations
        {
            Junior_Developer = 1,
            Developer = 2,
            Senior_Developer = 3,
            Team_Lead=4
        }
        [Display(Name = "Status")]
        [Required(ErrorMessage = "Please Fill")]
        public MemberStatusselect? MemberStatus { get; set; }
        [Display(Name = "Billable")]
        
        public BillableStatusselect? BillableStatus { get; set; }
        public int MStatusSelected { get; set; }
        public int BStatusSelected { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Fill")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Fill")]
        public Designations Designation { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date, ErrorMessage = "Invalid Date")]
        [Required(ErrorMessage = "Please Fill")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        public int calledFrom { get; set; }
        public string Image { get; set; }


        public bool IsTeanLead { get; set; }

        public System.Nullable<int> TeamId { get; set; }

        public IEnumerable<Team> TeamList { get; set; }

        public string search { get; set; }
        public IEnumerable<string> YearPass { get; set; }

        [Required(ErrorMessage = "Please Fill")]
        [Display(Name = "Descriptoin")]
        public string BriefDescription { get; set; }

        [Required(ErrorMessage = "Please Fill")]
        [Display(Name = "Qualification")]
        public string HighestQualification { get; set; }


        [Display(Name = "Passing Year")]
        [Required(ErrorMessage = "Please Fill")]
        public int YearOfPassing { get; set; }

        [Required(ErrorMessage = "Please Fill")]
        [Display(Name = "Joined CCI")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime YearofJoiningCCI { get; set; }

        [Required(ErrorMessage = "Please Fill")]
        [Display(Name = "Joined Team")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime YearofJoiningTeam { get; set; }

        [Required(ErrorMessage = "Please Fill")]
        [Display(Name = "Mobile")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public string phoneNumber { get; set; }

        [Required(ErrorMessage = "Please Fill")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please Fill")]
        public string Technologies { get; set; }

        [Required(ErrorMessage = "Please Fill")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email")]

        public string SkypeId { get; set; }

        [Required(ErrorMessage = "Please Fill")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email")]

        public string EmailId { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid Email")]
        [Required(ErrorMessage = "Please Fill")]

        public string GmailId { get; set; }
        public string previousUrl { get; set; }

        public HttpPostedFileBase File { get; set; }
        public int mode { get; set; }
    }
}