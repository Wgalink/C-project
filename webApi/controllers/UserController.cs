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


        // GET: api/users
        [HttpGet, Route("/users")]
        public ActionResult<IEnumerable<User>> GetUser()
        {
            try{
                return Ok(_userServ?.GetAll());
            }catch(err){
                res.status(500).json({ error: 'error system' })
    }
            }
        }

        // GET: api/users/5
        [HttpGet, Route("/users/{id}")]
        public ActionResult<User> GetUser(Guid id)
        {try{
            var user = _userServ?.GetById(id);
            return user == null
                ? NotFound()
                : Ok(user);
            }catch(err){
                res.status(500).json({ error: 'error system' })
    }
        }

        // PUT: api/users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut, Route("/users/{id}")]
        public IActionResult PutUser(Guid id, User user)
        {
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

            return NoContent();
        }

        // POST: api/users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost, Route("/users")]
        public IActionResult PostUser(User user)
        {
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
                _userServ?.DeleteById(id);
                _userServ?.SaveChanges();
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}