using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TheRamShop.Models.Authentication;
using TheRamShop.Models.DataEntities;
using TheRamShop.Models.DataPreparation;
using TheRamShop.Models.DataProviders;
using TheRamShop.Models.PageModels;
using TheRamShop.Models.Statement;

namespace TheRamShop.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult LogIn()
        {
            DefaultPreparations.LoadPrimaryInfo(this);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                AccountInfo user = null;

                using (AuthenticationProvider provider = new AuthenticationProvider(new SqlConnection()))
                {
                    user = provider.Authenticate(model.Email, model.Password);
                }
                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Пользователя с таким логином и паролем нет");
                }
            }
            DefaultPreparations.LoadPrimaryInfo(this);
            return View(model);
        }

        public ActionResult Register()
        {
            DefaultPreparations.LoadPrimaryInfo(this);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                AccountInfo user = null;
                /*using (UserContext db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Email == model.Name);
                }
                if (user == null)
                {
                    // создаем нового пользователя
                    using (UserContext db = new UserContext())
                    {
                        db.Users.Add(new User { Email = model.Name, Password = model.Password, Age = model.Age });
                        db.SaveChanges();

                        user = db.Users.Where(u => u.Email == model.Name && u.Password == model.Password).FirstOrDefault();
                    }
                    // если пользователь удачно добавлен в бд
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Name, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с таким логином уже существует");
                }*/
            }
            DefaultPreparations.LoadPrimaryInfo(this);
            return View(model);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}