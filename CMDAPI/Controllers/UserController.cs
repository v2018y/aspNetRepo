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

        //  api/user
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUser(){
            return _context.CommandItems;
        }
    }
}
