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
    public class HTableController : ControllerBase
    {
        private readonly CommandContext _context;
        
        public HTableController(CommandContext context){
            _context=context;
        }

        //GET:  api/htable
        [HttpGet]
        public ActionResult<IEnumerable<HTable>> GetHTable(){
            return _context.HTable;
        }

        //GET : api/htable/n
        [HttpGet("{id}")]
        public ActionResult<HTable> GetHTableItem(int id){
            var hTabelItem= _context.HTable.Find(id);
            if(hTabelItem == null){
                return NotFound();
            }
            return hTabelItem;
        }

        //POST : api/htable
        [HttpPost]
        public ActionResult<HTable> PostHTableItem(HTable hTabel){
            _context.HTable.Add(hTabel);
            _context.SaveChanges();
           return CreatedAtAction("GetHTableItem",new HTable{tabId=hTabel.tabId},hTabel);
       }

        //PUT : api/htable/n
        [HttpPut("{id}")]
        public ActionResult PutHTableItem(int id,HTable hTabel){
            if(id !=hTabel.tabId){
                return BadRequest();
            }
            _context.Entry(hTabel).State= EntityState.Modified;
            _context.SaveChanges();
            return CreatedAtAction("GetHTableItem",new HTable{tabId=hTabel.tabId},hTabel);
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
