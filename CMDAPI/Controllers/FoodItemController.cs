using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CMDAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CMDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemController : ControllerBase
    {
        private readonly CommandContext _context;
        
        public FoodItemController(CommandContext context){
            _context=context;
        }

        //GET:  api/foodietm
        [HttpGet]
        public ActionResult<IEnumerable<FoodItem>> GetFoodIetm(){
            return _context.FoodItem;
        }

        //GET : api/foodietm/n
        [HttpGet("{id}")]
        public ActionResult<FoodItem> GetFoodIetm(int id){
            var foodItem= _context.FoodItem.Find(id);
            if(foodItem == null){
                return NotFound();
            }
            return foodItem;
        }

        //POST : api/foodietm
        [HttpPost]
        public ActionResult<FoodItem> PostFoodIetm(FoodItem foodItem){
            _context.FoodItem.Add(foodItem);
            _context.SaveChanges();
           return CreatedAtAction("GetFoodIetm",new FoodItem{foId=foodItem.foId},foodItem);
       }

        //PUT : api/foodietm/n
        [HttpPut("{id}")]
        public ActionResult PutFoodIetm(int id,FoodItem foodItem){
            if(id !=foodItem.foId){
                return BadRequest();
            }
            _context.Entry(foodItem).State= EntityState.Modified;
            _context.SaveChanges();
            return CreatedAtAction("GetUserItem",new FoodItem{foId=foodItem.foId},foodItem);
        }

        //DELETE : api/foodietm/n
        [HttpDelete("{id}")]
        public ActionResult<FoodItem> DeleteFoodIetm(int id){
            var foodItem=_context.FoodItem.Find(id);
            if(foodItem == null){
                return NotFound();
            }
            _context.FoodItem.Remove(foodItem);
            _context.SaveChanges();
            return foodItem;
        }
    }
}
