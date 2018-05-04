using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using sampleApi.Models;

namespace sampleApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly SampleContext _context;

        public UsersController(SampleContext context)
        {
            _context = context;

            if (_context.Users.Count() == 0)
            {
                _context.Users.Add(new User { Id = 1, Name = "Shahbaz" });
                _context.SaveChanges();
            }
        }

        // GET api/users
        [HttpGet]
        public List<User> Get()
        {
            return _context.Users.ToList();
        }

        // GET api/users/5
        [HttpGet("{id}"), ActionName("Get")]
        public ActionResult Get(long id)
        {
            var item = _context.Users.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // POST api/users
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok(user.Id);
        }

        // PUT api/users/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody]User value)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            user.Name = value.Name;

            _context.Users.Update(user);
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
