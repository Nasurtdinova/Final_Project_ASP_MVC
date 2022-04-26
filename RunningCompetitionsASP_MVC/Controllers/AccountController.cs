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
                    Password = model.Password, 
                    idType = 2 
                };

                Sponsor spon = new Sponsor 
                { 
                    Surname = model.Surname, 
                    Name = model.Name, 
                    Phone = model.Phone, 
                    idUser = Connection.GetUsers().Last().idUser 
                };

                if (Connection.IsCoinsLogin(model.Password))
                    ModelState.AddModelError("", "Такой логин уже существует");
                else if (!(model.Password.Length >= 6 && Connection.IsCorrectPassword(model.Password)))
                    ModelState.AddModelError("", "Пароль должен отвечать следующим требованиям \nМинимум 6 символов \nМинимум 1 прописная буква \nМинимум 1 цифра \nМинимум один символ из набора: ! @ # $ % ^. ");
                else
                {
                    Connection.AddUser(user);
                    Connection.AddSponsor(spon);
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
                if (Connection.IsLogin(model.Login,model.Password) == 1)
                {
                    return RedirectToAction("IndexHome", "Home");
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
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
