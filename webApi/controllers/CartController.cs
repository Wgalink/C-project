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

        // PUT: api/carts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut, Route("/carts/{id}")]
        public IActionResult AddProduct(Guid id, Cart cart)
        {
            if (id != cart.Id)
            {
                return BadRequest();
            }

            try
            {
                _cartServ?.Update(cart);
                _cartServ?.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_cartServ?.GetById(id) != null)
                {
                    return NotFound();
                }

                return BadRequest();
            }

            return NoContent();
        }

        // POST: api/carts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost, Route("/carts")]
        public IActionResult PostCart(Cart cart)
        {
            _cartServ?.Add(cart);
            _cartServ?.SaveChanges();

            return CreatedAtAction("GetCart", new { id = cart.Id }, cart);
        }

        // DELETE: api/carts/5
        [HttpDelete, Route("/carts/{id}")]
        public IActionResult DeleteCart(Guid id)
        {
            try
            {
                _cartServ?.DeleteById(id);
                _cartServ?.SaveChanges();
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}