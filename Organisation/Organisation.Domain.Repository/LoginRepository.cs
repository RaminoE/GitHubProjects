using Organisation.Domain.Repository.Pattern;
using Organisation.Domain.Repository.Pattern.Infrastructure;
using Organisation.Domian.Model.Models;
using Organisation.Web.CustomLibraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.Domain.Repository
{
    public class LoginRepository : Repository<Login>, ILoginRepository
    {
        public LoginRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

       

        public Login GetLoginByName(string username)
        {
           
            var user = this.DbContext.Login.Where(c=>c.Name.ToLower()==username.ToLower()||c.Email==username).FirstOrDefault();

            return user;
        }

      

        public override void Update(Login entity)
        {
            entity.DateModified = DateTime.Now;
            base.Update(entity);
        }
    }
    public interface ILoginRepository : IRepository<Login>
    {
        Login GetLoginByName(string username);
    }

}

