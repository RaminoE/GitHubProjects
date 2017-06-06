using Organisation.Domain.Repository.Pattern.Infrastructure;
using Organisation.Domain.EF;

namespace Organisation.Domain.Repository.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        OrganisationEntities dbContext;
        public OrganisationEntities Init()
        {
            return dbContext ?? (dbContext = new OrganisationEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
