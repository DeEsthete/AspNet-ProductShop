using AspNet_FirstLesson.Interfaces;
using AspNet_FirstLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet_FirstLesson.Data
{
    public class UserBasketRepository : IBasketRepository
    {
        private readonly ProductContext db = new ProductContext();

        public bool AddToBasket(int basketId, int productId)
        {
            if (db.Baskets.FirstOrDefault(b => b.Id == basketId) != null && db.Products.FirstOrDefault(p => p.Id == productId) != null)
            {
                db.BasketItems.Add(new BasketItem { BasketId = basketId, ProductId = productId });
                return true;
            }
            return false;
        }

        public bool RemoveFromBasket(int basketId, int productId)
        {
            if (db.Baskets.FirstOrDefault(b => b.Id == basketId) != null && db.Products.FirstOrDefault(p => p.Id == productId) != null)
            {
                BasketItem basketItem = db.BasketItems.FirstOrDefault(bi => bi.BasketId == basketId && bi.ProductId == productId);
                if (basketItem != null)
                {
                    db.BasketItems.Remove(basketItem);
                    return true;
                }
            }
            return false;
        }
    }
}