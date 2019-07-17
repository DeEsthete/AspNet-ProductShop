using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNet_FirstLesson.Models
{
    public class Basket
    {
        [Required]
        [Key]
        public int Id { get; set; }

        public IEnumerable<BasketItem> Items { get; set; }
    }
}