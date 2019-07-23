using AspNet_FirstLesson.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNet_FirstLesson.ViewModels
{
    public class EditViewModel
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string RoleId { get; set; }

        public EditViewModel()
        {

        }
        public EditViewModel(User user)
        {
            Id = user.Id;
            UserName = user.UserName;
            RoleId = user.Roles.First().RoleId;
            Email = user.Email;
        }
    }
}