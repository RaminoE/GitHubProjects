using Organisation.Domian.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Organisation.Domain.Repository.Pattern.Infrastructure;
using Organisation.Domain.Repository.Pattern;

namespace Organisation.Domain.Repository
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
        public Team GetTeamByName(string teamname)
        {
            var team = this.DbContext.Teams.Where(c => c.Name == teamname).FirstOrDefault();

            return team;
        }

        public override void Update(Team entity)
        {
            entity.DateModified = DateTime.Now;
            base.Update(entity);
        }
    }
    public interface ITeamRepository : IRepository<Team>
    {
        Team GetTeamByName(string groupname);
    }

}
