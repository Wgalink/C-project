using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cproject.Entities.Services;
using Cproject.Entities.Models;
using Cproject.Context;

namespace Cproject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController(iBayDbContext ctx) : ControllerBase
    {

        private readonly CartService? _cartServ = new(ctx);


        // GET: api/carts
        [HttpGet, Route("/cart")]
        public ActionResult<IEnumerable<Cart>> GetCart()
        {
            return Ok(_cartServ?.GetAll());
        }

        // GET: api/carts/5
        [HttpGet, Route("/carts/{id}")]
        public ActionResult<Cart> GetCart(Guid id)
        {
            var cart = _cartServ?.GetById(id);
            return cart == null
                ? NotFound()
                : Ok(cart);
        }

        // POST: api/carts
        [HttpPost, Route("/carts")]
        public IActionResult PostCart(Cart cart, [FromQuery] Guid userId)
        {
            _cartServ?.Add(cart);
            _cartServ?.SaveChanges();

            return Ok(cart);
        }

        // DELETE: api/carts/5
        [HttpDelete, Route("/carts/{id}")]
        public IActionResult DeleteCart(Guid id)
        {
            try
            {
                _cartServ?.DeleteById(id);
                _cartServ?.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        // put: api/carts/empty
        [HttpPut, Route("/carts/empty")]
        public IActionResult EmptyCart(Cart cart) 
        {
            try
            {
                _cartServ?.Empty(cart);
                _cartServ?.SaveChanges();
                return Ok(cart);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}