using DisplayTemplatesDemo.DataAccess.Managers;
using DisplayTemplatesDemo.DataAccess.Model;
using DisplayTemplatesDemo.ViewModels.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DisplayTemplatesDemo.Controllers
{
    public class RoleController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var roles = RoleManager.GetAll();
            return View(roles);
        }

        [HttpGet]
        public ActionResult Add()
        {
            Role role = new Role();
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Role role)
        {
            RoleManager.Add(role.Name);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult User(int id)
        {
            UserRoleVM model = new UserRoleVM();
            model.Users = UserManager.GetByRole(id);
            model.Role = RoleManager.GetByID(id);
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Role model = RoleManager.GetByID(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Role model)
        {
            RoleManager.Edit(model.ID, model.Name);
            return RedirectToAction("Index");
        }
    }
}