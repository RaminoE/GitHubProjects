using Organisation.Domian.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.Domian.Model.Models
{
   public  class Login:LogingEntity
    {

      
        public string Email { get; set; }

      public string Name { get; set; }
        public string Password { get; set; }

       
public string ReturnUrl { get; set; }
        public Login()
        {
            DateCreated = DateTime.Now;
            DateModified = DateTime.Now;
        }
    }
}
