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
    class TeamMemberAssignmentRepository : Repository<TeamMemberAssignment>, ITeamMemberAssignmentRepository
    {
        public TeamMemberAssignmentRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
        public override void Update(TeamMemberAssignment entity)
        {
            entity.DateModified = DateTime.Now;
            base.Update(entity);
        }
    }
    public interface ITeamMemberAssignmentRepository : IRepository<TeamMemberAssignment>
    {

    }
}
