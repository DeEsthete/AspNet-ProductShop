using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNet_FirstLesson.Models
{
    public class Entity
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле имя должно быть заполнено")]
        public string Name { get; set; }
    }
}