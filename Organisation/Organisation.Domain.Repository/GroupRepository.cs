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
    public class GroupRepository : Repository<Group>,IGroupRepository
    {
        public GroupRepository(IDbFactory dbFactory) : 
            base(dbFactory)
        {
        }
        public Group GetGroupByName(string groupname)
        {
            var group = this.DbContext.Groups.Where(c => c.Name == groupname).FirstOrDefault();

            return group;
        }

        public override void Update(Group entity)
        {
            entity.DateModified = DateTime.Now;
            base.Update(entity);
        }
    }

    public interface IGroupRepository : IRepository<Group>
    {
        Group GetGroupByName(string groupname);
    }
}
