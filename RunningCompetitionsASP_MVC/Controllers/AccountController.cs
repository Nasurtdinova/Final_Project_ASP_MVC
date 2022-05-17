using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
                    Email = model.Login, 
                    Password = model.Password                    
                };

                Sponsor spon = new Sponsor 
                { 
                    Surname = model.Surname, 
                    Name = model.Name, 
                    Phone = model.Phone, 
                };

                if (ConnectionUser.IsCoinsLogin(model.Password))
                    ModelState.AddModelError("", "Такой логин уже существует");
                else if (!(model.Password.Length >= 6 && ConnectionUser.IsCorrectPassword(model.Password)))
                    ModelState.AddModelError("", "Пароль должен отвечать следующим требованиям \nМинимум 6 символов \nМинимум 1 прописная буква \nМинимум 1 цифра \nМинимум один символ из набора: ! @ # $ % ^. ");
                else
                {
                    ConnectionUser.AddUser(user);
                    ConnectionUser.AddSponsor(spon);
                    ModelState.AddModelError("", "Вы зарегистрированы!");
                }
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
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }

                if (ConnectionUser.IsCorrectUser(model.Login,model.Password) == 1)
                {                                   
                    return RedirectToAction("IndexHome", "Home");
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
