using AspNet_FirstLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet_FirstLesson.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string SecondPassword { get; set; }

        public void SetFields(User user)
        {
            Login = user.Login;
            Password = user.Password;
            RoleId = user.RoleId;
        }

        public User GetUser()
        {
            return new User { Name = Name, Login = Login, Password = Password, RoleId = RoleId };
        }
    }
}