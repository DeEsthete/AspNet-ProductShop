using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNet_FirstLesson.Models
{
    public class OrderBasketItem
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [ForeignKey("OrderBasket")]
        [Required]
        public int OrderBasketId { get; set; }
        public virtual Basket OrderBasket { get; set; }

        [ForeignKey("Product")]
        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}