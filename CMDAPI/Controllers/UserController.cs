using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CMDAPI.Models;

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
           int i= _context.SaveChanges();
            if(i>0){
                return user;
            }else{
                return NotFound();
            }

        }
    }
}
