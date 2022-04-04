using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Project_ASP_MVC.Models;
using RunningCompetitionsASP_MVC.ViewModels;
using CoreFramework;

namespace RunningCompetitionsASP_MVC.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                Users user = new Users 
                { 
                    Email = model.Email, 
                    Password = model.Password, 
                    idType = 2 
                };
                Connection.AddUser(user);

                Sponsor spon = new Sponsor 
                { 
                    Surname = model.Surname, 
                    Name = model.Name, 
                    Phone = model.Phone, 
                    idUser = Connection.GetUsers().Last().idUser 
                };
                Connection.AddSponsor(spon);

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (Connection.IsLogin(model.Email,model.Password) == 1)
                {
                    return RedirectToAction("IndexHome", "Home");
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                }
                else if (Connection.IsLogin(model.Email, model.Password) == 2)
                {
                    CurrentUser.user = Connection.GetUser(model.Email, model.Password);
                    CurrentUser.spon = Connection.GetSponsor(CurrentUser.user.idUser);
                    return RedirectToAction("IndexSponsor", "Home");
                }

                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }
    }
}
