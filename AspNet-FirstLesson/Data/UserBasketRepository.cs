using AspNet_FirstLesson.Interfaces;
using AspNet_FirstLesson.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNet_FirstLesson.Data
{
    public class UserBasketRepository : IBasketRepository<Basket>
    {
        private readonly ProductContext db = new ProductContext();

        public bool AddToBasket(int basketId, int productId)
        {
            if (db.Baskets.FirstOrDefault(b => b.Id == basketId) != null && db.Products.FirstOrDefault(p => p.Id == productId) != null)
            {
                db.BasketItems.Add(new BasketItem { BasketId = basketId, ProductId = productId });
                db.SaveChanges();
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
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public Dictionary<int, int> GetAllItems(int basketId)
        {
            Basket basket = db.Baskets.FirstOrDefault(b => b.Id == basketId);
            if (basket != null)
            {
                Dictionary<int,int> result = new Dictionary<int, int>();
                foreach(var i in db.BasketItems)
                {
                    foreach (var p in db.Products)
                    {
                        if (i.ProductId == p.Id)
                        {
                            if (result.Keys.FirstOrDefault(k => k == p.Id) != 0)
                            {
                                result[p.Id]++;
                            }
                            else
                            {
                                result.Add(p.Id, 1);
                            }
                        }
                    }
                }
                return result;
            }
            throw new NotImplementedException();
        }
    }
}