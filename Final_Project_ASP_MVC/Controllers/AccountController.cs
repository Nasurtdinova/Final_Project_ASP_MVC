﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Final_Project_ASP_MVC.Models;
using Final_Project_ASP_MVC.ViewModels;
using Final_Project_ASP_MVC.Core;

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
                User user = new User { Email = model.Email, UserName = model.Email, Password = model.Password, Year = model.Year };
                Connection.AddUser(user);
                // добавляем пользователя
                //var result = await _userManager.CreateAsync(user, model.Password);
                //if (result.Succeeded)
                //{
                    // установка куки
                    //await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                //}
                //else
                //{
                //    foreach (var error in result.Errors)
                //    {
                //        ModelState.AddModelError(string.Empty, error.Description);
                //    }
                //}
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
                    else
                    {
                        return RedirectToAction("Index", "Home");
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
