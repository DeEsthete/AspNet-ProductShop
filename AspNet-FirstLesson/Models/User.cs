using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspNet_FirstLesson.Models
{
    public class User : IdentityUser
    {
        public double Wallet { get; set; }

        [ForeignKey("Basket")]
        public int? BasketId { get; set; }
        public Basket Basket { get; set; }
    }
}