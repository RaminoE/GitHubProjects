using Organisation.Domian.Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organisation.Domian.Model.Models
{
    public class Register:LogingEntity
    {
       
        public string Email { get; set; }
        
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public Register()
        {
            DateCreated = DateTime.Now;
            DateModified = DateTime.Now;
        }
    }

}
