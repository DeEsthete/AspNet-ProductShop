using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNet_FirstLesson.Models
{
    public class Order : Entity
    {
        [ForeignKey("OrderBasket")]
        public int OrderBasketId { get; set; }
        public virtual OrderBasket OrderBasket { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
        public double Amount { get; set; }
    }
}