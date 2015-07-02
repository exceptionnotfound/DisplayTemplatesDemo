using DisplayTemplatesDemo.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DisplayTemplatesDemo.DataAccess.Managers
{
    public static class RoleManager
    {
        public static List<Role> GetAll()
        {
            using(UsersEntities context = new UsersEntities())
            {
                return context.Roles.Include(x => x.Users).ToList();
            }
        }

        public static Role GetByID(int id)
        {
            using (UsersEntities context = new UsersEntities())
            {
                return context.Roles.Include(x => x.Users).Where(x=>x.ID == id).First();
            }
        }

        public static void Add(string name)
        {
            using(UsersEntities context = new UsersEntities())
            {
                Role role = new Role()
                {
                    Name = name
                };

                context.Roles.Add(role);
                context.SaveChanges();
            }
        }

        public static void Edit(int id, string name)
        {
            using (UsersEntities context = new UsersEntities())
            {
                Role role = context.Roles.Find(id);
                role.Name = name;
                context.SaveChanges();
            }
        }
    }
}