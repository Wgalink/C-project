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
    public class UserController(iBayDbContext ctx) : ControllerBase
    {

        private readonly UserService? _userServ = new(ctx);
        private readonly CartService? _cartServ = new(ctx);


        // GET: api/users
        [HttpGet, Route("/users")]
        public ActionResult<IEnumerable<User>> GetUser()
        {
            
                return Ok(_userServ?.GetAll());
            
        }

        // GET: api/users/5
        [HttpGet, Route("/users/{id}")]
        public ActionResult<User> GetUser(Guid id)
        {
            var user = _userServ?.GetById(id);
            return user == null
                ? NotFound()
                : Ok(user);
            
    }

        // PUT: api/users/5
        [HttpPut, Route("/users/{id}")]
        public IActionResult PutUser(Guid id)
        {
            var user = _userServ?.GetById(id);
            if (id != user.Id)
            {
                return BadRequest();
            }

            try
            {
                _userServ?.Update(user);
                _userServ?.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_userServ?.GetById(id) != null)
                {
                    return NotFound();
                }

                return BadRequest();
            }

            return Ok(user);
        }


        // PUT: api/users/seller
        [HttpPut, Route("/users/seller/{id}")]
        public IActionResult PutSeller(Guid id)
        {
            var user = _userServ?.GetById(id);
            if (id != user.Id)
            {
                return BadRequest();
            }

            try
            {
                _userServ?.PassSeller(user);
                _userServ?.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_userServ?.GetById(id) != null)
                {
                    return NotFound();
                }

                return BadRequest();
            }

            return Ok(user);
        }

        // POST: api/users
        [HttpPost, Route("/users")]
        public IActionResult PostUser(User user)
        {
            if (user.Cart == null){
                Cart cart = new Cart {
                    UserId = user.Id,
                    User = user
                };
                _cartServ.Add(cart);
                _cartServ.SaveChanges();
            }
            _userServ?.Add(user);
            _userServ?.SaveChanges();

            return Ok(user);
        }

        // DELETE: api/users/5
        [HttpDelete, Route("/users/{id}")]
        public IActionResult DeleteUser(Guid id)
        {
            try
            {
                var user = _userServ?.GetById(id);
                if (id != user.Id)
            {
                return BadRequest();
            }
                _userServ?.DeleteById(id);
                _userServ?.SaveChanges();
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}