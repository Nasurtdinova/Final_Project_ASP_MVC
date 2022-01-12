using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Final_Project_ASP_MVC.Models;
using Final_Project_ASP_MVC.ViewModels;
using Core;

namespace Final_Project_ASP_MVC.Controllers
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
                User user = new User { Email = model.Email, Password = model.Password, Year = model.Year, Surname = model.Surname, UserName= model.Name };
                Connection.AddUser(user);
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
                if (Connection.IsLogin(model.Email,model.Password))
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else if (model.Email == "nasurtdinovaguz@mail.ru" && model.Password == "2003")
                    {
                        return RedirectToAction("IndexHome", "Home");
                    }
                    else
                    {
                        Connection con = new Connection(model.Email, model.Password);
                        return RedirectToAction("IndexSponsor", "Home");
                    }
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
