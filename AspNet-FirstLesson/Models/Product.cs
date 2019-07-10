using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet_FirstLesson.Models
{
    public class Product : Entity
    {
        public Producer Producer { get; set; }
        public double Price { get; set; }

        public string GetString()
        {
            return Producer.Name + " " + Name + " " + Price;
        }
    }
}