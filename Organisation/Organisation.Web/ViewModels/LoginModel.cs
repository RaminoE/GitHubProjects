using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Organisation.Web.ViewModels
{
    public class LoginModel
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Please Fill")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please Fill")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Fill")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

      
        public string ReturnUrl { get; set; }

        
        public string EmailName { get; set; }
        
    }
}