using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CMDAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CMDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodQtyController : ControllerBase
    {
        private readonly CommandContext _context;
        
        public FoodQtyController(CommandContext context){
            _context=context;
        }

        //GET:  api/foodQty
        [HttpGet]
        public ActionResult<IEnumerable<FoodQty>> GetFoodQty(){
            return _context.FoodQty;
        }

        //GET : api/foodQty/n
        [HttpGet("{id}")]
        public ActionResult<FoodQty> GetFoodQtyItem(int id){
            var foodQtyItem= _context.FoodQty.Find(id);
            if(foodQtyItem == null){
                return NotFound();
            }
            return foodQtyItem;
        }

        //POST : api/foodQty
        [HttpPost]
        public ActionResult<FoodQty> PostFoodQtyItem(FoodQty foodQty){
            _context.FoodQty.Add(foodQty);
            _context.SaveChanges();
           return CreatedAtAction("GetFoodQtyItem",new FoodQty{foId=foodQty.foId},foodQty);
       }

        //PUT : api/foodQty/n
        [HttpPut("{id}")]
        public ActionResult PutFoodQtyItem(int id,FoodQty foodQty){
            if(id !=foodQty.foId){
                return BadRequest();
            }
            _context.Entry(foodQty).State= EntityState.Modified;
            _context.SaveChanges();
            return CreatedAtAction("GetFoodQtyItem",new FoodQty{foId=foodQty.foId},foodQty);
        }
        //DELETE : api/foodQty/n
        [HttpDelete("{id}")]
        public ActionResult<FoodQty> DeleteFoodQtyItem(int id){
            var foodQtyItem=_context.FoodQty.Find(id);
            if(foodQtyItem == null){
                return NotFound();
            }
            _context.FoodQty.Remove(foodQtyItem);
            _context.SaveChanges();
            return foodQtyItem;
        }


    }
}
