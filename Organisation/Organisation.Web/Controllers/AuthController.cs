using AutoMapper;
using Organisation.Domain.Service.Pattern;
using Organisation.Domian.Model.Models;
using Organisation.Web.CustomLibraries;
using Organisation.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Organisation.Web.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly ILoginService loginService;
        // GET: Auth
        public AuthController()
        {

        }
        public AuthController(ILoginService loginService)
        {
            this.loginService = loginService;

        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            var username = login.EmailName;
            
            if (!string.IsNullOrEmpty(login.EmailName.ToString()) && !string.IsNullOrEmpty(login.Password.ToString()))
            {
                var login_details=loginService.GetLogin(username);
                if(login_details!=null)
                {
                    var decrypt_password = CustomDecrypt.Decrypt(login_details.Password);
                    if(decrypt_password.Equals(login.Password))
                    {
                        var identity = new ClaimsIdentity(new[] {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Email, login_details.Email.ToString()),
           
    }, "ApplicationCookie");
                        var ctx = Request.GetOwinContext();
                        var authManager = ctx.Authentication;
                        authManager.SignIn(identity);
                        return Redirect(GetUrl());
                    }
                }
                else
                {
                    return View(login);
                }
            }
            else {
                return View(login);
            }
            return View();
        }

        private string GetUrl()
        {
            return Url.Action("Index", "Home");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(LoginModel model)
        {
            if (ModelState.IsValid)
            {


                var encryptedPassword = CustomEncrypt.Encrypt(model.Password);

                model.Email = model.Email;
                model.Password = encryptedPassword;

                model.Name = model.Name;
                var user = Mapper.Map<LoginModel, Login>(model);
                loginService.CreateLogin(user);
                loginService.SaveLogin();
                return RedirectToAction("Login");
            }
            else
            {
                return View(model);
            }

        }
    }
}