using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository repository;
        public UserController(IUserRepository repo)
        {
            repository = repo;
        }
        public ViewResult MainPage(int userId)
        {
            User user = repository.Users
                .FirstOrDefault(p => p.UserID == userId);
            return View(user);
        }
        public ViewResult Login()
        {
            return View(new User());
        }
       [HttpPost]
        public ViewResult Login(User userEntered)
        {
            User user = repository.Users
                .FirstOrDefault(p => p.Email == userEntered.Email);
            if (user != null)
            {
                if (user.Password == userEntered.Password)
                {
                    return View("MainPage", user);
                }
                else
                {
                    TempData["message"] = string.Format("Password isn't correct");
                    return View(new User());
                }
            }
            else
            {
                TempData["message"] = string.Format("{0} is not found", userEntered.Email);
                return View(new User());
            }

        }
        public ViewResult Registration()
        {
            return View(new RegistrationModel());
        }

        [HttpPost]
        public ActionResult Registration(RegistrationModel registrDataUser, HttpPostedFileBase image)
        {
            User userForCheckedEmail = repository.Users
                .FirstOrDefault(p => p.Email == registrDataUser.Email);
            if (userForCheckedEmail == null)
            {
                User user = new User();
                if (ModelState.IsValid)
                {
                    if (image != null)
                    {
                        user.ImageMimeType = image.ContentType;
                        user.ImageData = new byte[image.ContentLength];
                        image.InputStream.Read(user.ImageData, 0, image.ContentLength);
                    }
                    user.Email = registrDataUser.Email;
                    user.Password = registrDataUser.Password;
                    user.Name = registrDataUser.Name;
                    user.Surname = registrDataUser.Surname;
                    user.UserID = registrDataUser.UserID;
                    user.Burthday = registrDataUser.Burthday;
                    user.NumberPhone = registrDataUser.NumberPhone;
                    repository.SaveUser(user);
                    return View("MainPage", user);
                }
                else
                {
                    return View(registrDataUser);
                }
            }
            else
            {
                return View(registrDataUser);

            }

        }
        public ActionResult About()
        {
            return PartialView();
        }
        public FileContentResult GetImage(int userId)
        {
            User user = repository.Users.FirstOrDefault(u => u.UserID == userId);
            if (user!=null)
	        {
		        return  File(user.ImageData, user.ImageMimeType);
	        }
            else
	        {
                return null;
	        }
        }

    }
}