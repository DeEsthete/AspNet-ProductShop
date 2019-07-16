using AspNet_FirstLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet_FirstLesson.ViewModels
{
    public class UserViewModel : User
    {
        public string SecondPassword { get; set; }
    }
}