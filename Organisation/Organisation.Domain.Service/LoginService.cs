using Organisation.Domain.Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Organisation.Domian.Model.Models;
using Organisation.Domain.Repository.Pattern.Infrastructure;
using Organisation.Domain.Repository;

namespace Organisation.Domain.Service
{
    class LoginService : ILoginService
    {
        private readonly ILoginRepository loginRepository;
       
        private readonly IUnitOfWork unitOfWork;
        public LoginService(ILoginRepository loginRepository, IUnitOfWork unitOfWork)
        {
            this.loginRepository = loginRepository;
          
            this.unitOfWork = unitOfWork;
        }
        public void CreateLogin(Login Login)
        {
            loginRepository.Add(Login);
        }

        public void DeleteLogin(int id)
        {
            loginRepository.Delete(id);
        }

        public void DeleteLogin(Login Login)
        {
            loginRepository.Delete(Login);
        }

        public IEnumerable<Login> GetAllLogin(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return loginRepository.GetAll();
            else
                return loginRepository.GetAll().Where(c => c.Name == name);
        }

        public Login GetLogin(string name)
        {
            return loginRepository.GetLoginByName(name);
        }

        public Login GetLogin(int id)
        {
            return loginRepository.GetById(id);
        }

      

        public void SaveLogin()
        {
            unitOfWork.Commit();
        }

        public void UpdateLogin(Login Login)
        {
            loginRepository.Update(Login);
        }
    }
}
