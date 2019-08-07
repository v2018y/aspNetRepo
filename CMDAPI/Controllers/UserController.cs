using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CMDAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CMDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly CommandContext _context;
        
        public UserController(CommandContext context){
            _context=context;
        }

        //GET:  api/user
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUser(){
            return _context.User;
        }

        //GET : api/user/n
        [HttpGet("{id}")]
        public ActionResult<User> GetUserItem(int id){
            var userItem= _context.User.Find(id);
            if(userItem == null){
                return NotFound();
            }
            return userItem;
        }

        //POST : api/user
        [HttpPost]
        public ActionResult<User> PostUserItem(User user){
            _context.User.Add(user);
            _context.SaveChanges();
           return CreatedAtAction("GetUserItem",new User{id=user.id},user);
       }

        //PUT : api/user/n
        [HttpPut("{id}")]
        public ActionResult PutUserItem(int id,User user){
            if(id !=user.id){
                return BadRequest();
            }
            _context.Entry(user).State= EntityState.Modified;
            _context.SaveChanges();
            return CreatedAtAction("GetUserItem",new User{id=user.id},user);
        }
        //DELETE : api/user/n
        [HttpDelete("{id}")]
        public ActionResult<User> DeleteUserItem(int id){
            var userItem=_context.User.Find(id);
            if(userItem == null){
                return NotFound();
            }
            _context.User.Remove(userItem);
            _context.SaveChanges();
            return userItem;
        }


    }
}
