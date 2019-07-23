using AspNet_FirstLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspNet_FirstLesson.Interfaces
{
    public interface IBasketRepository
    {
        bool AddToBasket(int basketId, int productId);
        bool RemoveFromBasket(int basketId, int productId);
    }
}
