using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNet_FirstLesson.Models
{
    public class Product : Entity
    {
        [ForeignKey("Producer")]
        public int ProducerId { get; set; }
        public virtual Producer Producer { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [Required]
        public double Price { get; set; }

        public string GetString()
        {
            return Producer.Name + " " + Name + " " + Price;
        }
    }
}