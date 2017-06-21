using Organisation.Domian.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.Domain.Service.Pattern
{
    public interface ILoginService
    {
        IEnumerable<Login> GetAllLogin(string name = null);
       
        Login GetLogin(int id);
        Login GetLogin(string name);
        void CreateLogin(Login Login);
        void UpdateLogin(Login Login);
        void DeleteLogin(Login Login);
        void SaveLogin();
        void DeleteLogin(int id);
    }
}
