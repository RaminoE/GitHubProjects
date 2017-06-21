namespace Organisation.Domain.Ef.Migrations
{
    using Domian.Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Organisation.Domain.EF.OrganisationEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Organisation.Domain.EF.OrganisationEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //


            //GetGroups().ForEach(g => context.Groups.Add(g));
            //GetTeams().ForEach(g => context.Teams.Add(g));
            //GetTeamMemebers().ForEach(g => context.TeamMembers.Add(g));

           // context.Commit();
        }

        //private static List<Group> GetGroups()
        //{
        //    return new List<Group>
        //    {
        //        new Group {
        //            Name = "Web",
        //            DateCreated=DateTime.UtcNow,
        //           DateModified=DateTime.UtcNow,
        //        },
        //        new Group {
        //            Name = "Mobile",
        //            DateCreated=DateTime.UtcNow,
        //           DateModified=DateTime.UtcNow,
        //        },

        //    };
        //}

        //private static List<Team> GetTeams()
        //{
        //    return new List<Team>
        //    {
        //        new Team {
        //            Name = "SAR",
        //            ClientName="client2",
        //            GroupId=1,
        //            DateCreated=DateTime.UtcNow,
        //           DateModified=DateTime.UtcNow,
        //        },
        //        new Team {
        //            Name = "NETKEMIA",
        //            ClientName="Client1",
        //            GroupId=2,
        //            DateCreated=DateTime.UtcNow,
        //           DateModified=DateTime.UtcNow,
        //        },
               
        //        // Code ommitted 
        //    };
        //}

        //private static List<TeamMember> GetTeamMemebers()
        //{
        //    return new List<TeamMember>
        //    {
        //        new TeamMember {
        //            Name = "TeamMember1",
        //            Designation=1,
        //            DOB=DateTime.Parse("1991-01-01"),
        //            TeamId=1,
        //            Image="Capture.png",
        //            IsTeanLead=false,
        //           SkypeId="abc@skype.com",
        //           GmailId="abc@gmail.com",
        //           EmailId="acd@skype.com",
        //           Address="Goa",
        //           BriefDescription="",
        //           HighestQualification="MSC.IT",
        //           YearofJoiningCCI=DateTime.UtcNow,
        //           YearOfPassing=2007,
        //            YearofJoiningTeam =DateTime.UtcNow,
        //           phoneNumber="9955223366",
        //           Technologies=".net",
        //           DateCreated=DateTime.UtcNow,
        //           DateModified=DateTime.UtcNow,



        //        },
        //      new TeamMember {
        //            Name = "TeamMember2",
        //            Designation=1,
        //            DOB=DateTime.Parse("1991-01-01"),
        //            TeamId=1,
        //            Image="Capture.png",
        //            IsTeanLead=false,
        //             SkypeId="abc@skype.com",
        //           GmailId="abc@gmail.com",
        //           EmailId="acd@skype.com",
        //           Address="Goa",
        //           BriefDescription="",
        //           HighestQualification="MSC.IT",
        //           YearofJoiningCCI=DateTime.UtcNow,
        //           YearOfPassing=2007,
        //           YearofJoiningTeam=DateTime.UtcNow,
        //           phoneNumber="9955223366",
        //           Technologies=".net",
        //           DateCreated=DateTime.UtcNow,
        //           DateModified=DateTime.UtcNow,
        //        },
               
        //        // Code ommitted 
        //    };
        //}

    }
}

