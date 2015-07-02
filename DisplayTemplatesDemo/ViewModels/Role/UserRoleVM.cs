using DisplayTemplatesDemo.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DisplayTemplatesDemo.ViewModels.Role
{
    public class UserRoleVM
    {
        public List<User> Users { get; set; }
        public DisplayTemplatesDemo.DataAccess.Model.Role Role { get; set; }
    }
}