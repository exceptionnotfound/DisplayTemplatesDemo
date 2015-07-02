using DisplayTemplatesDemo.DataAccess.Managers;
using DisplayTemplatesDemo.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DisplayTemplatesDemo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var users = UserManager.GetAll();
            return View(users);
        }

        [HttpGet]
        public ActionResult Add()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(User user)
        {
            UserManager.Add(user.FirstName, user.MiddleInitial, user.LastName, user.DateOfBirth, user.UserName, user.IsAdmin, new List<int>());
            return RedirectToAction("Index");
        }
    }
}