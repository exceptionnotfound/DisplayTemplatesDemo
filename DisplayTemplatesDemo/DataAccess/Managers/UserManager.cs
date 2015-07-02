using DisplayTemplatesDemo.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DisplayTemplatesDemo.DataAccess.Managers
{
    public static class UserManager
    {
        public static List<User> GetAll()
        {
            using (UsersEntities context = new UsersEntities())
            {
                return context.Users.Include(x => x.Roles).Include(x => x.Addresses).ToList();
            }
        }
        public static User GetByID(int id)
        {
            using(UsersEntities context = new UsersEntities())
            {
                return context.Users.Include(x => x.Roles).Include(x => x.Addresses).Where(x => x.ID == id).First();
            }
        }

        public static List<User> GetByRole(int roleID)
        {
            using (UsersEntities context = new UsersEntities())
            {
                return context.Users.Include(x => x.Roles).Include(x => x.Addresses).Where(x => x.Roles.Select(y => y.ID).Contains(roleID)).ToList();
            }
        }

        public static void Add(string firstName, string middleInitial, string lastName, DateTime dateOfBirth, string userName, bool isAdmin, List<int> roles)
        {
            using(UsersEntities context = new UsersEntities())
            {
                User user = new User()
                {
                    FirstName = firstName,
                    MiddleInitial = middleInitial,
                    LastName = lastName,
                    DateOfBirth = dateOfBirth,
                    UserName = userName,
                    IsAdmin = isAdmin,
                    Roles = context.Roles.Where(x=>roles.Contains(x.ID)).ToList()
                };

                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public static void Edit(int userID, string firstName, string middleInitial, string lastName, DateTime dateOfBirth, string userName, bool isAdmin, List<int> roles)
        {
            using(UsersEntities context = new UsersEntities())
            {
                var user = context.Users.Find(userID);
                user.FirstName = firstName;
                user.MiddleInitial = middleInitial;
                user.LastName = lastName;
                user.DateOfBirth = dateOfBirth;
                user.UserName = userName;
                user.IsAdmin = isAdmin;
                user.Roles = context.Roles.Where(x => roles.Contains(x.ID)).ToList();

                context.SaveChanges();
            }
        }
    }
}