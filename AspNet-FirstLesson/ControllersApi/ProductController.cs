using AspNet_FirstLesson.Data;
using AspNet_FirstLesson.Interfaces;
using AspNet_FirstLesson.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace AspNet_FirstLesson.ControllersApi
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private readonly IRepository<Product> productRepository = new ProductRepository();

        [Route("GetProduct/{id}")]
        [HttpGet]
        public IHttpActionResult GetProduct(int? id)
        {
            Product product = null;
            if (id != null)
            {
                product = productRepository.GetAll().FirstOrDefault(p => p.Id == id);
            }
            return Json(product);
        }

        [Route("GetProducts")]
        [HttpGet]
        public IHttpActionResult GetProducts()
        {
            return Json(productRepository.GetAll().ToList());
        }

        [Route("Add")]
        [HttpPost]
        public void Add(Product product)
        {
            productRepository.Add(product);
        }

        [Route("Delete/{id}")]
        [HttpPost]
        public void Delete(int? id)
        {
            if (id != null)
            {
                productRepository.Delete(id.Value);
            }
        }

        [Route("Edit")]
        [HttpPost]
        public void Edit(Product product)
        {
            productRepository.Edit(product);
        }
    }
}
