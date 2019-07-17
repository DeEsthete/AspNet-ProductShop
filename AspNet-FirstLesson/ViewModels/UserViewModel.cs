using AspNet_FirstLesson.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNet_FirstLesson.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Это поле необходимо заполнить")]
        [MinLength(5, ErrorMessage = "Логин должен состоять как минимум из 5 символов")]
        [RegularExpression("^[a-zA-Zа-яА-Я][a-zA-Zа-яА-Я0-9]{2,9}$", ErrorMessage = "Логин не должен содержать спец. символы и должен иметь определенную длину")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Это поле необходимо заполнить")]
        [MinLength(5, ErrorMessage = "Логин должен состоять как минимум из 5 символов")]
        [RegularExpression("^[a-zA-Zа-яА-Я][a-zA-Zа-яА-Я0-9]{2,9}$", ErrorMessage = "Логин не должен содержать спец. символы и должен иметь определенную длину")]
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