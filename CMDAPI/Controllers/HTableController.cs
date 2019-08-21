using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CMDAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CMDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HTableController : ControllerBase
    {
        private readonly CommandContext _context;
        
        public HTableController(CommandContext context){
           _context=context;
        }

        //GET:  api/htable
        [HttpGet]
        public IActionResult GetHTable(){
            var user=Request.Headers["userId"];
            Console.WriteLine("User Id "+user);
            Console.WriteLine(" Res = "+_context.HTable.Where(s => s.userId == user));
            return Ok (_context.HTable.Where(s => s.userId == Convert.ToInt32(user)));
        }

        //GET : api/htable/n
        [HttpGet("{id}")]
        public IActionResult GetHTableItem(int id){
            var hTabelItem= _context.HTable.Where(s => s.tabId == id);
            if(hTabelItem == null){
                return NotFound();
            }
            return Ok(hTabelItem);
        }

        //POST : api/htable
        [HttpPost]
        public IActionResult PostHTableItem(HTable hTabel){
            var user=Request.Headers["userId"];
            hTabel.userId=Convert.ToInt32(user);
            _context.HTable.Add(hTabel);
            _context.SaveChanges();
           return GetHTableItem(hTabel.tabId); 
       }

        //PUT : api/htable/n
        [HttpPut("{id}")]
        public IActionResult PutHTableItem(int id,HTable hTabel){
            if(id !=hTabel.tabId){
                return BadRequest() ;
            }
            _context.Entry(hTabel).State= EntityState.Modified;
            _context.SaveChanges();
            return GetHTableItem(hTabel.tabId);
        }
        //DELETE : api/htable/n
        [HttpDelete("{id}")]
        public ActionResult<HTable> DeleteHTableItem(int id){
            var hTabelItem=_context.HTable.Find(id);
            if(hTabelItem == null){
                return NotFound();
            }
            _context.HTable.Remove(hTabelItem);
            _context.SaveChanges();
            return hTabelItem;
        }


    }
}
