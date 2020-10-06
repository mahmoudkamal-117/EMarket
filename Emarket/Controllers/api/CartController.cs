using Emarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Emarket.Controllers.api
{
    public class CartController : ApiController
    {
         private ApplicationDbContext _context;
         public CartController()
        {
            _context = new ApplicationDbContext();
        }
         [HttpPost]
        //action get one parammeter (id) 
         public IHttpActionResult Add(int id)
         {
             //creat object from cart model and adding the data 
             var cart = new Cart
             {
                 product_id = id,
                 added_at = DateTime.Now
             };
             //pass the object tp data base to add new record
             _context.Cart.Add(cart);
             _context.SaveChanges();
             return Ok();
         }
         [HttpDelete]
        //getting product id 
         public IHttpActionResult Delete(int id)
         {
             //linq query to check if proudct is exist or not
             var cart = _context.Cart.SingleOrDefault(p => p.product_id == id);
             //if not exist return not fount err404
             if (cart == null)
                 return NotFound();
             //delete the record from the database and update it
             _context.Cart.Remove(cart);
             _context.SaveChanges();
             return Ok();
         }
    }
}
