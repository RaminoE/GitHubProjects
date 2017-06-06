
using Organisation.Domian.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.Domain.EF
{
    public class StoreSeedData : DropCreateDatabaseIfModelChanges<OrganisationEntities>
    {
        protected override void Seed(OrganisationEntities context)
        {
            GetGroups().ForEach(g => context.Groups.Add(g));
            GetTeams().ForEach(g => context.Teams.Add(g));
            GetTeamMemebers().ForEach(g => context.TeamMembers.Add(g));

            context.Commit();
        }

        private static List<Group> GetGroups()
        {
            return new List<Group>
            {
                new Group {
                    Name = "Web"
                },
                new Group {
                    Name = "Mobile"
                },
                
            };
        }

        private static List<Team> GetTeams()
        {
            return new List<Team>
            {
                new Team {
                    Name = "SAR",
                    ClientName="client2",
                    GroupId=1
                },
                new Team {
                    Name = "NETKEMIA",
                    ClientName="Client1",
                    GroupId=2
                },
               
                // Code ommitted 
            };
        }

        private static List<TeamMember> GetTeamMemebers()
        {
            return new List<TeamMember>
            {
                new TeamMember {
                    Name = "TeamMember1",
                    Designation="Developer",
                    DOB=DateTime.Parse("1991-01-01"),
                    TeamId=1,
                    Image="Capture.png",
                    IsTeanLead=false
                    
                   
                },
              new TeamMember {
                    Name = "TeamMember2",
                    Designation="Developer",
                    DOB=DateTime.Parse("1991-01-01"),
                    TeamId=1,
                    Image="Capture.png",
                    IsTeanLead=false
                },
               
                // Code ommitted 
            };
        }
    }
}
