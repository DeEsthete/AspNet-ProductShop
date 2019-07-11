using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet_FirstLesson.Models
{
    public class Category : Entity
    {
        public virtual IEnumerable<Product> Products { get; set; }
    }
}