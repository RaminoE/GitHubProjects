
using Organisation.Domain.EF.Mappings;
using Organisation.Domian.Model.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.Domain.EF
{
    public class OrganisationEntities: DbContext
    {
        public OrganisationEntities() : base("OrganisationEntities") { }
        
        public DbSet<Group> Groups { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        
        public virtual void Commit()
        {
            base.SaveChanges();
        }

        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TeamMemberMappings());
            modelBuilder.Configurations.Add(new TeamMappings());
            modelBuilder.Configurations.Add(new GroupMappings());
            //modelBuilder.Configurations.Add(new GroupMappings());


        }
    }
}
